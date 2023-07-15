import jwt_decode from "jwt-decode";

export function isAuthenticated() {
    const token = localStorage.getItem("token");
    if (!token) return false;

    const decodedToken = jwt_decode(token);
    const currentDate = new Date();

    if (decodedToken.exp * 1000 < currentDate.getTime()) return false;

    return true;
}

export function getClaims() {
    const token = localStorage.getItem("token");
    if (!token) return null;

    return jwt_decode(token);
}

export function isAuthorized(role) {
    const claims = getClaims();

    if (
        claims &&
        claims.role &&
        claims.role.toLowerCase() === role.toLowerCase()
    )
        return true;

    return false;
}
