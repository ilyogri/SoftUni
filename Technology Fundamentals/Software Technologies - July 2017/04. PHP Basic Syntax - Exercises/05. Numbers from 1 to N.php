<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Numbers from 1 to N</title>
    </head>
    <body>
        <?php $numbers=array();
            if(isset($_GET['num'])){
                $num = intval($_GET['num']);
                for ($i = 1; $i <= $num; $i++){
                    $numbers[] = $i;
                }
            }
        ?>

        <form>
            N: <input type="text" name="num">
            <input type="submit" value="Submit"><br/>
            <?= implode(" ", $numbers) ?>
        </form>
    </body>
</html>