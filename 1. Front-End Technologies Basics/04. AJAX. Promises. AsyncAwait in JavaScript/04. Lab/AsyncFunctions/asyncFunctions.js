function resolveAfter2Seconds(){ 
    return new Promise(resolve => {
    setTimeout(()=>{
    resolve('resolved');
    },2000);
    });
    }

  async function asyncCall() {
        console.log('calling before');
        let result = await resolveAfter2Seconds();
        console.log(result);
        console.log('calling after');
        }  

asyncCall()