function lockedProfile() {
   let buttons = document.getElementsByTagName("button");

   for (const button of buttons) {
    button.addEventListener('click', showInfo)
   }

   function showInfo(event)
   {
    let lockRadioButton = event.target.parentNode.children[2];

    let hiddenDivElement = event.target.previousElementSibling;

    //console.log(lockRadioButton.checked);

    if(lockRadioButton.checked == false)
    {
        if(event.target.textContent == "Hide it")
        {
            hiddenDivElement.style.dispaly = "none";
            event.target.textContent = "Show more";
        }
        else
        {
            hiddenDivElement.style.display = "block";
            event.target.textContent = "Hide it";
        }
    }
   }
}