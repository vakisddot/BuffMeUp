import React, { useEffect, useState, useRef } from "react";

const About = () => {
    const url = `/api/WeatherForecast`;

    const [values, setValues] = useState([]);

    useEffect(() => {
        fetch(url)
            .then((response) => {
                return response.json();
            })
            .then((response) => {
                setValues(response);
                console.log(response);
            })
            .catch((err) => console.log(err));
    }, []);

    return (
        <>
            {values.length > 0 ? (
                values.map((v) => (
                    <div>
                        <p>asd</p>
                        <div>{v.date}</div>
                        <div>{v.temperatureC}*C</div>
                        <div>{v.temperatureF}*F</div>
                    </div>
                ))
            ) : (
                <p>Nada :/</p>
            )}
        </>
    );
};

export default About;
