using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FTTSS
{
    public class Connect
    {
        String WinUserNameOnly = System.Environment.UserName.ToString();
        tsUser tsuser;
        tsUtils tsutils;

        public Ambiente ambiente; 

  

       



        public struct methods
        {
            public const int Enroll = 0;
            public const int Capturar = 1;           
        }


      



        public Connect()
        {
            tsuser = new tsUser();
            tsutils = new tsUtils();
            tsuser = tsutils.retornausuario();

            ambiente = new Ambiente(tsuser);
           
           

           


        }




    public string getDigitalString(int digital)
        {

            return enviarRequisição(tsuser.SIPAddress, digital);
            //return enviarRequisição("192.168.1.52", digital); //< para debug local

            

            


        }

        private String enviarRequisição(String ip, int envio)
        {
            Int32 port = 13000;

            try
            {                              

                TcpClient client = new TcpClient(ip, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(envio.ToString());
                // Get a client stream for reading and writing.
                // Stream stream = client.GetStream();
                NetworkStream stream = client.GetStream();
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
               

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.

                data = new Byte[100000];
              


                // String to store the response ASCII representation.
                String responseData = String.Empty;
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
              
                client.Close();
                return responseData;
                
               
            }
            catch (ArgumentNullException e)
            {
                return e.ToString();
            }

        }




    }
}
