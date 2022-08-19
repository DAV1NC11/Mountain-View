using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MountainView
{
    public partial class frmAddTitles : Form
    {
        public frmAddTitles()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add Title Button. Can't risk loosing UI juu ya naming mazee.
            try
            {
                string movieName = txtMovieName.Text;
                string rating = txtRating.Text;
                string movieYear = txtYear.Text;
                string genre = cmbGenre.Text;
                string movieType = cmbMovieType.Text;

                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data source= movie_db.accdb";
                conn.Open();

                String my_querry = "INSERT INTO LIST(MOVIE_NAME, GENRE, RATING, MOVIE_YEAR, TYPE)VALUES('" + movieName + "','" + genre + "','" + rating + "', '" + movieYear + "', '" + movieType + "')";

                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data saved successfuly...!");
                conn.Close();
            }
            catch (Exception ds)
            {
                MessageBox.Show(ds.Message);
            }
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtMovieName.Clear();
            txtRating.Clear();
            txtYear.Clear();
            cmbGenre.SelectedItem = null;
            cmbMovieType.SelectedItem = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
