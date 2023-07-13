import "./App.css";
import Layout from "./layout/Layout";
import { Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Credits from "./pages/Credits";
import About from "./pages/About";
import SignUp from "./pages/auth/SignUp";
import Account from "./pages/Account";
import RouteGuard from "./components/RouteGuard";
import LogIn from "./pages/auth/LogIn";

function App() {
    return (
        <div className="App">
            <Layout>
                <Routes>
                    <Route path="/" Component={Home}></Route>
                    <Route path="/credits" Component={Credits}></Route>
                    <Route path="/about" Component={About}></Route>
                    <Route path="/signup" Component={SignUp}></Route>
                    <Route path="/login" Component={LogIn}></Route>
                    <Route
                        path="/account"
                        element={
                            <RouteGuard>
                                <Account></Account>
                            </RouteGuard>
                        }
                    ></Route>
                </Routes>
            </Layout>
        </div>
    );
}

export default App;
