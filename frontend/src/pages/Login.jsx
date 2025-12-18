import { useState } from "react";
import { useAuth } from "./AuthContext";

export default function Login() {
    const { login } = useAuth();
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const submit = (e) => {
        e.preventDefault();
        login(username, password);
    };

    return (
        <div className="page">
        <div className="loginCard">
            <h1>Login</h1>

            <form className="loginForm" onSubmit={submit}>
            <input
                placeholder="Login"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
            />

            <input
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />

            <button type="submit">Sign in</button>
            </form>

            <div className="loginHint">
            <div><b>Test users:</b> admin / anna / maria / client</div>
            </div>
        </div>
        </div>
    );
}
