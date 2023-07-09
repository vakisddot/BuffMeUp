import "./SignUp.css";
import { useState, useEffect } from "react";
import { endpoint } from "../../endpoints";

const SignUp = () => {
    const constantsUrl = `${endpoint}/ValidationConstants?modelName=User`;
    const signUpEndpoint = `${endpoint}/SignUp`;

    const [firstName, setFirstName] = useState("");
    const [email, setEmail] = useState("");
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [validationConstants, setValidationConstants] = useState({});
    const [fieldErrors, setFieldErrors] = useState(
        () =>
            new Set([
                "firstName",
                "email",
                "username",
                "password",
                "confirmPassword",
            ])
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

        fetch(signUpEndpoint, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                username: username,
                password: password,
                email: email,
                firstName: firstName,
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
                console.log(response);
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
                <h1>Sign up</h1>

                <label className="red general-error"></label>

                <div>
                    <label htmlFor="firstName" className="red validation-error">
                        Invalid first name!
                    </label>
                    <label htmlFor="firstName">FIRST NAME</label>
                    <input
                        type="text"
                        onChange={(e) => {
                            setFirstName(e.target.value);

                            tryUpdateField("firstName", e.target.value);
                        }}
                        placeholder="First name"
                        id="firstName"
                        required
                    />
                </div>

                <div>
                    <label htmlFor="email" className="red validation-error">
                        Invalid e-mail!
                    </label>
                    <label htmlFor="email">E-MAIL</label>
                    <input
                        type="email"
                        onChange={(e) => {
                            setEmail(e.target.value);

                            tryUpdateField("email", e.target.value);
                        }}
                        placeholder="E-mail"
                        id="email"
                    />
                </div>

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

                            tryUpdateField(
                                "password",
                                e.target.value,
                                confirmPassword
                            );
                        }}
                        placeholder="Password"
                        id="password"
                        required
                    />
                </div>

                <div>
                    <label
                        htmlFor="confirmPassword"
                        className="red validation-error"
                    >
                        Passwords don't match!
                    </label>
                    <label htmlFor="confirmPassword">CONFIRM PASSWORD</label>
                    <input
                        type="password"
                        onChange={(e) => {
                            setConfirmPassword(e.target.value);

                            tryUpdateField(
                                "confirmPassword",
                                e.target.value,
                                password
                            );
                        }}
                        placeholder="Confirm password"
                        id="confirmPassword"
                        required
                    />
                </div>

                <div>
                    <input
                        className="Auth-btn"
                        type="button"
                        value="Sign up"
                        onClick={() => trySignUp()}
                    />
                </div>

                <img src="/images/pexels-tetyana-kovyrina-2988229.jpg" alt="" />
            </div>
        </div>
    );
};

export default SignUp;
