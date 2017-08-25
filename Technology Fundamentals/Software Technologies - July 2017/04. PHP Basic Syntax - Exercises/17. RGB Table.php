<!DOCTYPE html>
<html>
<head>
    <style>
        table,tr,td{
            border: 1px solid black;
            border-collapse: collapse;
        }
        tr,td{
            width: 55px;
            height: 55px;
        }
    </style>
</head>
<body>
<table>
    <tr>
        <td>Red</td>
        <td>Green</td>
        <td>Blue</td>
    </tr>

    <?php
    for ($i=51; $i<=255;$i  +=51) {
        ?> <tr>
            <td style='background-color: rgb(<?= $i ?>, 0, 0)'></td>
            <td style='background-color: rgb(0, <?= $i ?>, 0)'></td>
            <td style='background-color: rgb(0, 0, <?= $i ?>)'></td>
           </tr>
    <?php
    } ?>
</table>
</body>
</html>
