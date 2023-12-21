
import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Layout from "./pages/Layout";
import Home from "./pages/Home";

import Login from "./pages/Login";


const App = () => {

    return (

        <>
            
            <Routes>

                <Route path="/SGU/Login" element={<Login></Login >}>

                </Route>
                <Route path="/Home" element={<Home></Home >}>

                </Route>

            </Routes>
            

        </>

    );

}

export default App;