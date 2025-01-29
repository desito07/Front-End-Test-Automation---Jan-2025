let button = document.getElementById("button");
let div = document.getElementById("child");

button.addEventListener("click", (event) => {
    div.textContent = "UpdatedChild";
    console.log(event);
});
