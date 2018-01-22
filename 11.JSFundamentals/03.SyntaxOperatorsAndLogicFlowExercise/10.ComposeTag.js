function tag(params) {
    let location = params[0];
    let alternateText = params[1];

    console.log(`<img src="${location}" alt="${alternateText}">`);
    
}

tag(['smiley.gif', 'Smiley Face']);