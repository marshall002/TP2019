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
using System.Globalization;

public partial class AdministrarRutina : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        txtfecha.Text = System.DateTime.Now.ToShortDateString();
        if (!IsPostBack)
        {
            if (Session["id_perfil"] != null)
            {
                if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_ENTRENADOR)
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
        Log.WriteLog("weeksInMonth" + (int)DateTime.Now.Day);

        DataTable dt = new DataTable();
        DataColumn n1 = dt.Columns.Add("n1", typeof(string));
        DataColumn n2 = dt.Columns.Add("n2", typeof(string));
        //DataColumn n3 = dt.Columns.Add("n3", typeof(string));
        //DataColumn n4 = dt.Columns.Add("n9", typeof(Int64));

        for (int i = 1  ; i <= daysInMonth; i++)
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


    protected void gvLista_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VerC")
        {
            Log.WriteLog("1");
            int index = Convert.ToInt32(e.CommandArgument);
            Log.WriteLog("2");
            var colsNoVisible = gvLista.DataKeys[index].Values;
            Log.WriteLog("3");
            string id = colsNoVisible[0].ToString();
            Log.WriteLog("4");

            DateTime fec = Convert.ToDateTime(id);
            Session["Tipo_Rutina"] = 1;
            Session["Primerdia"] = fec;
            Log.WriteLog("5");
            Log.WriteLog("ID Tipo de rutina seleccionada es :  " + Session["Tipo_Rutina"].ToString());

            //Session["Fecha_Seleccionada"] = a;
            Log.WriteLog("Dia seleccionado es:   " + Session["Primerdia"].ToString());
            TituloTRut.Text = "Crossfit";
            consultarDatos();
            Log.WriteLog("6");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal2').modal('show');", true);
            Response.Redirect("AdministrarRutina_Extra.aspx");
        }
        if (e.CommandName == "VerF")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvLista.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();

            DateTime fec = Convert.ToDateTime(id);
            Session["Tipo_Rutina"] = 2;
            //Session["Primerdia"] = id;
            Session["Primerdia"] = fec;
            Log.WriteLog("ID Tipo de rutina seleccionada es :  " + Session["Tipo_Rutina"].ToString());
            Log.WriteLog("Dia seleccionado es:   " + Session["Primerdia"].ToString());
            TituloTRut.Text = "Funcional";
            consultarDatos();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal2').modal('show');", true);
            Response.Redirect("AdministrarRutina_Extra.aspx");
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
            consultarDatos();
            obtener_Rutina_Fecha();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal').modal('show');", true);
            Response.Redirect("AdministrarRutina_Extra.aspx");

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
            consultarDatos();
            obtener_Rutina_Fecha();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal').modal('show');", true);

        }
    }
    [System.Web.Services.WebMethod]
    //public static ListSelect GetList()
    //{
    //    CtrTipo_Ejercicio objCtrTipo_Ejercicio = new CtrTipo_Ejercicio();
    //    var Tipoejercicio = objCtrTipo_Ejercicio.CargaDatosTEjercicio();
    //    CtrEjercicio objCtrEjercicio = new CtrEjercicio();
    //    var ejercicio = objCtrEjercicio.CargaDatosEjercicio();
    //    var a = ejercicio.AsEnumerable().ToList();
    //    List<DtoTipo_Ejercicio> listTipoEjercicio = Tipoejercicio.AsEnumerable().Select(m => new DtoTipo_Ejercicio()
    //    {
    //        PK_ITE_Cod = Convert.ToInt32(m.ItemArray[0]),
    //        VTE_Nombre = m.ItemArray[1].ToString()
    //    }).ToList();
    //    List<DtoEjercicio> listEjercicio = ejercicio.AsEnumerable().Select(m => new DtoEjercicio()
    //    {
    //        PK_IE_Cod = Convert.ToInt32(m.ItemArray[0]),
    //        FK_ITE_Cod = Convert.ToInt32(m.ItemArray[2]),
    //        VE_Nombre = m.ItemArray[1].ToString(),
    //    }).ToList();
    //    var list = new ListSelect();
    //    list.dtoEjercicios = listEjercicio;
    //    list.dtoTipoEjercicios = listTipoEjercicio;
    //    return list;
    //}
    //[System.Web.Services.WebMethod]
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
        public List<DtoEjercicio> dtoEjercicios { get; set; }
        public List<DtoTipo_Ejercicio> dtoTipoEjercicios { get; set; }
    }

    public void obtener_Rutina_Fecha()
    {
        string fecha = Session["PrimerDia"].ToString();
        string TRutina = Session["Tipo_Rutina"].ToString();

        DateTime dia = DateTime.Parse(fecha);
        CultureInfo test = new System.Globalization.CultureInfo("es-ES");
        string diaespaniol = test.DateTimeFormat.GetDayName(dia.DayOfWeek);
        txtfechaRuti.Text = fecha + ", " + diaespaniol;
        txtfechaRuti.Enabled = false;

        UpdatePanel1.Update();


    }

    protected void btnGuardar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtfechaRuti.Text != "" || txtdescripcion.Text != "")
            {

                CtrRutina objctrRutina = new CtrRutina();
                DtoRutina objdtoRutina = new DtoRutina();
                string fecha = Session["PrimerDia"].ToString();
                DateTime Fecha = DateTime.Parse(fecha);

                DateTime fechaclase = Fecha;
                objdtoRutina.DR_FechaRutina = DateTime.Parse(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));

                objdtoRutina.FK_ITR_Cod = int.Parse(Session["Tipo_Rutina"].ToString());
                objdtoRutina.VR_Descripcion = txtdescripcion.Text;
                objctrRutina.Registrar_Rutina(objdtoRutina);
                txtdescripcion.Text = "";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Registrado correctamente', 'bottom', 'center', null, null);", true);

            }
        }
        catch (Exception ex)
        {
            Log.WriteLog("Error: " + ex.Message);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red','" + ex.Message + "', 'bottom', 'center', null, null);", true);

        }

    }

    protected void btnactualizar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            actualizarRutina();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Actualizado correctamente', 'bottom', 'center', null, null);", true);

        }
        catch (Exception ex)
        {
            Log.WriteLog("Ex acutalizar error:  " + ex.Message);
        }

    }

    protected void btneliminar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            EliminarRutina();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Eliminado correctamente', 'bottom', 'center', null, null);", true);

        }
        catch (Exception ex)
        {
            Log.WriteLog("Ex eliminar error:  " + ex.Message);
        }
    }
    public void consultarDatos()
    {
        DtoRutina objdtoRutina = new DtoRutina();
        CtrRutina objctrRutina = new CtrRutina();
        string fecha = Session["Primerdia"].ToString();
        DateTime Fecha = DateTime.Parse(fecha);

        DateTime fechaclase = Fecha;
        objdtoRutina.DR_FechaRutina = DateTime.Parse(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));

        objdtoRutina.FK_ITR_Cod = int.Parse(Session["Tipo_Rutina"].ToString());
        objctrRutina.Obtener_Rutina(objdtoRutina);

        Log.WriteLog("objdotioRutina" + objdtoRutina.PK_IR_Cod);
        Log.WriteLog("objdotioRutina" + objdtoRutina.VR_Descripcion);


        DateTime dia = DateTime.Parse(fecha);
        CultureInfo test = new System.Globalization.CultureInfo("es-ES");
        string diaespaniol = test.DateTimeFormat.GetDayName(dia.DayOfWeek);
        txtfechaVer.Text = fecha + ", " + diaespaniol;
        txtfechaRuti.Enabled = false;
        txtVerDesc.Text = objdtoRutina.VR_Descripcion;
        UpdatePanel2.Update();
    }
    public void actualizarRutina()
    {
        DtoRutina objdtoRutina = new DtoRutina();
        CtrRutina objctrRutina = new CtrRutina();
        string fecha = Session["PrimerDia"].ToString();
        DateTime Fecha = DateTime.Parse(fecha);

        DateTime fechaclase = Fecha;
        objdtoRutina.DR_FechaRutina = DateTime.Parse(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));

        objdtoRutina.FK_ITR_Cod = int.Parse(Session["Tipo_Rutina"].ToString());
        objctrRutina.Obtener_Rutina(objdtoRutina);

        Log.WriteLog("objdotioRutina" + objdtoRutina.PK_IR_Cod);
        Log.WriteLog("objdotioRutina" + objdtoRutina.VR_Descripcion);
        objdtoRutina.VR_Descripcion = txtVerDesc.Text;

        objctrRutina.Actualizar_Rutina(objdtoRutina);

    }
    public void EliminarRutina()
    {
        DtoRutina objdtoRutina = new DtoRutina();
        CtrRutina objctrRutina = new CtrRutina();
        string fecha = Session["PrimerDia"].ToString();
        DateTime Fecha = DateTime.Parse(fecha);

        DateTime fechaclase = Fecha;
        objdtoRutina.DR_FechaRutina = DateTime.Parse(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));

        objdtoRutina.FK_ITR_Cod = int.Parse(Session["Tipo_Rutina"].ToString());
        objctrRutina.Obtener_Rutina(objdtoRutina);

        Log.WriteLog("objdotioRutina" + objdtoRutina.PK_IR_Cod);

        objctrRutina.Eliminar_Rutina(objdtoRutina);

    }
}