<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_Registrar_Socio.aspx.cs" Inherits="WebPrincipal_WF_Registrar_Socio" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <title>La Parada - Crossfit</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="http://webthemez.com" />

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="../materialize/css/materialize.min.css" media="screen,projection" />
    <link href="../css/StilosPW/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/StilosPW/style.css" rel="stylesheet" />
</head>

<body>
    <script type="text/javascript">
        function SoloNumeros(e) {
            var key_press = document.all ? key_press = e.keyCode : key_press = e.which;
            return ((key_press > 47 && key_press < 58) || key_press == 46);
        }

        function SoloLetras() {
            if ((event.keyCode >= 65) && (event.keyCode <= 90) || (event.keyCode >= 97) && (event.keyCode <= 122)) {
                event.returnValue = true;
            }
            else {
                event.returnValue = false;
            }

        }
    </script>
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
                        <a class="navbar-brand" href="WF_Pagina_Principal.aspx">
                            <img src="../img/Logo2.png" />La Parada - Crossfit</a>
                    </div>
                    <div class="navbar-collapse collapse ">
                        <ul class="nav navbar-nav">
                            <li><a class="waves-effect waves-dark" href="WF_Pagina_Principal.aspx">Inicio</a></li>
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
        <form id="form1" runat="server">
            <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
            <section id="content">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="about-logo">
                                <h3>Registrar<span class="color"> Socio</span></h3>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            
                            <div class="input-field">
                                <asp:TextBox ID="txtDni" runat="server" class="form-control white-text" name="name"></asp:TextBox>
                                <label for="name" class="" style="color: white">DNI</label>
                            </div>
                            <div class="input-field">
                                <asp:TextBox ID="txtnombre" runat="server" class="form-control white-text" onkeypress="SoloLetras()" name="name"></asp:TextBox>
                                <label for="name" class="" style="color: white">Nombre</label>
                            </div>
                            <div class="input-field">
                                <asp:TextBox ID="txtapellidopaterno" runat="server" class="form-control white-text" onkeypress="SoloLetras()" name="name"></asp:TextBox>
                                <label for="name" class="" style="color: white">Apellido Paterno</label>
                            </div>
                            <div class="input-field">
                                <asp:TextBox ID="txtapellidomaterno" runat="server" class="form-control white-text" onkeypress="SoloLetras()" name="name"></asp:TextBox>
                                <label for="name" class="" style="color: white">Apellido Materno</label>
                            </div>
                            <div class="input-field">
                                <asp:TextBox ID="txtcorreo" runat="server" class="form-control white-text" name="name"></asp:TextBox>
                                <label for="name" class="" style="color: white">Correo</label>
                            </div>
                            <div class="input-field">
                                <asp:TextBox ID="txtcelular" runat="server" class="form-control white-text" name="name"></asp:TextBox>
                                <label for="name" class="" style="color: white">Celular</label>
                            </div>
                            <div class="input-field">
                                <asp:TextBox ID="txtedad" runat="server" class="form-control white-text" name="name"></asp:TextBox>
                                <%--<input  ID="txtedad" runat="server" class="form-control white-text" name="name" type="date" />--%>
                                <label for="name" class="" style="color: white">fecha de nacimiento</label>
                            </div>
                            <div class="input-field">
                                <asp:TextBox ID="txtdireccion" runat="server" class="form-control white-text" name="name"></asp:TextBox>
                                <label for="name" class="" style="color: white">Direccion</label>
                            </div>
                            <div class="input-field">
                                <asp:TextBox ID="txtcontrasenia" runat="server" class="form-control white-text" TextMode="Password" name="name"></asp:TextBox>
                                <label for="name" class="" style="color: white">Contraseña</label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnregistrarsocio" runat="server" class="btn btn-primary waves-effect waves-dark pull-left" Text="Registrar" OnClick="btnregistrarsocio_Click" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Button ID="btnregresar" runat="server" class="btn btn-primary waves-effect waves-dark pull-left" Text="regresar" OnClick="btnregresar_Click" />
                        </div>
                    </div>

                </div>
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
    <script src="../js/animate.js"></script>
    <!-- Vendor Scripts -->
    <script src="../js/modernizr.custom.js"></script>
    <script src="../js/jquery.isotope.min.js"></script>
    <script src="../js/jquery.magnific-popup.min.js"></script>
    <script src="../js/animate.js"></script>
    <script src="../js/custom.js"></script>

    <script src="contact/jqBootstrapValidation.js"></script>
    <script src="contact/contact_me.js"></script>


</body>
</html>
