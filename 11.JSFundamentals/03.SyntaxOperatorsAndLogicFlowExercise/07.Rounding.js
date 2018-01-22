function round(input) {
    let number = Number(input[0]);
    let precision = Number(input[1]);

    if (precision > 15) {
        precision = 15;
    }

    let result = number.toFixed(precision);

    console.log(parseFloat(result));
}

round([3.1415926535897932384626433832795, 2]);
round([10.5, 3]);