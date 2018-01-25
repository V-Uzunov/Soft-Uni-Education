function printArrayWithDelimiter(array) {
    let result = [];
    let dilimiter = array[array.length - 1];
    array.pop();
    
    for (let i = 0; i < array.length; i++) {
        result[i] = array[i];
    }

    console.log(result.join(dilimiter));
}

printArrayWithDelimiter(['One', 'Two', 'Three', 'Four', 'Five', '-']);