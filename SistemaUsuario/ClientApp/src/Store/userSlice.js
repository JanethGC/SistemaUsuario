﻿import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios"; // Import axios separately

const hostName = "your_host_name_here"; // Define your hostName variable

export const loginUser = createAsyncThunk(
    'user/log',
    async (userCredentials) => {
        try {
            const request = await axios.post(`${hostName}api/usuario/login`, userCredentials);
            const response = request.data.data;
            localStorage.setItem("user", JSON.stringify(response));
            return response;
        } catch (error) {
            throw error; // 
        }
    }
);

const userSlice = createSlice({
    name: 'user',
    initialState: {
        loading: false,
        user: null,
        error: null
    },
    extraReducers: (builder) => {
        builder
            .addCase(loginUser.pending, (state) => {
                state.loading = true;
                state.user = null;
                state.error = null;
            })
            .addCase(loginUser.fulfilled, (state, action) => {
                state.loading = false;
                state.user = action.payload;
                state.error = null;
            })
            .addCase(loginUser.rejected, (state, action) => {
                state.loading = false;
                state.user = null;
                console.log(action.error.message);
                if (action.error.message === "Request failed with status code 401") {
                    state.error = "Acceso denegado! Credenciales incorrectas";
                } else {
                    state.error = action.error.message;
                }
            });
    }
});

export default userSlice.reducer;
