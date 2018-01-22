function printTriangle(num) {

    for (let i = 1; i <= num; i++) {
        console.log('*'.repeat(i));
    }
    for (let i = num - 1; i > 0; i--) {
        console.log('*'.repeat(i));
    }
}

printTriangle(5);
