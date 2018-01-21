function printSquare(squareSize) {
    let middleLine = Math.ceil(squareSize / 2);
 
    for (let i = 0; i < (middleLine * 2) - 1 ; i++) {
        if (i === 0 || i === (middleLine * 2) - 2 || i === middleLine - 1) {
            console.log('+' + Array(squareSize - 1).join("-") + '+' + Array(squareSize - 1).join("-") + '+');
        } else {
            console.log('|' + Array(squareSize - 1).join(" ") + '|' + Array(squareSize - 1).join(" ") + '|');
        }
    }
}

printSquare('3');