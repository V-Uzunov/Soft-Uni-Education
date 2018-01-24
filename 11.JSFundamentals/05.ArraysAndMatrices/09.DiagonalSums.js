function diagonalSum(matrix) {
    let upperDiagonalSum = 0;
    let downDiagonalSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        upperDiagonalSum += matrix[row][row];
        downDiagonalSum += matrix[row][matrix.length - row - 1];
    }
    console.log(upperDiagonalSum + ' ' + downDiagonalSum);
}

diagonalSum([[20, 40],
             [10, 60]]);