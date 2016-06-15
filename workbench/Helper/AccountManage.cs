using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace workbench.Helper
{
    class AccountManage
    {
        public string DataDir { get; set; }

        public AccountManage()
        {
            DataDir = AppDomain.CurrentDomain.BaseDirectory + "accounts.dat";
            if (!File.Exists(DataDir))
                InitEmpty();
        }

        public void InitEmpty()
        {
            //写入一个空list
            List<ConnectItem> temp = new List<ConnectItem>();
            SaveList(temp);
        }

        public List<ConnectItem> GetAccList()
        {
            List<ConnectItem> ret = new List<ConnectItem>();
            FileStream fs = new FileStream(DataDir, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            byte[] buffer = br.ReadBytes((int)fs.Length);
            ret = JsonConvert.DeserializeObject<List<ConnectItem>>(EncryptUtils.DESDecrypt(Encoding.UTF32.GetString(buffer), "6SUHDbR9", "vkWMQQxZ"));
            br.Close();
            fs.Close();
            return ret;
        }

        public void AddAccount(ConnectItem item)
        {
            //此时文件一定是存在的
            List<ConnectItem> temp = new List<ConnectItem>();
            if (item != null)
            {
                temp = GetAccList();
                temp.Add(item);
            }
            SaveList(temp);
        }

        public void SaveList(List<ConnectItem> list)
        {
            FileStream fs = new FileStream(DataDir, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            byte[] buffer = Encoding.UTF32.GetBytes(EncryptUtils.DESEncrypt(JsonConvert.SerializeObject(list), "6SUHDbR9", "vkWMQQxZ"));

            bw.Write(buffer, 0, buffer.Length);
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        public void DeleteAccount(string key)
        {
            List<ConnectItem> temp = GetAccList();
            ConnectItem ci = temp.Where(k => k.Key == key).FirstOrDefault();
            if (ci != null)
            {
                temp.Remove(ci);
                SaveList(temp);
            }
        }

    }
}
