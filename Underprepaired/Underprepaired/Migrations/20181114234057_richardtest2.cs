using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Underprepaired.Migrations
{
    public partial class richardtest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Grab this pack of socks to refill your drawer that the pesky dryer keeps stealing from.", "~/img/3socks.jpg", "Socks 3-Pack, Black", 5.50m },
                    { 2, "Fulfill your Michael Jackson glove fantasy with this \"official\" glove modeled after Michael Jackson's real life glove.", "~/img/mikeGlove.jpg", "Diamond Encrusted Glove - Left", 999.99m },
                    { 3, "For those nights when your right hand is just too cold. Works with all left mittens.", "~/img/rightMitten.jpg", "Red Mitten - Right", 10.99m },
                    { 4, "Have you ever lost half of your monocle? Look no further! The Uni-Monocle can solve all of your half-monocle problems. (No repair kit included)", "~/img/uniMonocle.jpg", "Uni-Monocle", 49.99m },
                    { 5, "Do you have two lonely right shoes? Here's two left shoes for your right shoes. Complete the random collection of footwear in your closet today!", "~/img/twoLeftShoes.jpg", "Two Left Shoes", 49.99m },
                    { 6, "For when you are missing that key component to your next sandwich. Order this slice of bread to help keep the contents of your sandwich from falling in your lap.", "~/img/breadSlice.jpg", "Slice Of Bread", 1.99m },
                    { 7, "Next time you lose a pant hopping the fence running from the law don't worry! This genuine pant will be ready for you to apply to your current lacking pair of pants in a jiffy.", "~/img/pant.jpg", "Pant", 19.99m },
                    { 8, "Did that \"big one\" get away again and this time take your half-pole with it? Get back out there and teach that ro... fish a lesson with your new half-pole. (May not work with current fishing pole)", "~/img/halfPole.jpg", "Fishing Pole - Top Half", 99.99m },
                    { 9, "Sometimes all of those Big Macs don't do your figure any justice. The half-belt can be used to extend your current belt or maybe fix it. The ball is in your court now.", "~/img/halfBelt.jpg", "Half-Belt", 14.99m },
                    { 10, "Does your mug get too hot in the morning? Have you recently dropped your favorite sarcastic phrased mug only for the handle to be shattered in a million pieces? This mug handle fits great with the mug of your dreams so now you don't have throw it away while crying.", "~/img/mugHandle.jpg", "Mug Handle", 4.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
