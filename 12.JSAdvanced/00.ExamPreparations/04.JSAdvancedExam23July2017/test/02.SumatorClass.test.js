let Sumator = require('../02.SumatorClass.js').Sumator;
let expect = require('chai').expect;

describe('Test sumator class', function () {
    let myClass;
    beforeEach(function () {
        myClass = new Sumator();
    });
    describe('Test initial state', function () {
        it('Add exists', function () {
            expect(Sumator.prototype.hasOwnProperty('add')).to.equal(true);
        });
        it('Sum exists', function () {
            expect(Sumator.prototype.hasOwnProperty('sumNums')).to.equal(true);
        });
        it('Remove filter exists', function () {
            expect(Sumator.prototype.hasOwnProperty('removeByFilter')).to.equal(true);
        });
        it('toString exists', function () {
            expect(Sumator.prototype.hasOwnProperty('toString')).to.equal(true);
        });
    });
    describe('Test toString func', function () {
        it('Expect return "(empty)" with empty data', () => {
            expect(myClass.toString()).to.be.equal('(empty)');
        });
    });
    describe('Test add function', function () {
        it('Expect add correct element with add(5)', () => {
            myClass.add(5);
            expect(myClass.data.length).to.be.equal(1, 'Data don`t add correctly!');
        });
        it('Expect add correct multiply elements add(5), add(6), add("two")', () => {
            myClass.add(5);
            myClass.add(6);
            myClass.add('two');
            expect(myClass.data.length).to.be.equal(3, 'Data don`t add correctly!');
        });
    });
    describe('Test sumNums function', function () {
        it('Expect return 0 with empty data', () => {
            expect(myClass.sumNums()).to.be.equal(0, 'Data don`t sumNums correctly!');
        });
        it('Expect return 0 with string elements in data', () => {
            myClass.add('two');
            expect(myClass.sumNums()).to.be.equal(0, 'Data don`t sumNums correctly!');
        });
        it('Expect return correct sum with elements 5, 6', () => {
            myClass.add(5);
            myClass.add(6);
            expect(myClass.sumNums()).to.be.equal(11, 'Data don`t sumNums correctly!');
        });
    });
    describe('Test removeByFilter function', function () {
        it('Expect return correct nums with x => x % 2 === 0', () => {
            myClass.add(1);
            myClass.add(2);
            myClass.add(3);
            myClass.add(4);
            myClass.removeByFilter(x => x % 2 === 0);
            expect(myClass.toString()).to.be.equal('1, 3', 'Data don`t remove by filter correctly!');
        });
        it('Expect return empty filtered nums with no elements in data', () => {
            myClass.removeByFilter(x => x % 2 === 0);
            expect(myClass.toString()).to.be.equal('(empty)', 'Data don`t remove by filter correctly!');
        });
        it('Expect filter all names that start with K', function () {
            myClass.add('Kiro');
            myClass.add('Lili');
            myClass.add('Krasi');
            myClass.add('Mimi');
            myClass.add('Kamen');
            myClass.removeByFilter(x => x.startsWith('K'));
            expect(myClass.toString()).to.equal('Lili, Mimi', 'Remove By Filter did not filter correctly!');
        });
    });
});