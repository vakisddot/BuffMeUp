import React from "react";
import { Navigate } from "react-router-dom";
import hasJWT from "../utils";

const AuthorizedOnly = ({ children }) => {
    if (!hasJWT()) {
        return <Navigate to="/login" replace />;
    }
    return children;
};

export default AuthorizedOnly;
