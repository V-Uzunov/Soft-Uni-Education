(function solve() {

    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        let newArray = [];
        for (let i = n; i < this.length; i++) {
            newArray.push(this[i]);
        }
        return newArray;
    };

    Array.prototype.take = function (n) {
        let newArray = [];
        for (let i = 0; i < n; i++) {
            newArray.push(this[i]);
        }
        return newArray;
    };

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b);
    };

    Array.prototype.average = function () {
        return this.sum() / this.length;
    };
})();