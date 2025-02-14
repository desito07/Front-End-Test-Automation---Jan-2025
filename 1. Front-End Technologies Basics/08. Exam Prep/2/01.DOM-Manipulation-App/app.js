window.addEventListener('load', solve);

function solve() {
    let carModelInput = document.getElementById("car-model");
    let carYearInput = document.getElementById("car-year");
    let partNameInput = document.getElementById("part-name");
    let partNumberInput = document.getElementById("part-number");
    let conditionInput = document.getElementById("condition");

    let infoCarModel = document.getElementById("info-car-model");
    let infoCarYear = document.getElementById("info-car-year");
    let infoPartName = document.getElementById("info-part-name");
    let infoPartNumber = document.getElementById("info-part-number");
    let infoCondition = document.getElementById("info-condition");

    let partInfoElement = document.getElementById("part-info");
    let confirmOrderElement = document.getElementById("confirm-order");

    let nextButton = document.getElementById("next-btn");
    nextButton.addEventListener("click", onNext);

    function onNext(e){
        e.preventDefault();

        let carYearNumberValue = Number(carYearInput.value);

        if(carModelInput == "" || partNameInput == "" || partNumberInput == "" || conditionInput == "" || carYearNumberValue < 1990 || carYearNumberValue > 2025)
        {
            return;
        }

        infoCarModel.textContent = carModelInput.value;
        infoCarYear.textContent = carYearInput.value;
        infoPartName.textContent = partNameInput.value;
        infoPartNumber.textContent = partNumberInput.value;
        infoCondition.textContent = conditionInput.value;

        partInfoElement.style.display = "block";
        nextButton.disabled = true; 

        carModelInput.value = "";
        carYearInput.value = "";
        partNameInput.value = "";
        partNumberInput.value = "";
        conditionInput.value = "";
    }

    let editButton = document.getElementById("edit-btn");
    editButton.addEventListener("click", onEdit);

    function onEdit()
    {
        carModelInput.value = infoCarModel.textContent;
        carYearInput.value = infoCarYear.textContent;
        partNameInput.value = infoPartName.textContent;
        partNumberInput.value = infoPartNumber.textContent;
        conditionInput.value = infoCarModel.textContent;

        partInfoElement.style.display = "none";
        nextButton.disabled = false;
    }

    let confirmButton = document.getElementById("confirm-btn");
    confirmButton.addEventListener("click", onConfirm);

    function onConfirm()
    {
        partInfoElement.style.display = "none";
        confirmOrderElement.style.display = "block"

    }

    let newOrderButton = document.getElementById("new-btn");
    newOrderButton.addEventListener("click", onNew);

    function onNew()
    {
        confirmOrderElement.style.display = "none";
        nextButton.disabled = false;
    }
};


    
    
