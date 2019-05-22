using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;

public partial class AdministrarRutina : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtfecha.Text = System.DateTime.Now.ToShortDateString();
        //ddlMes.SelectedValue = DateTime.Now.Month.ToString();
            

        if (!IsPostBack)
        {
            encontrarsemanas();
        }


        //ddlMes.SelectedItem = DateTime.Now.ToShortDateString();
        //txtfecha.SelectedDate.ToLongDateString();
        //fnCargarDDL();

        //DataTable dt = new DataTable();
        //DataColumn n1 = dt.Columns.Add("n1", typeof(string));
        //DataColumn n2 = dt.Columns.Add("n2", typeof(string));
        //DataColumn n3 = dt.Columns.Add("n3", typeof(string));
        //DataColumn n4 = dt.Columns.Add("n9", typeof(Int64));

        //dt.Rows.Add("29/04/2018", "05/05/2018");
        //dt.Rows.Add("06/05/2018", "12/05/2018");
        //dt.Rows.Add("13/05/2018", "19/05/2018");
        //dt.Rows.Add("20/05/2018", "26/05/2018");
        //gvLista.DataSource = dt;
        //gvLista.DataBind();

    }
    protected void Registro_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministrarRutina.aspx", false);
    }
    protected void Regreso_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministrarRutina.aspx", false);
    }

    public void encontrarsemanas()
    {
        DateTime today = DateTime.Now;
        //EXTRAEMOS EL MES
        int daysInMonth = DateTime.DaysInMonth(today.Year, int.Parse(ddlMes.SelectedValue));
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
            //for (int j = 0; j <= 2; j++)
            //{

            //    dt.Rows.Add();
            //}
            if (i == i + 7)
            {
                dt.Rows.Add(i, i + 7);
            }
            dt.Rows.Add(i, i + 7);
        }


        //dt.Rows.Add("29/04/2018", "05/05/2018");
        //dt.Rows.Add("06/05/2018", "12/05/2018");
        //dt.Rows.Add("13/05/2018", "19/05/2018");
        //dt.Rows.Add("20/05/2018", "26/05/2018");
        gvLista.DataSource = dt;
        gvLista.DataBind();
        upCursos.Update();


    }



    protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        encontrarsemanas();
        gvLista.PageIndex = e.NewPageIndex;
        gvLista.DataBind();
    }

    protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        upCursos.Update();
        encontrarsemanas();
        upCursos.Update();
    }
}