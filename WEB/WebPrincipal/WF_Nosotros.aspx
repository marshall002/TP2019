﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_Nosotros.aspx.cs" Inherits="WebPrincipal_WF_Nosotros" %>

<!DOCTYPE html>

<html lang="en">
<head>
<meta charset="utf-8">
<title>La Parada - Crossfit</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<meta name="description" content="" />
<meta name="author" content="http://webthemez.com" />

<link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
<link rel="stylesheet" href="../materialize/css/materialize.min.css" media="screen,projection" />
<link href="../css/StilosPW/bootstrap.min.css" rel="stylesheet" />
<link href="../css/StilosPW/fancybox/jquery.fancybox.css" rel="stylesheet"> 
<link href="../css/StilosPW/flexslider.css" rel="stylesheet" /> 
<link href="../css/StilosPW/style.css" rel="stylesheet" />
</head>

<body>
<div id="wrapper"> 
	<!-- start header -->
	<header>
        <div class="navbar navbar-default navbar-static-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="WF_Pagina_Principal.aspx"><img src="../img/Logo2.png"/>La Parada - Crossfit</a>
                </div>
                <div class="navbar-collapse collapse ">
                    <ul class="nav navbar-nav">
                        <li><a class="waves-effect waves-dark" href="WF_Pagina_Principal.aspx">Inicio</a></li> 
                        <li class="active"><a href="WF_Nosotros.aspx" class="waves-effect waves-dark">Nosotros</a></li>
						<li><a href="WF_Servicios.aspx" class="waves-effect waves-dark">Planes</a></li>           
                        <li><a class="waves-effect waves-dark" href="WF_Horarios.aspx">Horario</a></li>                      
                        <li><a class="waves-effect waves-dark" href="WF_Iniciar_Sesion.aspx">Iniciar Sesion</a></li>
                    </ul>
                </div>
            </div>
        </div>
	</header>
	<!-- end header -->
