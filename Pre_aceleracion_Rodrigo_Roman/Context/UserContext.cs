using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pre_aceleracion_Rodrigo_Roman.Models;

namespace Pre_aceleracion_Rodrigo_Roman.Context
{
    public class UserContext : IdentityDbContext<User>
    {
        private const string Schema = "Users";

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);
        }

    }
}