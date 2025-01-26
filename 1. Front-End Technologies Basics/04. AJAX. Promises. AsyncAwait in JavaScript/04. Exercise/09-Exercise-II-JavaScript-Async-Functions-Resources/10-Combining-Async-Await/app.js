async function asyncGenerator(generatorFunc) {
   const generator = generatorFunc();
   let result = generator.next(); 
   
   while(!result.done){
    try
    {
        const response = await result.value;
        console.log('Success:', response);
    }
    catch(err)
    {
        console.error('Errorrrrr:', err);
    }

    result = generator.next();
   }
}

function* startAsyncGenerator() {
    yield new Promise((resolve) => resolve('Success 1!'));
    yield new Promise((resolve) => resolve('Success 2!'));
    yield new Promise((_, reject) => reject('Failure 1!'));
}

asyncGenerator(startAsyncGenerator);