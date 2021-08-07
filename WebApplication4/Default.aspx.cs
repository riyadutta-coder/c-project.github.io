using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication4
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=userlogin; password=root");
            con.Open();
             Response.Write("Connected");

            MySqlCommand cmd = new MySqlCommand("select * from user", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            GridView2.DataSource = ds;
            GridView2.DataBind();
            cmd.Dispose();
            con.Close();
        }
    }


    
}