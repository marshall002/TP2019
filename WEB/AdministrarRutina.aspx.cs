using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using CTR;
using DAO;
using DTO;

public partial class AdministrarRutina : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        txtfecha.Text = System.DateTime.Now.ToShortDateString();
        if (!IsPostBack)
        {
            ddlMes.SelectedValue = DateTime.Now.Month.ToString();
            encontrarsemanas();
            //CargarTEjercicio();
            //CargarEjercicio();
            
        }
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
        gvLista.DataSource = dt;
        gvLista.DataBind();
        upCursos.Update();

    }
    protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        upCursos.Update();
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

    //private void CargarTEjercicio()
    //{
    //    CtrTipo_Ejercicio objCtrTipo_Ejercicio = new CtrTipo_Ejercicio();

    //    ddlTEjercicio.DataSource = objCtrTipo_Ejercicio.CargaDatosTEjercicio();
    //    ddlTEjercicio.DataTextField = "VTE_Nombre";
    //    ddlTEjercicio.DataValueField = "PK_ITE_Cod";
    //    ddlTEjercicio.DataBind();
    //    ddlTEjercicio.Items.Insert(0, new ListItem("Seleccione","0"));
    //}

    //private void CargarEjercicio()
    //{
    //    CtrEjercicio objCtrEjercicio = new CtrEjercicio();

    //    ddlEjercicio.DataSource = objCtrEjercicio.CargaDatosEjercicio();
    //    ddlEjercicio.DataTextField = "VE_Nombre";
    //    ddlEjercicio.DataValueField = "PK_IE_Cod";
    //    ddlEjercicio.DataBind();
    //    ddlEjercicio.Items.Insert(0, new ListItem("Seleccione", "0"));
    //}
    
    protected void gvLista_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VerC")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvLista.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();

            Session["Tipo_Rutina"] = 1;
            Session["Primerdia"] = id;
            Log.WriteLog("ID Tipo de rutina seleccionada es :  " + Session["Tipo_Rutina"].ToString());
            Log.WriteLog("Dia seleccionado es:   " + Session["Primerdia"].ToString());
            TituloTRut.Text = "Crossfit";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal').modal('show');", true);
        }
        if (e.CommandName == "VerF")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvLista.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();

            Session["Tipo_Rutina"] = 2;
            Session["Primerdia"] = id;
            Log.WriteLog("ID Tipo de rutina seleccionada es :  " + Session["Tipo_Rutina"].ToString());
            Log.WriteLog("Dia seleccionado es:   " + Session["Primerdia"].ToString());
            TituloTRut.Text = "Funcional";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal').modal('show');", true);
        }
        if (e.CommandName == "RegistrarC")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvLista.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();

            Session["Tipo_Rutina"] = 1;
            Session["Primerdia"] = id;
            Log.WriteLog("ID Tipo de rutina seleccionada es :  " + Session["Tipo_Rutina"].ToString());
            Log.WriteLog("Dia seleccionado es:   " + Session["Primerdia"].ToString());
            TituloTRut.Text = "Crossfit";
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal').modal('show');", true);
            
        }
        if (e.CommandName == "RegistrarF")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvLista.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();

            Session["Tipo_Rutina"] = 2;
            Session["Primerdia"] = id;
            Log.WriteLog("ID Tipo de rutina seleccionada es :  " + Session["Tipo_Rutina"].ToString());
            Log.WriteLog("Dia seleccionado es:   " + Session["Primerdia"].ToString());
            TituloTRut.Text = "Funcional";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal').modal('show');", true);
        }
    }
    [System.Web.Services.WebMethod]
    public static ListSelect GetList()
    {
        CtrTipo_Ejercicio objCtrTipo_Ejercicio = new CtrTipo_Ejercicio();
        var Tipoejercicio = objCtrTipo_Ejercicio.CargaDatosTEjercicio();
        CtrEjercicio objCtrEjercicio = new CtrEjercicio();
        var ejercicio = objCtrEjercicio.CargaDatosEjercicio();
        var a = ejercicio.AsEnumerable().ToList();
        List<DtoTipo_Ejercicio> listTipoEjercicio = Tipoejercicio.AsEnumerable().Select(m => new DtoTipo_Ejercicio()
        {
            PK_ITE_Cod = Convert.ToInt32(m.ItemArray[0]),
            VTE_Nombre = m.ItemArray[1].ToString()
        }).ToList();
        List<DtoEjercicio> listEjercicio = ejercicio.AsEnumerable().Select(m => new DtoEjercicio()
        {
            PK_IE_Cod = Convert.ToInt32(m.ItemArray[0]),
            FK_ITE_Cod = Convert.ToInt32(m.ItemArray[2]),
            VE_Nombre = m.ItemArray[1].ToString(),
        }).ToList();
        var list = new ListSelect();
        list.dtoEjercicios = listEjercicio;
        list.dtoTipoEjercicios = listTipoEjercicio;
        return list;
    }
    [System.Web.Services.WebMethod]
    public static ListSelect GetEjercicioByTipoEjercicio(int idTipoUsuario)
    {
        CtrEjercicio objCtrEjercicio = new CtrEjercicio();
        var ejercicio = objCtrEjercicio.CargaDatosEjercicioXT(idTipoUsuario);
        List<DtoEjercicio> listEjercicio = ejercicio.AsEnumerable().Select(m => new DtoEjercicio()
        {
            PK_IE_Cod = Convert.ToInt32(m.ItemArray[0]),
            FK_ITE_Cod = Convert.ToInt32(m.ItemArray[2]),
            VE_Nombre = m.ItemArray[1].ToString(),
        }).ToList();
        var list = new ListSelect();
        list.dtoEjercicios = listEjercicio;
        return list;
    }
    public class ListSelect
    {
        public List<DtoEjercicio> dtoEjercicios {get;set;}
        public List<DtoTipo_Ejercicio> dtoTipoEjercicios {get;set;}
    }
}