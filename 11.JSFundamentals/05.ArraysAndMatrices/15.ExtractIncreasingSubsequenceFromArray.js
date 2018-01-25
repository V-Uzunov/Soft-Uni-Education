function subsequence(array) {
    let biggestOne = Number.NEGATIVE_INFINITY;

    for (let i = 0; i < array.length; i++) {
        if (array[i] >= biggestOne) {
            biggestOne=array[i];
            console.log(biggestOne);
        }
    }
}

subsequence([20, 3, 2, 15, 6, 1]);