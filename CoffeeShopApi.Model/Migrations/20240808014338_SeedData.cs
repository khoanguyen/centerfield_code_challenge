using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShopApi.Model.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("CoffeeShops",
                new[] { "Name", "OpeningTime", "ClosingTime" },
                new object[,] {
                    { "LA Fancy", TimeOnly.Parse("8:00"), TimeOnly.Parse("23:00") },
                    { "Porto's", TimeOnly.Parse("8:30"), TimeOnly.Parse("22:00") },
                    { "Sencha", TimeOnly.Parse("6:00"), TimeOnly.Parse("0:00") },
                    { "Boba Ave", TimeOnly.Parse("0:00"), TimeOnly.Parse("0:00") },
                    { "Uratu", TimeOnly.Parse("7:00"), TimeOnly.Parse("20:00") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE CoffeeShops");
        }
    }
}
