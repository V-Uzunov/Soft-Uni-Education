let expect = require('chai').expect;
let Console = require('../09.C#Console.js').Console;

describe('C# Console Unit Tests', function () {
    it('writeLine is a functions', function () {
        expect(typeof Console.writeLine).to.be.equal('function');
    });

    describe('tests with one argument passed', function () {
        it('should return the input string', () => {
            let res = Console.writeLine('test');
            expect(res).to.equal('test');
        });

        it('should return undefined on non-string argument', () => {
            let res = Console.writeLine(123);
            expect(res).to.be.undefined;
        });

        it('should throw error оn empty input', () => {
            expect(() => Console.writeLine()).to.throw(TypeError);
        });

        it('should return the input object as JSON', () => {
            let obj = {'name': 'Stamat'};
            let res = Console.writeLine(obj);
            expect(res).to.equal(JSON.stringify(obj));
        });
    });

    describe('tests with multiply arguments', function () {
        it('should throw TypeError on non-string first argument', () => {
            expect(() => Console.writeLine(123, 'test')).to.throw(TypeError);
        });

        it('should throw RangeError on less than expected placeholder parameters', () => {
            expect(() => Console.writeLine('Test {0}, {1} {2}', 'first', 'second')).to.throw(RangeError);
        });

        it('should throw RangeError on more than expected placeholder parameters', () => {
            expect(() => Console.writeLine('Test {0}, {1} {2}', 'first', 'second', 'third', 'fourth')).to.throw(RangeError);
        });

        it('should throw RangeError on negative placeholder index', () => {
            expect(() => Console.writeLine('Test {-5}, {1} {2}', 'first', 'second', 'third')).to.throw(RangeError);
        });

        it('should throw RangeError on out-of-range placeholder index', () => {
            expect(() => Console.writeLine('Test {0}, {1} {20}', 'first', 'second', 'third')).to.throw(RangeError);
        });

        it('should throw RangeError on out-of-range placeholder index', () => {
            expect(() => Console.writeLine('Test {20}', 'first')).to.throw(RangeError);
        });

        it('should replace correctly all placeholders', () => {
            expect(Console.writeLine('Test {0}, {1} {2} - {3}', 'first', 'second', 'third', 'fourth')).to.equal('Test first, second third - fourth');
        });

        it('should replace correctly all placeholders on mixed placeholder numbers', () => {
            expect(Console.writeLine('Test {1}, {0} {2} - {3}', 'first', 'second', 'third', 'fourth')).to.equal('Test second, first third - fourth');
        });

        it('should replace correctly one placeholder', () => {
            expect(Console.writeLine('{0}', 'first')).to.equal('first');
        });
    });
});