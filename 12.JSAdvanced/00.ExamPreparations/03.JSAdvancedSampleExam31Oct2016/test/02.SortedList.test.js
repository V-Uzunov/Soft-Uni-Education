let SortedList = require('../02.SortedList.js').SortedList;
let expect = require('chai').expect;

describe('Test SortedList class', function () {
    let myList;
    beforeEach(function () {
        myList = new SortedList();
    });
    describe('Test initial state', function () {
        it('Add exists', function () {
            expect(SortedList.prototype.hasOwnProperty('add')).to.equal(true);
        });
        it('Remove exists', function () {
            expect(SortedList.prototype.hasOwnProperty('remove')).to.equal(true);
        });
        it('Get exists', function () {
            expect(SortedList.prototype.hasOwnProperty('get')).to.equal(true);
        });
        it('Size exists', function () {
            expect(SortedList.prototype.hasOwnProperty('size')).to.equal(true);
        });
    });
    describe('Test add function', function () {
        it('Expect add correct element add(5)', () => {
            myList.add(5);
            expect(myList.list.join(', ')).to.be.equal('5', 'List don`t add correctly!');
        });
        it('Expect add correct multiply elements add(5), add(6)', () => {
            myList.add(5);
            myList.add(6);
            myList.add(4);
            expect(myList.list.join(', ')).to.be.equal('4, 5, 6', 'List don`t add correctly!');
        });
    });
    describe('Test remove function', function () {
        it('Expect remove correctly element', () => {
            myList.add(3);
            myList.add(5);
            myList.add(4);
            myList.remove(1);
            expect(myList.list.join(', ')).to.be.equal('3, 5', 'List don`t remove correctly!');
        });
        it('Expect throw Error with empty list', () => {
            expect(() => myList.remove()).throw(Error, 'Collection is empty.');
        });
        it('Expect throw Error with negative index', () => {
            myList.add(3);
            expect(() => myList.remove(-1)).throw(Error, 'Index was outside the bounds of the collection.')
        });
        it('Expect throw Error with bigger number than list index', () => {
            myList.add(3);
            expect(() => myList.remove(2)).throw(Error, 'Index was outside the bounds of the collection.')
        });
    });
    describe('Test get function', function () {
        it('Expect return correct index', () => {
            myList.add(3);
            myList.add(5);
            myList.add(4);
            expect(myList.get(1)).to.be.equal(4, 'List don`t get correctly index.');
        });
        it('Expect throw Error with empty list', () => {
            expect(() => myList.get()).throw(Error, 'Collection is empty.');
        });
        it('Expect throw Error with negative index', () => {
            myList.add(3);
            expect(() => myList.get(-1)).throw(Error, 'Index was outside the bounds of the collection.')
        });
        it('Expect throw Error with bigger number than list index', () => {
            myList.add(3);
            expect(() => myList.get(2)).throw(Error, 'Index was outside the bounds of the collection.')
        });
    });
    describe('Test size property', function () {
        it('Expect return correctly list length', () => {
            myList.add(3);
            myList.add(5);
            myList.add(4);
            expect(myList.size).to.be.equal(3, 'List don`t get corrctly length');
        });
        it('Expect return correctly list length with no elements', () => {
            expect(myList.size).to.be.equal(0, 'List was not empty');
        });
    });
});