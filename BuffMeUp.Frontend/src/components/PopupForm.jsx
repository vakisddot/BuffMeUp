import InputForm from "./InputForm";
import { useState } from "react";

const PopupForm = ({ show, toggleShow, ...props }) => {
    const handleClose = () => {
        if (toggleShow) {
            toggleShow(false);
        }
    };

    if (!show) {
        return null;
    }

    return (
        <div className="popup-form">
            <InputForm
                {...props}
                onBack={handleClose}
                onSuccessfulSubmit={(response, submitObject) => {
                    if (props.onSuccessfulSubmit) {
                        props.onSuccessfulSubmit(response, submitObject);
                    }
                    handleClose();
                }}
            />
        </div>
    );
};

export default PopupForm;
