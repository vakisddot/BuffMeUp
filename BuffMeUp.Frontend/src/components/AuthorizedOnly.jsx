import React from "react";
import { Navigate } from "react-router-dom";
import { isAuthenticated, getClaims, isAuthorized } from "../utils";

const AuthorizedOnly = ({ children, role }) => {
    if (!isAuthenticated()) {
        return <Navigate to="/login" replace />;
    } else if (role && !isAuthorized(role)) {
        console.log(
            `Unathorized! Invalid role. Your role was '${
                getClaims().role
            }', but '${role}' is required for access!`
        );
        return <Navigate to="/" replace />;
    }
    return children;
};

export default AuthorizedOnly;
