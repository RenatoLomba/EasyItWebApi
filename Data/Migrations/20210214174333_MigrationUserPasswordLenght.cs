using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MigrationUserPasswordLenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8b98a548-0797-49f4-af2c-0f653d13e144"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(45)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 989, DateTimeKind.Utc).AddTicks(8892),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 14, 17, 40, 3, 354, DateTimeKind.Utc).AddTicks(1404));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 994, DateTimeKind.Utc).AddTicks(6850),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 14, 17, 40, 3, 359, DateTimeKind.Utc).AddTicks(2067));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 992, DateTimeKind.Utc).AddTicks(1248),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 14, 17, 40, 3, 356, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("2068292e-ac61-463e-9380-96593b7c5a23"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 14, 17, 43, 32, 998, DateTimeKind.Utc).AddTicks(8861), "adm@root.com", "Administrador", "mudar123", "Administrator", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2068292e-ac61-463e-9380-96593b7c5a23"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "VARCHAR(45)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 14, 17, 40, 3, 354, DateTimeKind.Utc).AddTicks(1404),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 989, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 14, 17, 40, 3, 359, DateTimeKind.Utc).AddTicks(2067),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 994, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 14, 17, 40, 3, 356, DateTimeKind.Utc).AddTicks(5150),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 992, DateTimeKind.Utc).AddTicks(1248));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("8b98a548-0797-49f4-af2c-0f653d13e144"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 14, 17, 40, 3, 363, DateTimeKind.Utc).AddTicks(5058), "adm@root.com", "Administrador", "mudar123", "Administrator", null });
        }
    }
}
