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
                    Age = table.Column<int>(type: "int", maxLength: 150, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
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
                name: "tblChatLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblChatLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblChatLog_tblUsers_User1Id",
                        column: x => x.User1Id,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblChatLog_tblUsers_User2Id",
                        column: x => x.User2Id,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblLike",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User1Score = table.Column<int>(type: "int", nullable: false),
                    User2Score = table.Column<int>(type: "int", nullable: false),
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
                    { new Guid("0233b3c9-1242-46ab-b665-cdf0240111f8"), "What is your favorite movie?" },
                    { new Guid("463540bd-fdbd-4ce7-ac37-e8f75ce9f089"), "What is your favorite food?" },
                    { new Guid("7d47a974-e70e-4884-8f4a-97941aa01786"), "What is your favorite TV show?" },
                    { new Guid("8d644aee-7dfe-4d56-8f96-7b4f7a2193cb"), "What is your favorite color?" },
                    { new Guid("990cc560-ac0b-4e24-9614-54ffd9cb5270"), "What is your favorite movie?" },
                    { new Guid("9df00ba1-c4de-4f3c-9dae-7b3c6d098f80"), "What is your favorite animal?" },
                    { new Guid("b329c4ee-29cb-4443-ac68-2edac71fa9fc"), "What is your favorite book?" },
                    { new Guid("cc202b4c-3d0f-41ca-abea-ff7aae7352ce"), "What is your favorite sport?" },
                    { new Guid("e2d0e160-35f7-4017-a21f-5cfc25af6193"), "What is your favorite book?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("042a555d-6162-4210-99a1-141fb8965c8b"), 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hunter.Swift@wordpress.org", "Man", true, false, false, "Stuart", -1.0, -71.0, "Savannah", "123456", "01078-108714", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0a1b4456-2a41-4f34-9864-00ce44994605"), 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thomas.Hilton@arstechnica.org.uk", "Man", true, false, false, "Perkins", 67.0, -16.0, "Madelyn", "123456", "01629-590670", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0b3c0dce-1d10-4dea-b14b-32dc199a9323"), 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aubree.Mcgregor@adamriddick.net", "Man", true, false, false, "Sinclair", 15.0, -87.0, "Cooper", "123456", "01975-872580", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d30576e-152e-4a2e-bad0-e2d5603a070d"), 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Power@wikipedia.org.uk", "Man", true, false, false, "Hancock", 38.0, -121.0, "Mason", "123456", "01217-293112", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10f8eb2f-1d54-4cc1-ad52-71fd74ec9c79"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Akhtar@etsy.org.uk", "Woman", true, false, false, "Mcgregor", 11.0, 172.0, "Alexandra", "123456", "01945-955120", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1aaf890b-0cc4-492e-a171-34289a28c284"), 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jackson.Johnson@wordpress.info", "Man", true, false, false, "Fleming", 83.0, 100.0, "Amelia", "123456", "01122-518212", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2048614a-a82d-4308-954c-50b8af0c2987"), 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.Evans@yahoo.co.uk", "Man", true, false, false, "Leach", 38.0, 126.0, "Lydia", "123456", "01104-218646", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22c81fd1-db85-44be-b683-a7c06cea3c98"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", true, true, false, "Admin", -79.0, -46.0, "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("24bae8b9-f6a9-43ea-817a-14a8563f83eb"), 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "K.Brown@microsoft.org", "Woman", true, false, false, "Walters", 45.0, -4.0, "Wyatt", "123456", "01647-617858", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("313dc69e-7f02-49a4-962c-90ec9373f8b5"), 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Easton.Nash@gmail.com", "Woman", true, false, false, "Summers", -58.0, -171.0, "Olivia", "123456", "01092-668074", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("35cd9577-b620-4b34-a5d3-1c5e838155ec"), 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Jones@yelp.com", "Woman", true, false, false, "Osborne", 18.0, -57.0, "Bentley", "123456", "01544-082517", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("451c4724-6810-41d6-a6bd-41e73b7dc093"), 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R.Thompson@taobao.info", "Man", true, false, false, "Davies", 6.0, 109.0, "Jackson", "123456", "01591-275115", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59417b4b-9f1d-43f1-9412-069216845b94"), 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chloe.Buckley@wordpress.co", "Man", true, false, false, "Coles", 80.0, 47.0, "Scott", "123456", "01628-033176", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f62bf8a-41a0-4c7b-ab73-b51a73edf92b"), 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Taylor@sky.co.uk", "Woman", true, false, false, "Barlow", -6.0, 97.0, "Bailey", "123456", "01932-831401", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f66fc94-3b3d-4523-8172-d9eb6893cf1f"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Shepherd@arstechnica.net", "Man", true, false, false, "Smith", 82.0, 88.0, "Owen", "123456", "01469-363969", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("66a51485-1a64-41d1-96fb-485596d90e0e"), 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jacob.Jackson@etsy.co", "Woman", true, false, false, "Thornton", 17.0, -157.0, "Zoe", "123456", "01060-660812", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6cb8c64d-2423-4eab-8653-22dfa44225c6"), 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Giles@bet365.net", "Man", true, false, false, "Abbott", -6.0, -23.0, "Madeline", "123456", "01725-149212", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6faa40e4-1128-49dc-bb0d-67f79a18eb4b"), 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Rossi@ebay.org", "Man", true, false, false, "Schofield", 35.0, -43.0, "Trinity", "123456", "01930-690941", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("728db219-a50c-456d-9d96-f8570959b8cb"), 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christian.Hilton@live.org.uk", "Woman", true, false, false, "Bradshaw", 47.0, 22.0, "Kevin", "123456", "01630-544159", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7d388d46-ada1-4479-a3dc-4640ea7fb363"), 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Thornton@stackoverflow.info", "Man", true, false, false, "Wright", 44.0, 146.0, "Jace", "123456", "01868-713939", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("86d85dbd-1c53-4205-bcba-27b1ce0b2f88"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Hooper@amazon.co", "Man", true, false, false, "Shepherd", 24.0, -16.0, "Dominic", "123456", "01152-193745", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8904535d-4e47-431a-846d-402cb619d385"), 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony.Mac@sky.org", "Woman", true, false, false, "Swift", 35.0, -78.0, "Alexa", "123456", "01418-261559", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ab297b7-21ce-45e1-b4d8-4fcba64f11b4"), 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Blair@163.co", "Man", true, false, false, "Perkins", -69.0, -5.0, "Nevaeh", "123456", "01692-813173", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a3e8d51-5aee-4c11-bb8d-0d4e6bd81f86"), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P.Wyatt@qq.org.uk", "Man", true, false, false, "Kenny", 68.0, 24.0, "Violet", "123456", "01847-500769", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1cae350-fff7-41a0-b948-68fc686bcbc6"), 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R.Walker@msdn.us", "Man", true, false, false, "Hilton", -2.0, 70.0, "Bentley", "123456", "01932-649626", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2ac1f0a-c60b-4a5e-a439-5273af796c8b"), 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Taylor@ask.org.uk", "Woman", true, false, false, "Lord", 88.0, 179.0, "Lauren", "123456", "01531-787757", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3797715-115f-4bf7-925d-1ee2915ba700"), 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hailey.Seymour@adamriddick.org.uk", "Woman", true, false, false, "Watson", -81.0, -38.0, "Savannah", "123456", "01010-996514", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b983ce01-d61b-4146-b2bb-e63ddc3910f5"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lauren.Rossi@lego.org.uk", "Woman", true, false, false, "Coles", -52.0, -135.0, "Anthony", "123456", "01403-509836", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bcc6292e-fa9e-42bd-a014-dfaace259c62"), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Robinson@google.org", "Man", true, false, false, "Whittaker", 46.0, 34.0, "Victoria", "123456", "01580-021519", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bdf42bd7-7a48-4633-aca0-9d850086296e"), 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "K.Buckley@bestbuy.co.uk", "Woman", true, false, false, "Boyd", -44.0, -123.0, "Cooper", "123456", "01251-488613", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c895b7c3-3641-468a-9256-f08343383b50"), 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", true, true, false, "Gürbüz", -22.0, -21.0, "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd81a5fa-8524-4592-b057-f7e2e62e05a0"), 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hudson.Rossi@sky.biz", "Woman", true, false, false, "Mac", 71.0, 154.0, "Naomi", "123456", "01308-795223", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1033cc7-099a-4d74-873d-1ef3ee11d909"), 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Summers@youtube.org.uk", "Woman", true, false, false, "Weaver", -5.0, -62.0, "Victoria", "123456", "01770-926617", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("d7cc81aa-a3f7-41ed-9a60-c63f68090ba0"), 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z.Lewis@paypal.com", "Woman", true, false, false, "Leach", 88.0, 176.0, "Madeline", "123456", "01809-614743", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db470f4d-0d14-47d8-adbe-6caea07a8467"), 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Smith@stackoverflow.info", "Woman", true, false, false, "Wright", -26.0, 45.0, "Jason", "123456", "01555-746187", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eab4ce73-8c2b-4fef-8855-e37d8d5e02a9"), 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Justin.Power@bing.us", "Man", true, false, false, "Blair", 85.0, 51.0, "Aubrey", "123456", "01378-484174", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec4746af-58be-4f27-bc8a-c7d36baeb600"), 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Hooper@maplin.com", "Woman", true, false, false, "Carroll", 67.0, -43.0, "Julia", "123456", "01776-213764", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ed000730-c544-46ff-871a-638c4319bc0a"), 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Nelson@wikipedia.co", "Man", true, false, false, "Wright", 57.0, 148.0, "Adam", "123456", "01077-168225", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ee5bee7d-05aa-4629-9d7d-7935aa86b21a"), 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "K.Evans@sky.info", "Woman", true, false, false, "Boyd", 47.0, -43.0, "Luis", "123456", "01630-353199", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eedbc1b8-9828-4ead-9eab-79e085968d56"), 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.Savage@pinterest.info", "Woman", true, false, false, "Taylor", -25.0, 75.0, "John", "123456", "01680-357891", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe48f468-4db4-4194-b66b-c4b7a7457bcc"), 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "T.Obrien@stackoverflow.biz", "Man", true, false, false, "Chadwick", 48.0, 146.0, "Claire", "123456", "01857-073502", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("febd6ec4-ff3a-4a1a-bf55-3a64fde3d75e"), 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Mann@google.us", "Woman", true, false, false, "Nelson", 61.0, -127.0, "Faith", "123456", "01710-536461", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("1114c733-79b8-4081-bc85-3629d386ad76"), "Answer 0.2", new Guid("8d644aee-7dfe-4d56-8f96-7b4f7a2193cb") },
                    { new Guid("23060ca5-b020-4e5d-98fe-edb8d38a10ec"), "Answer 0.3", new Guid("8d644aee-7dfe-4d56-8f96-7b4f7a2193cb") },
                    { new Guid("322a2d5d-f402-4618-b522-879e95163859"), "Answer 1.2", new Guid("9df00ba1-c4de-4f3c-9dae-7b3c6d098f80") },
                    { new Guid("43be7f15-eaa7-40aa-b83b-1e54eafd6585"), "Answer 3.2", new Guid("cc202b4c-3d0f-41ca-abea-ff7aae7352ce") },
                    { new Guid("5f196ea8-80f0-40b8-a314-71108f71a0ef"), "Answer 3.1", new Guid("cc202b4c-3d0f-41ca-abea-ff7aae7352ce") },
                    { new Guid("75121b73-550d-47ae-8010-41365cb5f09e"), "Answer 2.1", new Guid("463540bd-fdbd-4ce7-ac37-e8f75ce9f089") },
                    { new Guid("7ae74f93-b7f7-49bf-a0b9-c9965a86f268"), "Answer 2.2", new Guid("463540bd-fdbd-4ce7-ac37-e8f75ce9f089") },
                    { new Guid("7fe5faca-3b24-479c-9982-51c6334e9412"), "Answer 2.4", new Guid("463540bd-fdbd-4ce7-ac37-e8f75ce9f089") },
                    { new Guid("83d93a9e-4c9d-4735-a46b-c65faa0a4c32"), "Answer 1.4", new Guid("9df00ba1-c4de-4f3c-9dae-7b3c6d098f80") },
                    { new Guid("9aec5637-426a-4f9e-bd9d-37fcade6680f"), "Answer 4.1", new Guid("990cc560-ac0b-4e24-9614-54ffd9cb5270") },
                    { new Guid("9d82a914-7b90-4da2-8964-29b618cad651"), "Answer 4.6", new Guid("990cc560-ac0b-4e24-9614-54ffd9cb5270") },
                    { new Guid("9dce7f68-d8eb-430f-a300-fd48bfa80268"), "Answer 4.5", new Guid("990cc560-ac0b-4e24-9614-54ffd9cb5270") },
                    { new Guid("a66a319f-383d-4f65-be0d-f3be4a148314"), "Answer 0.4", new Guid("8d644aee-7dfe-4d56-8f96-7b4f7a2193cb") },
                    { new Guid("aaad1ded-5911-4dbe-8ddf-fd7d5f67417c"), "Answer 1.1", new Guid("9df00ba1-c4de-4f3c-9dae-7b3c6d098f80") },
                    { new Guid("c4151a41-e91f-4839-a5df-34472e6df5dc"), "Answer 4.4", new Guid("990cc560-ac0b-4e24-9614-54ffd9cb5270") },
                    { new Guid("c7221f7a-bdaa-47ad-affa-748bde2c761a"), "Answer 3.3", new Guid("cc202b4c-3d0f-41ca-abea-ff7aae7352ce") },
                    { new Guid("d3b9fa80-304e-4a58-84c9-998403f3bbef"), "Answer 4.3", new Guid("990cc560-ac0b-4e24-9614-54ffd9cb5270") },
                    { new Guid("d681c10f-ef45-4581-9c81-8b18076ca0d3"), "Answer 3.4", new Guid("cc202b4c-3d0f-41ca-abea-ff7aae7352ce") },
                    { new Guid("dd81e86d-6037-4e3c-995d-005ea516ea24"), "Answer 0.1", new Guid("8d644aee-7dfe-4d56-8f96-7b4f7a2193cb") },
                    { new Guid("edd00243-257e-43bb-86ff-04952aa76185"), "Answer 1.3", new Guid("9df00ba1-c4de-4f3c-9dae-7b3c6d098f80") },
                    { new Guid("f4c1b58b-1e79-415b-b099-b9ee0b20628d"), "Answer 2.3", new Guid("463540bd-fdbd-4ce7-ac37-e8f75ce9f089") },
                    { new Guid("fb59037c-d747-4545-9cb4-a0e33c96c4d9"), "Answer 4.2", new Guid("990cc560-ac0b-4e24-9614-54ffd9cb5270") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAnswers_QuestionId",
                table: "tblAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblChatLog_User1Id",
                table: "tblChatLog",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblChatLog_User2Id",
                table: "tblChatLog",
                column: "User2Id");

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
                name: "tblChatLog");

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
