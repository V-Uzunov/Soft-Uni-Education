function decriptor(keyword, text) {
    let pattern = /(north|east)\D*(\d{2})[^,]*(,)\D*(\d{6})/gi;
    let messagePattern = new RegExp(`(${keyword})(.*?)(${keyword})`, 'g');
    let message = messagePattern.exec(text)[2];

    let latitude = '';
    let longtitude = '';
    let match = pattern.exec(text);
    while (match) {
        if (match[1].toLowerCase() === 'north') {
            latitude = `${match[2]}.${match[4]} N`;
        } else {
            longtitude = `${match[2]}.${match[4]} E`;
        }
        match = pattern.exec(text);
    }
    console.log(latitude);
    console.log(longtitude);
    console.log(`Message: ${message}`);
}

decriptor('<>', 'o u%&lu43t&^ftgv><nortH4276hrv756dcc,  jytbu64574655k <>ThE sanDwich is iN the refrIGErator<>yl i75evEAsTer23,lfwe 987324tlblu6b');