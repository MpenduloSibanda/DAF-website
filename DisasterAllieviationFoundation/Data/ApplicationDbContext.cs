using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DisasterAllieviationFoundation.Models;

namespace DisasterAllieviationFoundation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DisasterAllieviationFoundation.Models.MonetaryDonations> MonetaryDonations { get; set; }
        public DbSet<DisasterAllieviationFoundation.Models.GoodsDonations> GoodsDonations { get; set; }
        public DbSet<DisasterAllieviationFoundation.Models.Disasters> Disasters { get; set; }
    }
}
