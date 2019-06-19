using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class AdministrarCitaNutri : System.Web.UI.Page
{
    CtrCita ct = new CtrCita();

    //DtoCita objdtoCita = new DtoCita();
    //CtrUsuario objctrusuario = new CtrUsuario();
    //DtoUsuario objdtousuario = new DtoUsuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_perfil"] != null)
        {
            if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_NUTRICIONISTA)
            {
                gvLista.DataSource = ct.LCitaNutri();
                gvLista.DataBind();
            }
            else
            {
                Log.WriteLog("Citas Nutri Administracion - Error en id Perfil");
                Response.Redirect("Inicio.aspx");
            }
        }
        else
        {

            Log.WriteLog("Citas Nutri Administracion - Error en id Perfil");
            Response.Redirect("Inicio.aspx");

        }

        
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

    protected void btnReprogramar_Click(object sender, EventArgs e)
    {
        string txtareaconsulta = textObs.Text.Trim();
        //TimeSpan Hora = TimeSpan.Parse(ddlNuevaHora.Text);
        //DateTime Fecha = Convert.ToDateTime(txtFechaProNueva.Text);
        //DateTime fechaReprogramada = Fecha + Hora;
        int codigosol = int.Parse(Session["CodigoSolicitudCita"].ToString());
        //Log.WriteLog(txtresultadoChecbox.Value);
        //Log.WriteLog("Fecha reprogramada " + fechaReprogramada);
        string mensaje = "Datos actualizados";
        //ct.ReprogramarCita(codigosol, fechaReprogramada);
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);
        Response.Redirect("~/Proc_Citas_Sol_Listar.aspx");
    }
}