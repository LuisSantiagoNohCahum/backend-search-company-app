using Microsoft.EntityFrameworkCore;
using backend_app.Models;

namespace backend_app.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Empresa> Empresas { get; set; }
    }
}