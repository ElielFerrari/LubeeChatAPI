using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}