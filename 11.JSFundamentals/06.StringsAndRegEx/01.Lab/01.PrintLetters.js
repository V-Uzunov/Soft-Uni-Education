function printLetters(params) {
    for (let i = 0; i < params.length; i++) {
        console.log(`str[${i}] -> ${params[i]}`);
    }
}

printLetters('Hello, World!');