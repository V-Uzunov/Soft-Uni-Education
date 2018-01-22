function imperialUnits(num) {
    let units = Number(num);

    let feet = Math.floor(units / 12);
    let inches = units % 12;

    console.log(`${feet}'-${inches}"`);
    
}

imperialUnits(36);
imperialUnits(55);
imperialUnits(11);