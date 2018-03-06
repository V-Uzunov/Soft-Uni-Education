class Stringer{
    constructor(innerString , innerLength){
        this.innerString  = innerString ;
        this.innerLength = Number(innerLength);
    }
    get innerLength() {
        return this._innerLength;
    }
    set innerLength(value) {
        if (value < 0) {
            this._innerLength = 0;
        }else {
            this._innerLength = value;
        }
    }
    increase(num){
        this.innerLength += num;
    }
    decrease(num){
        this.innerLength -= num;
    }
    toString(){
        if(this.innerString.length > this.innerLength){
            return this.innerString.substring(0, this.innerLength) + '...';
        }

        return this.innerString;
    }
}

let test = new Stringer('Test', 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...

test.increase(4);
console.log(test.toString()); //Test
