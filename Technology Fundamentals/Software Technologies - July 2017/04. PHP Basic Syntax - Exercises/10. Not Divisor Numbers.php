<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Not Divisor Numbers</title>
</head>
    <body>
        <form>
            N: <input type="text" name="num">
            <input type="submit" value="Submit"><br/>
        </form>
        <?php
            $num="";
            $result=array();
            if(isset($_GET['num'])){
                $num = intval($_GET['num']);
                for ($i=$num;$i>=1;$i--){
                    if($num % $i != 0){
                        $result[]=$i;
                    }
                }

                echo implode(" ", $result);
            }
        ?>
    </body>
</html>