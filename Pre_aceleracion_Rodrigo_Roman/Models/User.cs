using Microsoft.AspNetCore.Identity;
namespace Pre_aceleracion_Rodrigo_Roman.Models
{
    public class User : IdentityUser
    {
        public bool isActive { get; set; }
        
    }
}
