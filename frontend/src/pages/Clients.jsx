import { useEffect, useMemo, useState } from "react";
import { getAll, create, remove } from "../api/clients";

/* ===== MOCK CLIENTS FOR VISIBILITY ===== */
    const mockClients = [
    { id: 1, name: "Anna Magical" },
    { id: 2, name: "Marta Popik" },
    { id: 3, name: "Olena Kovalenko" },
    { id: 4, name: "Sofia Melnyk" },
    ];

    export default function Clients() {
    const [list, setList] = useState([]);
    const [name, setName] = useState("");
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

    const visibleClients = useMemo(
        () => (list.length > 0 ? list : mockClients),
        [list]
    );

    const addClient = async () => {
        if (!name.trim()) return;

        await create({ name: name.trim() });
        setName("");
        load();
    };

    const removeClient = async (id) => {
        if (!confirm("Delete this client?")) return;
        await remove(id);
        load();
    };

    return (
        <div className="page">
        <div className="card">
            <h1>Clients</h1>

            {/* ADD FORM */}
            <div className="form">
            <input
                placeholder="Client name"
                value={name}
                onChange={(e) => setName(e.target.value)}
            />

            <button onClick={addClient}>Add</button>
            </div>

            {/* CLIENTS LIST */}
            {loading && list.length === 0 ? (
            <p style={{ opacity: 0.7 }}>Loading clients…</p>
            ) : (
            <ul className="list">
                {visibleClients.map((c) => (
                <li key={c.id}>
                    <span>{c.name}</span>

                    {/* delete only real clients */}
                    {list.length > 0 && (
                    <button
                        onClick={() => removeClient(c.id)}
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
