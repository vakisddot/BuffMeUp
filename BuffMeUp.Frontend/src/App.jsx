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
import AllWorkouts from "./pages/workout/AllWorkouts";
import AllMeals from "./pages/meals/AllMeals";
import AdminPanel from "./pages/admin/AdminPanel";
import WorkoutDetails from "./pages/workout/WorkoutDetails";
import OnRoute from "./components/OnRoute";
import startNewWorkout from "./pages/workout/workoutUtils";
import NewExercise from "./pages/workout/NewExercise";
import MealDetails from "./pages/meals/MealDetails";
import NewFood from "./pages/meals/NewFood";

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
                        path="/allworkouts"
                        element={
                            <AuthorizedOnly>
                                <AllWorkouts></AllWorkouts>
                            </AuthorizedOnly>
                        }
                    ></Route>
                    <Route
                        path="/workoutnew"
                        element={
                            <AuthorizedOnly>
                                <OnRoute
                                    callback={startNewWorkout}
                                    redirect="/workoutform"
                                ></OnRoute>
                            </AuthorizedOnly>
                        }
                    ></Route>
                    <Route
                        path="/workoutdetails/:id"
                        element={
                            <AuthorizedOnly>
                                <WorkoutDetails></WorkoutDetails>
                            </AuthorizedOnly>
                        }
                    ></Route>
                    <Route
                        path="/newexercise"
                        element={
                            <AuthorizedOnly>
                                <NewExercise></NewExercise>
                            </AuthorizedOnly>
                        }
                    ></Route>

                    <Route
                        path="/allmeals"
                        element={
                            <AuthorizedOnly>
                                <AllMeals></AllMeals>
                            </AuthorizedOnly>
                        }
                    ></Route>
                    <Route
                        path="/mealdetails/:id"
                        element={
                            <AuthorizedOnly>
                                <MealDetails></MealDetails>
                            </AuthorizedOnly>
                        }
                    ></Route>
                    <Route
                        path="/newfood"
                        element={
                            <AuthorizedOnly>
                                <NewFood></NewFood>
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

                    <Route
                        path="/admin"
                        element={
                            <AuthorizedOnly role="admin">
                                <AdminPanel></AdminPanel>
                            </AuthorizedOnly>
                        }
                    ></Route>
                </Routes>
            </Layout>
        </div>
    );
}

export default App;
