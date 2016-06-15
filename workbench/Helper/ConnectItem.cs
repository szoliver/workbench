using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace workbench.Helper
{
    public class ConnectItem
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool SavePassWord { get; set; }
        public string KeySpace { get; set; }
        /// <summary>
        /// 默认7天后密码失效
        /// </summary>
        public DateTime Addtime { get; set; }
    }
}
