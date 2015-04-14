<?php 

function createLink($_content, $_link){
	return '<a href="'.$_link.'" target="_blank">'.$_content.'</a>';
}
function createLinkImage($_imgurl, $_link, $_alt=""){
	$content = '<img class="img-responsive" src="'.$_imgurl.'" alt="'.$_alt.'">';
	return createLink($content, $_link);
}

?>