import "./Account.css";
import { useState, useEffect } from "react";
import { CircularProgress } from "@mui/material";
import jwt_decode from "jwt-decode";
import InputForm from "../components/InputForm";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import { fetchAuthenticated, setTitle } from "../utils";
import { displayPopup } from "../components/popupFormUtils";

const Account = ({ nutrients }) => {
    useEffect(() => setTitle("Account"), []);

    const token = localStorage.getItem("token");
    const claims = jwt_decode(token);

    const [personalStats, setPersonalStats] = useState({});

    useEffect(() => {
        fetchAuthenticated("/api/PersonalStats")
            .then((res) => res.json())
            .then((res) => {
                setPersonalStats(res);

                console.log("Personal stats:", res);
            })
            .catch((err) => console.log(err));
    }, []);

    const cmToInches = (cm) => cm / 2.54;

    const getBmiType = (bmi) => {
        if (bmi >= 40) return "Extreme obesity!";
        if (bmi >= 35) return "Severe obesity!";
        if (bmi >= 30) return "Obesity!";
        if (bmi >= 25) return "Overweight";
        if (bmi >= 18.5) return "Normal";
        if (bmi >= 17) return "Underweight";
        if (bmi >= 16) return "Severely underweight!";

        return "Extremely underweight!";
    };

    const getGenderString = (gender) => (gender ? "Male" : "Female");

    const getAgeString = (age) => `${age} years old`;

    const getWeightString = (weightKg) =>
        `${weightKg} kg / ${Math.round(weightKg * 2.205)} lbs`;

    const getHeightString = (heightCm) =>
        `${(heightCm / 100).toFixed(2)} m / ${Math.floor(
            cmToInches(heightCm) / 12
        )}'${Math.round(cmToInches(heightCm) % 12)}"`;

    const getBmiString = (bmi) => `${bmi.toFixed(1)} (${getBmiType(bmi)})`;

    const [bmi, setBmi] = useState(0);
    const [accStats, setAccStats] = useState({});
    const [weightChange, setWeightChange] = useState(0);
    const [weightChangeRemaining, setWeightChangeRemaining] = useState(0);

    useEffect(() => {
        setWeightChange(
            personalStats?.currentWeight - personalStats?.startingWeight || 0
        );

        setWeightChangeRemaining(
            personalStats?.currentWeight - personalStats?.goalWeight || 0
        );

        setBmi(
            personalStats?.currentWeight / (personalStats?.height / 100) ** 2
        );

        setAccStats({
            Gender: getGenderString(personalStats?.gender),
            Age: getAgeString(personalStats?.age || 0),
            Height: getHeightString(personalStats?.height || 0),
            Weight: getWeightString(personalStats?.currentWeight || 0),
            BMI: getBmiString(bmi || 0),
        });
    }, [personalStats]);

    const nutrientGoals = {
        Calories: [
            nutrients?.currentCalories || 0,
            nutrients?.goalCalories || 0,
            "M349.4 44.6c5.9-13.7 1.5-29.7-10.6-38.5s-28.6-8-39.9 1.8l-256 224c-10 8.8-13.6 22.9-8.9 35.3S50.7 288 64 288H175.5L98.6 467.4c-5.9 13.7-1.5 29.7 10.6 38.5s28.6 8 39.9-1.8l256-224c10-8.8 13.6-22.9 8.9-35.3s-16.6-20.7-30-20.7H272.5L349.4 44.6z",
            448,
            "yellow",
        ],
        Protein: [
            nutrients?.currentProtein || 0,
            nutrients?.goalProtein || 0,
            "M160 265.2c0 8.5-3.4 16.6-9.4 22.6l-26.8 26.8c-12.3 12.3-32.5 11.4-49.4 7.2C69.8 320.6 65 320 60 320c-33.1 0-60 26.9-60 60s26.9 60 60 60c6.3 0 12 5.7 12 12c0 33.1 26.9 60 60 60s60-26.9 60-60c0-5-.6-9.8-1.8-14.5c-4.2-16.9-5.2-37.1 7.2-49.4l26.8-26.8c6-6 14.1-9.4 22.6-9.4H336c6.3 0 12.4-.3 18.5-1c11.9-1.2 16.4-15.5 10.8-26c-8.5-15.8-13.3-33.8-13.3-53c0-61.9 50.1-112 112-112c8 0 15.7 .8 23.2 2.4c11.7 2.5 24.1-5.9 22-17.6C494.5 62.5 422.5 0 336 0C238.8 0 160 78.8 160 176v89.2z",
            512,
            "red",
        ],
        Fat: [
            nutrients?.currentFats || 0,
            nutrients?.goalFats || 0,
            "M96 0C82.7 0 72 10.7 72 24s10.7 24 24 24c4.4 0 8 3.6 8 8v64.9c0 12.2-7.2 23.1-17.2 30.1C53.7 174.1 32 212.5 32 256V448c0 35.3 28.7 64 64 64H224c35.3 0 64-28.7 64-64V256c0-43.5-21.7-81.9-54.8-105c-10-7-17.2-17.9-17.2-30.1V56c0-4.4 3.6-8 8-8c13.3 0 24-10.7 24-24s-10.7-24-24-24l-8 0 0 0 0 0H104l0 0 0 0L96 0zm64 382c-26.5 0-48-20.1-48-45c0-16.8 22.1-48.1 36.3-66.4c6-7.8 17.5-7.8 23.5 0C185.9 288.9 208 320.2 208 337c0 24.9-21.5 45-48 45z",
            320,
            "green",
        ],
        Carbs: [
            nutrients?.currentCarbs || 0,
            nutrients?.goalCarbs || 0,
            "M505 41c9.4-9.4 9.4-24.6 0-33.9s-24.6-9.4-33.9 0L383 95c-9.4 9.4-9.4 24.6 0 33.9s24.6 9.4 33.9 0l88-88zM305.5 27.3c-6.2-6.2-16.4-6.2-22.6 0L271.5 38.6c-37.5 37.5-37.5 98.3 0 135.8l10.4 10.4-30.5 30.5c-3.4-27.3-15.5-53.8-36.5-74.8l-11.3-11.3c-6.2-6.2-16.4-6.2-22.6 0l-11.3 11.3c-37.5 37.5-37.5 98.3 0 135.8l10.4 10.4-30.5 30.5c-3.4-27.3-15.5-53.8-36.5-74.8L101.8 231c-6.2-6.2-16.4-6.2-22.6 0L67.9 242.3c-37.5 37.5-37.5 98.3 0 135.8l10.4 10.4L9.4 457.4c-12.5 12.5-12.5 32.8 0 45.3s32.8 12.5 45.3 0l68.9-68.9 12.2 12.2c37.5 37.5 98.3 37.5 135.8 0l11.3-11.3c6.2-6.2 6.2-16.4 0-22.6l-11.3-11.3c-21.8-21.8-49.6-34.1-78.1-36.9l31.9-31.9 12.2 12.2c37.5 37.5 98.3 37.5 135.8 0l11.3-11.3c6.2-6.2 6.2-16.4 0-22.6l-11.3-11.3c-21.8-21.8-49.6-34.1-78.1-36.9l31.9-31.9 12.2 12.2c37.5 37.5 98.3 37.5 135.8 0L486.5 231c6.2-6.2 6.2-16.4 0-22.6L475.2 197c-5.2-5.2-10.6-9.8-16.4-13.9L505 137c9.4-9.4 9.4-24.6 0-33.9s-24.6-9.4-33.9 0l-59.4 59.4c-20.6-4.4-42-3.7-62.3 2.1c6.1-21.3 6.6-43.8 1.4-65.3L409 41c9.4-9.4 9.4-24.6 0-33.9s-24.6-9.4-33.9 0L329.1 52.9c-3.7-5-7.8-9.8-12.4-14.3L305.5 27.3z",
            512,
            "blue",
        ],
    };

    return (
        <>
            <header className="user-stats">
                <div className="profile-info">
                    <div className="acc-info">
                        <div className="profile-pic">
                            <img src="/images/no_avatar.png" alt="" />
                        </div>

                        <div className="profile-text">
                            <div className="firstname-and-username">
                                <h2>
                                    {(
                                        claims?.firstName || "Unnamed"
                                    ).toUpperCase()}
                                </h2>
                                <p className="username">
                                    @{claims?.username || "invalid"}
                                </p>

                                <Link to="#" className="Auth-btn">
                                    Edit account
                                </Link>
                            </div>

                            <div className="acc-stats">
                                {Object.entries(accStats).map(
                                    ([key, value]) => (
                                        <p key={key}>
                                            <b>{key}:</b> {value}
                                        </p>
                                    )
                                )}

                                <Link to="#" className="Auth-btn">
                                    Update info
                                </Link>
                            </div>
                        </div>
                    </div>
                </div>

                <div className="so-far">
                    <h1>SO FAR YOU HAVE...</h1>

                    <div className="accomplishments">
                        <h2>
                            {weightChange < 0 ? "Lost" : "Gained"}{" "}
                            {getWeightString(Math.abs(weightChange))}...
                        </h2>
                        <h4>
                            ... with{" "}
                            {getWeightString(Math.abs(weightChangeRemaining))}{" "}
                            more to go!
                        </h4>
                    </div>

                    <div className="update-weight-info">
                        <p>
                            Make sure to update your weight once a week and log
                            every single workout!
                        </p>

                        <a
                            onClick={() => displayPopup("update-weight")}
                            className="Auth-btn-outline"
                        >
                            Update weight
                        </a>
                    </div>
                </div>

                <div className="calories-goal">
                    <h1>GOALS FOR TODAY</h1>

                    <div className="nutrients">
                        {Object.entries(nutrientGoals).map(([key, value]) => (
                            <div className="nutrient">
                                <div className="nutrient-icon">
                                    <svg
                                        className="nutrient-icon-svg"
                                        xmlns="http://www.w3.org/2000/svg"
                                        height="2em"
                                        viewBox={`0 0 ${value[3]} 512`}
                                    >
                                        <path d={value[2]} />
                                    </svg>

                                    <CircularProgress
                                        sx={{
                                            color: "var(--gray)",
                                            position: "absolute",
                                            top: "19%",
                                            left: "19%",
                                            scale: "1.5",
                                        }}
                                        variant="determinate"
                                        value={100}
                                    />
                                    <CircularProgress
                                        sx={{
                                            color: `var(--${value[4]})`,
                                            position: "absolute",
                                            top: "19%",
                                            left: "19%",
                                            scale: "1.5",
                                        }}
                                        variant="determinate"
                                        value={25}
                                    />
                                </div>

                                <p key={key}>
                                    <b>{key}:</b> {value[0]} / {value[1]}
                                </p>
                            </div>
                        ))}
                    </div>
                </div>
            </header>

            <div className="update-weight popup-form">
                <InputForm
                    title="Update weight"
                    fields={{
                        weight: {
                            label: "New weight (kg)",
                            type: "number",
                            value: personalStats.currentWeight,
                        },
                    }}
                    onSuccessfulSubmit={() => {
                        document.querySelector(".popup-form").style.display =
                            "none";

                        window.location.reload(false);
                    }}
                    onBack={() =>
                        (document.querySelector(".popup-form").style.display =
                            "none")
                    }
                    authorize={true}
                    endpoint="/api/PersonalStats"
                    method="PUT"
                    submitLabel="Update"
                />
            </div>

            <footer className="user-footer">
                <div className="footer-card">
                    <h3>MEALS</h3>
                    <Link to="#" className="Auth-btn-outline">
                        Add meals
                    </Link>
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        height="25em"
                        viewBox="0 0 448 512"
                    >
                        <path d="M416 0C400 0 288 32 288 176V288c0 35.3 28.7 64 64 64h32V480c0 17.7 14.3 32 32 32s32-14.3 32-32V352 240 32c0-17.7-14.3-32-32-32zM64 16C64 7.8 57.9 1 49.7 .1S34.2 4.6 32.4 12.5L2.1 148.8C.7 155.1 0 161.5 0 167.9c0 45.9 35.1 83.6 80 87.7V480c0 17.7 14.3 32 32 32s32-14.3 32-32V255.6c44.9-4.1 80-41.8 80-87.7c0-6.4-.7-12.8-2.1-19.1L191.6 12.5c-1.8-8-9.3-13.3-17.4-12.4S160 7.8 160 16V150.2c0 5.4-4.4 9.8-9.8 9.8c-5.1 0-9.3-3.9-9.8-9L127.9 14.6C127.2 6.3 120.3 0 112 0s-15.2 6.3-15.9 14.6L83.7 151c-.5 5.1-4.7 9-9.8 9c-5.4 0-9.8-4.4-9.8-9.8V16zm48.3 152l-.3 0-.3 0 .3-.7 .3 .7z" />
                    </svg>
                </div>

                <div className="footer-card">
                    <h3>WORKOUT</h3>
                    <Link to="/allworkouts" className="Auth-btn-outline">
                        My workouts
                    </Link>
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        height="25em"
                        viewBox="0 0 640 512"
                    >
                        <path d="M96 64c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32V224v64V448c0 17.7-14.3 32-32 32H128c-17.7 0-32-14.3-32-32V384H64c-17.7 0-32-14.3-32-32V288c-17.7 0-32-14.3-32-32s14.3-32 32-32V160c0-17.7 14.3-32 32-32H96V64zm448 0v64h32c17.7 0 32 14.3 32 32v64c17.7 0 32 14.3 32 32s-14.3 32-32 32v64c0 17.7-14.3 32-32 32H544v64c0 17.7-14.3 32-32 32H480c-17.7 0-32-14.3-32-32V288 224 64c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32zM416 224v64H224V224H416z" />
                    </svg>
                </div>
            </footer>
        </>
    );
};

export default Account;
