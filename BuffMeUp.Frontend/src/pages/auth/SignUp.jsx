import InputForm from "../../components/InputForm";
import { useEffect } from "react";
import { setTitle } from "../../utils";

const SignUp = () => {
    useEffect(() => setTitle("Sign up"), []);

    const fields = {
        firstName: {
            label: "First name",
        },

        username: {
            label: "Username",
        },

        email: {
            label: "E-Mail",
            type: "email",
        },

        password: {
            label: "Password",
            type: "password",
        },

        confirmPassword: {
            label: "Confirm password",
            type: "password",
            shouldEqual: "password",
            invisible: true,
        },
    };

    return (
        <InputForm
            title="Sign up"
            modelName="User"
            fields={fields}
            endpoint="/api/Account/SignUp"
            redirect="/personalstats"
            submitLabel="Sign up"
            onSuccessfulSubmit={(response) =>
                localStorage.setItem("token", response.token)
            }
            bgSrc="/images/pexels-tetyana-kovyrina-2988229.jpg"
        />
    );
};

export default SignUp;
