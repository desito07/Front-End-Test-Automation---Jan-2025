async function fetchData() {
    const response = await fetch('https://swapi.dev/api/people/1');
    const characterData = await response.json();
    console.log(characterData);
}
fetchData();