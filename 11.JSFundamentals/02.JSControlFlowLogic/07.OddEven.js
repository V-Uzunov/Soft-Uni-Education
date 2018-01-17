function oddEven(num) {
    if (num % 2 == 0) {
        console.log('even');
    }else if (Math.abs(num % 2) === 1) {
        console.log('odd');
    }else{
        console.log('invalid');
    }
}

oddEven(1.5);