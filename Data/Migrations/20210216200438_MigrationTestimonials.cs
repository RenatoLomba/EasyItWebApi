using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MigrationTestimonials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5a9cc866-db3d-4773-9a8d-432c28075621"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 628, DateTimeKind.Utc).AddTicks(6756),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 927, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 633, DateTimeKind.Utc).AddTicks(3786),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 942, DateTimeKind.Utc).AddTicks(4138));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Photo",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 638, DateTimeKind.Utc).AddTicks(1597),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 958, DateTimeKind.Utc).AddTicks(460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 630, DateTimeKind.Utc).AddTicks(8820),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 934, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.CreateTable(
                name: "Testimonial",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 640, DateTimeKind.Utc).AddTicks(4425)),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ExpertId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Stars = table.Column<double>(type: "DOUBLE(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testimonial_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Testimonial_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("a49f0424-954c-4cbf-ab09-764efb711e7e"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 16, 20, 4, 37, 642, DateTimeKind.Utc).AddTicks(2139), "adm@root.com", "Administrador", "mudar123", "Administrator", null });

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_ExpertId",
                table: "Testimonial",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_Id",
                table: "Testimonial",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_UserId",
                table: "Testimonial",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Testimonial");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a49f0424-954c-4cbf-ab09-764efb711e7e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 927, DateTimeKind.Utc).AddTicks(6676),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 628, DateTimeKind.Utc).AddTicks(6756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 942, DateTimeKind.Utc).AddTicks(4138),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 633, DateTimeKind.Utc).AddTicks(3786));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Photo",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 958, DateTimeKind.Utc).AddTicks(460),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 638, DateTimeKind.Utc).AddTicks(1597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 14, 8, 30, 934, DateTimeKind.Utc).AddTicks(6868),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 630, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("5a9cc866-db3d-4773-9a8d-432c28075621"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 16, 14, 8, 30, 961, DateTimeKind.Utc).AddTicks(6436), "adm@root.com", "Administrador", "mudar123", "Administrator", null });
        }
    }
}
