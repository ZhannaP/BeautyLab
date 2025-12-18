import { useMemo } from "react";
import { create as createAppointment } from "../api/appointments";
import { create as createPayment } from "../api/payments";
import { useAuth } from "./AuthContext";

export default function Cart({ cart, setCart }) {
    const { user } = useAuth();
    if (!user || user.role !== "client") return null;

    const total = useMemo(
        () => cart.reduce((sum, s) => sum + Number(s.price || 0), 0),
        [cart]
    );

    const removeItem = (id) => {
        setCart((prev) => prev.filter((i) => i.id !== id));
    };

    const clearCart = () => setCart([]);

    const pay = async () => {
        if (cart.length === 0) return;

        const clientId = user.id;
        const masterId = Number(localStorage.getItem("selectedMasterId")) || 1;

        await createPayment({
        amount: total,
        clientId,
        masterId,
        });

        for (const s of cart) {
        await createAppointment({
            serviceId: s.id,
            clientId,
            masterId,
            date: new Date().toISOString(),
            status: "planned",
        });
        }

        clearCart();
        alert("Payment successful");
    };

    return (
        <div className="page">
        <div className="cartCard">
            <h1>Cart</h1>

            {cart.length === 0 ? (
            <p className="emptyText">Your cart is empty.</p>
            ) : (
            <>
                <div className="cartList">
                {cart.map((s) => (
                    <div key={s.id} className="cartItem">
                    <div>
                        <div className="cartName">{s.name}</div>
                        <div className="cartMeta">
                        {s.duration} min · {s.price} UAH
                        </div>
                    </div>

                    <button
                        className="removeBtn"
                        onClick={() => removeItem(s.id)}
                        title="Remove"
                    >
                        ✕
                    </button>
                    </div>
                ))}
                </div>

                <div className="cartFooter">
                <div className="cartTotal">
                    <span>Total</span>
                    <b>{total} UAH</b>
                </div>

                <button className="payBtn" onClick={pay}>
                <span className="payContent">
                    <span className="appleIcon"></span>
                    Pay
                </span>
                </button>
                
                <button className="clearBtn" onClick={clearCart}>
                    Clear cart
                </button>
                </div>
            </>
            )}
        </div>
        </div>
    );
}
