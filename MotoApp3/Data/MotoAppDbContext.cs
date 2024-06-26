namespace MotoApp3.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MotoApp3.Entities;

public class MotoAppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Cars> Cars => Set<Cars>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}

