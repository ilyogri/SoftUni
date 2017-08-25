function solve(numbers) {
    numbers = numbers.map(Number);
    let firstNum = numbers[0];
    let secondNum = numbers[1];

    if(secondNum >= firstNum){
        console.log(firstNum * secondNum);
    } else {
        console.log(firstNum / secondNum);
    }
}