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
    public partial class frmDashboard : Form
    {
        //private OleDbConnection connection = new OleDbConnection();
        public string CmdText = "SELECT * FROM [LIST]";
        public string ConnString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source=movie_db.accdb;";
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Hide();
            login.ShowDialog();
        }

        private void btnAddTitles_Click(object sender, EventArgs e)
        {
            frmAddTitles aT = new frmAddTitles();
            this.Hide();
            aT.ShowDialog();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //connection.Open();
            try
            {
                OleDbCommand command = new OleDbCommand();
                CmdText = "SELECT * FROM [LIST] WHERE GENRE = '" + cmbGenres.Text + "'AND TYPE = '" + cmbType.Text + "'";
                OleDbDataAdapter dA = new OleDbDataAdapter(CmdText, ConnString);
                DataSet ds = new DataSet();
                dA.Fill(ds, "[LIST]");
                dgvFilterResult.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //connection.Close();
        }
    }
}
