export function calculateCalories(protein, fats, carbs) {
    return protein * 4 + fats * 9 + carbs * 4;
}

export function addNewMeal() {
    return new Promise((resolve, reject) => {
        const token = localStorage.getItem("token");

        fetch("/api/Meal", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + token,
            },
        })
            .then(() => {
                console.log("Added new meal!");
                resolve();
            })
            .catch((err) => {
                console.log("Failed to add new meal! Error:", err);
                reject(err);
            });
    });
}
