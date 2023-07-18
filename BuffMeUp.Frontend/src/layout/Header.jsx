import React from "react";
import "./Header.css";
import hasJWT from "../utils";
import { Link, useNavigate } from "react-router-dom";
import { isAuthenticated, isAuthorized } from "../utils";

const Header = () => {
    const navigate = useNavigate();

    return (
        <header className="App-header">
            <Link to="/" className="App-logo">
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
            </Link>

            <nav>
                {isAuthenticated() && (
                    <>
                        <Link to="/about">MEALS</Link>
                        <Link className="Dropdown-btn">
                            WORKOUTS
                            <div className="Dropdown-menu">
                                <Link to="/allworkouts">View all</Link>
                                <a href="#" className="Dropdown-btn">
                                    Exercises
                                    <div className="Dropdown-menu">
                                        <Link to="#">Create new</Link>
                                    </div>
                                </a>
                            </div>
                        </Link>
                    </>
                )}
                <Link to="/about">ABOUT</Link>
                <Link to="/credits">CREDITS</Link>
                {isAuthorized("admin") && (
                    <>
                        <Link to="/admin">ADMIN</Link>
                    </>
                )}
            </nav>

            <div className="Auth-btns">
                {!isAuthenticated() ? (
                    <>
                        <Link to="/login" className="Auth-btn">
                            Log in
                        </Link>
                        <Link to="/signup" className="Auth-btn">
                            Sign up
                        </Link>
                    </>
                ) : (
                    <>
                        <Link to="account">My Account</Link>
                        <Link
                            to="/"
                            onClick={() => {
                                localStorage.removeItem("token");
                            }}
                            href="#"
                        >
                            Log out
                        </Link>
                    </>
                )}
            </div>
        </header>
    );
};

export default Header;
