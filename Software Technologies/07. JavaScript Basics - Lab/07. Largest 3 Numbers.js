function solve(inputNums) {
    let numbers = inputNums.map(Number);

    numbers = numbers.sort((a, b) => b - a);
    let total = Math.min(numbers.length, 3);

    for(let i = 0; i < total; i++){
      console.log(numbers[i]);
    }
}

solve([
    "10",
    "20",
    "30"
]);