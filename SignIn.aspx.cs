﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace PrisonManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ABDULWAHAB;Initial Catalog=PrisonManagementSystem;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {

            checkAdmin();

        }

        public void checkAdmin()
        {
            string username = txt_Username.Text;
            string password = txt_Password.Text;
            string qry = "select * from AdminTable where username='" + username + "' and password='" + password + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Response.Redirect("AdminHomePage.aspx");
            }
            else
            {
                lblError.Text = "Username & Password Is not correct Try again..!!";
            }
        }
        public void checkJailor()
        {
            string id = txt_Username.Text;
            string password = txt_Password.Text;
            string qry = "select * from JailorTable where jailorID='" + id + "' and password='" + password + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Response.Redirect("JailorMainPage.aspx");
            }
            else
            {
                lblError.Text = "Username & Password Is not correct Try again..!!";
            }
        }

        public void checkGaurd()
        {
            string id = txt_Username.Text;
            string password = txt_Password.Text;
            string qry = "select * from gaurdTable where gaurdID='" + id + "' and password='" + password + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Response.Redirect("GaurdHomePage.aspx");
            }
            else
            {
                lblError.Text = "Username & Password Is not correct Try again..!!";
            }
        }
    }
}