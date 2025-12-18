import { useEffect, useMemo, useState } from "react";
import { getAll } from "../api/appointments";
import { services, masters } from "../data/MockData";
import { useAuth } from "./AuthContext";

const mockAppointments = [
    {
        id: 1,
        serviceId: 1,
        masterId: 1,
        clientId: 100,
        date: new Date().toISOString(),
        status: "planned",
    },
    {
        id: 2,
        serviceId: 2,
        masterId: 2,
        clientId: 100,
        date: new Date(Date.now() + 3600_000).toISOString(),
        status: "confirmed",
    },
    {
        id: 3,
        serviceId: 3,
        masterId: 1,
        clientId: 101,
        date: new Date(Date.now() - 7200_000).toISOString(),
        status: "completed",
    },
    ];

    export default function Appointments() {
    const { user } = useAuth();
    const [appointments, setAppointments] = useState([]);

    useEffect(() => {
        getAll().then((r) => setAppointments(r.data || []));
    }, []);

    const data =
        appointments.length > 0 ? appointments : mockAppointments;

    const serviceById = useMemo(
        () => new Map(services.map((s) => [s.id, s.name])),
        []
    );

    const masterById = useMemo(
        () => new Map(masters.map((m) => [m.id, m.name])),
        []
    );

    const visibleAppointments = useMemo(() => {
        if (user.role === "admin") return data;

        if (user.role === "master") {
        return data.filter(
            (a) => (a.masterId ?? a.MasterId) === user.id
        );
        }

        if (user.role === "client") {
        return data.filter(
            (a) => (a.clientId ?? a.ClientId) === user.id
        );
        }

        return [];
    }, [data, user]);

    const changeStatus = (id, status) => {
        if (!confirm(`Change status to "${status}"?`)) return;

        setAppointments((prev) =>
        prev.map((a) =>
            a.id === id ? { ...a, status } : a
        )
        );
    };

    return (
        <div className="page">
        <div className="card">
            <h1>Appointments</h1>

            {visibleAppointments.length === 0 ? (
            <p style={{ opacity: 0.7 }}>No appointments yet.</p>
            ) : (
            <table
                style={{
                width: "100%",
                borderCollapse: "collapse",
                marginTop: 16,
                }}
            >
                <thead>
                <tr
                    style={{
                    textAlign: "left",
                    borderBottom: "1px solid rgba(255,255,255,0.2)",
                    }}
                >
                    <th style={{ padding: 8 }}>Service</th>
                    <th style={{ padding: 8 }}>Master</th>
                    <th style={{ padding: 8 }}>Date</th>
                    <th style={{ padding: 8 }}>Status</th>
                    <th style={{ padding: 8 }}>Actions</th>
                </tr>
                </thead>

                <tbody>
                {visibleAppointments.map((a) => {
                    const serviceName =
                    serviceById.get(a.serviceId) ||
                    `Service ${a.serviceId}`;

                    const masterName =
                    masterById.get(a.masterId) ||
                    `Master ${a.masterId}`;

                    return (
                    <tr
                        key={a.id}
                        style={{
                        borderBottom:
                            "1px solid rgba(255,255,255,0.08)",
                        }}
                    >
                        <td style={{ padding: 8 }}>{serviceName}</td>
                        <td style={{ padding: 8 }}>{masterName}</td>
                        <td style={{ padding: 8 }}>
                        {new Date(a.date).toLocaleString()}
                        </td>
                        <td style={{ padding: 8 }}>
                        <b>{a.status}</b>
                        </td>
                        <td style={{ padding: 8 }}>
                        {(user.role === "admin" ||
                            user.role === "master") && (
                            <>
                            {a.status === "planned" && (
                                <>
                                <button
                                    onClick={() =>
                                    changeStatus(a.id, "confirmed")
                                    }
                                    style={{ marginRight: 6 }}
                                >
                                    Confirm
                                </button>
                                <button
                                    onClick={() =>
                                    changeStatus(a.id, "cancelled")
                                    }
                                >
                                    Cancel
                                </button>
                                </>
                            )}

                            {a.status === "confirmed" && (
                                <button
                                onClick={() =>
                                    changeStatus(a.id, "completed")
                                }
                                >
                                Complete
                                </button>
                            )}
                            </>
                        )}

                        {user.role === "client" && (
                            <span style={{ opacity: 0.6 }}>—</span>
                        )}
                        </td>
                    </tr>
                    );
                })}
                </tbody>
            </table>
            )}
        </div>
        </div>
    );
}
