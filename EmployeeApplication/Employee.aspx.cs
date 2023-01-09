using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeApplication.Business;

namespace EmployeeApplication
{
    public partial class _Default : Page
    {
        BLEmployee blEmployee = new BLEmployee();

        protected void Page_Load(object sender, EventArgs e)
        { }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            int result = blEmployee.AddOrUpdateEmployee(name.Text, email.Text, address.Text, contact.Text);
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
            }
            else if (result == 2)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('This Contact Already Exist, Please Enter new number !!');", true);
            }
            else if (result == 3)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
            }
            LoadRecord();
            ClearControls();      
        }

        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            int result = blEmployee.DeleteEmployeeByEmailId(email.Text);
            if(result > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully deleted');", true);
                LoadRecord();
                ClearControls();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Email Does not Exists!!!');", true);
            }
        }

        protected void Showbtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = blEmployee.ViewEmployeeByEmailId(email.Text);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Data Does not Exist For This Email!!!');", true);
            }
        }

        public void ClearControls()
        {
            name.Text = email.Text = address.Text = contact.Text = "";
        }

        public void LoadRecord()
        {
            DataTable dt = new DataTable();
            dt = blEmployee.ViewEmployeeDetails();
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string emailField = row.Cells[2].Text;
            SqlDataReader r = blEmployee.BindEmployees(emailField);
            while (r.Read())
            {
                name.Text = r.GetValue(0).ToString();
                email.Text = r.GetValue(1).ToString();
                address.Text = r.GetValue(2).ToString();
                contact.Text = r.GetValue(3).ToString();
            }
        }
    }
}