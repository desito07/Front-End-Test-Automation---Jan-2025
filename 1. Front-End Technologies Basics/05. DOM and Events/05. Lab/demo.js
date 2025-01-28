/*let newDiv = document.createElement("div");
document.body.appendChild(newDiv)*/

for(let i = 1; i <= 10; i++){
    let div = document.createElement("div");
    div.textContent = "This is div " + i;
    div.style.color = "blue";
    document.body.appendChild(div);
}