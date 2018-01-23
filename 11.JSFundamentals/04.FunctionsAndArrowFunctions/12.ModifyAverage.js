function average(number) {
    let numToString = String(number);

    let getAverage = (numStr) => numToString.split('').map(Number).reduce((a, b) => a += b) / numToString.length;

    while (getAverage(numToString) <= 5) {
        numToString+='9';
    }

    console.log(numToString);
}

average(101);
average(5835);