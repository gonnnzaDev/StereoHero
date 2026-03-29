using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class creacionBDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Producers_produceByid",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_Products_produceByid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "produceByid",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "produceBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "produceBy",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "produceByid",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_produceByid",
                table: "Products",
                column: "produceByid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Producers_produceByid",
                table: "Products",
                column: "produceByid",
                principalTable: "Producers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
