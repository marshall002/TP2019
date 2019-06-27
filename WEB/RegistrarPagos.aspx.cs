using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CTR;
using DTO;
using System.Drawing;
using System.Text;

public partial class RegistrarPagos : System.Web.UI.Page
{
    DtoCPago objDTOCP = new DtoCPago();
    CtrCPago objCTRCP = new CtrCPago();
    //DtoUsuario  objDTOU = new DtoUsuario();
    CtrUsuario objCTRU = new CtrUsuario();
    string conexionString = "data source=LACING202A-06; initial catalog=BD_SCLAP; integrated security=SSPI;";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btn_resgitrar_Click(object sender, EventArgs e)
    {

        int Tamanio = fu_load_imagen.PostedFile.ContentLength;
        byte[] imag = new byte[Tamanio];

        fu_load_imagen.PostedFile.InputStream.Read(imag, 0, Tamanio);
        //Bitmap ImagenOiginalBinaria = new Bitmap(fu_load_imagen.PostedFile.InputStream);

        Registrar(imag);

        Response.Redirect("~/Realizar_Pago.aspx");
    }

    public void Registrar(byte[] imag)
    {
        int Sesion = int.Parse(Session["SessionUsuario"].ToString());
        string data = StringToBinary(imag.ToString());
        objDTOCP.VCP_NOperacion = txt_operacion.Text;
        objDTOCP.DCP_Monto = Double.Parse(txt_monto.Text);
        objDTOCP.ICP_NFisio = Int32.Parse(txt_fisio.Text);
        objDTOCP.ICP_NNutri = Int32.Parse(txt_nutri.Text);
        objDTOCP.FK_CU_Dni = Sesion;
        Log.WriteLog("data" + data);
        Log.WriteLog("data" + data.Count());

        string mensaje = "Registrado con exito";
        //objCTRCP.RegistrarComprobante_Pago(objDTOCP, data);

        SqlConnection conexion = new SqlConnection(conexionString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Insert into T_Comprobante_pago (IMCP_imagen,VCP_NOperacion,ICP_NFIsio,ICP_NNutri,VCP_Estado_Pago, DCP_Monto,DCP_FechaHoraRealizada,FK_CU_Dni) values (@imagen,@Noperaciones,@NFisio,@NNutri,'pendiente',@Monto,getdate(),'74931448')";
        cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = imag;
        cmd.Parameters.Add("@Noperaciones",SqlDbType.VarChar).Value = txt_operacion.Text;
        cmd.Parameters.Add("@NFisio", SqlDbType.Int).Value = Convert.ToInt32(txt_fisio.Text);
        cmd.Parameters.Add("@NNutri", SqlDbType.Int).Value = Convert.ToInt32(txt_nutri.Text);
        cmd.Parameters.Add("@Monto", SqlDbType.Int).Value = Convert.ToInt32(txt_monto.Text);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conexion;
        conexion.Open();
        cmd.ExecuteNonQuery();



        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + mensaje + "', 'bottom', 'center', null, null);", true);

    }
    public static string StringToBinary(string data)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in data.ToCharArray())
        {
            sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
        }
        return sb.ToString();
    }
    protected void btnSubir_Click1(object sender, EventArgs e)
    {

        int Tamanio = fu_load_imagen.PostedFile.ContentLength;
        byte[] imag = new byte[Tamanio];

        fu_load_imagen.PostedFile.InputStream.Read(imag, 0, Tamanio);
        Bitmap ImagenOiginalBinaria = new Bitmap(fu_load_imagen.PostedFile.InputStream);
        //Insertar en la bd
        string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(imag);
        imagen_previa.ImageUrl = ImagenDataURL64;
    }
}