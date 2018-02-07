function janNotations(array) {
    let stack = [];
    let instructionSet = {
        '+': (a, b) => a + b,
        '-': (a, b) => a - b,
        '*': (a, b) => a * b,
        '/': (a, b) => a / b,
    };

    for (let i of array) {
        let instruction = instructionSet[i];
        if (instruction === undefined) {
            stack.push(i);
        } else {
            let [reg2, reg1] = [stack.pop(), stack.pop()];
            if (reg1 === undefined || reg2 === undefined) {
                console.log('Error: not enough operands!');
                return;
            }
            stack.push(instruction(reg1, reg2));
        }
    }

    if (stack.length > 1) {
        console.log('Error: too many operands!');
    } else {
        console.log(stack.pop());
    }
}

janNotations([3, 4, '+']);