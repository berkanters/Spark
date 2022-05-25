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
                    { new Guid("1dde4d66-3ffa-42de-88c2-a9ff126b6066"), "What is your favorite sport?" },
                    { new Guid("2902e0c4-2081-438a-a986-a14f6c863e77"), "What is your favorite animal?" },
                    { new Guid("32834587-752e-4b1d-9602-7232c9075553"), "What is your favorite movie?" },
                    { new Guid("45faaf3e-d4dd-4c70-9579-594a4206138f"), "What is your favorite book?" },
                    { new Guid("6bd7dbc8-8197-463a-aae7-f3df6ba428b2"), "What is your favorite book?" },
                    { new Guid("94081597-c5c4-4aa1-a99c-44736bb3c922"), "What is your favorite color?" },
                    { new Guid("b749b0a9-4407-4ef9-8239-cd04faa6a248"), "What is your favorite movie?" },
                    { new Guid("b965e349-37b0-4e03-8293-6f1ca323822a"), "What is your favorite food?" },
                    { new Guid("d050709d-10d4-4b16-87ce-2d8c8c2f68f9"), "What is your favorite TV show?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00fa084d-b417-46c4-bc41-b4987d5d6487"), (short)32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Brown@yelp.org", "Woman", true, false, false, "Thorne", 30.0, 38.0, "Sophie", "123456", "01419-240081", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("043c1cc4-ea99-4b0e-af68-d3c7bc9c0612"), (short)30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Williams@baidu.org.uk", "Man", true, false, false, "Lord", 33.0, 94.0, "Stella", "123456", "01121-367289", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("084c3c18-9157-4d09-b662-c8dbffe7361b"), (short)43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Whelan@globo.co.uk", "Woman", true, false, false, "Osborne", 69.0, 116.0, "Allison", "123456", "01388-984464", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("113d7b60-bf66-4aef-baf0-d87bf9b8cbd9"), (short)44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caleb.Thomas@gmail.info", "Man", true, false, false, "Sanders", 50.0, 96.0, "Olivia", "123456", "01703-813658", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20736dcf-3b92-4f9d-a10e-b4e203a3a6e6"), (short)37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lillian.Williams@wikia.us", "Woman", true, false, false, "Giles", 76.0, -61.0, "Owen", "123456", "01660-923731", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3053e5ca-08cf-49f4-a288-710c6f6d611b"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.Wright@youtube.info", "Woman", true, false, false, "Mcfarlane", -57.0, -154.0, "Lucas", "123456", "01848-252336", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("35777337-7216-4ca5-95d6-0e938df1d1c4"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Cassidy@flipkart.us", "Woman", true, false, false, "Lindsay", 50.0, 88.0, "Ethan", "123456", "01189-829372", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("37a2157f-2e2f-4ddf-9124-87f2a5a7c70b"), (short)55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia.Mcgregor@yahoo.co", "Man", true, false, false, "Sanders", 67.0, -53.0, "Violet", "123456", "01106-963832", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("38587627-1718-4082-8b5f-0c9c46c02b37"), (short)34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gianna.Dale@taobao.biz", "Man", true, false, false, "Mcgregor", -45.0, -78.0, "Thomas", "123456", "01315-774167", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f21fea8-c7fc-4742-beb1-8ad6c6b83d6d"), (short)33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Mcfarlane@flipkart.org", "Woman", true, false, false, "Whittaker", 65.0, 41.0, "Christopher", "123456", "01428-389086", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("47581ad2-a770-40e3-a03a-d7751198ec16"), (short)52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Davies@globo.com", "Man", true, false, false, "Mohamed", -65.0, 134.0, "Jonathan", "123456", "01285-503500", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4d0a37bc-29fb-4e29-bf1d-f447c2bdb41f"), (short)58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R.Mohamed@bet365.net", "Man", true, false, false, "Jackson", -87.0, -116.0, "Noah", "123456", "01981-294382", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e16e349-941f-4eff-8b3f-d1676c9b05dc"), (short)41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Cullen@flipkart.net", "Woman", true, false, false, "Evans", -46.0, 94.0, "Jonathan", "123456", "01329-735564", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("510d55f7-a368-47da-9540-5a0673c55bcf"), (short)29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Dale@adamriddick.us", "Man", true, false, false, "Stuart", 79.0, -38.0, "Cameron", "123456", "01424-114763", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("51dcf984-7a07-4e5d-903a-874d89633650"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xavier.Briggs@qq.us", "Woman", true, false, false, "Robinson", -30.0, -154.0, "Scarlett", "123456", "01937-042846", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("686d756c-9c47-46cd-bf3c-d377bdb3d212"), (short)19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natalie.Nash@bet365.com", "Man", true, false, false, "Mcfarlane", 7.0, 44.0, "Adam", "123456", "01621-004380", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("847461be-2710-4deb-9d8d-e6ed1532c9e2"), (short)23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Dale@expedia.biz", "Woman", true, false, false, "Obrien", -27.0, 66.0, "Madison", "123456", "01884-860396", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("962f7cbe-55f5-46be-a7e1-a95608d40fca"), (short)24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Thornton@163.co.uk", "Man", true, false, false, "Whitehead", -74.0, -8.0, "Samantha", "123456", "01409-767230", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("98542833-04d6-41b2-9e1c-e9ca1274d357"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Kenny@lego.us", "Man", true, false, false, "Lord", 28.0, -152.0, "Audrey", "123456", "01572-701932", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2843e31-554d-4b71-8aac-235f348b0832"), (short)37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Layla.Riddick@live.co.uk", "Man", true, false, false, "Mohamed", -77.0, -172.0, "Alexa", "123456", "01425-280097", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3576300-c743-4f97-918b-57a6b8023961"), (short)48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Mellor@etsy.co.uk", "Man", true, false, false, "Taylor", 58.0, 142.0, "Hailey", "123456", "01168-912843", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3a98686-11b0-4579-87df-e7024fa16a4c"), (short)43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z.Osborne@sohu.org", "Woman", true, false, false, "Evans", -87.0, -133.0, "Adrian", "123456", "01714-534245", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a660de14-ec56-4947-af7d-4cb5ec89d912"), (short)31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Cullen@studio1337.co", "Man", true, false, false, "Silva", -27.0, -138.0, "Elizabeth", "123456", "01151-564736", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a6a58589-544c-4a79-b320-c07b2509f279"), (short)31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colton.Power@google.co", "Man", true, false, false, "Boyd", 28.0, 96.0, "Hudson", "123456", "01371-020713", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ace4b381-f035-4910-94d5-3f2b886aedca"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", true, true, false, "Admin", 69.0, -131.0, "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b17f97e7-e4cd-452b-8ca8-715f6ddd9f28"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Whelan@globo.com", "Woman", true, false, false, "Mann", 43.0, -102.0, "Carter", "123456", "01642-224572", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2341a73-ab75-4553-bdc4-6888376c1e83"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Mcgrath@lego.biz", "Woman", true, false, false, "Sanders", -45.0, -38.0, "Emma", "123456", "01619-119360", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b63fe0ee-4b06-4125-8a9d-1d9dfa6e45aa"), (short)62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brooklyn.Summers@wikia.org.uk", "Woman", true, false, false, "Giles", -88.0, 96.0, "Anna", "123456", "01700-469255", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf253cf2-1f27-457c-aa99-90d954af1886"), (short)45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claire.Hooper@expedia.org.uk", "Woman", true, false, false, "Burrows", -71.0, 138.0, "Jack", "123456", "01457-033746", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf59993d-6f02-4785-97f2-9451ff692bf7"), (short)44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel.Sinclair@bbc.co.uk", "Woman", true, false, false, "Whitehouse", 30.0, -79.0, "Bryson", "123456", "01489-776376", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c2f5b021-4793-4f67-9e66-a62b9b3ba6c7"), (short)36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allison.Bradshaw@techcrunch.com", "Woman", true, false, false, "Cullen", 69.0, 8.0, "Alexis", "123456", "01550-250517", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c7569be6-bf07-49ce-94a8-be24cb397881"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "T.Silva@wikipedia.com", "Man", true, false, false, "Stuart", 52.0, 116.0, "Victoria", "123456", "01335-931155", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d143ee2e-c440-496e-a646-fddeef31d8db"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", true, true, false, "Gürbüz", -88.0, 132.0, "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("d6713fda-f09e-4559-b3fe-202aed9ac324"), (short)58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Whelan@cnn.org.uk", "Man", true, false, false, "Mcgregor", -83.0, -5.0, "Lucas", "123456", "01289-474203", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da4cba17-bdc3-4886-b81c-8d6bf1039da6"), (short)64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "T.Bradshaw@bbc.com", "Woman", true, false, false, "Giles", -83.0, 178.0, "Lucy", "123456", "01357-361990", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("deef2f85-a84b-4c9e-a295-848bdd80e2ab"), (short)54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Kenny@amazon.com", "Man", true, false, false, "Stuart", 71.0, -7.0, "Nolan", "123456", "01865-282217", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3112ed6-68a5-4ac6-ac3b-98d2df7f9f2c"), (short)63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "London.Briggs@stackoverflow.co", "Woman", true, false, false, "Bradshaw", -62.0, -59.0, "Sophia", "123456", "01500-198847", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ea1502b8-b3f3-4912-95fe-cb0816197750"), (short)19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alyssa.Thomas@wikipedia.biz", "Woman", true, false, false, "Sinclair", 77.0, -64.0, "Ryder", "123456", "01930-000488", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("efc77eb0-2ef7-4dd9-b530-fa1cf887a390"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gianna.Baldwin@bing.org.uk", "Man", true, false, false, "Wilson", 71.0, 107.0, "Leah", "123456", "01986-745679", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f281971c-48e7-4017-b90d-ee8badf31d09"), (short)53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Fleming@wikia.co.uk", "Woman", true, false, false, "Green", -70.0, 60.0, "Autumn", "123456", "01040-959601", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8c82586-41f3-41cf-b9f1-3cf979abce80"), (short)45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ella.Naylor@stackoverflow.biz", "Man", true, false, false, "Lord", -17.0, -119.0, "Isaac", "123456", "01305-603658", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb343b72-f483-4aeb-94d5-e397eecc59f5"), (short)55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex.Savage@sky.co", "Man", true, false, false, "Leach", -85.0, -116.0, "Cameron", "123456", "01056-502458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("0aa833d6-8df7-419c-ae3d-b30b156574c0"), "Answer 3.4", new Guid("1dde4d66-3ffa-42de-88c2-a9ff126b6066") },
                    { new Guid("18d46c7d-18b0-4da7-bd59-66d061419307"), "Answer 4.2", new Guid("32834587-752e-4b1d-9602-7232c9075553") },
                    { new Guid("26d07ab0-c129-4bd2-93a5-fcba9f923185"), "Answer 0.3", new Guid("94081597-c5c4-4aa1-a99c-44736bb3c922") },
                    { new Guid("2c71cece-df40-4d5d-b9db-c18b2bded014"), "Answer 4.3", new Guid("32834587-752e-4b1d-9602-7232c9075553") },
                    { new Guid("5724f016-b1af-42ca-92d3-0ff663270d61"), "Answer 1.1", new Guid("2902e0c4-2081-438a-a986-a14f6c863e77") },
                    { new Guid("79091bc5-780c-4e1b-a48c-85266c92888d"), "Answer 1.4", new Guid("2902e0c4-2081-438a-a986-a14f6c863e77") },
                    { new Guid("79550195-c195-42b4-a583-5a8703841a3e"), "Answer 3.3", new Guid("1dde4d66-3ffa-42de-88c2-a9ff126b6066") },
                    { new Guid("804409b1-feeb-48c8-a8c9-f035cd89c66e"), "Answer 4.6", new Guid("32834587-752e-4b1d-9602-7232c9075553") },
                    { new Guid("89a350b9-090f-4926-af2a-0d54d65e2da5"), "Answer 3.2", new Guid("1dde4d66-3ffa-42de-88c2-a9ff126b6066") },
                    { new Guid("92aa45f2-7721-49e8-ae9f-88adf1467cd3"), "Answer 2.1", new Guid("b965e349-37b0-4e03-8293-6f1ca323822a") },
                    { new Guid("98a0785f-f8e5-4e61-a62d-cbc069fc4ed3"), "Answer 4.1", new Guid("32834587-752e-4b1d-9602-7232c9075553") },
                    { new Guid("9d3a22b2-69c6-4e99-95f2-a710ffe9f957"), "Answer 0.2", new Guid("94081597-c5c4-4aa1-a99c-44736bb3c922") },
                    { new Guid("a8da514a-621e-44d7-82bd-3e4def184ec3"), "Answer 4.5", new Guid("32834587-752e-4b1d-9602-7232c9075553") },
                    { new Guid("af524911-5e1c-4c90-869b-53a1abfd744b"), "Answer 3.1", new Guid("1dde4d66-3ffa-42de-88c2-a9ff126b6066") },
                    { new Guid("b14a16c7-6744-422e-8082-c4dcb0e5514e"), "Answer 1.3", new Guid("2902e0c4-2081-438a-a986-a14f6c863e77") },
                    { new Guid("b2897b3c-a54f-4f60-b164-4c3c6d254adb"), "Answer 0.4", new Guid("94081597-c5c4-4aa1-a99c-44736bb3c922") },
                    { new Guid("bb270ce4-3701-4b26-9f70-f58c155fd0b1"), "Answer 2.2", new Guid("b965e349-37b0-4e03-8293-6f1ca323822a") },
                    { new Guid("c203af7a-a9ad-4924-ac89-b79fd19202aa"), "Answer 2.4", new Guid("b965e349-37b0-4e03-8293-6f1ca323822a") },
                    { new Guid("c6b5d6d0-06ec-4184-8917-91b30e2b69e5"), "Answer 4.4", new Guid("32834587-752e-4b1d-9602-7232c9075553") },
                    { new Guid("cdf2d87a-840e-4137-9647-7ad8218780ce"), "Answer 2.3", new Guid("b965e349-37b0-4e03-8293-6f1ca323822a") },
                    { new Guid("f523e407-24ef-48b3-b856-e4d28bf82f03"), "Answer 1.2", new Guid("2902e0c4-2081-438a-a986-a14f6c863e77") },
                    { new Guid("fa54a2b6-8fa1-4418-bdb6-1af196c13884"), "Answer 0.1", new Guid("94081597-c5c4-4aa1-a99c-44736bb3c922") }
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
