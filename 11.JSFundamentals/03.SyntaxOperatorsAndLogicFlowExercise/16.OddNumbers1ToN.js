function oddNums(num) {
    let nums = 0;
    for (let i = 1; i <= num; i++) {
        if (i % 2 !== 0) {
            console.log(i);
        }
    }
}

oddNums(5);