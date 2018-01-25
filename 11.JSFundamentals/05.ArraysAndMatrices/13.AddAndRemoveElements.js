function addAndRemove(array) {
    let result = [];

    for (let i = 0; i < array.length; i++) {
        if (array[i] === 'add') {
            result.push(i + 1);
        }
        if (array[i] === 'remove') {
            result.pop();
        }
    }
    if (result.length > 0) {
        console.log(result.join('\n'));
    } else {
        console.log('Empty');
    }
}

addAndRemove(['add', 'add', 'add', 'add']);