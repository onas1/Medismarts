using Microsoft.EntityFrameworkCore;
using Registration.Api.Entities;

namespace Registration.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<UserRegistrationForm> UserRegistration { get; set; }

    }


}
