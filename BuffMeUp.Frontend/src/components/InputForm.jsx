import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

const InputForm = ({
    fields,
    title,
    modelName,
    submitLabel,
    endpoint,
    redirect,
    onSuccessfulSubmit,
}) => {
    const navigate = useNavigate();
    const [errorLabels, setErrorLabels] = useState([]);

    useEffect(() => {
        setErrorLabels(
            Array.from(document.querySelectorAll(".validation-error"))
        );
    }, []);
    console.log("Error labels: ", errorLabels);

    const generalErrorLabel = document.querySelector(".general-error");

    const getErrorLabel = (fieldName) => {
        return errorLabels.find((el) => el.htmlFor === fieldName);
    };

    const validateField = (fieldName, value) => {
        if (fields[fieldName] == null) {
            return false;
        }

        if (fields[fieldName].minValue && value < fields[fieldName].minValue) {
            return false;
        }
        if (fields[fieldName].maxValue && value > fields[fieldName].maxValue) {
            return false;
        }

        if (
            fields[fieldName].minLength &&
            value.length < fields[fieldName].minLength
        ) {
            return false;
        }
        if (
            fields[fieldName].maxLength &&
            value.length > fields[fieldName].maxLength
        ) {
            return false;
        }
        if (fields[fieldName].regex && !value.match(fields[fieldName].regex)) {
            return false;
        }

        if (
            fields[fieldName].shouldEqual &&
            value !== fields[fields[fieldName].shouldEqual].value
        )
            return false;

        return true;
    };

    const updateField = (fieldName, value) => {
        fields[fieldName].value = value;

        fields[fieldName].isValid = validateField(fieldName, value);

        const errorLabel = getErrorLabel(fieldName);
        if (errorLabel)
            errorLabel.style.display = fields[fieldName].isValid
                ? "none"
                : "block";

        console.log(errorLabel);

        console.log(`${fieldName} is valid: ${fields[fieldName].isValid}`);
    };

    const allFieldsAreValid = () => {
        return Object.entries(fields).every(([id, data]) => {
            return data.isValid;
        });
    };

    const submitForm = () => {
        if (!allFieldsAreValid()) {
            generalErrorLabel.setHTML(
                "Some fields are not valid! Cannot submit form yet!"
            );

            return;
        }

        const submitObject = {};
        for (const [key, value] of Object.entries(fields)) {
            if (!value.invisible) {
                submitObject[key] = value.value;
            }
        }

        fetch(endpoint, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(submitObject),
        })
            .then((response) => response.json())
            .then((response) => {
                if (response.status >= 400 && response.status <= 499) {
                    const errors = [];

                    for (const prop in response.errors) {
                        errors.push(...response.errors[prop]);
                    }

                    generalErrorLabel.setHTML(
                        errors.map((e) => `<p>${e}</p>`).join("")
                    );

                    return;
                } else if (response.status >= 500) {
                    generalErrorLabel.setHTML(
                        "Server has failed to process the request!"
                    );

                    return;
                }

                console.log("Form has been successfully submitted!");

                if (onSuccessfulSubmit) onSuccessfulSubmit(response);

                if (redirect) navigate(redirect);
            })
            .catch((err) =>
                console.log("Error while trying to submit form!", err)
            );
    };

    // Fetches the validation constants for the current model
    useEffect(() => {
        const constantsUrl = `/api/ValidationConstants?modelName=${modelName}`;
        let validationConstants = {};

        fetch(constantsUrl)
            .then((response) => {
                return response.json();
            })
            .then((response) => {
                validationConstants = response;
                console.log("Received validation constants!");
                console.log(validationConstants);

                Object.entries(fields).forEach(([id, data]) => {
                    data.isValid = data.type === "radio" ? true : false;
                    data.value = null;

                    if (validationConstants[id])
                        Object.entries(validationConstants[id]).forEach(
                            ([key, value]) => {
                                data[key] = value;
                            }
                        );
                });

                console.log("Updated fields.");
                console.log(fields);
            })
            .catch((err) => console.log(err));
    }, []);

    return (
        <form className="SignUp-form">
            <h1>{title}</h1>

            <label className="red general-error"></label>

            {Object.entries(fields).map(([id, data]) => {
                return data.type !== "radio" ? (
                    <div>
                        <label htmlFor={id} className="red validation-error">
                            Invalid {data.label}!
                        </label>

                        <label htmlFor={id}>{data.label.toUpperCase()}</label>
                        <input
                            type={data.type || "text"}
                            placeholder={data.label}
                            onChange={(e) => {
                                updateField(id, e.target.value);
                            }}
                            id={id}
                            required
                        />
                    </div>
                ) : (
                    <div>
                        <label htmlFor={id}>{data.label.toUpperCase()}</label>

                        <div className="radio">
                            {data.values.map((v) => {
                                return (
                                    <div className="radio-option">
                                        <label htmlFor={id}>{v.name}</label>
                                        <input
                                            type="radio"
                                            id={v.name}
                                            name={id}
                                            checked={v.checked}
                                        />
                                    </div>
                                );
                            })}
                        </div>
                    </div>
                );
            })}

            <div>
                <input
                    className="Auth-btn"
                    type="button"
                    value={submitLabel || "Submit"}
                    onClick={() => submitForm()}
                />
            </div>
        </form>
    );
};

export default InputForm;
