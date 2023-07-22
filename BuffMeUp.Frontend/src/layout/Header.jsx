import React from "react";
import "./Header.css";
import { Link, useNavigate } from "react-router-dom";
import { isAuthenticated, isAuthorized } from "../utils";
import Logo from "../components/Logo";

const Header = () => {
    const navigate = useNavigate();

    return (
        <header className="App-header">
            <Logo />

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
                                        <Link to="/newexercise">
                                            Create new
                                        </Link>
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