<section id="inner-headline">
	<div class="container">
		<div class="row">
			<div class="col-lg-12">
				<h2 class="pageTitle">Nosotros</h2>
			</div>
		</div>
	</div>
	</section>
	<section id="content">
	<section class="section-padding">
		<div class="container">
			<div class="row showcase-section">
				<div class="col-md-6">
					<img src="../img/dev1.png" alt="showcase image">
				</div>
				<div class="col-md-6">
					<div class="about-text">
						<h3>Nuestra <span class="color">Compañía</span></h3>
						<p style="text-align: justify">El Crossfit es un método de acondicionamiento físico. Está basado en ejercicios constantemente variados, con movimientos funcionales, ejecutados a alta intensidad. A diferencia de los gimnasios, donde solo vas trabajar la fuerza, en el crossfit se trabaja la fuerza, flexibilidad, potencia y dinámica.</p>
						 <p style="text-align: justify">El ser humano está diseñado para trabajar muchas cosas más que las que se suelen hacer en un gimnasio tradicional. Los gimnasio usan máquinas, Crossfit La Parada las construye.</p>
					</div>
				</div>
			</div>
		</div>
	</section>
	<div class="container">
					
					<div class="about">
				
						
						<div class="row">
							<div class="col-md-4">
								<!-- Heading and para -->
								<div class="block-heading-two">
									<h3><span>Why Choose Us?</span></h3>
								</div>
								<p>Sed ut perspiciaatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur. <br/><br/>Sed ut perspiciaatis iste natus error sit voluptatem probably haven't heard of them accusamus.</p>
							</div>
							<div class="col-md-4">
								<div class="block-heading-two">
									<h3><span>Our Solution</span></h3>
								</div>		
								<!-- Accordion starts -->
								<div class="panel-group" id="accordion-alt3">
								 <!-- Panel. Use "panel-XXX" class for different colors. Replace "XXX" with color. -->
								  <div class="panel">	
									<!-- Panel heading -->
									 <div class="panel-heading">
										<h4 class="panel-title">
										  <a data-toggle="collapse" data-parent="#accordion-alt3" href="#collapseOne-alt3">
											<i class="fa fa-angle-right"></i> Accordion Heading Text Item # 1
										  </a>
										</h4>
									 </div>
									 <div id="collapseOne-alt3" class="panel-collapse collapse">
										<!-- Panel body -->
										<div class="panel-body">
										  Sed ut perspiciaatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas
										</div>
									 </div>
								  </div>
								  <div class="panel">
									 <div class="panel-heading">
										<h4 class="panel-title">
										  <a data-toggle="collapse" data-parent="#accordion-alt3" href="#collapseTwo-alt3">
											<i class="fa fa-angle-right"></i> Accordion Heading Text Item # 2
										  </a>
										</h4>
									 </div>
									 <div id="collapseTwo-alt3" class="panel-collapse collapse">
										<div class="panel-body">
										  Sed ut perspiciaatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas
										</div>
									 </div>
								  </div>
								  <div class="panel">
									 <div class="panel-heading">
										<h4 class="panel-title">
										  <a data-toggle="collapse" data-parent="#accordion-alt3" href="#collapseThree-alt3">
											<i class="fa fa-angle-right"></i> Accordion Heading Text Item # 3
										  </a>
										</h4>
									 </div>
									 <div id="collapseThree-alt3" class="panel-collapse collapse">
										<div class="panel-body">
										  Sed ut perspiciaatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas
										</div>
									 </div>
								  </div>
								  <div class="panel">
									 <div class="panel-heading">
										<h4 class="panel-title">
										  <a data-toggle="collapse" data-parent="#accordion-alt3" href="#collapseFour-alt3">
											<i class="fa fa-angle-right"></i> Accordion Heading Text Item # 4
										  </a>
										</h4>
									 </div>
									 <div id="collapseFour-alt3" class="panel-collapse collapse">
										<div class="panel-body">
										  Sed ut perspiciaatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas
										</div>
									 </div>
								  </div>
								</div>
								<!-- Accordion ends -->
								
							</div>
							
							<div class="col-md-4">
								<div class="block-heading-two">
									<h3><span>Our Expertise</span></h3>
								</div>								
								<h6>Web Development</h6>
								<div class="progress pb-sm">
								  <!-- White color (progress-bar-white) -->
								  <div class="progress-bar progress-bar-red" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
									 <span class="sr-only">40% Complete (success)</span>
								  </div>
								</div>
								<h6>Designing</h6>
								<div class="progress pb-sm">
								  <div class="progress-bar progress-bar-green" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%">
									 <span class="sr-only">40% Complete (success)</span>
								  </div>
								</div>
								<h6>User Experience</h6>
								<div class="progress pb-sm">
								  <div class="progress-bar progress-bar-lblue" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">
									 <span class="sr-only">40% Complete (success)</span>
								  </div>
								</div>
								<h6>Development</h6>
								<div class="progress pb-sm">
								  <div class="progress-bar progress-bar-yellow" role="progressbar" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100" style="width: 30%">
									 <span class="sr-only">40% Complete (success)</span>
								  </div>
								</div>
							</div>
							
						</div>
						
						 		
<div class="about home-about">
<div class="container">

