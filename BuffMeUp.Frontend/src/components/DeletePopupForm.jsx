import React from "react";
import InputForm from "./InputForm";

function DeletePopupForm({ name, title, id, endpoint, onConfirm }) {
    const token = localStorage.getItem("token");

    return (
        <div className={`popup-form ${name}`}>
            <InputForm
                title={title || "Are you sure?"}
                onBack={() =>
                    (document.querySelector(
                        `.popup-form ${name}`
                    ).style.display = "none")
                }
                fields={{}}
                submitFields={{ id }}
                endpoint={endpoint}
                method="POST"
                headers={{
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + token,
                }}
                submitLabel="Confirm"
                backLabel="Cancel"
            />
        </div>
    );
}

export default DeletePopupForm;
