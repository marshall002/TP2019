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
    Log _log = new Log();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Listar_Comprobante_Pago();
            txt_noperacion1.Attributes.Add("onkeypress", "javascript:return SoloNumeros(event);");
            txt_nfisio1.Attributes.Add("onkeypress", "javascript:return SoloNumeros(event);");
            txt_nnutri1.Attributes.Add("onkeypress", "javascript:return SoloNumeros(event);");
            txt_monto1.Attributes.Add("onkeypress", "javascript:return SoloNumeros(event);");
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
        if (e.CommandName == "ver Actualizar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            DTOCP.PK_ICP_Cod = Convert.ToInt32(gvRegistrarPago.Rows[index].Cells[0].Text);
            txtmostrarcod.Value = gvRegistrarPago.Rows[index].Cells[0].Text;
            CTRCP.VERPAGO(DTOCP);
            txt_noperacion1.Text = "" + DTOCP.VCP_NOperacion;
            txt_nfisio1.Text = "" + DTOCP.ICP_NFisio;
            txt_nnutri1.Text = "" + DTOCP.ICP_NNutri;
            txt_monto1.Text = "" + DTOCP.DCP_Monto;
            Session["id"] = DTOCP.PK_ICP_Cod;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#Actualizarprueba').modal('show');", true);
        }

        if (e.CommandName == "Ver Pago")
        {
            int index = Convert.ToInt32(e.CommandArgument);
        
            DTOCP.PK_ICP_Cod = Convert.ToInt32(gvRegistrarPago.Rows[index].Cells[0].Text);
            txtmostrarcod.Value=gvRegistrarPago.Rows[index].Cells[0].Text;
            _log.CustomWriteOnLog("Realizar_Pago","txtmostrarcod.Value : " + txtmostrarcod.Value);
            CTRCP.VERPAGO(DTOCP);
            txt_noperacion.Text = "" + DTOCP.VCP_NOperacion;
            txt_nfisio.Text = "" + DTOCP.ICP_NFisio;
            txt_nnutri.Text = "" + DTOCP.ICP_NNutri;
            txt_monto.Text = "" + DTOCP.DCP_Monto;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#VerPago').modal('show');", true);
        }
    }

    protected Boolean ValidacionEstadoPago(string EstadoPago)
    {
        return EstadoPago == "pendiente";
    }

    protected void gvRegistrarPago_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        if (txt_noperacion1.Text.Equals(""))
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo N°operacionees se encuentra vacio" + "');", true);
            txt_noperacion1.Text = "";
            return;
        }
        if (txt_nfisio1.Text.Equals(""))
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo N° fisioterapeuta se encuentra vacio" + "');", true);
            txt_nfisio1.Text = "";
            return;
        }
        if (txt_nnutri1.Text.Equals(""))
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo N°Nutricionista se encuentra vacio" + "');", true);
            txt_nnutri1.Text = "";
            return;
        }
        if (txt_monto1.Text.Equals(""))
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo Monto se encuentra vacio" + "');", true);
            txt_monto1.Text = "";
            return;
        }
        DTOCP.PK_ICP_Cod = int.Parse(Session["id"].ToString());
        DTOCP.VCP_NOperacion = txt_noperacion1.Text;
        DTOCP.ICP_NFisio = int.Parse(txt_nfisio1.Text);
        DTOCP.ICP_NNutri = int.Parse(txt_nnutri1.Text);
        DTOCP.DCP_Monto = double.Parse(txt_monto1.Text);
        

        CTRCP.ActualizarComprobante_Pago(DTOCP);
        Listar_Comprobante_Pago();
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {

    }
    public void llenarDatos()
    {
        int codP = Convert.ToInt32(Session["id"].ToString());
        DTOCP = CTRCP.verComprobanteP(codP);
        txt_monto1.Text = DTOCP.DCP_Monto.ToString();
        txt_noperacion1.Text = DTOCP.VCP_NOperacion.ToString();
        txt_nnutri1.Text = DTOCP.ICP_NFisio.ToString();
        txt_nfisio1.Text = DTOCP.ICP_NNutri.ToString();


    }
}