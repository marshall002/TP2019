<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Verificar_Pago.aspx.cs" Inherits="Verificar_Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" Runat="Server">

    <section>
        <div class="container-fluid">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>VERIFICAR PAGO
                            </h2>
                        <ul class="header-dropdown m-r--5">
                            <li class="dropdown">
                                <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                    <i class="material-icons">more_vert</i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li><a href="javascript:void(0);">Action</a></li>
                                    <li><a href="javascript:void(0);">Another action</a></li>
                                    <li><a href="javascript:void(0);">Something else here</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
     <div class="modal-footer">
     <button type="button" class="btn btn-info" data-dismiss="modal">REGISTRAR CITA</button>
    </div>
     <div class="modal-footer">
     <button type="button" class="btn btn-info" data-dismiss="modal">REGISTRAR NUEVO SOCIO</button>
    </div>
                    <div class="body">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped table-hover js-basic-example dataTable">
                                <thead>
                                    <tr>
                                        <th>Nombre</th>
                                        <th>Fecha</th>
                                        <th>Hora</th>
                                        <th>Especialista</th>
                                        <th>Tipo de Membresia</th>
                                        <th>Pago</th>
                                        <th>Estado</th>
                                        <th>Accion</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <tr>
                                        <td>Garrett Winters</td>
                                        <td>Accountant</td>
                                        <td>Tokyo</td>
                                        <td>63</td>
                                        <td>2011/07/25</td>
                                        <td>
                                            <button class="btn btn-warning">VER</button></td>
                                        <td>2011/07/26</td>
                                        <td>
                                            <button class="btn btn-danger">APROBAR SOLICITUD DE CITA</button>   <button class="btn btn-danger">REPORTAR CITA</button></td>
                                    </tr>

                                    <tr>
                                        <td>Yeni>
                                        <td>Accountant</td>
                                        <td>Tokyo</td>
                                        <td>63</td>
                                        <td>2011/07/25</td>
                                        <td>
                                        <button class="btn btn-warning">VER</button></td>
                                        <td>2011/07/26</td>
                                        <td>
                                            <button class="btn btn-danger">APROBAR SOLICITUD DE CITA</button>   <button class="btn btn-danger">REPORTAR CITA </button></td>
                                        </tr>


                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="../../plugins/jquery-datatable/jquery.dataTables.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" Runat="Server">
</asp:Content>

