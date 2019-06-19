using DTO;
using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class VerificarPagoJD : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CtrCPago ct = new CtrCPago();
            this.gvLista.DataSource = ct.VComPago("");
            gvLista.DataBind();
        }
    }
    protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver Pago")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvLista.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();
            string Nnutri = colsNoVisible[1].ToString();
            string Nfisio = colsNoVisible[2].ToString();
            Session["CodigoComprobante"] = id;
            Session["NuNutri"] = Nnutri;
            Session["NuFisio"] = Nfisio;
            txtNnutri.Text = Nnutri;
            txtFisio.Text = Nfisio;
            CtrCPago obj = new CtrCPago();
            var p = obj.ComprobanteP(Convert.ToInt32(id));
            textImagen.ImageUrl = "data:image/jpg;base64," + p.IMC_Imagen;
            txtMonto.Text = p.DCP_Monto.ToString();
            txtOpera.Text = p.VCP_NOperacion.ToString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#VerPago').modal('show');", true);
        }
        if (e.CommandName == "AceptarP")
        {
            Log.WriteLog("Entro a comando aceptar pago");
            int index = Convert.ToInt32(e.CommandArgument);
            Log.WriteLog("1");
            var colsNoVisible = gvLista.DataKeys[index].Values;
            Log.WriteLog("2");
            string id = colsNoVisible[0].ToString();
            Log.WriteLog("3");
            Session["CodigoComprobante"] = id;
            CtrCPago obj = new CtrCPago();
            obj.AceptP(Convert.ToInt32(id));
            Log.WriteLog("4");
            string mensaje = "Datos actualizados";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);
            Response.Redirect("~/VerificarPagoJD.aspx");
        }
        if (e.CommandName == "ReportarP")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvLista.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();
            Session["CodigoComprobante"] = id;
            CtrCPago obj = new CtrCPago();
            obj.RechaP(Convert.ToInt32(id));
            Response.Redirect("~/VerificarPagoJD.aspx");
        }
        
    }
    protected Boolean ValidacionEstadoCita(string VCP_Estado_Pago)
    {
        return VCP_Estado_Pago == "Pendiente";
    }
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        CtrCPago ct = new CtrCPago();
        var dt = ct.VComPago(txtBsocio.Text);
        this.gvLista.DataSource = dt;
        gvLista.DataBind();
    }
}