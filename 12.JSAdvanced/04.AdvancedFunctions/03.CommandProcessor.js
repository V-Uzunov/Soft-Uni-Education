function commandProcessor(commands) {
    let processor = (function () {
        let text = '';

        return function (command) {
            let [cmd, args] = command.split(' ');
            switch (cmd) {
                case 'append':
                    text += args;
                    break;
                case 'removeStart':
                    text = text.slice(args);
                    break;
                case 'removeEnd':
                    text = text.slice(0, text.length - args);
                    break;
                case 'print':
                    console.log(text);
                    break;
            }
        };
    })();
    for (let command of commands) {
        processor(command);
    }
}

commandProcessor(['append hello',
    'append again',
    'removeStart 3',
    'removeEnd 4',
    'print']);