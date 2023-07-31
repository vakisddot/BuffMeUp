export default function startNewWorkout() {
    return new Promise((resolve, reject) => {
        const token = localStorage.getItem("token");

        fetch("/api/Workout", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + token,
            },
        })
            .then(() => {
                console.log("Started new workout!");
                resolve();
            })
            .catch((err) => {
                console.log("Failed to start new workout! Error:", err);
                reject(err);
            });
    });
}
