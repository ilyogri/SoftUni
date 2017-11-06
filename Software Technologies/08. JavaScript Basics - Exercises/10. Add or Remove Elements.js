function solve(args) {
    let nums = [];

    for(let i = 0; i < args.length; i++){
        let tokens = args[i].split(' ');
        let command = tokens[0];

        if(command === 'add'){
            let element = Number(tokens[1]);
            nums.push(element);
        } else{
            let index = Number(tokens[1]);

            //another way:
            // delete nums[index];
            //nums = nums.filter(x => x !== undefined);
            nums.splice(index,1);
        }
    }

    nums.forEach(x => console.log(x));
}