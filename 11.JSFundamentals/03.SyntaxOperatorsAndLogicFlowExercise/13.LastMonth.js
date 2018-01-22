function lastMonth(params) {
    let day = Number(params[0]);
    let month = Number(params[1]);
    let year = Number(params[2]);

    let result = new Date(year, month-1, 0);

    console.log(result.getDate());
}

lastMonth([17, 3, 2002]);
lastMonth([13, 12, 2004]);