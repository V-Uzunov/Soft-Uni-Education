function printSquare(num) {
    for (let i = 0; i < num; i++) {
        console.log('* '.repeat(num).trim());
    }
}

printSquare(5);