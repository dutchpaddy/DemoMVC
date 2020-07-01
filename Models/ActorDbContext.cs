using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoMVC.Models
{
    public partial class ActorDbContext : DbContext
    {
        public ActorDbContext()
        {
        }

        public ActorDbContext(DbContextOptions<ActorDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actors> Actors { get; set; }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
