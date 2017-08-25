function solve(args) {
    let result = {};

    for (let i = 0; i < args.length; i++) {
        let townIncome = JSON.parse(args[i]);
        let town = townIncome.town;
        let income = townIncome.income;

        if (town in result) {
            result[town] += income;
        } else {
            result[town] = income;
        }
    }

        let towns = Object.keys(result).sort();

        for (let i = 0; i < towns.length; i++){
            console.log(`${towns[i]} -> ${result[towns[i]]}`);
        }
}

solve([
    '{"town":"Sofia","income":200}',
    '{"town":"Varna","income":120}',
    '{"town":"Pleven","income":60}',
     '{"town":"Varna","income":70}'
]);