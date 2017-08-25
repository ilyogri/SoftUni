<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Odd Numbers from N to 1</title>
    </head>
    <body>
        <?php $numbers=array();
        if(isset($_GET['num'])){
            $num = intval($_GET['num']);
            for ($i = $num; $i >= 1; $i--){
                if($i % 2 != 0){
                    $numbers[] = $i;
                }
            }
        }
        ?>

        <form>
            N: <input type="text" name="num">
            <input type="submit" value="Submit"><br/>
            <?= implode(" ",$numbers) ?>
        </form>
    </body>
</html>