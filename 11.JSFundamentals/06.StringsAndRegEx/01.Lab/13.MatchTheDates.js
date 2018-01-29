function matchDates(array) {
    let regex = /\b([0-9]{1,2})-([A-Z][a-z]{2})-([0-9]{4})\b/g;
    let result = regex.exec(array);
    while (result) {
        console.log(`${result[0]} (Day: ${result[1]}, Month: ${result[2]}, Year: ${result[3]})`);
        result = regex.exec(array);
    }
}

matchDates('I am born on 30-Dec-1994.',
    'This is not date: 512-Jan-1996.',
    'My father is born on the 29-Jul-1955.'
);