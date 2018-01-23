function validityChecker(input) {
    let x1 = Number(input[0]);
    let y1 = Number(input[1]);
    let x2 = Number(input[2]);
    let y2 = Number(input[3]);

    let distanceTo01 = Math.sqrt(Math.pow(x1, 2) + Math.pow(y1, 2));
    if (distanceTo01 === parseInt(distanceTo01)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }
    else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    let distanceTo02 = Math.sqrt(Math.pow(x2, 2) + Math.pow(y2, 2));
    if (distanceTo02 === parseInt(distanceTo02)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    }
    else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    let distanceBetweenPoints = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    if (distanceBetweenPoints === parseInt(distanceBetweenPoints)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    }
    else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}
validityChecker(['3','0','0','4']);