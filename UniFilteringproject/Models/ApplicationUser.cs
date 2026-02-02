using Microsoft.AspNetCore.Identity;
namespace UniFilteringproject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}