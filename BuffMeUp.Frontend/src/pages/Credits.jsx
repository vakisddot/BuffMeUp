import "./Credits.css";

const contributors = [
    {
        name: "Ivaylo D.",
        description: "App developer",
    },
    {
        name: "KolyoG",
        description: "Came up with the name 'BuffMeUp'",
    },
    {
        name: "Pexels",
        description: "Provider of stock photos",
    },
    {
        name: "FontAwesome",
        description: "Provider of icons",
    },
];

const Credits = () => {
    return (
        <div className="contributors">
            {contributors.map((c) => (
                <div className="contributor">
                    <h2>{c.name}</h2>
                    <p>{c.description}</p>
                </div>
            ))}
        </div>
    );
};

export default Credits;
