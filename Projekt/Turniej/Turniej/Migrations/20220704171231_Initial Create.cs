using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turniej.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trenerzy",
                columns: table => new
                {
                    id_trenera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie_t = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    nazwisko_t = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    ile_medali_t = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__trenerzy__E25E0CF801356BA1", x => x.id_trenera);
                });

            migrationBuilder.CreateTable(
                name: "zawody",
                columns: table => new
                {
                    id_zawodow = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lokalizacja = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__zawody__4E37E54B3297864F", x => x.id_zawodow);
                });

            migrationBuilder.CreateTable(
                name: "zawodnicy",
                columns: table => new
                {
                    id_zawodnika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    nazwisko = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    kraj = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ile_medali_t = table.Column<int>(type: "int", nullable: false),
                    id_trenera = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__zawodnic__96B2F8BC6BADB5CD", x => x.id_zawodnika);
                    table.ForeignKey(
                        name: "FK__zawodnicy__id_tr__286302EC",
                        column: x => x.id_trenera,
                        principalTable: "trenerzy",
                        principalColumn: "id_trenera");
                });

            migrationBuilder.CreateTable(
                name: "uczestnictwo",
                columns: table => new
                {
                    id_uczestnictwa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_zawodnika = table.Column<int>(type: "int", nullable: true),
                    id_zawodow = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__uczestni__79BC730BAA104BC4", x => x.id_uczestnictwa);
                    table.ForeignKey(
                        name: "FK__uczestnic__id_za__2B3F6F97",
                        column: x => x.id_zawodnika,
                        principalTable: "zawodnicy",
                        principalColumn: "id_zawodnika");
                    table.ForeignKey(
                        name: "FK__uczestnic__id_za__2C3393D0",
                        column: x => x.id_zawodow,
                        principalTable: "zawody",
                        principalColumn: "id_zawodow");
                });

            migrationBuilder.CreateIndex(
                name: "IX_uczestnictwo_id_zawodnika",
                table: "uczestnictwo",
                column: "id_zawodnika");

            migrationBuilder.CreateIndex(
                name: "IX_uczestnictwo_id_zawodow",
                table: "uczestnictwo",
                column: "id_zawodow");

            migrationBuilder.CreateIndex(
                name: "IX_zawodnicy_id_trenera",
                table: "zawodnicy",
                column: "id_trenera");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uczestnictwo");

            migrationBuilder.DropTable(
                name: "zawodnicy");

            migrationBuilder.DropTable(
                name: "zawody");

            migrationBuilder.DropTable(
                name: "trenerzy");
        }
    }
}
