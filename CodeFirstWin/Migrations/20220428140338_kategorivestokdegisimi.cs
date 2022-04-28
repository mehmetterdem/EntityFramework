using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWin.Migrations
{
    public partial class kategorivestokdegisimi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StokAdi",
                table: "Stoklar",
                newName: "stookAdi");

            migrationBuilder.RenameColumn(
                name: "KategoriAdi",
                table: "Kategoriler",
                newName: "CategoryName");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Stoklar",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "stookAdi",
                table: "Stoklar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Kategoriler",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Kategoriler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "stookAdi",
                table: "Stoklar",
                newName: "StokAdi");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Kategoriler",
                newName: "KategoriAdi");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Stoklar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "StokAdi",
                table: "Stoklar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Kategoriler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "KategoriAdi",
                table: "Kategoriler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
