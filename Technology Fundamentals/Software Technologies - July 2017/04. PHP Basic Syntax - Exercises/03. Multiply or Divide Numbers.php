<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Multiply / Divide Numbers</title>
    </head>
    <body>
        <?php
            function Divide(float $num1, float $num2){
                return $num1 / $num2;
            }

            function Multiply(float $num1, float $num2){
                return $num1 * $num2;
            }

            $result = "";
            if(isset($_GET['num1']) && isset($_GET['num2'])){
                $num1 = floatval($_GET['num1']);
                $num2 = floatval($_GET['num2']);

                if($num1 > $num2){
                    $result = Divide($num1, $num2);
                } else{
                    $result = Multiply($num1, $num2);
                }

            }
        ?>
        <form>
          N: <input type="text" name="num1">
            M: <input type="text" name="num2">
            <input type="submit" value="Calculate"><br/>
            <?= $result ?>
        </form>
    </body>
</html>