using BillToPayApi.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BillToPayApi.Models
{
    public class ContaApagarContext : DbContext
    {
        public ContaApagarContext(DbContextOptions<ContaApagarContext> options) : base(options)
        {

        }
       // public DbSet<ContaApagar> ContaApagar { get; set; }
        public DbSet<ContaApagarDto> ContaApagarDto { get; set; }
        
    }
}
