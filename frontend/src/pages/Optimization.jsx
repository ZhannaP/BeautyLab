import { useEffect, useMemo, useState } from "react";
import { getAll as getAppointments } from "../api/appointments";
import { getAll as getMasters } from "../api/masters";

function toDayKey(d) {
    const dt = new Date(d);
    if (Number.isNaN(dt.getTime())) return null;
    return dt.toISOString().slice(0, 10);
    }

    export default function Optimization() {
    const [appointments, setAppointments] = useState([]);
    const [masters, setMasters] = useState([]);
    const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
    const [limit, setLimit] = useState("6"); // порог загрузки
    const [loading, setLoading] = useState(true);

    const load = async () => {
        setLoading(true);
        try {
        const [a, m] = await Promise.all([getAppointments(), getMasters()]);
        setAppointments(a.data || []);
        setMasters(m.data || []);
        } finally {
        setLoading(false);
        }
    };

    useEffect(() => {
        load();
    }, []);

    const recommendations = useMemo(() => {
        const day = date;
        const max = Number(limit || 6);

        const byMaster = new Map();
        for (const ap of appointments) {
        const key = toDayKey(ap.startTime ?? ap.StartTime ?? ap.date ?? ap.Date);
        if (key !== day) continue;

        const mid = ap.masterId ?? ap.MasterId;
        if (mid == null) continue;

        byMaster.set(mid, (byMaster.get(mid) || 0) + 1);
        }

        const masterNameById = new Map(
        masters.map(m => [
            m.masterId ?? m.MasterId,
            m.userFullName ?? m.UserFullName ?? `Master ${m.masterId ?? m.MasterId}`
        ])
        );

        const loads = [...byMaster.entries()].map(([id, count]) => ({
        id,
        name: masterNameById.get(id) || `Master ${id}`,
        count
        }));

        loads.sort((a, b) => b.count - a.count);

        const overloaded = loads.filter(x => x.count > max);
        const underloaded = loads.filter(x => x.count <= max).slice(-3);

        const actions = overloaded.map(o => ({
        master: o,
        suggestion:
            underloaded.length > 0
            ? `Consider moving 1–2 appointments from "${o.name}" to a less loaded master (e.g., ${underloaded
                .map(u => `"${u.name}"`)
                .join(", ")}).`
            : `Consider limiting new bookings for "${o.name}" or adding an extra shift.`
        }));

        return { loads, overloaded, actions };
    }, [appointments, masters, date, limit]);

    return (
        <div className="page">
        <div className="card">
            <h1>Optimization</h1>

            <div className="form">
            <input type="date" value={date} onChange={e => setDate(e.target.value)} />
            <input
                placeholder="Max appointments per master/day"
                value={limit}
                onChange={e => setLimit(e.target.value)}
            />
            <button onClick={load}>Recalculate</button>
            </div>

            {loading ? (
            <p style={{ textAlign: "center", opacity: 0.8 }}>Loading...</p>
            ) : (
            <>
                <h2 style={{ textAlign: "center", margin: "10px 0 14px", fontSize: 18, opacity: 0.9 }}>
                Workload for {date}
                </h2>

                <ul className="list">
                {recommendations.loads.map(x => (
                    <li key={x.id}>
                    {x.name}
                    <span>{x.count}</span>
                    </li>
                ))}
                {recommendations.loads.length === 0 && (
                    <li>
                    No data for this day
                    <span>—</span>
                    </li>
                )}
                </ul>

                <h2 style={{ textAlign: "center", margin: "28px 0 14px", fontSize: 18, opacity: 0.9 }}>
                Recommendations
                </h2>

                <ul className="list">
                {recommendations.actions.map((a, idx) => (
                    <li key={idx} style={{ alignItems: "flex-start" }}>
                    <div style={{ maxWidth: 300, lineHeight: 1.35 }}>
                        <div style={{ fontWeight: 600 }}>{a.master.name}</div>
                        <div style={{ opacity: 0.85 }}>{a.suggestion}</div>
                    </div>
                    <span>{a.master.count}</span>
                    </li>
                ))}
                {recommendations.actions.length === 0 && (
                    <li>
                    No overload detected
                    <span>OK</span>
                    </li>
                )}
                </ul>
            </>
            )}
        </div>
        </div>
    );
}
