import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import hasJWT from "../utils";

const RouteGuard = ({ children }) => {
    if (!hasJWT()) {
        return <Navigate to="/login" replace />;
    }
    return children;
};

export default RouteGuard;
