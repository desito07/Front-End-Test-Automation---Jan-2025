async function fetchParallel() {
  const promise1 = fetch('https://swapi.dev/api/people/1');
  const promise2 = fetch('https://swapi.dev/api/people/2');

  const response = await Promise.all([promise1, promise2]);

  //console.log(response);

  for(const responseObj of response){
    const data = await responseObj.json();
    console.log(data);
  } 
}

fetchParallel();