import axios from "axios";

const API_BASE = import.meta.env.VITE_API_BASE_URL || "http://localhost:5000";
const LS_KEY = "payments_mock";

export async function getAll() {
    try {
        return await axios.get(`${API_BASE}/payments`);
    } catch {
        const data = JSON.parse(localStorage.getItem(LS_KEY) || "[]");
        return { data };
    }
    }

export async function create(payment) {
    try {
        return await axios.post(`${API_BASE}/payments`, payment);
    } catch {
        const data = JSON.parse(localStorage.getItem(LS_KEY) || "[]");
        const newItem = {
        id: Date.now(),
        createdAt: new Date().toISOString(),
        ...payment,
        };
        data.push(newItem);
        localStorage.setItem(LS_KEY, JSON.stringify(data));
        return { data: newItem };
    }
}
