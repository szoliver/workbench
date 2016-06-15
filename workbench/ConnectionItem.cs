using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workbench
{
    public partial class ConnectionItem : UserControl
    {
        public ConnectionItem()
        {
            InitializeComponent();
        }

        private string _connectname = "";
        public string ConnectName
        {
            get { return _connectname; }
            set
            {
                _connectname = value;
                connName.Text = _connectname;
            }
        }

        private string _hostname = "";
        public string HostName
        {
            get { return _hostname; }
            set
            {
                _hostname = value;
                if (Port != 0)
                    label2.Text = _hostname + ":" + Port;
                else
                    label2.Text = _hostname;
            }
        }

        private int _port = 0;
        public int Port
        {
            get { return _port; }
            set
            {
                _port = value;
                if (HostName != "")
                    label2.Text = HostName + ":" + _port;
                else
                    label2.Text = "0.0.0.0:" + _port;
            }
        }

        private string _username = "";
        public string UserName
        {
            get { return _username; }
            set { _username = value; label1.Text = _username; }
        }

        private string _password = "";
        public string PassWord
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _key = "";
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            RemoveMe(this, new CIEventArgs() { Key = this.Key });
        }

        public delegate void CIEventHandler(object sender, CIEventArgs e);

        public event CIEventHandler RemoveMe;
    }

    public class CIEventArgs : EventArgs
    {
        public string Key = "";
    }

}
