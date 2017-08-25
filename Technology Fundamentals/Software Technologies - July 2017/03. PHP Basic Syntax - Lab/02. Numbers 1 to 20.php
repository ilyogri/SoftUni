<!DOCTYPE html>
<html>
    <head>
        <title>Numbers 1 to 20</title>
    </head>
    <body>
        <ul>
            <?php
                for ($i=1; $i <= 20; $i++){
                    if($i % 2 == 0) {
                        $color = 'green';
                    } else{
                        $color = 'blue';
                    }

                    echo "<li><span style='color: $color;'>$i</span></li>";
                }
            ?>
        </ul>
    </body>
</html>