using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ProductManagement
{
    public partial class index : System.Web.UI.Page
    {
        string connectionstring = @"Server=localhost;Database=prodmang;UID=root;Pwd=1234";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                GridFill();
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlconn = new MySqlConnection(connectionstring))
                {
                    sqlconn.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("ProductAddOrEdit", sqlconn);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_productid", Convert.ToInt32(hfProductID.Value == "" ? "0" : hfProductID.Value));
                    sqlCmd.Parameters.AddWithValue("_product", txtProduct.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_price", Convert.ToDecimal(txtPrice.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("_count", Convert.ToInt32(txtCount.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("_description", txtDescription.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    Clear();
                    GridFill();
                    lblSuccessMessage.Text = "Submitted Sucessfully";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        void Clear()
        {
            hfProductID.Value = "";
            txtCount.Text = txtDescription.Text = txtProduct.Text = txtPrice.Text = "";
            btSave.Text = "Save";
            btDelete.Enabled = false;
            lblErrorMessage.Text = lblSuccessMessage.Text = "";
        }


        void GridFill()
        {
            using (MySqlConnection sqlconn = new MySqlConnection(connectionstring))
            {
                sqlconn.Open();
                MySqlDataAdapter sqlda = new MySqlDataAdapter("ProductView", sqlconn);
                sqlda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                System.Data.DataTable dtbl = new System.Data.DataTable();
                sqlda.Fill(dtbl);
                gvProduct.DataSource = dtbl;
                gvProduct.DataBind();
            }
        }

        protected void lnkSelect_OnClick(object sender,EventArgs e)
        {
            int productID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            using (MySqlConnection sqlconn = new MySqlConnection(connectionstring))
            {
                sqlconn.Open();
                MySqlDataAdapter sqlda = new MySqlDataAdapter("ProductViewByID", sqlconn);
                sqlda.SelectCommand.Parameters.AddWithValue("_productid", productID);
                sqlda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                System.Data.DataTable dtbl = new System.Data.DataTable();
                sqlda.Fill(dtbl);
                txtProduct.Text = dtbl.Rows[0][1].ToString();
                txtPrice.Text = dtbl.Rows[0][2].ToString();
                txtCount.Text = dtbl.Rows[0][3].ToString();
                txtDescription.Text = dtbl.Rows[0][4].ToString();
                hfProductID.Value = dtbl.Rows[0][0].ToString();
                btSave.Text = "Update";
                btDelete.Enabled = true;
            }
        }

        protected void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection sqlconn = new MySqlConnection(connectionstring))
            {
                sqlconn.Open();
                MySqlCommand sqlCmd = new MySqlCommand("ProductDeleteByID", sqlconn);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("_productid", Convert.ToInt32(hfProductID.Value == "" ? "0" : hfProductID.Value));
                sqlCmd.ExecuteNonQuery();
                Clear();
                GridFill();
                lblSuccessMessage.Text = "Deleted Sucessfully";
            }
        }
    }
}