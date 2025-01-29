const button = document.getElementById("button");
button.addEventListener("mouseover", function (e) {
const buttonElementStyles = e.currentTarget.style;
buttonElementStyles.backgroundColor = "red";
});

button.addEventListener("mouseout", function (e) {
const buttonElementStyles = e.currentTarget.style;
buttonElementStyles.backgroundColor = "blue";
});

