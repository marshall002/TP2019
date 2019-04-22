<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sol_Citas_Detalles.aspx.cs" Inherits="Sol_Citas_Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
	<section>
		<div class="container-fluid">
			<div class="block-header">
				<h1>Actualizacion de Solicitud</h1>
			</div>
			<div class="row clearfix">
				<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
					<div class="card">
						<div class="header">
							<h2>Actualiza los campos de tu solicitud
                               
								<small></small>
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
						<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
						<div class="body">
							<div class="row">
								<div class="col-md-8">
									<div class="row clearfix">
										<div class="col-sm-12">
											<div class="form-group form-float">
												<label class="form-label">Fecha de la solicitud</label>
												<div class="form-line focused">
													<div class="form-line">
														<asp:TextBox ID="txtFecha" class="form-control" runat="server" TextMode="Date" MaxLength="10"></asp:TextBox>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
								<div class="row">
									<div class="col-md-4">
										<div class="row clearfix">
											<div class="col-sm-12">
												<div class="form-group form-float">
													<label class="form-label">Hora</label>
													<div class="form-line focused">
														<asp:TextBox ID="txtHoras" class="form-control numeros" TextMode="Time" runat="server" MaxLength="3"></asp:TextBox>

													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-lg-12">
									<div class="row clearfix">
										<div class="col-sm-12">
											<div class="form-group">
												<label class="form-label">Duda o consulta</label>
												<div class="form-line">
													<asp:TextBox ID="txtDudaConsulta" runat="server" TextMode="multiline" Rows="4" class="form-control no-resize" placeholder="Ingrese la consulta brevemente"></asp:TextBox>

												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
							<h2 class="card-inside-title">Seleccione el tipo de cita</h2>
							<div class="row">
								<div class="col-lg-4">
									<div class="demo-checkbox">
										<div class="demo-radio-button">
											<input type="radio" id="cbx_Nutricionista" name="Servicios" class="radio-col-indigo" value="1" />
											<label for="cbx_Nutricionista">Cita con nutricionista</label>
										</div>
									</div>

								</div>
								<div class="col-lg-4">
									<div class="demo-checkbox">
										<div class="demo-radio-button">
											<input type="radio" id="cbx_Fisioterapeuta" name="Servicios" class="radio-col-red" value="2" />
											<label for="cbx_Fisioterapeuta">Cita con fisioterapeuta</label>
										</div>
									</div>

								</div>
								<div class="col-lg-3 right">

								<%--	<button type="button" class="btn bg-indigo waves-effect" id="btnGuardar" runat="server" onserverclick="btnGuardar_ServerClick" >
										<i class="material-icons">save</i>
										<span>Guardar</span>
									</button>
									<button type="button" class="btn bg-red waves-effect" id="btnCancelar" runat="server" onserverclick="btnCancelar_ServerClick">
										<i class="material-icons">cancel</i>
										<span>Cancelar</span>
									</button>--%>
									<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"
										ChildrenAsTriggers="true">
										<ContentTemplate>
											<asp:LinkButton ID="btnCancelar1" runat="server" CssClass="btn bg-red waves-effect" Style="float: right" Width="33%" Text="Cancelar" PostBackUrl="~/Sol_Citas_Administracion.aspx" OnClick="btnCancelar_ServerClick">
												<i class="material-icons">arrow_back</i>Regresar
											</asp:LinkButton>
										</ContentTemplate>
										<Triggers>
											<asp:AsyncPostBackTrigger ControlID="btnCancelar1" EventName="Click" />
										</Triggers>
									</asp:UpdatePanel>

									<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"
										ChildrenAsTriggers="true">
										<ContentTemplate>
											<asp:LinkButton ID="btnGuardar1" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: right" Width="33%" Text="Guardar" OnClick="btnGuardar_ServerClick" >
												<i class="material-icons">save</i> Guardar
											</asp:LinkButton>
										</ContentTemplate>
										<Triggers>
											<asp:AsyncPostBackTrigger ControlID="btnGuardar1" EventName="Click" />
										</Triggers>
									</asp:UpdatePanel>

									<asp:HiddenField  ID="txtresultadoChecbox" runat="server"/>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
	<script src="js/RadioButtonCustom.js"></script>
</asp:Content>

