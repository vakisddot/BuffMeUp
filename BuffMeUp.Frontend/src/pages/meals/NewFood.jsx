import { useEffect } from "react";
import InputForm from "../../components/InputForm";
import { setTitle } from "../../utils";

const NewFood = () => {
    useEffect(() => setTitle("New Food"), []);

    const fields = {
        name: {
            label: "Name",
        },

        protein: {
            label: "Protein (per 100g)",
            type: "number",
        },

        fats: {
            label: "Fats (per 100g)",
            type: "number",
        },

        carbs: {
            label: "Carbs (per 100g)",
            type: "number",
        },

        isGlobal: {
            label: "Visible to...",
            type: "radio",
            values: [
                {
                    name: "Everyone",
                    value: true,
                },
                {
                    name: "Just me",
                    value: false,
                    checked: true,
                },
            ],
        },
    };

    return (
        <InputForm
            title="New food"
            modelName="FoodItem"
            fields={fields}
            endpoint="/api/FoodItem"
            redirect="/allmeals"
            submitLabel="Create"
            bgSrc="/images/pexels-luna-lovegood-4087609.jpg"
            toastOnSubmit={true}
            authorize={true}
        />
    );
};

export default NewFood;
