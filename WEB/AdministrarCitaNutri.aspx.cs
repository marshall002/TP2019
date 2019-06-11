using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdministrarCitaNutri : System.Web.UI.Page
{
    CtrCita ct = new CtrCita();
    protected void Page_Load(object sender, EventArgs e)
    {
        gvLista.DataSource = ct.LCitaNutri();
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