function rotateArray(array) {
    let rotationAmount = Number(array[array.length - 1]);
    array.pop();
    
    for (let i = 0; i < rotationAmount % array.length; i++) {
        array.unshift(array.pop());    
    }

    console.log(array.join(' '));
}

rotateArray(['Banana', 'Orange', 'Coconut', 'Apple', '15']);