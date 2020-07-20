using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using DAO;
using CTR;

public partial class AdministrarCitaNutri : System.Web.UI.Page
{
    CtrCita objctrcita = new CtrCita();
    DaoCita objdaocita = new DaoCita();
    DtoCita objdtocita = new DtoCita();
  

    //DtoCita objdtoCita = new DtoCita();
    //CtrUsuario objctrusuario = new CtrUsuario();
    //DtoUsuario objdtousuario = new DtoUsuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["id_perfil"] != null)
            {
                if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_NUTRICIONISTA)
                {
                    gvLista.DataSource = objctrcita.LCitaNutri();
                    gvLista.DataBind();
                }
                else
                {
                    Log.WriteOnLog("Citas Nutri Administracion - Error en id Perfil");
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {
                Log.WriteOnLog("Citas Nutri Administracion - Error en id Perfil");
                Response.Redirect("Inicio.aspx");

            }
        }


        }
    protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Asistencia")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvLista.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                //string estadosol = colsNoVisible[1].ToString();
                Session["CodigoSolicitudCita"] = id;
                string nombre= colsNoVisible[1].ToString();
                Session["nombre"] = nombre;
                string fecha = colsNoVisible[2].ToString();
                Session["fechaCita"] =fecha ;
                string obs = colsNoVisible[4].ToString();
                Session["obs"] = obs ;
                //if (estadosol != "2")
                //{
                //consultarDatos();
                //obtener_Rutina_Fecha();
                cargardatosCitas();

                
                ddlNuevaHora.Enabled = false;
                txtFechaProNueva.Enabled = false;
                upcitaNutri.Update();
                string script = @"<script type='text/javascript'>
                                      $('#VerDetalleMod').modal('show');
                                  </script>";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
                    
                
                  }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

            }
            
        }
}


    protected void btnReprogramar_Click(object sender, EventArgs e)
    {
        txtFechaProNueva.Enabled = true;
        ddlNuevaHora.Enabled = true;
        btnGuardar.Text = "REPROGRAMAR";
        upbotones.Update();
    }

    public void cargardatosCitas()
    {
        try
        {
            Log.WriteOnLog("Entro a cargar datos citas");
            objdtocita.IC_Cod = int.Parse(Session["CodigoSolicitudCita"].ToString());
            Log.WriteOnLog("1");
            btnGuardar.Text = "GUARDAR";
            objctrcita.ObtenerInformacionSolicitudCita(objdtocita);
            textNombre.Text = Session["nombre"].ToString();
            DateTime dtValue =Convert.ToDateTime(Session["fechaCita"].ToString());
            txtFechaProNueva.Text = dtValue.ToString("yyyy-MM-dd");
            //txtFechaProNueva.Enabled = false;
            ddlNuevaHora.SelectedValue = dtValue.ToString("HH:mm");
            ddlNuevaHora.Enabled = false;
            textObs.Text= Session["obs"].ToString();
        }
        catch (Exception ex)
        {
            Log.WriteOnLog("Error en EX" + ex.Message);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No tiene los permisos para actualizar', 'bottom', 'center', null, null);", true);

        }
    }
    public void actualizarDatos(string valorRadiobuttonentxt)
    {
        string txtareaconsulta = textObs.Text.Trim();
        TimeSpan Hora = TimeSpan.Parse(ddlNuevaHora.SelectedValue);
        DateTime Fecha = Convert.ToDateTime(txtFechaProNueva.Text);
        DateTime fechasolitada = Fecha + Hora;
        int codigosol = int.Parse(Session["CodigoSolicitudCita"].ToString());
        
        string mensaje = "Datos actualizados";

        objctrcita.actualizarSolicitudCita(codigosol, fechasolitada, txtareaconsulta, int.Parse(valorRadiobuttonentxt));
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);

    }


    protected void btnAsistencia_ServerClick(object sender, EventArgs e)
    {
        int cod = Convert.ToInt32(Session["CodigoSolicitudCita"]);
        actualizardatos(txtasistenciaChecbox.Value);
        string mensaje = "Cita Actualizada";
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);

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

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (btnGuardar.Text == "REPROGRAMAR")
        {
            int codigosol = Convert.ToInt32(Session["CodigoSolicitudCita"].ToString());
            TimeSpan Hora = TimeSpan.Parse(ddlNuevaHora.SelectedValue);
            DateTime Fecha = Convert.ToDateTime(txtFechaProNueva.Text);
            DateTime fechaReprogramada = Fecha + Hora;
            string mensaje = "Datos actualizados";
            objctrcita.ReprogramarCita(codigosol, fechaReprogramada);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);
            Response.Redirect("AdministrarCitaNutri.aspx");
        }
        else
        {
            int cod = Convert.ToInt32(Session["CodigoSolicitudCita"]);
            actualizardatos(txtasistenciaChecbox.Value);
            string mensaje = "Cita Actualizada";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);
            Response.Redirect("AdministrarCitaNutri.aspx");
        }
    }
}

