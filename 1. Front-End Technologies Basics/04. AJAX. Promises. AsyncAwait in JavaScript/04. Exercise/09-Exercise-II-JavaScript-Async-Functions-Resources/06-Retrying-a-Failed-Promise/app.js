async function retryPromise(promiseFunc, retries = 3) {
  let attemptsFailed = 0;

  while(attemptsFailed < retries){
    try
    {
      const result = await promiseFunc();
      console.log(result);
      return;
    }
    catch (err) {
      attemptsFailed++;

      console.log(`Failed attempt #${attemptsFailed}`);

      if(attemptsFailed === 3){
        console.log(err);
      }
    }
  }
}

function createRandomPromise(){
  const randomDecimal = Math.random();

  return new Promise((resolve, reject) => {

    if(randomDecimal >= 0.7){
      resolve('Success!');
    }
    else {
      reject('Failure');
    }
  });
}

retryPromise(createRandomPromise);