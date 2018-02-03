function populationInTowns(text) {
    let total = new Map();
    for (let dataRow of text) {
        let [town, population] = dataRow.split(/\s*<->\s*/);

        if (total.has(town)) {
            total.set(town, total.get(town) + Number(population));
        }
        else {
            total.set(town, Number(population));
        }
    }
    for (let [town, sum] of total) {
        console.log(town + ' : ' + sum);
    }
}

populationInTowns(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);