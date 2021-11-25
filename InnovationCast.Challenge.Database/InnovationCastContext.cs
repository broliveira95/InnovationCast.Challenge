using InnovationCast.Challenge.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnovationCast.Challenge.Database
{
    public class InnovationCastContext : DbContext
    {
        public InnovationCastContext(DbContextOptions<InnovationCastContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }
}
