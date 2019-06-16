using DTO;
using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerificarPagoJD : System.Web.UI.Page
{
    CtrCPago ct = new CtrCPago();
    protected void Page_Load(object sender, EventArgs e)
    {
        gvLista.DataSource = ct.VComPago();
        gvLista.DataBind();
    }
    protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver evaluacion")
        {
            //int index = Convert.ToInt32(e.CommandArgument);
            //var col = gvLista.DataKeys[index].Values;
            //string id = col[0].ToString();
            //int CitaId = Convert.ToInt32(id);
            //var modelCite = ct.LCitaNutri();
            //Session["Cita"] = CitaId;
            //textNombre.Text = modelCite.;
            //textFecha.Text = 
            //textHora.Text = Convert.ToString(modelCite.hora);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#VerDetalleMod').modal('show');", true);
        }

    }
}