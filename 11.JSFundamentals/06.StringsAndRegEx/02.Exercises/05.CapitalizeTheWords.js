function capitalizer(text) {
    let result = [];
    text = text.toLowerCase().split(' ');
    
    for (const words of text) {
       result.push(words.charAt(0).toUpperCase() + words.substring(1));
    }

    console.log(result.join(' '));
}

capitalizer('Capitalize these words');
capitalizer('Was that Easy? tRY thIs onE for SiZe!');