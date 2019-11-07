using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTTSS
{
    class Connect
    {
        String WinUserNameOnly = System.Environment.UserName.ToString();
        tsUser tsuser;

        tsUtils tsutils;
       
        public Connect()
        {
            tsuser = new tsUser();
            tsutils = new tsUtils();
            tsuser = tsutils.retornausuario();
            enviarRequisição(tsuser.SIPAddress);
            

        }





        private void enviarRequisição(String ip)
        {


        }
    }
}
