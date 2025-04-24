import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../../services/api";
import "./style.css";

export default function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();
        try {
            const response = await api.post("/tokenAuth", { email, password });
            localStorage.setItem("token", response.data.token);
            navigate("/home");
        } catch (error) {
            alert("Login inválido!", error);
        }
    };

    return (
        <div className="container">
            <form onSubmit={handleLogin}>
                <h1>Login </h1>
                <input
                    placeholder="Login"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <input
                    type="password"
                    placeholder="Senha"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <button type="submit">Entrar</button>
            </form>
        </div>
    );

}
