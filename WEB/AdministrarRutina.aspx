<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarRutina.aspx.cs" Inherits="AdministrarRutina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" Runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
				<h1>Administrar Rutina</h1>
			</div>
            <div class="row clearfix">
            <div class="col-md-11">
             <div class="card">
                <!-- form start -->
                <div class="row"><br />
                    <div class="col-lg-1"></div><div class="col-lg-3">
                       <label for="lblCliente">Seleccionar Mes: </label>
                        <asp:DropDownList runat="server" ID="ddlMes" CssClass="form-control"  AutoPostBack="true">
																														
															<asp:ListItem Value="1">Enero</asp:ListItem>
															<asp:ListItem Value="2">Febrero</asp:ListItem>
															<asp:ListItem Value="3">Marzo</asp:ListItem>
															<asp:ListItem Value="4">Abril</asp:ListItem>
															<asp:ListItem Value="5">Mayo</asp:ListItem>
															<asp:ListItem Value="6">Junio</asp:ListItem>
															<asp:ListItem Value="7">Julio</asp:ListItem>
															<asp:ListItem Value="8">Agosto</asp:ListItem>
															<asp:ListItem Value="9">Setiembre</asp:ListItem>
                                                            <asp:ListItem Value="10">Octubre</asp:ListItem>
															<asp:ListItem Value="11">Noviembre</asp:ListItem>
															<asp:ListItem Value="12">Diciembre</asp:ListItem>

									</asp:DropDownList>    
                    </div>
                    <div class="col-lg-3">
                        
                    </div>    
                     <div class="col-lg-4">
                             <label for="lblCliente">Fecha de hoy: </label>
                        <asp:TextBox ID="txtfecha" runat="server" ReadOnly CssClass="form-control" Width="250px" Height="30px"></asp:TextBox>    
                    </div>
                     </div> 
                <br /><br />
                 
               <div class="row">
                        <div class="col-lg-1"></div>  
                 <div class="col-lg-10">
            <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" GridLines="None"  
                AllowPaging="true" CssClass="table table-striped table-hover" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="32">
           <Columns>
                            <asp:BoundField DataField="n1" HeaderText="Inicio de Semana"/> 
                            <asp:BoundField DataField="n2" HeaderText="Fin de semana"/> 
                           <asp:ButtonField ButtonType="button"  HeaderText="Crossfit" CommandName="Crear" Text="Crear">
                            <ControlStyle CssClass= "btn btn-success"  />


                             </asp:ButtonField>    
                            <asp:ButtonField ButtonType="button"  HeaderText="Funtional" CommandName="Crear" Text="Crear">
                            <ControlStyle CssClass= "btn btn-success" />
                             </asp:ButtonField>                                
           </Columns>
               </asp:GridView>
        </asp:Panel> 
                     </div>  
                   </div>  
              </div>
              </div>
            </div>
             </div>
        </div>
     </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" Runat="Server">
</asp:Content>


