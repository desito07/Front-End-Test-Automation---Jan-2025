window.addEventListener("load", solve);

function solve() {
    let roomSizeInput = document.getElementById("room-size");
    let timeSlotInput = document.getElementById("time-slot");
    let fullNameInput = document.getElementById("full-name");
    let emailInput = document.getElementById("email");
    let phoneNumberInput = document.getElementById("phone-number");

    let bookRoomButton = document.getElementById("book-btn");
    //let previewContainerElement = document.getElementsByClassName("preview-container");
    let previewContainerElement = document.getElementById("preview");
    let confirmationElement = document.getElementById("confirmation");

    let roomSize = document.getElementById("preview-room-size");
    let timeSlot = document.getElementById("preview-time-slot");
    let fullName = document.getElementById("preview-full-name");
    let email = document.getElementById("preview-email");
    let phoneNumber = document.getElementById("preview-phone-number");

    /*bookRoomButton.addEventListener("click", printValies)
    function printValies()
    {
        console.log(roomSizeInput.value);
        console.log(timeSlotInput.value);
        console.log(fullNameInput.value);
        console.log(emailInput.value);
        console.log(phoneNumberInput.value);
    }*/

    bookRoomButton.addEventListener("click", previewBookedRooms)

    function previewBookedRooms()
    {
        
        if(roomSizeInput.value == "" || timeSlotInput.value == "" || fullNameInput.value == "" || emailInput.value == "" || phoneNumberInput.value == "")
        {
            return;
        }

        roomSize.textContent = roomSizeInput.value;
        timeSlot.textContent = timeSlotInput.value;
        fullName.textContent = fullNameInput.value;
        email.textContent = emailInput.value;
        phoneNumber.textContent = phoneNumberInput.value;

        previewContainerElement.style.display = "block";
        bookRoomButton.disabled = true;

        roomSizeInput.value = "";
        timeSlotInput.value = "";
        fullNameInput.value = "";
        emailInput.value = "";
        phoneNumberInput.value = "";
    }

    let editButton = document.getElementById("edit-btn");
        editButton.addEventListener("click", onEdit);

    function onEdit()
    {
            
        roomSizeInput.value = roomSize.textContent;
        timeSlotInput.value = timeSlot.textContent;
        fullNameInput.value = fullName.textContent; 
        emailInput.value = email.textContent;
        phoneNumberInput.value = phoneNumber.textContent;

        previewContainerElement.style.display = "none";
        bookRoomButton.disabled = false;
    }

    let confirmBookingButton = document.getElementById("confirm-btn");
    confirmBookingButton.addEventListener("click", onConfirm)
    
    function onConfirm()
    {
        previewContainerElement.style.display = "none";
        confirmationElement.style.display = "block";
    }

    let bookAnotherRoomButton = document.getElementById("back-btn");
    bookAnotherRoomButton.addEventListener("click", onBookAnother)

    function onBookAnother()
    {
        confirmationElement.style.display = "none";
        bookRoomButton.disabled = false;
    }
          
}
  