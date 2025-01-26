async function fetchDataWithErrorHandling() {
    try 
    {
        const response = await fetch('https://swapi.dev/api/peple/1'); //the URL is broken
        //console.log(characterData);

        if(!response.ok){
            throw new Error('Something went wrong');
        }

        const characterData = await response.json();
        console.log(characterData);
    }
    catch(err)
    {
        console.log('Errorrrrrr', err.message);
    }
}
fetchDataWithErrorHandling();