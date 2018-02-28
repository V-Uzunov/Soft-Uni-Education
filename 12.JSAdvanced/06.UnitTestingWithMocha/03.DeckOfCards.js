function printDeckOfCards(cards) {
    let result = [];
    for (const key of cards) {
        let face = key.substring(0, key.length - 1);
        let suite = key.substr(key.length - 1, 1);
        try {
            result.push(playingCards(face, suite));
        } catch (error) {
            console.log(`Invalid card: ${key}`);
            return;
        }

    }
    console.log(result.join(' '));
    function playingCards(face, suite) {
        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let validSuites = ['S', 'H', 'D', 'C'];
        if (!validFaces.includes(face)) {
            throw new Error('Error');
        }
        if (!validSuites.includes(suite)) {
            throw new Error('Error');
        }

        let resultCard = {
            face: face,
            suite: suite,
            toString: () => {
                let suitToChar = {
                    'S': '\u2660', // ♠
                    'H': '\u2665', // ♥
                    'D': '\u2666', // ♦
                    'C': '\u2663', // ♣
                };
                return face + suitToChar[suite];
            }
        };
        return resultCard;
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);