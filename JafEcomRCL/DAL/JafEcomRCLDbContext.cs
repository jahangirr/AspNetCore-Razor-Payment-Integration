using JafEcomRCL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JafEcomRCL.DAL
{
    public class JafEcomRCLDbContext : DbContext
    {
        public JafEcomRCLDbContext(DbContextOptions<JafEcomRCLDbContext> options) : base(options)
        {
           
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\sqlexpress;database=JafEcom;trusted_connection=true;", optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Item>().HasData(new Item() { Id = 1 , ProductName = "Mission" }, new Item() { Id = 2 , ProductName = "aBokk" });
            
        }



        
        public DbSet<PaymentLog> PaymentLog { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
