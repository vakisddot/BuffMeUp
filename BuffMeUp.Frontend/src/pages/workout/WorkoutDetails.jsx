import "./WorkoutDetails.css";
import { Link } from "react-router-dom";
import InputForm from "../../components/InputForm";
import { useState, useEffect } from "react";
import { fetchAuthenticated } from "../../utils";
import SearchBar from "../../components/SearchBar";
import { toast } from "react-toastify";

const WorkoutDetails = () => {
    const token = localStorage.getItem("token");

    const [workout, setWorkout] = useState({});
    const [sets, setSets] = useState([]);
    let setIndex = 1;

    const [currTemplate, setCurrTemplate] = useState("");

    const getWorkoutId = () => window.location.pathname.split("/").slice(-1);

    useEffect(() => {
        fetchAuthenticated(`/api/Workout/Details?id=${getWorkoutId()}`)
            .then((res) => res.json())
            .then((res) => {
                setWorkout(res);
            });

        fetchAuthenticated(
            `/api/ExerciseSet/AllByWorkout?workoutId=${getWorkoutId()}`
        )
            .then((res) => res.json())
            .then((res) => {
                setSets(res.reverse());
            })
            .catch((err) => {
                console.log(err);
            });
    }, []);

    const duplicateSet = (set) => {
        fetchAuthenticated(
            "/api/ExerciseSet/AddWithExerciseName",
            "POST",
            JSON.stringify({
                reps: set.reps,
                weight: set.weight,
                exerciseName: set.exerciseName,
                workoutId: workout.id,
            })
        )
            .then((res) => res.json())
            .then((res) => {
                setSets([
                    ...sets,
                    {
                        id: res.id,
                        reps: set.reps,
                        weight: set.weight,
                        exerciseName: set.exerciseName,
                        exerciseType: set.exerciseType,
                    },
                ]);

                toast.success("Duplicated set!");
            });
    };

    const deleteSet = (set) => {
        fetchAuthenticated(
            "/api/ExerciseSet/Delete",
            "POST",
            JSON.stringify({
                id: set.id,
            })
        ).then(() => {
            setSets([...sets.filter((s) => s.id != set.id)]);

            toast.success("Removed set!");
        });
    };

    return (
        <div className="Workout-form">
            <header className="Workout-form-header">
                <svg
                    xmlns="http://www.w3.org/2000/svg"
                    height="5em"
                    viewBox="0 0 640 512"
                >
                    <path d="M96 64c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32V224v64V448c0 17.7-14.3 32-32 32H128c-17.7 0-32-14.3-32-32V384H64c-17.7 0-32-14.3-32-32V288c-17.7 0-32-14.3-32-32s14.3-32 32-32V160c0-17.7 14.3-32 32-32H96V64zm448 0v64h32c17.7 0 32 14.3 32 32v64c17.7 0 32 14.3 32 32s-14.3 32-32 32v64c0 17.7-14.3 32-32 32H544v64c0 17.7-14.3 32-32 32H480c-17.7 0-32-14.3-32-32V288 224 64c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32zM416 224v64H224V224H416z" />
                </svg>
                <h1>
                    WORK<span className="red">OUT</span> #{workout.number}
                </h1>
                <p>{currTemplate.name}</p>
                <div className="Workout-form-header-btns">
                    <a className="Auth-btn-fill">Add comment</a>
                </div>
                <SearchBar
                    endpoint="/api/Workout/Templates"
                    lookFor="name"
                    onResultSelect={(result) => {
                        setCurrTemplate(result);
                        document.querySelector(
                            ".new-set.popup-form"
                        ).style.display = "block";
                    }}
                />

                <div className="new-set popup-form">
                    <InputForm
                        title={currTemplate.name}
                        fields={{
                            reps: {
                                label: "Reps",
                                type: "number",
                            },
                            weight: {
                                label: "Weight",
                                type: "number",
                            },
                        }}
                        submitFields={{
                            exerciseTemplateId: currTemplate.id,
                            workoutId: workout.id,
                        }}
                        onSuccessfulSubmit={(response, submitObject) => {
                            setSets([
                                ...sets,
                                {
                                    id: response.id,
                                    reps: submitObject.reps,
                                    weight: submitObject.weight,
                                    exerciseName: currTemplate.name,
                                    exerciseType: currTemplate.exerciseType,
                                },
                            ]);

                            document.querySelector(
                                ".popup-form"
                            ).style.display = "none";
                        }}
                        onBack={() =>
                            (document.querySelector(
                                ".popup-form"
                            ).style.display = "none")
                        }
                        headers={{
                            "Content-Type": "application/json",
                            Authorization: "Bearer " + token,
                        }}
                        endpoint="/api/ExerciseSet/Add"
                        submitLabel="Add"
                    />
                </div>
            </header>

            <section className="Workout-form-body">
                <div className="exercise-sets">
                    {sets.map((set) => {
                        return (
                            <div className="exercise-set-card">
                                <div className="align-left set-info">
                                    <span>{setIndex++}</span>
                                    <svg
                                        className={`${set.exerciseType}-fill`}
                                        xmlns="http://www.w3.org/2000/svg"
                                        height="2em"
                                        viewBox="0 0 640 512"
                                    >
                                        <path d="M96 64c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32V224v64V448c0 17.7-14.3 32-32 32H128c-17.7 0-32-14.3-32-32V384H64c-17.7 0-32-14.3-32-32V288c-17.7 0-32-14.3-32-32s14.3-32 32-32V160c0-17.7 14.3-32 32-32H96V64zm448 0v64h32c17.7 0 32 14.3 32 32v64c17.7 0 32 14.3 32 32s-14.3 32-32 32v64c0 17.7-14.3 32-32 32H544v64c0 17.7-14.3 32-32 32H480c-17.7 0-32-14.3-32-32V288 224 64c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32zM416 224v64H224V224H416z" />
                                    </svg>

                                    <div>
                                        <h3
                                            className={`${set.exerciseType}-col`}
                                        >
                                            {set.exerciseName}
                                        </h3>
                                        <p className="gray">
                                            {set.exerciseType.toUpperCase()}
                                        </p>
                                    </div>
                                </div>

                                <div className="Sets-and-reps">
                                    <div>{set.reps}</div>
                                    <div className="gray">x</div>
                                    <p>
                                        {set.weight}
                                        <span className="gray"> kg</span>
                                    </p>
                                </div>

                                <div className="align-right ud-buttons">
                                    <a
                                        className="Duplicate-btn"
                                        onClick={() => duplicateSet(set)}
                                    >
                                        <svg
                                            xmlns="http://www.w3.org/2000/svg"
                                            height="1em"
                                            viewBox="0 0 512 512"
                                        >
                                            <path d="M272 0H396.1c12.7 0 24.9 5.1 33.9 14.1l67.9 67.9c9 9 14.1 21.2 14.1 33.9V336c0 26.5-21.5 48-48 48H272c-26.5 0-48-21.5-48-48V48c0-26.5 21.5-48 48-48zM48 128H192v64H64V448H256V416h64v48c0 26.5-21.5 48-48 48H48c-26.5 0-48-21.5-48-48V176c0-26.5 21.5-48 48-48z" />
                                        </svg>
                                    </a>
                                    <a className="Edit-btn">
                                        <svg
                                            xmlns="http://www.w3.org/2000/svg"
                                            height="1em"
                                            viewBox="0 0 512 512"
                                        >
                                            <path d="M471.6 21.7c-21.9-21.9-57.3-21.9-79.2 0L362.3 51.7l97.9 97.9 30.1-30.1c21.9-21.9 21.9-57.3 0-79.2L471.6 21.7zm-299.2 220c-6.1 6.1-10.8 13.6-13.5 21.9l-29.6 88.8c-2.9 8.6-.6 18.1 5.8 24.6s15.9 8.7 24.6 5.8l88.8-29.6c8.2-2.7 15.7-7.4 21.9-13.5L437.7 172.3 339.7 74.3 172.4 241.7zM96 64C43 64 0 107 0 160V416c0 53 43 96 96 96H352c53 0 96-43 96-96V320c0-17.7-14.3-32-32-32s-32 14.3-32 32v96c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V160c0-17.7 14.3-32 32-32h96c17.7 0 32-14.3 32-32s-14.3-32-32-32H96z" />
                                        </svg>
                                    </a>
                                    <a
                                        className="Delete-btn"
                                        onClick={() => deleteSet(set)}
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
                </div>
            </section>
        </div>
    );
};

export default WorkoutDetails;
