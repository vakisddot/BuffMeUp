export function displayPopup(name, title) {
    const form = document.querySelector(`.popup-form.${name}`);

    if (form) form.style.display = "block";
}

export function hidePopup(name) {
    const form = document.querySelector(`.popup-form.${name}`);

    if (form) form.style.display = "none";
}
