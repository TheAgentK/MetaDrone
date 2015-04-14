    <div class="content-section-a">

        <div class="container">
            <div class="row">
                <div class="col-lg-5 col-sm-6">
					<div class="spacer"></div>
					<div class="spacer"></div>
					<img class="img-responsive" src="img/controle_02.jpg" alt="Meta 1">
					
                </div>
                <div class="col-lg-5 col-lg-offset-2 col-sm-6">

                    <hr class="section-heading-spacer">
                    <div class="clearfix"></div>
                    <h2 class="section-heading">Getting Started</h2>
                    <p class="lead short">
						<strong>Was du brauchst:</strong>
					</p>
						<ul>
							<li><?php echo createLink("Parrot AR.Drone 2.0", "http://ardrone2.parrot.com/"); ?></li>
							<li><?php echo createLink("META 1 (Spaceglasses)", "https://www.getameta.com/"); ?></li>
							<li><?php echo createLink("Node.js", "https://nodejs.org/"); ?></li>
							<li>einen Computer</li>
						</ul>
					
                    <p class="lead short">
						<strong>Was du tun musst:</strong>
					</p>
						<ol>
							<li>
								Projekt von <?php echo createLink($settings["socialmedia"]["github"]["name"], $settings["socialmedia"]["github"]["url"]); ?> herrunterladen
							</li>
							<li>
								<?php echo createLink("Parrot AR.Drone 2.0", "http://ardrone2.parrot.com/"); ?>
								mit dem PC verbinden
							</li>
							<li>
								<?php echo createLink("META 1", "https://www.getameta.com/"); ?>
								mit dem PC verbinden
							</li>
							<li>
								evtl. die 
								<?php echo createLink("META 1", "https://www.getameta.com/"); ?>
								kalibrieren
							</li>
							<li>
								Node.js-Script "wws/main.js" in einer Console ausführen <code>node main.js</code>
							</li>
							<li>
								"/game/game.exe" ausführen
							</li>
							<li>
								Flug genießen!!!
							</li>
						<ol>
					<p class="lead">
					</p>
                </div>
            </div>
        </div>
        <!-- /.container -->

    </div>
    <!-- /.content-section-b -->