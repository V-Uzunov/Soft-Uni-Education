function stringOfNums(nums) {
    var res = "";
    for (let i = 1; i <= nums; i++) {
        res += i;
    }

    return res;
}

console.log(stringOfNums('11'));