using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spark.DataAccessLayer.Migrations
{
    public partial class init : Migration
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
                    { new Guid("0a8fe0ca-9dda-4fae-b912-80786d5ce9db"), "What is your favorite book?" },
                    { new Guid("1ec86833-eeda-43d3-8437-d4ff353864d2"), "What is your favorite TV show?" },
                    { new Guid("20d6e3d8-c6f1-4fc9-8c05-3276007d2f40"), "What is your favorite sport?" },
                    { new Guid("2c8ea75e-ba92-4590-893f-0dca722c5d8b"), "What is your favorite movie?" },
                    { new Guid("4312cf57-cd63-4589-a2ea-b5a1a8187b13"), "What is your favorite food?" },
                    { new Guid("86febca3-d570-4f62-9c3c-30ac7a59e20f"), "What is your favorite color?" },
                    { new Guid("aa373c94-0f36-41d5-b2f3-57ad38b94a14"), "What is your favorite book?" },
                    { new Guid("ceccd7df-c372-4b49-b070-16bd57ee2456"), "What is your favorite movie?" },
                    { new Guid("dce9f771-8f51-4af8-978b-3965db3915f9"), "What is your favorite animal?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "ImagePath", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0ede5275-71db-4950-8d1b-f973cb30991a"), 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natalie.Burrows@deviantart.biz", "Man", "user", true, false, false, "Vaughan", 43.0, 40.0, "Samuel", "123456", "01324-795038", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1d00bfe7-8f02-4db0-823b-ff8de9c589be"), 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandra.Wood@lego.co.uk", "Man", "user", true, false, false, "Mclean", 50.0, 71.0, "Alex", "123456", "01631-840112", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22cb8eca-c1c8-4182-932a-8b91705aaa40"), 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Mohamed@pinterest.com", "Man", "user", true, false, false, "Obrien", -27.0, 96.0, "Aaliyah", "123456", "01734-013161", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2daf931e-0568-4ecd-a112-c7b6cc08cd52"), 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver.Wyatt@amazon.biz", "Woman", "user", true, false, false, "Savage", 57.0, 38.0, "Sofia", "123456", "01192-574386", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31077c93-3fcd-4512-85e2-1c2fed1a843a"), 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kennedy.Naylor@yahoo.co", "Man", "user", true, false, false, "Barlow", -6.0, 142.0, "Alexander", "123456", "01635-224884", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("362b6652-2199-48f4-9df1-cec5acf3ace6"), 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chloe.Stuart@google.co.uk", "Man", "user", true, false, false, "Stuart", -60.0, -92.0, "Caroline", "123456", "01410-461569", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d27dbca-f64a-4613-ad62-b454700f397a"), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Mann@yelp.com", "Man", "user", true, false, false, "Joyce", 13.0, 111.0, "Mark", "123456", "01593-719611", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("41e1cb9a-352b-4f6a-aea0-958ff67f8ab6"), 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "K.Whittaker@techcrunch.com", "Man", "user", true, false, false, "Harris", 8.0, -143.0, "Cooper", "123456", "01304-856356", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4692f8b5-6883-4fde-9788-4a2e81c49136"), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.Harris@amazon.net", "Woman", "user", true, false, false, "Cassidy", -43.0, 174.0, "Kaylee", "123456", "01793-000005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("47b182aa-2689-43da-9dc4-bdc7c0f2de58"), 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aiden.Kenny@theguardian.org.uk", "Woman", "user", true, false, false, "Jones", -10.0, -135.0, "Kaylee", "123456", "01246-724128", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b7987c9-9b20-4033-9977-38f7b9df6f56"), 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Evans@amazon.info", "Woman", "user", true, false, false, "White", -79.0, 1.0, "Bentley", "123456", "01480-007765", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("54491fd5-9cc4-4fe2-9c6f-9b372d0eac88"), 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Cassidy@google.net", "Woman", "user", true, false, false, "Watson", -16.0, -20.0, "Aiden", "123456", "01737-350969", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("557b96f3-763f-41d9-8ca2-1996d5d011c3"), 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Nash@ebay.net", "Woman", "user", true, false, false, "Johnson", -17.0, -86.0, "Nolan", "123456", "01000-056460", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("563bdc59-adad-4182-9ce0-0822f3de5447"), 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natalie.Thomas@cnn.com", "Man", "user", true, false, false, "Welch", 70.0, -156.0, "Addison", "123456", "01413-125869", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5b2a7808-a368-489a-9743-4f152cd00e58"), 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Watson@globo.org.uk", "Woman", "user", true, false, false, "Jackson", -62.0, 113.0, "Michael", "123456", "01566-965707", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5efb0982-cf7c-458d-9439-c5b72f68aaf8"), 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nolan.Savage@theguardian.info", "Man", "user", true, false, false, "Thorne", -40.0, 98.0, "Christian", "123456", "01189-439870", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60516aab-b786-485e-b82f-75241b800233"), 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "K.Boyd@arstechnica.com", "Woman", "user", true, false, false, "Mcfarlane", -57.0, 149.0, "Tyler", "123456", "01187-730565", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7725503b-1da6-497a-94f0-b2e5c6ca2396"), 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel.Peters@msdn.co.uk", "Man", "user", true, false, false, "Mcgrath", 30.0, -20.0, "Isabella", "123456", "01384-554331", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a3b59ae-9c37-41d5-a778-5932a72c5c07"), 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "F.Akhtar@bing.co.uk", "Woman", "user", true, false, false, "Seymour", 30.0, 28.0, "Melanie", "123456", "01476-764703", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7dc57f5f-4c0b-4bc9-9d4a-c3b82c6e5cbd"), 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Jennings@expedia.co", "Man", "user", true, false, false, "Wyatt", 77.0, 14.0, "Jaxon", "123456", "01054-573455", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7dd654a3-efc2-4241-9363-63f2d59ffa84"), 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Watson@lego.org", "Man", "user", true, false, false, "White", 48.0, 131.0, "Gabriel", "123456", "01728-145816", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("832e24ca-737f-4135-84ce-b6b936723154"), 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julian.Coles@globo.com", "Man", "user", true, false, false, "White", -39.0, 108.0, "Kayla", "123456", "01279-807862", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8494b896-eadc-49ec-8299-0208ba3e0e81"), 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Sanders@taobao.co", "Man", "user", true, false, false, "Sanders", -15.0, -130.0, "Jose", "123456", "01078-555176", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("85774bde-7d0b-4a10-85dd-a5f8ca7a156c"), 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elijah.Silva@baidu.org.uk", "Man", "user", true, false, false, "Giles", -13.0, -8.0, "Samantha", "123456", "01843-227178", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("861de664-979b-45d8-a340-371111aba2a3"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", "user", true, true, false, "Admin", -53.0, 58.0, "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("87627f52-ecbc-43fd-9c5e-896f14c7901c"), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Austin.Boyd@gmail.co", "Man", "user", true, false, false, "Davies", 40.0, -153.0, "Genesis", "123456", "01516-617191", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8bdb3d0e-2a6f-4e32-8a81-b6cab0beefe8"), 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Leach@ebay.net", "Woman", "user", true, false, false, "Summers", -70.0, 7.0, "Brianna", "123456", "01373-153828", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9641c489-8d13-4be5-9551-b32aca324e16"), 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.Mcfarlane@expedia.us", "Woman", "user", true, false, false, "Rossi", 42.0, -99.0, "Autumn", "123456", "01090-340981", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f480b0a-6d42-429b-9961-34270f3e44c9"), 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony.Schofield@bestbuy.org.uk", "Man", "user", true, false, false, "Thorne", -34.0, -164.0, "Andrea", "123456", "01448-174707", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a60419d9-f0e1-4386-8475-681d5982c7ec"), 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Wilson@stackoverflow.co.uk", "Woman", "user", true, false, false, "Hilton", -68.0, 50.0, "Tyler", "123456", "01029-729394", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b567d950-0a9e-4d7d-a708-48c1857d149a"), 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Wyatt@qq.org.uk", "Woman", "user", true, false, false, "Joyce", 37.0, -160.0, "Gabriella", "123456", "01185-085486", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ceb2aaca-e357-4b2b-beb3-4d47f3caec59"), 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Lewis@wikipedia.co", "Woman", "user", true, false, false, "Buckley", 13.0, -143.0, "Bailey", "123456", "01347-972894", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0433f54-94c7-4a75-acb0-f4e1c83a4f55"), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Perkins@techcrunch.us", "Woman", "user", true, false, false, "Smith", 65.0, 79.0, "Josiah", "123456", "01534-866454", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "ImagePath", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("d1673382-a523-4cbe-94f6-776afea46317"), 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrea.Barlow@gmail.info", "Woman", "user", true, false, false, "Mcfarlane", 22.0, -145.0, "Brayden", "123456", "01750-459720", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1a5da2c-fbfe-44a4-b9a3-b6bbb6c5b6c7"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Wyatt@arstechnica.org", "Woman", "user", true, false, false, "Kenny", 31.0, 127.0, "Isaac", "123456", "01285-495162", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("de1b6fd9-a28b-42fb-ac09-8affe3bb93d9"), 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aria.Taylor@gmail.org.uk", "Woman", "user", true, false, false, "Jennings", -84.0, 22.0, "Colton", "123456", "01259-209926", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e28b5438-8090-4dd1-8677-d38adfeddad9"), 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", "user", true, true, false, "Gürbüz", -51.0, 34.0, "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2c8de87-08cf-4c01-80f8-62360288ed28"), 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grace.Smith@linkedin.biz", "Man", "user", true, false, false, "Haines", -63.0, -112.0, "Mackenzie", "123456", "01151-149218", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e42248ef-1924-4882-9775-ad5893ad086e"), 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claire.Little@wikia.us", "Man", "user", true, false, false, "Little", 25.0, 160.0, "Alyssa", "123456", "01104-099777", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e79caf95-7982-4cc6-9899-7376bf4295f3"), 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominic.Savage@baidu.co", "Woman", "user", true, false, false, "Carroll", 76.0, 130.0, "Layla", "123456", "01587-353209", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ea5ccd44-a0e1-4006-bccb-8eec6f70b44e"), 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Henry.Swift@ask.co", "Man", "user", true, false, false, "Lindsay", -76.0, -104.0, "Cameron", "123456", "01679-898758", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3532fc1-9890-4d88-accb-6dae646a2e7b"), 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kennedy.Sanders@wikipedia.co.uk", "Woman", "user", true, false, false, "Lewis", -87.0, -19.0, "Charlotte", "123456", "01855-398153", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("16f5eb45-7153-4c06-a3f5-b6ba770c8e2c"), "Answer 3.3", new Guid("20d6e3d8-c6f1-4fc9-8c05-3276007d2f40") },
                    { new Guid("1b4f9f5f-e156-401c-9c5d-f6fe76c100ae"), "Answer 2.2", new Guid("4312cf57-cd63-4589-a2ea-b5a1a8187b13") },
                    { new Guid("1e945f7e-fcf6-4d4a-96bd-d81b11c625f9"), "Answer 1.4", new Guid("dce9f771-8f51-4af8-978b-3965db3915f9") },
                    { new Guid("2cc3142a-7a0e-48ae-8844-430d0182f32d"), "Answer 4.3", new Guid("ceccd7df-c372-4b49-b070-16bd57ee2456") },
                    { new Guid("3707ed54-d2ab-41a6-a991-3163f47e0dd1"), "Answer 2.4", new Guid("4312cf57-cd63-4589-a2ea-b5a1a8187b13") },
                    { new Guid("4ad04232-616b-48c4-bbed-e2c9d6ea46f8"), "Answer 2.1", new Guid("4312cf57-cd63-4589-a2ea-b5a1a8187b13") },
                    { new Guid("4cc139d5-4085-460a-ad9f-e5fec6807aad"), "Answer 0.2", new Guid("86febca3-d570-4f62-9c3c-30ac7a59e20f") },
                    { new Guid("4f8d098a-8ee8-49f3-b33c-95c5ca976df3"), "Answer 4.5", new Guid("ceccd7df-c372-4b49-b070-16bd57ee2456") },
                    { new Guid("510a609d-3265-4e27-869e-cff4e1b04375"), "Answer 1.1", new Guid("dce9f771-8f51-4af8-978b-3965db3915f9") },
                    { new Guid("5ee7d78d-7dd7-4d7d-8fcb-e8d296694ced"), "Answer 0.1", new Guid("86febca3-d570-4f62-9c3c-30ac7a59e20f") },
                    { new Guid("61b3420c-b461-439e-81de-082814549512"), "Answer 4.2", new Guid("ceccd7df-c372-4b49-b070-16bd57ee2456") },
                    { new Guid("78bcbca8-7642-4327-a104-1d66e5a05cee"), "Answer 1.3", new Guid("dce9f771-8f51-4af8-978b-3965db3915f9") },
                    { new Guid("83010695-7111-496b-beb4-306041bec52e"), "Answer 2.3", new Guid("4312cf57-cd63-4589-a2ea-b5a1a8187b13") },
                    { new Guid("8441ea01-7beb-47b5-aefe-3dea556518e8"), "Answer 1.2", new Guid("dce9f771-8f51-4af8-978b-3965db3915f9") },
                    { new Guid("90498de7-3bb0-4efa-9bef-ad246a530660"), "Answer 3.2", new Guid("20d6e3d8-c6f1-4fc9-8c05-3276007d2f40") },
                    { new Guid("b8a58d9c-c958-43d8-a17e-e06270c8e198"), "Answer 4.6", new Guid("ceccd7df-c372-4b49-b070-16bd57ee2456") },
                    { new Guid("d52be4b1-71b8-434f-b3f5-fc8625f74790"), "Answer 3.1", new Guid("20d6e3d8-c6f1-4fc9-8c05-3276007d2f40") },
                    { new Guid("d787233d-b977-44d1-91f4-3a3445307991"), "Answer 3.4", new Guid("20d6e3d8-c6f1-4fc9-8c05-3276007d2f40") },
                    { new Guid("ded73cc1-a337-435a-b35c-c1be52d58a09"), "Answer 4.4", new Guid("ceccd7df-c372-4b49-b070-16bd57ee2456") },
                    { new Guid("e92f8d3d-992d-4ea6-a568-9b445b843dd7"), "Answer 0.4", new Guid("86febca3-d570-4f62-9c3c-30ac7a59e20f") },
                    { new Guid("ebfb590a-90be-4039-84c3-1a8655ef9ec1"), "Answer 4.1", new Guid("ceccd7df-c372-4b49-b070-16bd57ee2456") },
                    { new Guid("f8f8828b-6891-40c9-ad40-e18ba9e68f68"), "Answer 0.3", new Guid("86febca3-d570-4f62-9c3c-30ac7a59e20f") }
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
