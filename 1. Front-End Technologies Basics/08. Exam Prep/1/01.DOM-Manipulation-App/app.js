window.addEventListener("load", solve);

function solve() {
    let ticketsNumberInput = document.getElementById("num-tickets");
    let seatingPreferenceInput = document.getElementById("seating-preference");
    let fullNameInput = document.getElementById("full-name");
    let emailInput = document.getElementById("email");
    let phoneNumberInput = document.getElementById("phone-number");

    let purchaseButton = document.getElementById("purchase-btn");
    let ticketPreviewElement = document.getElementById("ticket-preview");
    let puchaseSuccess = document.getElementById("purchase-success");
    
    let purchaseTicketNumber = document.getElementById("purchase-num-tickets");
    let purchaseSeatingPreference = document.getElementById("purchase-seating-preference");
    let purchaseFullName = document.getElementById("purchase-full-name");
    let purchaseEmail = document.getElementById("purchase-email");
    let purchasePhoneNumber = document.getElementById("purchase-phone-number");
    
    /*purchaseButton.addEventListener("click", printValues)
    function printValues()
    {
        console.log(ticketsNumberInput.value);
        console.log(seatingPreferenceInput.value);
        console.log(fullNameInput.value);
        console.log(emailInput.value);
        console.log(phoneNumberInput.value);
    }*/

        purchaseButton.addEventListener("click", previewTickets);

        function previewTickets(e)
        {
            e.preventDefault();

            if(ticketsNumberInput.value == "" || seatingPreferenceInput.value == "seating-preference" || fullNameInput.value == "" || emailInput.value == "" || phoneNumberInput.value == "")
            {
                return;
            }

            purchaseTicketNumber.textContent = ticketsNumberInput.value;
            purchaseSeatingPreference.textContent = seatingPreferenceInput.value;
            purchaseFullName.textContent = fullNameInput.value;
            purchaseEmail.textContent = emailInput.value;
            purchasePhoneNumber.textContent = phoneNumberInput.value;

            ticketPreviewElement.style.display = "block";
            purchaseButton.disabled = true;

            ticketsNumberInput.value = "";
            seatingPreferenceInput.value = "seating-preference";
            fullNameInput.value = "";
            emailInput.value = "";
            phoneNumberInput.value = "";
        }
        
        let editButton = document.getElementById("edit-btn");
        editButton.addEventListener("click", onEdit);

        function onEdit()
        {
            ticketsNumberInput.value = purchaseTicketNumber.textContent;
            seatingPreferenceInput.value = purchaseSeatingPreference.textContent;
            fullNameInput.value = purchaseFullName.textContent;
            emailInput.value = purchaseEmail.textContent;
            phoneNumberInput.value = purchasePhoneNumber.textContent;

            ticketPreviewElement.style.display = "none";
            purchaseButton.disabled = false;
        }

        let buyButton = document.getElementById("buy-btn");
        buyButton.addEventListener("click", onBuy);

        function onBuy()
        {
            ticketPreviewElement.style.display = "none";
            puchaseSuccess.style.display = "block";

        }

        let backButton = document.getElementById("back-btn");
        backButton.addEventListener("click", onBack);

        function onBack()
        {
            puchaseSuccess.style.display = "none";
            purchaseButton.disabled = true;
        }




      








    
 }