function roadRadar(params) {
    let speed = Number(params[0]);
    let area = params[1];

    isInSpeedLimit(speed, area);

    function isInSpeedLimit(speed, area) {
        let speedLimits = { 'motorway': 130, 'interstate': 90, 'city': 50, 'residential': 20 };

        if (speed <= speedLimits[area]) {

        } else {
            if (speed - speedLimits[area] <= 20) {
                console.log('speeding')
            } else if (speed - speedLimits[area] <= 40) {
                console.log('excessive speeding');
            } else {
                console.log('reckless driving');
            }
        }
    }

}
//roadRadar([40, 'city']);
//roadRadar([21, 'residential']);
roadRadar([120, 'interstate']);
//roadRadar([200, 'motorway']);
