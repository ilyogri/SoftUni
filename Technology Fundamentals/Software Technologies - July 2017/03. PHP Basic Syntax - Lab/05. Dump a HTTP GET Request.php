<!DOCTYPE html>
<html>
    <head>
        <title>Dump a HTTP GET Request</title>
    </head>
    <body>
        <form>
            Name: </br>
            <input id="name" type="text" name="name"></input></br>
            Age: </br>
            <input id="age" type="number" name="age"></input></br>
            Town: </br>
            <select name="townId">
                <option value="1">Sofia</option>
                <option value="2">Varna</option>
                <option value="3">Sliven</option>
                <option value="4">Burgas</option>
            </select></br>
            <input type="submit"/>
        </form>
        <?php var_dump($_GET);?>
    </body>
</html>