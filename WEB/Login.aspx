<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=Edge" />
	<meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />

	<link rel="icon" href="favicon.ico" type="image/x-icon" />

	<!-- Google Fonts -->
	<link href="css/googleapis_latyn_cyrillic.css" rel="stylesheet" />
	<link href="css/googleapis_material_Icons.css" rel="stylesheet" />
	<link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />
	<link href="plugins/node-waves/waves.css" rel="stylesheet" />
	<link href="plugins/animate-css/animate.css" rel="stylesheet" />
	<link href="plugins/morrisjs/morris.css" rel="stylesheet" />
	<link href="../../plugins/sweetalert/sweetalert.css" rel="stylesheet" />

	<!-- Custom Css -->
	<link href="css/style.css" rel="stylesheet" />
	<link href="css/themes/all-themes.css" rel="stylesheet" />
	<script src="plugins/jquery/jquery.min.js"></script>

	<title>SGCLAP</title>
    </head>
<body class="theme-indigo">
    <div class="page-loader-wrapper">
        <div class="loader">
            <div class="preloader">
                <div class="spinner-layer pl-red">
                    <div class="circle-clipper left">
                        <div class="circle"></div>
                    </div>
                    <div class="circle-clipper right">
                        <div class="circle"></div>
                    </div>
                </div>
            </div>
            <p>Por favor espere...</p>
        </div>
    </div>
    <div class="overlay"></div>
    <div class="search-bar">
        <div class="search-icon">
            <i class="material-icons">search</i>
        </div>
        <input type="text" placeholder="START TYPING..." />
        <div class="close-search">
            <i class="material-icons">close</i>
        </div>
    </div>


    <form id="form1" runat="server">
        <nav class="theme-indigo navbar">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a href="javascript:void(0);" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse" aria-expanded="false"></a>
                    <a href="javascript:void(0);" class="bars"></a>
                    <a class="navbar-brand" href="index.html">SGCLAP
					</a>
                </div>
                <div class="collapse navbar-collapse" id="navbar-collapse">
                    <ul class="nav navbar-nav navbar-right">
                 
                        <li class="dropdown" onclick="javascript:LoginModal();">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button">
                               <i class="material-icons">perm_identity </i>
							</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="modal fade" id="modalIniciarSesion" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="login-page bg-blue">
                <div class="login-box">
                    <div class="logo m-t-10 ">
                        <a> <b>SGCLAP</b></a>
                    </div>
                    <div class="card">
                        <div class="body" id="bodyLogin">
                            <div class="msg">Inicie sesi&oacute;n para ingresar</div>

                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="material-icons">person</i>
                                </span>
                                <div class="form-line">
                                   
                                   <asp:TextBox ID="textUsuario" CssClass="form-control" runat="server" MaxLength="20" placeholder="Usuario"></asp:TextBox>


                                </div>
                            </div>
                            
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="material-icons">lock</i>
                                </span>
                                <div class="form-line">
                                     <asp:TextBox ID="textPassword" TextMode="Password" CssClass="form-control" runat="server" MaxLength="20" placeholder="Usuario"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-7 p-t-5">
                                    <input type="checkbox" runat="server" name="ckbRecuerdame" id="ckbRecuerdame" class="chk-col-pink" />
                                    <label for="ckbRecuerdame">Recuerdame</label>
                                </div>

                                <div class="col-xs-5">
                                      <asp:Button ID="btnIniciarSesión" runat="server" Text="INICAR SESI&Oacute;N" CssClass="btn btn-block bg-pink waves-effect"
                                          OnClick="btnIniciarSesión_Click"/>
                                </div>
                            </div>

                            <div class="row m-t-15 m-b--20">
                                <div class="col-xs-6">
                                    <a href="#" data-dismiss="modal" onclick="changeToRegister($(this));">&iexcl;Reg&iacute;strate ahora!</a>
                                </div>
                                <div class="col-xs-6 align-right">
                                    <a href="#" data-dismiss="modal" onclick="changeToRemember($(this));">&iquest;Olvidaste tu contraseña?</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    </form>

    

    <script>

        function LoginModal() {
            $('#modalIniciarSesion').modal();
        }
    </script>
    <!-- Jquery Core Js -->
    <!-- Bootstrap Core Js -->
    <script src="../../plugins/jquery/jquery.min.js"></script>
    <script src="../../plugins/bootstrap/js/bootstrap.js"></script>
    <script src="../../plugins/bootstrap-select/js/bootstrap-select.js"></script>
    <script src="../../plugins/jquery-slimscroll/jquery.slimscroll.js"></script>
    <script src="../../plugins/node-waves/waves.js"></script>
    <script src="../../plugins/autosize/autosize.js"></script>
    <script src="../../plugins/momentjs/moment.js"></script>
    <script src="../../plugins/bootstrap-notify/bootstrap-notify.js"></script>
    <script src="../../plugins/jquery-countto/jquery.countTo.js"></script>
    <script src="../../plugins/raphael/raphael.min.js"></script>
    <script src="../../plugins/morrisjs/morris.js"></script>
    <script src="../../plugins/chartjs/Chart.bundle.js"></script>
    <script src="../../plugins/flot-charts/jquery.flot.js"></script>
    <script src="../../plugins/flot-charts/jquery.flot.resize.js"></script>
    <script src="../../plugins/flot-charts/jquery.flot.pie.js"></script>
    <script src="../../plugins/flot-charts/jquery.flot.categories.js"></script>
    <script src="../../plugins/flot-charts/jquery.flot.time.js"></script>
    <script src="../../plugins/jquery-sparkline/jquery.sparkline.js"></script>
    <script src="../../js/admin.js"></script>
    <script src="../../js/pages/ui/tooltips-popovers.js"></script>
    <script src="../../js/pages/forms/basic-form-elements.js"></script>
    <script src="../../js/pages/ui/notifications.js"></script>
    <script src="../../js/pages/ui/modals.js"></script>
    <script src="js/pages/index.js"></script>
    <script src="../../plugins/sweetalert/sweetalert.min.js"></script>
    <script src="../../js/admin.js"></script>
    <script src="../../js/pages/ui/dialogs.js"></script>
    <script src="js/demo.js"></script>
    <script src="../../js/public/utils.js"></script>

</body>
</html>
