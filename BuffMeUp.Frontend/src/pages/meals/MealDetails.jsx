import React, { useEffect, useState } from "react";
import "./MealDetails.css";
import { calculateCalories } from "./mealUtils";
import SearchBar from "../../components/SearchBar";
import { fetchAuthenticated, getIdFromUrl, setTitle } from "../../utils";
import { displayPopup, hidePopup } from "../../components/popupFormUtils";
import InputForm from "../../components/InputForm";

function MealDetails() {
    useEffect(() => setTitle("Meal Details"), []);

    const [meal, setMeal] = useState({});
    const [currFoodItem, setCurrFoodItem] = useState({});
    const [portions, setPortions] = useState([]);

    useEffect(() => {
        fetchAuthenticated(`/api/Portion?id=${getIdFromUrl()[0]}`)
            .then((res) => res.json())
            .then((res) => {
                console.log(res);
                setPortions(res);
            })
            .catch((err) => console.log(err));
    }, []);

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
                        setCurrFoodItem(result);
                        console.log(result);
                        displayPopup("new-portion");
                    }}
                />
                <div className="popup-form new-portion">
                    <InputForm
                        title={currFoodItem.name}
                        fields={{
                            grams: {
                                label: "Grams",
                                type: "number",
                            },
                        }}
                        submitFields={{
                            foodItemId: currFoodItem.id,
                            mealId: getIdFromUrl()[0],
                        }}
                        onSuccessfulSubmit={(response, submitObject) => {
                            // onNewCreatedSet(response, submitObject);
                            hidePopup("new-portion");
                        }}
                        onBack={() => hidePopup("new-portion")}
                        authorize={true}
                        endpoint="/api/Portion"
                        submitLabel="Add"
                        resetOnSubmit={true}
                    />
                </div>
            </header>
            <main className="Meal-details-main">
                {portions
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
