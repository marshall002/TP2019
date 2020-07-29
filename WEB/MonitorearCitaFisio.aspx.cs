using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;


public partial class MonitorearCitaFisio : System.Web.UI.Page
{
    CtrMonitoriarCitaFisio ct = new CtrMonitoriarCitaFisio();
    DtoCita dtoCita = new DtoCita();
    Log _log = new Log();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvListaMoniCitaFisio.DataSource = ct.VMonitoriarCitaFisio();
            gvListaMoniCitaFisio.DataBind();
        }
    }

    protected void listaCitaFisio_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver Acción")
        {
            _log.CustomWriteOnLog("MonitorearCitaFisio","1");
            int index = Convert.ToInt32(e.CommandArgument);
            _log.CustomWriteOnLog("MonitorearCitaFisio","2");

            var colsNoVisible = gvListaMoniCitaFisio.DataKeys[index].Values;
            _log.CustomWriteOnLog("MonitorearCitaFisio","3");

            string id = colsNoVisible[0].ToString();
            _log.CustomWriteOnLog("MonitorearCitaFisio","4");

            dtoCita.IC_Cod = int.Parse(colsNoVisible[0].ToString());
            _log.CustomWriteOnLog("MonitorearCitaFisio","5");

            Session["codigoCita"] = int.Parse(colsNoVisible[0].ToString());
            _log.CustomWriteOnLog("MonitorearCitaFisio","6");

            dtoCita = ct.ObtenerInformacionSolicitudCita(dtoCita);
            _log.CustomWriteOnLog("MonitorearCitaFisio","7");

            textCodigo.Text = Session["codigoCita"].ToString();
            _log.CustomWriteOnLog("MonitorearCitaFisio","dtoCita.IC_Cod.ToString();" + dtoCita.IC_Cod.ToString());

            textObs.Text = dtoCita.VC_Observacion;
            _log.CustomWriteOnLog("MonitorearCitaFisio","dtoCita.VC_Observacion" + dtoCita.VC_Observacion);

            textHora.Text = dtoCita.DC_FechaHoraSolicitada.ToString("dd-MM-yyyy");
            _log.CustomWriteOnLog("MonitorearCitaFisio","textHora.Text" + textHora.Text);

            textFecha.Text = dtoCita.DC_FechaHoraSolicitada.ToString("HH:mm tt");


            _log.CustomWriteOnLog("MonitorearCitaFisio","11");
            upModal.Update();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#VerDetalleMod').modal('show');", true);
        }
    }

    protected void btnGuardar_ServerClick(object sender, EventArgs e)
    {
        int codigoCita = int.Parse(Session["codigoCita"].ToString()); //249;

        string check = Request.Form["chk"];

        try
        {
            if (string.IsNullOrEmpty(check))
            {

                throw new Exception("Debe Seleccionar un estado");

            }

            if (check != null)
            {
                int codigoEstadoCita = int.Parse(check);
                ct.actualizarSolicitudCita(codigoCita, codigoEstadoCita);
                gvListaMoniCitaFisio.DataSource = ct.VMonitoriarCitaFisio();
                gvListaMoniCitaFisio.DataBind();
                //UPGridview.Update();
                Response.Redirect("MonitorearCitaFisio.aspx");
            }
        }
        catch (Exception ex)
        {
            string msj = "";
            msj = ex.Message;
            string script = @"<script type='text/javascript'>
                                      alert('Seleccione un estado');
                                  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            //msjrb.Text = msj;

        }
    }
}