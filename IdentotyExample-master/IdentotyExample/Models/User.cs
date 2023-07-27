using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentotyExample.Models
{
    public class User : IdentityUser
    {
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
