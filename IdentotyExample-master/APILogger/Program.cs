
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string serverIp = "127.0.0.1";
            int port = 5000;
            TcpListener listener = new TcpListener(IPAddress.Parse(serverIp), port);
            listener.Start();
            Console.WriteLine("Listening...");
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("API call received from: " + client.Client.RemoteEndPoint);
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("API call: " + receivedMessage);
            }
            stream.Close();
            client.Close();
            listener.Stop();

        }
    }
}