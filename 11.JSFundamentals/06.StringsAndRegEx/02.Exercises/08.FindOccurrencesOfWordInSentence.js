function finder(text, word) {
    
    let regex = new RegExp(`\\b${word}\\b`, 'gi');
    let matches = text.match(regex);
    
    if (matches !== null) {
        console.log(matches.length);
    }else{
        console.log(0);
    }
}

finder('The waterfall was so high, that the child couldn’t see its peak.', 'the');
finder('How do you plan on achieving that? How? How can you even think of that?', 'how');
finder('There was one. Therefore I bought it. I wouldn’t buy it otherwise.', 'there');