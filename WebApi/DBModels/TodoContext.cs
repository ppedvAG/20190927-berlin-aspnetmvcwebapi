using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DBModels
{
    public class TodoContext: IdentityDbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoOwner>()
                .HasKey(to => new { to.TodoId, to.OwnerId });
        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<TodoOwner> TodoOwners { get; set; }
    }
}
