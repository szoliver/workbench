using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using workbench.Helper;
using workbench.Interface;

namespace workbench
{
    public partial class frmMain : Form, IWBForm
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
            FlushForm();
        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            EditConnect addconn = new EditConnect();
            addconn.ShowDialog(this);
        }

        public void FlushForm()
        {
            AccountManage am = new AccountManage();
            List<ConnectItem> ci = am.GetAccList();
            flowLayoutPanel1.Controls.Clear();
            foreach (var obj in ci)
            {
                var cbi = new ConnectionItem();
                cbi.ConnectName = obj.Name;
                cbi.HostName = obj.Host;
                cbi.UserName = obj.UserName;
                cbi.PassWord = obj.PassWord;
                cbi.Port = obj.Port;
                cbi.Key = obj.Key;
                cbi.RemoveMe += cbi_RemoveMe;
                flowLayoutPanel1.Controls.Add(cbi);
            }
        }

        void cbi_RemoveMe(object sender, CIEventArgs e)
        {
            foreach (var obj in flowLayoutPanel1.Controls.OfType<ConnectionItem>())
            {
                if (obj.Key == e.Key)
                {
                    flowLayoutPanel1.Controls.Remove(obj);
                    //更新配置文件
                    AccountManage am = new AccountManage();
                    am.DeleteAccount(e.Key);
                }
            }
        }
    }
}
