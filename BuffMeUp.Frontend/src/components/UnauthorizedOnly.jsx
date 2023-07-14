import React from "react";
import { Navigate } from "react-router-dom";
import hasJWT from "../utils";

const UnauthorizedOnly = ({ children }) => {
    if (hasJWT()) {
        return <Navigate to="/account" replace />;
    }
    return children;
};

export default UnauthorizedOnly;
