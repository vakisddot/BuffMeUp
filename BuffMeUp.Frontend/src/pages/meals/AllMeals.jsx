import React, { useEffect, useState } from "react";
import "./AllMeals.css";
import { Link } from "react-router-dom";
import { useSearchParams } from "react-router-dom";
import {
    fetchAuthenticated,
    getClaims,
    getQueryString,
    setTitle,
} from "../../utils";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import InputForm from "../../components/InputForm";
import { displayPopup, hidePopup } from "../../components/popupFormUtils";
import { addNewMeal, calculateCalories } from "./mealUtils";

function AllMeals() {
    useEffect(() => setTitle("Meals"), []);

    const [searchParams] = useSearchParams();

    const today = new Date().toISOString().split("T")[0];

    searchParams.get("date") || searchParams.set("date", today);

    useEffect(() => {
        document.querySelector("input[type='date']").value =
            searchParams.get("date");
    }, []);

    const [meals, setMeals] = useState([]);
    const [refreshMeals, setRefreshMeals] = useState(false);

    useEffect(() => {
        fetchAuthenticated(`/api/Meal?${getQueryString(searchParams)}`)
            .then((res) => res.json())
            .then((res) => {
                setMeals(res);

                console.log("Meals:", res);
            })
            .catch((err) => console.log("Failed to get meals!", err));
    }, [refreshMeals]);

    const mealss = [
        // {
        //     hour: 18,
        //     minute: 14,
        //     protein: 35,
        //     fats: 50,
        //     carbs: 107,
        // },
        // {
        //     hour: 6,
        //     minute: 32,
        //     protein: 24,
        //     fats: 8,
        //     carbs: 93,
        // },
        // {
        //     hour: 9,
        //     minute: 55,
        //     protein: 24,
        //     fats: 8,
        //     carbs: 93,
        // },
        // {
        //     hour: 23,
        //     minute: 5,
        //     protein: 24,
        //     fats: 8,
        //     carbs: 93,
        // },
        // {
        //     hour: 7,
        //     minute: 7,
        //     protein: 7,
        //     fats: 83,
        //     carbs: 105,
        // },
        // {
        //     hour: 3,
        //     minute: 1,
        //     protein: 24,
        //     fats: 8,
        //     carbs: 93,
        // },
        // {
        //     hour: 1,
        //     minute: 13,
        //     protein: 53,
        //     fats: 12,
        //     carbs: 50,
        // },
    ];

    const generateMealList = (meals) => {
        return meals
            .sort((a, b) => b.hour - a.hour || b.minute - a.minute)
            .map((meal) => {
                return (
                    <Link to={`/mealdetails/${meal.id}`} className="meal">
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            height="1em"
                            viewBox="0 0 448 512"
                        >
                            <path d="M416 0C400 0 288 32 288 176V288c0 35.3 28.7 64 64 64h32V480c0 17.7 14.3 32 32 32s32-14.3 32-32V352 240 32c0-17.7-14.3-32-32-32zM64 16C64 7.8 57.9 1 49.7 .1S34.2 4.6 32.4 12.5L2.1 148.8C.7 155.1 0 161.5 0 167.9c0 45.9 35.1 83.6 80 87.7V480c0 17.7 14.3 32 32 32s32-14.3 32-32V255.6c44.9-4.1 80-41.8 80-87.7c0-6.4-.7-12.8-2.1-19.1L191.6 12.5c-1.8-8-9.3-13.3-17.4-12.4S160 7.8 160 16V150.2c0 5.4-4.4 9.8-9.8 9.8c-5.1 0-9.3-3.9-9.8-9L127.9 14.6C127.2 6.3 120.3 0 112 0s-15.2 6.3-15.9 14.6L83.7 151c-.5 5.1-4.7 9-9.8 9c-5.4 0-9.8-4.4-9.8-9.8V16zm48.3 152l-.3 0-.3 0 .3-.7 .3 .7z" />
                        </svg>

                        <div>
                            {calculateCalories(
                                meal.protein,
                                meal.fats,
                                meal.carbs
                            )}
                            <span className="Shoulders-col"> KCal</span>{" "}
                        </div>

                        <div className="meal-nutrients">
                            <div>
                                <strong className="Chest-col">P</strong>{" "}
                                {meal.protein}
                            </div>
                            <div>
                                <strong className="Biceps-col">F</strong>{" "}
                                {meal.fats}
                            </div>
                            <div>
                                <strong className="Back-col">C</strong>{" "}
                                {meal.carbs}
                            </div>
                        </div>

                        <div className="meal-right">
                            <p>
                                {meal.hour.toString().padStart(2, "0")}:
                                {meal.minute.toString().padStart(2, "0")}
                            </p>

                            <a className="Delete-btn">
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    height="1em"
                                    viewBox="0 0 448 512"
                                >
                                    <path d="M135.2 17.7L128 32H32C14.3 32 0 46.3 0 64S14.3 96 32 96H416c17.7 0 32-14.3 32-32s-14.3-32-32-32H320l-7.2-14.3C307.4 6.8 296.3 0 284.2 0H163.8c-12.1 0-23.2 6.8-28.6 17.7zM416 128H32L53.2 467c1.6 25.3 22.6 45 47.9 45H346.9c25.3 0 46.3-19.7 47.9-45L416 128z" />
                                </svg>
                            </a>
                        </div>
                    </Link>
                );
            });
    };

    return (
        <>
            <header className="Meals-header">
                <div className="date">
                    <input
                        type="date"
                        onChange={(e) => {
                            searchParams.set("date", e.target.value);
                        }}
                    />
                    <a
                        onClick={() => {
                            const date = searchParams.get("date");
                            document.location.href = `?date=${date}`;
                        }}
                        className="Auth-btn-fill"
                    >
                        Go to date
                    </a>
                </div>

                <div>
                    <h1>
                        Meals for{" "}
                        {searchParams.get("date").split("-").join("/")}
                    </h1>

                    <a
                        onClick={() => {
                            toast
                                .promise(addNewMeal, {
                                    pending: "Adding new meal...",
                                    success: "New meal added!",
                                    error: "Failed to add new meal!",
                                })
                                .then(() => {
                                    setRefreshMeals(!refreshMeals);
                                })
                                .catch((err) => {
                                    console.log(
                                        "Failed to add new meal! Error:",
                                        err
                                    );
                                });
                        }}
                        className="Auth-btn-fill"
                    >
                        Add new meal
                    </a>
                </div>

                <div className="totals">
                    <h2>
                        {meals.reduce((acc, curr) => {
                            return (
                                acc +
                                calculateCalories(
                                    curr.protein,
                                    curr.fats,
                                    curr.carbs
                                )
                            );
                        }, 0)}{" "}
                        calories
                    </h2>
                    <h3>
                        {meals.reduce((acc, curr) => {
                            return acc + curr.protein;
                        }, 0)}{" "}
                        protein
                    </h3>
                    <h3>
                        {meals.reduce((acc, curr) => {
                            return acc + curr.fats;
                        }, 0)}{" "}
                        fats
                    </h3>
                    <h3>
                        {meals.reduce((acc, curr) => {
                            return acc + curr.carbs;
                        }, 0)}{" "}
                        carbs
                    </h3>
                </div>

                <img src="/images/pexels-alexy-almond-3758133.jpg" alt="" />
            </header>
            <main className="meals-all">
                <section className="meals breakfast">
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        height="2em"
                        viewBox="0 0 640 512"
                    >
                        <path d="M96 64c0-17.7 14.3-32 32-32H448h64c70.7 0 128 57.3 128 128s-57.3 128-128 128H480c0 53-43 96-96 96H192c-53 0-96-43-96-96V64zM480 224h32c35.3 0 64-28.7 64-64s-28.7-64-64-64H480V224zM32 416H544c17.7 0 32 14.3 32 32s-14.3 32-32 32H32c-17.7 0-32-14.3-32-32s14.3-32 32-32z" />
                    </svg>
                    <h2>BREAKFAST</h2>
                    {generateMealList(
                        meals.filter((m) => m.hour >= 3 && m.hour < 11)
                    )}
                </section>
                <section className="meals lunch">
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        height="2em"
                        viewBox="0 0 512 512"
                    >
                        <path d="M361.5 1.2c5 2.1 8.6 6.6 9.6 11.9L391 121l107.9 19.8c5.3 1 9.8 4.6 11.9 9.6s1.5 10.7-1.6 15.2L446.9 256l62.3 90.3c3.1 4.5 3.7 10.2 1.6 15.2s-6.6 8.6-11.9 9.6L391 391 371.1 498.9c-1 5.3-4.6 9.8-9.6 11.9s-10.7 1.5-15.2-1.6L256 446.9l-90.3 62.3c-4.5 3.1-10.2 3.7-15.2 1.6s-8.6-6.6-9.6-11.9L121 391 13.1 371.1c-5.3-1-9.8-4.6-11.9-9.6s-1.5-10.7 1.6-15.2L65.1 256 2.8 165.7c-3.1-4.5-3.7-10.2-1.6-15.2s6.6-8.6 11.9-9.6L121 121 140.9 13.1c1-5.3 4.6-9.8 9.6-11.9s10.7-1.5 15.2 1.6L256 65.1 346.3 2.8c4.5-3.1 10.2-3.7 15.2-1.6zM160 256a96 96 0 1 1 192 0 96 96 0 1 1 -192 0zm224 0a128 128 0 1 0 -256 0 128 128 0 1 0 256 0z" />
                    </svg>
                    <h2>LUNCH</h2>
                    {generateMealList(
                        meals.filter((m) => m.hour >= 11 && m.hour < 19)
                    )}
                </section>
                <section className="meals dinner">
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        height="2em"
                        viewBox="0 0 384 512"
                    >
                        <path d="M223.5 32C100 32 0 132.3 0 256S100 480 223.5 480c60.6 0 115.5-24.2 155.8-63.4c5-4.9 6.3-12.5 3.1-18.7s-10.1-9.7-17-8.5c-9.8 1.7-19.8 2.6-30.1 2.6c-96.9 0-175.5-78.8-175.5-176c0-65.8 36-123.1 89.3-153.3c6.1-3.5 9.2-10.5 7.7-17.3s-7.3-11.9-14.3-12.5c-6.3-.5-12.6-.8-19-.8z" />
                    </svg>
                    <h2>DINNER</h2>
                    {generateMealList(
                        meals.filter((m) => m.hour >= 19 || m.hour < 3)
                    )}
                </section>
            </main>
        </>
    );
}

export default AllMeals;
