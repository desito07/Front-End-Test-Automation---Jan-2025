let parentElement = document.createElement("div");
parentElement.id = "parentElement";
parentElement.textContent = "Parent";
document.body.appendChild(parentElement);

let childElement = document.createElement("div");
childElement.id = "childElement";
childElement.textContent = "Child";
parentElement.appendChild(childElement); 
