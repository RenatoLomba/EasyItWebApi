using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MigrationExpertServicesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expert",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValue: new DateTime(2021, 2, 14, 17, 40, 3, 356, DateTimeKind.Utc).AddTicks(5150)),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Role = table.Column<string>(type: "VARCHAR(45)", maxLength: 45, nullable: false, defaultValue: "User"),
                    Password = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    Avatar = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    Stars = table.Column<double>(type: "DOUBLE(2,2)", nullable: false),
                    Location = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValue: new DateTime(2021, 2, 14, 17, 40, 3, 354, DateTimeKind.Utc).AddTicks(1404)),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Role = table.Column<string>(type: "VARCHAR(45)", maxLength: 45, nullable: false, defaultValue: "User"),
                    Password = table.Column<string>(type: "VARCHAR(45)", maxLength: 200, nullable: true),
                    Avatar = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValue: new DateTime(2021, 2, 14, 17, 40, 3, 359, DateTimeKind.Utc).AddTicks(2067)),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Price = table.Column<double>(type: "DOUBLE(10,2)", nullable: false),
                    ExpertId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("8b98a548-0797-49f4-af2c-0f653d13e144"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 14, 17, 40, 3, 363, DateTimeKind.Utc).AddTicks(5058), "adm@root.com", "Administrador", "mudar123", "Administrator", null });

            migrationBuilder.CreateIndex(
                name: "IX_Expert_Email",
                table: "Expert",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_Code",
                table: "Service",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_ExpertId",
                table: "Service",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Expert");
        }
    }
}
