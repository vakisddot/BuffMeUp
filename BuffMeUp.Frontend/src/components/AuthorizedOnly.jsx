import React from "react";
import { Navigate } from "react-router-dom";
import { isAuthenticated, getClaims, isAuthorized } from "../utils";
import { toast } from "react-toastify";

const AuthorizedOnly = ({ children, role }) => {
    if (!isAuthenticated()) {
        const errorMessage = "This action requires you to be logged in!";
        console.log(errorMessage);
        toast.error(errorMessage);

        return <Navigate to="/login" replace />;
    } else if (role && !isAuthorized(role)) {
        const errorMessage = `Unathorized! Invalid role. Your role was '${
            getClaims().role
        }', but '${role}' is required for access!`;
        console.log(errorMessage);
        toast.error(errorMessage);

        return <Navigate to="/" replace />;
    }

    return children;
};

export default AuthorizedOnly;
