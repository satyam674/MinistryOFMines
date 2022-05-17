using Microsoft.EntityFrameworkCore.Migrations;

namespace MinistryMines.Migrations
{
    public partial class u1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_State2",
                columns: table => new
                {
                    S_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_State2", x => x.S_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_District2",
                columns: table => new
                {
                    Dis_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dis_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State2S_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_District2", x => x.Dis_Id);
                    table.ForeignKey(
                        name: "FK_tbl_District2_tbl_State2_State2S_Id",
                        column: x => x.State2S_Id,
                        principalTable: "tbl_State2",
                        principalColumn: "S_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_District2_State2S_Id",
                table: "tbl_District2",
                column: "State2S_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_District2");

            migrationBuilder.DropTable(
                name: "tbl_State2");
        }
    }
}
