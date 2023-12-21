import React from 'react';
import ReactDOM from 'react-dom';

import App from './App';

import { BrowserRouter } from "react-router-dom";

import { Provider } from 'react-redux';  //Este componente permite que la aplicación React acceda al store de Redux.
import store from './Store'; // Importando el store



//Vamos a crear un root / elemento raiz donde deseamos que se
//renderize / pinte nuestros componentes

//const routes = useRoutes();

const root = ReactDOM.createRoot(document.getElementById("root"));

root.render(

    <React.StrictMode>
            <BrowserRouter>
                <App />
            </BrowserRouter>
    </React.StrictMode>

  
);


