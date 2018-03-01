let mathEnforcer = require('../11.MathEnforcer').mathEnforcer;
let expect = require('chai').expect;

describe('Math Enforcer Test', function () {
    describe('addFive', function () {
        it('with not a number parameter "test", must return undefind', () => {
            expect(mathEnforcer.addFive('test')).to.be.undefined;
        });
        it('with not a number parameter object, must return undefind', () => {
            expect(mathEnforcer.addFive({ name: 'pesho' })).to.be.undefined;
        });
        it('with negative number parameter -5, must return 0', () => {
            expect(mathEnforcer.addFive(-5)).to.be.equal(0);
        });
        it('with floating-point number parameter 3.3, must return 8.3', () => {
            expect(mathEnforcer.addFive(3.3)).to.be.equal(8.3, 0.01);
        });
        it('with number parameter 5, must return 10', () => {
            expect(mathEnforcer.addFive(5)).to.be.equal(10);
        });
    });
    describe('subtractTen', function () {
        it('with not a number parameter "test", must return undefind', () => {
            expect(mathEnforcer.subtractTen('test')).to.be.undefined;
        });
        it('with not a number parameter object, must return undefind', () => {
            expect(mathEnforcer.subtractTen({ name: 'pesho' })).to.be.undefined;
        });
        it('with negative number parameter -10, must return -20', () => {
            expect(mathEnforcer.subtractTen(-10)).to.be.equal(-20);
        });
        it('with floating-point number parameter 20.2, must return 10.2', () => {
            expect(mathEnforcer.subtractTen(20.2)).to.be.equal(10.2);
        });
        it('with number parameter 20, must return 10', () => {
            expect(mathEnforcer.subtractTen(20)).to.be.equal(10);
        });
    });
    describe('sum', function () {
        it('with not a number, first parameter ("test", 5), must return undefind', () => {
            expect(mathEnforcer.sum('test', 5)).to.be.undefined;
        });
        it('with not a number, second parameter (5, "test"), must return undefind', () => {
            expect(mathEnforcer.sum(5, 'test')).to.be.undefined;
        });
        it('with number parameters (10, 20), must return 30', () => {
            expect(mathEnforcer.sum(10, 20)).to.be.equal(30);
        });
        it('with negative numbers (-5, -5), must return -10', () => {
            expect(mathEnforcer.sum(-5, -5)).to.be.equal(-10);
        });
        it('with floating - point numbers (10.53, 22.11), must return 32.64', ()=>{
            expect(mathEnforcer.sum(10.53, 22.11)).to.be.closeTo(32.64, 0.01);
        });
    });
});