using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MigrationUserAvatarLenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2068292e-ac61-463e-9380-96593b7c5a23"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 180, DateTimeKind.Utc).AddTicks(8784),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 989, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "User",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 185, DateTimeKind.Utc).AddTicks(8738),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 994, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.AlterColumn<double>(
                name: "Stars",
                table: "Expert",
                type: "DOUBLE(4,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "DOUBLE(2,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 183, DateTimeKind.Utc).AddTicks(2201),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 992, DateTimeKind.Utc).AddTicks(1248));

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Expert",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("fcdb180b-3904-4732-a903-93010f940e4d"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 15, 0, 2, 20, 190, DateTimeKind.Utc).AddTicks(985), "adm@root.com", "Administrador", "mudar123", "Administrator", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 989, DateTimeKind.Utc).AddTicks(8892),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 180, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "User",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 994, DateTimeKind.Utc).AddTicks(6850),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 185, DateTimeKind.Utc).AddTicks(8738));

            migrationBuilder.AlterColumn<double>(
                name: "Stars",
                table: "Expert",
                type: "DOUBLE(2,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "DOUBLE(4,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 14, 17, 43, 32, 992, DateTimeKind.Utc).AddTicks(1248),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 15, 0, 2, 20, 183, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Expert",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("2068292e-ac61-463e-9380-96593b7c5a23"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 14, 17, 43, 32, 998, DateTimeKind.Utc).AddTicks(8861), "adm@root.com", "Administrador", "mudar123", "Administrator", null });
        }
    }
}
