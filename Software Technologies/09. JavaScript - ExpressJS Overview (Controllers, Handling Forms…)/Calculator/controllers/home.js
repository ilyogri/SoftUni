const Calculator = require('./../models/Calculator');

module.exports = {
    indexGet: (req, res) => {
        res.render('home/index');
    },
    indexPost: (req, res) => {
        let calculatorParams =
            req.body['calculator'];

         let calculator = new Calculator(
             Number(calculatorParams.leftOperand),
             Number(calculatorParams.rightOperand),
             calculatorParams.operator
         );

        let result = calculator.calculateResult();

        res.render('home/index', {
            'calculator': calculator,
            'result':result
        });
    }
};