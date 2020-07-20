using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using CTR;
using DTO;

public partial class _Default : System.Web.UI.Page
{
    CtrCita objctrcita = new CtrCita();
    DtoCita objdtoCita = new DtoCita();
    CtrUsuario objctrusuario = new CtrUsuario();
    DtoUsuario objdtousuario = new DtoUsuario();

    Log Log = new Log();
    int TipoCitaSol = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["id_perfil"] != null)
            {
                if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_SOCIO)
                {
                    ListarSolicitudesCita(TipoCitaSol, Session["SessionUsuario"].ToString());
                    contarCitasxServicio();
                    NutriCont.InnerText = (int.Parse(Session["ISN_Cantidad"].ToString()) - int.Parse(objdtousuario.IC_Citas_Nutri_Usadas.ToString())).ToString();
                    NutriFisio.InnerText = (int.Parse(Session["ISF_Cantidad"].ToString()) - int.Parse(objdtousuario.IC_Citas_Fisio_Usadas.ToString())).ToString();
                    

                    //contarCitasxServicio();
                    ValidarfechaFinPlan();
                }
                else
                {
                    Log.WriteOnLog(" Sol Citas Administracion - Error en id Perfil");
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {

                Log.WriteOnLog(" Sol Citas Administracion - Error en id Perfil");
                Response.Redirect("Inicio.aspx");

            }

        }
    }
    public void ListarSolicitudesCita(int tiposolicitud, string CodigoUsuario)
    {
        gvSolicitudesCita.DataSource = objctrcita.VerSolicitudesCita(CodigoUsuario);
        gvSolicitudesCita.DataBind();
    }
    protected void gvSolicitudesCita_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "actualizar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvSolicitudesCita.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();
            string estadosol = colsNoVisible[1].ToString();
            string tipocitasol = colsNoVisible[2].ToString();

            Session["CodigoSolicitudCita"] = id;
            Session["estadosol"] = estadosol;
            Session["TipoCitaSol"] = tipocitasol;
            Log.WriteOnLog("CodigoSolicitudCita" + id);
            Log.WriteOnLog("estadosol" + estadosol);
            Log.WriteOnLog("TipoCitaSol" + tipocitasol);


            if (estadosol != "2")
            {
                Response.Redirect("Sol_Citas_Detalles.aspx");

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Usted no puede actualizar la cita', 'bottom', 'center', null, null);", true);

            }

        }
        if (e.CommandName == "eliminar")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolicitudesCita.DataKeys[index].Values;
                string idSol = colsNoVisible[0].ToString();
                string estadosol = colsNoVisible[1].ToString();
                Session["CodigoSolicitudCita"] = idSol;
                Session["estadosol"] = estadosol;
                if (estadosol != "2")
                {
                    string script = @"<script type='text/javascript'>
                                      $('#modalconfirmacioneliminarsol').modal('show');
                                  </script>";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Usted no puede eliminar la cita', 'bottom', 'center', null, null);", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

            }
        }
        if (e.CommandName == "AprobarRepro")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolicitudesCita.DataKeys[index].Values;
                int idSol = int.Parse(colsNoVisible[0].ToString());
                Session["CodigoSolicitudCita"] = idSol;
                ObtenerHoraReprograma(objdtoCita);
                string script = @"<script type='text/javascript'>
                                      $('#modalDetallesHoraReprogramada').modal('show');
                                  </script>";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);


                //objctrcita.EvaluarReprogramarCita(objdtoCita);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '"+index+"', 'bottom', 'center', null, null);", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'error en ComandoAprobar:" + ex.Message + "', 'bottom', 'center', null, null);", true);
            }
        }
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Sol_Citas_Registrar.aspx");
    }

    protected void btnEliminarSolCita_ServerClick(object sender, EventArgs e)
    {
        try
        {
            int idSolicitud = int.Parse(Session["CodigoSolicitudCita"].ToString());
            int estadosol = int.Parse(Session["estadosol"].ToString());
            objctrcita.EliminarrSolicitudCita(idSolicitud, estadosol);
            ListarSolicitudesCita(TipoCitaSol, Session["SessionUsuario"].ToString());
            upCursos.Update();
            contarCitasxServicio();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Solicitud eliminada con exito	', 'bottom', 'center', null, null);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);
        }
    }
    public void contarCitasxServicio()
    {
        objdtousuario.PK_CU_Dni = Session["SessionUsuario"].ToString();
        objctrusuario.ObtenerNumCitasRealizadas(objdtousuario);
    }

    public void ValidarfechaFinPlan()
    {
        DateTime Fechafinpla = DateTime.Parse(Session["DP_Fecha_Fin_Plan"].ToString());
        DateTime fechaahora = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

        if (fechaahora > Fechafinpla)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Es mayor la fecha de hoy a la fecha de fin de plan', 'bottom', 'center', null, null);", true);
        }
        else if (fechaahora <= Fechafinpla)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Es menor la fecha de hoy a la fecha de fin de plan', 'bottom', 'center', null, null);", true);
        }

    }
    protected Boolean ValidacionEstadoCita(int FK_IEC_Cod)
    {
        return FK_IEC_Cod == 3;
    }
    protected Boolean ValidacionEstadoCitaEliminar(int FK_IEC_Cod)
    {
        return FK_IEC_Cod == 1;
    }

    public void ObtenerHoraReprograma(DtoCita objdtoCita)
    {
        objdtoCita.IC_Cod = int.Parse(Session["CodigoSolicitudCita"].ToString());
        Log.WriteOnLog("objdtoCita.IC_Cod " + objdtoCita.IC_Cod);
        objctrcita.ObtenerInformacionSolicitudCita(objdtoCita);
        DateTime dtValue = objdtoCita.DC_FechaReprogramada;
        Log.WriteOnLog("dtValue " + dtValue);


        txtFechareprogramada.Text = dtValue.ToString("dd/MM/yyyy");
        txtHorareprogramada.Text = dtValue.ToString("hh:mm tt");
        upHoraReprogramada.Update();
    }

    protected void btnAprobar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            Log.WriteOnLog("Entro a funcion aprobar ");

            objdtoCita.IC_Cod = int.Parse(Session["CodigoSolicitudCita"].ToString());
            objdtoCita.FK_IEC_Cod = 2;
            Log.WriteOnLog("1A");
            Log.WriteOnLog("objdtoCita.IC_Cod" + objdtoCita.IC_Cod);
            Log.WriteOnLog("objdtoCita.FK_IEC_Cod " + objdtoCita.FK_IEC_Cod);

            objctrcita.EvaluarReprogramarCita(objdtoCita);
            Log.WriteOnLog("objdtoCita.IC_Cod" + objdtoCita.IC_Cod);
            Log.WriteOnLog("objdtoCita.FK_IEC_Cod " + objdtoCita.FK_IEC_Cod);

            Log.WriteOnLog("2A");
            upCursos.Update();
            Response.Redirect("Sol_Citas_Administracion.aspx");

        }
        catch (Exception ex)
        {
            Log.WriteOnLog("CATCH Aprobar " + ex.Message);
        }
    }

    protected void btnRechazar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            Log.WriteOnLog("Entro a funcion rechazar");
            objdtoCita.IC_Cod = int.Parse(Session["CodigoSolicitudCita"].ToString());
            objdtoCita.FK_IEC_Cod = 8;
            Log.WriteOnLog("1R");
            Log.WriteOnLog("objdtoCita.IC_Cod" + objdtoCita.IC_Cod);
            Log.WriteOnLog("objdtoCita.FK_IEC_Cod " + objdtoCita.FK_IEC_Cod);
            objctrcita.EvaluarReprogramarCita(objdtoCita);
            Log.WriteOnLog("objdtoCita.IC_Cod" + objdtoCita.IC_Cod);
            Log.WriteOnLog("objdtoCita.FK_IEC_Cod " + objdtoCita.FK_IEC_Cod);
            Log.WriteOnLog("2R");
            upCursos.Update();
            Response.Redirect("Sol_Citas_Administracion.aspx");

        }
        catch (Exception ex)
        {
            Log.WriteOnLog("CATCH RECHAZAR " + ex.Message);
        }
    }
}