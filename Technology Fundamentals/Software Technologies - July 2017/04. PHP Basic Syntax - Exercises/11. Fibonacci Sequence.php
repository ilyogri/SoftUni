<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Fibonacci Sequence</title>
    </head>
    <body>
        <form>
            N: <input type="text" name="num">
            <input type="submit" value="Submit"><br/>
        </form>
        <?php
            if(isset($_GET['num'])){
                $num=intval($_GET['num']);
                $fibonacciNums=array();
                $fibonacciNums[] =1;
                $a=0;
                $b=1;

                for ($i=1; $i< $num;$i++){
                    $temp=$a;
                    $a=$b;
                    $b=$temp+$a;
                    $fibonacciNums[]=$b;
                }
                    echo implode(" ", $fibonacciNums);
            }
        ?>
    </body>
</html>