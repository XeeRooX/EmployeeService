using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeService.Migrations
{
    public partial class psqlMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SurplusFactor = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfEmployment = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TariffRate = table.Column<double>(type: "double precision", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Произодственный" },
                    { 2, "Финансовый" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "DateOfBirth", "Firstname", "Lastname", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1987, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Михаил", "Соколов", "Викторович" },
                    { 2, new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Геннадий ", "Овчинников ", "Рубенович" },
                    { 3, new DateTime(1996, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Илья ", "Голубев ", "Натанович" },
                    { 4, new DateTime(1977, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Михаил", "Фролов", null },
                    { 5, new DateTime(1979, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Владлена", "Богданова", "Олеговна" },
                    { 6, new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алевтина", "Пономарёва", "Альбертовна" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name", "SurplusFactor" },
                values: new object[,]
                {
                    { 1, "Инженер", 1.2 },
                    { 2, "Младший инженер", 1.0 },
                    { 3, "Главный инженер", 1.5 },
                    { 4, "Бухгалтер", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfEmployment", "DepartmentId", "PersonId", "PositionId", "TariffRate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 35000.0 },
                    { 2, new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 2, 31000.0 },
                    { 3, new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 1, 32000.0 },
                    { 4, new DateTime(2019, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, 4, 34000.0 },
                    { 5, new DateTime(2022, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 4, 35000.0 },
                    { 6, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, 37000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonId",
                table: "Employees",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