<div class="row">
	<div class="col-md-4"> 
	<div class="block-heading-two">
			<h3><span>Features</span></h3>
		</div>	
	<div class="tab-section">
		<div class="s12">
		<ul class="tabs">
		<li class="tab col s4"><a href="#test1" class="waves-effect waves-dark">Test 1</a></li>
		<li class="tab col s4"><a class="waves-effect waves-dark active" href="#test2">Test 2</a></li>
		<li class="tab col s4"><a href="#test3" class="waves-effect waves-dark">Test 3</a></li> 
		</ul>
		</div>
		<div id="test1" class="col s12 container">Ande omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur. </div>
		<div id="test2" class="col s12 container">Terspiciaatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur. </div>
		<div id="test3" class="col s12 container">Perspiciaatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur. </div> 
		</div>
	</div>
	<div class="col-md-4">
		<div class="block-heading-two">
			<h3><span>Latest News</span></h3>
		</div>		
		<!-- Accordion starts -->
	  <ul class="collapsible" id="accordionSection" data-collapsible="accordion">
		<li>
		  <div class="collapsible-header active"><i class="material-icons">filter_drama</i>First</div>
		  <div class="collapsible-body"><p>Perspiciaatis unde omnis iste natus error Nemo enim ipsam voluptatem quia voluptas sit aspernatur. sit voluptatem accusanti</p></div>
		</li>
		<li>
		  <div class="collapsible-header"><i class="material-icons">place</i>Second</div>
		  <div class="collapsible-body"><p>Nemo enim ipsam voluptatem quia voluptas sit aspernatur. Perspiciaatis unde omnis iste natus error sit voluptatem accusanti</p></div>
		</li>
		<li>
		  <div class="collapsible-header"><i class="material-icons">whatshot</i>Third</div>
		  <div class="collapsible-body"><p>Perspiciaatis Nemo enim ipsam voluptatem quia voluptas sit aspernatur. unde omnis iste natus error sit voluptatem accusanti</p></div>
		</li>
	  </ul>
								 <!-- Accordion ends -->
		
	</div>
	
	<div class="col-md-4">
		<div class="block-heading-two">
			<h3><span>Testimonials</span></h3>
		</div>	
			 <div class="testimonials">
				<div class="active item">
				  <blockquote><p>Lorem ipsum dolor met consectetur adipisicing. Aorem psum dolor met consectetur adipisicing sit amet, consectetur adipisicing elit, of them jean shorts sed magna aliqua. Lorem ipsum dolor met.</p></blockquote>
				  <div class="carousel-info">
					<img alt="" src="../img/team4.jpg" class="pull-left">
					<div class="pull-left">
					  <span class="testimonials-name">Marc Cooper</span>
					  <span class="testimonials-post">Technical Director</span>
					</div>
				  </div>
				</div>
			</div>
	</div>
	
</div>
						
<br> 
</div> 
</div>
						
						 
						<br>
						<!-- Our Team starts -->
				
						<!-- Heading -->
						<div class="block-heading-six">
							<h4 class="bg-color">Our Team</h4>
						</div>
						<br>
						
						<!-- Our team starts -->
						
						<div class="team-six">
							<div class="row">
								<div class="col-md-3 col-sm-6">
									<!-- Team Member -->
									<div class="team-member">
										<!-- Image -->
										<img class="img-responsive" src="../img/team1.jpg" alt="">
										<!-- Name -->
										<h4>Johne Doe</h4>
										<span class="deg">Master</span> 
									</div>
								</div>
								<div class="col-md-3 col-sm-6">
									<!-- Team Member -->
									<div class="team-member">
										<!-- Image -->
										<img class="img-responsive" src="../img/team2.jpg" alt="">
										<!-- Name -->
										<h4>Jennifer</h4>
										<span class="deg">Master</span> 
									</div>
								</div>
								<div class="col-md-3 col-sm-6">
									<!-- Team Member -->
									<div class="team-member">
										<!-- Image -->
										<img class="img-responsive" src="../img/team3.jpg" alt="">
										<!-- Name -->
										<h4>Christean</h4>
										<span class="deg">Master</span> 
									</div>
								</div>
								<div class="col-md-3 col-sm-6">
									<!-- Team Member -->
									<div class="team-member">
										<!-- Image -->
										<img class="img-responsive" src="../img/team4.jpg" alt="">
										<!-- Name -->
										<h4>Kerinele rase</h4>
										<span class="deg">Master</span> 
									</div>
								</div>
							</div>
						</div>
						
						<!-- Our team ends -->
					  
						
					</div>
									
				</div>
	</section>
