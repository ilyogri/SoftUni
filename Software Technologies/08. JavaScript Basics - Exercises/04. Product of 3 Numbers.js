function solve(numbers) {
    numbers = numbers.map(Number);
    let firstNum = numbers[0];
    let secondNum = numbers[1];
    let thirdNum = numbers[2];

    if(numbers.filter(x => x >= 0).length === 3 ||
        numbers.filter(x => x < 0).length === 2){
        console.log('Positive')
    } else{
        console.log('Negative')
    }
}