using DatabaseTemplateREST.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTemplateREST
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}