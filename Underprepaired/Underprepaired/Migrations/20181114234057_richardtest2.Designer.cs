﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Underprepaired.Data;

namespace Underprepaired.Migrations
{
    [DbContext(typeof(UnderprepairedDbContext))]
    [Migration("20181114234057_richardtest2")]
    partial class richardtest2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Underprepaired.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("ImageURL");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new { ID = 1, Description = "Grab this pack of socks to refill your drawer that the pesky dryer keeps stealing from.", ImageURL = "~/img/3socks.jpg", Name = "Socks 3-Pack, Black", Price = 5.50m },
                        new { ID = 2, Description = "Fulfill your Michael Jackson glove fantasy with this \"official\" glove modeled after Michael Jackson's real life glove.", ImageURL = "~/img/mikeGlove.jpg", Name = "Diamond Encrusted Glove - Left", Price = 999.99m },
                        new { ID = 3, Description = "For those nights when your right hand is just too cold. Works with all left mittens.", ImageURL = "~/img/rightMitten.jpg", Name = "Red Mitten - Right", Price = 10.99m },
                        new { ID = 4, Description = "Have you ever lost half of your monocle? Look no further! The Uni-Monocle can solve all of your half-monocle problems. (No repair kit included)", ImageURL = "~/img/uniMonocle.jpg", Name = "Uni-Monocle", Price = 49.99m },
                        new { ID = 5, Description = "Do you have two lonely right shoes? Here's two left shoes for your right shoes. Complete the random collection of footwear in your closet today!", ImageURL = "~/img/twoLeftShoes.jpg", Name = "Two Left Shoes", Price = 49.99m },
                        new { ID = 6, Description = "For when you are missing that key component to your next sandwich. Order this slice of bread to help keep the contents of your sandwich from falling in your lap.", ImageURL = "~/img/breadSlice.jpg", Name = "Slice Of Bread", Price = 1.99m },
                        new { ID = 7, Description = "Next time you lose a pant hopping the fence running from the law don't worry! This genuine pant will be ready for you to apply to your current lacking pair of pants in a jiffy.", ImageURL = "~/img/pant.jpg", Name = "Pant", Price = 19.99m },
                        new { ID = 8, Description = "Did that \"big one\" get away again and this time take your half-pole with it? Get back out there and teach that ro... fish a lesson with your new half-pole. (May not work with current fishing pole)", ImageURL = "~/img/halfPole.jpg", Name = "Fishing Pole - Top Half", Price = 99.99m },
                        new { ID = 9, Description = "Sometimes all of those Big Macs don't do your figure any justice. The half-belt can be used to extend your current belt or maybe fix it. The ball is in your court now.", ImageURL = "~/img/halfBelt.jpg", Name = "Half-Belt", Price = 14.99m },
                        new { ID = 10, Description = "Does your mug get too hot in the morning? Have you recently dropped your favorite sarcastic phrased mug only for the handle to be shattered in a million pieces? This mug handle fits great with the mug of your dreams so now you don't have throw it away while crying.", ImageURL = "~/img/mugHandle.jpg", Name = "Mug Handle", Price = 4.99m }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
