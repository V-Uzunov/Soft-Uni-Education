function tripLength(numbers) {
    let x1 = Number(numbers[0]);
    let y1 = Number(numbers[1]);
    let x2 = Number(numbers[2]);
    let y2 = Number(numbers[3]);
    let x3 = Number(numbers[4]);
    let y3 = Number(numbers[5]);

    let AB = Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
    let BC = Math.sqrt(Math.pow(x2 - x3, 2) + Math.pow(y2 - y3, 2));
    let AC = Math.sqrt(Math.pow(x1 - x3, 2) + Math.pow(y1 - y3, 2));

    if (AB + BC <= BC + AC) {
        console.log('1->2->3: ' + Number(AB + BC));
    }
    else if (AB + AC < BC + AC) {
        console.log('2->1->3: ' + Number(AB + AC));
    }
    else {
        console.log('1->3->2: ' + Number(BC + AC));
    }
}

tripLength([0, 0, 2, 0, 4, 0]);