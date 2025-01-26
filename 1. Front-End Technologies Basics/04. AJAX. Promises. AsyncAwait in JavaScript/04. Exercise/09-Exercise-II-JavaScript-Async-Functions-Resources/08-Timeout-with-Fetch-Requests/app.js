async function fetchWithTimeout(url = "https://swapi.dev/api/people/1", timeout = 2000) {

    try
    {
        const result = await Promise.race([
            fetch(url), 
            new Promise((resolve, reject) => {
                setTimeout(() => {
                    reject('Timeout has passed.')
                }, timeout);
            })
        ]);
    
        const data = await result.json();
        console.log(data);
    }
    catch(err)
    {
        console.error(err);
    }
    
}

fetchWithTimeout();