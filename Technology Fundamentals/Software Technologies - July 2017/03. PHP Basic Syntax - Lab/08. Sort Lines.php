<!DOCTYPE html>
<html>
    <head>
    <title>08. Sort Lines</title>
    </head>
    <body>
    <?php $sortedLines = "";
      if(isset($_GET['lines'])){
          $lines = explode("\n", $_GET['lines']);
          $lines = array_map('trim',$lines);
          sort($lines,SORT_STRING);
          $sortedLines = implode("\n",$lines);
      }
    ?>
    <form>
    <textarea name="lines" cols="25" rows="16"> <?= $sortedLines ?></textarea></br>
        <input type="submit" value="Sort">
    </form>
    </body>
</html>