import { Routes, Route, Navigate } from "react-router-dom";
import { useState } from "react";
import { useAuth } from "./pages/AuthContext";

import Menu from "./pages/Menu";
import Login from "./pages/Login";
import Main from "./pages/Main";
import Cart from "./pages/Cart";
import Clients from "./pages/Clients";
import Services from "./pages/Services";
import Appointments from "./pages/Appointments";
import Analytics from "./pages/Analytics";
import Optimization from "./pages/Optimization";

export default function App() {
  const { user } = useAuth();
  const [cart, setCart] = useState([]);

  if (!user) {
    return <Login />;
  }

  return (
    <>
      <Menu cart={cart} />

      <Routes>
        {user.role === "client" && (
  <>
    <Route
      path="/"
      element={<Main cart={cart} setCart={setCart} />}
    />

    <Route
      path="/cart"
      element={<Cart cart={cart} setCart={setCart} />}
        />
          <Route
            path="/appointments"
            element={<Appointments />}
          />

          <Route
            path="*"
            element={<Navigate to="/" />}
          />
        </>
      )}
        {user.role === "master" && (
          <>
            <Route path="/appointments" element={<Appointments />} />
            <Route path="/analytics" element={<Analytics />} />
            <Route path="*" element={<Navigate to="/appointments" />} />
          </>
        )}
        {user.role === "admin" && (
          <>
            <Route path="/clients" element={<Clients />} />
            <Route path="/services" element={<Services />} />
            <Route path="/appointments" element={<Appointments />} />
            <Route path="/analytics" element={<Analytics />} />
            <Route path="/optimization" element={<Optimization />} />
            <Route path="*" element={<Navigate to="/clients" />} />
          </>
        )}
      </Routes>
    </>
  );
}
