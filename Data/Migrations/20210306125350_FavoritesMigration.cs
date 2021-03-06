using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FavoritesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f72bb172-3859-4a53-9072-a44edbae7377"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 509, DateTimeKind.Utc).AddTicks(854),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 364, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Testimonial",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 519, DateTimeKind.Utc).AddTicks(1875),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 379, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 513, DateTimeKind.Utc).AddTicks(712),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 370, DateTimeKind.Utc).AddTicks(4737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Photo",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 517, DateTimeKind.Utc).AddTicks(2295),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 376, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 511, DateTimeKind.Utc).AddTicks(371),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 367, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "AvailableHour",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 526, DateTimeKind.Utc).AddTicks(9270),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 390, DateTimeKind.Utc).AddTicks(6437));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "AvailableDate",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 524, DateTimeKind.Utc).AddTicks(6622),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 387, DateTimeKind.Utc).AddTicks(6800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Appointment",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 522, DateTimeKind.Utc).AddTicks(2549),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 384, DateTimeKind.Utc).AddTicks(6131));

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 528, DateTimeKind.Utc).AddTicks(9088)),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ExpertId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("28fb11be-e9ad-48e4-b05c-09a10b297cec"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 3, 6, 12, 53, 50, 530, DateTimeKind.Utc).AddTicks(4909), "adm@root.com", "Administrador", "mudar123", "Administrator", null });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ExpertId",
                table: "Favorites",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Id",
                table: "Favorites",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28fb11be-e9ad-48e4-b05c-09a10b297cec"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 364, DateTimeKind.Utc).AddTicks(2678),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 509, DateTimeKind.Utc).AddTicks(854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Testimonial",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 379, DateTimeKind.Utc).AddTicks(6019),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 519, DateTimeKind.Utc).AddTicks(1875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 370, DateTimeKind.Utc).AddTicks(4737),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 513, DateTimeKind.Utc).AddTicks(712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Photo",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 376, DateTimeKind.Utc).AddTicks(4976),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 517, DateTimeKind.Utc).AddTicks(2295));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 367, DateTimeKind.Utc).AddTicks(1575),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 511, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "AvailableHour",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 390, DateTimeKind.Utc).AddTicks(6437),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 526, DateTimeKind.Utc).AddTicks(9270));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "AvailableDate",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 387, DateTimeKind.Utc).AddTicks(6800),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 524, DateTimeKind.Utc).AddTicks(6622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Appointment",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 384, DateTimeKind.Utc).AddTicks(6131),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 3, 6, 12, 53, 50, 522, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("f72bb172-3859-4a53-9072-a44edbae7377"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 20, 16, 15, 32, 392, DateTimeKind.Utc).AddTicks(5026), "adm@root.com", "Administrador", "mudar123", "Administrator", null });
        }
    }
}
