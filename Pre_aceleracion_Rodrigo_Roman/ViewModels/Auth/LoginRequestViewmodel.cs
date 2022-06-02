using System.ComponentModel.DataAnnotations;

namespace Pre_aceleracion_Rodrigo_Roman.ViewModels.Auth
{
    public class LoginRequestViewmodel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
