function matchWords(input) {
    let text = input.match(/\w+/g);
    console.log(text.join('|'));
}

matchWords('_(Underscores) are also word characters');