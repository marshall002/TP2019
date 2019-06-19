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
            Response.Redirect("~/ActualizarPagos.aspx");
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