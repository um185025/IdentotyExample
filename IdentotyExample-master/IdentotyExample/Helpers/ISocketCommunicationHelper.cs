namespace AlohaAPIExample.Helpers
{
    public interface ISocketCommunicationHelper
    {
        void SendMessage(string message);
        void CloseConnection();
    }
}
