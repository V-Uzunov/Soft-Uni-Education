function airport(recordOfPlanes) {

    let planesLanded = new Map();
    let townAndPassengers = new Map();
    let planeAndCity = new Map();

    for (let currentPlane of recordOfPlanes) {
        let [plane, town, passengers, condition] = currentPlane.split(' ');

        if (!planesLanded.has(plane) && condition !== 'depart') {
            planesLanded.set(plane, condition);
        } else {
            if ((planesLanded.get(plane) === 'land' && condition === 'depart') ||
                (planesLanded.get(plane) === 'depart' && condition === 'land')) {
                planesLanded.set(plane, condition);
            } else {
                continue;
            }
        }

        if (!townAndPassengers.has(town)) {
            if (planesLanded.get(plane) === 'land') {
                townAndPassengers.set(town, {arrivals: Number(passengers), departures: 0});
            } else if (planesLanded.get(plane) === 'depart') {
                townAndPassengers.set(town, {arrivals: 0, departures: Number(passengers)});
            }

        } else {
            if (planesLanded.get(plane) === 'land') {
                let arrivalsOldValue = townAndPassengers.get(town).arrivals;
                let departureOldValue = townAndPassengers.get(town).departures;

                townAndPassengers.set(town, {
                    arrivals: Number(passengers) + arrivalsOldValue,
                    departures: departureOldValue
                })
            } else if (planesLanded.get(plane) === 'depart') {
                let arrivalsOldValue = townAndPassengers.get(town).arrivals;
                let departureOldValue = townAndPassengers.get(town).departures;

                townAndPassengers.set(town, {
                    arrivals: arrivalsOldValue,
                    departures: departureOldValue + Number(passengers)
                })
            }
        }

        if (!planeAndCity.has(plane)) {
            planeAndCity.set(plane, new Set());
        }
        planeAndCity.get(plane).add(town);
    }

    console.log('Planes left:');
    for (let [plane, condition] of [...planesLanded].sort((p1, p2) => p1[0].localeCompare(p2[0]))) {
        if (condition === 'land') {
            console.log(`- ${plane}`);
        }
    }
    for (let [town, passengers] of [...townAndPassengers].sort(function (a, b) {
        if (b[1].arrivals > a[1].arrivals) return 1;
        if (b[1].arrivals < a[1].arrivals) return -1;
        return a[0].localeCompare(b[0]);
    })) {
        console.log(town);
        console.log(`Arrivals: ${passengers.arrivals}`);
        console.log(`Departures: ${passengers.departures}`);
        console.log('Planes:');
        for (let [plane, city] of [...planeAndCity].sort(function (a, b) {
            return a[0].toLowerCase().localeCompare(b[0].toLowerCase());
        })) {
            if (city.has(town)) {
                console.log(`-- ${plane}`);
            }
        }
    }
}

airport(['Boeing474 Madrid 300 land',
    'AirForceOne WashingtonDC 178 land',
    'Airbus London 265 depart',
    'ATR72 WashingtonDC 272 land',
    'ATR72 Madrid 135 depart']);