import React, { useEffect, useState } from "react";
import "./MealDetails.css";
import { calculateCalories } from "./mealUtils";
import SearchBar from "../../components/SearchBar";
import { fetchAuthenticated, getIdFromUrl, setTitle } from "../../utils";
import { displayPopup, hidePopup } from "../../components/popupFormUtils";
import InputForm from "../../components/InputForm";
import { toast } from "react-toastify";

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

    const onNewCreatedPortion = (response, submitObject) => {
        setPortions([
            ...portions,
            {
                id: response.id,
                foodItem: {
                    name: currFoodItem.name,
                    protein: currFoodItem.protein,
                    fats: currFoodItem.fats,
                    carbs: currFoodItem.carbs,
                },
                grams: submitObject.grams,
            },
        ]);
    };

    const deletePortion = (portion) => {
        fetchAuthenticated(
            "/api/Portion",
            "DELETE",
            JSON.stringify({
                id: portion.id,
            })
        ).then(() => {
            setPortions([...portions.filter((p) => p.id !== portion.id)]);

            toast.success("Removed portion!");
        });
    };

    const getBorderColor = (protein, fats, carbs) => {
        if (protein > fats && protein > carbs) return "var(--red)";
        else if (fats > protein && fats > carbs) return "var(--green)";
        else return "var(--blue)";
    };

    return (
        <div className="meal-details">
            <header className="meal-details-header">
                <svg
                    style={{ fill: "var(--white)" }}
                    xmlns="http://www.w3.org/2000/svg"
                    height="3em"
                    viewBox="0 0 448 512"
                >
                    <path d="M416 0C400 0 288 32 288 176V288c0 35.3 28.7 64 64 64h32V480c0 17.7 14.3 32 32 32s32-14.3 32-32V352 240 32c0-17.7-14.3-32-32-32zM64 16C64 7.8 57.9 1 49.7 .1S34.2 4.6 32.4 12.5L2.1 148.8C.7 155.1 0 161.5 0 167.9c0 45.9 35.1 83.6 80 87.7V480c0 17.7 14.3 32 32 32s32-14.3 32-32V255.6c44.9-4.1 80-41.8 80-87.7c0-6.4-.7-12.8-2.1-19.1L191.6 12.5c-1.8-8-9.3-13.3-17.4-12.4S160 7.8 160 16V150.2c0 5.4-4.4 9.8-9.8 9.8c-5.1 0-9.3-3.9-9.8-9L127.9 14.6C127.2 6.3 120.3 0 112 0s-15.2 6.3-15.9 14.6L83.7 151c-.5 5.1-4.7 9-9.8 9c-5.4 0-9.8-4.4-9.8-9.8V16zm48.3 152l-.3 0-.3 0 .3-.7 .3 .7z" />
                </svg>
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
                            onNewCreatedPortion(response, submitObject);
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
                            id: serving.id,
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
                                <div className="serving-title">
                                    <svg
                                        style={{
                                            fill: getBorderColor(
                                                serving.protein,
                                                serving.fats,
                                                serving.carbs
                                            ),
                                        }}
                                        xmlns="http://www.w3.org/2000/svg"
                                        height="1.5em"
                                        viewBox="0 0 448 512"
                                    >
                                        <path d="M416 0C400 0 288 32 288 176V288c0 35.3 28.7 64 64 64h32V480c0 17.7 14.3 32 32 32s32-14.3 32-32V352 240 32c0-17.7-14.3-32-32-32zM64 16C64 7.8 57.9 1 49.7 .1S34.2 4.6 32.4 12.5L2.1 148.8C.7 155.1 0 161.5 0 167.9c0 45.9 35.1 83.6 80 87.7V480c0 17.7 14.3 32 32 32s32-14.3 32-32V255.6c44.9-4.1 80-41.8 80-87.7c0-6.4-.7-12.8-2.1-19.1L191.6 12.5c-1.8-8-9.3-13.3-17.4-12.4S160 7.8 160 16V150.2c0 5.4-4.4 9.8-9.8 9.8c-5.1 0-9.3-3.9-9.8-9L127.9 14.6C127.2 6.3 120.3 0 112 0s-15.2 6.3-15.9 14.6L83.7 151c-.5 5.1-4.7 9-9.8 9c-5.4 0-9.8-4.4-9.8-9.8V16zm48.3 152l-.3 0-.3 0 .3-.7 .3 .7z" />
                                    </svg>
                                    <h2 className="align-left">
                                        {serving.name}{" "}
                                        <span className="serving-grams">
                                            {serving.grams}g
                                        </span>
                                    </h2>
                                </div>

                                <h3>
                                    <span className="serving-grams">
                                        {Math.round(serving.calories)}
                                    </span>{" "}
                                    kCal
                                </h3>

                                <div className="serving-macros">
                                    <h4>
                                        Protein:{" "}
                                        <span className="serving-grams">
                                            {Math.round(serving.protein)}
                                        </span>
                                    </h4>
                                    <h4>
                                        Fats:{" "}
                                        <span className="serving-grams">
                                            {Math.round(serving.fats)}
                                        </span>
                                    </h4>
                                    <h4>
                                        Carbs:{" "}
                                        <span className="serving-grams">
                                            {Math.round(serving.carbs)}
                                        </span>
                                    </h4>
                                </div>

                                <div className="align-right ud-buttons">
                                    <a
                                        className="Delete-btn"
                                        onClick={() => deletePortion(serving)}
                                    >
                                        <svg
                                            xmlns="http://www.w3.org/2000/svg"
                                            height="1em"
                                            viewBox="0 0 448 512"
                                        >
                                            <path d="M135.2 17.7L128 32H32C14.3 32 0 46.3 0 64S14.3 96 32 96H416c17.7 0 32-14.3 32-32s-14.3-32-32-32H320l-7.2-14.3C307.4 6.8 296.3 0 284.2 0H163.8c-12.1 0-23.2 6.8-28.6 17.7zM416 128H32L53.2 467c1.6 25.3 22.6 45 47.9 45H346.9c25.3 0 46.3-19.7 47.9-45L416 128z" />
                                        </svg>
                                    </a>
                                </div>
                            </div>
                        );
                    })}
            </main>
        </div>
    );
}

export default MealDetails;
