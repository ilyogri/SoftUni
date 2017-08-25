<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Multiply Two Numbers</title>
    </head>
    <body>
        <?php
            function Multiply(int $num1, int $num2){
                return $num1 * $num2;
            }

            $result = "";
            if(isset($_GET['num1']) && $_GET['num2']){
                $num1 = intval($_GET['num1']);
                $num2 = intval($_GET['num2']);
                $result = Multiply($num1, $num2);
            }
        ?>

        <form>
           N: <input type="text" name="num1">
            M: <input type="text" name="num2">
            <input type="submit" value="Multiply"><br/>
            <?= $result ?>
        </form>
    </body>
</html>