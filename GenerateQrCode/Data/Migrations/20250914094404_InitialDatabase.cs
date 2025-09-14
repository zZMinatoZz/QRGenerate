using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenerateQrCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonViHanhChinhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TinhThanhPho = table.Column<string>(type: "TEXT", nullable: false),
                    MaTP = table.Column<string>(type: "TEXT", nullable: false),
                    QuanHuyen = table.Column<string>(type: "TEXT", nullable: false),
                    MaQH = table.Column<string>(type: "TEXT", nullable: false),
                    PhuongXaThiTran = table.Column<string>(type: "TEXT", nullable: false),
                    MaPX = table.Column<string>(type: "TEXT", nullable: false),
                    Cap = table.Column<string>(type: "TEXT", nullable: false),
                    TenTiengAnh = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViHanhChinhs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonViHanhChinhs");
        }
    }
}
