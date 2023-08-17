using System.Net.Sockets;
using System.Text;

namespace AlohaAPIExample.Helpers
{
    public class SocketCommunicationHelper : ISocketCommunicationHelper
    {
        private readonly string serverIp;
        private readonly int port;
        private TcpClient client;

        public SocketCommunicationHelper(string serverIp, int port)
        {
            this.serverIp = serverIp;
            this.port = port;
        }

        public void SendMessage(string message)
        {
            try
            {
                client = new TcpClient();
                client.Connect(serverIp, port);
                using NetworkStream stream = client.GetStream();
                byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                stream.Write(messageBytes, 0, messageBytes.Length);
                stream.Close();
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Error sending message: ", ex.Message);
            }
        }

        public void CloseConnection()
        {
            client.Close();
        }
    }
}
