function countWords(text) {
    let myMap = new Map();
    let array = text.join('').toLowerCase().split(/\W+/).filter(a => a !== '');
    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        if (myMap.has(element)) {
            myMap.set(element, myMap.get(element) + 1);
        }else{
            myMap.set(element, 1);
        }
    }
    let sortedMap =Array.from(myMap.keys()).sort();
    for (const key of sortedMap) {
        console.log(`'${key}' -> ${myMap.get(key)} times`);
    }
}

countWords(['Far too slow, you\'re far too slow.']);