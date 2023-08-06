import jwt_decode from "jwt-decode";

export function isAuthenticated() {
    const token = localStorage.getItem("token");
    if (!token) return false;

    const decodedToken = jwt_decode(token);
    const currentDate = new Date();

    if (decodedToken.exp * 1000 < currentDate.getTime()) {
        localStorage.removeItem("token");
        return false;
    }

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
        claims.userRole &&
        claims.userRole.toLowerCase() === role.toLowerCase()
    )
        return true;

    return false;
}

export function fetchAuthenticated(endpoint, method, body) {
    return fetch(endpoint, {
        method: method || "GET",
        headers: {
            "Content-Type": "application/json",
            Authorization: "Bearer " + localStorage.getItem("token"),
        },
        body: body,
    });
}

export function getQueryString(searchParams) {
    const params = [];

    searchParams.forEach((value, key) => {
        params.push([key, value]);
    });

    const joinedParams = params
        .map(([key, value]) => `${key}=${value}`)
        .join("&");

    return joinedParams;
}

export function setTitle(title) {
    document.title = `${title} - BuffMeUp`;
}
