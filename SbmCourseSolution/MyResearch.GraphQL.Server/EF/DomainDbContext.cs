using Microsoft.EntityFrameworkCore;
using MyResearch.GraphQL.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResearch.GraphQL.Server.EF
{
    public class DomainDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
    }
}
