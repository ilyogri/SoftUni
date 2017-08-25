<!DOCTYPE html>
<html>
    <head>
        <title>Sum Two Numbers</title>
    </head>
    <body>
        <?php if(isset($_GET['num1']) && $_GET['num2']){
            $num1 = ($_GET['num1']);
            $num2 = intval($_GET['num2']);
            $sum = $num1 + $num2;
        } ?>
        <form>
            <div>First Number:</div>
            <input type="number" name="num1"/>
            <div>Second Number:</div>
            <input type="number" name="num2"/>
            <div><input type="submit" value="Calculate"/></div>
        </form>
        <?php echo "$num1 + $num2 = $sum";?>
    </body>
</html>