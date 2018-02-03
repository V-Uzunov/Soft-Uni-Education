function storeCataloge(data) {
    let catalogue = new Map();


    for (let line of data) {
        let [product, price] = line.split(/\s:\s/);
        let productFirstLetter = product[0].toUpperCase();
        if (!catalogue.has(productFirstLetter)) {
            catalogue.set(productFirstLetter, []);
        }

        catalogue.get(productFirstLetter).push({title: product, value: price});
    }

    function customComparator(productA, productB) {
        return productA.title.toLowerCase().localeCompare(productB.title.toLowerCase());
    }
    let sortedCategories = [...catalogue.keys()].sort();
    for (let category of sortedCategories) {
        console.log(category);
        let products = catalogue.get(category).sort(customComparator);
        products.forEach(p => console.log(`  ${p.title}: ${p.value}`));
    }
}

storeCataloge(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);