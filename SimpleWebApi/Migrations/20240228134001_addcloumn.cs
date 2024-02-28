using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addcloumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectionTime",
                table: "VehicleInspection",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 28, 21, 40, 1, 127, DateTimeKind.Local).AddTicks(2485),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 25, 13, 4, 20, 647, DateTimeKind.Local).AddTicks(6000));

            migrationBuilder.AddColumn<string>(
                name: "InspectionLocation",
                table: "VehicleInspection",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InspectionLocation",
                table: "VehicleInspection");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectionTime",
                table: "VehicleInspection",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 25, 13, 4, 20, 647, DateTimeKind.Local).AddTicks(6000),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 28, 21, 40, 1, 127, DateTimeKind.Local).AddTicks(2485));
        }
    }
}
