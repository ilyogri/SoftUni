<!DOCTYPE html>
<html>
    <head><title>CelsiusAndFahrenheitConvertion</title>
    </head>
    <body>
        <?php
        function celsiusToFahrenheit( $celsius)
        {
            return $celsius * 1.8 + 32;
        }
        function fahrenheitToCelsius( $fahrenheit)
        {
            return ($fahrenheit - 32) / 1.8;
        }
        $msgAfterCelsius = "";
        if (isset($_GET['cel'])) {
            $cel = floatval($_GET['cel']);
            $fah = celsiusToFahrenheit($cel);
            $msgAfterCelsius = "$cel &deg;C = $fah &deg;F";
        }
        $msgAfterFahrenheit = "";
        if (isset($_GET['fah'])) {
            $fah = floatval($_GET['fah']);
            $cel = fahrenheitToCelsius($fah);
            $msgAfterFahrenheit = "$fah &deg;F = $cel &deg;C";
        }
        ?>
        <form>
            Celsius: <input type="text" name="cel" />
            <input type="submit" value="Convert">
            <?= $msgAfterCelsius ?>
        </form>
        <form>
            Fahrenheit: <input type="text" name="fah" />
            <input type="submit" value="Convert">
            <?= $msgAfterFahrenheit ?>
        </form>
    </body>
</html>