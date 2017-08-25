<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Draw an S with Buttons</title>
    </head>
    <body>
        <?php
            for ($rows=0;$rows<9;$rows++) {
                for ($cols = 0; $cols < 5; $cols++) {
                    if($rows==0 || $rows == 4 || $rows==8){ ?>
                        <button style='background-color: blue'>1</button> <?php }

                     else if($rows<=4 && $cols==0){ ?>
                         <button style='background-color:  blue'>1</button> <?php }

                     else if($rows > 4 && $rows<8 && $cols==4){ ?>
                         <button style='background-color: blue'>1</button> <?php }

                    else{ ?>
                        <button>0</button>  <?php } } ?> <br/>
                    <?php } ?>
    </body>
</html>