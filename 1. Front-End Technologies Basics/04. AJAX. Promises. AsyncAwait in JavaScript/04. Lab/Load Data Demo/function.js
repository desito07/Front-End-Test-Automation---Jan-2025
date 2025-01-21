let button = document.querySelector("#load");
let quickButton = document.querySelector("#quickload");
let httpRequest;

button.addEventListener('click', eventListenerAction);
quickButton.addEventListener('click', quickLoad);

function quickLoad(){
    document.getElementById("quickRes").textContent = "It's working while waiting for github response."
}

function eventListenerAction(){
    let url = 'https://api.github.com/users/testnakov/repos';
    httpRequest = new XMLHttpRequest();
    httpRequest.addEventListener('readystatechange', httpHadler);
    httpRequest.open("GET", url);
    httpRequest.send();
}

 
async function httpHadler(){


    
    await sleep(10000);
    if(httpRequest.readyState === 4 && httpRequest.status === 200){
        document.getElementById("res").textContent = httpRequest.responseText;
    }
}

function sleep(ms){
    return new Promise(resolve => setTimeout(resolve, ms));
}