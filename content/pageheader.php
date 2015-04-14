    <!-- Header -->
	<section class="content-section video-section">
	  <div class="pattern-overlay">
	  <a id="bgndVideo" class="player" data-property="{videoURL:'http://youtu.be/oG0BTWE2OyM',containment:'.video-section', quality:'large', autoPlay:true, mute:true, opacity:1}">bg</a>
		<div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="intro-message">
                        <h1><?php echo $settings["pagetitle"] ?></h1>
                        <h3><?php echo $settings["pagesubtitle"] ?></h3>
                        <hr class="intro-divider">
                        <ul class="list-inline intro-social-buttons">
							<?php 
								foreach($settings["socialmedia"] AS $network){
									echo '<a href="'.$network["url"].'" target="_blank" class="btn btn-default btn-lg">';
										echo '<i class="'.$network["icon"].'"></i>';
										echo '<span class="network-name">'.$network["name"].'</span>';
									echo '</a>';
									echo "\n\r";
								}
							?>
                        </ul>
                    </div>
                </div>
            </div>
		</div>
	  </div>
	</section>
	<!--Video Section Ends Here-->
	<script type="text/javascript">
	$( document ).ready(function() {

		$(".player").mb_YTPlayer();

	});
	</script>
	<!-- /.intro-header -->