function solve(text) {
    text = text.join(" ");
    let pattern = /\b[A-Z]+\b/g;
    let result = [];

    let matches = text.match(pattern);
    result.push(matches.join(", "));

    console.log(result.join(""));
}

text = [
    'We start by HTML, CSS, JavaScript, JSON and REST.',
    'Later we touch some PHP, MySQL and SQL.',
    'Later we play with C#, EF, SQL Server and ASP.NET MVC.',
    'Finally, we touch some Java, Hibernate and Spring.MVC.'
];

solve(text);