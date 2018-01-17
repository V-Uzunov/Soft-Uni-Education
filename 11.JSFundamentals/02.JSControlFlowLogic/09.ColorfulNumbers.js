function colorfulyNums(num) {
    let result = '<ul>\n';

    for (let i = 1; i <= num; i++) {
        let color = i % 2 === 0 ? 'blue' : 'green';
        result += ` <li><span style='color:${color}'>${i}</span></li>\n`
    }
    result += '</ul>'
    document.getElementById('myId').innerHTML = result;
    return result;
}


console.log(colorfulyNums(10));
