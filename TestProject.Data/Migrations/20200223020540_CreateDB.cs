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
                    { 1, 1, new DateTime(1975, 11, 8, 6, 5, 40, 411, DateTimeKind.Local).AddTicks(1479), "Irakli", (byte)0, null, "Zarandia", "00000356154" },
                    { 15, 2, new DateTime(1978, 9, 18, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(3138), "Lela", (byte)1, null, "Tsurtsumia", "00000361444" },
                    { 16, 2, new DateTime(2006, 4, 19, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(3149), "Inga", (byte)1, null, "Grigolia", "00000219804" },
                    { 3, 3, new DateTime(1975, 6, 27, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2852), "Eduardi", (byte)0, null, "Shevardnaze", "00000867034" },
                    { 4, 4, new DateTime(1988, 8, 5, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2866), "Mikheili", (byte)0, null, "Saakashvili", "00000485913" },
                    { 2, 5, new DateTime(2000, 1, 15, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2797), "Zviadi", (byte)0, null, "Gamsaxurdia", "00000641250" },
                    { 5, 5, new DateTime(1985, 2, 4, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2884), "Giorgi", (byte)0, null, "Margvelashvili", "00000164487" },
                    { 6, 5, new DateTime(1986, 10, 2, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2907), "Salome", (byte)1, null, "Zurabishvili", "00000821019" },
                    { 7, 6, new DateTime(1995, 11, 25, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2918), "Leqo", (byte)0, null, "Nidzaradze", "00000074083" },
                    { 8, 6, new DateTime(1981, 11, 3, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2929), "Bidzina", (byte)0, null, "Tabagari", "00000391136" },
                    { 9, 8, new DateTime(1980, 5, 18, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2939), "Geno", (byte)0, null, "Shavdia", "00000859549" },
                    { 10, 8, new DateTime(1956, 11, 2, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2952), "Rezo", (byte)0, null, "Khatamadze", "00000148158" },
                    { 11, 11, new DateTime(2003, 1, 14, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2962), "გურამი", (byte)0, null, "ჯონირია", "00000616809" },
                    { 12, 11, new DateTime(1966, 12, 4, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2972), "ომგერი", (byte)0, null, "კაკაურიძე", "00000782139" },
                    { 13, 11, new DateTime(1963, 7, 26, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2983), "უჩა", (byte)0, null, "ზერაგია", "00000897696" },
                    { 14, 11, new DateTime(1948, 2, 13, 6, 5, 40, 412, DateTimeKind.Local).AddTicks(2993), "Dinara", (byte)1, null, "Chkadua", "00000164447" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Number", "PersonId", "Type" },
                values: new object[,]
                {
                    { 1, "00000726871", 1, (byte)0 },
                    { 17, "00000007018", 13, (byte)1 },
                    { 16, "00000613026", 13, (byte)0 },
                    { 15, "00000622724", 12, (byte)0 },
                    { 14, "00000539898", 11, (byte)0 },
                    { 13, "00000736031", 10, (byte)0 },
                    { 12, "00000774127", 9, (byte)0 },
                    { 11, "00000605234", 8, (byte)0 },
                    { 10, "00000729033", 7, (byte)0 },
                    { 9, "00000844708", 6, (byte)1 },
                    { 8, "00000542007", 6, (byte)0 },
                    { 18, "00000698282", 13, (byte)2 },
                    { 7, "00000256751", 5, (byte)0 },
                    { 6, "00000150510", 4, (byte)1 },
                    { 5, "00000984454", 4, (byte)0 },
                    { 4, "00000188631", 3, (byte)0 },
                    { 25, "00000110126", 16, (byte)2 },
                    { 24, "00000176968", 16, (byte)1 },
                    { 23, "00000900573", 16, (byte)0 },
                    { 22, "00000179517", 15, (byte)2 },
                    { 21, "00000640103", 15, (byte)1 },
                    { 20, "00000866474", 15, (byte)0 },
                    { 2, "00000269300", 1, (byte)1 },
                    { 3, "00000012838", 2, (byte)0 },
                    { 19, "00000290906", 14, (byte)0 }
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
