using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class OrderMetadata
    {
        public ClientPlatformType ClientPlatform { get; set; }
        public string ClientVersion { get; set; }
        public string Channel { get; set; }
    }
}
