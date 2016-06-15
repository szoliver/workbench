using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workbench
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmmain_Load(object sender, EventArgs e)
        {
            //leftMenu form2 = new leftMenu();
            //form2.Show(this.dockPanel1);
            //form2.DockTo(this.dockPanel1, DockStyle.Left);
        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            EditConnect addconn = new EditConnect();
            addconn.ShowDialog(this);
        }
    }
}
