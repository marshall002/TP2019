using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Globalization;

public partial class Listar_rutinas_socio : System.Web.UI.Page
{
    DtoUsuario objdtousuario = new DtoUsuario();
    DtoUsuario_X_Rutina objdtousuarioxrutina = new DtoUsuario_X_Rutina();
    CtrUsuario_X_Rutina objctrusuarioxrutina = new CtrUsuario_X_Rutina();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listarRutinasSocio();
        }
    }
    public void listarRutinasSocio()
    {
        objdtousuario.PK_CU_Dni = Session["SessionUsuario"].ToString();
        gvRutinasinscritas.DataSource = objctrusuarioxrutina.ListarRutinas_Usuario(objdtousuario);
        gvRutinasinscritas.DataBind();
    }

    protected void gvRutinasinscritas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRutinasinscritas.PageIndex = e.NewPageIndex;
        listarRutinasSocio();
    }

    protected void gvRutinasinscritas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Actualizar")
        {

            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvRutinasinscritas.DataKeys[index].Values;
                int codrutina = Convert.ToInt32(colsNoVisible[0]);
                string fecha = colsNoVisible[1].ToString();
                string tipor = colsNoVisible[2].ToString();
                Session["cor_R"] = codrutina;
                Session["Tipo_Rutina"] = tipor;
                Session["fecha"] = fecha;
                obtener_Rutina_Fecha();
                string script = @"<script type='text/javascript'>
                                      $('#modalActualizacion').modal('show');
                                  </script>";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
                cargarddlHoras();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);
            }
        }
        if (e.CommandName == "Eliminar")
        {

            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvRutinasinscritas.DataKeys[index].Values;
                int codrutina = Convert.ToInt32(colsNoVisible[0]);
                Session["cor_R"] = codrutina;
                objdtousuarioxrutina.FK_CU_Dni = Session["SessionUsuario"].ToString();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);
            }
        }
    }
    protected void btnActualizar_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btnEliminarInscripcion_ServerClick(object sender, EventArgs e)
    {

    }
    public void obtener_Rutina_Fecha()
    {
        string fecha = Session["fecha"].ToString();
        string TRutina = Session["Tipo_Rutina"].ToString();
        if (TRutina == "Crossfit")
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
        txtfechaClase.Text = fecha + ", " + Convert.ToInt32(dia.DayOfWeek);
        txtfechaClase.Enabled = false;

        upFecha_Rutina.Update();


    }
    public void cargarddlHoras()
    {
        ddlHoras.Items.Clear();
        Log.WriteLog("1");
        string fecha = Session["fecha"].ToString();

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


    protected void ddlHoras_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}