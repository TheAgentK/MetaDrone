<?php
$settings["pagetitle"] = "nexGEN META-DRONE";
$settings["pagesubtitle"] = "Drone Control your way!";

$settings["socialmedia"]["github"]["name"] = "GitHub";
$settings["socialmedia"]["github"]["url"] = "https://github.com/TheAgentK/MetaDrone";
$settings["socialmedia"]["github"]["icon"] = "fa fa-github fa-fw";

$settings["pages"] = array(
    0 => array(
		"inMenu" => false,
		"inFooter" => false,
		"title" => "navigation",
		"filename" => "navigation"),
    1 => array(
		"inMenu" => false,
		"inFooter" => true,
		"title" => "Home",
		"filename" => "pageheader"),
    2 => array(
		"inMenu" => true,
		"inFooter" => true,
		"title" => "Das Projekt",
		"filename" => "theproject"),
    3 => array(
		"inMenu" => true,
		"inFooter" => true,
		"title" => "Getting Started",
		"filename" => "gettingstarted"),
	4 => array(
		"inMenu" => false,
		"inFooter" => false,
		"title" => "Built with",
		"filename" => "builtwith"),
	5 => array(
		"inMenu" => true,
		"inFooter" => true,
		"title" => "In Aktion",
		"filename" => "inaction"),
	6 => array(
		"inMenu" => true,
		"inFooter" => true,
		"title" => "Steuerung",
		"filename" => "control"),
    7 => array(
		"inMenu" => true,
		"inFooter" => true,
		"title" => "Über mich",
		"filename" => "aboutme"),
    99 => array(
		"inMenu" => true,
		"inFooter" => true,
		"title" => "Kontakt",
		"filename" => "contact"),
    100 => array(
		"inMenu" => false,
		"inFooter" => false,
		"title" => "pagefooter",
		"filename" => "pagefooter"),
);

?>