using CTR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;

public partial class Inscribir_Clase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtfecha.Text = System.DateTime.Now.ToShortDateString();
        if (!IsPostBack)
        {
            ddlMes.SelectedValue = DateTime.Now.Month.ToString();
            encontrarsemanas();
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
        string fecha = Session["PrimerDia"].ToString();
        TimeSpan Hora = TimeSpan.Parse(ddlHoras.Text);
        DateTime Fecha = Convert.ToDateTime(fecha);
        DateTime fechaclase = Fecha + Hora;
        Log.WriteLog("Fecha y hora clase"+fechaclase);
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
            dt.Rows.Add(resultadodia + "/" + resultado + "/" + today.Year);
        }
        gvDiasRutinas.DataSource = dt;
        gvDiasRutinas.DataBind();
        upCursos.Update();

    }
    public void obtener_Rutina_Fecha()
    {
        string fecha = Session["PrimerDia"].ToString();
        string TRutina = Session["Tipo_Rutina"].ToString();
        if (TRutina == "1") {
            txtTipoR.Text = "Crossfit";
            txtTipoR.Enabled = false;
        }
        else
        {
            txtTipoR.Text = "Functional";
            txtTipoR.Enabled = false;
        }
        txtfechaClase.Text = fecha;
        
        upFecha_Rutina.Update();

    }

    protected void ddlHoras_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}