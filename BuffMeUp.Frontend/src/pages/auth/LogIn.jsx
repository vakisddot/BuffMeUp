import InputForm from "../../components/InputForm";

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
            endpoint="/api/Account/LogIn"
            redirect="/account"
            submitLabel="Log in"
            onSuccessfulSubmit={(response) =>
                localStorage.setItem("token", response.token)
            }
            bgSrc="/images/pexels-mali-maeder-65175.jpg"
        />
    );
};

export default LogIn;
