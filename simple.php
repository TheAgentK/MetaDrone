<?php
$homepage = file_get_contents('http://meta-drone.siedentopp.eu/simple.txt');
$homepage = utf8_decode($homepage);
file_put_contents("./simple.html", $homepage);
echo $homepage;
?>