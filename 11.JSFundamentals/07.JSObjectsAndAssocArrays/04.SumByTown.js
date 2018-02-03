function sumByTown(array) {
    let result = {};
    for (let i = 0; i < array.length; i+=2) {
        if (result.hasOwnProperty(array[i])) {
            result[array[i]] += Number(array[i + 1]);
        }else{
            result[array[i]] = Number(array[i + 1]);
        }
    }
    console.log(JSON.stringify(result));
}

sumByTown(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4']);