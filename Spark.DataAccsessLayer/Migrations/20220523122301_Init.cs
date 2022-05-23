using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spark.DataAccessLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionBody = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<short>(type: "smallint", maxLength: 150, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAnswers_tblQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "tblQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblLike",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMatch = table.Column<bool>(type: "bit", nullable: false),
                    IsWin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblLike_tblUsers_LikedUserId",
                        column: x => x.LikedUserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblLike_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUserAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblUserAnswer_tblAnswers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "tblAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblUserAnswer_tblQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "tblQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblUserAnswer_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblQuestions",
                columns: new[] { "Id", "QuestionBody" },
                values: new object[,]
                {
                    { new Guid("654eca31-ffb8-4820-940b-75b424b604d3"), "What is your favorite sport?" },
                    { new Guid("6bb9e15a-88dd-49b3-a788-33ad90b9f179"), "What is your favorite book?" },
                    { new Guid("6e47af72-752f-4345-8c24-6119be2d4643"), "What is your favorite TV show?" },
                    { new Guid("6f30538b-7ff5-4b55-881e-b376aefef4ca"), "What is your favorite food?" },
                    { new Guid("81b9acfa-f573-4361-84fd-1f44fc1956b8"), "What is your favorite color?" },
                    { new Guid("849a6375-90ab-44a0-854e-d873ce435f13"), "What is your favorite movie?" },
                    { new Guid("962c3f72-53b6-4eba-9b14-84ee56f38330"), "What is your favorite book?" },
                    { new Guid("a4cff7dd-cde7-4435-acf3-afd1dc4ba114"), "What is your favorite movie?" },
                    { new Guid("e67ffecb-1f9e-4972-be43-b2b7e17395aa"), "What is your favorite animal?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00adec4f-19e6-4be6-b33d-dd83ab3fb398"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Whitehead@sohu.biz", "Man", true, false, false, "Walker", "Sydney", "123456", "01696-540329", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("05ba83ce-2f09-4ffb-af5b-8ee3e0b85e61"), (short)33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christian.Dale@lego.org.uk", "Woman", true, false, false, "Blair", "Madison", "123456", "01050-284272", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("079c235e-4def-4369-8cab-0808c9d28f67"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.White@theguardian.org.uk", "Man", true, false, false, "Silva", "Robert", "123456", "01169-170697", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c8dfe54-2f37-4ca4-ac52-e314eec4e101"), (short)44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucy.Shepherd@expedia.org", "Woman", true, false, false, "Power", "Bryson", "123456", "01839-903212", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10aa385f-0f10-4eba-8273-37f780763f50"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ashley.Buckley@bestbuy.biz", "Woman", true, false, false, "Cullen", "Connor", "123456", "01461-756153", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("12e10e23-bfff-4d13-9811-97f89c499ac5"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nolan.Mann@bbc.info", "Man", true, false, false, "Giles", "Bryson", "123456", "01446-301897", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1336a9d5-58e5-4e46-b77d-58b36c850400"), (short)22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Joyce@sohu.biz", "Woman", true, false, false, "Briggs", "Nathaniel", "123456", "01108-935169", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1541cb93-9277-447f-8ff2-d21f414342cd"), (short)48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Mcgrath@maplin.biz", "Man", true, false, false, "Hancock", "Samantha", "123456", "01363-027883", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("23746b5f-5043-4a9e-aca0-c620b0145483"), (short)36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nolan.Power@youtube.co", "Man", true, false, false, "Adam", "Carter", "123456", "01939-715736", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a401794-e187-4988-8275-5c612aeded50"), (short)31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allison.Giles@live.org.uk", "Woman", true, false, false, "Swift", "Autumn", "123456", "01481-461377", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3326607a-9115-46ce-a0a6-f2aa265c0f7e"), (short)18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofia.Leach@amazon.co", "Woman", true, false, false, "Davies", "Adrian", "123456", "01329-452061", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33f303a7-a346-4ae3-aec6-faa1d3589ba4"), (short)28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Walters@arstechnica.biz", "Woman", true, false, false, "Naylor", "Juan", "123456", "01216-890504", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("371d39d0-1ac0-4533-a20c-0f9290e5c5b0"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Adam@lego.com", "Woman", true, false, false, "Carroll", "Joseph", "123456", "01499-010198", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c853e63-7f05-45cc-920d-729d0e790d91"), (short)42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Giles@adamriddick.net", "Woman", true, false, false, "Roberts", "Isaiah", "123456", "01853-625987", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3ecc14a9-5e4b-4cc6-b026-6416a92acfe8"), (short)52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Chadwick@wordpress.com", "Woman", true, false, false, "Carroll", "Charlotte", "123456", "01138-932544", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("430f3492-d269-40a0-a431-d1ee3776ee1e"), (short)19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elizabeth.Baldwin@bestbuy.biz", "Man", true, false, false, "Buckley", "Justin", "123456", "01739-436787", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c517c18-8aab-49b9-9b19-d061af58a128"), (short)56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver.Kenny@arstechnica.com", "Woman", true, false, false, "Robinson", "Eli", "123456", "01047-821255", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64ced3ec-05e6-4bc9-a9c1-ad80bd4bd29e"), (short)19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver.Riddick@163.biz", "Man", true, false, false, "Baldwin", "Robert", "123456", "01332-998242", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7026a086-24da-4f88-819c-6aad46876726"), (short)35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maya.Taylor@bet365.biz", "Man", true, false, false, "Vaughan", "Josiah", "123456", "01942-507271", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("728b7dd6-b221-4c39-9a5d-6fe026a1471e"), (short)32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Wyatt@ask.us", "Woman", true, false, false, "Sanders", "Isaac", "123456", "01696-493802", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("84cc1286-a570-45f9-8258-dc09a3cb5f0c"), (short)53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Obrien@etsy.co", "Man", true, false, false, "Mann", "Brody", "123456", "01820-957517", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c78b556-5fd3-4481-8ba6-9af933feb570"), (short)46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ariana.Green@microsoft.com", "Man", true, false, false, "Blair", "Ayden", "123456", "01812-849322", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c9b7115-58c8-413e-9900-afc984754956"), (short)36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caleb.Lindsay@yelp.com", "Woman", true, false, false, "Vaughan", "Genesis", "123456", "01748-811907", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("915d164b-d57b-4816-a64e-6f651920e9d1"), (short)54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Seymour@wikipedia.org", "Man", true, false, false, "Robinson", "Dylan", "123456", "01899-340988", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("93afac9c-e6a3-4162-9b2c-b66c72aeae6a"), (short)35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alyssa.Schofield@wikia.info", "Woman", true, false, false, "Wyatt", "Mia", "123456", "01255-202689", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1d95d8a-cbde-4653-96be-82c63f142bea"), (short)55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Joyce@globo.net", "Woman", true, false, false, "Carroll", "Gianna", "123456", "01626-199649", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a45fb8cf-e0e9-4db6-9484-1bd74aefda89"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alyssa.Burrows@bbc.co.uk", "Woman", true, false, false, "Thompson", "Skylar", "123456", "01370-837832", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a86147f9-60f4-48d8-8251-721648e39334"), (short)60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P.Haines@bing.com", "Man", true, false, false, "Smith", "Hudson", "123456", "01321-898811", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a91fd168-02f0-4c77-b07b-08d451174102"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jace.Wright@stackoverflow.co", "Man", true, false, false, "Sinclair", "Camila", "123456", "01536-969451", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0213fa9-efb7-43d8-8dae-91d411abc199"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis.Thornton@163.net", "Man", true, false, false, "Schofield", "Taylor", "123456", "01339-556984", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ba73aad0-3158-464b-8e3b-38abcd2617b3"), (short)22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.Burrows@globo.us", "Man", true, false, false, "Schofield", "Carter", "123456", "01196-077391", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c10d7f75-4fd2-4d75-aab0-6e0a184d457f"), (short)22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Jackson@arstechnica.net", "Man", true, false, false, "Chadwick", "Emma", "123456", "01152-529943", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c5362d10-b89a-4e3b-946d-3409fb0420c4"), (short)50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Adam@yahoo.co.uk", "Man", true, false, false, "Cullen", "Ellie", "123456", "01280-694549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("c71afd2c-46ac-46fb-a36c-da4f51436205"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", true, true, false, "Admin", "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d26f0d9f-f092-4744-bfbc-e83afa177201"), (short)44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nathan.Thornton@lego.com", "Woman", true, false, false, "Mohamed", "Madelyn", "123456", "01480-406151", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d63b7cfa-7ac2-4d0d-b306-334abbd49a4e"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayden.Schofield@wikia.com", "Woman", true, false, false, "Chadwick", "Josiah", "123456", "01442-483907", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d728e443-3fc9-4cf2-85ed-f750ea4fd43c"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", true, true, false, "Gürbüz", "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("de31458b-d664-4fb1-8d1e-555cbb50aa0a"), (short)23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hannah.Mac@baidu.net", "Man", true, false, false, "Thomas", "Joshua", "123456", "01135-760655", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e02f5386-c7e4-4ee3-aea7-95d426d7d3d7"), (short)42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameron.Walker@flipkart.us", "Woman", true, false, false, "Nash", "Dylan", "123456", "01811-516286", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e30134c3-d7f8-4304-8086-9a6850f71566"), (short)55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Whelan@techcrunch.org", "Man", true, false, false, "Akhtar", "Scarlett", "123456", "01347-874233", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec300c14-787a-4af9-9475-2944bc0d4ff0"), (short)61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Joyce@live.org", "Woman", true, false, false, "White", "Aaron", "123456", "01678-538132", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f23e60d2-f3bd-4516-a2ae-166197e43e81"), (short)33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brooklyn.Wood@linkedin.co.uk", "Man", true, false, false, "Mclean", "Faith", "123456", "01586-340550", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("059552be-d23f-412a-af34-49e8bc69b003"), "Answer 1.3", new Guid("e67ffecb-1f9e-4972-be43-b2b7e17395aa") },
                    { new Guid("1a2893c5-6ed2-4b92-822a-d4afc0102a33"), "Answer 4.2", new Guid("a4cff7dd-cde7-4435-acf3-afd1dc4ba114") },
                    { new Guid("26dc1eaf-3932-40cb-8ecf-a385572efd91"), "Answer 0.2", new Guid("81b9acfa-f573-4361-84fd-1f44fc1956b8") },
                    { new Guid("346e3fc2-8516-4441-a169-b7e764f3c676"), "Answer 3.4", new Guid("654eca31-ffb8-4820-940b-75b424b604d3") },
                    { new Guid("3e968fc6-32eb-41f0-a0d5-0a19ef7cfd2d"), "Answer 0.1", new Guid("81b9acfa-f573-4361-84fd-1f44fc1956b8") },
                    { new Guid("4626010b-68d2-46db-b2d1-7dea977b95be"), "Answer 0.3", new Guid("81b9acfa-f573-4361-84fd-1f44fc1956b8") },
                    { new Guid("4ee93cb8-19d9-48cc-8fcf-30d7794e0318"), "Answer 4.4", new Guid("a4cff7dd-cde7-4435-acf3-afd1dc4ba114") },
                    { new Guid("56e1320a-490c-4bba-a1e4-de404ba53712"), "Answer 4.3", new Guid("a4cff7dd-cde7-4435-acf3-afd1dc4ba114") },
                    { new Guid("6c319de3-fc37-450b-a2e0-0ee17a282bf6"), "Answer 2.2", new Guid("6f30538b-7ff5-4b55-881e-b376aefef4ca") },
                    { new Guid("71936d58-0d77-4741-aa46-2c5bed633ef5"), "Answer 1.4", new Guid("e67ffecb-1f9e-4972-be43-b2b7e17395aa") },
                    { new Guid("9bd77471-f543-4fc7-b9ba-c69f04579639"), "Answer 1.2", new Guid("e67ffecb-1f9e-4972-be43-b2b7e17395aa") },
                    { new Guid("a2a07223-ab85-4c1d-8e0c-a4434b1a3c07"), "Answer 3.2", new Guid("654eca31-ffb8-4820-940b-75b424b604d3") },
                    { new Guid("ab3add72-a135-4b22-9036-cba25d147ede"), "Answer 0.4", new Guid("81b9acfa-f573-4361-84fd-1f44fc1956b8") },
                    { new Guid("adad6d56-3afa-42f7-8f12-9eb8c576f3ab"), "Answer 4.1", new Guid("a4cff7dd-cde7-4435-acf3-afd1dc4ba114") },
                    { new Guid("b0243f02-26d2-4c96-84d8-583494300a93"), "Answer 2.4", new Guid("6f30538b-7ff5-4b55-881e-b376aefef4ca") },
                    { new Guid("b9639d3e-4596-4bc0-96ab-1c7fe147e47e"), "Answer 1.1", new Guid("e67ffecb-1f9e-4972-be43-b2b7e17395aa") },
                    { new Guid("cf714acb-0a2c-4a35-9d5b-39d6cbe5fdb1"), "Answer 3.3", new Guid("654eca31-ffb8-4820-940b-75b424b604d3") },
                    { new Guid("de8076f2-a535-49c3-b2fe-d45a417968ea"), "Answer 4.6", new Guid("a4cff7dd-cde7-4435-acf3-afd1dc4ba114") },
                    { new Guid("e69b4ac0-65ae-4a3b-9085-08100401abb4"), "Answer 4.5", new Guid("a4cff7dd-cde7-4435-acf3-afd1dc4ba114") },
                    { new Guid("f6f1c93f-7863-4915-95c4-3ed5d0f3dc9c"), "Answer 2.3", new Guid("6f30538b-7ff5-4b55-881e-b376aefef4ca") },
                    { new Guid("fb1b5f26-d3ac-4ebb-ab25-ac6042c7ef90"), "Answer 2.1", new Guid("6f30538b-7ff5-4b55-881e-b376aefef4ca") },
                    { new Guid("fc89888a-4a1d-4542-a346-208bbe3afd05"), "Answer 3.1", new Guid("654eca31-ffb8-4820-940b-75b424b604d3") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAnswers_QuestionId",
                table: "tblAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLike_LikedUserId",
                table: "tblLike",
                column: "LikedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLike_UserId",
                table: "tblLike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserAnswer_AnswerId",
                table: "tblUserAnswer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserAnswer_QuestionId",
                table: "tblUserAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserAnswer_UserId",
                table: "tblUserAnswer",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblLike");

            migrationBuilder.DropTable(
                name: "tblUserAnswer");

            migrationBuilder.DropTable(
                name: "tblAnswers");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblQuestions");
        }
    }
}
