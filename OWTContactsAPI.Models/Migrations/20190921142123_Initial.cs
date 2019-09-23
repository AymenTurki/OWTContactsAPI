using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OWTContactsAPI.Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    MobilePhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "ExpertizeLevel",
                columns: table => new
                {
                    ExpertizeLevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    NumericValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertizeLevel", x => x.ExpertizeLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "ContactSkills",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    ExpertizeLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactSkills", x => new { x.ContactId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_ContactSkills_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactSkills_ExpertizeLevel_ExpertizeLevelId",
                        column: x => x.ExpertizeLevelId,
                        principalTable: "ExpertizeLevel",
                        principalColumn: "ExpertizeLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "Email", "FirstName", "LastName", "MobilePhoneNumber" },
                values: new object[,]
                {
                    { 1, "Chemin de la Prairie 36, 1007 Lausanne", "jp@jeshua.ch", "Jeshua", "Park", "07544412213" },
                    { 2, "Rue de Marterey 4", "fatou@gmail.com", "Fatima", "Diallo", "0758954545" },
                    { 3, "Avenu du Mauborget 13", "m.a.k@hotmail.ch", "Modahmed-Ali", "Kurai", "0751111122" }
                });

            migrationBuilder.InsertData(
                table: "ExpertizeLevel",
                columns: new[] { "ExpertizeLevelId", "Name", "NumericValue" },
                values: new object[,]
                {
                    { 1, "Beginner", 0 },
                    { 2, "Intermediate", 1 },
                    { 3, "Expert", 2 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name" },
                values: new object[,]
                {
                    { 1, "C# Programming" },
                    { 2, "SOLID Principles" },
                    { 3, "Obect Oriented Programming" }
                });

            migrationBuilder.InsertData(
                table: "ContactSkills",
                columns: new[] { "ContactId", "SkillId", "ExpertizeLevelId" },
                values: new object[] { 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "ContactSkills",
                columns: new[] { "ContactId", "SkillId", "ExpertizeLevelId" },
                values: new object[] { 1, 3, 3 });

            migrationBuilder.InsertData(
                table: "ContactSkills",
                columns: new[] { "ContactId", "SkillId", "ExpertizeLevelId" },
                values: new object[] { 2, 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ContactSkills_ExpertizeLevelId",
                table: "ContactSkills",
                column: "ExpertizeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactSkills_SkillId",
                table: "ContactSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactSkills");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ExpertizeLevel");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
