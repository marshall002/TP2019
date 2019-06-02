using CTR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using System.Globalization;

public partial class Inscribir_Clase : System.Web.UI.Page
{
    DtoUsuario_X_Rutina objdtousuariorutina = new DtoUsuario_X_Rutina();
    CtrUsuario_X_Rutina objctrusuariorutina = new CtrUsuario_X_Rutina();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtfecha.Text = System.DateTime.Now.ToShortDateString();
        if (!IsPostBack)
        {
            if (Session["id_perfil"] != null)
            {
                if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_SOCIO)
                {
                    ddlMes.SelectedValue = DateTime.Now.Month.ToString();
                    encontrarsemanas();
                }
                else
                {
                    Log.WriteLog("Listar rutinas socio - Error en id Perfil");
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {

                Log.WriteLog("Listar rutinas socio - Error en id Perfil");
                Response.Redirect("Inicio.aspx");

            }
        }
    }

    protected void gvDiasRutinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        upCursos.Update();
        encontrarsemanas();
        gvDiasRutinas.PageIndex = e.NewPageIndex;
        gvDiasRutinas.DataBind();
    }

    protected void gvDiasRutinas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VerC")
        {

            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvDiasRutinas.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                //string estadosol = colsNoVisible[1].ToString();
                Session["Tipo_Rutina"] = 1;
                Session["Primerdia"] = id;
                Log.WriteLog("ID Tipo de rutina seleccionada es :  " + Session["Tipo_Rutina"].ToString());
                Log.WriteLog("Dia seleccionado es:   " + Session["Primerdia"].ToString());
                //if (estadosol != "2")
                //{

                obtener_Rutina_Fecha();

                string script = @"<script type='text/javascript'>
                                      $('#modalInscripcion').modal('show');
                                  </script>";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
                cargarddlHoras();

                //}
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Usted no puede eliminar la cita', 'bottom', 'center', null, null);", true);
                //}


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

            }
        }
        if (e.CommandName == "VerF")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvDiasRutinas.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();

                Session["Tipo_Rutina"] = 2;
                Session["Primerdia"] = id;
                Log.WriteLog("ID Tipo de rutina seleccionada es :  " + Session["Tipo_Rutina"].ToString());
                Log.WriteLog("Dia seleccionado es:   " + Session["Primerdia"].ToString());
                obtener_Rutina_Fecha();

                string script = @"<script type='text/javascript'>
                                      $('#modalInscripcion').modal('show');
                                  </script>";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
                cargarddlHoras();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

            }

        }
    }

    protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        upCursos.Update();
        encontrarsemanas();
        upCursos.Update();
    }

    protected void btnInscribir_ServerClick(object sender, EventArgs e)
    {
        Log.WriteLog("entra boton inscribir");
        DtoRutina objrutina = new DtoRutina();
        string fecha = Session["PrimerDia"].ToString();
        TimeSpan Hora = TimeSpan.Parse(ddlHoras.Text);
        DateTime Fecha = DateTime.Parse(fecha);
        Log.WriteLog("fecha:" + Fecha);
        objrutina.DR_FechaRutina = Fecha;
        Log.WriteLog("fecha rutina:" + objrutina.DR_FechaRutina);
        DateTime fechaclase = Fecha + Hora;
        objdtousuariorutina.FK_CU_Dni = Session["SessionUsuario"].ToString();

        Log.WriteLog("dni" + Session["SessionUsuario"].ToString());
        Log.WriteLog("cod rutina" + objctrusuariorutina.retornaRutinaId(Fecha.ToString("yyyy/MM/dd"), int.Parse(Session["Tipo_Rutina"].ToString())));
        objdtousuariorutina.FK_IR_Cod = objctrusuariorutina.retornaRutinaId(Fecha.ToString("yyyy/MM/dd"), int.Parse(Session["Tipo_Rutina"].ToString()));
        objdtousuariorutina.DR_FechaHora = DateTime.Parse(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));
        Log.WriteLog("fechahora " + fechaclase.ToString("yyyy-MM-dd HH':'mm':'ss"));
        objdtousuariorutina.FK_IH_Cod = objctrusuariorutina.retornaHoraId(ddlHoras.Text);
        int tiporutina = int.Parse(Session["Tipo_Rutina"].ToString());
        int idr = objctrusuariorutina.retornaRutinaId(Fecha.ToString("yyyy/MM/dd"), int.Parse(Session["Tipo_Rutina"].ToString()));
        int idh = objctrusuariorutina.retornaHoraId(ddlHoras.Text);
        Log.WriteLog("fechaclase" + fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));
        bool resultadobuscadorfecharegistrada = objctrusuariorutina.buscarfechaInsc(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"), Session["SessionUsuario"].ToString(), tiporutina);

        Log.WriteLog("-------------------------------------------------");
        Log.WriteLog(" Resultado de funcion  objctrusuariorutina.retornaNumeroParticipantes(idr, idh)  : " + objctrusuariorutina.retornaNumeroParticipantes(idr, idh));
        Log.WriteLog("-------------------------------------------------");
        bool valNumXclase = objctrusuariorutina.validarNClasesXdia(Fecha.ToString("yyyy-MM-dd'T'HH':'mm':'ss"), Session["SessionUsuario"].ToString());
        Log.WriteLog("fecha:" + Fecha.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));
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

        Log.WriteLog("Fecha y hora clase" + fechaclase);

    }
    public void encontrarsemanas()
    {
        DateTime today = DateTime.Now;
        //EXTRAEMOS EL MES
        int daysInMonth = DateTime.DaysInMonth(today.Year, int.Parse(ddlMes.SelectedValue));
        Log.WriteLog("Dias de semana: " + daysInMonth);
        DateTime firstOfMonth = new DateTime(today.Year, today.Month, 1);
        Log.WriteLog("firstOfMonth: " + firstOfMonth);


        //DIAS DEL MES COMIENZA DEL DOMINGO =0
        int firstDayOfMonth = (int)firstOfMonth.DayOfWeek;
        Log.WriteLog("Primer dia de mes: " + firstDayOfMonth);

        int weeksInMonth = (int)Math.Ceiling((firstDayOfMonth + daysInMonth) / 7.0);
        Log.WriteLog("weeksInMonth" + weeksInMonth);

        DataTable dt = new DataTable();
        DataColumn n1 = dt.Columns.Add("n1", typeof(string));
        DataColumn n2 = dt.Columns.Add("n2", typeof(string));
        //DataColumn n3 = dt.Columns.Add("n3", typeof(string));
        //DataColumn n4 = dt.Columns.Add("n9", typeof(Int64));

        for (int i = 1; i <= daysInMonth; i++)
        {
            string resultadodia = i.ToString();
            if (i < 10)
            {
                resultadodia = "0" + i;
            }
            string resultado = ddlMes.SelectedValue;
            if (int.Parse(ddlMes.SelectedValue) < 10)
            {
                resultado = "0" + ddlMes.SelectedValue;
            }

            string resultadoamostrar = resultadodia + "/" + resultado + "/" + today.Year;
            DateTime dia = DateTime.Parse(resultadoamostrar);
            CultureInfo test = new System.Globalization.CultureInfo("es-ES");
            string diaespaniol = test.DateTimeFormat.GetDayName(dia.DayOfWeek);

            dt.Rows.Add(resultadoamostrar, diaespaniol);
        }
        gvDiasRutinas.DataSource = dt;
        gvDiasRutinas.DataBind();
        upCursos.Update();

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

    protected void ddlHoras_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void cargarddlHoras()
    {
        ddlHoras.Items.Clear();
        Log.WriteLog("1");
        string fecha = Session["PrimerDia"].ToString();

        Log.WriteLog("2");
        DateTime dia = DateTime.Parse(fecha);
        Log.WriteLog("3");
        //txtfechaClase.Text = fecha + ", " + dia.DayOfWeek.ToString();
        if (Convert.ToInt32(dia.DayOfWeek) == 0)
        {
            Log.WriteLog("dia:" + Convert.ToInt32(dia.DayOfWeek));
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
            Log.WriteLog("Convert.ToInt32(dia.DayOfWeek)" + Convert.ToInt32(dia.DayOfWeek));
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