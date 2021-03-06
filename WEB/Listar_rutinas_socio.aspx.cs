﻿using System;
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
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["id_perfil"] != null)
            {
                if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_SOCIO)
                {
                    listarRutinasSocio();

                }
                else
                {
                    
                    _log.CustomWriteOnLog("Listar_rutinas_socio","Listar rutinas socio - Error en id Perfil");
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {

                _log.CustomWriteOnLog("Listar_rutinas_socio","Listar rutinas socio - Error en id Perfil");
                Response.Redirect("Inicio.aspx");

            }

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
        upCursos.Update();
        listarRutinasSocio();
        gvRutinasinscritas.PageIndex = e.NewPageIndex;
        gvRutinasinscritas.DataBind();
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
                string fechahora = colsNoVisible[2].ToString();
                string tipor = colsNoVisible[3].ToString();
                Session["cor_R"] = codrutina;
                Session["Tipo_Rutina"] = tipor;
                Session["fecha"] = fecha;
                Session["fechahora"] = fechahora;
                consultarDatos();
                obtener_Rutina_Fecha();
                if (Convert.ToDateTime(fecha)> DateTime.Now)
                {
                    string script = @"<script type='text/javascript'>
                                      $('#modalActualizacion').modal('show');
                                  </script>";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
                    cargarddlHoras(); }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Usted no puede actualizar en las rutinas anteriores al dia de hoy', 'bottom', 'center', null, null);", true);
                }
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
                string fechahora = colsNoVisible[2].ToString();
                string fecha = colsNoVisible[1].ToString();
                Session["cor_R"] = codrutina;
                Session["fechaHora"] = fechahora;
                Session["fecha"] = fecha;
                if (Convert.ToDateTime(fecha) > DateTime.Now)
                {
                    string script = @"<script type='text/javascript'>
                                      $('#modalconfirmacioneliminarIns').modal('show');
                                  </script>";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Usted no puede eliminar en las rutinas anteriores al dia de hoy', 'bottom', 'center', null, null);", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);
            }
        }
    }
    protected void btnActualizar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (validacionHora() == false)
            {
                string f = Session["fecha"].ToString();
                DateTime fecha = DateTime.Parse(f);
                TimeSpan Hora = TimeSpan.Parse(ddlHoras.Text);
                objdtousuarioxrutina.FK_CU_Dni = Session["SessionUsuario"].ToString();
                objdtousuarioxrutina.FK_IR_Cod = int.Parse(Session["cor_R"].ToString());
                DateTime fechaclase = fecha + Hora;
                _log.CustomWriteOnLog("Listar_rutinas_socio","fecha hora=" + fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));
                objdtousuarioxrutina.DR_FechaHora = DateTime.Parse(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));
                _log.CustomWriteOnLog("Listar_rutinas_socio","objdtousuarioxrutina.DR_FechaHora:" + objdtousuarioxrutina.DR_FechaHora);

                _log.CustomWriteOnLog("Listar_rutinas_socio","fh:" + objdtousuarioxrutina.DR_FechaHora.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));
                objdtousuarioxrutina.FK_IH_Cod = objctrusuarioxrutina.retornaHoraId(ddlHoras.Text);
                int tr = 0;
                string TRutina = Session["Tipo_Rutina"].ToString();
                if (TRutina == "Crossfit")
                {
                    tr = 1;
                }
                else
                {
                    tr = 2;
                }
                if (objctrusuarioxrutina.buscarfechaInsc(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"), Session["SessionUsuario"].ToString(), tr) == false)
                {
                    objctrusuarioxrutina.actualizarUsuario_rutina(objdtousuarioxrutina, fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + "Actualizacion exitosa" + "', 'bottom', 'center', null, null);", true);
                    listarRutinasSocio();
                    upCursos.Update();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red','" + "existe inscripcion en la misma hora" + "', 'bottom', 'center', null, null);", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red','" + "existe inscripcion en la misma hora, revise" + "', 'bottom', 'center', null, null);", true);
            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);
            _log.CustomWriteOnLog("Listar_rutinas_socio","" + ex.Message);
        }
    }

    protected void btnEliminarInscripcion_ServerClick(object sender, EventArgs e)
    {
        try
        {
            objdtousuarioxrutina.FK_CU_Dni = Session["SessionUsuario"].ToString();
            objdtousuarioxrutina.FK_IR_Cod = int.Parse(Session["cor_R"].ToString());
            DateTime hora = DateTime.Parse(Session["fechahora"].ToString());
            String H = hora.ToString("HH:mm");
            objdtousuarioxrutina.FK_IH_Cod=objctrusuarioxrutina.retornaHoraId(H);
            objctrusuarioxrutina.eliminarUsuario_rutina(objdtousuarioxrutina);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + "se elimino correctamente" + "', 'bottom', 'center', null, null);", true);
            listarRutinasSocio();
            upCursos.Update();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);
        }


    }
    public void obtener_Rutina_Fecha()
    {
        string fecha = Session["fechahora"].ToString();
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
        CultureInfo test = new System.Globalization.CultureInfo("es-ES");
        string diaespaniol = test.DateTimeFormat.GetDayName(dia.DayOfWeek);
        txtfechaClase.Text = dia.ToString("dd/MM/yy") + ", " + diaespaniol;
        txtfechaClase.Enabled = false;

        upFecha_Rutina.Update();


    }

    public void cargarddlHoras()
    {
        ddlHoras.Items.Clear();
        _log.CustomWriteOnLog("Listar_rutinas_socio","1");
        string fecha = Session["fecha"].ToString();

        DateTime dia = DateTime.Parse(fecha);
        _log.CustomWriteOnLog("Listar_rutinas_socio","3");
        //txtfechaClase.Text = fecha + ", " + dia.DayOfWeek.ToString();
        if (Convert.ToInt32(dia.DayOfWeek) == 0)
        {
            _log.CustomWriteOnLog("Listar_rutinas_socio","dia:" + Convert.ToInt32(dia.DayOfWeek));
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
            _log.CustomWriteOnLog("Listar_rutinas_socio","Convert.ToInt32(dia.DayOfWeek)" + Convert.ToInt32(dia.DayOfWeek));
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
        DateTime hora = DateTime.Parse(Session["fechahora"].ToString());
        ddlHoras.Text = hora.ToString("HH:mm");
        _log.CustomWriteOnLog("Listar_rutinas_socio","hora es:" + hora.ToString("hh:mm"));
        Udp_ddlhoras.Update();
    }


    protected void ddlHoras_SelectedIndexChanged(object sender, EventArgs e)
    {
        validacionHora();
    }

    public bool validacionHora()
    {
        string dni = Session["SessionUsuario"].ToString();
        int idr = int.Parse(Session["cor_R"].ToString());
        int idH = objctrusuarioxrutina.retornaHoraId(ddlHoras.Text);
        bool rep = objctrusuarioxrutina.validarHoraRepetida(dni, idr, idH);
        return rep;
    }
    public void consultarDatos()
    {
        DtoRutina objdtoRutina = new DtoRutina();
        CtrRutina objctrRutina = new CtrRutina();
        string fecha = Session["fecha"].ToString();
        DateTime Fecha = DateTime.Parse(fecha);

        DateTime fechaclase = Fecha;
        objdtoRutina.DR_FechaRutina = DateTime.Parse(fechaclase.ToString("yyyy-MM-dd'T'HH':'mm':'ss"));

        string TRutina = Session["Tipo_Rutina"].ToString();
        if (TRutina == "Crossfit")
        {
            objdtoRutina.FK_ITR_Cod = 1;
        }
        else
        {
            objdtoRutina.FK_ITR_Cod = 2;
        }
        
        objctrRutina.Obtener_Rutina(objdtoRutina);

        _log.CustomWriteOnLog("Listar_rutinas_socio","objdotioRutina" + objdtoRutina.PK_IR_Cod);
        _log.CustomWriteOnLog("Listar_rutinas_socio","objdotioRutina" + objdtoRutina.VR_Descripcion);


        DateTime dia = DateTime.Parse(fecha);
        CultureInfo test = new System.Globalization.CultureInfo("es-ES");
        string diaespaniol = test.DateTimeFormat.GetDayName(dia.DayOfWeek);

        //txtEjercicios.Text = objdtoRutina.VR_Descripcion;
        //upEjercicios.Update();
    }
}