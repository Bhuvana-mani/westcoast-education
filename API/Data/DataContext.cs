using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext

    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Staff> Staffs { get; set; }
       
        public DataContext( DbContextOptions options) : base(options)
        {
        }
        
        
    }
}