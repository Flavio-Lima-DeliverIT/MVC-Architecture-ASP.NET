using BillToPayApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BillToPayApi.Models.DTOs;

namespace BillToPayApi.Models
{
    public class ListaContaCadastradaContext : DbContext
    {
        public ListaContaCadastradaContext(DbContextOptions<ListaContaCadastradaContext> options) : base(options)
        {

        }
        public DbSet<ListaContaCadastrada> ContaCadastradaConta { get; set; }
        public DbSet<BillToPayApi.Models.DTOs.ListaContaCadastradaDto> ListaContaCadastradaDto { get; set; }
    }
}
