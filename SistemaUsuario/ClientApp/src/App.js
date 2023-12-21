
import React from "react";
import { Routes, Route } from 'react-router-dom';
import Layout from "./pages/Layout";
import Login from "./pages/Login";


const App = () => {

    return (

        <>
            
            <Routes>

                <Route path="/SGU/Login" element={<Login></Login> }>

                </Route>

            </Routes>
            

        </>

    );

}

export default App;