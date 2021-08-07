using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using MySql.Data;

namespace WebApplication4
{
    public partial class FeedbackForm : System.Web.UI.Page
    {
      //  MySqlConnection con;
       // MySqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            String ans1 = string.Empty;
            RadioButton rb1 = (RadioButton)FindControl("RadioButton1");
            RadioButton rb2 = (RadioButton)FindControl("RadioButton2");

            if (rb1.Checked == true)
                ans1 = rb1.Text;
            if (rb2.Checked == true)
                ans1 = rb2.Text;

            String ans2 = string.Empty;
            RadioButton rb3 = (RadioButton)FindControl("RadioButton3");
            RadioButton rb4 = (RadioButton)FindControl("RadioButton4");
            RadioButton rb5 = (RadioButton)FindControl("RadioButton5");

            if (rb3.Checked == true)
                ans2 = rb3.Text;
            if (rb4.Checked == true)
                ans2 = rb4.Text;
            if (rb5.Checked == true)
                ans2 = rb5.Text;

            String ans3 = string.Empty;
            RadioButton rb6 = (RadioButton)FindControl("RadioButton6");
            RadioButton rb7 = (RadioButton)FindControl("RadioButton7");
            RadioButton rb8 = (RadioButton)FindControl("RadioButton8");

            if (rb6.Checked == true)
                ans3 = rb6.Text;
            if (rb7.Checked == true)
                ans3 = rb7.Text;
            if (rb8.Checked == true)
                ans3 = rb8.Text;

            String ans4 = string.Empty;
            RadioButton rb9 = (RadioButton)FindControl("RadioButton9");
            RadioButton rb10 = (RadioButton)FindControl("RadioButton10");
            RadioButton rb11= (RadioButton)FindControl("RadioButton11");

            if (rb9.Checked == true)
                ans4 = rb9.Text;
            if (rb10.Checked == true)
                ans4 = rb10.Text;
            if (rb11.Checked == true)
                ans4 = rb11.Text;

           String ans5 = string.Empty;
            RadioButton rb12 = (RadioButton)FindControl("RadioButton12");
            RadioButton rb13= (RadioButton)FindControl("RadioButton13");
            RadioButton rb14 = (RadioButton)FindControl("RadioButton14");

            if (rb12.Checked == true)
                ans5 = rb12.Text;
            if (rb13.Checked == true)
                ans5 = rb13.Text;
            if (rb14.Checked == true)
                ans5 = rb14.Text;

            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["userloginConnectionString"].ConnectionString);
            String username = (string)Session["username"];
            String Remarks = TextBox1.Text;

             MySqlCommand cmd = new MySqlCommand("Insert into feedback(username, ANS1, ANS2, ANS3,ANS4,ANS5,Remarks) VALUES(@username, @ANS1, @ANS2,@ANS3,@ANS4,@ANS5,@Remarks)",con);
            // MySqlCommand cmd = new MySqlCommand("INSERT INTO feedback(user, ANS1, ANS2, ANS3) VALUES('1234', 'yes', 'good', 'good')", con);

           
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@ANS1", ans1);
            cmd.Parameters.AddWithValue("@ANS2", ans2);
            cmd.Parameters.AddWithValue("@ANS3", ans3);
            cmd.Parameters.AddWithValue("@ANS4", ans4);
            cmd.Parameters.AddWithValue("@ANS5", ans5);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);

            con.Open();
            cmd.ExecuteNonQuery();
            //Response.Write("Submitted Successfully.......");
               
            Response.Redirect("ThankyouPage.aspx");
           
            con.Close();
        }

        protected void btn_exit(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
    }

