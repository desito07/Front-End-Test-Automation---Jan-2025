document.body.innerHTML = 
`
<div class= "box">BOX1</div>
<div class= "box">BOX2</div>
`

let htmlCollection = document.getElementsByClassName("box");
console.log("Initial HTML Collection: ", htmlCollection);

let newDiv = document.createElement("div");
newDiv.className = "box";
newDiv.textContent = "BOX3";
document.body.appendChild(newDiv);

console.log("HTML Collection after adding elements", htmlCollection);

