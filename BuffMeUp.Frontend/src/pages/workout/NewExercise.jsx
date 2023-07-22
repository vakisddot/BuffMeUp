import InputForm from "../../components/InputForm";

const NewExercise = () => {
    const fields = {
        name: {
            label: "Name",
        },

        description: {
            label: "Description",
            value: "",
        },

        exerciseType: {
            label: "Exercise type",
            type: "radio",
            // TODO: Don't hardcode these... ?
            values: [
                {
                    name: "Back",
                    value: 0,
                    checked: true,
                },
                {
                    name: "Chest",
                    value: 1,
                },
                {
                    name: "Legs",
                    value: 2,
                },
                {
                    name: "Shoulders",
                    value: 3,
                },
                {
                    name: "Triceps",
                    value: 4,
                },
                {
                    name: "Biceps",
                    value: 5,
                },
                {
                    name: "Core",
                    value: 6,
                },
                {
                    name: "Cardio",
                    value: 7,
                },
            ],
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
            title="New exercise"
            modelName="ExerciseTemplate"
            fields={fields}
            endpoint="/api/ExerciseTemplate/New"
            redirect="/allworkouts"
            submitLabel="Create"
            bgSrc="/images/pexels-victor-freitas-841130.jpg"
            toastOnSubmit={true}
            authorize={true}
        />
    );
};

export default NewExercise;
