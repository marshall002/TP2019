﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminRutina.aspx.cs" Inherits="AdminRutina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" Runat="Server">

        <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Administrar Rutinas</h1>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UPGridview" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <div class="card">
                                <div class="header">
                                    <%--<h2>Programas actuales por sede</h2>--%>
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
                                <div class="body table-responsive ">
                                    <asp:GridView ID="gvPhoneBook" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="PhoneBookID"
                                        ShowHeaderWhenEmpty="true"
                                        OnRowCommand="gvPhoneBook_RowCommand1" OnRowEditing="gvPhoneBook_RowEditing1" OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit1"
                                        OnRowUpdating="gvPhoneBook_RowUpdating1" OnRowDeleting="gvPhoneBook_RowDeleting1"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <%-- Theme Properties --%>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="First Name">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("FirstName") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' runat="server" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtFirstNameFooter" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Last Name">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("LastName") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat="server" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtLastNameFooter" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("Contact") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtContact" Text='<%# Eval("Contact") %>' runat="server" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtContactFooter" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("Email") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEmail" Text='<%# Eval("Email") %>' runat="server" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtEmailFooter" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                                                    <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                                    <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
                                    <br />
                                    <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>

                            <%--<asp:AsyncPostBackTrigger ControlID="btnEliminarSolCita" />
                            <asp:AsyncPostBackTrigger ControlID="btnAprobar" />
                            <asp:AsyncPostBackTrigger ControlID="btnRechazar" />--%>
                        </Triggers>

                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" Runat="Server">
</asp:Content>

