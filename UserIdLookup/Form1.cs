using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserIdLookup.Services;

namespace UserIdLookup
{
    public partial class Form1 : Form
    {
        DataAccessLayer DAL = new DataAccessLayer();
        string userName = "";
        DataTable dt = new DataTable();
        DataView dv;

        public Form1()
        {
            InitializeComponent();
            dt = DAL.findSqlUsers();
            dataGridView1.DataSource = dt;
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            userName = searchBox.Text;
            dv = DAL.queryDataTable(userName, dt);
            dataGridView1.DataSource = dv;
        }
    }
}
