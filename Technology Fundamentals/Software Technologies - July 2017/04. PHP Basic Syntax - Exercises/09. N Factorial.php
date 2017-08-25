<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>N Factorial</title>
    </head>
    <body>
    <form>
        N: <input type="text" name="num">
        <input type="submit" value="Submit"><br/>
    </form>
        <?php
           $num="";
           $factorial=1;
            if(isset($_GET['num'])){
                $num=intval($_GET['num']);
                for ($i=1; $i<=$num;$i++){
                    $factorial *= $i;
                }

                echo $factorial;
            }
        ?>
    </body>
</html>