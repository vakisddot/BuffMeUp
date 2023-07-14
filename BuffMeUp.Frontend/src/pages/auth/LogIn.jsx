import InputForm from "../../components/InputForm";
import "./SignUp.css";

const LogIn = () => {
    const fields = {
        username: {
            label: "Username",
        },

        password: {
            label: "Password",
            type: "password",
        },
    };

    return (
        <InputForm
            title="Log in"
            modelName="User"
            fields={fields}
            endpoint="/api/LogIn"
            redirect="/account"
            onSuccessfulSubmit={(response) =>
                localStorage.setItem("token", response.token)
            }
        />
    );
};

export default LogIn;
