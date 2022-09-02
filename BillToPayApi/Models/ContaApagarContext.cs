using BillToPayApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillToPayApi.Models
{
    public class ContaApagarContext : DbContext
    {
        public ContaApagarContext(DbContextOptions<ContaApagarContext> options) : base(options)
        {

        }
        public DbSet<ContaApagar> ContaApagar { get; set; }
        
    }
}
