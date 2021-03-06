﻿using System;
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
    DtoContrato objdtocontrato = new DtoContrato();
    DtoSesionFisio objdtosesionFisio = new DtoSesionFisio();
    DtoSesionNutri objdtosesionNutri = new DtoSesionNutri();
    Log Log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Log.WriteOnLog("Session['id_perfil']"+ Session["id_perfil"]);
            if (Session["id_perfil"] != null)
            {
                if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_ADMINISTRADOR)
                {
                    cargardatosCitas();
                }
                 else
                {
                    Log.WriteOnLog("Proc Citas Sol Detalles - Error en id Perfil");
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {

                Log.WriteOnLog("Proc Citas Sol Detalles - Error en id Perfil");
                Response.Redirect("Inicio.aspx");

            }
        }

    }

    protected void btnGuardar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string valorRadiobuttonentxt = txtresultadoChecbox.Value;
            Log.WriteOnLog("valorRadiobuttonentxt" + valorRadiobuttonentxt);
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
            Log.WriteOnLog("Error en el actualizar aprobar o rechazar :" + ex.Message);
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
            if (TipoCitaSol == "1")
            {
                txtServicios.Text = "Nutricionista";
            }
            else
            {
                txtServicios.Text = "Fisioterapeuta";
            }
            txtDudaConsulta.Text = objdtocita.VC_Observacion;
            txtFecha.Text = Convert.ToString(objdtocita.DC_FechaHoraSolicitada.ToString("yyyy-MM-dd"));
            txtEstadoSolicitud.Text = objdtocita.FK_IEC_Nombre;

            objdtousuario.PK_CU_Dni = objdtocita.FK_CU_DNI;
            try
            {
                objctrusuario.ObtenerInformacionUsuario(objdtousuario, objdtocontrato, objdtosesionFisio, objdtosesionNutri);
                txtUsuarioSolicitante.Text = objdtousuario.VU_Nombre;
                txtApellidos.Text = objdtousuario.VU_APaterno + " " + objdtousuario.VU_AMaterno;
            }
            catch (Exception )
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
        Log.WriteOnLog(txtresultadoChecbox.Value);
        Log.WriteOnLog("Fecha reprogramada "+ fechaReprogramada);
        string mensaje = "Datos actualizados";
        objctrcita.ReprogramarCita(codigosol, fechaReprogramada);
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);
        Response.Redirect("~/Proc_Citas_Sol_Listar.aspx");
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