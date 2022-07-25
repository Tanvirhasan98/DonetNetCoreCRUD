using Microsoft.EntityFrameworkCore;
using TestExam2.Models;

namespace TestExam2.DataContext
{
    public class UserDataContext:DbContext
    {
        public UserDataContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<RegistrationModel> Registrations { get; set; }
    }
}
