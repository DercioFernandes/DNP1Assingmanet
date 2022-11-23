using Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class PostContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Post.db");    
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasKey(post => post.idPost);
        modelBuilder.Entity<User>().HasKey(user => user.idUser);
        
        modelBuilder.Entity<Post>().Property(post => post.title).HasMaxLength(50);
    }
}