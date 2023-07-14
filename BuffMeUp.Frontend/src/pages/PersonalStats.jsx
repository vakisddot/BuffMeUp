import "./PersonalStats.css";
import InputForm from "../components/InputForm";
import jwt_decode from "jwt-decode";

const PersonalStats = () => {
    const token = localStorage.getItem("token");
    const claims = jwt_decode(token);

    const fields = {
        gender: {
            label: "Gender",
            type: "radio",
            values: [
                {
                    name: "Male",
                    value: true,
                    checked: true,
                },
                {
                    name: "Female",
                    value: false,
                },
            ],
        },

        age: {
            label: "Age",
            type: "number",
        },

        height: {
            label: "Height (cm)",
            type: "number",
        },

        weight: {
            label: "Weight (kg)",
            type: "number",
        },

        goalWeight: {
            label: "Goal Weight (kg)",
            type: "number",
            shouldEqual: "weight",
        },
    };

    return (
        <InputForm
            title={`${
                claims?.firstName || "Unknown"
            }, we would like to know more
                    about you...`}
            modelName="PersonalStats"
            fields={fields}
            endpoint="/api/SignUp"
            redirect="/"
        />
    );
};

export default PersonalStats;
