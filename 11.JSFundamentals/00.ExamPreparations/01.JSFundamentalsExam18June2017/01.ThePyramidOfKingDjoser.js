function solve(base, increment) {
    let stone = 0;
    let marble = 0;
    let lapis = 0;
    let gold = 0;
    let step = 1;

    while (base > 2) {
        let bulk = (base - 2) ** 2;
        let decoration = (base * 4) - 4;
        stone += bulk * increment;
        if (step % 5 === 0) {
            lapis += decoration * increment;
        } else {
            marble += decoration * increment;
        }
        step++;
        base -= 2;
    }
    gold = (base ** 2) * increment;

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapis)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(step * increment)}`);
}

solve(11, 1);