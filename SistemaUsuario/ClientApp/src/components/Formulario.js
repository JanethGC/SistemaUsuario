// Importar el archivo de estilos de Bootstrap
import "bootstrap/dist/css/bootstrap.min.css";

// Función de componente Login

const Login = () => {
    return (
        <form>

            {/*Utiliza 'className' en lugar de 'class' en JSX */}

            <div className="mb-3">

                <label htmlFor="cedula" className="form-label"> Cedula </label>
                <input type="text" className="form-control" id="cedula" placeholder=" 10 digitos" />

                <label htmlFor="nombres" className="form-label"> Nombres </label>
                <input type="text" className="form-control" id="nombres" placeholder="Tus nombres" />

                <label htmlFor="apellidos" className="form-label"> Apellidos </label>
                <input type="text" className="form-control" id="apellidos" placeholder="Tus apellidos" />

                <label htmlFor="edad" className="form-label"> Edad </label>
                <input type="number" className="form-control" id="edad" placeholder=" Su edad" />

                <label htmlFor="email" className="form-label"> Email address </label>
                <input type="email" className="form-control" id="email" placeholder="correo@example.com" />

                <label htmlFor="telefono" className="form-label"> Edad </label>
                <input type="text" className="form-control" id="telefono" placeholder="Su numero telefonico" />


            </div>

            <button type="submit" className="btn btn-primary">
                Enviar
            </button>

        </form>
    );
};

export default Login;
