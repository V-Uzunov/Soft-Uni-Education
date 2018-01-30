function variableNames(text) {
    let result = [];
    let pattern = /\b_([A-Za-z0-9]+)\b/g;
    let matches = pattern.exec(text);

    while(matches){
        result.push(matches[1]);
        matches = pattern.exec(text);
    }
    
    console.log(result.join(','));
}

variableNames('The _id and _age variables are both integers.');