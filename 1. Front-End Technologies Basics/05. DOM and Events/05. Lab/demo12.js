let parentDiv = document.createElement("div");
parentDiv.style.width = "300px";
parentDiv.style.height = "300px";
parentDiv.style.border = "2px solid blue";
parentDiv.style.display = "flex";
parentDiv.style.alignItems = "center";
parentDiv.style.justifyContent = "center";

document.body.appendChild(parentDiv);

let buttonChild = document.createElement("button");
buttonChild.textContent = "Click Me";
parentDiv.appendChild(buttonChild);

parentDiv.addEventListener("click", (event) => {
    console.log("Parent Clcik Handler"); 
    console.log("Target:" , event.target);
    console.log("Current Target:", event.currentTarget);
})