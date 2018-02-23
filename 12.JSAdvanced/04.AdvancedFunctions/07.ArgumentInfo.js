function argumentsInfo() {
    let typeCounter = new Map();

    for (const args of arguments) {
        let obj = args;
        let type = typeof obj;
        if (!typeCounter.has(type)) {
            typeCounter.set(type, 1);
        } else {
            typeCounter.set(type, typeCounter.get(type) + 1);
        }
        console.log(`${type}: ${obj}`);
    }

    for (const [type, count] of [...typeCounter].sort((a, b) => b[1] - a[1])) {
        console.log(`${type} = ${count}`);
    }
}

argumentsInfo('dog', 'cat', 42, function () { console.log('Hello world!'); });