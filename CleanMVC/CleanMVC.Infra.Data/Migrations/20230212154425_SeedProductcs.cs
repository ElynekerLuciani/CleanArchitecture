using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanMVC.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductcs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO products(Name,Description,Price,Stock,Image,CategoryId) " +
                "VALUES('Caneta', 'Bic', 1.99, 100, 'caneta.jpg',1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM products");
        }
    }
}
