import "./SignUp.css";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

const LogIn = () => {
    const navigate = useNavigate();
    const constantsUrl = "/api/ValidationConstants?modelName=User";
    const logInEndpoint = "/api/LogIn";

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [validationConstants, setValidationConstants] = useState({});
    const [fieldErrors, setFieldErrors] = useState(
        () => new Set(["username", "password"])
    );

    const errorLabels = Array.from(
        document.querySelectorAll(".validation-error")
    );
    const generalErrorLabel = document.querySelector(".general-error");

    const getErrorLabel = (fieldName) => {
        return errorLabels.find((el) => el.htmlFor === fieldName);
    };

    const validateField = (fieldName, value, shouldBeEqualTo) => {
        const minLengthName = `${fieldName}MinLength`;
        const maxLengthName = `${fieldName}MaxLength`;
        const regexName = `${fieldName}Regex`;

        if (shouldBeEqualTo && value !== shouldBeEqualTo) return false;

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

    const tryUpdateField = (fieldName, value, shouldBeEqualTo) => {
        const isValid = validateField(fieldName, value, shouldBeEqualTo);

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

        fetch(logInEndpoint, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                username: username,
                password: password,
            }),
        })
            .then((response) => response.json())
            .then((response) => {
                if (response.status === 401) {
                    generalErrorLabel.setHTML(
                        "Invalid username and/or password!"
                    );

                    return;
                }

                console.log("Successfuly logged in!");
                localStorage.setItem("token", response.token);
                navigate("/account");
            })
            .catch((err) => console.log("Error while trying to log in!", err));
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
                <h1>Log in</h1>

                <label className="red general-error"></label>

                <div>
                    <label htmlFor="username" className="red validation-error">
                        Invalid username!
                    </label>
                    <label htmlFor="username">USERNAME</label>
                    <input
                        type="text"
                        onChange={(e) => {
                            setUsername(e.target.value);

                            tryUpdateField("username", e.target.value);
                        }}
                        placeholder="Username"
                        id="username"
                        required
                    />
                </div>

                <div>
                    <label htmlFor="password" className="red validation-error">
                        Invalid password!
                    </label>
                    <label htmlFor="password">PASSWORD</label>
                    <input
                        type="password"
                        onChange={(e) => {
                            setPassword(e.target.value);

                            tryUpdateField("password", e.target.value);
                        }}
                        placeholder="Password"
                        id="password"
                        required
                    />
                </div>

                <div>
                    <input
                        className="Auth-btn"
                        type="button"
                        value="Log in"
                        onClick={() => trySignUp()}
                    />
                </div>

                <img src="/images/pexels-tetyana-kovyrina-2988229.jpg" alt="" />
            </div>
        </div>
    );
};

export default LogIn;
