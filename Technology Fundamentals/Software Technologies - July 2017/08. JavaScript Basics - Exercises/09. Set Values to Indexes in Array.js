function solve(args) {
    let arrSize = Number(args[0]);
    let nums = [];

    for(let i=1; i < args.length; i++){
        let tokens = args[i].toString().split(' - ').map(Number);
        let index = tokens[0];
        let value = tokens[1];

        nums[index] = value;
    }

    for(let i=0; i < arrSize; i++){
        if(nums[i] === undefined){
            nums[i] = 0;
        }

        console.log(nums[i]);
    }
}

// solve([
//     '5',
//     '0 - 3',
//     '3 - -1',
//     '4 - 2'
// ]);