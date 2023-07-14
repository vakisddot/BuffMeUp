import React from "react";
import "./AllWorkouts.css";

function AllWorkouts() {
    const workouts = [
        {
            id: 1,
            date: "July 13th, 2023",
            sets: [
                { exerciseType: "Back" },
                { exerciseType: "Back" },
                { exerciseType: "Back" },
                { exerciseType: "Biceps" },
                { exerciseType: "Biceps" },
            ],
        },
        {
            id: 2,
            date: "July 13th, 2023",
            sets: [
                { exerciseType: "Chest" },
                { exerciseType: "Chest" },
                { exerciseType: "Chest" },
                { exerciseType: "Shoulders" },
                { exerciseType: "Chest" },
                { exerciseType: "Chest" },
                { exerciseType: "Shoulders" },
                { exerciseType: "Triceps" },
            ],
        },
        {
            id: 3,
            date: "July 13th, 2023",
            sets: [],
        },
    ];

    const getUniqueExercises = (sets) => {
        const uniqueValues = new Set();

        sets.forEach((set) => {
            uniqueValues.add(set.exerciseType);
        });

        return Array.from(uniqueValues).join(" / ");
    };

    return (
        <>
            <header className="All-workouts-header">
                <h1>My Workouts</h1>

                <a href="#" className="Auth-btn-fill">
                    Start new
                </a>

                <img src="/images/pexels-leon-ardho-1552242.jpg" alt="" />
            </header>

            <section className="All-workouts-body">
                {workouts.map((workout) => {
                    return (
                        <div className="workout-details">
                            <svg
                                xmlns="http://www.w3.org/2000/svg"
                                height="25em"
                                viewBox="0 0 640 512"
                            >
                                <path d="M96 64c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32V224v64V448c0 17.7-14.3 32-32 32H128c-17.7 0-32-14.3-32-32V384H64c-17.7 0-32-14.3-32-32V288c-17.7 0-32-14.3-32-32s14.3-32 32-32V160c0-17.7 14.3-32 32-32H96V64zm448 0v64h32c17.7 0 32 14.3 32 32v64c17.7 0 32 14.3 32 32s-14.3 32-32 32v64c0 17.7-14.3 32-32 32H544v64c0 17.7-14.3 32-32 32H480c-17.7 0-32-14.3-32-32V288 224 64c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32zM416 224v64H224V224H416z" />
                            </svg>
                            <div>
                                <h2>WORKOUT #{workout.id}</h2>

                                <div>
                                    <p>
                                        <span className="gray">Date / </span>{" "}
                                        {workout.date}
                                    </p>
                                    <p>
                                        <span className="gray">
                                            Total Sets /{" "}
                                        </span>{" "}
                                        {workout.sets.length}
                                    </p>
                                </div>

                                <p className="set-circles">
                                    {workout.sets.map((set) => {
                                        return (
                                            <span
                                                className={`set-circle ${set.exerciseType}`}
                                            ></span>
                                        );
                                    })}
                                </p>
                            </div>

                            <div className="workout-details-end">
                                <div>
                                    <h3 className="gray">EXERCISE TYPES</h3>
                                    <p>{getUniqueExercises(workout.sets)}</p>
                                </div>
                                <div className="workout-btns">
                                    <a href="#" className="Auth-btn-fill">
                                        View
                                    </a>
                                    <a href="#" className="Auth-btn-fill">
                                        Edit
                                    </a>
                                    <a href="#" className="Auth-btn-fill">
                                        Delete
                                    </a>
                                </div>
                            </div>
                        </div>
                    );
                })}
            </section>
        </>
    );
}

export default AllWorkouts;
