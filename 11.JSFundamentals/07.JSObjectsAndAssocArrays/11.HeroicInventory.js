function heroInventory(array) {
    let result = [];
    for (const elements of array) {
        let args = elements.split(' / ');
        let heroName = args[0];
        let heroLevel = Number(args[1]);
        let heroItems = [];
        if (args.length > 2) {
            heroItems = args[2].split(', ');
        }
        let heroData = {
            name:heroName,
            level: Number(heroLevel),
            items: heroItems
        };
        result.push(heroData);
    }
    console.log(JSON.stringify(result));
}

heroInventory(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']);