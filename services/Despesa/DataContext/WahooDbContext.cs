using Microsoft.EntityFrameworkCore;
using WahooDespesa.Model;
namespace WahooDespesa.DataContext
{
    public class WahooDbContext:DbContext
    {
        public WahooDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
