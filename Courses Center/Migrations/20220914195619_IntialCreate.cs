using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses_Center.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UniName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => new { x.Name, x.UniName });
                    table.ForeignKey(
                        name: "FK_Colleges_Universities_UniName",
                        column: x => x.UniName,
                        principalTable: "Universities",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UniName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => new { x.Name, x.ColName });
                    table.ForeignKey(
                        name: "FK_Departments_Colleges_ColName_UniName",
                        columns: x => new { x.ColName, x.UniName },
                        principalTable: "Colleges",
                        principalColumns: new[] { "Name", "UniName" });
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeptName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semester = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => new { x.Name, x.DeptName });
                    table.ForeignKey(
                        name: "FK_Courses_Departments_ColName_DeptName",
                        columns: x => new { x.ColName, x.DeptName },
                        principalTable: "Departments",
                        principalColumns: new[] { "Name", "ColName" });
                });

            migrationBuilder.CreateTable(
                name: "CourseProfessor",
                columns: table => new
                {
                    ProfessorsId = table.Column<int>(type: "int", nullable: false),
                    CoursesName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoursesDeptName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfessor", x => new { x.ProfessorsId, x.CoursesName, x.CoursesDeptName });
                    table.ForeignKey(
                        name: "FK_CourseProfessor_Courses_CoursesName_CoursesDeptName",
                        columns: x => new { x.CoursesName, x.CoursesDeptName },
                        principalTable: "Courses",
                        principalColumns: new[] { "Name", "DeptName" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfessor_Professors_ProfessorsId",
                        column: x => x.ProfessorsId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountOfBuy = table.Column<int>(type: "int", nullable: false),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ProfID = table.Column<int>(type: "int", nullable: false),
                    CrsName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeptName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sources_Courses_CrsName_DeptName",
                        columns: x => new { x.CrsName, x.DeptName },
                        principalTable: "Courses",
                        principalColumns: new[] { "Name", "DeptName" });
                    table.ForeignKey(
                        name: "FK_Sources_Professors_ProfID",
                        column: x => x.ProfID,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyingCarts",
                columns: table => new
                {
                    BuyUserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaNumber = table.Column<int>(type: "int", nullable: false),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyingCarts", x => new { x.SId, x.BuyUserName });
                    table.ForeignKey(
                        name: "FK_BuyingCarts_Buyers_BuyUserName",
                        column: x => x.BuyUserName,
                        principalTable: "Buyers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyingCarts_Sources_SId",
                        column: x => x.SId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyingCarts_BuyUserName",
                table: "BuyingCarts",
                column: "BuyUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_UniName",
                table: "Colleges",
                column: "UniName");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfessor_CoursesName_CoursesDeptName",
                table: "CourseProfessor",
                columns: new[] { "CoursesName", "CoursesDeptName" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ColName_DeptName",
                table: "Courses",
                columns: new[] { "ColName", "DeptName" });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ColName_UniName",
                table: "Departments",
                columns: new[] { "ColName", "UniName" });

            migrationBuilder.CreateIndex(
                name: "IX_Sources_CrsName_DeptName",
                table: "Sources",
                columns: new[] { "CrsName", "DeptName" });

            migrationBuilder.CreateIndex(
                name: "IX_Sources_ProfID",
                table: "Sources",
                column: "ProfID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyingCarts");

            migrationBuilder.DropTable(
                name: "CourseProfessor");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Colleges");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
