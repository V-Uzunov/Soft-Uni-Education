function calc(a, b, op) {
    let add = (x, z) => x + z;
    let subtract = (x, z) => x - z;
    let multiply = (x, z) => x * z;
    let divide = (x, z) => x / z;
    switch (op) {
        case '+': console.log(add(a, b));
            break;
        case '-': console.log(subtract(a, b));
            break;
        case '*': console.log(multiply(a, b));
            break;
        case '/': console.log(divide(a, b));
            break;
    }
}

calc(2, 4, '+');
calc(3, 3, '/');
calc(18, -1, '*');