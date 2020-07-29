using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;

public partial class Solicitudes_Cita_Registrar_Solicitud_Cita : System.Web.UI.Page
{
    DtoUsuario objdtousuario = new DtoUsuario();
    CtrUsuario objctrusuario = new CtrUsuario();
    DtoCita objdtoCita = new DtoCita();
    CtrCita objctrCita = new CtrCita();
    Log _log = new Log();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["id_perfil"] != null)
            {
                if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_SOCIO)
                {
                    contarCitasxServicio();

                }
                else
                {
                    _log.CustomWriteOnLog("SolCitasRegistrar", " Sol Citas Registrar - Error en id Perfil");
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {

                _log.CustomWriteOnLog("SolCitasRegistrar", " Sol Citas Registrar - Error en id Perfil");
                Response.Redirect("Inicio.aspx");

            }
        }
    }
    protected void btnGuardar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string valorRadiobuttonentxt = txtresultadoChecbox.Value;
            contarCitasxServicio();
            _log.CustomWriteOnLog("SolCitasRegistrar", "---------------------------------------------------------------------------------------------");

            _log.CustomWriteOnLog("SolCitasRegistrar", "Cantidad de sesiones x plan de fisioterapeuta actuales: " + Session["ISF_Cantidad"].ToString());
            _log.CustomWriteOnLog("SolCitasRegistrar", "Contador de sesiones registradas actuales: " + objdtousuario.IC_Citas_Fisio_Usadas.ToString());
            _log.CustomWriteOnLog("SolCitasRegistrar", "Contador de sesiones x plan de nutricionista actuales: " + Session["ISN_Cantidad"].ToString());
            _log.CustomWriteOnLog("SolCitasRegistrar", "Contador de sesiones registradas actuales: " + objdtousuario.IC_Citas_Nutri_Usadas.ToString());
            _log.CustomWriteOnLog("SolCitasRegistrar", "---------------------------------------------------------------------------------------------");



            if (valorRadiobuttonentxt == "1")//Nutri
            {
                if (int.Parse(Session["IC_Citas_Nutri_Usadas"].ToString()) >= int.Parse(Session["ISN_Cantidad"].ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para Nutri', 'bottom', 'center', null, null);", true);
                }
                else
                {
                    RegistrarCodigo(valorRadiobuttonentxt);
                }
            }
            else if (valorRadiobuttonentxt == "2")//Fisio
            {
                if (int.Parse(Session["IC_Citas_Fisio_Usadas"].ToString()) >= int.Parse(Session["ISF_Cantidad"].ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para Fisio', 'bottom', 'center', null, null);", true);
                }
                else
                {
                    RegistrarCodigo(valorRadiobuttonentxt);
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

        }

    }
    public void RegistrarCodigo(string valorRadiobuttonentxt)
    {
        try
        {
            TimeSpan Hora = TimeSpan.Parse(ddlHoras.Text);
            string txtareaconsulta = txtDudaConsulta.Text.Trim();
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            DateTime fechasolitada = Fecha + Hora;
            string Sesion = Session["SessionUsuario"].ToString();

            int IECCod = 1;

            objdtoCita.DC_FechaHoraSolicitada = fechasolitada;
            objdtoCita.VC_Observacion = txtareaconsulta;
            objdtoCita.FK_IEC_Cod = IECCod;
            objdtoCita.FK_ITC_Cod = int.Parse(valorRadiobuttonentxt);
            objdtoCita.FK_CU_DNI = Sesion;
            bool valHoraCita = objctrCita.ExisteCita(fechasolitada.ToString("yyyy-MM-dd'T'HH':'mm':'ss"), Sesion);

            if (Fecha > DateTime.Now)
            {
                if (valHoraCita == false)
                {
                    string mensaje = "Registrado con exito";
                    objctrCita.registrarSolicitudCita(objdtoCita);

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);
                }
                else
                {
                    string mensaje = "Existe Cita en esa hora";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + mensaje + "', 'bottom', 'center', null, null);", true);
                }
            }
            else
            {
                string mensaje = "selecione fecha correctamente";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + mensaje + "', 'bottom', 'center', null, null);", true);
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("SolCitasRegistrar", "ERROR : " + ex.Message);
            _log.CustomWriteOnLog("SolCitasRegistrar", "STACKTRACE : "+ex.StackTrace);
        }
    }
    protected void btnCancelar_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Sol_Citas_Administracion.aspx");
    }
    public void contarCitasxServicio()
    {
        objdtousuario.PK_CU_Dni = Session["SessionUsuario"].ToString();
        objctrusuario.ObtenerNumCitasRealizadas(objdtousuario);
    }

    protected void ddlHoras_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

}