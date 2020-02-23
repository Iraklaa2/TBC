using System;
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 100, nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        principalColumn: "Id");
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
                    { 1, 1, new DateTime(2052, 1, 25, 5, 57, 17, 952, DateTimeKind.Local).AddTicks(7788), "Irakli", (byte)0, null, "Zarandia", "00000465813" },
                    { 15, 2, new DateTime(2075, 5, 9, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6363), "Lela", (byte)1, null, "Tsurtsumia", "00000563934" },
                    { 16, 2, new DateTime(2120, 6, 17, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6392), "Inga", (byte)1, null, "Grigolia", "00000988157" },
                    { 3, 3, new DateTime(2041, 11, 1, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6074), "Eduardi", (byte)0, null, "Shevardnaze", "00000895687" },
                    { 4, 4, new DateTime(2045, 12, 1, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6102), "Mikheili", (byte)0, null, "Saakashvili", "00000171103" },
                    { 2, 5, new DateTime(2048, 9, 23, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(5953), "Zviadi", (byte)0, null, "Gamsaxurdia", "00000314137" },
                    { 5, 5, new DateTime(2112, 3, 19, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6124), "Giorgi", (byte)0, null, "Margvelashvili", "00000817832" },
                    { 6, 5, new DateTime(2115, 4, 21, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6154), "Salome", (byte)1, null, "Zurabishvili", "00000623628" },
                    { 7, 6, new DateTime(2044, 9, 4, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6176), "Leqo", (byte)0, null, "Nidzaradze", "00000182603" },
                    { 8, 6, new DateTime(2090, 5, 17, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6199), "Bidzina", (byte)0, null, "Tabagari", "00000716033" },
                    { 9, 8, new DateTime(2117, 6, 29, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6218), "Geno", (byte)0, null, "Shavdia", "00000149762" },
                    { 10, 8, new DateTime(2098, 8, 14, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6246), "Rezo", (byte)0, null, "Khatamadze", "00000081132" },
                    { 11, 11, new DateTime(2091, 6, 14, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6267), "გურამი", (byte)0, null, "ჯონირია", "00000219816" },
                    { 12, 11, new DateTime(2088, 8, 1, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6285), "ომგერი", (byte)0, null, "კაკაურიძე", "00000002205" },
                    { 13, 11, new DateTime(2085, 10, 5, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6308), "უჩა", (byte)0, null, "ზერაგია", "00000840617" },
                    { 14, 11, new DateTime(2105, 11, 16, 5, 57, 17, 954, DateTimeKind.Local).AddTicks(6334), "Dinara", (byte)1, null, "Chkadua", "00000622022" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Number", "PersonId", "Type" },
                values: new object[,]
                {
                    { 1, "00000790065", 1, (byte)0 },
                    { 16, "00000564913", 8, (byte)0 },
                    { 17, "00000669484", 9, (byte)0 },
                    { 18, "00000051109", 9, (byte)1 },
                    { 19, "00000467375", 9, (byte)2 },
                    { 20, "00000137156", 10, (byte)0 },
                    { 21, "00000219157", 10, (byte)1 },
                    { 15, "00000484980", 7, (byte)0 },
                    { 22, "00000151000", 11, (byte)0 },
                    { 24, "00000374999", 11, (byte)2 },
                    { 25, "00000729289", 12, (byte)0 },
                    { 26, "00000092534", 12, (byte)1 },
                    { 27, "00000696239", 13, (byte)0 },
                    { 28, "00000649200", 13, (byte)1 },
                    { 29, "00000553098", 14, (byte)0 },
                    { 23, "00000405463", 11, (byte)1 },
                    { 30, "00000546161", 14, (byte)1 },
                    { 14, "00000840651", 6, (byte)2 },
                    { 12, "00000045490", 6, (byte)0 },
                    { 2, "00000646016", 1, (byte)1 },
                    { 3, "00000271315", 1, (byte)2 },
                    { 32, "00000232670", 15, (byte)0 },
                    { 33, "00000747313", 15, (byte)1 },
                    { 34, "00000546818", 16, (byte)0 },
                    { 35, "00000948634", 16, (byte)1 },
                    { 13, "00000095316", 6, (byte)1 },
                    { 7, "00000376430", 3, (byte)0 },
                    { 9, "00000067900", 3, (byte)2 },
                    { 10, "00000468570", 4, (byte)0 },
                    { 4, "00000222640", 2, (byte)0 },
                    { 5, "00000395255", 2, (byte)1 },
                    { 6, "00000808365", 2, (byte)2 },
                    { 11, "00000128391", 5, (byte)0 },
                    { 8, "00000122198", 3, (byte)1 },
                    { 31, "00000402407", 14, (byte)2 }
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
