let result = (function () {
    let validFace = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let Suits = {
        CLUBS: '\u2663',
        DIAMONDS: '\u2666',
        HEARTS: '\u2665',
        SPADES: '\u2660'
    };
    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }
        get face(){
            return this._face;
        }
        set face(value){
            if (!validFace.includes(value)) {
                throw new Error('Invalid card face ' + value);
            }
            this._face = value;
        }
        get suit() {
            return this._suit;
        }
        set suit(value) {
            if(!Object.keys(Suits).map(k => Suits[k]).includes(value)){
                throw new Error('Suit does not exist!');
            }
            this._suit = value;
        }

        toString(){
            return this.face + this.suit;
        }
    }

    return { Card, Suits };
})();
let Card = result.Card;
let Suits = result.Suits;

let card = new Card('2', Suits.CLUBS);
console.log(card.toString());


