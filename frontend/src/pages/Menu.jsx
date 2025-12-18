import { NavLink } from "react-router-dom";
import { useAuth } from "../pages/AuthContext";

export default function Menu({ cart = [] }) {
    const { user, logout } = useAuth();
    if (!user) return null;

    return (
        <div className="menu">
        {user.role === "client" && (
            <>
            <NavLink to="/" end>Services</NavLink>
            <NavLink to="/appointments">Appointments</NavLink>
            <NavLink to="/cart">Cart ({cart.length})</NavLink>
            </>
        )}

        {user.role === "master" && (
            <>
            <NavLink to="/appointments">Appointments</NavLink>
            <NavLink to="/analytics">Analytics</NavLink>
            </>
        )}

        {user.role === "admin" && (
            <>
            <NavLink to="/clients">Clients</NavLink>
            <NavLink to="/services">Services</NavLink>
            <NavLink to="/appointments">Appointments</NavLink>
            <NavLink to="/analytics">Analytics</NavLink>
            </>
        )}

        <button className="logout-btn" onClick={logout}>Logout</button>
        </div>
    );
}
