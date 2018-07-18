using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrBrApDs
{
    public partial class FrmAppDs : Form
    {
        public FrmAppDs()
        {
            InitializeComponent();
        }

        private void FrmAppDs_Load(object sender, EventArgs e)
        {
            var t = DateTime.Now.ToString();
            txbEnter.Text = t;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            var t = DateTime.Now.ToString();
            txbEnter.Text = t;
        }
    }
}
