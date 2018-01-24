function evenPosition(elements) {
    console.log(elements.filter((a, index) => index % 2 === 0).join(' '));
}

evenPosition(['20', '30', '40']);
evenPosition(['5', '10']);