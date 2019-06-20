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
            int index = Convert.ToInt32(e.CommandArgument);

            var colsNoVisible = gvListaMoniCitaFisio.DataKeys[index].Values;

            string id = colsNoVisible[0].ToString();

            dtoCita.IC_Cod = int.Parse(colsNoVisible[0].ToString());

            Session["codigoCita"] = int.Parse(colsNoVisible[0].ToString());

            dtoCita = ct.ObtenerInformacionSolicitudCita(dtoCita);

            textCodigo.Text = dtoCita.IC_Cod.ToString();

            textObs.Text = dtoCita.VC_Observacion;

            textHora.Text = dtoCita.DC_FechaHoraSolicitada.ToString("dd-MM-yyyy");

            textFecha.Text = dtoCita.DC_FechaHoraSolicitada.ToString("HH:mm tt");




            //Actualizar Estado de cita:

            //dtoCita.IC_Cod = int.Parse(colsNoVisible[0].ToString());


            //dtoCita.FK_IEC_Cod = 4;





            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#VerDetalleMod').modal({backdrop: 'static', keyboard: false});", true);
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
            }
        }
        catch (Exception ex)
        {
            string msj = "";
            msj = ex.Message;
            string script = @"<script type='text/javascript'>
                                      alert('Selecciodne un estado');
                                  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            //msjrb.Text = msj;

        }
    }
}