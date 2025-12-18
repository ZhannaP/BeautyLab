import { useState } from "react";
import { services, masters } from "../data/MockData";

export default function Main({ cart, setCart }) {
    const [selectedMasterId, setSelectedMasterId] = useState(
        Number(localStorage.getItem("selectedMasterId")) || masters[0]?.id
    );

    const addToCart = (service) => {
        setCart((prev) => [...prev, service]);
    };

    const onSelectMaster = (id) => {
        setSelectedMasterId(id);
        localStorage.setItem("selectedMasterId", String(id));
    };

    return (
        <div className="page">
        <div className="card" style={{ maxWidth: 960 }}>
            <h1>Services</h1>

            {/* ===== MASTERS ===== */}
            <div className="section">
            <div className="sectionTitle">Choose master</div>

            <div className="mastersGrid">
                {masters.map((m) => (
                <button
                    key={m.id}
                    type="button"
                    onClick={() => onSelectMaster(m.id)}
                    className={`masterItem ${
                    selectedMasterId === m.id ? "active" : ""
                    }`}
                >
                    <img src={m.image} alt={m.name} />
                    <div className="masterName">{m.name}</div>
                    <div className="masterSpec">{m.specialty}</div>
                </button>
                ))}
            </div>
            </div>

            {/* ===== SERVICES ===== */}
            <div className="section">
            <div className="sectionTitle">Available services</div>

            <div className="servicesGrid">
                {services.map((s) => (
                <div key={s.id} className="serviceCard">
                    <img src={s.image} alt={s.name} />

                    <div className="serviceInfo">
                    <div className="serviceName">{s.name}</div>
                    <div className="serviceMeta">
                        {s.duration} min · {s.price} UAH
                    </div>
                    </div>

                    <button
                    type="button"
                    className="addBtn"
                    onClick={() => addToCart(s)}
                    >
                    Add
                    </button>
                </div>
                ))}
            </div>
            </div>
        </div>
        </div>
    );
}
