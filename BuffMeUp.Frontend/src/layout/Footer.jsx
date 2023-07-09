import React from "react";
import "./Footer.css";

const Footer = () => {
    return (
        <footer className="App-footer">
            <nav>
                <a href="/">HOME</a>
                <a href="about">ABOUT</a>
                <a href="credits">CREDITS</a>
            </nav>

            <div>
                <p>&copy; BuffMeUp 2023 - {new Date().getFullYear()}.</p>
                <p>All rights reserved.</p>
            </div>
        </footer>
    );
};

export default Footer;
