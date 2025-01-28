const parent = document.createElement("div");
parent.id = "parent";
document.body.appendChild(parent);

const child1 = document.createElement('p');
child1.textContent = "This is the first child";
parent.appendChild(child1);

const child2 = document.createElement('p');
child2.textContent = "This is the second child";
parent.appendChild(child2);

console.log("Before change");
console.log(parent.innerHTML);

parent.innerHTML = "<p>I'm a paragraph</p>"

console.log("After change");
console.log(parent.innerHTML);
