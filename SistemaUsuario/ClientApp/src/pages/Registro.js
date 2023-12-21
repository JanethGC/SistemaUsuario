import "bootstrap/dist/css/bootstrap.min.css";
import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { registerUser } from "../Store/userSlice"; // Assuming a registerUser action exists

const Registro = () => {
    // States for all form fields
    const [cedula, setCedula] = useState("");
    const [nombres, setNombres] = useState("");
    const [apellidos, setApellidos] = useState("");
    const [edad, setEdad] = useState("");
    const [email, setEmail] = useState("");
    const [telefono, setTelefono] = useState("");


    return (
        <div className="container">
            <div className="row">
                <div className="col-md-6 offset-md-3">
                    <div className="card">
                        <div className="card-body">
                            <h1 className="card-title text-center">Registro de Usuario</h1>
                            <form>
                                {/* Fields for cedula, nombres, apellidos, edad, email, telefono */}
                                <div className="mb-3">
                                    <label htmlFor="cedula" className="form-label">
                                        Cédula
                                    </label>
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="cedula"
                                        name="cedula"
                                        required
                                        value={cedula}
                                        onChange={(e) => setCedula(e.target.value)}
                                    />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="nombres" className="form-label">
                                        Nombres
                                    </label>
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="nombres"
                                        name="nombres"
                                        required
                                        value={nombres}
                                        onChange={(e) => setNombres(e.target.value)}
                                    />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="apellidos" className="form-label">
                                        Apellidos
                                    </label>
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="apellidos"
                                        name="apellidos"
                                        required
                                        value={apellidos}
                                        onChange={(e) => setApellidos(e.target.value)}
                                    />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="edad" className="form-label">
                                        Edad
                                    </label>
                                    <input
                                        type="number"
                                        className="form-control"
                                        id="edad"
                                        name="edad"
                                        required
                                        value={edad}
                                        onChange={(e) => setEdad(e.target.value)}
                                    />
                                </div>
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
                                    <label htmlFor="text" className="form-label">
                                        Telefono
                                    </label>
                                    <input
                                        type="telefono"
                                        className="form-control"
                                        id="telefono"
                                        name="telefono"
                                        required
                                        value={telefono}
                                        onChange={(e) => setTelefono(e.target.value)}
                                    />
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>

      );                         
};
export default Registro;                             