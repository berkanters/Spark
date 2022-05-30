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
                    { new Guid("35150207-8bb6-44b4-bf36-ddebc3b906ad"), "What is your favorite book?" },
                    { new Guid("3d558891-b737-4128-96b6-4cbb4c20fa38"), "What is your favorite color?" },
                    { new Guid("5a9d7492-aa63-45fb-a140-67104aae418b"), "What is your favorite animal?" },
                    { new Guid("b6216cd5-1742-4772-b2be-670378a3f8b0"), "What is your favorite TV show?" },
                    { new Guid("c4576fdb-7268-43a0-b164-1c229bc25b0c"), "What is your favorite movie?" },
                    { new Guid("cae01936-f045-4bb8-a504-939024c30f08"), "What is your favorite book?" },
                    { new Guid("ce6ec072-0332-48b7-bfcf-40d07c5fae28"), "What is your favorite movie?" },
                    { new Guid("e35c3200-febd-4528-9012-a3e2b00e9f88"), "What is your favorite food?" },
                    { new Guid("e94c7ea7-baf1-4880-8356-833e5d6288c7"), "What is your favorite sport?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00f635ae-3289-4a8b-926c-c595589cae5b"), 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R.Brown@bet365.org.uk", "Man", true, false, false, "Cassidy", 20.0, -42.0, "Annabelle", "123456", "01505-771198", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("057b7dc7-46b3-4445-b294-6a45fa4be9f6"), 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isaac.Whelan@flipkart.net", "Woman", true, false, false, "Mac", -51.0, -142.0, "Evan", "123456", "01075-233347", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("12d72eed-8e1e-43ac-8e10-05803030b051"), 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Wilson@qq.co", "Woman", true, false, false, "Stuart", 74.0, 138.0, "Victoria", "123456", "01843-667335", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("138a8eb3-d20b-4a43-acac-546819ab28e3"), 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savannah.Mcfarlane@ebay.co.uk", "Man", true, false, false, "Watson", -18.0, -59.0, "Sarah", "123456", "01938-307142", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("15b33b6a-ddaf-42ce-b502-90aeded58ddb"), 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brianna.Joyce@sohu.us", "Man", true, false, false, "Lord", 28.0, -164.0, "Aubree", "123456", "01021-897803", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b999419-da9a-480c-8e79-94d05edf6227"), 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evelyn.Hancock@theguardian.biz", "Man", true, false, false, "Mac", 32.0, 174.0, "Xavier", "123456", "01023-567921", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26a41e27-e8dd-4031-b3b5-3e0c2af11e20"), 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Mcgregor@ebay.co", "Woman", true, false, false, "Jones", -53.0, 95.0, "Grayson", "123456", "01449-182428", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2ec07870-2cb3-4ec6-b3e0-23b07cd4c566"), 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Giles@stackoverflow.co", "Man", true, false, false, "Vaughan", 8.0, -114.0, "Bailey", "123456", "01476-709213", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f2bf069-4233-4550-b5b6-c0e65c988a79"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abigail.Leach@msdn.org.uk", "Woman", true, false, false, "Mcfarlane", 19.0, 139.0, "Chase", "123456", "01931-074889", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c26f46e-970d-4536-9a06-34036f1969be"), 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kylie.Whitehead@arstechnica.org.uk", "Woman", true, false, false, "Fleming", -26.0, 132.0, "Hannah", "123456", "01980-923060", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d55a075-a48b-490f-936d-2277c4e12761"), 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.Carroll@yelp.co.uk", "Man", true, false, false, "Coles", -20.0, -147.0, "Levi", "123456", "01628-987724", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4940d873-32c0-44c3-9c83-fb9d0c98ef39"), 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aubree.Whittaker@paypal.org", "Man", true, false, false, "Walker", 24.0, -92.0, "Aubrey", "123456", "01178-837454", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4f66b4ae-88e8-4e55-a731-a50c48a57ada"), 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Sinclair@google.info", "Woman", true, false, false, "Jackson", 43.0, -84.0, "Ashley", "123456", "01303-899231", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("54cc393b-8ae7-4011-b139-92f7e9e758e1"), 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Thorne@taobao.co.uk", "Woman", true, false, false, "Riddick", -18.0, 138.0, "Ayden", "123456", "01365-558882", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64f15390-9d41-48d5-b5f7-0336f48cc8f5"), 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P.Naylor@studio1337.info", "Man", true, false, false, "Whittaker", -46.0, -107.0, "Luis", "123456", "01662-351410", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ee7dd15-a6ef-4c23-b7f0-2ca45d64861b"), 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aaron.Mann@wikipedia.co.uk", "Woman", true, false, false, "Blair", 52.0, -76.0, "Isaiah", "123456", "01701-699402", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7631836f-83d1-4647-9f04-95340b18be0f"), 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sydney.Giles@expedia.co.uk", "Man", true, false, false, "Burrows", -55.0, -99.0, "Matthew", "123456", "01152-686470", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80e9ccc0-a567-4e8d-9ce0-6e21b02aeb09"), 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Nelson@wikipedia.net", "Man", true, false, false, "Welch", -65.0, -37.0, "Robert", "123456", "01118-087007", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8f4b67c7-586d-4d78-bd41-5d4b5cb1dfbb"), 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noah.Thornton@wordpress.us", "Man", true, false, false, "Briggs", -85.0, -71.0, "Nathan", "123456", "01406-439160", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("952f793c-5475-4b5b-9691-e4a3806a5c6d"), 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel.Sanders@bing.info", "Woman", true, false, false, "Green", -82.0, -162.0, "Sophie", "123456", "01569-365265", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a2d2194-5d3a-462d-b235-1fe995361d64"), 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brianna.Barlow@globo.co", "Woman", true, false, false, "Mcfarlane", 57.0, -29.0, "Dylan", "123456", "01514-082291", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b6cdeec-5a2a-428a-a896-4f0b577184ad"), 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kimberly.Harris@etsy.info", "Woman", true, false, false, "Mcgrath", -45.0, 43.0, "Hudson", "123456", "01194-233712", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a7be8a16-ff8d-45e9-aa32-172d35ad7152"), 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Thornton@youtube.org", "Man", true, false, false, "Brown", 89.0, 159.0, "Michael", "123456", "01524-367158", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("afb574a0-d812-42d5-9ff7-6d443aa133a4"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", true, true, false, "Admin", -64.0, 79.0, "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b02b80c4-cb71-4144-aecf-633b4774e78d"), 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Rossi@maplin.org", "Woman", true, false, false, "Watson", 2.0, 124.0, "Cooper", "123456", "01264-202726", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3b4320a-6928-44c1-9ffd-c28672285c4c"), 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Taylor@amazon.org", "Man", true, false, false, "Peters", 61.0, -51.0, "Carter", "123456", "01150-106438", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3d07448-0777-4973-bc92-23170c596a79"), 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", true, true, false, "Gürbüz", 83.0, 59.0, "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6b2bdfe-7e43-4ba2-b818-790c01dd75c8"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blake.Williams@sohu.co.uk", "Woman", true, false, false, "Riddick", -79.0, -121.0, "Joshua", "123456", "01631-601013", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c34dd59e-b9bd-4621-aff1-9260010b324e"), 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Coles@msdn.org.uk", "Woman", true, false, false, "Riddick", -17.0, 167.0, "Jack", "123456", "01490-439342", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4e7fe8a-d80d-42c0-9f79-39685d7cdc20"), 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Audrey.Bradshaw@yahoo.org", "Woman", true, false, false, "Little", -41.0, -139.0, "Brianna", "123456", "01121-729133", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6dc6e91-a840-4d12-ab5c-fb9d973dc330"), 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "K.Lewis@etsy.biz", "Man", true, false, false, "Mclean", -24.0, -134.0, "Dylan", "123456", "01658-923130", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9fd2f3f-b9a8-4750-86ca-3df27fd1b01f"), 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Wyatt@sky.biz", "Woman", true, false, false, "White", 69.0, 5.0, "Landon", "123456", "01757-685878", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d87b34b0-c74c-4f7c-afc0-f8421312cee0"), 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hunter.Hilton@qq.net", "Man", true, false, false, "Johnson", 54.0, -17.0, "Hunter", "123456", "01212-367758", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("df263d1f-e30b-49f8-85aa-60e3791ae273"), 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I.Joyce@gmail.biz", "Man", true, false, false, "Welch", 61.0, -54.0, "Avery", "123456", "01523-591807", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec42338e-4894-425f-b7b0-cd5b52e0215a"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lily.Riddick@bestbuy.co", "Woman", true, false, false, "Hooper", 77.0, -113.0, "Abigail", "123456", "01025-398880", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ed885008-9b16-4286-aaf1-152bae2d269b"), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Whitehouse@cnn.net", "Man", true, false, false, "Mac", 83.0, 170.0, "Liam", "123456", "01820-135419", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ede5a860-5c1f-48ee-9d7c-581eed9266df"), 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kennedy.Schofield@sohu.co", "Woman", true, false, false, "Roberts", 21.0, 141.0, "Grayson", "123456", "01855-939293", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f0250c04-4360-4782-bfc3-d9aa312da662"), 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christian.Hancock@yelp.biz", "Woman", true, false, false, "Evans", 20.0, -147.0, "Angel", "123456", "01675-815696", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1ff360e-e84a-4222-9c7e-bcafd7599eb2"), 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Mohamed@adamriddick.org.uk", "Man", true, false, false, "Nash", -51.0, -154.0, "Mason", "123456", "01444-287024", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f358b354-d421-4e1b-b63f-207598590d0f"), 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Blair@paypal.biz", "Woman", true, false, false, "Summers", 12.0, 175.0, "Luis", "123456", "01163-223783", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f51b84e5-de89-4a04-8e61-42311d028a0b"), 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Summers@baidu.biz", "Man", true, false, false, "Leach", 6.0, 157.0, "Addison", "123456", "01858-088800", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fea10494-50f1-49e8-8eb5-cf7a16f03bf1"), 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlett.Green@arstechnica.co", "Man", true, false, false, "Thornton", -22.0, 131.0, "Sophia", "123456", "01917-087665", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("1a2b318e-ad68-45b3-ae4e-cee11d7cb743"), "Answer 1.2", new Guid("5a9d7492-aa63-45fb-a140-67104aae418b") },
                    { new Guid("1e334880-30a6-4319-b5fd-ff8a24cb4c84"), "Answer 0.2", new Guid("3d558891-b737-4128-96b6-4cbb4c20fa38") },
                    { new Guid("38e1874b-2ae7-48ab-b3f3-1c04b639849f"), "Answer 0.4", new Guid("3d558891-b737-4128-96b6-4cbb4c20fa38") },
                    { new Guid("4b0cc8e7-223e-4652-9ea4-bc96a38524e3"), "Answer 4.5", new Guid("c4576fdb-7268-43a0-b164-1c229bc25b0c") },
                    { new Guid("5256c7f9-5153-484c-b4fb-523dcf2c7c13"), "Answer 2.1", new Guid("e35c3200-febd-4528-9012-a3e2b00e9f88") },
                    { new Guid("615964c4-a68a-4ca4-9f15-a7d1cf34ad07"), "Answer 1.3", new Guid("5a9d7492-aa63-45fb-a140-67104aae418b") },
                    { new Guid("6e258357-b99b-4065-b976-e602411e2124"), "Answer 4.6", new Guid("c4576fdb-7268-43a0-b164-1c229bc25b0c") },
                    { new Guid("6f2038cc-aa94-4ffa-a6f5-6a2cba8b0938"), "Answer 3.1", new Guid("e94c7ea7-baf1-4880-8356-833e5d6288c7") },
                    { new Guid("71ee6d24-6875-4fa3-93da-ae7eba3f6c49"), "Answer 2.4", new Guid("e35c3200-febd-4528-9012-a3e2b00e9f88") },
                    { new Guid("8c889d30-5a34-4c65-b277-337580f8bbd3"), "Answer 3.2", new Guid("e94c7ea7-baf1-4880-8356-833e5d6288c7") },
                    { new Guid("a3aeadf1-8337-4e4d-b944-01fa4750a845"), "Answer 2.2", new Guid("e35c3200-febd-4528-9012-a3e2b00e9f88") },
                    { new Guid("a55c7af2-cd62-4d8f-b25b-033ca0602bf7"), "Answer 1.4", new Guid("5a9d7492-aa63-45fb-a140-67104aae418b") },
                    { new Guid("b6ea01bf-afa2-4afd-827e-5b47ced51286"), "Answer 2.3", new Guid("e35c3200-febd-4528-9012-a3e2b00e9f88") },
                    { new Guid("c38930cc-3c59-46ac-af5c-239997ae1cdf"), "Answer 4.3", new Guid("c4576fdb-7268-43a0-b164-1c229bc25b0c") },
                    { new Guid("d08a6705-c027-4e39-bf25-915dc8da326d"), "Answer 3.3", new Guid("e94c7ea7-baf1-4880-8356-833e5d6288c7") },
                    { new Guid("e6036f80-60b0-48eb-91fb-0288f8134e5a"), "Answer 4.4", new Guid("c4576fdb-7268-43a0-b164-1c229bc25b0c") },
                    { new Guid("e78f09b4-dd0c-4abb-81f4-9fc3366afd92"), "Answer 0.3", new Guid("3d558891-b737-4128-96b6-4cbb4c20fa38") },
                    { new Guid("e834fcfa-95fb-46a2-bbe0-7b5ee7ab9728"), "Answer 0.1", new Guid("3d558891-b737-4128-96b6-4cbb4c20fa38") },
                    { new Guid("f56d0dca-aa6b-4a12-a884-769d6a6d31b4"), "Answer 4.2", new Guid("c4576fdb-7268-43a0-b164-1c229bc25b0c") },
                    { new Guid("f9e9cc8e-fc86-4b6e-bf88-0570e3b58be3"), "Answer 3.4", new Guid("e94c7ea7-baf1-4880-8356-833e5d6288c7") },
                    { new Guid("fac2430c-0577-43e8-9572-a37af70095fd"), "Answer 1.1", new Guid("5a9d7492-aa63-45fb-a140-67104aae418b") },
                    { new Guid("fcf39aad-1988-425f-b6b6-aaa3de34a3e4"), "Answer 4.1", new Guid("c4576fdb-7268-43a0-b164-1c229bc25b0c") }
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
