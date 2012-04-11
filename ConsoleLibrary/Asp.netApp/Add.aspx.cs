using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asp.netApp.AspServiceReference;

namespace Asp.netApp
{
    public partial class Add : System.Web.UI.Page
    {
        private ConsoleClient client = new ConsoleClient("WSHttpBinding_IConsole");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void MessageBox(string message)
        {

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('" + message + "');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            bool parser=false;
            int zipcode;
            int tele=0;
            int mobile=0;
     
             if (!String.IsNullOrEmpty(txtAddress.Text) &&
                !String.IsNullOrEmpty(txtFirstName.Text) &&
                !String.IsNullOrEmpty(txtMiddleName.Text) &&
                !String.IsNullOrEmpty(txtLastName.Text) &&
                !String.IsNullOrEmpty(txtCity.Text) &&
                !String.IsNullOrEmpty(txtProvince.Text) &&
                !String.IsNullOrEmpty(txtZipCode.Text) &&
                !String.IsNullOrEmpty(txtMobile.Text) &&
                !String.IsNullOrEmpty(txtTelephone.Text) &&
                !String.IsNullOrEmpty(txtEmail.Text))
            {
                parser = int.TryParse(txtZipCode.Text, out zipcode);
                if (!parser) MessageBox("ZipCode must be Numeric.");
                else parser = int.TryParse(txtTelephone.Text, out tele);
                if (!parser) MessageBox("Telephone must be Numeric.");
                else parser = int.TryParse(txtMobile.Text, out mobile);
                if (!parser) MessageBox("Mobile must be Numeric.");
                else client.CreateAccount(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text, txtProvince.Text, zipcode, tele, mobile, txtEmail.Text);
            }
            else
            {
                    MessageBox("All Fields must be Fill in.");
            }
              
        }
    }
}