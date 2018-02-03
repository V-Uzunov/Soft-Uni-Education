function townsToJSON(towns) {
    let townsArr = [];
    let sliceTowns = towns.slice(1);
    for (let town of sliceTowns) {
        let [empty, townName, lat, lng] = town.split(/\s*\|\s*/);
        let townObj = {
            Town: townName,
            Latitude: Number(lat),
            Longitude: Number(lng)
        };
        townsArr.push(townObj);
    }
    console.log(JSON.stringify(townsArr));
}

townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']);