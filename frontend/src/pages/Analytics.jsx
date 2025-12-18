import { useEffect, useMemo, useState } from "react";
import { useAuth } from "./AuthContext";

import { getAll as getAppointments } from "../api/appointments";
import { getAll as getPayments } from "../api/payments";
import { getAll as getMasters } from "../api/masters";
import { getAll as getServices } from "../api/services";

const mockAppointments = [
    { id: 1, masterId: 1, serviceId: 1, date: "2025-12-10" },
    { id: 2, masterId: 2, serviceId: 2, date: "2025-12-11" },
    { id: 3, masterId: 1, serviceId: 1, date: "2025-12-12" },
    { id: 4, masterId: 2, serviceId: 3, date: "2025-12-13" },
    { id: 5, masterId: 1, serviceId: 2, date: "2025-12-14" },
    ];

    const mockPayments = [
    { id: 1, masterId: 1, amount: 800, date: "2025-12-10" },
    { id: 2, masterId: 2, amount: 1200, date: "2025-12-11" },
    { id: 3, masterId: 1, amount: 600, date: "2025-12-12" },
    { id: 4, masterId: 2, amount: 900, date: "2025-12-13" },
    { id: 5, masterId: 1, amount: 1500, date: "2025-12-14" },
    ];

    function toDayKey(d) {
    const dt = new Date(d);
    if (Number.isNaN(dt.getTime())) return null;
    return dt.toISOString().slice(0, 10); // YYYY-MM-DD
    }

    function sum(arr) {
    return arr.reduce((acc, x) => acc + x, 0);
    }

    export default function Analytics() {
    const { user } = useAuth();

    const [appointments, setAppointments] = useState([]);
    const [payments, setPayments] = useState([]);
    const [masters, setMasters] = useState([]);
    const [services, setServices] = useState([]);
    const [loading, setLoading] = useState(true);

    const load = async () => {
        setLoading(true);
        try {
        const [a, p, m, s] = await Promise.all([
            getAppointments(),
            getPayments(),
            getMasters(),
            getServices(),
        ]);

        setAppointments(a?.data || []);
        setPayments(p?.data || []);
        setMasters(m?.data || []);
        setServices(s?.data || []);
        } finally {
        setLoading(false);
        }
    };

    useEffect(() => {
        load();
    }, []);

    const stats = useMemo(() => {
        const isMaster = user?.role === "master";
        const userId = user?.id;

        // 1) Fallback на мок-данные, если API пуст
        const baseAppointments =
        (appointments && appointments.length > 0) ? appointments : mockAppointments;

        const basePayments =
        (payments && payments.length > 0) ? payments : mockPayments;

        // 2) Видимые данные (мастер — только своё, админ — всё)
        const visibleAppointments = isMaster
        ? baseAppointments.filter(a => (a.masterId ?? a.MasterId) === userId)
        : baseAppointments;

        const visiblePayments = isMaster
        ? basePayments.filter(p => (p.masterId ?? p.MasterId) === userId)
        : basePayments;

        // Appointments count
        const totalAppointments = visibleAppointments.length;

        // Revenue
        const totalRevenue = sum((visiblePayments || []).map(x => Number(x.amount || 0)));

        // Popular services (by appointment count)
        const serviceCount = new Map();
        for (const a of visibleAppointments) {
        const sid = a.serviceId ?? a.ServiceId;
        if (sid == null) continue;
        serviceCount.set(sid, (serviceCount.get(sid) || 0) + 1);
        }

        const serviceNameById = new Map(
        (services || []).map(s => [s.serviceId ?? s.ServiceId, s.name ?? s.Name])
        );

        const topServices = [...serviceCount.entries()]
        .map(([id, cnt]) => ({
            id,
            name: serviceNameById.get(id) || `Service ${id}`,
            count: cnt,
        }))
        .sort((a, b) => b.count - a.count)
        .slice(0, 5);

        // Master workload (appointments per master) — имеет смысл только для админа
        const masterCount = new Map();
        for (const a of baseAppointments) {
        const mid = a.masterId ?? a.MasterId;
        if (mid == null) continue;
        masterCount.set(mid, (masterCount.get(mid) || 0) + 1);
        }

        const masterNameById = new Map(
        (masters || []).map(m => [
            m.masterId ?? m.MasterId,
            m.userFullName ?? m.UserFullName ?? `Master ${m.masterId ?? m.MasterId}`,
        ])
        );

        const masterLoad = [...masterCount.entries()]
        .map(([id, cnt]) => ({
            id,
            name: masterNameById.get(id) || `Master ${id}`,
            count: cnt,
        }))
        .sort((a, b) => b.count - a.count)
        .slice(0, 5);

        // Daily series last 7 days (по видимым записям мастера или по всем для админа)
        const today = new Date();
        const days = [];
        for (let i = 6; i >= 0; i--) {
        const d = new Date(today);
        d.setDate(today.getDate() - i);
        days.push(d.toISOString().slice(0, 10));
        }

        const apptByDay = new Map(days.map(d => [d, 0]));
        for (const a of visibleAppointments) {
        const key = toDayKey(a.startTime ?? a.StartTime ?? a.date ?? a.Date);
        if (key && apptByDay.has(key)) apptByDay.set(key, apptByDay.get(key) + 1);
        }

        const payByDay = new Map(days.map(d => [d, 0]));
        for (const p of visiblePayments) {
        const key = toDayKey(p.createdAt ?? p.CreatedAt ?? p.date ?? p.Date);
        if (key && payByDay.has(key)) {
            payByDay.set(key, payByDay.get(key) + Number(p.amount || 0));
        }
        }

        const apptSeries = days.map(d => ({ day: d, value: apptByDay.get(d) || 0 }));
        const paySeries = days.map(d => ({ day: d, value: payByDay.get(d) || 0 }));

        const avgAppt = apptSeries.length ? (sum(apptSeries.map(x => x.value)) / apptSeries.length) : 0;
        const avgPay = paySeries.length ? (sum(paySeries.map(x => x.value)) / paySeries.length) : 0;

        return {
        totalAppointments,
        totalRevenue,
        topServices,
        masterLoad,
        apptSeries,
        paySeries,
        forecastAppointmentsNextWeek: Math.round(avgAppt * 7),
        forecastRevenueNextWeek: Math.round(avgPay * 7),
        isMaster,
        };
    }, [appointments, payments, masters, services, user]);

    return (
        <div className="page">
        <div className="card">
            <h1>Analytics</h1>

            {loading ? (
            <p style={{ textAlign: "center", opacity: 0.8 }}>Loading...</p>
            ) : (
            <>
                <ul className="list">
                <li>
                    Total appointments
                    <span>{stats.totalAppointments}</span>
                </li>
                <li>
                    Total revenue
                    <span>{stats.totalRevenue}</span>
                </li>
                <li>
                    Forecast (appointments / next 7 days)
                    <span>{stats.forecastAppointmentsNextWeek}</span>
                </li>
                <li>
                    Forecast (revenue / next 7 days)
                    <span>{stats.forecastRevenueNextWeek}</span>
                </li>
                </ul>

                <h2 style={{ textAlign: "center", margin: "28px 0 14px", fontSize: 18, opacity: 0.9 }}>
                Top services
                </h2>
                <ul className="list">
                {stats.topServices.map(s => (
                    <li key={s.id}>
                    {s.name}
                    <span>{s.count}</span>
                    </li>
                ))}
                {stats.topServices.length === 0 && (
                    <li>
                    No data yet
                    <span>—</span>
                    </li>
                )}
                </ul>

                {/* Master workload показываем только админу */}
                {!stats.isMaster && (
                <>
                    <h2 style={{ textAlign: "center", margin: "28px 0 14px", fontSize: 18, opacity: 0.9 }}>
                    Master workload
                    </h2>
                    <ul className="list">
                    {stats.masterLoad.map(m => (
                        <li key={m.id}>
                        {m.name}
                        <span>{m.count}</span>
                        </li>
                    ))}
                    {stats.masterLoad.length === 0 && (
                        <li>
                        No data yet
                        <span>—</span>
                        </li>
                    )}
                    </ul>
                </>
                )}

                <h2 style={{ textAlign: "center", margin: "28px 0 14px", fontSize: 18, opacity: 0.9 }}>
                Last 7 days (appointments)
                </h2>
                <ul className="list">
                {stats.apptSeries.map(x => (
                    <li key={x.day}>
                    {x.day}
                    <span>{x.value}</span>
                    </li>
                ))}
                </ul>
            </>
            )}
        </div>
        </div>
    );
}
