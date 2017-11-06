function printSymmetricNums(input) {
    let number = Number(input);
    let symmetricNums = [];

    for(let i=1; i <= number; i++){
        if(isSymmetric(i)){
            symmetricNums.push(i);
        }
    }

    function isSymmetric(number) {
        number = number + "";

        if(number === number.split('').reverse().join('')){
            return true;
        }

        return false;
    }

    console.log(symmetricNums.join(" "));
}