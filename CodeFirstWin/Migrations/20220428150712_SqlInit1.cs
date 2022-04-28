using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWin.Migrations
{
    public partial class SqlInit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stoklar_Kategoriler_kategoriId",
                table: "Stoklar");

            migrationBuilder.DropIndex(
                name: "IX_Stoklar_kategoriId",
                table: "Stoklar");

            migrationBuilder.DropColumn(
                name: "kategoriId",
                table: "Stoklar");

            migrationBuilder.CreateTable(
                name: "KategoriStok",
                columns: table => new
                {
                    StoklarId = table.Column<int>(type: "int", nullable: false),
                    kategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriStok", x => new { x.StoklarId, x.kategoriId });
                    table.ForeignKey(
                        name: "FK_KategoriStok_Kategoriler_kategoriId",
                        column: x => x.kategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategoriStok_Stoklar_StoklarId",
                        column: x => x.StoklarId,
                        principalTable: "Stoklar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KategoriStok_kategoriId",
                table: "KategoriStok",
                column: "kategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategoriStok");

            migrationBuilder.AddColumn<int>(
                name: "kategoriId",
                table: "Stoklar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stoklar_kategoriId",
                table: "Stoklar",
                column: "kategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stoklar_Kategoriler_kategoriId",
                table: "Stoklar",
                column: "kategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
