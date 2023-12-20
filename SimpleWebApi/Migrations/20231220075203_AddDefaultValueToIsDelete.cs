using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValueToIsDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TestDb",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否删除",
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldComment: "是否删除");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TestDb",
                type: "tinyint(1)",
                nullable: false,
                comment: "是否删除",
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: false,
                oldComment: "是否删除");
        }
    }
}
