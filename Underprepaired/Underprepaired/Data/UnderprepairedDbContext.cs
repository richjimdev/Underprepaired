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
                },
                
                new Product
                {
                    ID = 6,
                    Name = "Slice Of Bread",
                    Description = "For when you are missing that key component to your next sandwich. Order this slice of bread to help keep the contents of your sandwich from falling in your lap.",
                    Price = 1.99M,
                    ImageURL = "~/img/breadSlice.jpg"
                },

                new Product
                {
                    ID = 7,
                    Name = "Pant",
                    Description = "Next time you lose a pant hopping the fence running from the law don't worry! This genuine pant will be ready for you to apply to your current lacking pair of pants in a jiffy.",
                    Price = 19.99M,
                    ImageURL = "~/img/pant.jpg"
                },

                new Product
                {
                    ID = 8,
                    Name = "Fishing Pole - Top Half",
                    Description = "Did that \"big one\" get away again and this time take your half-pole with it? Get back out there and teach that ro... fish a lesson with your new half-pole. (May not work with current fishing pole)",
                    Price = 99.99M,
                    ImageURL = "~/img/halfPole.jpg"
                },
                
                new Product
                {
                    ID = 9,
                    Name = "Half-Belt",
                    Description = "Sometimes all of those Big Macs don't do your figure any justice. The half-belt can be used to extend your current belt or maybe fix it. The ball is in your court now.",
                    Price = 14.99M,
                    ImageURL = "~/img/halfBelt.jpg"
                },
                
                new Product
                {
                    ID = 10,
                    Name = "Mug Handle",
                    Description = "Does your mug get too hot in the morning? Have you recently dropped your favorite sarcastic phrased mug only for the handle to be shattered in a million pieces? This mug handle fits great with the mug of your dreams so now you don't have throw it away while crying.",
                    Price = 4.99M,
                    ImageURL = "~/img/mugHandle.jpg"
                }
            );
        }

        public DbSet<Product> Products { get; set; }

    }
}
