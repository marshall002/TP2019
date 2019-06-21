using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using CTR;
using DTO;

public partial class Realizar_Pago : System.Web.UI.Page
{
    DtoCPago DTOCP = new DtoCPago();
    CtrCPago CTRCP = new CtrCPago();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Listar_Comprobante_Pago();
        }
    }
    public void Listar_Comprobante_Pago()
    {
        gvRegistrarPago.DataSource = CTRCP.VerComprobante_Pago();
        gvRegistrarPago.DataBind();
    }


    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RegistrarPagos.aspx");
    }

    protected void gvRegistrarPago_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Actualizar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvRegistrarPago.DataKeys[index].Values;
            int codComp = Convert.ToInt32(colsNoVisible[0]);
            Session["idcomp"] = codComp;
            Response.Redirect("~/ActualizarPagos.aspx");
        }
        if (e.CommandName == "Ver")
        {
            string script = @"<script type='text/javascript'>
                                      $('#VerPago').modal('show');
                                  </script>";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
            
        }
    }
    protected Boolean ValidacionEstadoPago(string EstadoPago)
    {
        return EstadoPago == "pendiente";
    }

    protected void gvRegistrarPago_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}