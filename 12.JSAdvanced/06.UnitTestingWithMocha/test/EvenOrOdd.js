let isOddOrEven = require('../09.EvenOrOdd').isOddOrEven;
let expect = require('chai').expect;

describe('isOddOrEven', function () {
    it('with number parameter must return undefind', function ()  {
        expect(isOddOrEven(16)).to.be.undefined;
    });
    it('with word "lolo", must return even', function () {
        expect(isOddOrEven('lolo')).to.be.equal('even', 'Function did not return the correct result!');
    });
    it('with word "hah", must return odd', function ()  {
        expect(isOddOrEven('hah')).to.be.equal('odd', 'Function did not return the correct result!');
    });
});