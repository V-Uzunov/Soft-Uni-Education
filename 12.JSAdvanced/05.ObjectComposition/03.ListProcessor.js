function listProcessor(commands) {

    let cmdProcessor = (function () {
        let text = [];
        return {
            add: (word) => text.push(word),
            remove: (word) => text = text.filter(w => w !== word),
            print: ()=> console.log(text)
        };
    })();

    for (const cmdArgs of commands) {
        let [cmdName, word] = cmdArgs.split(' ');
        cmdProcessor[cmdName](word);
    }
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);