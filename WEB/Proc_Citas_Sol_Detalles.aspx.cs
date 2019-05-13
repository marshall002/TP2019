using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;

public partial class Sol_Citas_Detalles : System.Web.UI.Page
{
    CtrCita objctrcita = new CtrCita();
    CtrUsuario objctrusuario = new CtrUsuario();
    DtoCita objdtocita = new DtoCita();
    DtoUsuario objdtousuario = new DtoUsuario();
    DtoPlan objdtoplan = new DtoPlan();
    DtoSesionFisio objdtosesionFisio = new DtoSesionFisio();
    DtoSesionNutri objdtosesionNutri = new DtoSesionNutri();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargardatosCitas();
        }

    }

    protected void btnGuardar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string valorRadiobuttonentxt = txtresultadoChecbox.Value;
            Log.WriteLog("valorRadiobuttonentxt" + valorRadiobuttonentxt);
            contarCitasxServicio();
            actualizardatos(valorRadiobuttonentxt);
            string mensaje = "Datos actualizados";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', ' asdasdasd:" + ex.Message + "', 'bottom', 'center', null, null);", true);

        }

    }
    public void actualizardatos(string valorRadiobuttonentxt)
    {
        try
        {

            int codigosol = int.Parse(Session["CodigoSolicitudCita"].ToString());
            objdtocita.IC_Cod = codigosol;
            objdtocita.FK_IEC_Cod = int.Parse(valorRadiobuttonentxt);
            objctrcita.ActualizarSolCitaAdmin(objdtocita);
        }
        catch (Exception ex)
        {
            Log.WriteLog("Error en el actualizar aprobar o rechazar :" + ex.Message);
            throw;
        }

    }
    public void cargardatosCitas()
    {
        try
        {
            objdtocita.IC_Cod = int.Parse(Session["CodigoSolicitudCita"].ToString());
            objctrcita.ObtenerInformacionSolicitudCita(objdtocita);
            DateTime dtValue = objdtocita.DC_FechaHoraSolicitada;
            txtFecha.Text = dtValue.ToString("yyyy-MM-dd");
            ddlHoras.Text = dtValue.ToString("HH:mm");
            string TipoCitaSol = Session["tipocitasol"].ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            #region js
            sb.Append(@"<script language='javascript'>");
            sb.Append(@"SeleccionarRadioButton(" + TipoCitaSol + ");");
            sb.Append(@"</script>");
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", sb.ToString(), false);
#endregion
            txtDudaConsulta.Text = objdtocita.VC_Observacion;
            txtFecha.Text = Convert.ToString(objdtocita.DC_FechaHoraSolicitada.ToString("yyyy-MM-dd"));
            txtEstadoSolicitud.Text = objdtocita.FK_IEC_Nombre;
            
            objdtousuario.PK_CU_Dni= objdtocita.FK_CU_DNI;
            try
            {
                objctrusuario.ObtenerInformacionUsuario(objdtousuario, objdtoplan, objdtosesionFisio, objdtosesionNutri);
                txtUsuarioSolicitante.Text = objdtousuario.VU_Nombre+" " + objdtousuario.VU_APaterno+" "+ objdtousuario.VU_AMaterno;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No tiene los permisos para actualizar', 'bottom', 'center', null, null);", true);
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No tiene los permisos para actualizar', 'bottom', 'center', null, null);", true);

        }

    }

    protected void btnCancelar_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("~/");
    }

    public void contarCitasxServicio()
    {
        objdtousuario.PK_CU_Dni = Session["CodigoUsuarioCita"].ToString();
        objctrusuario.ObtenerNumCitasRealizadas(objdtousuario);
    }

    protected void btnReproSCita_ServerClick(object sender, EventArgs e)
    {
        string txtareaconsulta = txtDudaConsulta.Text.Trim();
        TimeSpan Hora = TimeSpan.Parse(ddlNuevaHora.Text);
        DateTime Fecha = Convert.ToDateTime(txtFechaProNueva.Text);
        DateTime fechaReprogramada = Fecha + Hora;
        int codigosol = int.Parse(Session["CodigoSolicitudCita"].ToString());
        Log.WriteLog(txtresultadoChecbox.Value);
        string mensaje = "Datos actualizados";
        objctrcita.ReprogramarCita(codigosol, fechaReprogramada);
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);
    }

    protected void btnReprogramar_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>
                                      $('#modalreprogramar').modal('show');
                                  </script>";
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
    }

    public void reprogramar()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script language='javascript'>");
        sb.Append(@"ValidacionCheckboxAprobado;");
        sb.Append(@"</script>");
        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", sb.ToString(), false);
    }

    protected void ddlNuevaHora_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}