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

public partial class SolicitarPlan : System.Web.UI.Page
{
    List<DtoPlan> lstPLan = new List<DtoPlan>();

    CtrPlan objctrplan = new CtrPlan();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            try
            {
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
    }

    public void CrearRuleta(List<DtoPlan> obLRuleta)
    {
        StringBuilder myString = new StringBuilder();
        StringBuilder CarouselIndicators = new StringBuilder();
        //Array a = obLRuleta.Take(3).ToArray();
        for (int i = 0; i <= obLRuleta.Max(x => x.Index); i++)
        {
            string a = "";
            if (i == 0)
            {
                a = "active";
            }
            CarouselIndicators.Append("<li data-target='#carousel-example-generic' data-slide-to=" + i + " class='" + a + "'>" +
                    //"<img src = 'resources/img/user_carrusel.png' width = '32'/>" +
                    "</li>"
                         );
            //CarouselIndicators.Append("<li data-target='#carousel-example-generic' data-slide-to='0' class='active'></li>" +
            //    "<li data-target='#carousel-example-generic' data-slide-to='1'></li>" +
            //    "<li data-target='#carousel-example-generic' data-slide-to='2'></li>"
            //   );

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
                myString.Append("<b>"+value.DP_Costo+"</b>");
                myString.Append("</td>");
                myString.Append("</tr>");
                myString.Append("</table>");
                myString.Append("</p>");
                myString.Append("<button ID='btn"+value.PK_IP_Cod+"' class='btn btn-primary' onclick='CambiarTextboxHF("+ value.PK_IP_Cod +")'/>inscribirse");
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
        //foreach (DtoPlan beruleta in obLRuleta)
        //{
        //    _log.CustomWriteOnLog("Crear_Ruleta", " _beRuleta.Aprobador    " + beruleta.IE_Cantidad_Sesion_Nutri);
        //    _log.CustomWriteOnLog("Crear_Ruleta", " _beRuleta.Cargo        " + beruleta.IP_Cantidad_Sesion_Fisio);
        //    _log.CustomWriteOnLog("Crear_Ruleta", " _beRuleta.Fecha        " + beruleta.MembresiaDuracionString);
        //    _log.CustomWriteOnLog("Crear_Ruleta", " _beRuleta.Index        " + beruleta.PK_IP_Cod);
        //    _log.CustomWriteOnLog("Crear_Ruleta", " _beRuleta.Orden        " + beruleta.Congelamiento);
        //    _log.CustomWriteOnLog("Crear_Ruleta", " _beRuleta.Posicion     " + beruleta.DP_Costo);
        //    _log.CustomWriteOnLog("Crear_Ruleta", " _beRuleta.EstadoColor  " + beruleta.FrecuenciaString);
        //    _log.CustomWriteOnLog("Crear_Ruleta", " -------------------------------------------------");
        //}

    }


    protected void hfValorSeleccionado_ValueChanged(object sender, EventArgs e)
    {
        _log.CustomWriteOnLog("Crear_Ruleta", "Obtenido valor cambiado "+ hfValorSeleccionado.Value);
        //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mostrarModal();");
        Utils.AddScriptClientUpdatePanel(upCarrusel, "mostrarModal();");
        _log.CustomWriteOnLog("Crear_Ruleta", "PASO");

    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {

    }
}