namespace IdentotyExample.Models.Dto
{
    public class OutUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OutAddressDto> Addresses { get; set; }
    }
}
