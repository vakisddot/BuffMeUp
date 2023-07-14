import "./PersonalStats.css";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";

const PersonalStats2 = () => {
    const token = localStorage.getItem("token");
    const claims = jwt_decode(token);

    const navigate = useNavigate();
    const constantsUrl = "/api/ValidationConstants?modelName=PersonalStats";
    const signUpEndpoint = "/api/SignUp";

    const [age, setAge] = useState(0);
    const [gender, setGender] = useState(true);
    const [height, setHeight] = useState(0);
    const [weight, setWeight] = useState(0);
    const [goalWeight, setGoalWeight] = useState(0);
    const [validationConstants, setValidationConstants] = useState({});
    const [fieldErrors, setFieldErrors] = useState(
        () => new Set(["age", "height", "weight", "goalWeight"])
    );

    const errorLabels = Array.from(
        document.querySelectorAll(".validation-error")
    );
    const generalErrorLabel = document.querySelector(".general-error");

    const getErrorLabel = (fieldName) => {
        return errorLabels.find((el) => el.htmlFor === fieldName);
    };

    const validateField = (fieldName, value) => {
        const minLengthName = `${fieldName}MinLength`;
        const maxLengthName = `${fieldName}MaxLength`;
        const regexName = `${fieldName}Regex`;

        if (
            validationConstants[minLengthName] &&
            value.length < validationConstants[minLengthName]
        )
            return false;

        if (
            validationConstants[maxLengthName] &&
            value.length > validationConstants[maxLengthName]
        )
            return false;

        if (
            validationConstants[regexName] &&
            !value.match(validationConstants[regexName])
        )
            return false;

        return true;
    };

    const tryUpdateField = (fieldName, value) => {
        const isValid = validateField(fieldName, value);

        if (isValid) {
            setFieldErrors((current) => {
                const next = new Set(current);
                next.delete(fieldName);
                return next;
            });
        } else {
            setFieldErrors((current) => new Set(current).add(fieldName));
        }

        console.log(fieldErrors);

        // Updates the proper label
        const errorLabel = getErrorLabel(fieldName);

        if (!errorLabel) return;

        if (isValid) {
            errorLabel.style.display = "none";
        } else {
            errorLabel.style.display = "block";
        }
    };

    const trySignUp = () => {
        if (fieldErrors.size > 0) {
            alert("Make sure that all fields are correct before submitting!");
            return;
        }

        fetch(signUpEndpoint, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                age,
                gender,
                height,
                weight,
                goalWeight,
            }),
        })
            .then((response) => response.json())
            .then((response) => {
                if (response.errors) {
                    const errors = [];

                    console.log(response);
                    console.log(response.errors);

                    for (const prop in response.errors) {
                        errors.push(...response.errors[prop]);
                    }

                    generalErrorLabel.setHTML(
                        errors.map((e) => `<p>${e}</p>`).join("")
                    );

                    return;
                }

                console.log("Successfuly signed up!");
                localStorage.setItem("token", response.token);
                navigate("/account");
            })
            .catch((err) => console.log("Error while trying to sign up!", err));
    };

    useEffect(() => {
        fetch(constantsUrl)
            .then((response) => {
                return response.json();
            })
            .then((response) => {
                setValidationConstants(response);
                console.log(response);
            })
            .catch((err) => console.log(err));
    }, []);

    return (
        <div className="SignUp">
            <div className="SignUp-form">
                <h1>
                    {claims?.firstName || "Unknown"}, we would like to know more
                    about you...
                </h1>

                <label className="red general-error"></label>

                <div>
                    <label htmlFor="genders">GENDER</label>
                    <div id="genders">
                        <div>
                            <label htmlFor="male">Male</label>
                            <input
                                type="radio"
                                id="male"
                                onChange={(e) => {
                                    setGender(true);
                                }}
                                name="genders"
                            />
                        </div>

                        <div>
                            <label htmlFor="female">Female</label>
                            <input
                                type="radio"
                                id="female"
                                onChange={(e) => {
                                    setGender(false);
                                }}
                                name="genders"
                            />
                        </div>
                    </div>
                </div>

                <div>
                    <label htmlFor="age" className="red validation-error">
                        Invalid age!
                    </label>
                    <label htmlFor="age">AGE</label>
                    <input
                        type="number"
                        onChange={(e) => {
                            setAge(e.target.value);

                            tryUpdateField("age", e.target.value);
                        }}
                        placeholder="Age"
                        id="age"
                        required
                    />
                </div>

                <div>
                    <label htmlFor="height" className="red validation-error">
                        Invalid height!
                    </label>
                    <label htmlFor="height">HEIGHT (CM)</label>
                    <input
                        type="number"
                        onChange={(e) => {
                            setHeight(e.target.value);

                            tryUpdateField("height", e.target.value);
                        }}
                        placeholder="Height"
                        id="height"
                        required
                    />
                </div>

                <div>
                    <label htmlFor="weight" className="red validation-error">
                        Invalid weight!
                    </label>
                    <label htmlFor="weight">WEIGHT (KG)</label>
                    <input
                        type="number"
                        onChange={(e) => {
                            setHeight(e.target.value);

                            tryUpdateField("weight", e.target.value);
                        }}
                        placeholder="Weight"
                        id="weight"
                        required
                    />
                </div>

                <div>
                    <label
                        htmlFor="goalWeight"
                        className="red validation-error"
                    >
                        Invalid weight!
                    </label>
                    <label htmlFor="goalWeight">GOAL WEIGHT (KG)</label>
                    <input
                        type="number"
                        onChange={(e) => {
                            setHeight(e.target.value);

                            tryUpdateField("goalWeight", e.target.value);
                        }}
                        placeholder="Goal weight"
                        id="goalWeight"
                        required
                    />
                </div>

                <div>
                    <input
                        className="Auth-btn"
                        type="button"
                        value="Submit"
                        onClick={() => trySignUp()}
                    />
                </div>
            </div>
        </div>
    );
};

export default PersonalStats2;
