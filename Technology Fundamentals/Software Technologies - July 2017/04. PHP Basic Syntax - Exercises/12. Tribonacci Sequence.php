<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Tribonacci Sequence</title>
    </head>
    <body>
        <form>
           N: <input type="text" name="num">
            <input type="submit" value="Submit"><br/>
        </form>

        <?php
            if(isset($_GET['num'])){
                $num = intval($_GET['num']);
                $tribonacciNums=array(1, 1, 2);
                for ($i=0; $i < $num - 3; $i++){
                    $firstNum = $tribonacciNums[$i];
                    $secondNum = $tribonacciNums[$i + 1];
                    $thirdNum = $tribonacciNums[$i + 2];
                    $sum = $firstNum + $secondNum + $thirdNum;
                    $tribonacciNums[]=$sum;
                }

                echo implode(" ",$tribonacciNums);
            }
        ?>
    </body>
</html>