<footer>
	<div class="container">
		<div class="row">
			<div class="col-sm-3">
				<div class="widget">
					<h5 class="widgetheading">Contáctanos</h5>
					<address>
					<strong>La Parada Crossfir - Perú</strong><br>
					Avenida Ernesto Diez Canseco 220<br>
					Miraflores - Lima.</address>
					<p>
						<i class="icon-phone"></i> 01 - 512-5632 <br>
						<i class="icon-envelope-alt"></i> info@crossfitlaparada.pe
					</p>
				</div>
			</div>
			<div class="col-sm-3">
				<div class="widget">
					<h5 class="widgetheading">Quick Links</h5>
					<ul class="link-list">
						<li><a class="waves-effect waves-dark" href="#">Eventos</a></li>
						<li><a class="waves-effect waves-dark" href="#">Terminos y Condiciones</a></li>
						<li><a class="waves-effect waves-dark" href="#">Politica de la empresa</a></li>
						<li><a class="waves-effect waves-dark" href="#">Carrera</a></li>
						<li><a class="waves-effect waves-dark" href="#">Contactanos</a></li>
					</ul>
				</div>
			</div>
			<div class="col-sm-3">
				<div class="widget">
					<h5 class="widgetheading">Ultimos Post</h5>
					<ul class="link-list">
						<li><a class="waves-effect waves-dark" href="#">Nuevos horarios.</a></li>
						<li><a class="waves-effect waves-dark" href="#">Inscribite</a></li>
						<li><a class="waves-effect waves-dark" href="#">Planes Nuevos</a></li>
					</ul>
				</div>
			</div>
			<div class="col-sm-3">
				<div class="widget">
					<h5 class="widgetheading">Noticias Recientes</h5>
					<ul class="link-list">
						<li><a class="waves-effect waves-dark" href="#">Nuevos equipos de gimnasio.</a></li>
						<li><a class="waves-effect waves-dark" href="#">Muy pronto un evento para toda la comunidad crossfit.</a></li>
						<li><a class="waves-effect waves-dark" href="#">Tenemos descuentos de ropa de gimnasio de nuestra marca.</a></li>
					</ul>
				</div>
			</div>
		</div>
	</div>
	<div id="sub-footer">
		<div class="container">
			<div class="row">
				<div class="col-lg-6">
					<div class="copyright">
						<p>
							<span>&copy; Fitness 2018. </span> 
						</p>
					</div>
				</div>
				<div class="col-lg-6">
					<ul class="social-network">
						<li><a class="waves-effect waves-dark" href="https://web.facebook.com/laparadafitnessclub/" data-placement="top" title="Facebook"><i class="fa fa-facebook"></i></a></li>
						<li><a class="waves-effect waves-dark" href="#" data-placement="top" title="Twitter"><i class="fa fa-twitter"></i></a></li>
						<li><a class="waves-effect waves-dark" href="#" data-placement="top" title="Linkedin"><i class="fa fa-linkedin"></i></a></li>
						<li><a class="waves-effect waves-dark" href="#" data-placement="top" title="Pinterest"><i class="fa fa-pinterest"></i></a></li>
						<li><a class="waves-effect waves-dark" href="#" data-placement="top" title="Google plus"><i class="fa fa-google-plus"></i></a></li>
					</ul>
				</div>
			</div>
		</div>
	</div>
	</footer>
</div>
<a href="#" class="scrollup waves-effect waves-dark"><i class="fa fa-angle-up active"></i></a>
<!-- javascript
    ================================================== -->
<!-- Placed at the end of the document so the pages load faster -->
<script src="../js/jquery.js"></script>
<script src="../js/jquery.easing.1.3.js"></script>
<script src="../materialize/js/materialize.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/jquery.fancybox.pack.js"></script>
<script src="../js/jquery.fancybox-media.js"></script>  
<script src="../js/jquery.flexslider.js"></script>
<script src="../js/animate.js"></script>
<!-- Vendor Scripts -->
<script src="../js/modernizr.custom.js"></script>
<script src="../js/jquery.isotope.min.js"></script>
<script src="../js/jquery.magnific-popup.min.js"></script>
<script src="../js/animate.js"></script> 
<script src="../js/custom.js"></script>
</body>
</html>