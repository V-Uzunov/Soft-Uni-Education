function negativePosition(arr) {
    let result = [];

    for (let i = 0; i < arr.length; i++) {
        let num = Number(arr[i]);

        if (num >= 0) {
            result.push(num);
        }else{
            result.unshift(num);
        }
    }
    console.log(result.join('\n'));
}

negativePosition([7, -2, 8, 9]);