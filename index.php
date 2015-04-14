<?php
include_once("./scripts/functions.php");
include_once("./settings.php");

include_once("./theme/header.php");

foreach($settings["pages"] AS $pagename){
	echo '<a name="'.$pagename["filename"].'"></a>';
	include_once("./content/".$pagename["filename"].".php");
	echo "\n\r";
}

include_once("./theme/footer.php");

?>