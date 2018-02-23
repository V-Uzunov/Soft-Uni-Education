let manager = (function () {
    let ingredientStock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    let recipes = {
        'apple': { carbohydrate: 1, flavour: 2 },
        'coke': { carbohydrate: 10, flavour: 20 },
        'burger': { carbohydrate: 5, fat: 7, flavour: 3 },
        'omelet': { protein: 5, fat: 1, flavour: 1 },
        'cheverme': { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
    };

    function restock(ingredient, quantity) {
        ingredientStock[ingredient] += Number(quantity);
        return 'Success';
    }

    function prepare(recipe, quantity) {
        let meal = recipes[recipe];

        for (let key of Object.keys(meal)) {
            if (ingredientStock[key] < meal[key] * Number(quantity)) {
                return `Error: not enough ${key} in stock`;
            }
        }
        Object.keys(meal).forEach(key => ingredientStock[key] -= meal[key] * Number(quantity));
        return 'Success';
    }

    function report() {
        return `protein=${ingredientStock.protein} carbohydrate=${ingredientStock.carbohydrate} fat=${ingredientStock.fat} flavour=${ingredientStock.flavour}`;
    }

    return function commandParser(input) {
        let [cmd, element, value] = input.split(' ');
        switch (cmd) {
            case 'prepare':
                return prepare(element, Number(value));
            case 'restock':
                return restock(element, Number(value));
            case 'report':
                return report();
        }
    };
})();


console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));