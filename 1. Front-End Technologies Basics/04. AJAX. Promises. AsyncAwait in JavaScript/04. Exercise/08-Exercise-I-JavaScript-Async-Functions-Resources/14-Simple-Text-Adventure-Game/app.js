async function askQuestion(question){
    return new Promise((resolve, reject) => {
        const answer = prompt(question);
        resolve(answer);
    })
}

async function startAdventure(){
    console.log("Welcome to the simple text adventure game!");

    let currentScene = "start";

    while(true){
        switch(currentScene){
            case "start": 
                console.log("You find yourself in a dark forest. You can go 'left' or 'right'.");
                const startChoice = await askQuestion("What do you do? (left/right): ");

                if(startChoice.toLowerCase() === "left")
                {
                    currentScene = "leftPath";
                }
                else if(startChoice.toLowerCase() === "right")
                {
                    currentScene = "rightPath";
                }
                else
                {
                    console.log("Invalid choice. Try again");
                }
                break;

            case "leftPath": 
                console.log("You encounter a wild animal! You can 'fight' or 'run'.");
                const leftChoice = await askQuestion("What do you do? (fight/run): ");

                if(leftChoice.toLowerCase() === "fight")
                {
                    console.log("You bravely fight the animal and win!");
                    currentScene = "end";
                }
                else if(leftChoice.toLowerCase() === "run")
                {
                    console.log("You run away safely.");
                    currentScene = "start";
                }
                else
                {
                    console.log("Invalid choice. Try again");
                }
                break;

                case "rightPath": 
                console.log("You find a treasure chest! You can 'open' it or 'leave' it.");
                const rightChoice = await askQuestion("What do you do? (open/leave): ");

                if(rightChoice.toLowerCase() === "open")
                {
                    console.log("You open the chest and find a treasure! You win!");
                    currentScene = "end";
                }
                else if(rightChoice.toLowerCase() === "leave")
                {
                    console.log("You leave the chest and go back to the start.");
                    currentScene = "start";
                }
                else
                {
                    console.log("Invalid choice. Try again");
                }
                break;

            case "end":
                const playAgain = await askQuestion("Do you want to play again? (yes/no): ");

                if(playAgain.toLowerCase() === "yes"){
                    console.log("start game again");
                    currentScene = "start";
                }
                else
                {
                    console.log("Thank you for playing!")
                    return;
                }
                break;

            default:
                console.log("Something went wrong. Starting again");
                currentScene = "start";
                break;
        }
    }
}