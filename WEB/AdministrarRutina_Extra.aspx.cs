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
    string connectionString = @"Data Source=LAPTOP-TG82GILV;Integrated Security=true;Initial Catalog=BD_SCLAP";
    //DAO.DaoRutina obj = new DAO.DaoRutina();
    //DTO.DtoRuti dtoR = new DTO.DtoRuti();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        Log.WriteLog("Page");
            PopulateGridview();
        }
    }
    void PopulateGridview()
    {
        DataTable dtbl = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM T_RUTI", sqlCon);
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

    protected void gvRutina_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }

    protected void gvRutina_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvRutina.EditIndex = e.NewEditIndex;
        PopulateGridview();

    }

    protected void gvRutina_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRutina.EditIndex = -1;
        PopulateGridview();
    }

    protected void gvRutina_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void gvRutina_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Log.WriteLog("entro a funcion eliminar");
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
            Log.WriteLog("1");
                sqlCon.Open();
                Log.WriteLog("2");

                string query = "DELETE FROM T_Ruti WHERE PK_IR_Cod = @id";
                Log.WriteLog("3");

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            Log.WriteLog("4");
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvRutina.DataKeys[e.RowIndex].Value.ToString()));
            Log.WriteLog("5");
                sqlCmd.ExecuteNonQuery();
            Log.WriteLog("6");
                PopulateGridview();
            Log.WriteLog("7");
                lblSuccessMessage.Text = "Selected Record Deleted";
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
}