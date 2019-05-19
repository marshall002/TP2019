using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdministrarRutina : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtfecha.Text = System.DateTime.Now.ToShortDateString();
        //ddlMes.SelectedItem = DateTime.Now.ToShortDateString();
        //txtfecha.SelectedDate.ToLongDateString();
        //fnCargarDDL();

        DataTable dt = new DataTable();
        DataColumn n1 = dt.Columns.Add("n1", typeof(string));
        DataColumn n2 = dt.Columns.Add("n2", typeof(string));
        DataColumn n3 = dt.Columns.Add("n3", typeof(string));
        DataColumn n4 = dt.Columns.Add("n9", typeof(Int64));

        dt.Rows.Add("29/04/2018", "05/05/2018");
        dt.Rows.Add("06/05/2018", "12/05/2018");
        dt.Rows.Add("13/05/2018", "19/05/2018");
        dt.Rows.Add("20/05/2018", "26/05/2018");
        gvLista.DataSource = dt;
        gvLista.DataBind();
    }
    protected void Registro_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministrarRutina.aspx", false);
    }
    protected void Regreso_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministrarRutina.aspx", false);
    }
}