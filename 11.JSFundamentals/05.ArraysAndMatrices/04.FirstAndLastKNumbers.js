function sequence(params) {
    let n = params.shift();
    console.log(params.slice(0, n).join(' '));
    console.log(params.slice(params.length - n, params.length).join(' '));
}

sequence([3, 6, 7, 8, 9]);