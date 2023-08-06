import React, { useEffect } from "react";
import "./MealDetails.css";
import { calculateCalories } from "./mealUtils";
import SearchBar from "../../components/SearchBar";
import { setTitle } from "../../utils";

function MealDetails() {
    useEffect(() => setTitle("Meal Details"), []);

    const servings = [
        {
            foodItem: {
                name: "Egg",
                protein: 20,
                fats: 31,
                carbs: 1,
            },
            grams: 300,
        },
        {
            foodItem: {
                name: "Watermelon",
                protein: 0,
                fats: 0,
                carbs: 7,
            },
            grams: 500,
        },
        {
            foodItem: {
                name: "Chicken Breast",
                protein: 45,
                fats: 3,
                carbs: 5,
            },
            grams: 250,
        },
    ];

    return (
        <div>
            <header>
                <h1>Meal Details</h1>
                <SearchBar
                    endpoint="/api/FoodItem"
                    lookFor="name"
                    onResultSelect={(result) => {
                        console.log(result);
                    }}
                />
            </header>
            <main className="Meal-details-main">
                {servings
                    .map((serving) => {
                        const percentage = serving.grams / 100;

                        const protein = serving.foodItem.protein * percentage;
                        const fats = serving.foodItem.fats * percentage;
                        const carbs = serving.foodItem.carbs * percentage;

                        return {
                            name: serving.foodItem.name,
                            protein,
                            fats,
                            carbs,
                            grams: serving.grams,
                            calories: calculateCalories(protein, fats, carbs),
                        };
                    })
                    .map((serving) => {
                        return (
                            <div className="serving">
                                <h2>
                                    {serving.name} - {serving.grams}g
                                </h2>

                                <p>Calories: {Math.round(serving.calories)}</p>

                                <div>
                                    <h3>
                                        Protein: {Math.round(serving.protein)}
                                    </h3>
                                    <h3>Fats: {Math.round(serving.fats)}</h3>
                                    <h3>Carbs: {Math.round(serving.carbs)}</h3>
                                </div>
                            </div>
                        );
                    })}
            </main>
        </div>
    );
}

export default MealDetails;
