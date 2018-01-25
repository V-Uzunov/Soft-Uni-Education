function sortation(array) {
    console.log(array.sort()
        .sort((a, b) => a.length - b.length)
        .join('\n'));
}

sortation(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);






