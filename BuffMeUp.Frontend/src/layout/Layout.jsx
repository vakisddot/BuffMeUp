import React from "react";
import Header from "./Header";
import Footer from "./Footer";
import "./Layout.css";

const Layout = ({ children }) => {
    return (
        <>
            <Header />

            <div className="App-page">{children}</div>

            <Footer />
        </>
    );
};

export default Layout;