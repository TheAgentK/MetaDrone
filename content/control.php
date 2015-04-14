  <div class="content-section-b">
        <div class="container">
            <div class="row">
                <div class="col-lg-4 col-sm-6">
                    <hr class="section-heading-spacer">
                    <div class="clearfix"></div>
                    <h2 class="section-heading">Steuerung</h2>
					<p class="lead">
					Die Meta 1 ist eine Augmented Reality (AR) Brille, durch die dem Träger eine noch natürlichere Steuerung des Quadrocopters Parrot Ar.Drone 2.0 ermöglicht wird.
					</p>
					<p class="lead">
						Rechte Hand:
					</p>
					<ul>
						<li><a href="gesten_rechts_oben" class="gesten" >Hoch</a></li>
						<li><a href="gesten_rechts_unten" class="gesten">Runter</a></li>
						<li><a href="gesten_rechts_rechts" class="gesten">Rotation CW (rechts)</a></li>
						<li><a href="gesten_rechts_links" class="gesten">Rotation CCW (links)</a></li>
					</ul>
					<p class="lead">
						Linke Hand:
					</p>
					<ul>
						<li><a href="gesten_links_vor" class="gesten">Vor</a></li>
						<li><a href="gesten_links_zureuck" class="gesten">Zurück</a></li>
					</ul>
					<script type="text/javascript">
					$('a.gesten').click(function(event){
						event.preventDefault();
					});
					$('a.gesten').hover(function(event){
						var img = "#" + $( this ).attr("href");
						$("#gesten").addClass("hide");
						$(img).removeClass("hide");
					}, function() {
						var img = "#" + $( this ).attr("href");
						$("#gesten").removeClass("hide");
						$(img).addClass("hide");
					}
					
					);
					</script>
                </div>
                <div class="col-lg-8 col-sm-6">
                    <img src="img/gesten/gesten.png" class="gesten img-responsive" alt="Responsive image" id="gesten">
                    <img src="img/gesten/gesten_links_vor.png" class="gesten img-responsive hide" alt="Responsive image" id="gesten_links_vor">
                    <img src="img/gesten/gesten_links_zureuck.png" class="gesten img-responsive hide" alt="Responsive image" id="gesten_links_zureuck">
                    <img src="img/gesten/gesten_rechts_oben.png" class="gesten img-responsive hide" alt="Responsive image" id="gesten_rechts_oben">
                    <img src="img/gesten/gesten_rechts_unten.png" class="gesten img-responsive hide" alt="Responsive image" id="gesten_rechts_unten">
                    <img src="img/gesten/gesten_rechts_links.png" class="gesten img-responsive hide" alt="Responsive image" id="gesten_rechts_links">
                    <img src="img/gesten/gesten_rechts_rechts.png" class="gesten img-responsive hide" alt="Responsive image" id="gesten_rechts_rechts">
                </div>
            </div>


        </div>
        <!-- /.container -->

    </div>
    <!-- /.content-section-a -->