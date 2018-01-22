function toUpperFunc(words) {
    console.log(words.toUpperCase()
                        .split(/\W+/)
                        .filter(w => w !=='')
                        .join(', '));
}

toUpperFunc('Hi, how are you?');
toUpperFunc('hello');
