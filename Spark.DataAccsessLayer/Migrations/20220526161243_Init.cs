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
                    { new Guid("126320f6-6439-4bd8-8a2f-58a57fef4a5e"), "What is your favorite food?" },
                    { new Guid("24fa12ad-1eb2-4c54-8a77-fa8a439fa7bb"), "What is your favorite movie?" },
                    { new Guid("2953a69c-dde5-47ec-98da-4cdb2e6b2922"), "What is your favorite movie?" },
                    { new Guid("3250d019-b02b-4dce-9cf0-521c587ac6e2"), "What is your favorite TV show?" },
                    { new Guid("5cbb639d-0571-41df-ad92-5d3be6212969"), "What is your favorite book?" },
                    { new Guid("5ec93cce-92c8-4f6d-96e1-6c4bf4a5d915"), "What is your favorite book?" },
                    { new Guid("9b1c28fa-31d4-4412-867d-a594050f8c7a"), "What is your favorite sport?" },
                    { new Guid("ddacb0ba-edd4-403a-a943-142d59839459"), "What is your favorite color?" },
                    { new Guid("f5b6fb3f-64d5-4b24-b6ec-b85c1c628c6d"), "What is your favorite animal?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("07a07261-67f0-4b6a-9dcd-197f07fe950f"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "T.Johnson@gmail.co.uk", "Man", true, false, false, "Silva", -51.0, -75.0, "Mia", "123456", "01978-492178", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("086210dd-4823-426a-99e2-6267ce023cb3"), (short)31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luke.Stuart@live.info", "Woman", true, false, false, "Seymour", -83.0, 156.0, "Claire", "123456", "01913-986952", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("08762458-9b5b-4924-90ce-26154de5b4e8"), (short)33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicholas.Obrien@linkedin.us", "Man", true, false, false, "Harris", -67.0, -57.0, "Blake", "123456", "01229-577866", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c3ee6cc-f34e-4d7c-b3f6-ea02e281cc64"), (short)36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caleb.Whelan@deviantart.co", "Woman", true, false, false, "Jennings", 42.0, 174.0, "Ellie", "123456", "01602-487479", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d01e268-e569-4953-b4c9-cdea823abea0"), (short)64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z.Taylor@globo.net", "Man", true, false, false, "Walters", 44.0, 126.0, "Audrey", "123456", "01920-774571", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e4c0246-1d07-40a4-82a6-9607ec62d53f"), (short)34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ryan.Williams@microsoft.net", "Woman", true, false, false, "Shepherd", -21.0, -79.0, "Katherine", "123456", "01489-186933", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("15d29786-3875-4260-9307-8b128be0d748"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Davies@msdn.co", "Man", true, false, false, "Blair", 20.0, -103.0, "Nathan", "123456", "01018-106319", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("17a0f5cf-d430-4ae3-8cb3-76c4ca48c022"), (short)45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew.Cullen@qq.co", "Woman", true, false, false, "Sanders", -47.0, 153.0, "Serenity", "123456", "01393-064542", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1a99fe07-dd8b-4773-8974-2a2fe5d60cb4"), (short)62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aaron.Thompson@deviantart.com", "Man", true, false, false, "Evans", -11.0, -20.0, "Brody", "123456", "01592-815954", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e456020-62ec-4f39-86aa-6b9c5c039298"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", true, true, false, "Gürbüz", 37.0, 9.0, "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e1e9296-5d37-4acc-bf8e-e5a6c6256936"), (short)35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Hilton@ask.info", "Man", true, false, false, "Carroll", 49.0, -79.0, "Violet", "123456", "01972-345987", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("30943e7e-9e85-4066-9c22-5df11e872c2e"), (short)49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reagan.Adam@studio1337.co.uk", "Woman", true, false, false, "Thorne", -8.0, -144.0, "Nathaniel", "123456", "01113-350733", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d372677-8ab2-4a15-bcef-af8dbc28ce13"), (short)36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin.Swift@flipkart.info", "Woman", true, false, false, "Watson", -85.0, 11.0, "Genesis", "123456", "01396-607291", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d9b4001-cf97-4bdc-94e7-888c8c650a52"), (short)19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bailey.Riddick@maplin.co.uk", "Woman", true, false, false, "Kenny", -20.0, -150.0, "Adrian", "123456", "01799-887597", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b98484a-355c-456b-9be3-d0c2f2b6b631"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amelia.Wood@wordpress.co.uk", "Man", true, false, false, "Mac", 43.0, -177.0, "Cooper", "123456", "01490-278169", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4ca7081b-17b8-4b7f-b0b6-3d96ef7b1c2f"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angel.Cassidy@lego.org", "Woman", true, false, false, "Whittaker", -4.0, -162.0, "Aiden", "123456", "01255-941309", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("50ff8cf8-25df-4ad2-9281-6d5841c12dcb"), (short)60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Mann@linkedin.biz", "Man", true, false, false, "Chadwick", -84.0, -38.0, "Matthew", "123456", "01301-306119", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5179948b-9637-4487-b53c-c7628ce643e4"), (short)35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isaac.Silva@google.net", "Man", true, false, false, "Evans", 65.0, 11.0, "Christian", "123456", "01641-247555", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57ae6816-06d6-4c5a-9698-c1c09a4d0248"), (short)60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Mann@flipkart.co.uk", "Man", true, false, false, "Jones", -23.0, -84.0, "Isaiah", "123456", "01413-333627", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("61f6bc31-740d-4097-8245-5e07b2bbb1f5"), (short)24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faith.Baldwin@yahoo.biz", "Man", true, false, false, "Jackson", -51.0, 60.0, "Aaliyah", "123456", "01570-017370", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6dc186bb-e8dc-492b-9bbd-3a73a3839f80"), (short)61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P.Wright@live.co", "Man", true, false, false, "Briggs", 24.0, 84.0, "Maya", "123456", "01471-552066", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c9cc5b2-19aa-4b68-ac1c-c550600cf043"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul.Peters@bestbuy.biz", "Man", true, false, false, "Boyd", 26.0, 139.0, "Carter", "123456", "01747-186093", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8933c4ec-8823-4a6f-b930-c85e4055563c"), (short)24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor.Mellor@theguardian.info", "Woman", true, false, false, "Mann", 69.0, -49.0, "Scarlett", "123456", "01724-299440", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89bf02a3-4a58-49c4-b34e-6bb16d606ac6"), (short)35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hailey.Lord@youtube.biz", "Man", true, false, false, "Jackson", -52.0, -3.0, "Lily", "123456", "01251-650416", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("93c705c6-0a7a-4fca-b5b8-b01bb84308e3"), (short)29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Boyd@globo.net", "Man", true, false, false, "Shepherd", 8.0, 111.0, "Addison", "123456", "01109-635858", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("97d32340-4568-4717-8687-a5336dc032b2"), (short)23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Adam@stackoverflow.co.uk", "Woman", true, false, false, "Blair", -25.0, -180.0, "Christopher", "123456", "01186-376802", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4bcac39-5d90-4f95-ab1d-3ec1471ddc17"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Akhtar@sky.co.uk", "Woman", true, false, false, "Whitehouse", 82.0, 52.0, "Brooklyn", "123456", "01093-377486", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a536ac6a-6deb-4ed7-8182-b7e15c7fdf5d"), (short)51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Mac@etsy.com", "Man", true, false, false, "Wilson", 84.0, 141.0, "John", "123456", "01032-567049", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a8a0e290-413f-4d7e-9ecd-c335d9eab7db"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luke.Johnson@baidu.info", "Woman", true, false, false, "Roberts", 56.0, -165.0, "Charlotte", "123456", "01558-826457", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ae380d63-57ef-481b-a745-1156ded16ee8"), (short)34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Molly.Johnson@bing.biz", "Man", true, false, false, "Dale", -56.0, 83.0, "Hudson", "123456", "01544-642303", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b13ae2ca-9444-4574-b977-98d5601083c5"), (short)21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicholas.Brown@sohu.co", "Woman", true, false, false, "Thomas", -5.0, 175.0, "Dylan", "123456", "01122-447518", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1a4ceaa-285b-443a-80b8-166e47e71adf"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", true, true, false, "Admin", -15.0, -63.0, "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c79d2216-6edb-43e8-83bf-bba091d64581"), (short)47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Cassidy@microsoft.net", "Woman", true, false, false, "Adam", -66.0, 106.0, "London", "123456", "01586-516874", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("ca080383-548f-4208-90b1-9c7fb7019ccc"), (short)28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Lewis@arstechnica.com", "Woman", true, false, false, "Coles", 33.0, -50.0, "Skylar", "123456", "01777-326182", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cca2117d-4a03-4595-af30-2dd3b695f0fc"), (short)33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark.Mcfarlane@wikia.co.uk", "Man", true, false, false, "Wood", -29.0, 89.0, "Austin", "123456", "01389-237179", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ce0cc5ff-3398-449b-80d3-a7b3fce671ae"), (short)47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Whelan@ask.net", "Woman", true, false, false, "Little", -27.0, 107.0, "Kevin", "123456", "01799-894999", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9239f67-7f7b-4eb7-aaba-e02f96f9c33a"), (short)53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Taylor@taobao.net", "Man", true, false, false, "Osborne", 45.0, -83.0, "Kylie", "123456", "01108-910901", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5de8bf3-901b-41fe-a4c4-479d2c6536aa"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Watson@qq.info", "Woman", true, false, false, "Mclean", -23.0, -130.0, "London", "123456", "01228-773046", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ea07bbb3-e75d-4369-93b5-07267fa42ded"), (short)54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "K.Kenny@sohu.biz", "Woman", true, false, false, "Stuart", 69.0, 8.0, "Anthony", "123456", "01588-681737", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("edfc8a0e-759b-403f-8762-428ddb9500de"), (short)56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jason.Walters@techcrunch.us", "Woman", true, false, false, "Stuart", -37.0, -17.0, "Mark", "123456", "01346-272290", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eebc7316-1071-4120-b807-7904ed509407"), (short)27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julian.Thompson@etsy.net", "Woman", true, false, false, "Stuart", -40.0, -119.0, "Josiah", "123456", "01713-578441", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f540c535-a928-4a49-8845-50491e29273d"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lily.Perkins@bet365.co.uk", "Man", true, false, false, "Power", -67.0, 149.0, "Xavier", "123456", "01767-212541", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("077d4006-dfd0-4a4b-9161-1e656aebc215"), "Answer 3.3", new Guid("9b1c28fa-31d4-4412-867d-a594050f8c7a") },
                    { new Guid("09a54ed7-35a4-4609-9588-757980e2aa8a"), "Answer 0.2", new Guid("ddacb0ba-edd4-403a-a943-142d59839459") },
                    { new Guid("0a1af1a4-405c-4fd8-83d5-e3c48c1d18e6"), "Answer 4.1", new Guid("2953a69c-dde5-47ec-98da-4cdb2e6b2922") },
                    { new Guid("1b7c312a-3cc0-4143-b794-b78a1e6c41b4"), "Answer 3.2", new Guid("9b1c28fa-31d4-4412-867d-a594050f8c7a") },
                    { new Guid("20bb699e-6bec-44ae-abb7-bc700bf2301d"), "Answer 4.4", new Guid("2953a69c-dde5-47ec-98da-4cdb2e6b2922") },
                    { new Guid("28f09c1a-40dc-4fe1-b876-2b49e906336d"), "Answer 4.2", new Guid("2953a69c-dde5-47ec-98da-4cdb2e6b2922") },
                    { new Guid("31baeca1-f51e-4282-9e62-3ae5e719e90b"), "Answer 2.3", new Guid("126320f6-6439-4bd8-8a2f-58a57fef4a5e") },
                    { new Guid("3f42ae72-c3b6-4898-b832-c4e072439ae9"), "Answer 4.5", new Guid("2953a69c-dde5-47ec-98da-4cdb2e6b2922") },
                    { new Guid("3fc32342-f2ab-42e8-8064-01e5dda8ca76"), "Answer 3.1", new Guid("9b1c28fa-31d4-4412-867d-a594050f8c7a") },
                    { new Guid("44aebeae-4ee2-4148-880b-64411d567b16"), "Answer 1.1", new Guid("f5b6fb3f-64d5-4b24-b6ec-b85c1c628c6d") },
                    { new Guid("45d9ff96-467d-4c4f-b654-388b4add16a2"), "Answer 2.2", new Guid("126320f6-6439-4bd8-8a2f-58a57fef4a5e") },
                    { new Guid("4ad5809a-8923-432d-9165-41e9b01ca23b"), "Answer 0.4", new Guid("ddacb0ba-edd4-403a-a943-142d59839459") },
                    { new Guid("4e04e89a-1de6-4bb8-aa38-6d8d06737c11"), "Answer 0.1", new Guid("ddacb0ba-edd4-403a-a943-142d59839459") },
                    { new Guid("4e403cc0-d4ce-4bdf-9403-d76774914c67"), "Answer 1.4", new Guid("f5b6fb3f-64d5-4b24-b6ec-b85c1c628c6d") },
                    { new Guid("526af9d9-bcf2-4405-abf0-53f7397d5943"), "Answer 4.3", new Guid("2953a69c-dde5-47ec-98da-4cdb2e6b2922") },
                    { new Guid("679796f0-5816-48a5-96d7-c4f42f875d62"), "Answer 1.2", new Guid("f5b6fb3f-64d5-4b24-b6ec-b85c1c628c6d") },
                    { new Guid("71ba581a-06dd-4f6a-9368-5af97bc91a49"), "Answer 3.4", new Guid("9b1c28fa-31d4-4412-867d-a594050f8c7a") },
                    { new Guid("8b1fcc1a-5de8-48f8-82a7-44140ea66b66"), "Answer 4.6", new Guid("2953a69c-dde5-47ec-98da-4cdb2e6b2922") },
                    { new Guid("a06db825-2dbd-4d9d-b14d-0fba808e356b"), "Answer 0.3", new Guid("ddacb0ba-edd4-403a-a943-142d59839459") },
                    { new Guid("adf4d301-912c-4582-b421-e8748b9cc3ba"), "Answer 2.1", new Guid("126320f6-6439-4bd8-8a2f-58a57fef4a5e") },
                    { new Guid("c40a7f94-c432-4c4f-b411-e4b4ac18522e"), "Answer 2.4", new Guid("126320f6-6439-4bd8-8a2f-58a57fef4a5e") },
                    { new Guid("fcd4fad0-2081-4f30-8034-c467f653aff2"), "Answer 1.3", new Guid("f5b6fb3f-64d5-4b24-b6ec-b85c1c628c6d") }
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
