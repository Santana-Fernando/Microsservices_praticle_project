using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Login.API.Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });


            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id", "email", "name", "password" },
                values: new object[] { 1, "system@gmail.com", "system", "$2a$10$e/IZDBCPryoa6XMwowkItuVWAeZmYOH1RiinVrcHVTm560uGIaUa2" });
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
