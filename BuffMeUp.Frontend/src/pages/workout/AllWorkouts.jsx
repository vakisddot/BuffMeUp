import React, { useEffect, useState } from "react";
import "./AllWorkouts.css";
import "../../css/quickClasses.css";
import { Link } from "react-router-dom";
import { useSearchParams } from "react-router-dom";
import { getClaims, getQueryString } from "../../utils";
import startNewWorkout from "./workoutUtils";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import InputForm from "../../components/InputForm";
import { displayPopup, hidePopup } from "../../components/popupFormUtils";
import PageBar from "../../components/PageBar";

function AllWorkouts() {
    const token = localStorage.getItem("token");

    const [searchParams] = useSearchParams();

    searchParams.get("page") || searchParams.set("page", 1);
    searchParams.get("resultCount") || searchParams.set("resultCount", 10);

    console.log(
        "Search params:",
        "page:",
        searchParams.get("page"),
        "resultCount:",
        searchParams.get("resultCount")
    );

    const [workouts, setWorkouts] = useState([]);
    const [refreshWorkouts, setRefreshWorkouts] = useState(false);
    const [currId, setCurrId] = useState("");

    useEffect(() => {
        fetch(`/api/Workout/All?${getQueryString(searchParams)}`, {
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + token,
            },
        })
            .then((res) => res.json())
            .then((res) => {
                setWorkouts(res);

                console.log("Workouts:", res);
            })
            .catch((err) => console.log("Failed to get workouts!", err));
    }, [refreshWorkouts]);

    const getUniqueExercises = (sets) => {
        const uniqueValues = new Set();

        sets.forEach((set) => {
            uniqueValues.add(set);
        });

        return Array.from(uniqueValues).join(" / ");
    };

    return (
        <>
            <header className="All-workouts-header">
                <h1>My Workouts</h1>

                <a
                    onClick={() => {
                        toast
                            .promise(startNewWorkout, {
                                pending: "Starting new workout...",
                                success: "New workout started!",
                                error: "Failed to start new workout!",
                            })
                            .then(() => {
                                setRefreshWorkouts(!refreshWorkouts);
                            })
                            .catch((err) => {
                                console.log(
                                    "Failed to start new workout! Error:",
                                    err
                                );
                            });
                    }}
                    className="Auth-btn-fill"
                >
                    Start new
                </a>

                <img src="/images/pexels-leon-ardho-1552242.jpg" alt="" />
            </header>

            <section className="All-workouts-body">
                <PageBar
                    params={searchParams}
                    isLastPage={() =>
                        workouts.length < searchParams.get("resultCount") ||
                        workouts.length <= 0
                    }
                />
                <div className="popup-form delete-workout">
                    <InputForm
                        title={"Are you sure?"}
                        fields={{}}
                        submitFields={{
                            id: currId,
                        }}
                        onSuccessfulSubmit={(response, submitObject) => {
                            hidePopup("delete-workout");

                            setWorkouts(
                                workouts.filter((w) => w.id !== currId)
                            );
                        }}
                        onBack={() => hidePopup("delete-workout")}
                        authorize={true}
                        endpoint="/api/Workout"
                        submitLabel="Delete"
                        method="DELETE"
                    />
                </div>

                {workouts.length > 0 ? (
                    workouts.map((workout) => {
                        return (
                            <Link to={`/workoutdetails/${workout.id}`}>
                                <div className="workout-details">
                                    <svg
                                        xmlns="http://www.w3.org/2000/svg"
                                        height="25em"
                                        viewBox="0 0 640 512"
                                    >
                                        <path d="M96 64c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32V224v64V448c0 17.7-14.3 32-32 32H128c-17.7 0-32-14.3-32-32V384H64c-17.7 0-32-14.3-32-32V288c-17.7 0-32-14.3-32-32s14.3-32 32-32V160c0-17.7 14.3-32 32-32H96V64zm448 0v64h32c17.7 0 32 14.3 32 32v64c17.7 0 32 14.3 32 32s-14.3 32-32 32v64c0 17.7-14.3 32-32 32H544v64c0 17.7-14.3 32-32 32H480c-17.7 0-32-14.3-32-32V288 224 64c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32zM416 224v64H224V224H416z" />
                                    </svg>
                                    <div>
                                        <h2>WORKOUT #{workout.number}</h2>

                                        <div>
                                            <p>
                                                <span className="gray">
                                                    Date /{" "}
                                                </span>{" "}
                                                {workout.date?.split("T")[0]}
                                            </p>
                                            <p>
                                                <span className="gray">
                                                    Total Sets /{" "}
                                                </span>{" "}
                                                {workout.sets.length}
                                            </p>
                                        </div>
                                    </div>

                                    <div className="workout-details-comment">
                                        {workout.comment && (
                                            <>
                                                <h3 className="gray">
                                                    COMMENT
                                                </h3>
                                                <p className="comment">
                                                    "{workout.comment}"
                                                </p>
                                            </>
                                        )}
                                    </div>

                                    <div className="workout-details-end">
                                        <div>
                                            <h3 className="gray">
                                                EXERCISE TYPES
                                            </h3>
                                            <p>
                                                {getUniqueExercises(
                                                    workout.sets
                                                )}
                                            </p>

                                            <p className="set-circles">
                                                {workout.sets
                                                    .reverse()
                                                    .map((set) => {
                                                        return (
                                                            <span
                                                                className={`set-circle ${set}`}
                                                            ></span>
                                                        );
                                                    })}
                                            </p>
                                        </div>

                                        <div className="align-right ud-buttons">
                                            <a
                                                className="Delete-btn"
                                                onClick={(e) => {
                                                    e.preventDefault();
                                                    setCurrId(workout.id);
                                                    displayPopup(
                                                        "delete-workout"
                                                    );
                                                }}
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
                                </div>
                            </Link>
                        );
                    })
                ) : (
                    <h1>No workouts logged yet. :(</h1>
                )}
            </section>
        </>
    );
}

export default AllWorkouts;
