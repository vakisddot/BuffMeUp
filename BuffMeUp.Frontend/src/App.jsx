import "./App.css";
import Layout from "./layout/Layout";
import { Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Credits from "./pages/Credits";
import About from "./pages/About";
import SignUp from "./pages/auth/SignUp";
import Account from "./pages/Account";
import LogIn from "./pages/auth/LogIn";
import AuthorizedOnly from "./components/AuthorizedOnly";
import UnauthorizedOnly from "./components/UnauthorizedOnly";
import PersonalStats from "./pages/PersonalStats";

function App() {
    return (
        <div className="App">
            <Layout>
                <Routes>
                    <Route path="/" Component={Home}></Route>
                    <Route path="/credits" Component={Credits}></Route>
                    <Route path="/about" Component={About}></Route>
                    <Route
                        path="/account"
                        element={
                            <AuthorizedOnly>
                                <Account></Account>
                            </AuthorizedOnly>
                        }
                    ></Route>
                    <Route
                        path="/personalstats"
                        element={
                            <AuthorizedOnly>
                                <PersonalStats></PersonalStats>
                            </AuthorizedOnly>
                        }
                    ></Route>
                    <Route
                        path="/login"
                        element={
                            <UnauthorizedOnly>
                                <LogIn></LogIn>
                            </UnauthorizedOnly>
                        }
                    ></Route>
                    <Route
                        path="/signup"
                        element={
                            <UnauthorizedOnly>
                                <SignUp></SignUp>
                            </UnauthorizedOnly>
                        }
                    ></Route>
                </Routes>
            </Layout>
        </div>
    );
}

export default App;
