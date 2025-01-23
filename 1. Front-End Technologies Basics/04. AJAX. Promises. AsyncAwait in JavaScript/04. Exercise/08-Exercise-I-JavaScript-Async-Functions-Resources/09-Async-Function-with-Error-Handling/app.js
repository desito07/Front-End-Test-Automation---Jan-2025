async function promiseRejectionAsync() {
   try{
      await new Promise((resolve, reject) => {   
         setTimeout(() => {
            reject(new Error("oops!")) 
         }, 1000);

         //code to be executed after promise is resolved successufully
      })
   }

   catch(error) {

      // code to be executed after promise is rejected
      console.error(error);
   }
}
promiseRejectionAsync();