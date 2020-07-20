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

public partial class ActualizarPagos : System.Web.UI.Page
{
    DtoCPago objDTOCP = new DtoCPago();
    CtrCPago objCTRCP = new CtrCPago();
    //DtoUsuario objDTOU = new DtoUsuario();
    CtrUsuario objCTRU = new CtrUsuario();

    string conexionString = "data source=LAPTOP-UEI1JFVM; initial catalog=BD_SCLAP; integrated security=SSPI;";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarDatos();
        }

    }



    protected void btn_actualizar_Click(object sender, EventArgs e)
    {


        SqlConnection conexion = new SqlConnection(conexionString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "update T_Comprobante_Pago set VCP_NOperacion = @Noperaciones, ICP_NFisio=@NFisio, ICP_NNutri=@NNutri, DCP_Monto=@Monto  where PK_ICP_Cod = @Cod_P";
        cmd.Parameters.Add("@Cod_P", SqlDbType.Int).Value = Convert.ToInt32(Session["idcomp"].ToString());
        cmd.Parameters.Add("@Noperaciones", SqlDbType.VarChar).Value = txt_operaciones.Text;
        cmd.Parameters.Add("@NFisio", SqlDbType.Int).Value = Convert.ToInt32(txt_n_cita_fisio.Text);
        cmd.Parameters.Add("@NNutri", SqlDbType.Int).Value = Convert.ToInt32(txt_n_cita_nutri.Text);
        cmd.Parameters.Add("@Monto", SqlDbType.Int).Value = Convert.ToInt32(txt_monto.Text);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conexion;
        conexion.Open();
        cmd.ExecuteNonQuery();



        
        
        
        
        Response.Redirect("~/Realizar_Pago.aspx");





    }
    public void llenarDatos()
    {
        int codP = Convert.ToInt32(Session["idcomp"]);
        objDTOCP= objCTRCP.verComprobanteP(codP);
        txt_monto.Text = objDTOCP.DCP_Monto.ToString();
        txt_operaciones.Text = objDTOCP.VCP_NOperacion.ToString();
        txt_n_cita_fisio.Text = objDTOCP.ICP_NFisio.ToString();
        txt_n_cita_nutri.Text = objDTOCP.ICP_NNutri.ToString();


    }

    protected void btnsubir_Click(object sender, EventArgs e)
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