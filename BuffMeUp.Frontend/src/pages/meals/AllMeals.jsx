import React, { useEffect, useState } from "react";
import "./AllMeals.css";
import { Link } from "react-router-dom";
import { useSearchParams } from "react-router-dom";
import { fetchAuthenticated, getClaims, getQueryString } from "../../utils";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import InputForm from "../../components/InputForm";
import { displayPopup, hidePopup } from "../../components/popupFormUtils";

function AllMeals() {
    const [searchParams] = useSearchParams();

    const today = new Date().toISOString().split("T")[0];

    const [dateChanged, setDateChanged] = useState(false);

    searchParams.get("date") || searchParams.set("date", today);

    useEffect(() => {
        document.querySelector("input[type='date']").value =
            searchParams.get("date");
    }, []);

    return (
        <>
            <header className="Meals-header">
                <h1>
                    Meals for {searchParams.get("date").split("-").join("/")}
                </h1>
                <div className="date">
                    <input type="date" />
                    <a href="#" className="Auth-btn-fill">
                        Go to date
                    </a>
                </div>
                <a href="#" className="Auth-btn-fill">
                    Add new meal
                </a>
                <img src="/images/pexels-alexy-almond-3758133.jpg" alt="" />
            </header>
            <main className="meals-all">
                <section className="meals breakfast">
                    <h2>BREAKFAST</h2>
                </section>
                <section className="meals lunch">
                    <h2>LUNCH</h2>
                </section>
                <section className="meals dinner">
                    <h2>DINNER</h2>
                </section>
            </main>
        </>
    );
}

export default AllMeals;
