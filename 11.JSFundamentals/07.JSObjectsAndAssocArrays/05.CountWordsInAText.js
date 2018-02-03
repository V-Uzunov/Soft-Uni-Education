function countWordsInText(text) {
    let result = {};
    let array = text.join('').split(/\W+/).filter(a => a !== '');
    for (let i = 0; i < array.length; i++) {
    const element = array[i];
        if (result.hasOwnProperty(element)) {
            result[element] +=1;
        }else{
            result[element] = 1;
        }
    }
    console.log(JSON.stringify(result));
}

countWordsInText(['Far too slow, you\'re far too slow.']);