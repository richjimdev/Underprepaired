using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Underprepaired.Models;

namespace Underprepaired.Data
{
    public class UnderprepairedDbContext : DbContext
    {
        public UnderprepairedDbContext(DbContextOptions<UnderprepairedDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Socks 3-Pack, Black",
                    Description = "Grab this pack of socks to refill your drawer that the pesky dryer keeps stealing from.",
                    Price = 5.50M,
                    ImageURL = "~/img/3socks.jpg"
                },

                new Product
                {
                    ID = 2,
                    Name = "Diamond Encrusted Glove - Left",
                    Description = "Fulfill your Michael Jackson glove fantasy with this \"official\" glove modeled after Michael Jackson's real life glove.",
                    Price = 999.99M,
                    ImageURL = "~/img/mikeGlove.jpg"
                },

                new Product
                {
                    ID = 3,
                    Name = "Red Mitten - Right",
                    Description = "For those nights when your right hand is just too cold. Works with all left mittens.",
                    Price = 10.99M,
                    ImageURL = "~/img/rightMitten.jpg"
                },

                new Product
                {
                    ID = 4,
                    Name = "Uni-Monocle",
                    Description = "Have you ever lost half of your monocle? Look no further! The Uni-Monocle can solve all of your half-monocle problems. (No repair kit included)",
                    Price = 49.99M,
                    ImageURL = "~/img/uniMonocle.jpg"
                },

                new Product
                {
                    ID = 5,
                    Name = "Two Left Shoes",
                    Description = "Do you have two lonely right shoes? Here's two left shoes for your right shoes. Complete the random collection of footwear in your closet today!",
                    Price = 49.99M,
                    ImageURL = "~/img/twoLeftShoes.jpg"
                }
            );
        }
    }
}
