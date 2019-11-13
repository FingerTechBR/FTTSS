using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTTSS
{
    public class Ambiente
    {
        public string ip;
        public string user;

        public Ambiente(tsUser user)
        {
            this.ip = user.SIPAddress;
            this.user = user.SUserName;

        }
    }
}
