function proccesOddNums(params) {
    console.log(params.filter((a, index) => index % 2 !== 0).map(a => a * 2).reverse().join(' '));
}

proccesOddNums([3, 0, 10, 4, 7, 3]);