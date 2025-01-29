
let parent = document.getElementById("parent");
let newChild = document.createElement("div");
let firstChild = document.getElementById("child");

newChild.textContent = "I'm child 2";
parent.appendChild(newChild);
parent.removeChild(firstChild);


