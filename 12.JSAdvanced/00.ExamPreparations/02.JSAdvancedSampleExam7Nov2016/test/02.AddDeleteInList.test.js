let expect = require('chai').expect;
let list = require('../02.AddDeleteInList.js').list;

describe('Add/Delete in list Test', function () {
    let resultList;
    beforeEach(function () {
        resultList = list;
    });
    it('Expect return Object', () => {
        expect(typeof resultList).to.be.equal('object');
    });

    describe('Add, toString() functions Test', function () {
        it('Test empty list', function () {
            expect(resultList.toString()).to.equal('', 'List was not empty!')
        });
        it('Expect apend add(3)', () => {
            resultList.add(3);
            expect(resultList.toString()).to.be.equal('3');
        });
        it('Expect apend add("text")', () => {
            resultList.add('text');
            expect(resultList.toString()).to.be.equal('text');
        });
        it('toString expect return 3, 4 after apend add(3), add(4)', () => {
            resultList.add(3);
            resultList.add(4);
            expect(resultList.toString()).to.be.equal('3, 4');
        });
    });
    describe('Test Delete functions', function () {
        it('Expect return undefind if index is not a number', () => {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            expect(resultList.delete('text')).to.be.undefined;
        });
        it('Expect return undefind if index is negative number', () => {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            expect(resultList.delete(-2)).to.be.undefined;
        });
        it('Expect return undefind if index is floating-point number', () => {
            expect(resultList.delete(1.3)).to.be.undefined;
        });
        it('Expect return undefind if index is bigger than list length', () => {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            expect(resultList.delete(3)).to.be.undefined;
        });
        it('with empty list should return undefined', function () {
            expect(resultList.delete(0)).to.be.undefined;
        });
        it('Expect return correct result with index = 1', () => {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            expect(resultList.delete(1)).to.be.equal(2);
        });
        it('with index 0 should delete from list', function () {
            resultList.add(5);
            resultList.add(6);
            resultList.add(7);
            resultList.delete(0);
            expect(resultList.toString()).to.be.equal('6, 7');
        });
    });
});