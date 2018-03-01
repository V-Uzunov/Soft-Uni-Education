let sharedObject = require('../12.SharedObject').sharedObject;
let expect = require('chai').expect;
let $ = require('../node_modules/jquery/dist/jquery');
let jsdom = require('jsdom-global')();

document.body.innerHTML = '<body><div id="wrapper"><input type="text" id="name"> <input type="text" id="income"> </div>  </body>';

describe('Shared Object Unit Tests', function () {
    describe('Initial value tests', function () {
        it('Initial value for name (should be null)', function () {
            expect(sharedObject.name).to.be.null;
        });
        it('Initial value for name (should be null)', function () {
            expect(sharedObject.income).to.be.null;
        });
    });

    describe('changeName tests', function () {
        it('Pass empty string (should not change)', function () {
            sharedObject.changeName('');
            expect(sharedObject.name).to.be.equal(null, 'Name should not change');
        });
        it('Pass empty string with preexisting value (should not change)', function () {
            sharedObject.name = 'Kenov';
            sharedObject.changeName('');
            expect(sharedObject.name).to.be.equal('Kenov', 'Name should not change');
        });
        it('Pass non-empty string (should change)', function () {
            sharedObject.changeName('Veso');
            expect(sharedObject.name).to.be.equal('Veso', 'Name should change');
        });

        describe('changeName textbox tests', function () {
            it('Pass empty string (should not change textbox)', function () {
                let nameTxt = $('#name');
                sharedObject.changeName('');
                expect(nameTxt.val()).to.be.equal('Veso', 'Name should not change');
            });
            it('Pass non-empty string (should change)', function () {
                let nameTxt = $('#name');
                sharedObject.changeName('Veneta');
                expect(nameTxt.val()).to.be.equal('Veneta', 'Name should change');
            });
        })
    });
    
    describe('changeIncome tests', function () {
        it('Pass object inside should not change income', function () {
            sharedObject.changeIncome({});
            expect(sharedObject.income).to.be.null;
        });
        it('Pass object inside with predefined value should not change income', function () {
            sharedObject.income = 22;
            sharedObject.changeIncome({});
            expect(sharedObject.income).to.be.equal(22);
        });
        it('Pass floating-point should not change income', function () {
            sharedObject.income = 33;
            sharedObject.changeIncome(22.1);
            expect(sharedObject.income).to.be.equal(33);
        });
        it('Pass negative integer should not change income', function () {
            sharedObject.income = 33;
            sharedObject.changeIncome(-33);
            expect(sharedObject.income).to.be.equal(33);
        });
        it('Pass zero should not change income', function () {
            sharedObject.income = 33;
            sharedObject.changeIncome(0);
            expect(sharedObject.income).to.be.equal(33);
        });
        it('Pass positive integer should change income', function () {
            sharedObject.income = 33;
            sharedObject.changeIncome(44);
            expect(sharedObject.income).to.be.equal(44);
        });

        describe('changeIncome textbox tests', function () {
            it('Pass object inside should not change income', function () {
                sharedObject.changeIncome(33);
                let incomeTxt = $('#income');
                sharedObject.changeIncome({});
                expect(incomeTxt.val()).to.be.equal('33');
            });
            it('Pass floating-point should not change income', function () {
                sharedObject.changeIncome(33);
                let incomeTxt = $('#income');
                sharedObject.changeIncome(22.2);
                expect(incomeTxt.val()).to.be.equal('33');
            });
            it('Pass negative integer should not change income', function () {
                sharedObject.changeIncome(33);
                let incomeTxt = $('#income');
                sharedObject.changeIncome(-50);
                expect(incomeTxt.val()).to.be.equal('33');
            });
            it('Pass zero should not change income', function () {
                sharedObject.changeIncome(33);
                let incomeTxt = $('#income');
                sharedObject.changeIncome(0);
                expect(incomeTxt.val()).to.be.equal('33');
            });
            it('Pass positive integer should change income', function () {
                sharedObject.changeIncome(33);
                let incomeTxt = $('#income');
                sharedObject.changeIncome(50);
                expect(incomeTxt.val()).to.be.equal('50');
            });
        })
    });

    describe('changeName tests', function () {
        it('Pass empty string (should not change)', function () {
            sharedObject.changeName('Veso');
            let nameTxt = $('#name');
            nameTxt.val('');
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('Veso');
        });
        it('Pass non-empty string (should change)', function () {
            sharedObject.changeName('Veso');
            let nameTxt = $('#name');
            nameTxt.val('Veneta');
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('Veneta');
        });
    });

    describe('changeIncome tests', function () {
        it('Pass a string (should not change)', function () {
            sharedObject.changeIncome(11);
            let incomeTxt = $('#income');
            incomeTxt.val('Veso');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(11);
        });
        it('Pass a floating-point (should not change)', function () {
            sharedObject.changeIncome(11);
            let incomeTxt = $('#income');
            incomeTxt.val('22.2');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(11);
        });
        it('Pass a negative integer (should not change)', function () {
            sharedObject.changeIncome(11);
            let incomeTxt = $('#income');
            incomeTxt.val('-11');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(11);
        });
        it('Pass zero (should not change)', function () {
            sharedObject.changeIncome(11);
            let incomeTxt = $('#income');
            incomeTxt.val('0');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(11);
        });
        it('Pass a positive integer (should change)', function () {
            sharedObject.changeIncome(11);
            let incomeTxt = $('#income');
            incomeTxt.val('66');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(66);
        });
    });
});