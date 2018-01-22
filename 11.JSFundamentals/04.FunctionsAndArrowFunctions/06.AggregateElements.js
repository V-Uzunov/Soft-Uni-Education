function aggregate(array) {
    aggregateFunc(0, (a, b) => a + b);
    aggregateFunc(0, (a, b) => a + 1 / b);
    aggregateFunc('', (a, b) => a + b);

    function aggregateFunc(initValue, arrowFunc) {
        for (let index = 0; index < array.length; index++) {
            initValue = arrowFunc(initValue, array[index]);
        }
        console.log(initValue);
    }
}

aggregate([1, 2, 3]);