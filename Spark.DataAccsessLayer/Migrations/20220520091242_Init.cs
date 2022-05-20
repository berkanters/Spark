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
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    { new Guid("28bbb60c-a3ee-43e8-ab06-bac089b0d611"), "What is your favorite TV show?" },
                    { new Guid("5742266e-03a7-46d3-8a32-9edc7cb80c02"), "What is your favorite animal?" },
                    { new Guid("5f121709-5e0c-48fc-acd5-d31d8c535b2d"), "What is your favorite movie?" },
                    { new Guid("647b3149-019b-4266-92d6-e80747b8dee1"), "What is your favorite book?" },
                    { new Guid("736edf27-261c-4e98-a848-13c2517e7dd3"), "What is your favorite sport?" },
                    { new Guid("9fb77ee2-7ee3-409b-a6a9-2e306eb7ea26"), "What is your favorite movie?" },
                    { new Guid("ad1f79c6-920f-4d9f-a278-d75792db6950"), "What is your favorite book?" },
                    { new Guid("f9116a69-328d-4d52-bd5d-39f358f9e8a1"), "What is your favorite food?" },
                    { new Guid("fad445c2-bdd3-4550-aeb0-edcf9a5a2681"), "What is your favorite color?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("07bc3dcf-d0c1-4fff-8c29-8aae3fbd9850"), (short)51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Silva@bet365.us", "Man", true, false, false, "Akhtar", "Aaliyah", "123456", "01622-485052", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0968fee8-3bd3-45f5-b41d-20adb97812b9"), (short)21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Thorne@etsy.info", "Man", true, false, false, "Osborne", "Ariana", "123456", "01657-663284", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d5872bf-eae2-47e4-95cf-91f0c828f14f"), (short)49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher.Jackson@sky.info", "Man", true, false, false, "Haines", "Adrian", "123456", "01178-033949", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e95e556-2d29-49e7-a331-7b2ae0bc739f"), (short)42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R.Stuart@theguardian.org", "Man", true, false, false, "Dale", "Alexandra", "123456", "01388-195503", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("139f3be0-574f-4eaf-afe8-f3a94e3f8fd8"), (short)60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John.Power@maplin.org.uk", "Woman", true, false, false, "Sanders", "Annabelle", "123456", "01025-418820", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("17767e0e-8e08-4ca8-8418-e57b795b2865"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Sinclair@adamriddick.co", "Man", true, false, false, "Walker", "Evan", "123456", "01579-410701", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1776e815-6a48-4236-819f-edb95f56b03a"), (short)27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Whittaker@expedia.co", "Woman", true, false, false, "Peters", "Jace", "123456", "01388-968718", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1fd51401-e685-40d1-9563-7603c6db415d"), (short)58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madeline.Taylor@bing.net", "Woman", true, false, false, "Mohamed", "Piper", "123456", "01537-321443", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("23444ec3-ab0a-4fb2-8c45-779818036b37"), (short)41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madelyn.Lindsay@paypal.org", "Woman", true, false, false, "Walker", "Zoey", "123456", "01603-420888", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("264f2f7a-a98f-4803-b0f3-54f5986f0e2f"), (short)61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Shepherd@bbc.co", "Man", true, false, false, "Riddick", "Zoe", "123456", "01166-847500", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2aed8567-6003-48a6-8d5d-c63f97006665"), (short)45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Genesis.Jackson@pinterest.net", "Woman", true, false, false, "Naylor", "Molly", "123456", "01446-638256", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31fa4538-9734-47ad-8dc9-043906d21b2d"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Mclean@flipkart.info", "Woman", true, false, false, "Obrien", "Nathaniel", "123456", "01662-656874", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3266b206-83c2-4200-9995-7b6042905ba8"), (short)34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Mcgregor@bbc.com", "Man", true, false, false, "Obrien", "Luis", "123456", "01259-649919", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("337c7827-0d5d-44c4-bca8-da25b510e036"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", true, true, false, "Admin", "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3acfd925-ed5f-49e3-8a55-f299c908e0bb"), (short)37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Harris@cnn.us", "Woman", true, false, false, "Lewis", "Violet", "123456", "01996-385384", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3b6b38ab-59cf-4d80-92e5-a630743dc559"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lauren.Johnson@bing.us", "Man", true, false, false, "Schofield", "Julian", "123456", "01784-885980", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c80f733-6b10-4c85-8664-475b149fd7f8"), (short)55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peyton.Mann@bing.biz", "Woman", true, false, false, "Nash", "Julia", "123456", "01183-002191", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("47894362-4df6-4134-9cec-5fac3b55a9a7"), (short)48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Weaver@gmail.biz", "Man", true, false, false, "Giles", "Annabelle", "123456", "01940-836224", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a955d66-15eb-4033-80eb-7637e4d4bba1"), (short)34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Mann@theguardian.org", "Man", true, false, false, "Mcgrath", "Elizabeth", "123456", "01297-937062", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4f8cfe1b-4a59-41dd-95c4-d81a9714dd54"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Makayla.Mann@wikia.co", "Man", true, false, false, "Sinclair", "Bailey", "123456", "01988-195762", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5126492a-ee60-4381-8fa7-3d163debf933"), (short)26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Hooper@bing.net", "Woman", true, false, false, "Dale", "Samuel", "123456", "01438-344972", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("590125e8-4c75-4dbe-895c-fd3268ae1735"), (short)46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carter.Power@cnn.org", "Woman", true, false, false, "Mann", "Wyatt", "123456", "01778-177548", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60897502-ec62-4890-8580-692ccee544f8"), (short)51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Naylor@etsy.org", "Man", true, false, false, "Adam", "Brody", "123456", "01692-995691", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6b04f922-5cf4-407b-a93e-113f1d69494f"), (short)18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Mcfarlane@bet365.biz", "Woman", true, false, false, "Carroll", "Aria", "123456", "01363-042902", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6db1b939-d625-4c0f-b546-1b43538f6cfa"), (short)56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew.Thomas@bing.org", "Woman", true, false, false, "Stuart", "Ava", "123456", "01064-185631", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("759078f5-37a8-4736-b344-6dd87a06a2aa"), (short)51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z.Buckley@adamriddick.net", "Man", true, false, false, "Abbott", "Brooklyn", "123456", "01842-839429", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("88b3e7ed-0f53-42e9-8c97-b63b21eafd06"), (short)41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Giles@bet365.org.uk", "Woman", true, false, false, "Adam", "Grayson", "123456", "01899-887445", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8f24c28a-6c12-4d85-a9dd-c9913b5cc1ca"), (short)24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Vaughan@qq.org.uk", "Woman", true, false, false, "Roberts", "Jasmine", "123456", "01658-119799", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("90d90a4b-62a6-4385-9e56-0200874c673c"), (short)21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naomi.Mohamed@wordpress.co", "Woman", true, false, false, "Lord", "Ian", "123456", "01781-743209", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("90ff94a3-7e46-4b5a-8996-f0109d1826a8"), (short)30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Mac@yahoo.org.uk", "Man", true, false, false, "Hancock", "Faith", "123456", "01406-710161", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("972e5e47-7294-44b2-b9d3-dc497d0266c2"), (short)61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "W.Blair@bing.info", "Woman", true, false, false, "Silva", "Scott", "123456", "01613-606518", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a7f6c440-4858-43d0-aa0a-9834a9f1428c"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", true, true, false, "Gürbüz", "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a882684a-8163-4775-a0db-c20bc686ef57"), (short)46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kylie.Brown@maplin.co", "Man", true, false, false, "Lindsay", "Daniel", "123456", "01797-732349", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b5c11d2a-b1f7-458c-99db-b9269afdd2cb"), (short)26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel.Giles@wikia.biz", "Man", true, false, false, "Carroll", "Easton", "123456", "01408-525210", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bdfd9cd2-5af7-4d01-a889-ffb8c13ce777"), (short)18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jace.Wyatt@bestbuy.org", "Woman", true, false, false, "Abbott", "Oliver", "123456", "01232-420144", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("be1a0f33-5c0d-45b6-96b2-ab8cc85c91c7"), (short)27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia.Mellor@amazon.co.uk", "Man", true, false, false, "Akhtar", "Bailey", "123456", "01017-292918", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cad5b7a1-0fb6-4950-afb9-344e0121e6b8"), (short)40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Walker@paypal.org.uk", "Woman", true, false, false, "Mcgregor", "Ian", "123456", "01442-424585", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d75d7571-5741-483a-9507-9691767a560a"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Hilton@wikipedia.co", "Man", true, false, false, "Akhtar", "Claire", "123456", "01200-840685", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da180cc2-d0e7-4cd3-9db9-bcba36fe7f6a"), (short)43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Hooper@arstechnica.co.uk", "Man", true, false, false, "Leach", "Hannah", "123456", "01668-455875", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e789dad8-cf40-4fe9-bf21-338a105d7fe9"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Mann@yahoo.org.uk", "Woman", true, false, false, "Lord", "Victoria", "123456", "01050-447042", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ee462f9a-2008-4021-b817-54007523c85f"), (short)37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Green@cnn.info", "Woman", true, false, false, "Wyatt", "Avery", "123456", "01721-407880", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f012d7f0-cc41-48f8-ab2c-b953b5d7e105"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayden.Lindsay@maplin.co", "Man", true, false, false, "Giles", "Tristan", "123456", "01463-909422", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("02a3e60e-fdb5-4896-b7ed-c30e838d14ce"), "Answer 4.5", new Guid("5f121709-5e0c-48fc-acd5-d31d8c535b2d") },
                    { new Guid("05efd886-0f48-4af4-bb33-d950db5f1258"), "Answer 0.1", new Guid("fad445c2-bdd3-4550-aeb0-edcf9a5a2681") },
                    { new Guid("2e0de8f3-cc7b-4c1a-8e1f-aff68b525d70"), "Answer 3.4", new Guid("736edf27-261c-4e98-a848-13c2517e7dd3") },
                    { new Guid("3d1494f7-e04c-411b-ac4c-e4b00f6aa6e9"), "Answer 0.4", new Guid("fad445c2-bdd3-4550-aeb0-edcf9a5a2681") },
                    { new Guid("40f8fb3a-975f-4bbc-a9a0-0d6b1de92074"), "Answer 4.1", new Guid("5f121709-5e0c-48fc-acd5-d31d8c535b2d") },
                    { new Guid("4e00a3ac-dfc2-4e7b-9ecf-d27f7864ff7d"), "Answer 1.4", new Guid("5742266e-03a7-46d3-8a32-9edc7cb80c02") },
                    { new Guid("5c57a581-f295-4557-a45c-07c0dfdd51dd"), "Answer 1.3", new Guid("5742266e-03a7-46d3-8a32-9edc7cb80c02") },
                    { new Guid("69cfb74b-015f-4413-a59d-17801db27753"), "Answer 2.3", new Guid("f9116a69-328d-4d52-bd5d-39f358f9e8a1") },
                    { new Guid("6b5a42b8-aded-473b-acf3-68e9ca5a2218"), "Answer 4.6", new Guid("5f121709-5e0c-48fc-acd5-d31d8c535b2d") },
                    { new Guid("73ba4de1-2fca-41db-b070-bbf73f019be9"), "Answer 1.1", new Guid("5742266e-03a7-46d3-8a32-9edc7cb80c02") },
                    { new Guid("74b2106c-91ec-4799-93d0-254175ad3878"), "Answer 0.3", new Guid("fad445c2-bdd3-4550-aeb0-edcf9a5a2681") },
                    { new Guid("81c9883e-2f5b-4414-9d1d-de839372620a"), "Answer 3.1", new Guid("736edf27-261c-4e98-a848-13c2517e7dd3") },
                    { new Guid("9cfc4298-5e9a-44ac-bb1d-9f9cabfead5d"), "Answer 4.4", new Guid("5f121709-5e0c-48fc-acd5-d31d8c535b2d") },
                    { new Guid("b504af33-e204-4d81-82ae-f37fc8b8068e"), "Answer 2.4", new Guid("f9116a69-328d-4d52-bd5d-39f358f9e8a1") },
                    { new Guid("bfebab8a-ee7a-4b5c-a398-9a9b8ae595f3"), "Answer 4.2", new Guid("5f121709-5e0c-48fc-acd5-d31d8c535b2d") },
                    { new Guid("c834e037-fb97-4654-be49-3ce2079fa526"), "Answer 1.2", new Guid("5742266e-03a7-46d3-8a32-9edc7cb80c02") },
                    { new Guid("cd6ecdec-d197-4090-a0a5-1494eb1d8db9"), "Answer 3.2", new Guid("736edf27-261c-4e98-a848-13c2517e7dd3") },
                    { new Guid("d7593386-4e33-4c0a-b0f1-08212579a2d7"), "Answer 0.2", new Guid("fad445c2-bdd3-4550-aeb0-edcf9a5a2681") },
                    { new Guid("d7cd0dbe-c422-4884-b68e-67e3468c132c"), "Answer 2.2", new Guid("f9116a69-328d-4d52-bd5d-39f358f9e8a1") },
                    { new Guid("d93043df-90db-4b94-8f7b-8a080bf37deb"), "Answer 4.3", new Guid("5f121709-5e0c-48fc-acd5-d31d8c535b2d") },
                    { new Guid("e3c9e688-159b-4d50-b95e-7cea90e48241"), "Answer 2.1", new Guid("f9116a69-328d-4d52-bd5d-39f358f9e8a1") },
                    { new Guid("f5277697-e5cf-45b2-a29f-c779eb969ec4"), "Answer 3.3", new Guid("736edf27-261c-4e98-a848-13c2517e7dd3") }
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
