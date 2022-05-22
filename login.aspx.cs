using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace login
{
    public partial class login : System.Web.UI.Page
    {
        Class1 c1 = new Class1();
        String mainCon = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public login()
        {

            mainCon = c1.servercon;

        }


        protected void login__submit_Click(object sender, EventArgs e)
        {



            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-7J2NU9S\SQLEXPRESS;Initial Catalog=Accidentdb;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select * from signin where nationalid='"+TextBox1.Text+"'and password='"+TextBox2.Text+"'and usertype='"+DropDownList1.SelectedItem.ToString()+"'",sqlCon);
                DataTable dt = new DataTable();
            sda.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    Response.Write("<script>alert(you are logined as"+dt.Rows[0][0]+"') </script>");
                    if (DropDownList1.SelectedIndex==0)
                    {
                        Response.Redirect("Home.aspx");
                    }
                    else if(DropDownList1.SelectedIndex==1)
                        {
                        Response.Redirect("Mainpage.aspx");
                    }
                    else if (DropDownList1.SelectedIndex==2)
                    {
                        Server.Transfer("Mainpage.aspx");
                    }
                    else if (DropDownList1.SelectedIndex==3)
                    {
                        Server.Transfer("webmaster.aspx");
                    }

                }
                else
                {
                    Response.Write("Error in your output");
                }
            }
            
    }
}