using Pre_aceleracion_Rodrigo_Roman.Models;

namespace Pre_aceleracion_Rodrigo_Roman.Interfaces
{
    public interface IMailService
    {
        /// <summary>
        /// Envia Emails a un username particular
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task SendEmail(User user);
    }
}