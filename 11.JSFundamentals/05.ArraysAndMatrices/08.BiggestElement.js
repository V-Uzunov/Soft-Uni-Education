function biggestElement(matrix) {
    let maxNum = Number.NEGATIVE_INFINITY;
    
    for (let row = 0; row < matrix.length; row++) {
       for (let col = 0; col < matrix[row].length; col++) {
           if (maxNum < matrix[row][col]) {
               maxNum = matrix[row][col];
           }
       }
    }
    console.log(maxNum);

    // console.log(matrix.map(a => a.sort((a, b) => a<b)[0])
    //                              .sort((a, b) => a<b)[0]);
    
}

biggestElement([[20, 50, 10],
                [8, 33, 145]]);