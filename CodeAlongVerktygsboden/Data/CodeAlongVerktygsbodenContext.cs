using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeAlongVerktygsboden.Models;

namespace CodeAlongVerktygsboden.Data
{
    public class CodeAlongVerktygsbodenContext : DbContext
    {
        public CodeAlongVerktygsbodenContext (DbContextOptions<CodeAlongVerktygsbodenContext> options)
            : base(options)
        {
        }

        public DbSet<CodeAlongVerktygsboden.Models.User> User { get; set; } = default!;
        public DbSet<CodeAlongVerktygsboden.Models.Asset> Asset { get; set; } = default!;
        public DbSet<CodeAlongVerktygsboden.Models.Booking> Booking { get; set; } = default!;
    }
}
