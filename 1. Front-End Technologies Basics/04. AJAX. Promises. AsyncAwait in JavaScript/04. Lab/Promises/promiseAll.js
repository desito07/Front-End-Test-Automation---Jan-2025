function fetchData1(){
    return new Promise(resolve => {
        setTimeout(() => resolve("Data from API 1"), 1000)
    })
}

// Promise.all ['Data from API 1', 'Data from API 2', 'Data from API 3']
/*function fetchData2(){
    return new Promise(resolve => {
        setTimeout(() => resolve("Data from API 2"), 2000)
    })
}*/

function fetchData2(){
    return Promise.reject("Rejected")
}

function fetchData3(){
    return new Promise(resolve => {
        setTimeout(() => resolve("Data from API 3"), 1500)
    })
}

//Promise.all([fetchData1(), fetchData2(), fetchData3()]) //Rejected
//Promise.allSettled([fetchData1(), fetchData2(), fetchData3()])  //[{…}, {…}, {…}]
//Promise.race([fetchData1(), fetchData2(), fetchData3()]) //Rejected
Promise.race([fetchData1(), fetchData2(), fetchData3()])
.then(results => {
        console.log(results)
})
.catch(error => {
    console.log(error)
})
.finally( () => {
    console.log("data cleanUp")  //data cleanUp
})