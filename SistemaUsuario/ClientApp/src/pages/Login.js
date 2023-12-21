import "bootstrap/dist/css/bootstrap.min.css";
import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux"; // Import useSelector
import { useNavigate } from "react-router-dom"; // Update import path
import { loginUser } from "../Store/userSlice";

const Login = () => {
    // States
    const [email, setEmail] = useState(''); // Corrected syntax
    const [password, setPassword] = useState(''); // Corrected syntax

    // Redux state
    const { loading, error } = useSelector((state) => state.user); // Corrected syntax

    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleLoginEvent = (e) => {
        e.preventDefault();
        let userCredential = {
            email,
            password
        };

        dispatch(loginUser(userCredential)).then((result) => {
            if (result.payload) {
                setEmail('');
                setPassword('');
                navigate('/');
            }
        });
    };

    return (
        <div className="container">
            <div className="row">
                <div className="col-md-6 offset-md-3">
                    <div className="card">
                        <div className="card-body">
                            <h1 className="card-title text-center">Inicia Sesion</h1>
                            <form onSubmit={handleLoginEvent}>
                                <div className="mb-3">
                                    <label htmlFor="email" className="form-label">
                                        Email
                                    </label>
                                    <input
                                        type="email"
                                        className="form-control"
                                        id="email"
                                        name="email"
                                        required
                                        value={email}
                                        onChange={(e) => setEmail(e.target.value)}
                                    />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="password" className="form-label">
                                        Password
                                    </label>
                                    <input
                                        type="password"
                                        className="form-control"
                                        id="password"
                                        name="password"
                                        required
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                    />
                                </div>
                                <div className="text-center">
                                    <button type="submit" className="btn btn-primary">
                                        Ingresar {loading ? 'Cargando...' : ''}
                                    </button>
                                </div>

                                {error && (
                                    <div className="alert alert-danger" role="alert">
                                        {error}
                                    </div>
                                )}
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Login;
