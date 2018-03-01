let lookupChar = require('../10.CharLookup').lookupChar;
let expect = require('chai').expect;

describe('lookupChar Tests', function () {
    describe('Test inputs', function (){
        it('with first parameter integer (13), should return undefind', () => {
            expect(lookupChar(13, 0)).to.be.undefined;
        });
        it('with second parameter string "test", should return undefind', () => {
            expect(lookupChar('test', 'test2')).to.be.undefined;
        });
        it('with second parameter string floating-point number, should return undefind', () => {
            expect(lookupChar('test', 3.3)).to.be.undefined;
        });

        it('second param (index) is bigger than or equal to the string length, must return text "Incorrect index', () => {
           expect(lookupChar('test', 7)).to.be.equal('Incorrect index'); 
        });
        it('second param (index) is negative number, must return text "Incorrect index', () => {
            expect(lookupChar('test', -7)).to.be.equal('Incorrect index'); 
         });
        it('with input parameter with correct value ("test", 2), must return "s"', () => {
           expect(lookupChar('test', 2)) .to.be.equal('s');
        });
    });
});