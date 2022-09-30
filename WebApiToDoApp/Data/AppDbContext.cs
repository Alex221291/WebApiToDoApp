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
       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //  {
       //     optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Tasks;Username=postgres;Password=l22a12m91");
        //}
    }

}