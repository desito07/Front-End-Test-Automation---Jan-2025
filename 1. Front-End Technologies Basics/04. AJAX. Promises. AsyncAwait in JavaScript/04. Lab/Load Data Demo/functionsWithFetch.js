let button = document.querySelector("#load");
let httpReques;

button.addEventListener('click', eventListeerActionUsingFetch);

function eventListeerActionUsingFetch(){
    fetch('https://api.github.com/users/testnakov/repos')
    .then(response => response.json())
    .then((data) => document.getElementById("res").textContent = data)
    .catch((error) => console.log(error))
}