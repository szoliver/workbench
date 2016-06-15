using Cassandra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using workbench.Helper;

namespace workbench
{
    public partial class EditConnect : Form
    {
        public ConnectItem Model = null;
        private Builder builder = Cluster.Builder();

        public EditConnect()
        {
            InitializeComponent();
        }

        private void AddConnect_Resize(object sender, EventArgs e)
        {

        }

        private void EditConnect_Load(object sender, EventArgs e)
        {
            if (Model == null)
            {
                Model = new ConnectItem()
                {
                    Addtime = DateTime.Now,
                    Host = textBox2.Text,
                    KeySpace = comboBox1.Text,
                    Name = textBox1.Text,
                    PassWord = textBox5.Text,
                    Port = int.Parse(textBox3.Text),
                    SavePassWord = false,
                    UserName = textBox4.Text
                };
            }
            else
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Model.Host = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Model.Name = textBox1.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int port = 0;
            int.TryParse(textBox3.Text, out port);
            Model.Port = port;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Model.UserName = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Model.PassWord = textBox5.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Model.SavePassWord = checkBox1.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.KeySpace = comboBox1.Text;
        }

        /// <summary>
        /// 连接测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            TestConnect();
        }

        /// <summary>
        /// 连接测试
        /// </summary>
        private void TestConnect()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            try
            {
                var cluster = builder.AddContactPoints(Model.Host.Split(','))
                    .WithCredentials(Model.UserName, Model.PassWord)
                    .Build();
                var kpist = cluster.Metadata.GetKeyspaces();
                comboBox1.Items.Clear();
                foreach (var s in kpist)
                {
                    if (s != "system" && s != "system_auth")
                        comboBox1.Items.Add(s);
                }
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
                //var session = cluster.Connect("scylladata");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

    }
}
