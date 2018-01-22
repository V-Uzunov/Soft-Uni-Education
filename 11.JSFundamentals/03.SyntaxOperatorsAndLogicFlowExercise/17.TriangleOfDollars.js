function mult(nums) {

    for (let i = 1; i <= nums; i++) {
        console.log('$'.repeat(i));
        //console.log(new Array(i + 1).join('$'));
    }
}

mult(4);