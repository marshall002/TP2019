<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_Horarios.aspx.cs" Inherits="WebPrincipal_WF_Horarios" %>

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
                        <li><a href="WF_Nosotros.aspx" class="waves-effect waves-dark">Nosotros</a></li>
						<li><a href="WF_Servicios.aspx" class="waves-effect waves-dark">Planes</a></li>           
                        <li class="active"><a class="waves-effect waves-dark" href="WF_Horarios.aspx">Horario</a></li>                      
                        <li><a class="waves-effect waves-dark" href="WF_Iniciar_Sesion.aspx">Iniciar Sesion</a></li>
                    </ul>
                </div>
            </div>
        </div>
	</header>   
	<!-- end header -->
    <form id="form1" runat="server">
	<section id="inner-headline">
	<div class="container">
	
		<div class="row">
			<div class="col-lg-12">
				<h2 class="pageTitle">Horarios</h2>
			</div>
		</div>
	</div>
	</section>
	<section id="content">
       <section id="pricing">
        <div class="container">
           <div class="row"> 
							<div class="col-md-12">
								<div class="about-logo">
									<h3>Nuestros <span class="color">Horarios</span></h3>
									<p>Cada dia armamos nuevos horarios de acuerdo a la disponibilidad de nuestros entrenadores</p>
                                    <p>Tenemos variedades de ejercicios para Funtional y Crossfit</p>
                                    	
								</div>  
							</div>
						</div>
                            <div class="body">
                            <div id="aniimated-thumbnials" class="list-unstyled row clearfix">
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioCrossfit1.1.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioCrossfit1.1.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioCrossfit2.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioCrossfit2.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioCrossfit3.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioCrossfit3.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioCrossfit4.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioCrossfit4.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioCrossfit5.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioCrossfit5.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioCrossfit6.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioCrossfit6.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioCrossfit7.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioCrossfit7.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioCrossfit8.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioCrossfit8.jpg">
                                    </a>
                                </div>
                             <%--   <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioCrossfit9.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioCrossfit9.jpg">
                                    </a>
                                </div>--%>
                               <%-- <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioCrossfit10.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioCrossfit10.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioFuntional1.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioFuntional1.jpg">
                                    </a>
                                </div>--%>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioFuntional2.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioFuntional2.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioFuntional3.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioFuntional3.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioFuntional4.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioFuntional4.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioFuntional5.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioFuntional5.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioFuntional6.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioFuntional6.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioFuntional7.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioFuntional7.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioFuntional8.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioFuntional8.jpg">
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioFuntional9.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioFuntional9.jpg">
                                    </a>
                                </div>
                               <%-- <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <a href="../img/HorarioFuntional10.jpg" data-sub-html="Demo Description">
                                        <img class="img-responsive thumbnail" src="../img/HorarioFuntional10.jpg">
                                    </a>
                                </div>--%>
                            </div>
                        </div>
        </div>
    </section>
	</section>
        </form>
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
