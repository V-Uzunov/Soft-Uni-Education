function company(array) {
    let result = new Map();

    for (const items of array) {
        let [brand, model, quantity] = items.split(' | ');

        if (!result.has(brand)) {
            result.set(brand, new Map());
        }
        if (!result.get(brand).has(model)) {
            result.get(brand).set(model, 0);
        }
        result.get(brand).set(model, result.get(brand).get(model) + Number(quantity));
    }
    for (let [carBrand,carModel] of result) {
        console.log(carBrand);
        for (let [model,quantity] of carModel) {
            console.log(`###${model} -> ${quantity}`);
        }
    }
}

company(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);