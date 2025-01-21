function validateInput (input){
    if(input !== "expectedInput"){
        return Promise.reject("InvalidInput")
    }

    return Promise.resolve("ValidPormise");

}

validateInput("afdasd")
.then(result => {
    console.log(result)
})
.catch(error => {
    console.log(error)
})



