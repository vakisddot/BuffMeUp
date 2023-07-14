import jwt_decode from "jwt-decode";

function isAuthenticated() {
    const token = localStorage.getItem("token");

    if (!token) return false;

    const decodedToken = jwt_decode(token);
    const currentDate = new Date();

    if (decodedToken.exp * 1000 < currentDate.getTime()) return false;

    return true;
}

export default isAuthenticated;
