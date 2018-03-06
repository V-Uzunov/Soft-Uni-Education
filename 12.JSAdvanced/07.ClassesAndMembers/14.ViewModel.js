class Textbox{
    constructor(selector, regex){
        this._elements = $(selector);
        this.value = $(this._elements[0]).val();
        this._invalidSymbols = regex;
        this.onInput();
    }
    onInput() {
        this._elements.on('input', (event) => {
            let text = $(event.target).val();
            this._value = text;
            for (let el of this._elements) {
                $(el).val(text);
            }
        });
    }
    get value() {
        return this._value;
    }

    set value(value) {
        this._value = value;
        for (let el of this._elements) {
            $(el).val(value);
        }
    }
    get elements() {
        return this._elements;
    }

    isValid() {
        return !this._invalidSymbols.test(this._value);
    }
}
let textbox = new Textbox('.textbox', /[^a-zA-Z0-9]/);
let inputs = $('.textbox');

inputs.on('input',function(){
    console.log(textbox.value);
});
