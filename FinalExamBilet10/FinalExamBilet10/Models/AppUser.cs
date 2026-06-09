using Microsoft.AspNetCore.Identity;

namespace FinalExamBilet10.Models
{
    public class AppUser :IdentityUser
    {
        public string FullName { get; set; }
    }
}
