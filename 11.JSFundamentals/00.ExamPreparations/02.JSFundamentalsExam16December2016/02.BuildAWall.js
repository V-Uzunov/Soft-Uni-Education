function wallBuilder(array) {
    let nums = array.map(Number);
    let result = [];
    let isTrue = false;
    while (!isTrue) {
        let total = 0;
        isTrue = true;
        for (let i = 0; i < nums.length; i++) {
            if (nums[i] < 30) {
                nums[i] += 1;
                total += 195;
                isTrue = false;
            }
        }
        if (!isTrue) {
            result.push(total);
        }
    }
    console.log(result.join(', '));
    console.log(result.reduce((a, b)=> a + b) * 1900 + ' pesos');
}

wallBuilder(['21', '25', '28']);