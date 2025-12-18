import { Navigate } from "react-router-dom";
import { useAuth } from "../pages/AuthContext";

export default function RequireRole({ allowed, children }) {
    const { user } = useAuth();

    if (!allowed.includes(user.role)) {
        return <Navigate to="/" replace />;
    }

    return children;
}
