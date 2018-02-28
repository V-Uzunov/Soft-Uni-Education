(function () {
    String.prototype.ensureStart = function (str) {
        if(!this.startsWith(str)){
            return str + this;
        }
        return this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if(!this.endsWith(str)){
            return this + str;
        }
        return this.toString();
    };
    String.prototype.isEmpty=function (){
        return this.toString() === '';
    };
    String.prototype.truncate=function (n){
        let newStr = this;
        let haveMoreOrSameLenght = n >= this.length;
        if (!haveMoreOrSameLenght) {
            let substrOfThis = this.substring(0, n).trim();
            let indexOfSpace = substrOfThis.lastIndexOf(' ');
            if(indexOfSpace !== -1){
                return substrOfThis.substring(0, indexOfSpace) + '...';
            }
        }
        return newStr.toString();
    };
    String.format=function (str){
        for (let i = 1; i < arguments.length; i++) {
            str = str.replace('{' + (i - 1) + '}', arguments[i]);
        }
        return str;
    };
})();