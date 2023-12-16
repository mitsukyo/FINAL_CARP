using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2CARPENELLI
{
    public partial class QuickHelp : Form
    {
        StartUpForm frm1;
        public QuickHelp(StartUpForm sform)
        {
            InitializeComponent();
            frm1 = sform;



        }

        private void QuickHelp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm1.FormBorderStyle = FormBorderStyle.None;
            frm1.WindowState = FormWindowState.Maximized;
        }
    }
}
