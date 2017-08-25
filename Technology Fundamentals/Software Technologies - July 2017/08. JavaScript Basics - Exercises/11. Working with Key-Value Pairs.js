function solve(args) {
    let dict = {};

    for (let arg of args.slice(0, args.length - 1)) {
        let tokens = arg.split(' ');

        let key = tokens[0];
        let value = tokens[1];

        dict[key] = value;
    }

    let outputKey = args[args.length - 1];

    console.log(dict[outputKey] || 'None');
}

//solve('3test\n3test1\n4test2\n4test3\n4 test5\n4'.split('\n'));