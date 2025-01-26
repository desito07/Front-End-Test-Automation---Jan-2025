async function multiplePromises() {
    const response = await Promise.allSettled([

      new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve('Eat pizza - promise kept');
        }, 1000);
      }),

      new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve('Eat chips - promise kept');
        }, 2000);

      }),

      new Promise((resolve, reject) => {
        setTimeout(() => {
            reject('Failed to eat vegetables - promise failed');
        }, 3000);
      }),
    ]);

    console.log(response);
}

multiplePromises();
