using Microsoft.EntityFrameworkCore.Migrations;

namespace api_peliculas.Migrations
{
    public partial class Actor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricao",
                table: "T_Actor");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "T_Actor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "biografia",
                table: "T_Actor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "T_Actor",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "biografia",
                table: "T_Actor");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "T_Actor");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "T_Actor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "T_Actor",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
