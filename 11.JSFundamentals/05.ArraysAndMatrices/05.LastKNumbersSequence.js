function lastKseq(n, k) {
    let arr = [1];

    for (let i = 1; i < n; i++) {
        arr[i] = arr.slice(Math.max(0, arr.length - k)).reduce((a, b) =>  a + b);
    }
    console.log(arr.join(' '));
}

lastKseq(6, 3);