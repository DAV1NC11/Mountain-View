using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MountainView
{
    public partial class frmLogin : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public frmLogin()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source=movie_db.accdb;";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Credentials where username = '"+ txtUserName.Text+"' and password = '" +txtPassword.Text+ "'";
            OleDbDataReader reader = command.ExecuteReader();

            int count = 0;
            while(reader.Read())
            {
                count ++;
            }

            if (count == 1)
            {
                MessageBox.Show("Authentication Successful");
                count = 1;
               // this.Hide();
                frmDashboard dashboard = new frmDashboard();
                dashboard.Show();
                this.Hide();
            }

           // if (count > 1)
          //  {
         //       MessageBox.Show("Duplicate Entries in Database. Please Update.");
         //   }

            else
            {
                MessageBox.Show("Incorrect Username or Password");
            }


            connection.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
    }
}
