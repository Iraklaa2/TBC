using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Data.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 100, nullable: false),
                    Gender = table.Column<byte>(nullable: false),
                    PersonalNumber = table.Column<string>(type: "char(11)", fixedLength: true, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Image = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<byte>(nullable: false),
                    Number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPersons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    RelatedPersonId = table.Column<int>(nullable: false),
                    RelationType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPersons", x => new { x.RelatedPersonId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_RelatedPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatedPersons_Persons_RelatedPersonId",
                        column: x => x.RelatedPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tbilisi" },
                    { 2, "Kutaisi" },
                    { 3, "Rustavi" },
                    { 4, "Telavi" },
                    { 5, "Zugdidi" },
                    { 6, "Khashuri" },
                    { 7, "Zestafoni" },
                    { 8, "Marneuli" },
                    { 9, "Batumi" },
                    { 10, "Tsiatura" },
                    { 11, "Borjomi" },
                    { 12, "Kaspi" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CityId", "DateOfBirth", "FirstName", "Gender", "Image", "LastName", "PersonalNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2043, 2, 11, 5, 30, 56, 778, DateTimeKind.Local).AddTicks(4149), "Irakli", (byte)0, null, "Zarandia", "00000248035" },
                    { 15, 2, new DateTime(2043, 2, 16, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6820), "Lela", (byte)1, null, "Tsurtsumia", "00000189132" },
                    { 16, 2, new DateTime(2086, 12, 26, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6831), "Inga", (byte)1, null, "Grigolia", "00000062392" },
                    { 3, 3, new DateTime(2079, 9, 16, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6676), "Eduardi", (byte)0, null, "Shevardnaze", "00000875538" },
                    { 4, 4, new DateTime(2058, 11, 30, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6690), "Mikheili", (byte)0, null, "Saakashvili", "00000540348" },
                    { 2, 5, new DateTime(2069, 3, 5, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6619), "Zviadi", (byte)0, null, "Gamsaxurdia", "00000871494" },
                    { 5, 5, new DateTime(2092, 2, 5, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6700), "Giorgi", (byte)0, null, "Margvelashvili", "00000762571" },
                    { 6, 5, new DateTime(2108, 2, 19, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6718), "Salome", (byte)1, null, "Zurabishvili", "00000772159" },
                    { 7, 6, new DateTime(2071, 4, 18, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6729), "Leqo", (byte)0, null, "Nidzaradze", "00000895172" },
                    { 8, 6, new DateTime(2096, 11, 4, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6740), "Bidzina", (byte)0, null, "Tabagari", "00000195494" },
                    { 9, 8, new DateTime(2104, 9, 28, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6752), "Geno", (byte)0, null, "Shavdia", "00000317370" },
                    { 10, 8, new DateTime(2105, 6, 24, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6765), "Rezo", (byte)0, null, "Khatamadze", "00000518124" },
                    { 11, 11, new DateTime(2076, 1, 23, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6776), "გურამი", (byte)0, null, "ჯონირია", "00000749864" },
                    { 12, 11, new DateTime(2092, 5, 30, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6787), "ომგერი", (byte)0, null, "კაკაურიძე", "00000343590" },
                    { 13, 11, new DateTime(2057, 4, 22, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6798), "უჩა", (byte)0, null, "ზერაგია", "00000065554" },
                    { 14, 11, new DateTime(2111, 12, 5, 5, 30, 56, 779, DateTimeKind.Local).AddTicks(6808), "Dinara", (byte)1, null, "Chkadua", "00000743199" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Number", "PersonId", "Type" },
                values: new object[,]
                {
                    { 1, "00000049181", 1, (byte)0 },
                    { 26, "00000514463", 13, (byte)0 },
                    { 25, "00000012080", 12, (byte)1 },
                    { 24, "00000454572", 12, (byte)0 },
                    { 23, "00000814120", 11, (byte)1 },
                    { 22, "00000453490", 11, (byte)0 },
                    { 21, "00000787037", 10, (byte)1 },
                    { 20, "00000049256", 10, (byte)0 },
                    { 19, "00000074155", 9, (byte)0 },
                    { 18, "00000369124", 8, (byte)0 },
                    { 17, "00000033786", 7, (byte)1 },
                    { 16, "00000315792", 7, (byte)0 },
                    { 15, "00000110097", 6, (byte)0 },
                    { 14, "00000405129", 5, (byte)2 },
                    { 13, "00000209996", 5, (byte)1 },
                    { 12, "00000354085", 5, (byte)0 },
                    { 5, "00000297758", 2, (byte)1 },
                    { 4, "00000807909", 2, (byte)0 },
                    { 11, "00000080642", 4, (byte)2 },
                    { 10, "00000362102", 4, (byte)1 },
                    { 9, "00000971401", 4, (byte)0 },
                    { 8, "00000010414", 3, (byte)2 },
                    { 7, "00000551795", 3, (byte)1 },
                    { 6, "00000204954", 3, (byte)0 },
                    { 32, "00000173153", 16, (byte)0 },
                    { 31, "00000685453", 15, (byte)2 },
                    { 30, "00000125923", 15, (byte)1 },
                    { 29, "00000538373", 15, (byte)0 },
                    { 3, "00000220552", 1, (byte)2 },
                    { 2, "00000964223", 1, (byte)1 },
                    { 27, "00000578050", 14, (byte)0 },
                    { 28, "00000494701", 14, (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FirstName",
                table: "Persons",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_LastName",
                table: "Persons",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonalNumber",
                table: "Persons",
                column: "PersonalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonId",
                table: "PhoneNumbers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersons_PersonId",
                table: "RelatedPersons",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "RelatedPersons");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
