using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MigrationAppointmentsAndAvailables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a49f0424-954c-4cbf-ab09-764efb711e7e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 364, DateTimeKind.Utc).AddTicks(2678),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 628, DateTimeKind.Utc).AddTicks(6756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Testimonial",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 379, DateTimeKind.Utc).AddTicks(6019),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 640, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 370, DateTimeKind.Utc).AddTicks(4737),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 633, DateTimeKind.Utc).AddTicks(3786));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Photo",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 376, DateTimeKind.Utc).AddTicks(4976),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 638, DateTimeKind.Utc).AddTicks(1597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 367, DateTimeKind.Utc).AddTicks(1575),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 630, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 384, DateTimeKind.Utc).AddTicks(6131)),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ExpertId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableDate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 387, DateTimeKind.Utc).AddTicks(6800)),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ExpertId = table.Column<Guid>(nullable: false),
                    Day = table.Column<int>(type: "INT", nullable: false),
                    Month = table.Column<int>(type: "INT", nullable: false),
                    Year = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableDate_Expert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Expert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableHour",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 390, DateTimeKind.Utc).AddTicks(6437)),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    AvailableDateId = table.Column<Guid>(nullable: false),
                    Hour = table.Column<int>(type: "INT", nullable: false),
                    Minutes = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableHour_AvailableDate_AvailableDateId",
                        column: x => x.AvailableDateId,
                        principalTable: "AvailableDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("f72bb172-3859-4a53-9072-a44edbae7377"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 20, 16, 15, 32, 392, DateTimeKind.Utc).AddTicks(5026), "adm@root.com", "Administrador", "mudar123", "Administrator", null });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ExpertId",
                table: "Appointment",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Id",
                table: "Appointment",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ServiceId",
                table: "Appointment",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDate_ExpertId",
                table: "AvailableDate",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDate_Id",
                table: "AvailableDate",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvailableHour_AvailableDateId",
                table: "AvailableHour",
                column: "AvailableDateId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableHour_Id",
                table: "AvailableHour",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "AvailableHour");

            migrationBuilder.DropTable(
                name: "AvailableDate");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f72bb172-3859-4a53-9072-a44edbae7377"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 628, DateTimeKind.Utc).AddTicks(6756),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 364, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Testimonial",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 640, DateTimeKind.Utc).AddTicks(4425),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 379, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Service",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 633, DateTimeKind.Utc).AddTicks(3786),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 370, DateTimeKind.Utc).AddTicks(4737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Photo",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 638, DateTimeKind.Utc).AddTicks(1597),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 376, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Expert",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 16, 20, 4, 37, 630, DateTimeKind.Utc).AddTicks(8820),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 20, 16, 15, 32, 367, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("a49f0424-954c-4cbf-ab09-764efb711e7e"), "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png", new DateTime(2021, 2, 16, 20, 4, 37, 642, DateTimeKind.Utc).AddTicks(2139), "adm@root.com", "Administrador", "mudar123", "Administrator", null });
        }
    }
}
