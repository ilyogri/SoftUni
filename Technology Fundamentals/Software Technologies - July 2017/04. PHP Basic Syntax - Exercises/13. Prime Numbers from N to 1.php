<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Prime Numbers from N to 1</title>
    </head>
    <body>
        <form>
            N: <input type="text" name="num">
            <input type="submit" value="Submit"><br/>
        </form>
        <?php if(isset($_GET['num'])){
            function isPrime($num){
                if ($num == 1) return false;
                if ($num == 2) return true;

                if($num % 2 == 0) return false;
                $boundary = ceil(sqrt($num));

                for ($i = 3; $i <= $boundary; $i+=2)
                {
                    if ($num % $i == 0) return false;
                }

                return true; }

            $num = intval($_GET['num']);
            $primes = array();
            for ($i=$num; $i>=1; $i--){
                if(isPrime($i)){
                    $primes[] = $i;
                }
            }
            echo implode(" ", $primes);
        }
        ?>
    </body>
</html>