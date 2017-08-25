function solve(args) {
    for (let arg of args) {
        let parsed = JSON.parse(arg);

        console.log(`Name: ${parsed.name}`);
        console.log(`Age: ${parsed.age}`);
        console.log(`Date: ${parsed.date}`);
    }
}

//solve('{"name":"Gosho","age":10,"date":"19/06/2005"}\n{"name":"Tosho","age":11,"date":"04/04/2005"}'.split('\n'));