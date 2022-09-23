using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApp.Data.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Class_Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Class_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Date_Of_Birth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Countries_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Class_Name", "CreatedDate", "ModifiedDate" },
                values: new object[] { 1, "Class A", new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Class_Name", "CreatedDate", "ModifiedDate" },
                values: new object[] { 2, "Class B", new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Class_Name", "CreatedDate", "ModifiedDate" },
                values: new object[] { 3, "Class C", new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[] { 4, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oman" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[] { 5, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egypt" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[] { 6, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "KSA" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Class_Id", "Country_Id", "CreatedDate", "Date_Of_Birth", "Image", "ModifiedDate", "Name" },
                values: new object[] { 1, 1, 4, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.jpg", new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmed" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Class_Id", "Country_Id", "CreatedDate", "Date_Of_Birth", "Image", "ModifiedDate", "Name" },
                values: new object[] { 2, 2, 5, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "2.jpg", new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mohamed" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Class_Id", "Country_Id", "CreatedDate", "Date_Of_Birth", "Image", "ModifiedDate", "Name" },
                values: new object[] { 3, 3, 6, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "3.jpg", new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Younis" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Class_Id", "Country_Id", "CreatedDate", "Date_Of_Birth", "Image", "ModifiedDate", "Name" },
                values: new object[] { 4, 2, 4, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "6.jpg", new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sama" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Class_Id", "Country_Id", "CreatedDate", "Date_Of_Birth", "Image", "ModifiedDate", "Name" },
                values: new object[] { 5, 1, 5, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "4.jpg", new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Said" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Class_Id", "Country_Id", "CreatedDate", "Date_Of_Birth", "Image", "ModifiedDate", "Name" },
                values: new object[] { 6, 3, 6, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "5.jpg", new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Class_Id",
                table: "Students",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Country_Id",
                table: "Students",
                column: "Country_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
