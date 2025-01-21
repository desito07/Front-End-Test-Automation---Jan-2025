let promise = new Promise(function(resolve, reject){
    setTimeout(() => {

        let success = true; //Operation successfull
        if(success){
            resolve("Operation successfull");
        }
        else {
            reject("Operation failed");
        }
    }, 1000)
})

promise
.then(function (result){
    console.log(result);
})
.catch(function (error){
    console.log(error);
})