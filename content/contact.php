    <div class="banner">

        <div class="container">

            <div class="row">
                <div class="col-lg-6">
                    <h2>Connect to <?php echo $settings["pagetitle"] ?>:</h2>
                </div>
                <div class="col-lg-6">
                    <ul class="list-inline banner-social-buttons">
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
        <!-- /.container -->

    </div>
    <!-- /.banner -->