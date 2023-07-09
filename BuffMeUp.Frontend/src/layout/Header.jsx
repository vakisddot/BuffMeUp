import React from "react";
import "./Header.css";

const Header = () => {
    return (
        <header className="App-header">
            <a href="/" className="App-logo">
                <svg
                    xmlns="http://www.w3.org/2000/svg"
                    height="1em"
                    viewBox="0 0 448 512"
                >
                    <path d="M201.4 137.4c12.5-12.5 32.8-12.5 45.3 0l160 160c12.5 12.5 12.5 32.8 0 45.3s-32.8 12.5-45.3 0L224 205.3 86.6 342.6c-12.5 12.5-32.8 12.5-45.3 0s-12.5-32.8 0-45.3l160-160z" />
                </svg>
                <p>
                    <span className="red"> Buff</span>MeUp
                </p>
            </a>

            <nav>
                <a href="about">ABOUT</a>
                <a href="credits">CREDITS</a>
            </nav>

            <div className="Auth-btns">
                <a href="#" className="Auth-btn">
                    Log in
                </a>
                <a href="signup" className="Auth-btn">
                    Sign up
                </a>
                <a href="account">My Account</a>
                <a href="signup">Log out</a>
            </div>
        </header>
    );
};

export default Header;
