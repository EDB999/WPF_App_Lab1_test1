using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WPF_App_Lab1_test1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id_car = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    model = table.Column<string>(type: "character varying", nullable: true),
                    number = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Cars_pkey", x => x.id_car);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id_client = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    surname = table.Column<string>(type: "character varying", nullable: true),
                    patronymic = table.Column<string>(type: "character varying", nullable: true),
                    phone = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Clients_pkey", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id_driver = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    surname = table.Column<string>(type: "character varying", nullable: true),
                    phone_driver = table.Column<string>(type: "character varying", nullable: true),
                    rating = table.Column<string>(type: "character varying", nullable: true),
                    id_car = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Drivers_pkey", x => x.Id_driver);
                    table.ForeignKey(
                        name: "fkey_car",
                        column: x => x.id_car,
                        principalTable: "Cars",
                        principalColumn: "id_car");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id_order = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<string>(type: "character varying", nullable: true),
                    time = table.Column<string>(type: "character varying", nullable: true),
                    date = table.Column<string>(type: "character varying", nullable: true),
                    id_client = table.Column<int>(type: "integer", nullable: true),
                    id_driver = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Orders_pkey", x => x.id_order);
                    table.ForeignKey(
                        name: "fkey_client",
                        column: x => x.id_client,
                        principalTable: "Clients",
                        principalColumn: "id_client");
                    table.ForeignKey(
                        name: "fkey_driver",
                        column: x => x.id_driver,
                        principalTable: "Drivers",
                        principalColumn: "Id_driver");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_id_car",
                table: "Drivers",
                column: "id_car");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_client",
                table: "Orders",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_driver",
                table: "Orders",
                column: "id_driver");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
