using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FTTSS
{
    class tsUtils
    {
        ArrayList arraylist = new ArrayList();


        IntPtr pServer = IntPtr.Zero;
        string sUserName = string.Empty;
        string sDomain = string.Empty;
        string sClientApplicationDirectory = string.Empty;
        string sIPAddress = string.Empty;


        public  tsUser retornausuario()
        {

            RDPDLL.WTS_CLIENT_ADDRESS oClientAddres = new RDPDLL.WTS_CLIENT_ADDRESS();
            RDPDLL.WTS_CLIENT_DISPLAY oClientDisplay = new RDPDLL.WTS_CLIENT_DISPLAY();

            IntPtr pSessionInfo = IntPtr.Zero;

            int iCount = 0;
            int iReturnValue = RDPDLL.WTSEnumerateSessions(pServer, 0, 1, ref pSessionInfo, ref iCount);
            int iDataSize = Marshal.SizeOf(typeof(RDPDLL.WTS_SESSION_INFO));

            int iCurrent = (int)pSessionInfo;

            if (iReturnValue != 0)
            {
                //Go to all sessions
                for (int i = 0; i < iCount; i++)
                {
                    tsUser users = new tsUser();
                    RDPDLL.WTS_SESSION_INFO oSessionInfo = (RDPDLL.WTS_SESSION_INFO)Marshal.PtrToStructure((System.IntPtr)iCurrent,
                    typeof(RDPDLL.WTS_SESSION_INFO));
                    iCurrent += iDataSize;
                    uint iReturned = 0;

                    //Get the IP address of the Terminal Services User
                    IntPtr pAddress = IntPtr.Zero;
                    if (RDPDLL.WTSQuerySessionInformation(pServer,
                    oSessionInfo.iSessionID, RDPDLL.WTS_INFO_CLASS.WTSClientAddress,
                    out pAddress, out iReturned) == true)
                    {
                        oClientAddres = (RDPDLL.WTS_CLIENT_ADDRESS)Marshal.PtrToStructure
                        (pAddress, oClientAddres.GetType());
                        users.SIPAddress = oClientAddres.bAddress[2] + "." +
                                oClientAddres.bAddress[3] + "." + oClientAddres.bAddress[4]
                                + "." + oClientAddres.bAddress[5];
                    }
                    //Get the User Name of the Terminal Services User
                    if (RDPDLL.WTSQuerySessionInformation(pServer,
                    oSessionInfo.iSessionID, RDPDLL.WTS_INFO_CLASS.WTSUserName,
                        out pAddress, out iReturned) == true)
                    {
                        users.SUserName = Marshal.PtrToStringAnsi(pAddress);
                    }
                    //Get the Domain Name of the Terminal Services User
                    if (RDPDLL.WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID, RDPDLL.WTS_INFO_CLASS.WTSDomainName,
                            out pAddress, out iReturned) == true)
                    {
                        users.SDomain = Marshal.PtrToStringAnsi(pAddress);
                    }
                    //Get the Display Information  of the Terminal Services User
                    if (RDPDLL.WTSQuerySessionInformation(pServer,
                oSessionInfo.iSessionID, RDPDLL.WTS_INFO_CLASS.WTSClientDisplay,
                out pAddress, out iReturned) == true)
                    {
                        oClientDisplay = (RDPDLL.WTS_CLIENT_DISPLAY)Marshal.PtrToStructure
                (pAddress, oClientDisplay.GetType());
                    }
                    //Get the Application Directory of the Terminal Services User
                    if (RDPDLL.WTSQuerySessionInformation(pServer, oSessionInfo.iSessionID,
            RDPDLL.WTS_INFO_CLASS.WTSClientDirectory, out pAddress, out iReturned) == true)
                    {
                        users.SClientApplicationDirectory = Marshal.PtrToStringAnsi(pAddress);
                    }

                    arraylist.Add(users);


                }
            }

            String WinUserNameOnly = System.Environment.UserName.ToString();
            tsUser user = new tsUser();
            foreach (tsUser users in arraylist)
            {              
                if (users.SUserName == WinUserNameOnly)
                {
                    user = users;

                }
            }

            return user;
        }


    }
}
