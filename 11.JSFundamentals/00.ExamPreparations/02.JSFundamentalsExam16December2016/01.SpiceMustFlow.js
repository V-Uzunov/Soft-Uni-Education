function extractSpice(startYeld) {
    let yeld = startYeld.map(Number);
    let days = 0;
    let amount = 0;

    while (yeld >= 100) {
        amount += yeld - 26;
        yeld -= 10;
        days++;
    }

    if (amount >= 26) {
        amount -= 26;
    }
    console.log(days);
    console.log(amount);
}

extractSpice(['99']);