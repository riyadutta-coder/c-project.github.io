using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WebApplication4
{
    public partial class Login : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["userloginConnectionString"].ConnectionString);
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnlogin_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("select * from user where Username='" + TextBox2.Text + "'and Password='"+TextBox3.Text+"'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            bool flag = false;
            while(dr.Read())
            {
                Session["role"] = dr.GetValue(2).ToString();
                Session["username"] = dr.GetValue(1).ToString();
              /*  if(dr[0].Equals(TextBox2.Text))
                {
                    Session["username"] = TextBox1.Text;
                    lblMsg.Text = "You Have Successfully Logged In.....";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    flag = true;
                    Response.Redirect("FeedbackForm.aspx");
                }*/
            }
            String role = (string)Session["role"];
              if (role.Equals("admin"))
            {
                Response.Redirect("AdminPanel.aspx");
                Response.Write("Admin Logged In");
            }
            else if (role.Equals("student"))
            {
                Response.Redirect("FeedbackForm.aspx");
            }
              else
            {
                Session.RemoveAll();
                lblMsg.Text = "Incorrect Username Or Password";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                Response.Write("Incorrect Username Or Password");
                Response.Redirect("LoadingScreen.aspx");
            }
            /*if(!flag)
            {
                lblMsg.Text = "Incorrect Username Or Password";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }*/
            con.Close();
        }

        protected void btn_back(object sender, EventArgs e)
        {
            Response.Redirect("LoadingScreen.aspx");
        }
    }
}