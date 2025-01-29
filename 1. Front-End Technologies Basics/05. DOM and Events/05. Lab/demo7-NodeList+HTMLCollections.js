document.body.innerHTML = `<div id='example'>
<span>Text 1</span>
<span>Text 2</span>
</div>`

const div = document.getElementById("example");

//console.log("Child nodes (Nodelist): ", div.childNodes);

console.log("Child nodes (HTMLCollection): ", div.children);