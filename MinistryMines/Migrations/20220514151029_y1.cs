using Microsoft.EntityFrameworkCore.Migrations;

namespace MinistryMines.Migrations
{
    public partial class y1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                table: "tbl_User_Details",
                newName: "ImagePath");

            migrationBuilder.AlterColumn<int>(
                name: "State_Id",
                table: "tbl_District",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_District_State_Id",
                table: "tbl_District",
                column: "State_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_District_tbl_State_State_Id",
                table: "tbl_District",
                column: "State_Id",
                principalTable: "tbl_State",
                principalColumn: "State_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_District_tbl_State_State_Id",
                table: "tbl_District");

            migrationBuilder.DropIndex(
                name: "IX_tbl_District_State_Id",
                table: "tbl_District");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "tbl_User_Details",
                newName: "image");

            migrationBuilder.AlterColumn<int>(
                name: "State_Id",
                table: "tbl_District",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
