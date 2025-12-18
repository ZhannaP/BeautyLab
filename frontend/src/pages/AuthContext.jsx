import { createContext, useContext, useState } from "react";

const AuthContext = createContext(null);

const USERS_BY_ROLE = {
    admin: {
        id: 0,
        role: "admin",
        name: "Administrator",
    },

    anna: {
        id: 1,          
        role: "master",
        name: "Anna",
    },

    maria: {
        id: 2,          
        role: "master",
        name: "Maria",
    },

    client: {
        id: 100,
        role: "client",
        name: "Client",
    },
    };


    export function AuthProvider({ children }) {
    const [user, setUser] = useState(() => {
        const saved = localStorage.getItem("user");
        return saved ? JSON.parse(saved) : null;
    });

    const login = (role) => {
        const newUser = USERS_BY_ROLE[role];
        setUser(newUser);
        localStorage.setItem("user", JSON.stringify(newUser));
    };

    const logout = () => {
        setUser(null);
        localStorage.removeItem("user");
    };

    return (
        <AuthContext.Provider value={{ user, login, logout }}>
        {children}
        </AuthContext.Provider>
    );
    }

    export function useAuth() {
    return useContext(AuthContext);
    }
