<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Product of 3 Numbers</title>
    </head>
    <body>
        <?php
            $sign="";
            if(isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3'])){
                $num1 = intval($_GET['num1']);
                $num2 = intval($_GET['num2']);
                $num3 = intval($_GET['num3']);

                $numbers = array();
                array_push($numbers,$num1, $num2, $num3);

                $positive = array_filter($numbers, function ($v) {
                    return $v > 0;
                });

                if(count($positive) == 1 || count($positive) == 3){
                    $sign = 'Positive';
                } else{
                    $sign = 'Negative';
                }
            }
        ?>

        <form>
          FirstNumber: <input type="text" name="num1"><br/>
            SecondNumber: <input type="text" name="num2"><br/>
            ThirdNumber: <input type="text" name="num3"><br/>
            <input type="submit" value="Submit"><br/>
            <?= $sign ?>
        </form>
    </body>
</html>