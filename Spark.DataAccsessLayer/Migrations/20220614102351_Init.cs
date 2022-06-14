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
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { new Guid("2118e744-c566-4921-ab32-827179e6bcbf"), "What is your favorite food?" },
                    { new Guid("26350eb4-78b7-48b6-b5e7-cc2896e0f54c"), "What is your favorite animal?" },
                    { new Guid("9daef5e5-9e2b-458b-a0f2-8dd89f8fd1d5"), "What is your favorite book?" },
                    { new Guid("a66e2a98-542b-42ba-987a-f1a6927f8e9a"), "What is your favorite movie?" },
                    { new Guid("a9129d44-2390-406b-b89e-68389168b3a9"), "What is your favorite movie?" },
                    { new Guid("c91b676d-b080-418c-ae06-51c902b958cc"), "What is your favorite sport?" },
                    { new Guid("d21fc925-b9f6-43cc-8bbb-53ba4a23493e"), "What is your favorite TV show?" },
                    { new Guid("d846670b-bc25-4269-be0e-ed1ae8c45e32"), "What is your favorite book?" },
                    { new Guid("dede390b-ac58-40b2-b416-06b092f0330e"), "What is your favorite color?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "ImagePath", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("001ca796-7725-41a8-929b-5313acc60e66"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", "", true, true, false, "Admin", -69.0, 80.0, "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("052a5158-1543-4f68-8508-df1cc210eb8e"), 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack.Akhtar@baidu.org.uk", "Woman", "", true, false, false, "Whelan", 55.0, 13.0, "Avery", "123456", "01082-509240", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c1b1746-fdf1-4126-9b9f-2b3374725801"), 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "London.Stuart@adamriddick.org", "Man", "", true, false, false, "Coles", 22.0, 64.0, "Ryder", "123456", "01161-253758", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d644dd5-aa6a-4cd0-bccf-3446f69b853d"), 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Hancock@globo.org.uk", "Man", "", true, false, false, "Thomas", 41.0, 105.0, "Luis", "123456", "01323-966595", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f0e6243-6949-4792-ba72-5c5a20844ba3"), 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kylie.Boyd@techcrunch.co", "Man", "", true, false, false, "Swift", -5.0, -77.0, "Logan", "123456", "01089-834459", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11dc7526-4683-4428-a170-74bf9d470b04"), 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Davies@bet365.us", "Woman", "", true, false, false, "Wright", 55.0, 84.0, "Lucas", "123456", "01246-820176", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("12d2bdba-523a-4cde-a92b-fba27c45b6ba"), 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jocelyn.Vaughan@adamriddick.com", "Woman", "", true, false, false, "Roberts", 58.0, 147.0, "London", "123456", "01126-000368", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("160eba25-3c6b-4cb1-89dc-ea3c1d822f6b"), 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew.Carroll@lego.co.uk", "Woman", "", true, false, false, "Mac", -87.0, 126.0, "Hudson", "123456", "01254-317306", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1c6cd348-7ea2-44ea-9303-1e9039fc827f"), 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sebastian.White@sky.org.uk", "Man", "", true, false, false, "Cullen", -65.0, -99.0, "Jack", "123456", "01833-181221", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("208cc23c-8039-4c31-89ba-feb6dd2e14cb"), 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Walker@theguardian.com", "Man", "", true, false, false, "Seymour", -64.0, 3.0, "Makayla", "123456", "01840-935355", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("21cde6d8-299c-4db5-bf7b-671bd0afb48a"), 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P.Buckley@ebay.info", "Man", "", true, false, false, "Whittaker", 14.0, 177.0, "Caroline", "123456", "01256-571794", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("24e16ab3-d0a7-449a-88e5-3fb9e8a7ad1e"), 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeremiah.Mann@gmail.com", "Man", "", true, false, false, "Walker", 30.0, 129.0, "Wyatt", "123456", "01214-812963", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a2e70a8-1e23-4523-87a4-5daf146e5deb"), 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Adam@paypal.co", "Woman", "", true, false, false, "Osborne", 16.0, -104.0, "Abigail", "123456", "01740-679013", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("34c3a703-c158-4d7c-95ee-12c0e3a7b5e1"), 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jocelyn.Silva@sky.info", "Man", "", true, false, false, "Lord", -40.0, -46.0, "Jocelyn", "123456", "01542-944683", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("42209284-26eb-4038-aed0-9d92f9c9ba7a"), 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Coles@studio1337.com", "Woman", "", true, false, false, "Cullen", 79.0, 17.0, "Grace", "123456", "01935-654396", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4322af70-2b7c-4e6d-b231-7ff3706e9492"), 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Schofield@studio1337.biz", "Man", "", true, false, false, "Jones", 14.0, 33.0, "Robert", "123456", "01765-027680", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e1cd82a-6194-4b9d-9628-f3e3b2197a7e"), 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaylee.Wood@qq.co.uk", "Man", "", true, false, false, "Peters", 38.0, -163.0, "Lily", "123456", "01243-895278", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4f7bd39e-c734-446c-b342-41536a48a318"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aaron.Jackson@sky.co.uk", "Woman", "", true, false, false, "Joyce", 81.0, 51.0, "Natalie", "123456", "01503-593236", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59cc2562-c3d7-47eb-9056-940fac1968e6"), 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maya.Taylor@163.info", "Woman", "", true, false, false, "Swift", 81.0, 5.0, "Jack", "123456", "01294-132657", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ee0e1eb-fe7a-4da1-a302-547f506f2d60"), 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jacob.Silva@bestbuy.us", "Man", "", true, false, false, "Schofield", -63.0, -115.0, "Adam", "123456", "01843-267045", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f83b9e7-32f7-4003-b56e-3884cb6814d5"), 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caroline.Briggs@ask.net", "Man", "", true, false, false, "Thornton", -72.0, -84.0, "John", "123456", "01238-061980", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("752c50cf-2a45-46e0-9393-4ac874537aff"), 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nolan.Jennings@expedia.biz", "Woman", "", true, false, false, "Boyd", 76.0, 152.0, "Audrey", "123456", "01623-182519", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("84b032fa-5eeb-447f-8b0d-4df2ad3c9b57"), 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Barlow@deviantart.org.uk", "Woman", "", true, false, false, "Rossi", 34.0, -124.0, "Aaron", "123456", "01553-965483", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("87c80e23-9dea-414e-b3d0-990809235df4"), 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Carroll@wikipedia.co", "Woman", "", true, false, false, "Mohamed", -85.0, 66.0, "Bentley", "123456", "01212-546522", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("933909fb-3c17-4dd7-8cef-2964585ce3a5"), 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abigail.Riddick@stackoverflow.org.uk", "Woman", "", true, false, false, "Brown", -15.0, -88.0, "Victoria", "123456", "01907-853869", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("959fa116-0e54-4808-9f8c-e8bafcf6466a"), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.Shepherd@google.net", "Man", "", true, false, false, "Cullen", 41.0, -50.0, "Melanie", "123456", "01033-996765", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b9cc111-aed5-4d06-901b-b303c213b5b8"), 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Makayla.Mann@studio1337.info", "Woman", "", true, false, false, "Vaughan", -13.0, -156.0, "Elizabeth", "123456", "01444-294866", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f9c8f7e-7045-47b5-9be1-a6b962302542"), 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Seymour@flipkart.co.uk", "Man", "", true, false, false, "Kenny", -62.0, -42.0, "Serenity", "123456", "01664-410755", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a75e9144-6fe9-4447-8eeb-85882db181b9"), 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordan.Jackson@maplin.org", "Man", "", true, false, false, "Sanders", 1.0, -126.0, "Hannah", "123456", "01641-276781", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9e50e2e-a3d3-4c4d-bce0-387e06912204"), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaylee.Mcgregor@sky.org", "Man", "", true, false, false, "Boyd", -77.0, -128.0, "Owen", "123456", "01284-554544", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aa3af969-a7eb-454a-8ad3-c5a62e089b7a"), 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David.Taylor@taobao.net", "Man", "", true, false, false, "Akhtar", 88.0, -100.0, "Aaliyah", "123456", "01531-923682", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b4b884d0-34af-4d7b-9f0d-8e1b7c8b08ce"), 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew.Jackson@msdn.us", "Woman", "", true, false, false, "Fleming", 66.0, 134.0, "Andrew", "123456", "01408-780848", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c57660b5-57b6-4c6d-b691-cffd579669bc"), 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riley.Whitehead@deviantart.us", "Woman", "", true, false, false, "Hancock", -31.0, -108.0, "Taylor", "123456", "01164-063188", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "ImagePath", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("d287a77c-361e-4031-8d88-0c62f30b42fb"), 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nevaeh.Welch@lego.biz", "Woman", "", true, false, false, "Blair", -42.0, 135.0, "Lucas", "123456", "01829-234045", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d3f1613c-6b1f-4a52-9c5e-02463e9f8c03"), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Smith@deviantart.biz", "Man", "", true, false, false, "Mcgregor", 15.0, -5.0, "Jace", "123456", "01149-476140", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2dad40c-a9cb-4ee4-bb86-ccc1d926b9ea"), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Coles@arstechnica.net", "Woman", "", true, false, false, "Thompson", 20.0, -120.0, "Kennedy", "123456", "01716-373219", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ee8266ac-9f98-4c50-966f-473461eabf77"), 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Hooper@bestbuy.com", "Woman", "", true, false, false, "Haines", -53.0, 2.0, "Samantha", "123456", "01065-962964", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f171a2c9-8cad-49ac-aac7-050d45aa13fd"), 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul.Coles@theguardian.biz", "Man", "", true, false, false, "Savage", -76.0, 9.0, "Austin", "123456", "01777-336986", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f45a33d2-5d90-4c3e-8638-64d5f3b1b973"), 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Thomas@sohu.info", "Woman", "", true, false, false, "Wyatt", 76.0, 114.0, "Ryder", "123456", "01294-223654", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f645f022-2677-432a-83a9-7c3d565121cd"), 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Blair@sohu.co.uk", "Woman", "", true, false, false, "Dale", 17.0, 148.0, "Anthony", "123456", "01490-575841", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("faaf0ccf-cae6-4009-8b36-3b0aa7694326"), 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", "", true, true, false, "Gürbüz", 57.0, 111.0, "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fdb547a2-8d26-4cc3-b7a1-1e7ce041a1ba"), 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexis.Adam@bing.info", "Man", "", true, false, false, "Thompson", -72.0, -7.0, "Matthew", "123456", "01699-789354", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("0e2fdc71-1d91-425e-8567-b05842577283"), "Answer 3.4", new Guid("c91b676d-b080-418c-ae06-51c902b958cc") },
                    { new Guid("15febbf8-fbb1-4007-935a-15633e090c19"), "Answer 4.5", new Guid("a66e2a98-542b-42ba-987a-f1a6927f8e9a") },
                    { new Guid("17b9b647-a9e6-4e09-886d-cbee4e9929d4"), "Answer 4.6", new Guid("a66e2a98-542b-42ba-987a-f1a6927f8e9a") },
                    { new Guid("206d8bfb-6e7f-40e9-9fb7-3d76fecb3695"), "Answer 4.4", new Guid("a66e2a98-542b-42ba-987a-f1a6927f8e9a") },
                    { new Guid("3027bd9d-920d-45e1-98c2-963643b9bce2"), "Answer 4.3", new Guid("a66e2a98-542b-42ba-987a-f1a6927f8e9a") },
                    { new Guid("4153d117-7a02-427d-99c9-7c3cb9735d07"), "Answer 2.2", new Guid("2118e744-c566-4921-ab32-827179e6bcbf") },
                    { new Guid("421aae94-fa72-44e4-bebf-37f58a838ed5"), "Answer 3.3", new Guid("c91b676d-b080-418c-ae06-51c902b958cc") },
                    { new Guid("4332b4d3-8115-4e7a-9b6b-511bcb2aaa35"), "Answer 1.4", new Guid("26350eb4-78b7-48b6-b5e7-cc2896e0f54c") },
                    { new Guid("516769ad-2759-4c01-a5b9-28400bc9fdbb"), "Answer 0.2", new Guid("dede390b-ac58-40b2-b416-06b092f0330e") },
                    { new Guid("5ac8e639-a0ac-43ac-80a9-fbdb0d275984"), "Answer 4.1", new Guid("a66e2a98-542b-42ba-987a-f1a6927f8e9a") },
                    { new Guid("73a19344-7357-4f13-817f-4605e8c79922"), "Answer 0.1", new Guid("dede390b-ac58-40b2-b416-06b092f0330e") },
                    { new Guid("75ee4837-9946-430b-a974-7ccfb4457868"), "Answer 0.3", new Guid("dede390b-ac58-40b2-b416-06b092f0330e") },
                    { new Guid("77381ec3-e6b1-4566-8db6-e833f383a909"), "Answer 4.2", new Guid("a66e2a98-542b-42ba-987a-f1a6927f8e9a") },
                    { new Guid("81e578b7-5ac7-49e8-9890-386e4624490e"), "Answer 2.3", new Guid("2118e744-c566-4921-ab32-827179e6bcbf") },
                    { new Guid("97937d36-68ec-430b-9d8a-7561d9fa0a7d"), "Answer 2.1", new Guid("2118e744-c566-4921-ab32-827179e6bcbf") },
                    { new Guid("990a80c2-b8f2-46a2-b672-3bb926df3055"), "Answer 2.4", new Guid("2118e744-c566-4921-ab32-827179e6bcbf") },
                    { new Guid("9b334494-815c-4d31-bdd5-ed237edf9855"), "Answer 1.3", new Guid("26350eb4-78b7-48b6-b5e7-cc2896e0f54c") },
                    { new Guid("9e605997-b21f-4ec6-9312-d455dd41b613"), "Answer 3.1", new Guid("c91b676d-b080-418c-ae06-51c902b958cc") },
                    { new Guid("dde449e7-b8ed-45fe-be64-6384e0848ef0"), "Answer 0.4", new Guid("dede390b-ac58-40b2-b416-06b092f0330e") },
                    { new Guid("e12b2940-2471-4306-8d88-35e5b6b96bfb"), "Answer 1.1", new Guid("26350eb4-78b7-48b6-b5e7-cc2896e0f54c") },
                    { new Guid("ed1da9f6-35c5-46ea-93fd-c7cfbb389614"), "Answer 3.2", new Guid("c91b676d-b080-418c-ae06-51c902b958cc") },
                    { new Guid("f08c01eb-9d3d-4103-be8b-093a1635b8d5"), "Answer 1.2", new Guid("26350eb4-78b7-48b6-b5e7-cc2896e0f54c") }
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
