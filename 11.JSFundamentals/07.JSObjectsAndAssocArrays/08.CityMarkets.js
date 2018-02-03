function market(text) {
    let result = new Map();
    for (const data of text) {
        let [town, product, value] = data.split(/\s*->\s*/);
        let valueMultyply = value.split(/\s*:\s*/).map(s => Number(s)).reduce((a, b) => a * b);
        if (result.has(town)) {
            if (result.get(town).has(product)) {
                result.get(town).set(product, result.get(product) + valueMultyply);
            } else {
                result.get(town).set(product, valueMultyply);
            }
        } else {
            let itemsMap = new Map();
            itemsMap.set(product, valueMultyply);
            result.set(town, itemsMap);
        }
    }
    for (const [key, value] of result) {
        console.log(`Town - ${key}`);
        for (const [item, sum] of result.get(key)) {
            console.log(`$$$${item} : ${sum}`);
        }
    }
}

market(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3']);