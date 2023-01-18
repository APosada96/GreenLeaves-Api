using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenLeaves.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GreenLeavesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Telephone = table.Column<int>(type: "INT", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Date = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    CityAndState = table.Column<string>(type: "VARCHAR(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    IdState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_State_IdState",
                        column: x => x.IdState,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Colombia" });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "IdCountry", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Amazonas" },
                    { 2, 1, "Antioquia" },
                    { 3, 1, "Arauca" },
                    { 4, 1, "Atlántico" },
                    { 5, 1, "Bogotá" },
                    { 6, 1, "Bolívar" },
                    { 7, 1, "Boyacá" },
                    { 8, 1, "Caldas" },
                    { 9, 1, "Caquetá" },
                    { 10, 1, "Casanare" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "IdCountry", "IdState", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "Leticia" },
                    { 2, 1, 2, "Medellín" },
                    { 3, 1, 3, "Arauca" },
                    { 4, 1, 4, "Barranquilla" },
                    { 5, 1, 5, "Bogotá" },
                    { 6, 1, 6, "Cartagena" },
                    { 7, 1, 7, "Tunja" },
                    { 8, 1, 8, "Manizales" },
                    { 9, 1, 9, "Florencia" },
                    { 10, 1, 10, "Yopal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_IdCountry",
                table: "City",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_City_IdState",
                table: "City",
                column: "IdState");

            migrationBuilder.CreateIndex(
                name: "IX_State_IdCountry",
                table: "State",
                column: "IdCountry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
