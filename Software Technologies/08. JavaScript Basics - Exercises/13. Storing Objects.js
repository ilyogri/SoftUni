function solve(args) {
    let obj = [{}];

    for(let arg of args){
        arg = arg.split(' -> ');
        let name = arg[0];
        let age = arg[1];
        let grade = arg[2];

        let person = {name:name, age:age, grade:grade};
        obj.push(person);
    }

    for(let person of obj.filter(x => x.name !== undefined)) {
        console.log(`Name: ${person.name}`);
        console.log(`Age: ${person.age}`);
        console.log(`Grade: ${person.grade}`);
    }
}

solve('Pesho -> 13 -> 6.00\nIvan -> 12 -> 5.57\nToni -> 13 -> 4.90'.split('\n'));