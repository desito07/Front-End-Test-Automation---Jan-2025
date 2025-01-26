class AsyncQueue {
    constructor(){
        this.tasks = [];
    }

    addTask(taskFunc)
    {
        this.tasks.push(taskFunc);
        this.processTasks();
    }

    async processTasks(){
        while (this.tasks.length > 0){
            const currentTaskFunc = this.tasks.shift();
            
            try 
            {
                const response = await currentTaskFunc();
                console.log('Success:', response);
            }
            catch(err)
            {
                console.error('Errorrrrr:', err);
            } 
        }
    }
}

function startQueue() {
    let queue = new AsyncQueue();

    queue.addTask(() => new Promise((resolve, reject) => setTimeout(() => resolve('Success 1'), 1000)));
    queue.addTask(() => new Promise((resolve, reject) => setTimeout(() => resolve('Success 2'), 2000)));
    queue.addTask(() => new Promise((resolve, reject) => setTimeout(() => reject('Failure 1'), 2000)));
}

startQueue();