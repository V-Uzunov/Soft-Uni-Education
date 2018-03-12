let expect = require('chai').expect;
let createList = require('../02.AddSwapShiftLeftRightInList.js').createList;

describe('AddSwapShiftLeftRightInList Tests', function () {
    let resultList;
    beforeEach(function () {
        resultList = createList();
    });
    describe('Test return value', function () {
        it('Expect list to be an object', function () {
            expect(typeof resultList).to.be.equal('object');
        });
        it('Expect shiftLeft to be function', () => {
            expect(typeof resultList.shiftLeft).to.be.equal('function');
        });
        it('Expect shiftRight to be function', () => {
            expect(typeof resultList.shiftRight).to.be.equal('function');
        });
        it('Expect swap to be function', () => {
            expect(typeof resultList.swap).to.be.equal('function');
        });
        it('Expect toString to be function', () => {
            expect(typeof resultList.toString).to.be.equal('function');
        });
    });
    describe('Test the internal value', function () {
        it('Expect value to be undefined', function () {
            expect(resultList.value).to.be.undefined;
        });
    });
    describe('Test Add and toString func', function () {
        it('toString must return "3, 4" after add(3), add(4)', () => {
            resultList.add(3);
            resultList.add(4);
            expect(resultList.toString()).to.be.equal('3, 4');
        });
        it('Expect add(4) to return 4', () => {
            resultList.add(4);
            expect(resultList.toString()).to.be.equal('4');
        });
        it('Expect add(4, "5", {name: "Veso"}) return "4, 5, [object Object]"', function () {
            resultList.add(4);
            resultList.add('5');
            resultList.add({name: 'Kiro'});
            expect(resultList.toString()).to.equal('4, 5, [object Object]')
        });
    });
    describe('Test Shift Left func', function () {
        it('shiftLeft expect return same length if length < 1', () => {
            resultList.add(4);
            resultList.shiftLeft();
            expect(resultList.toString()).to.be.equal('4');
        });
        it('Expect shiftLeft elements (3, 4, 5) to return (4, 5, 3)', () => {
            resultList.add(3);
            resultList.add(4);
            resultList.add(5);
            resultList.shiftLeft();
            expect(resultList.toString()).to.be.equal('4, 5, 3');
        });
        it('shiftLeft expect return .... if no elements in list', () => {
            resultList.shiftLeft();
            expect(resultList.toString()).to.be.equal('');
        });
    });
    describe('Test Shift Right func', function () {
        it('shiftRight expect return same length if length < 1', () => {
            resultList.add(4);
            resultList.shiftRight();
            expect(resultList.toString()).to.be.equal('4');
        });
        it('Expect shiftRight elements (3, 4, 5) to return (5, 3, 4)', () => {
            resultList.add(3);
            resultList.add(4);
            resultList.add(5);
            resultList.shiftRight();
            expect(resultList.toString()).to.be.equal('5, 3, 4');
        });
        it('shiftRight expect return "" if no elements in list', () => {
            resultList.shiftRight();
            expect(resultList.toString()).to.be.equal('');
        });
    });
    describe('Test swap', function () {
        it('index1 as string', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap('0', 2);
            expect(result).to.equal(false, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('1, 2, 3', 'Elements should not swap!')
        });
        it('index2 as string', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap(0, '2');
            expect(result).to.equal(false, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('1, 2, 3', 'Elements should not swap!')
        });
        it('negative index1', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap(-2 , 2);
            expect(result).to.equal(false, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('1, 2, 3', 'Elements should not swap!')
        });
        it('negative index2', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap(2 , -2);
            expect(result).to.equal(false, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('1, 2, 3', 'Elements should not swap!')
        });
        it('index1 as much as data length', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap(3 , 2);
            expect(result).to.equal(false, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('1, 2, 3', 'Elements should not swap!')
        });
        it('index2 as much as data length', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap(2 , 3);
            expect(result).to.equal(false, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('1, 2, 3', 'Elements should not swap!')
        });
        it('index1 larger than data length', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap(4 , 2);
            expect(result).to.equal(false, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('1, 2, 3', 'Elements should not swap!')
        });
        it('index2 larger than data length', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap(2 , 4);
            expect(result).to.equal(false, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('1, 2, 3', 'Elements should not swap!')
        });
        it('with equal indexes (in range)', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap(1, 1);
            expect(result).to.equal(false, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('1, 2, 3', 'Elements should not swap!')
        });
        it('with correct indexes (should swap)', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap(0, 2);
            expect(result).to.equal(true, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('3, 2, 1', 'Elements should not swap!')
        });
        it('with correct indexes (should swap)', function () {
            resultList.add(1);
            resultList.add(2);
            resultList.add(3);
            let result = resultList.swap(2, 0);
            expect(result).to.equal(true, 'Elements should not swap!');
            expect(resultList.toString()).to.equal('3, 2, 1', 'Elements should not swap!')
        });
    });
});