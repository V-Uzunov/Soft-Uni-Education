function cars(commands) {

    let commandProcessor = (function () {
        let objects = new Map();
        return {
            create: (objName, inherits, parent) => {
                if (inherits !== 'inherit') {
                    objects.set(objName, {});
                } else {
                    objects.set(objName, Object.create(objects.get(parent)));
                }
            },
            set: (objName, key, value) => objects.get(objName)[key] = value,
            print: (objName) => {
                let result = [];

                let objToPrint = objects.get(objName);
                for (let prop in objToPrint) {
                    let kvp = `${prop}:${objToPrint[prop]}`;
                    result.push(kvp);
                }
                console.log(result.join(', '));
            }
        };

    })();

    for (const cmdArgs of commands) {
        let [cmd, objName, value, value2] = cmdArgs.split(' ');
        commandProcessor[cmd](objName, value, value2);
    }
}

cars(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);