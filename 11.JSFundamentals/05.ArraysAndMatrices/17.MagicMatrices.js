function magicMatrix(matrix) {

    function isMagic(matrix) {
        let sum = [];
        let sumCol = 0;
        let sumRow = 0;
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                sumRow += Number(matrix[row][col]);
                sumCol += Number(matrix[col][row]);
            }
            sum.push(sumRow);
            sum.push(sumCol);
            sumCol = 0;
            sumRow = 0;
            for (let i = 0; i < sum.length - 1; i++) {
                if (sum[i] !== sum[i + 1]) {
                    return false;
                }
            }
        }
        return true;
    }
    console.log(isMagic(matrix));
}

magicMatrix([[11, 32, 45],
                [21, 0, 1],
                [21, 1, 1]]);
