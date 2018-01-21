function biggestNum(numbers) {
    let firstNum = Number(numbers[0]);
    let secondNum = Number(numbers[1]);
    let thirdNum = Number(numbers[2]);

    let biggestNumber = Math.max(firstNum, secondNum, thirdNum);
    console.log(biggestNumber);
    
}

biggestNum([5, -2, 7]);