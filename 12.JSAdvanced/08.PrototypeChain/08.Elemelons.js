let result = function solve() {
    class Melon{
        constructor(weight, melonSort){
            if (new.target === Melon) {
                throw new Error('Cannot instance abstract class Melon');
            }
            this.weight = Number(weight);
            this.melonSort = melonSort;
            this._elementIndex = this.weight * this.melonSort.length;
            this.elementName = '';
        }

        get elementIndex(){
            return this._elementIndex;
        }

        toString(){
            return `Element: ${this.elementName}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }
    class Watermelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.elementName = 'Water';
        }
    }
    class Firemelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.elementName = 'Fire';            
        }
    }
    class Earthmelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.elementName = 'Earth';            
        }
    }
    class Airmelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.elementName = 'Air';
        }
    }
    class Melolemonmelon extends Watermelon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.elementName = 'Water';
            this.elements = ['Fire', 'Earth', 'Air', 'Water'];
            this.elIndex = 0;
        }

        morph(){
            this.elementName = this.elements[this.elIndex++ % 4];
        }
    }

    return {
        Melon,
        Watermelon,
        Firemelon,
        Earthmelon,
        Airmelon,
        Melolemonmelon
    };
};
let Melon = result.Melon;
let Watermelon = result.Watermelon;
let Melolemonmelon = result.Melolemonmelon;

//let test = new Melon(100, 'Test');
//Throws error

let watermelon = new Watermelon(12.5, 'Kingsize');
console.log(watermelon.toString());

// Element: Water
// Sort: Kingsize
// Element Index: 100

let morphMelon = new Melolemonmelon(15, 'Shit');
console.log(morphMelon.toString());
morphMelon.morph();
console.log(morphMelon.toString());
