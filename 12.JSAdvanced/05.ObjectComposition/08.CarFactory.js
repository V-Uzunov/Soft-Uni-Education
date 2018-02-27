function solve(car) {
    let [bestPower, bestVolume] = getEngine();
    let wheel = takeWheelSize();

    function getEngine() {
        let carPower = car.power;
        if (carPower <= 90) {
            return [90, 1800];
        } else if (carPower <= 120) {
            return [120, 2400];
        } else {
            return [200, 3500];
        }
    }

    function takeWheelSize() {
        let result = Math.abs(car.wheelsize);
        return result % 2 !== 0 ? result : result - 1;
    }

    let resultObj = {
        model: car.model,
        engine: {
            power: bestPower,
            volume: bestVolume
        },
        carriage: {
            type: car.carriage,
            color: car.color
        },
        wheels: [wheel, wheel, wheel, wheel]
    };

    return resultObj;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));