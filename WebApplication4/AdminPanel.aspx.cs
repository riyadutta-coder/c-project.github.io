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
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GVBind();
            }
        }
        protected void GVBind()
        {
            string cs = ConfigurationManager.ConnectionStrings["userloginConnectionString"].ConnectionString;
            using(MySqlConnection con=new MySqlConnection(cs))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from feedback", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows==true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }
        }
    }
}