function solve(args) {
    let obj = {};

     for(let arg of args){
         arg = arg.split(' -> ');
         let name = arg[0];
         let value = arg[1];

         if(!isNaN(value)){
             value = Number(value);
         }
        `${value} asdlasdas ${name}`
         obj[name] = value;
     }

     console.log(JSON.stringify(obj))
}

//solve('name -> Angel\nsurname -> Georgiev\nage -> 20\ngrade -> 6.00\ndate -> 23/05/1995\ntown -> Sofia'.split('\n'));