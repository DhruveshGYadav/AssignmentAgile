using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Common
{
    public class EFContext:DbContext
    {
        public EFContext(DbContextOptions dbContext):base(dbContext) { }
        public virtual DbSet<Employee> Employee { get; set; } = null!;        
    }
}