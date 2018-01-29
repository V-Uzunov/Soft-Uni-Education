function aggregateTable(array) {
    let towns = [];
    let sum = 0;

    for (let i = 0; i < array.length; i++) {
        let tokens = array[i].split('|').filter(a => a !== '');
        towns.push(tokens[0].trim());
        sum += Number(tokens[1].trim());
    }

    console.log(towns.join(', '));
    console.log(sum);
}

aggregateTable(['| Sofia           | 300',
                '| Veliko Tarnovo  | 500',
                '| Yambol          | 275']);