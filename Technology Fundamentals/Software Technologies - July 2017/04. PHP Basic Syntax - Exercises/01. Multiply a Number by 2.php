<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Multiply a Number by 2</title>

</head>
<body>
    <?php
        function Multiply(int $number){
            return $number * 2;
        }

        $num = "";
        if(isset($_GET['num'])){
            $num =  Multiply($_GET['num']);
        }
    ?>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" value="Multiply"/><br/>
        <?= $num ?>
    </form>
</body>
</html>