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
<<<<<<< HEAD
        public Ambiente ambiente; 
=======
        public Ambiente ambiente;
   
>>>>>>> 9a00bf2a539ed475c79c8c91edeb8c7ba53901f0
       



        public struct methods
        {
            public const int Enroll = 0;
            public const int Capturar = 1;           
        }

<<<<<<< HEAD

=======
       
      




>>>>>>> 9a00bf2a539ed475c79c8c91edeb8c7ba53901f0
        public Connect()
        {
            tsuser = new tsUser();
            tsutils = new tsUtils();
            tsuser = tsutils.retornausuario();
<<<<<<< HEAD
            ambiente = new Ambiente(tsuser);
           
           

=======

            ambiente = new Ambiente(tsuser);
           
           

>>>>>>> 9a00bf2a539ed475c79c8c91edeb8c7ba53901f0
        }




    public string getDigitalString(int digital)
        {
<<<<<<< HEAD
            return enviarRequisição(tsuser.SIPAddress, digital);
            //return enviarRequisição("192.168.1.52", digital); < para debug local
=======
            //return enviarRequisição(tsuser.SIPAddress, digital);
            return enviarRequisição("192.168.1.52", digital);

            
>>>>>>> 9a00bf2a539ed475c79c8c91edeb8c7ba53901f0

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
<<<<<<< HEAD
                data = new Byte[100000];
=======
                data = new Byte[40000];
>>>>>>> 9a00bf2a539ed475c79c8c91edeb8c7ba53901f0

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
