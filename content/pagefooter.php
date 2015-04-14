    <!-- Footer -->
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <ul class="list-inline">
						<?php
						$lastItemIndex = 0;
						foreach($settings["pages"] AS $pagename){
							if($pagename["inFooter"]) {
								$lastItemIndex++;
							}
						}
						$currentIndex = 0;
						foreach($settings["pages"] AS $pagename){
							if($pagename["inFooter"]) {
								$currentIndex++;
								echo '<li>';
									echo '<a href="#'.$pagename["filename"].'">'.$pagename["title"].'</a>';
								echo '</li>';
								if ($lastItemIndex > $currentIndex){
									echo '<li class="footer-menu-divider">&sdot;</li>';
								}
							}
						}
						?>
                    </ul>
				</div>
            </div>
            <div class="row copyright">
                <div class="col-lg-6">
                    <p class="text-muted small">Copyright &copy; Karsten Siedentopp 2014. All Rights Reserved</p>
                </div>
				<div class="col-lg-6 text-right">
					<p class="text-muted small">Projektarbeit 2015 an der Fachhoschule Stralsund</p>
				</div>
            </div>
        </div>
    </footer>