import { useEffect, useState, useMemo } from "react";
import { getAll, create, remove } from "../api/services";

/* ===== MOCK SERVICES FOR VISIBILITY ===== */
const mockServices = [
    { id: 1, name: "Haircut", duration: 45 },
    { id: 2, name: "Hair coloring", duration: 120 },
    { id: 3, name: "Manicure", duration: 60 },
    { id: 4, name: "Facial treatment", duration: 90 },
    ];

    export default function Services() {
    const [list, setList] = useState([]);
    const [name, setName] = useState("");
    const [duration, setDuration] = useState("");
    const [loading, setLoading] = useState(true);

    const load = async () => {
        setLoading(true);
        try {
        const res = await getAll();
        setList(res.data || []);
        } finally {
        setLoading(false);
        }
    };

    useEffect(() => {
        load();
    }, []);

    const visibleServices = useMemo(
        () => (list.length > 0 ? list : mockServices),
        [list]
    );

    const add = async () => {
        if (!name.trim() || !duration) return;

        await create({
        name: name.trim(),
        duration: Number(duration),
        });

        setName("");
        setDuration("");
        load();
    };

    const removeService = async (id) => {
        if (!confirm("Delete this service?")) return;
        await remove(id);
        load();
    };

    return (
        <div className="page">
        <div className="card">
            <h1>Services</h1>

            {/* ADD FORM */}
            <div className="form">
            <input
                placeholder="Service name"
                value={name}
                onChange={(e) => setName(e.target.value)}
            />

            <input
                type="number"
                min="1"
                placeholder="Duration (min)"
                value={duration}
                onChange={(e) => setDuration(e.target.value)}
            />

            <button onClick={add}>Add service</button>
            </div>

            {/* SERVICES LIST */}
            {loading && list.length === 0 ? (
            <p style={{ opacity: 0.7 }}>Loading services…</p>
            ) : (
            <ul className="list">
                {visibleServices.map((s) => (
                <li key={s.id}>
                    <div>
                    <div style={{ fontWeight: 600 }}>{s.name}</div>
                    <div style={{ fontSize: 13, opacity: 0.7 }}>
                        {s.duration} min
                    </div>
                    </div>

                    {/* delete only real services */}
                    {list.length > 0 && (
                    <button
                        onClick={() => removeService(s.id)}
                        title="Delete"
                    >
                        ✕
                    </button>
                    )}
                </li>
                ))}
            </ul>
            )}
        </div>
        </div>
    );
}
