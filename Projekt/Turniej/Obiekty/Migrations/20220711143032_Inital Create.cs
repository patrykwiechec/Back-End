using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obiekty.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "obiekt",
                columns: table => new
                {
                    IdObiekt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lokalizacja = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Nazwa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Ilosc_miejsc = table.Column<int>(type: "int", nullable: false),
                    Cena_biletu = table.Column<int>(type: "int", nullable: false),
                    Cena_biletu_vip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__obiekt__4DB25A0C40E50CC4", x => x.IdObiekt);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "obiekt");
        }
    }
}
