using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Globalization;

public partial class InsRutina_2 : System.Web.UI.Page
{
    CtrRutina objctrRutina = new CtrRutina();
    DtoUsuario_X_Rutina objdtousuariorutina = new DtoUsuario_X_Rutina();
    CtrUsuario_X_Rutina objctrusuariorutina = new CtrUsuario_X_Rutina();
    Log _log = new Log();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarEjercicios();
            cargarddlHoras();
            obtener_Rutina_Fecha();
        }
    }
    protected void btnGuardar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            _log.CustomWriteOnLog("InsRutina_2", "entra boton inscribir");
            DtoRutina objrutina = new DtoRutina();
            string fecha = Session["PrimerDia"].ToString();
            TimeSpan Hora = TimeSpan.Parse(ddlHoras.Text);
            DateTime Fecha = DateTime.Parse(fecha);
            _log.CustomWriteOnLog("InsRutina_2", "fecha:" + Fecha);
            objrutina.DR_FechaRutina = Fecha;
            _log.CustomWriteOnLog("InsRutina_2", "fecha rutina:" + objrutina.DR_FechaRutina);
            DateTime fechaclase = Fecha + Hora;
            objdtousuariorutina.FK_CU_Dni = Session["SessionUsuario"].ToString();

            _log.CustomWriteOnLog("InsRutina_2", "dni" + Session["SessionUsuario"].ToString());
            _log.CustomWriteOnLog("InsRutina_2", "cod rutina" + objctrusuariorutina.retornaRutinaId(Fecha.ToString("yyyy/MM/dd"), int.Parse(Session["Tipo_Rutina"].ToString())));
            objdtousuariorutina.FK_IR_Cod = objctrusuariorutina.retornaRutinaId(Fecha.ToString("yyyy/MM/dd"), int.Parse(Session["Tipo_Rutina"].ToString()));
            objdtousuariorutina.DR_FechaHora = DateTime.Parse(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));
            _log.CustomWriteOnLog("InsRutina_2", "fechahora " + fechaclase.ToString("yyyy-MM-dd HH':'mm':'ss"));
            objdtousuariorutina.FK_IH_Cod = objctrusuariorutina.retornaHoraId(ddlHoras.Text);
            int tiporutina = int.Parse(Session["Tipo_Rutina"].ToString());
            int idr = objctrusuariorutina.retornaRutinaId(Fecha.ToString("yyyy/MM/dd"), int.Parse(Session["Tipo_Rutina"].ToString()));
            int idh = objctrusuariorutina.retornaHoraId(ddlHoras.Text);
            _log.CustomWriteOnLog("InsRutina_2", "fechaclase" + fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));
            bool resultadobuscadorfecharegistrada = objctrusuariorutina.buscarfechaInsc(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"), Session["SessionUsuario"].ToString(), tiporutina);

            _log.CustomWriteOnLog("InsRutina_2", "-------------------------------------------------");
            _log.CustomWriteOnLog("InsRutina_2", " Resultado de funcion  objctrusuariorutina.retornaNumeroParticipantes(idr, idh)  : " + objctrusuariorutina.retornaNumeroParticipantes(idr, idh));
            _log.CustomWriteOnLog("InsRutina_2", "-------------------------------------------------");
            bool valNumXclase = objctrusuariorutina.validarNClasesXdia(Fecha.ToString("yyyy-MM-dd'T'HH':'mm':'ss"), Session["SessionUsuario"].ToString());
            _log.CustomWriteOnLog("InsRutina_2", "fecha:" + Fecha.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));
            if (valNumXclase == false)
            {
                if (resultadobuscadorfecharegistrada == false
                    && objctrusuariorutina.retornaNumeroParticipantes(idr, idh) <= 15
                    )
                {
                    objctrusuariorutina.registrarUsuario_rutina(objdtousuariorutina);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + "registro exitoso" + "', 'bottom', 'center', null, null);", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + "existe inscripcion en la misma hora" + "', 'bottom', 'center', null, null);", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + "exede el número de rutinas por dia" + "', 'bottom', 'center', null, null);", true);
            }

            _log.CustomWriteOnLog("InsRutina_2", "Fecha y hora clase" + fechaclase);
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("InsRutina_2", "Error" + ex.Message);

        }
            
       
    }
    protected void btnCancelar_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Inscribir_Rutina.aspx");
    }
    public void obtener_Rutina_Fecha()
    {
        string fecha = Session["PrimerDia"].ToString();
        string TRutina = Session["Tipo_Rutina"].ToString();
        if (TRutina == "1")
        {
            txtTipoR.Text = "Crossfit";
            txtTipoR.Enabled = false;
        }
        else
        {
            txtTipoR.Text = "Functional";
            txtTipoR.Enabled = false;
        }
        DateTime dia = DateTime.Parse(fecha);
        CultureInfo test = new System.Globalization.CultureInfo("es-ES");
        string diaespaniol = test.DateTimeFormat.GetDayName(dia.DayOfWeek);
        txtfechaClase.Text = fecha + ", " + diaespaniol;
        txtfechaClase.Enabled = false;

        upFecha_Rutina.Update();


    }
    public void CargarEjercicios()
    {
        try
        {
            _log.CustomWriteOnLog("InsRutina_2","Entro a funcion cargar ejercicios");
            DtoRutina objdtoRutina = new DtoRutina();
            objdtoRutina.FK_ITR_Cod = Convert.ToInt32(Session["Tipo_Rutina"]);
            _log.CustomWriteOnLog("InsRutina_2"," obj dtio rutina "+ objdtoRutina.FK_ITR_Cod);

            DateTime FechaSel = Convert.ToDateTime(Session["PrimerDia"]);
            string fecha = FechaSel.ToString("yyyy-MM-dd'T'HH':'mm':'ss");
            _log.CustomWriteOnLog("InsRutina_2","fecha " + fecha);

            GvEjercicios.DataSource = objctrRutina.verRutinaE(objdtoRutina, fecha);
            GvEjercicios.DataBind();
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("InsRutina_2","error cargar ejecricios: " + ex.Message);
            throw;
        }
      

    }
    public void cargarddlHoras()
    {
        ddlHoras.Items.Clear();
        _log.CustomWriteOnLog("InsRutina_2","1");
        string fecha = Session["PrimerDia"].ToString();

        _log.CustomWriteOnLog("InsRutina_2","2");
        DateTime dia = DateTime.Parse(fecha);
        _log.CustomWriteOnLog("InsRutina_2","3");
        //txtfechaClase.Text = fecha + ", " + dia.DayOfWeek.ToString();
        if (Convert.ToInt32(dia.DayOfWeek) == 0)
        {
            _log.CustomWriteOnLog("InsRutina_2","dia:" + Convert.ToInt32(dia.DayOfWeek));
            ListItem i;
            i = new ListItem("8:00 AM", "08:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("9:00 AM", "09:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("10:00 AM", "10:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("11:00 AM", "11:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("12:00 PM", "12:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("1:00 PM", "13:00");
            ddlHoras.Items.Add(i);

        }
        else
        {
            _log.CustomWriteOnLog("InsRutina_2","Convert.ToInt32(dia.DayOfWeek)" + Convert.ToInt32(dia.DayOfWeek));
            ListItem i;
            i = new ListItem("8:00 AM", "08:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("9:00 AM", "09:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("10:00 AM", "10:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("11:00 AM", "11:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("12:00 PM", "12:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("1:00 PM", "13:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("2:00 PM", "14:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("3:00 PM", "15:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("4:00 PM", "16:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("5:00 PM", "17:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("6:00 PM", "18:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("7:00 PM", "19:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("8:00 PM", "20:00");
            ddlHoras.Items.Add(i);
            i = new ListItem("9:00 PM", "21:00");
            ddlHoras.Items.Add(i);
        }
        Udp_ddlhoras.Update();
    }
}