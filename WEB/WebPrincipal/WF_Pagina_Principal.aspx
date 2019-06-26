<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_Pagina_Principal.aspx.cs" Inherits="WebPrincipal_WF_Pagina_Principal1" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <title>La Parada - Crossfit</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="http://webthemez.com" />

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <%--<link rel="stylesheet" href="../materialize/css/materialize.min.css" media="screen,projection" />--%>
    <link href="../css/StilosPW/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/StilosPW/fancybox/jquery.fancybox.css" rel="stylesheet">
    <link href="../css/StilosPW/flexslider.css" rel="stylesheet" />
    <link href="../css/StilosPW/style.css" rel="stylesheet" />
</head>

<body>
    <div id="wrapper" class="home-page">
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
                        <a class="navbar-brand" href="WF_Pagina_Principal.aspx">
                            <img src="../img/Logo2.png" />La Parada - Crossfit</a>
                    </div>
                    <div class="navbar-collapse collapse ">
                        <ul class="nav navbar-nav">
                            <li class="active"><a class="waves-effect waves-dark" href="WF_Pagina_Principal.aspx">Inicio</a></li>
                            <li><a href="WF_Nosotros.aspx" class="waves-effect waves-dark">Nosotros</a></li>
                            <li><a href="WF_Servicios.aspx" class="waves-effect waves-dark">Planes</a></li>
                            <li><a class="waves-effect waves-dark" href="WF_Horarios.aspx">Horario</a></li>
                            <li><a class="waves-effect waves-dark" href="WF_Iniciar_Sesion.aspx">Iniciar Sesion</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </header>
        <!-- end header -->
            <!-- Slider -->
            <div class="body">
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <div class="item active">
                            <img src="../img/slides/Crossfit1.1.jpg" />
                        </div>
                        <div class="item">
                            <img src="../img/slides/Crossfit2.1.jpg" />
                        </div>
                       
                    </div>

                    <!-- Controls -->
                    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
    </div>
    <!-- end slider -->
		<section class="dishes">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="aligncenter">
                            <h2 class="aligncenter">Nuestros Servicios</h2>
                            Tenemos esta variedad de servicios disponibles para ti cuando formes parte de esta gran comunidad.</div>
                        <br />
                    </div>
                </div>

                <div class="row service-v1 margin-bottom-40">
                    <div class="col-md-4 md-margin-bottom-40">
                        <div class="card small">
                            <div class="card-image">
                                <img class="img-responsive" src="../img/service1.jpg" alt="">
                                <span class="card-title">Funtional</span>
                            </div>
                            <div class="card-content">
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores quae porro consequatur aliquam, incidunt
                                </p>
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores quae porro consequatur aliquam, incidunt
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 md-margin-bottom-40">
                        <div class="card small">
                            <div class="card-image">
                                <img class="img-responsive" src="../img/service2.jpg" alt="">
                                <span class="card-title">Crossfit</span>
                            </div>
                            <div class="card-content">
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores quae porro consequatur aliquam, incidunt
                                </p>
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores quae porro consequatur aliquam, incidunt
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 md-margin-bottom-40">
                        <div class="card small">
                            <div class="card-image">
                                <img class="img-responsive" src="../img/service3.jpg" alt="">
                                <span class="card-title">Nutricionista</span>
                            </div>
                            <div class="card-content">
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores quae porro consequatur aliquam, incidunt
                                </p>
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores quae porro consequatur aliquam, incidunt
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 md-margin-bottom-40">
                        <div class="card small">
                            <div class="card-image">
                                <img class="img-responsive" src="../img/Fisio1.jpg" alt="">
                                <span class="card-title">Fisioterapia</span>
                            </div>
                            <div class="card-content">
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores quae porro consequatur aliquam, incidunt
                                </p>
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores quae porro consequatur aliquam, incidunt
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 md-margin-bottom-40">
                        <div class="card small">
                            <div class="card-image">
                                <img class="img-responsive" src="../img/Suple1.jpg" alt="">
                                <span class="card-title">Venta suplementos y más</span>
                            </div>
                            <div class="card-content">
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores quae porro consequatur aliquam, incidunt
                                </p>
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores quae porro consequatur aliquam, incidunt
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

    <section class="section-padding gray-bg">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="section-title text-center">
                        <h2>Nuestro espacio de entrenamiento</h2>
                        <p>Nuestro local posee una cantidad de espacio adecuada para realizar diferentes tipos de ejercicios.</p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-sm-6">
                    <div class="about-text">
                        <p>Grids is a responsive Multipurpose Template. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur aliquet quam id dui posuere blandit. Donec sollicitudin molestie malesuada. Pellentesque in ipsum id orci porta dapibus. Vivamus suscipit tortor eget felis porttitor volutpat.</p>

                        <ul class="withArrow">
                            <li><span class="fa fa-angle-right"></span>Lorem ipsum dolor sit amet</li>
                            <li><span class="fa fa-angle-right"></span>consectetur adipiscing elit</li>
                            <li><span class="fa fa-angle-right"></span>Curabitur aliquet quam id dui</li>
                            <li><span class="fa fa-angle-right"></span>Donec sollicitudin molestie malesuada.</li>
                        </ul>
                        <a href="#" class="btn btn-primary waves-effect waves-dark">Learn More</a>
                    </div>
                </div>
                <div class="col-md-6 col-sm-6">
                    <div class="about-image">
                        <img src="../img/Lugar1.jpg" alt="About Images">
                    </div>
                </div>
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
                            Miraflores - Lima.
                        </address>
                        <p>
                            <i class="icon-phone"></i>01 - 512-5632
                            <br>
                            <i class="icon-envelope-alt"></i>info@crossfitlaparada.pe
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
    <%--<script src="../js/animate.js"></script>--%>
    <!-- Vendor Scripts -->
<script src="../js/modernizr.custom.js"></script>
<script src="../js/jquery.isotope.min.js"></script>
<script src="../js/jquery.magnific-popup.min.js"></script>
<script src="../js/animate.js"></script> 
<script src="../js/custom.js"></script>
        <script src="../../plugins/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core Js -->
    <script src="../../plugins/bootstrap/js/bootstrap.js"></script>

    <!-- Select Plugin Js -->
    <script src="../../plugins/bootstrap-select/js/bootstrap-select.js"></script>

    <!-- Slimscroll Plugin Js -->
    <script src="../../plugins/jquery-slimscroll/jquery.slimscroll.js"></script>

    <!-- Waves Effect Plugin Js -->
    <script src="../../plugins/node-waves/waves.js"></script>

    <!-- Custom Js -->
    <script src="../../js/admin.js"></script>

    <!-- Demo Js -->
    <script src="../../js/demo.js"></script>
</body>
</html>

