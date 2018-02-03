function cappyJuice(array) {
    let totalJuice = new Map();
    let totalBottles = new Map();

    for (let i = 0; i < array.length; i++) {

        let current = array[i].split('=>');

        let fruit = current[0];
        let quantity = Number(current[1]);

        if (!totalJuice.has(fruit)) {
            totalJuice.set(fruit, 0);
        }
        let cuurentQuantity = totalJuice.get(fruit);
        cuurentQuantity += quantity;

        if (cuurentQuantity >= 1000) {
            let juiceLeft = cuurentQuantity % 1000;

            let bottlesToStore = (cuurentQuantity - juiceLeft) / 1000;

            if (!totalBottles.has(fruit)) {
                totalBottles.set(fruit, 0);
            }
            totalBottles.set(fruit, totalBottles.get(fruit) + bottlesToStore);
            quantity = juiceLeft;
        }
        totalJuice.set(fruit, totalJuice.get(fruit) + quantity);

    }
    for (let [juicee,bottles]of totalBottles) {
        console.log(juicee + '=> ' + bottles);
    }
}

cappyJuice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
    ]);