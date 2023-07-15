import React from "react";
import "./Footer.css";
import { Link } from "react-router-dom";

const Footer = () => {
    return (
        <footer className="App-footer">
            <nav>
                <Link to="/">HOME</Link>
                <Link to="/about">ABOUT</Link>
                <Link to="/credits">CREDITS</Link>
            </nav>

            <div>
                <p>&copy; BuffMeUp 2023 - {new Date().getFullYear()}.</p>
                <p>All rights reserved.</p>
            </div>
        </footer>
    );
};

export default Footer;
