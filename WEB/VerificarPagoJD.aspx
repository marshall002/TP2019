<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VerificarPagoJD.aspx.cs" Inherits="VerificarPagoJD" Async="true" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <!-- Jquery Core Js -->
	<script src="plugins/jquery/jquery.min.js"></script>
	<!-- Bootstrap Core Js -->
	<script src="plugins/bootstrap/js/bootstrap.js"></script>
    <asp:ScriptManager ID="ScriptManager1"
        runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server"></asp:UpdatePanel>
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Verificar Pagos</h1>
            </div>
            <div class="card">
			<div class="row clearfix">
			 <!-- left column -->
            <div class="col-md-11">
              <!-- general form elements -->
              <div class="box box-primary">
                <!-- form start -->
                <form role="form">
                <div class="row clearfix"><br />
                    <div class="col-lg-1"></div><div class="col-lg-3">
                     <label for="lblCliente">Socio: </label>  <asp:TextBox ID="txtBsocio" runat="server" CssClass="form-control" Width="250px" Height="30px"></asp:TextBox>
                    </div>
                    <div class="col-lg-3">
                        <br />
                         <button class="btn btn-primary" runat="server" onserverclick ="Unnamed_ServerClick">
                          <span class="glyphicon glyphicon-search"></span> Buscar</button>
                    </div>    
                     <div class="col-lg-4"><div class="col-lg-4"></div><br />
                     </div>
                </div><br /><br />
                 
               <div class="row">
                        <div class="col-lg-1"></div>  
                 <div class="col-lg-10">
            <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" GridLines="None"  
                AllowPaging="true" DataKeyNames="PK_ICP_Cod, ICP_NNutri, ICP_NFisio, VCP_Estado_Pago" CssClass="table table-striped table-hover" OnRowCommand="gvLista_RowCommand" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="9">
           <Columns>
                           <asp:BoundField DataField="PK_ICP_Cod" HeaderText="Codigo"/> 
                           <asp:BoundField DataField="nombres" HeaderText="Nombre"/> 
                           <asp:BoundField DataField="DCP_FechaHoraRealizada" HeaderText="Fecha"/>
                           <asp:BoundField DataField="ICP_NNutri" HeaderText="N° Nutri"/>  
                           <asp:BoundField DataField="ICP_NFisio" HeaderText="N° Fisio"/>  
                           <asp:ButtonField ButtonType="button"  HeaderText="Evaluacion" CommandName="Ver Pago" Text="Ver">
                           <ControlStyle CssClass= "btn btn-warning" />
                           </asp:ButtonField> 
                           <asp:BoundField DataField="VCP_Estado_Pago" HeaderText="Estado"/>  
                           <asp:TemplateField HeaderText="Aprobar Pago">
                           <ItemTemplate>
                           <asp:Button runat="server" Text="Aceptar Pago"  CommandName="AceptarP"
                           Visible='<%# ValidacionEstadoCita((string)Eval("VCP_Estado_Pago")) %>'
                            CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" />
                           </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Rechaza Pago">
                           <ItemTemplate>
                           <asp:Button runat="server" Text="Rechazar pago" 
                           Visible='<%# ValidacionEstadoCita((string)Eval("VCP_Estado_Pago")) %>'
                           CommandName="RechazarP" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-danger" />
                           </ItemTemplate>
                           </asp:TemplateField>
                          
           </Columns>
               </asp:GridView>
        </asp:Panel> 
                    
                     </div>  
                   </div>  
             
              </div><!-- /.box -->
			</div>
		</div>
                </div>
            </div>
	</section>
    <div id="modal_no">
         <div class="modal" id="VerPago" tabindex="-1" role="dialog">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">

                                        <h4 class="modal-title" id="ModalVerPago" runat="server">Verificar Pago</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="input-group colorpicker">
                                        <div class="form-line">
                                            <label for="textComprobante">Comprobante:</label><br /><div class="col-lg-4">
                                             <asp:Image ID="textImagen" Width="250" Height="200" runat="server" CssClass="form-control"></asp:Image>
                                        </div></div>
                                        <span class="input-group-addon">
                                            <i></i>
                                        </span>
                                    </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">   
                                    <div class="input-group colorpicker">
                                        <div class="form-line">
                                            <label for="textMontos">Monto:</label>
                                            <asp:TextBox ID="txtMonto" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <span class="input-group-addon">
                                            <i></i>
                                        </span>
                                    </div>

                                   <div class="input-group colorpicker">
                                        <div class="form-line">
                                            <label for="textNnutri">N° Citas Nutri:</label>
                                            <asp:TextBox ID="txtNnutri" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <span class="input-group-addon">
                                            <i></i>
                                        </span>
                                    </div>
                                </div>
                                           
                                       <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                   <div class="input-group colorpicker">
                                        <div class="form-line">
                                            <label for="textOpera">N° de Operación:</label>
                                            <asp:TextBox ID="txtOpera" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <span class="input-group-addon">
                                            <i></i>
                                        </span>
                                    </div>
                                   <div class="input-group colorpicker">
                                        <div class="form-line">
                                            <label for="textNfisio">N° Citas Fisio:</label>
                                            <asp:TextBox ID="txtFisio" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <span class="input-group-addon">
                                            <i></i>
                                        </span>
                                    </div>

                            </div>

                        </div>
                        <div class="modal-footer">

                            <div class="form-group">
                                <div class="form-group">
                                    <input type="button" value="Guardar" class="btn btn-success" runat="server">
                                    <input type="button" value="Cerrar" class="btn btn-danger" onclick="closeModal();">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    



</asp:Content>

