using Microsoft.EntityFrameworkCore;
using WalletAPI.Domain.Models;

namespace WalletAPI.Infrastructure.Data;

public class WalletDbContext : DbContext
{
    public WalletDbContext(DbContextOptions options) : base(options) {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<TransactionHistory> TransactionHistory { get; set; }
    public DbSet<AccountBalance> AccountBalances { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=Wallet.db");
        }
    }
}