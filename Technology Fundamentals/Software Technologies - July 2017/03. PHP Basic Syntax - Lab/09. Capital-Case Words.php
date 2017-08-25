<!DOCTYPE html>
<html>
<head>
    <title>Capital-Case Words</title>
</head>
<body>
<?php
$matches = array();
$wordsPattern = '/[A-Za-z]+/';
$text = $_GET['text'];
preg_match_all("/\b[A-Z]+\b/", $text, $matches);
?>

<form>
    <textarea name="text" rows="20" cols="20"><?= implode(", ", $matches[0]); ?></textarea><br/>
    <input type="submit" value="Convert">
</form>
</body>
</html>