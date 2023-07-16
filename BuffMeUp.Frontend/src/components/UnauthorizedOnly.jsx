import React from "react";
import { Navigate } from "react-router-dom";
import { isAuthenticated } from "../utils";

const UnauthorizedOnly = ({ children }) => {
    if (isAuthenticated()) {
        return <Navigate to="/account" replace />;
    }

    return children;
};

export default UnauthorizedOnly;
