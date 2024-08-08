using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CoffeeShopApi.Shared;
using System.Configuration;
using CoffeeShopApi.Model.Config;


namespace CoffeeShopApi.Model;

public class CoffeeShopContext : DbContext
{
    public DbSet<CoffeeShop> CoffeeShops { get; set; }        

    private string _connStr;


    public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) : base(options) { }

    //public CoffeeShopContext(IOptions<ConnectionStrings> connectStrings)
    //{
    //    _connStr = connectStrings.Value.CoffeeShop;
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        new CoffeeShopConfiguration().Configure(builder.Entity<CoffeeShop>());
        
    }

}
