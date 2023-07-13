function hasJWT() {
    return localStorage.getItem("token") ? true : false;
}

export default hasJWT;
