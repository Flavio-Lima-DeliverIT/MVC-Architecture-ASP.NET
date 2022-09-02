using BillToPayApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillToPayApi.Models
{
    public class ListaContaCadastradaContext : DbContext
    {
        public ListaContaCadastradaContext(DbContextOptions<ListaContaCadastradaContext> options) : base(options)
        {

        }
        public DbSet<ListaContaCadastrada> ContaCadastradaConta { get; set; }
    }
}
