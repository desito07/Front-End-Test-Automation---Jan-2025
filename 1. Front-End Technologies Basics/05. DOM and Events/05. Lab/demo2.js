let input = document.getElementById("username");
let button = document.getElementById("button");
let div = document.getElementById("displayValue");

button.addEventListener("click", () => {
    //div.textContent = input.value;
    div.innerHTML = `<h1>${input.value}</h1>`;
    div.style.color = "blue"
});

div.innerHTML = "<button>I'm a button</button>"
console.log(div.innerHTML);
