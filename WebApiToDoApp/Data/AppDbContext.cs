using Microsoft.EntityFrameworkCore;
using WebApiToDoApp.Models;

namespace WebApiToDoApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ToDo> Tasks { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}