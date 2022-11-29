using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AtividadeMVC1.EF;

namespace AtividadeMVC1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AtividadeMVC1.EF.Cliente> Cliente { get; set; }
        public DbSet<AtividadeMVC1.EF.Cancelamento> Cancelamento { get; set; }
    }
}
