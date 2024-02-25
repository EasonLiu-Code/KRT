using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlarmManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleSoundAndLight = table.Column<int>(type: "int", nullable: false),
                    VehicleLineBody = table.Column<int>(type: "int", nullable: false),
                    VehicleDisplay = table.Column<int>(type: "int", nullable: false),
                    VinSoundAndLightAlarm = table.Column<int>(type: "int", nullable: false),
                    VinLineBodyAlarm = table.Column<int>(type: "int", nullable: false),
                    VinDisplayAlarm = table.Column<int>(type: "int", nullable: false),
                    GuardPanelSoundAndLightAlarm = table.Column<int>(type: "int", nullable: false),
                    GuardPaneLineBodyAlarm = table.Column<int>(type: "int", nullable: false),
                    GuardPaneDisplayAlarm = table.Column<int>(type: "int", nullable: false),
                    NameplateSoundAndLightAlarm = table.Column<int>(type: "int", nullable: false),
                    NameplateLineBodyAlarm = table.Column<int>(type: "int", nullable: false),
                    NameplateDisplayAlarm = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmManagement", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleInspection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Vin = table.Column<string>(type: "longtext", nullable: true, comment: "Vin")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InspectionItem = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InspectionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2024, 2, 25, 13, 4, 20, 647, DateTimeKind.Local).AddTicks(6000)),
                    InspectionStatus = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInspection", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmManagement");

            migrationBuilder.DropTable(
                name: "VehicleInspection");
        }
    }
}
