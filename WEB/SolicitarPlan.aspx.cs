using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using DAO;
using CTR;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class SolicitarPlan : System.Web.UI.Page
{
    List<DtoPlan> lstPLan = new List<DtoPlan>();

    DtoUsuario objdtousuario = new DtoUsuario();
    DtoPlan objdtoplan = new DtoPlan();
    DtoContrato objdtocontrato = new DtoContrato();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            if (Session["id_perfil"] != null)
            {
                try
                {
                    CtrPlan objctrplan = new CtrPlan();
                    lstPLan = objctrplan.ObtenerPlanes();
                    if (lstPLan.Count > 0)
                    {
                        CrearRuleta(lstPLan);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {

                _log.CustomWriteOnLog("SolicitarPlan", "Proc Citas Sol Detalles - Error en id Perfil");
                Response.Redirect("Inicio.aspx");

            }


        }
    }

    public void CrearRuleta(List<DtoPlan> obLRuleta)
    {
        CtrPlan objctrplan = new CtrPlan();
        StringBuilder myString = new StringBuilder();
        StringBuilder CarouselIndicators = new StringBuilder();
        if (Session["SessionUsuario"] != null)
        {
            objdtousuario.PK_CU_Dni = Session["SessionUsuario"].ToString();

        }
        int validarcontrato = objctrplan.validarcontrato(objdtousuario);
        if (validarcontrato > 0)
        {
            objctrplan.ObtenerDatosContratoVigente(objdtousuario, objdtoplan, objdtocontrato);
            lblDuracionMeses.InnerText = objdtoplan.MembresiaDuracionString;
            lblfechainicio.InnerText = objdtocontrato.DC_Fecha_Inicio.ToShortDateString();
            lblfechavencimiento.InnerText = objdtocontrato.DC_Fecha_Vencimiento.ToShortDateString();
            lblnutricionista.InnerText = objdtoplan.IE_Cantidad_Sesion_Nutri.ToString() + " citas según su plan";
            lblfisioterapeuta.InnerText = objdtoplan.IP_Cantidad_Sesion_Fisio.ToString() + " citas según su plan";
            lblCongelamiento.InnerText = objdtoplan.Congelamiento.ToString() + " días";
            lblfrecuencia.InnerText = objdtoplan.FrecuenciaString.ToString();
            MensajeH.Visible = false;
        }
        else
        {
            MensajeH.Visible = true;
            divTablePlan.Visible = false;
        }
        for (int i = 0; i <= obLRuleta.Max(x => x.Index); i++)
        {
            string a = "";
            if (i == 0)
            {
                a = "active";
            }
            CarouselIndicators.Append("<li data-target='#carousel-example-generic' data-slide-to=" + i + " class='" + a + "'>" +
                    "</li>"
                         );
            List<DtoPlan> Temp = new List<DtoPlan>();
            Temp = obLRuleta.Where(x => x.Index == i).ToList();
            myString.Append("<div class='item " + a + "'>");

            foreach (DtoPlan value in Temp)
            {
                myString.Append("<div class='col-md-4'>");
                myString.Append("<div class='card'>");
                myString.Append("<div class='header bg-red'>");
                myString.Append("<h2>Duracion : " + value.MembresiaDuracionString + " meses</h2>");
                myString.Append("</div>");
                myString.Append("<div class='body'>");
                myString.Append("<p class='card-text'>");
                myString.Append("<table class='table table-responsive'>");
                myString.Append("<tr>");
                myString.Append("<td>");
                myString.Append(" N° de sesiones con Fisioterapeuta");
                myString.Append("</td>");
                myString.Append("<td>");
                myString.Append(value.IP_Cantidad_Sesion_Fisio);
                myString.Append("</td>");
                myString.Append("</tr>");
                myString.Append("<tr>");
                myString.Append("<td>");
                myString.Append(" N° de sesiones con Nutricionista");
                myString.Append("</td>");
                myString.Append("<td>");
                myString.Append(value.IE_Cantidad_Sesion_Nutri);
                myString.Append("</td>");
                myString.Append("</tr>");
                myString.Append("<tr>");
                myString.Append("<td>");
                myString.Append("Ilimitado o interdiario : ");
                myString.Append("</td>");
                myString.Append("<td>");
                myString.Append(value.FrecuenciaString);
                myString.Append("</td>");
                myString.Append("</tr>");
                myString.Append("<tr>");
                myString.Append("<td>");
                myString.Append("Costo : ");
                myString.Append("</td>");
                myString.Append("<td>");
                myString.Append("<b>" + value.DP_Costo + "</b>");
                myString.Append("</td>");
                myString.Append("</tr>");
                myString.Append("</table>");
                myString.Append("</p>");
                if (validarcontrato == 0)
                {
                    myString.Append("<button ID='btn" + value.PK_IP_Cod + "' class='btn btn-primary' onclick='CambiarTextboxHF(" + value.PK_IP_Cod + ")'/>inscribirse");
                }
                myString.Append("</div>");
                myString.Append("</div>");
                myString.Append("</div>");
            }
            myString.Append("</div>");
        }
        creadordeRuleta.Text = myString.ToString();
        indicadorescarouselLit.Text = CarouselIndicators.ToString();
        _log.CustomWriteOnLog("Crear_Ruleta", " -------------------------------------------------");
        _log.CustomWriteOnLog("Crear_Ruleta", " obLRuleta.Count        " + obLRuleta.Count);
        _log.CustomWriteOnLog("Crear_Ruleta", " -------------------------------------------------");
    }
    protected void hfValorSeleccionado_ValueChanged(object sender, EventArgs e)
    {
        _log.CustomWriteOnLog("Crear_Ruleta", "Obtenido valor cambiado " + hfValorSeleccionado.Value);
        Utils.AddScriptClientUpdatePanel(upCarrusel, "mostrarModal();");
        var ValordeHiddenfield = hfValorSeleccionado.Value;
        hfValorSeleccionado.Value = "";
        _log.CustomWriteOnLog("Crear_Ruleta", "PASO");
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        try
        {
            CtrContrato objctrContrato = new CtrContrato();
            _log.CustomWriteOnLog("SolicitarPlan", "............................" + txtFechaIngreso.Text);
            objdtocontrato.FK_IP_Cod = int.Parse(hidenfield.Value);
            objdtousuario.PK_CU_Dni = Session["SessionUsuario"].ToString();
            objdtocontrato.DC_Fecha_Inicio = Convert.ToDateTime(String.Format("{0:MM/dd/YYYY HH:mm:ss}", txtFechaIngreso.Text));
            objdtocontrato.VC_DEscripcion = txtComentario.Text;
            _log.CustomWriteOnLog("SolicitarPlan", "objdtocontrato.FK_IP_Cod " + int.Parse(hidenfield.Value));
            _log.CustomWriteOnLog("SolicitarPlan", "objdtousuario.PK_CU_Dni " + Session["SessionUsuario"].ToString());
            _log.CustomWriteOnLog("SolicitarPlan", "objdtocontrato.DC_Fecha_Inicio " + Convert.ToDateTime(String.Format("{0:dd-MM-YYYY 00:00:00}", txtFechaIngreso.Text)));
            _log.CustomWriteOnLog("SolicitarPlan", "objdtocontrato.VC_DEscripcion " + txtComentario.Text);
            objctrContrato.RegistrarContrato(objdtousuario, objdtocontrato);
            _log.CustomWriteOnLog("SolicitarPlan", "Registro plan solicitado");
            Utils.AddScriptClientUpdatePanel(UpdatePanel1, "mostrarMensajeConfirmacion();");
            Utils.AddScriptClientUpdatePanel(UpdatePanel1, "OcultaryLimpiarModal();");
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("SolicitarPlan", "ERROR " + ex.Message);
        }
    }
    protected void btnImprimirContrato_Click(object sender, EventArgs e)
    {
        CtrPlan objctrplan = new CtrPlan();
        DtoPlan objdtoplan = new DtoPlan();
        DtoContrato objdtocontrato = new DtoContrato();
        objdtousuario.PK_CU_Dni = Session["SessionUsuario"].ToString();

        objctrplan.ObtenerDatosContratoVigente(objdtousuario, objdtoplan, objdtocontrato);
        string idplan = objdtoplan.PK_IP_Cod.ToString();
        DateTime contratoFechainicio = objdtocontrato.DC_Fecha_Inicio;
        DateTime contratofechavencimiento = objdtocontrato.DC_Fecha_Vencimiento;
        string plancantidadsesionnutri = objdtoplan.IE_Cantidad_Sesion_Nutri.ToString();
        string plancantidadsesionfisio = objdtoplan.IP_Cantidad_Sesion_Fisio.ToString();
        string membresiaduracion = objdtoplan.MembresiaDuracionString;
        string congelamiento = objdtoplan.Congelamiento;
        string frecuenciaasistencia = objdtoplan.FrecuenciaString;


        Document DocumentoPDF = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        PdfWriter.GetInstance(DocumentoPDF, Response.OutputStream);
        DocumentoPDF.Open();
        string plantilla = HttpContext.Current.Server.MapPath("/plantillas/CalculoInsentivo.htm"); //Corregir ruta
        string imageURL = Server.MapPath(".") + "/images/LogoParadaFondo.png";
        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
        jpg.ScaleToFit(140f, 120f);
        jpg.SpacingBefore = 10f;
        jpg.SpacingAfter = 1f;

        jpg.Alignment = Element.ALIGN_LEFT;
        DocumentoPDF.Add(jpg);
        Paragraph titulo = new Paragraph();
        titulo.Add("CROSSFIT LA PARADA  -  CONTRATO DE MEMBRESIA");
        titulo.Alignment = Element.ALIGN_CENTER;
        DocumentoPDF.Add(titulo);
        DocumentoPDF.Add(new Paragraph(" "));
        DocumentoPDF.Add(new Paragraph(" "));
        DocumentoPDF.Add(new Paragraph(" "));
        PdfPTable table = new PdfPTable(2);

        PdfPCell cell = new PdfPCell(new Phrase("Descripción del plan contratado"));
        cell.Colspan = 2;
        cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
        table.AddCell(cell);
        table.AddCell("DNI del socio");
        table.AddCell(Session["SessionUsuario"].ToString());
        table.AddCell("Nombre completo del socio");
        table.AddCell(Session["NombreCompleto"].ToString());
        table.AddCell("Codigo del plan");
        table.AddCell(idplan);
        table.AddCell("Duracion de la membresia");
        table.AddCell(membresiaduracion +"meses");
        table.AddCell("Fecha de inicio de plan");
        table.AddCell(contratoFechainicio.ToString("dd/MM/yyyy"));
        table.AddCell("Fecha de fin");
        table.AddCell(contratofechavencimiento.ToString("dd/MM/yyyy"));
        table.AddCell("Sesiones con nutricionista incluido");
        table.AddCell(plancantidadsesionnutri);
        table.AddCell("Sesiones con fisioterapeuta incluido");
        table.AddCell(plancantidadsesionfisio);
        table.AddCell("Tiempo de congelamiento ");
        table.AddCell(congelamiento +"dias");

        DocumentoPDF.Add(table);
        DocumentoPDF.Add(new Paragraph(" "));
        DocumentoPDF.Add(new Paragraph(" "));
        DocumentoPDF.Add(new Paragraph(" "));
        DocumentoPDF.Add(new Paragraph("Clausulas: "));
        DocumentoPDF.Add(new Paragraph("PAGO: todo pago sera relizado de forma directa en la empresa."));
        DocumentoPDF.Add(new Paragraph("RENOVACION: El socio podra realizar la renovacion teniendo un plan en progreso, en donde el antiguo plan se cancelara y seguira con el nuevo plan."));
        DocumentoPDF.Add(new Paragraph("CUOTAS DE PAGOS: Solo existen 2 cuotas de pago al elegir el tipo de pago por cuotas."));
        DocumentoPDF.Add(new Paragraph("MEMBRESIAS: Todo socio que se haya ausentado de la asistencia al local en un plazo de 2 meses y no haya usado un congelamineto sera considerado como."));
        DocumentoPDF.Add(new Paragraph("SOSCIO ANTIGUOS: Todo socio que se haya ausentado de la asistencia al local en un plazo de 2 meses y no haya usado un congelamiento sera considerado como socio nuevo."));
        DocumentoPDF.Add(new Paragraph("BEBIDAS ALCOHOLICAS Y FUMAR: Se prohibe el consumo de cualquier tipo de bebida alcoholica y cigarro dentro del local."));


        DocumentoPDF.Close();



        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;" + "filename=Contrato_Membresia.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(DocumentoPDF);
        Response.End();
    }
}