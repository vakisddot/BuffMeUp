import React, { useEffect, useState } from "react";
import { fetchAuthenticated, setTitle } from "../../utils";
import "./AdminPanel.css";
import InputForm from "../../components/InputForm";
import { displayPopup, hidePopup } from "../../components/popupFormUtils";
import jwt_decode from "jwt-decode";

function AdminPanel() {
    useEffect(() => setTitle("Admin"), []);

    const token = localStorage.getItem("token");
    const claims = jwt_decode(token);

    const [accounts, setAccounts] = useState([]);
    const [currId, setCurrId] = useState();

    const [refresh, setRefresh] = useState(false);

    useEffect(() => {
        fetchAuthenticated("/api/Account")
            .then((res) => res.json())
            .then((res) => setAccounts(res));
    }, [refresh]);

    return (
        <div>
            <header className="admin-header">
                <h1>Admin panel</h1>
            </header>
            <main>
                <h2>Accounts</h2>

                <div className="popup-form delete-acc">
                    <InputForm
                        title={"Are you sure?"}
                        fields={{}}
                        submitFields={{
                            id: currId,
                        }}
                        onSuccessfulSubmit={(response, submitObject) => {
                            setRefresh(!refresh);
                            hidePopup("delete-acc");
                        }}
                        onBack={() => hidePopup("delete-acc")}
                        authorize={true}
                        endpoint="/api/Account"
                        submitLabel="Delete"
                        method="DELETE"
                        toastOnSubmit={true}
                    />
                </div>

                <div className="update-role popup-form">
                    <InputForm
                        title="Update role"
                        fields={{
                            role: {
                                label: "Role",
                                value: accounts.filter((a) => a.id === currId)
                                    .role,
                            },
                        }}
                        submitFields={{
                            id: currId,
                        }}
                        onSuccessfulSubmit={() => {
                            if (currId === claims?.userId) {
                                localStorage.removeItem("token");
                                window.location.href = "/login";
                            } else {
                                setRefresh(!refresh);
                                hidePopup("update-role");
                            }
                        }}
                        onBack={() => hidePopup("update-role")}
                        authorize={true}
                        endpoint="/api/Account/Role"
                        method="PUT"
                        submitLabel="Update"
                        toastOnSubmit={true}
                    />
                </div>

                <div className="accounts">
                    <div className="column-headers">
                        <p>Avatar</p>
                        <p>Username</p>
                        <p>Email</p>
                        <p className="align-center">Role</p>
                        <p className="align-right">Actions</p>
                    </div>
                    {accounts.map((acc) => {
                        return (
                            <div className="account">
                                <div className="account-info">
                                    <img
                                        src={
                                            acc.avatar
                                                ? `data:image/png;base64,${acc.avatar}`
                                                : "/images/no_avatar.png"
                                        }
                                    />
                                    <strong>@{acc.username}</strong>
                                    <p>{acc.email}</p>
                                    <strong
                                        className={`align-center ${
                                            acc.role.toLowerCase() ===
                                                "admin" && "Chest-col"
                                        }`}
                                    >
                                        {acc.role.toUpperCase()}
                                    </strong>
                                    <div
                                        className="ud-buttons"
                                        style={{ justifySelf: "right" }}
                                    >
                                        <a
                                            className="Edit-btn"
                                            onClick={(e) => {
                                                e.preventDefault();
                                                setCurrId(acc.id);
                                                displayPopup("update-role");
                                            }}
                                        >
                                            <svg
                                                xmlns="http://www.w3.org/2000/svg"
                                                height="1em"
                                                viewBox="0 0 512 512"
                                            >
                                                <path d="M471.6 21.7c-21.9-21.9-57.3-21.9-79.2 0L362.3 51.7l97.9 97.9 30.1-30.1c21.9-21.9 21.9-57.3 0-79.2L471.6 21.7zm-299.2 220c-6.1 6.1-10.8 13.6-13.5 21.9l-29.6 88.8c-2.9 8.6-.6 18.1 5.8 24.6s15.9 8.7 24.6 5.8l88.8-29.6c8.2-2.7 15.7-7.4 21.9-13.5L437.7 172.3 339.7 74.3 172.4 241.7zM96 64C43 64 0 107 0 160V416c0 53 43 96 96 96H352c53 0 96-43 96-96V320c0-17.7-14.3-32-32-32s-32 14.3-32 32v96c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V160c0-17.7 14.3-32 32-32h96c17.7 0 32-14.3 32-32s-14.3-32-32-32H96z" />
                                            </svg>
                                        </a>
                                        <a
                                            className="Delete-btn"
                                            onClick={(e) => {
                                                e.preventDefault();
                                                setCurrId(acc.id);
                                                displayPopup("delete-acc");
                                            }}
                                        >
                                            <svg
                                                xmlns="http://www.w3.org/2000/svg"
                                                height="1em"
                                                viewBox="0 0 448 512"
                                            >
                                                <path d="M135.2 17.7L128 32H32C14.3 32 0 46.3 0 64S14.3 96 32 96H416c17.7 0 32-14.3 32-32s-14.3-32-32-32H320l-7.2-14.3C307.4 6.8 296.3 0 284.2 0H163.8c-12.1 0-23.2 6.8-28.6 17.7zM416 128H32L53.2 467c1.6 25.3 22.6 45 47.9 45H346.9c25.3 0 46.3-19.7 47.9-45L416 128z" />
                                            </svg>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        );
                    })}
                </div>
            </main>
        </div>
    );
}

export default AdminPanel;
