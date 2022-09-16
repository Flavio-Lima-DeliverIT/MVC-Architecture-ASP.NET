using BillToPayApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillToPayApi.Models.Database
{
    public class ContaApagarContext : DbContext
    {
        public ContaApagarContext(DbContextOptions<ContaApagarContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
         public DbSet<ContaApagar> ContaApagar { get; set; }
        

    }
}
