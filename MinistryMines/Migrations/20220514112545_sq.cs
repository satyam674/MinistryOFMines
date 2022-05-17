using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinistryMines.Migrations
{
    public partial class sq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_District",
                columns: table => new
                {
                    District_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District_Name = table.Column<int>(type: "int", nullable: false),
                    State_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_District", x => x.District_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_State",
                columns: table => new
                {
                    State_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    St_Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_State", x => x.State_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Title",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    state_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User_Details", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_District");

            migrationBuilder.DropTable(
                name: "tbl_State");

            migrationBuilder.DropTable(
                name: "tbl_Title");

            migrationBuilder.DropTable(
                name: "tbl_User_Details");
        }
    }
}
