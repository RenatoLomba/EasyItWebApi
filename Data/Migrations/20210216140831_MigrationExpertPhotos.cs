using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MigrationExpertPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fcdb180b-3904-4732-a903-93010f940e4d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 927, DateTimeKind.Utc).AddTicks(6676),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 180, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 942, DateTimeKind.Utc).AddTicks(4138),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 185, DateTimeKind.Utc).AddTicks(8738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 934, DateTimeKind.Utc).AddTicks(6868),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 183, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 958, DateTimeKind.Utc).AddTicks(460)),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Url = table.Column<string>(type: "VARCHAR(225)", maxLength: 225, nullable: false),
                    ExpertId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("5a9cc866-db3d-4773-9a8d-432c28075621"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 16, 14, 8, 30, 961, DateTimeKind.Utc).AddTicks(6436), "adm@root.com", "Administrador", "mudar123", "Administrator", null });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ExpertId",
                table: "Photo",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_Id",
                table: "Photo",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5a9cc866-db3d-4773-9a8d-432c28075621"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 180, DateTimeKind.Utc).AddTicks(8784),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 927, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 185, DateTimeKind.Utc).AddTicks(8738),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 942, DateTimeKind.Utc).AddTicks(4138));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 183, DateTimeKind.Utc).AddTicks(2201),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 934, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("fcdb180b-3904-4732-a903-93010f940e4d"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 15, 0, 2, 20, 190, DateTimeKind.Utc).AddTicks(985), "adm@root.com", "Administrador", "mudar123", "Administrator", null });
        }
    }
}
