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


    }
    protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver evaluacion")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvLista.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                //string estadosol = colsNoVisible[1].ToString();
                Session["Tipo_Rutina"] = 1;
              
                Log.WriteLog("ID Tipo de rutina seleccionada es :  " + Session["Tipo_Rutina"].ToString());
                Log.WriteLog("Dia seleccionado es:   " + Session["Primerdia"].ToString());
                //if (estadosol != "2")
                //{
                //consultarDatos();
                //obtener_Rutina_Fecha();
                DateTime fecha = Convert.ToDateTime(Session["Primerdia"].ToString());
                // VALIDACION FECHA 
                if (fecha > DateTime.Now)
                {

                    //upEjercicios.Update();
                    string script = @"<script type='text/javascript'>
                                      $('#modalInscripcion').modal('show');
                                  </script>";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Usted no puede registrase....', 'bottom', 'center', null, null);", true);
                }
                  }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

            }
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

    public void cargardatosCitas()
    {
        try
        {
            Log.WriteLog("Entro a cargar datos citas");
            objdtocita.IC_Cod = int.Parse(Session["CodigoSolicitudCita"].ToString());
            Log.WriteLog("1");

            objctrcita.ObtenerInformacionSolicitudCita(objdtocita);
         
            DateTime dtValue = objdtocita.DC_FechaHoraSolicitada;
            textFecha.Text = dtValue.ToString("yyyy-MM-dd");
            textHora.Text = dtValue.ToString("HH:mm");     
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script language='javascript'>");
            sb.Append(@"</script>");
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", sb.ToString(), false);


            textObs.Text = objdtocita.VC_Observacion;
            textFecha.Text = Convert.ToString(objdtocita.DC_FechaHoraSolicitada.ToString("yyyy-MM-dd"));
            Log.WriteLog("objdtocita.IC_Cod" + objdtocita.IC_Cod);
            Log.WriteLog("dtValue" + dtValue);
            Log.WriteLog("objdtocita.VC_Observacion" + objdtocita.VC_Observacion);
            Log.WriteLog("objdtocita.FechaHoraSolicitada" + Convert.ToString(objdtocita.DC_FechaHoraSolicitada.ToString("yyyy-MM-dd")));

        }
        catch (Exception ex)
        {
            Log.WriteLog("Error en EX" + ex.Message);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No tiene los permisos para actualizar', 'bottom', 'center', null, null);", true);

        }
    }
    public void actualizarDatos(string valorRadiobuttonentxt)
    {
        string txtareaconsulta = textObs.Text.Trim();
        TimeSpan Hora = TimeSpan.Parse(textHora.Text);
        DateTime Fecha = Convert.ToDateTime(textFecha.Text);
        DateTime fechasolitada = Fecha + Hora;
        int codigosol = int.Parse(Session["CodigoSolicitudCita"].ToString());
        
        string mensaje = "Datos actualizados";

        objctrcita.actualizarSolicitudCita(codigosol, fechasolitada, txtareaconsulta, int.Parse(valorRadiobuttonentxt));
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);

    }

}

