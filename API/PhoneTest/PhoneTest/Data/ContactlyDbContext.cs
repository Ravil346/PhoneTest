using Microsoft.EntityFrameworkCore;
using PhoneTest.Models.Domain;

namespace PhoneTest.Data
{
    public class ContactlyDbContext : DbContext
    {
        public ContactlyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
