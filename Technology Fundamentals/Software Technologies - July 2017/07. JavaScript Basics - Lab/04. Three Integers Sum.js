function findSum(input) {
    input = input.toString().split(' ');

    let numbers = input.map(Number);

    console.log(checkForSum(numbers[0],numbers[1], numbers[2]) ||
        checkForSum(numbers[1],numbers[2], numbers[0]) ||
        checkForSum(numbers[0],numbers[2], numbers[1]) ||
        'No');

    function checkForSum(firstNum, secondNum, sum){
        if(firstNum + secondNum !== sum){
            return false;
        }

        if(firstNum > secondNum){
            [firstNum,secondNum] = [secondNum,firstNum];
        }

        return `${firstNum} + ${secondNum} = ${sum}`;
    }
}