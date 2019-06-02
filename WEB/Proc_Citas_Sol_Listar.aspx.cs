using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using DTO;
using CTR;

public partial class Proc_Citas_Sol_Listar : System.Web.UI.Page
{
    CtrCita objctrcita = new CtrCita();
    protected void Page_Load(object sender, EventArgs e)
    {
        Log.WriteLog("Session['id_perfil']" + Session["id_perfil"]);
        if (Session["id_perfil"] != null)
        {
            if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_ADMINISTRADOR)
            {
                ListarSolicitudesCitaAdmin();

            }
            else
            {
                Log.WriteLog("Proc Citas Sol Registrar2 - Error en id Perfil");
                Response.Redirect("Inicio.aspx");
            }
        }
        else
        {

            Log.WriteLog("Proc Citas Sol Registrar2 - Error en id Perfil");
            Response.Redirect("Inicio.aspx");

        }
    }
    public void ListarSolicitudesCitaAdmin()
    {
        gvSolicitudesCitaAdmin.DataSource = objctrcita.VerSolicitudesCitaAdmin();
        gvSolicitudesCitaAdmin.DataBind();
    }



    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Proc_Citas_Sol_Registrar.aspx");
    }

    protected void gvSolicitudesCitaAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvSolicitudesCitaAdmin.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();
            string estadosol = colsNoVisible[1].ToString();
            string tipocitasol = colsNoVisible[2].ToString();
            string CodigoUsuarioCita = colsNoVisible[3].ToString();



            Session["CodigoSolicitudCita"] = id;
            Session["estadosol"] = estadosol;
            Session["TipoCitaSol"] = tipocitasol;
            Session["CodigoUsuarioCita"] = CodigoUsuarioCita;
            Response.Redirect("Proc_Citas_Sol_Detalles.aspx");
        }
    }

}