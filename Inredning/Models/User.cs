using Microsoft.AspNetCore.Identity;

namespace Inredning.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; } //there is an Id in base class but it is a string, this one is here in case I need something simpler
        //public string UserName { get; set; } base class
        //public string Email { get; set; }  base class
    }
}