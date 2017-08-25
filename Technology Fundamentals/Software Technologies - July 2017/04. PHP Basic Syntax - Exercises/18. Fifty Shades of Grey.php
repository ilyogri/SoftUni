<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>First Steps Into PHP</title>
        <style>
            div{
                display: inline-block;
                margin: 5px;
                width: 30px;
                height: 30px;
            }
        </style>
    </head>
    <body>
        <?php
        for ($rows=0;$rows<=204;$rows+=51){
            $colsMax=$rows + 45;
            for ($cols=$rows;$cols<=$colsMax;$cols+=5){
                echo "<div style='background-color: rgb($cols, $cols, $cols)'></div>";
            }
            ?> <br/> <?php
        }
        ?>
    </body>
</html>