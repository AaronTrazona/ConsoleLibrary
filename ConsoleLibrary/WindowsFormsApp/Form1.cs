using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp.WindowsFormReference;
using ConsoleLibrary.Repository;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Configuration;



namespace WindowsFormsApp  
{
    public partial class frmContact : Form
    {
        private ConsoleClient client = new ConsoleClient("WSHttpBinding_IConsole");
        private Contact_Repository repo = new Contact_Repository();
        public int rowCount;
        private string contactID;
        
        public void displayDataGid()
        {
            
            dataGridView1.DataSource = repo.GetContacts();
            
            
        
        }

        private void GetNames()
        {
            if (!DoesUserHavePermission())
                return;

            string connectionString = repo.connectionString();

            //  You must stop the dependency before starting a new one.
            //  You must start the dependency when creating a new one.
            SqlDependency.Stop(connectionString);
            SqlDependency.Start(connectionString);

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM dbo.[tbl_ContactDB]";

                    cmd.Notification = null;

                    //  creates a new dependency for the SqlCommand
                    SqlDependency dep = new SqlDependency(cmd);
                    //  creates an event handler for the notification of data
                    //      changes in the database.
                    //  NOTE: the following code uses the normal .Net capitalization methods, though
                    //      the forum software seems to change it to lowercase letters
                    dep.OnChange += new OnChangeEventHandler(dep_OnChange);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            displayDataGid();
                        }
                    }
                }
            }
        }

        void dep_OnChange(object sender, SqlNotificationEventArgs e)
        {

            // this event is run asynchronously so you will need to invoke to run on UI thread(if required).
            if (this.InvokeRequired)
                dataGridView1.BeginInvoke(new MethodInvoker(GetNames));
            else
                GetNames();

            // this will remove the event handler since the dependency is only for a single notification
            SqlDependency dep = sender as SqlDependency;

            //  NOTE: the following code uses the normal .Net capitalization methods, though
            //      the forum software seems to change it to lowercase letters
            dep.OnChange -= new OnChangeEventHandler(dep_OnChange);
        }

        private bool DoesUserHavePermission()
        {
            try
            {
                SqlClientPermission clientPermission = new SqlClientPermission(PermissionState.Unrestricted);

                // will throw an error if user does not have permissions
                clientPermission.Demand();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public frmContact()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clearText();
           
            displayDataGid();
            buttonSetup();
            GetNames();
            Cursor.Current = Cursors.Default; 
        }

        private void label2_Click(object sender, EventArgs e)
        {
               
        }
        private void buttonSetup()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = true;
          
        }
        
        private void clearText()
        {
            txtAddress.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtMobile.Text="";
            txtProvince.Text = "";
            txtTelephone.Text = "";
            txtZipCode.Text = "";
            txtCity.Text = "";
            txtEmail.Text = "";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool parse = false;
            int zipcode;
            int tele;
            int mobile;
            parse = int.TryParse(txtZipCode.Text, out zipcode);
            if (!parse) zipcode = 0;
            parse = int.TryParse(txtTelephone.Text, out tele);
            if (!parse) tele = 0;
            parse = int.TryParse(txtMobile.Text, out mobile);
            if (parse)
            {
                Cursor.Current = Cursors.WaitCursor;
                client.CreateAccount(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtLastName.Text, txtCity.Text, txtProvince.Text, zipcode, tele, mobile, txtEmail.Text);
                MessageBox.Show("Successfully Created.", "Contact Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;
                displayDataGid();
                clearText();
                txtFirstName.Focus();
            }
            else
            {
                MessageBox.Show("Please input a Corret Mobile Number", "Mobile Number Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMobile.Focus();    
            }
        }

      
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                contactID = dataGridView1.Rows[rowCount].Cells[1].Value.ToString();
                txtFirstName.Text = dataGridView1.Rows[rowCount].Cells[2].Value.ToString();
                txtMiddleName.Text = dataGridView1.Rows[rowCount].Cells[3].Value.ToString();
                txtLastName.Text = dataGridView1.Rows[rowCount].Cells[4].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[rowCount].Cells[5].Value.ToString();
                txtCity.Text = dataGridView1.Rows[rowCount].Cells[6].Value.ToString();
                txtProvince.Text = dataGridView1.Rows[rowCount].Cells[7].Value.ToString();
                txtZipCode.Text = dataGridView1.Rows[rowCount].Cells[8].Value.ToString();
                txtTelephone.Text = dataGridView1.Rows[rowCount].Cells[9].Value.ToString();
                txtMobile.Text = dataGridView1.Rows[rowCount].Cells[10].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[rowCount].Cells[11].Value.ToString();
                btnDelete.Enabled = false;
                btnAdd.Enabled = false;
                btnSave.Enabled = true;
                
            }

            else
                MessageBox.Show("Please Select a Contact", "Contact Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowCount = e.RowIndex;
       
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool parse = false;
            int zipcode;
            int tele;
            int mobile;
            parse = int.TryParse(txtZipCode.Text, out zipcode);
            if (!parse) zipcode = 0;
            parse = int.TryParse(txtTelephone.Text, out tele);
            if (!parse) tele = 0;
            parse = int.TryParse(txtMobile.Text, out mobile);
            if (parse)
            {
                Cursor.Current = Cursors.WaitCursor;
                client.UpdateAccount(contactID,txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtLastName.Text, txtCity.Text, txtProvince.Text, zipcode, tele, mobile, txtEmail.Text);
                MessageBox.Show("Successfully Updated.", "Contact Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;
                displayDataGid();
                clearText();
                txtFirstName.Focus();
                buttonSetup();
            }
            else
            {
                MessageBox.Show("Please input a Corret Mobile Number", "Mobile Number Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMobile.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result;
             
                if (dataGridView1.SelectedRows.Count > 0)
            {
                 contactID = dataGridView1.Rows[rowCount].Cells[1].Value.ToString();
                result =  MessageBox.Show("Are you sure you want to delete this contact.", "Deletion Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    client.DeleteAccount(contactID);
                    Cursor.Current = Cursors.Default;
                    displayDataGid();
                }
            }

            else
                MessageBox.Show("Please Select a Contact", "Contact Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void frmContact_FormClosing(object sender, FormClosingEventArgs e)
        {
            string connectionString = repo.connectionString();
            SqlDependency.Stop(connectionString);

        }


    }

    }

