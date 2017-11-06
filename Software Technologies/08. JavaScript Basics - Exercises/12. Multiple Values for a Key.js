function solve(args) {
    let count = 0;
    let arr = [];

    for(let arg of args.slice(0, args.length - 1)){
        let tokens = arg.split(' ');
        let key = tokens[0];
        let value = tokens[1];

        if(!arr[key]){
            arr[key] = [];
        }
        arr[key].push(value);
    }

    let outputKey = args[args.length - 1];

    console.log(arr[outputKey] ? arr[outputKey].join('\n') : 'None');
}

//solve('3 test\n3 test1\n4 test2\n4 test3\n4 test5\n4'.split('\n'));