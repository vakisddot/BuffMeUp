import React from "react";
import Header from "./Header";
import Footer from "./Footer";
import "./Layout.css";
import { ToastContainer } from "react-toastify";

const Layout = ({ children }) => {
    return (
        <>
            <ToastContainer position="bottom-right" autoClose={2000} />

            <Header />

            <div className="App-page">{children}</div>

            <Footer />
        </>
    );
};

export default Layout;
