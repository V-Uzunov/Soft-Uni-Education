function censorship(text, array) {
    for (const str of array) {
        let regex = new RegExp(str, 'g');
        let dashes = '-'.repeat(str.length);
        text = text.replace(regex, dashes);
    }
    console.log(text);
}

censorship('roses are red, violets are blue', [', violets are', 'red']);