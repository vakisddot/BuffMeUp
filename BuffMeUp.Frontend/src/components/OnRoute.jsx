import React, { useEffect } from "react";
import { Navigate } from "react-router-dom";

function OnRoute({ callback, redirect }) {
    useEffect(() => {
        callback();

        return () => {};
    }, []);

    return <Navigate to={redirect} replace />;
}

export default OnRoute;
