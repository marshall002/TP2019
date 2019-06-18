using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CTR;

public partial class AdministrarRutina_Extra : System.Web.UI.Page
{
    string connectionString = @"Data Source=DESKTOP-UH5SKAR\LENOVOPC;Integrated Security=true;Initial Catalog=BD_SCLAP";
    //DAO.DaoRutina obj = new DAO.DaoRutina();
    //DTO.DtoRuti dtoR = new DTO.DtoRuti();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtfechaRutinaFooter.Text = Session["Primerdia"].ToString();

            Log.WriteLog("Page");
            PopulateGridview();
            //string fecha = Session["Primerdia"].ToString();
            DateTime fecha = Convert.ToDateTime(Session["Primerdia"].ToString());
            string today = System.DateTime.Now.ToShortDateString();

            string tipoR = Session["Tipo_Rutina"].ToString();

            //Session["Primerdia"]
            string f = fecha.ToString("yyyy/MM/dd");
            //obtener_Rutina_Fecha(fecha, tipoR, today);
            obtener_Rutina_Fecha(f, tipoR, today);
        }
    }
    void PopulateGridview()
    {

        DataTable dtbl = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM T_Ruti", sqlCon);
            sqlDa.Fill(dtbl);
        }
        if (dtbl.Rows.Count > 0)
        {

            gvRutina.DataSource = dtbl;
            gvRutina.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            gvRutina.DataSource = dtbl;
            gvRutina.DataBind();
            gvRutina.Rows[0].Cells.Clear();
            gvRutina.Rows[0].Cells.Add(new TableCell());
            gvRutina.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            gvRutina.Rows[0].Cells[0].Text = "No Data Found ..!";


            gvRutina.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }
        Log.WriteLog("ingreso a popular el gridview");
        //  Log.WriteLog("el valor de la session es:"+Session["PrimerDia"].ToString());
    }
    //protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gvRutina.EditIndex = -1;
    //    //PopulateGridview();
    //}

    //protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        using (SqlConnection sqlCon = new SqlConnection(connectionString))
    //        {
    //            sqlCon.Open();
    //            string query = "DELETE FROM PhoneBook WHERE PhoneBookID = @id";
    //            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
    //            sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvRutina.DataKeys[e.RowIndex].Value.ToString()));
    //            sqlCmd.ExecuteNonQuery();
    //            PopulateGridview();
    //            lblSuccessMessage.Text = "Selected Record Deleted";
    //            lblErrorMessage.Text = "";
    //            UPGridview.Update();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblSuccessMessage.Text = "";
    //        lblErrorMessage.Text = ex.Message;
    //    }
    //}

    //protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gvRutina.EditIndex = e.NewEditIndex;
    //    PopulateGridview();

    //}

    //protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (e.CommandName.Equals("AddNew"))
    //        {
    //            using (SqlConnection sqlCon = new SqlConnection(connectionString))
    //            {
    //                sqlCon.Open();
    //                string query = "INSERT INTO PhoneBook (FirstName,LastName,Contact,Email) VALUES (@FirstName,@LastName,@Contact,@Email)";
    //                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
    //                sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
    //                sqlCmd.Parameters.AddWithValue("@LastName", (gvPhoneBook.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
    //                sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
    //                sqlCmd.Parameters.AddWithValue("@Email", (gvPhoneBook.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
    //                sqlCmd.ExecuteNonQuery();
    //                PopulateGridview();
    //                lblSuccessMessage.Text = "New Record Added";
    //                lblErrorMessage.Text = "";
    //                UPGridview.Update();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblSuccessMessage.Text = "";
    //        lblErrorMessage.Text = ex.Message;
    //    }

    //}

    //protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    try
    //    {
    //        using (SqlConnection sqlCon = new SqlConnection(connectionString))
    //        {
    //            sqlCon.Open();
    //            string query = "UPDATE PhoneBook SET FirstName=@FirstName,LastName=@LastName,Contact=@Contact,Email=@Email WHERE PhoneBookID = @id";
    //            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
    //            sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
    //            sqlCmd.Parameters.AddWithValue("@LastName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
    //            sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
    //            sqlCmd.Parameters.AddWithValue("@Email", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
    //            sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
    //            sqlCmd.ExecuteNonQuery();
    //            gvRutina.EditIndex = -1;
    //            UPGridview.Update();
    //            PopulateGridview();
    //            UPGridview.Update();
    //            lblSuccessMessage.Text = "Selected Record Updated";
    //            lblErrorMessage.Text = "";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblSuccessMessage.Text = "";
    //        lblErrorMessage.Text = ex.Message;
    //    }
    //}

    //protected void gvRutina_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (e.CommandName.Equals("AddNew"))
    //        {

    //            DTO.DtoRuti objdtoruti = new DTO.DtoRuti();
    //            objdtoruti.DR_FechaRutina=Convert.ToDateTime((gvRutina.FooterRow.FindControl("txtfechaRutina") as TextBox).ToString());
    //            objdtoruti.VR_DescripcionE = (gvRutina.FooterRow.FindControl("txtdescripcionE") as TextBox).ToString();
    //            objdtoruti.VR_Duracion= (gvRutina.FooterRow.FindControl("txtduracion") as TextBox).Text.Trim().ToString();
    //            objdtoruti.IR_Repeticion=int.Parse((gvRutina.FooterRow.FindControl("txtrepeticion") as TextBox).ToString());

    //            ////PopulateGridview();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblSuccessMessage.Text = "";
    //        lblErrorMessage.Text = ex.Message;
    //    }
    //    obj.registrarRuti(dtoR);
    //}

    //protected void gvRutina_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gvRutina.EditIndex = e.NewEditIndex;
    //}

    //protected void gvRutina_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gvRutina.EditIndex = -1;
    //}

    //protected void gvRutina_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    obj.actualizarRuti(dtoR.DR_FechaRutina, dtoR.VR_DescripcionE,dtoR.VR_Duracion,dtoR.IR_Repeticion);
    //}

    //protected void gvRutina_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    obj.eliminarRuti(dtoR.PK_IR_Cod);
    //}

    public int validarTipo()
    {
        if ((gvRutina.FooterRow.FindControl("txtFK_ITR_CodFooter") as TextBox).Text.Trim().Equals("Crossfit"))
        {
            return 1;
        }
        else
            return 2;
    }

    protected void gvRutina_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                Log.WriteLog("entro a funcion add new");
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO T_Ruti (DR_FechaRutina,DR_FechaRegistro,VR_DescripcionE,FK_ITR_Cod,VR_Duracion,IR_Repeticion) VALUES (@Fecharutina,GETDATE(),@descripcion,@fkitrcod,@duracion,@repetic)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Fecharutina", DateTime.Parse((gvRutina.FooterRow.FindControl("txtfechaRutinaFooter") as TextBox).Text.Trim()));
                    //sqlCmd.Parameters.AddWithValue("@Fecharegistro", (gvRutina.FooterRow.FindControl("txtfecharegistroFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@descripcion", (gvRutina.FooterRow.FindControl("txtdescripcionFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@fkitrcod", (gvRutina.FooterRow.FindControl("txtFK_ITR_CodFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@duracion", (gvRutina.FooterRow.FindControl("txtduracionFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@repetic", (gvRutina.FooterRow.FindControl("txtrepeticionFooter") as TextBox).Text.Trim());

                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + "Registro exitoso" + "', 'bottom', 'center', null, null);", true);
                    //lblSuccessMessage.Text = "Registro de rutina con exito.";
                    lblErrorMessage.Text = "";
                    UPGridview.Update();
                }
            }
        }
        catch (Exception ex)
        {
            lblSuccessMessage.Text = "";
            lblErrorMessage.Text = ex.Message;
            Log.WriteLog("error en add new: " + ex.Message);
        }
    }

    protected void gvRutina_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvRutina.EditIndex = e.NewEditIndex;
        PopulateGridview();
        UPGridview.Update();

    }

    protected void gvRutina_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRutina.EditIndex = -1;
        PopulateGridview();
        UPGridview.Update();
    }

    protected void gvRutina_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Log.WriteLog("entro a funcion Actualizar");
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE T_Ruti SET DR_FechaRutina=@Fecharutina,VR_DescripcionE=@descripcion,FK_ITR_Cod=@fkitrcod,VR_Duracion=@duracion,IR_Repeticion=@repetic WHERE PK_IR_Cod = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Fecharutina", DateTime.Parse((gvRutina.Rows[e.RowIndex].FindControl("txtfechaRutina") as TextBox).Text.Trim()));
                sqlCmd.Parameters.AddWithValue("@descripcion", (gvRutina.Rows[e.RowIndex].FindControl("txtdescripcion") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@fkitrcod", (gvRutina.Rows[e.RowIndex].FindControl("txtFK_ITR_Cod") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@duracion", (gvRutina.Rows[e.RowIndex].FindControl("txtduracion") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@repetic", (gvRutina.Rows[e.RowIndex].FindControl("txtrepeticion") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvRutina.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvRutina.EditIndex = -1;
                UPGridview.Update();
                PopulateGridview();
                UPGridview.Update();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + "Actualizacion exitosa" + "', 'bottom', 'center', null, null);", true);
                //lblSuccessMessage.Text = "Rutina Actualizada con exito.";
                lblErrorMessage.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblSuccessMessage.Text = "";
            Log.WriteLog("Error en el actualizar : " + ex.Message);
        }
    }

    protected void gvRutina_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Log.WriteLog("entro a funcion eliminar");
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "DELETE FROM T_Ruti WHERE PK_IR_Cod = @id";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvRutina.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                PopulateGridview();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + "Rutina eliminada" + "', 'bottom', 'center', null, null);", true);
                //lblSuccessMessage.Text = "Rutina eliminada con exito";
                lblErrorMessage.Text = "";
                UPGridview.Update();
                

            }
        }
        catch (Exception ex)
        {
            lblSuccessMessage.Text = "";
            Log.WriteLog("Error al borrar" + ex.Message);
        }
    }


    public void obtener_Rutina_Fecha(string a, string b, string c)
    {
        //string a = (gvRutina.Rows[e.RowIndex].FindControl("txtFK_ITR_Cod") as TextBox).Text.Trim();
        //string TRutina = Session["Tipo_Rutina"].ToString();
        //string f = Session["Fecha_Seleccionada"].ToString();

        txt.Text = a;
        txt2.Text = b;
        txt3.Text = c;

    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministrarRutina.aspx");
    }
}