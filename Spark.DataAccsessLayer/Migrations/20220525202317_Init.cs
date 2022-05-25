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
                    { new Guid("00985a58-2d37-4304-b520-b4b5cee5c11a"), "What is your favorite food?" },
                    { new Guid("40290278-f7bf-4e13-9003-07c1b0731741"), "What is your favorite movie?" },
                    { new Guid("469f9fa7-889d-4a4b-b21a-be66807d9861"), "What is your favorite movie?" },
                    { new Guid("71e715dd-294e-458b-93a5-0ad12ed8044b"), "What is your favorite animal?" },
                    { new Guid("84ca6e94-cc18-430f-ab57-3313f40d8c92"), "What is your favorite TV show?" },
                    { new Guid("95296126-ae3a-406d-8a0b-cf6019aef809"), "What is your favorite color?" },
                    { new Guid("c3338318-928f-4858-8546-8db58e6cb8ea"), "What is your favorite sport?" },
                    { new Guid("d3ddb989-6a91-48f2-96ac-f39896f81252"), "What is your favorite book?" },
                    { new Guid("eb64981e-8aa9-445e-9deb-ba3018e98bc7"), "What is your favorite book?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0cb4adc2-47a4-4bbc-8008-52e5c9e57ed8"), (short)33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Watson@msdn.org.uk", "Man", true, false, false, "Mohamed", -40.0, 62.0, "Ellie", "123456", "01440-376040", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f8e5df0-58da-438c-beff-98893994bf9d"), (short)54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thomas.Obrien@taobao.org", "Woman", true, false, false, "Whelan", 32.0, -87.0, "Benjamin", "123456", "01307-146601", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1920e329-46f7-4fcc-b07e-ed75ecfb029c"), (short)42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert.Mclean@linkedin.co", "Man", true, false, false, "Seymour", 15.0, -161.0, "Lauren", "123456", "01366-997867", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19e6034e-b5de-476e-81fc-d597c16351aa"), (short)50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel.Hooper@arstechnica.com", "Man", true, false, false, "Wyatt", 44.0, -126.0, "Mackenzie", "123456", "01690-692791", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19ebfd82-8e11-4844-918c-06b086dbf70a"), (short)28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.Whitehouse@adamriddick.net", "Man", true, false, false, "Thorne", -87.0, 125.0, "Lauren", "123456", "01468-582675", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1a80654a-ad7b-4ac4-9741-86cdb88f77af"), (short)52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Mcgrath@adamriddick.info", "Woman", true, false, false, "Green", 40.0, -62.0, "Brianna", "123456", "01199-110254", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f2bd9f7-ed54-4aa6-91d9-4171ea9ac5ca"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Seymour@pinterest.info", "Woman", true, false, false, "Williams", -17.0, -113.0, "Ayden", "123456", "01806-547234", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26b55d4b-4c64-4120-aa7d-f7bedd39fb3a"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlotte.Dale@maplin.co.uk", "Woman", true, false, false, "Sinclair", 20.0, -101.0, "Paul", "123456", "01841-081191", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("32bce425-f6c6-4b2c-aecd-028b8a041ca8"), (short)27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Shepherd@qq.net", "Woman", true, false, false, "Thorne", 31.0, 135.0, "Connor", "123456", "01376-624141", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("32c2d5d7-cad9-451c-9b25-ac6fcb5cf3eb"), (short)48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aaron.Abbott@wikia.org.uk", "Man", true, false, false, "Sanders", 88.0, -148.0, "Carson", "123456", "01803-138193", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3451face-8ff6-4b04-864b-4c98b1f45ce2"), (short)58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexander.Hancock@flipkart.net", "Man", true, false, false, "Walker", -85.0, 34.0, "Nicholas", "123456", "01499-318137", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("40acbdcc-3d1f-473d-9533-fc43f01fd731"), (short)42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aubrey.Watson@linkedin.biz", "Man", true, false, false, "Roberts", 76.0, 47.0, "Sarah", "123456", "01911-170208", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44726630-be20-4812-be10-3872cfbc5379"), (short)43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khloe.Smith@cnn.co.uk", "Woman", true, false, false, "Schofield", -77.0, 0.0, "Zoe", "123456", "01070-962121", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("465eb959-d258-42fc-bd1d-cf00d60068e2"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gianna.Boyd@yahoo.co", "Woman", true, false, false, "Taylor", 65.0, 176.0, "Alyssa", "123456", "01349-280824", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("50b46000-38cd-458b-b1a5-550662184692"), (short)27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evelyn.Mclean@maplin.info", "Woman", true, false, false, "Wyatt", 36.0, -7.0, "Brandon", "123456", "01782-719210", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("519eb589-bbcf-4ae3-a63d-e3364b2a5f4f"), (short)56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Perkins@globo.co.uk", "Woman", true, false, false, "Carroll", 19.0, 95.0, "Nicholas", "123456", "01600-482104", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("53a111b8-dcce-4793-bed0-cedf3780f690"), (short)31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "T.Mcgrath@adamriddick.co", "Woman", true, false, false, "Hooper", 10.0, -135.0, "Gabriel", "123456", "01866-318594", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5db53de6-ae6c-4009-ae50-f95d12a2aa73"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John.Thomas@theguardian.co.uk", "Woman", true, false, false, "Cullen", 74.0, 83.0, "Samuel", "123456", "01462-566850", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("600a67ac-3491-4af8-94b2-d24ed2af30b7"), (short)32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Giles@wordpress.com", "Man", true, false, false, "Carroll", 39.0, -5.0, "Piper", "123456", "01584-787218", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("68d30ea0-3ffe-465a-9c08-0c21c962ced2"), (short)48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sydney.Mcgregor@bing.biz", "Man", true, false, false, "Carroll", -50.0, 43.0, "Xavier", "123456", "01399-411849", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6c09b7a6-4897-468e-a391-2372106e08f0"), (short)31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zoey.Jones@bbc.us", "Man", true, false, false, "Chadwick", 60.0, 167.0, "Jack", "123456", "01062-742114", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("708d798e-579e-4667-ad7d-44a6a407a5e6"), (short)55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethan.Roberts@pinterest.us", "Man", true, false, false, "Adam", 19.0, 96.0, "Jason", "123456", "01657-792615", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70bd645e-48e6-4214-b29f-edc54b4fc7a7"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", true, true, false, "Admin", -29.0, -106.0, "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("757fe150-8569-44a5-bc22-624e7bc18d81"), (short)35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noah.Mcgregor@baidu.co", "Man", true, false, false, "Rossi", -61.0, 90.0, "Peyton", "123456", "01705-596717", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("75999361-cbd6-4763-b445-f4db44a8233b"), (short)62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaxon.Jennings@theguardian.org.uk", "Woman", true, false, false, "Thorne", -78.0, 27.0, "Joseph", "123456", "01614-603373", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("83704753-b5ce-4a69-ad9b-7c873bc29469"), (short)55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chloe.Stuart@sohu.net", "Woman", true, false, false, "Summers", 55.0, 40.0, "Stella", "123456", "01674-520853", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("86962058-f0e7-46a1-918f-5ef3453d552d"), (short)63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Brown@yahoo.org", "Man", true, false, false, "Silva", -9.0, 40.0, "Lucas", "123456", "01927-688522", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("93924cb6-3dc7-4727-9768-a320148e33c6"), (short)56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lydia.Briggs@bing.com", "Woman", true, false, false, "Coles", 53.0, -102.0, "Zoe", "123456", "01351-772257", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("98ad2131-b443-47c0-a785-7b0052c24860"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabella.Akhtar@cnn.net", "Man", true, false, false, "Fleming", -54.0, 107.0, "Grace", "123456", "01902-026100", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9cc426e8-e557-48d3-a946-b98548ab921f"), (short)50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tyler.Wyatt@bestbuy.info", "Man", true, false, false, "Davies", 36.0, -174.0, "Aria", "123456", "01849-995055", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a8aa9e65-be67-4588-ab12-032266c544e5"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Jones@ebay.org.uk", "Woman", true, false, false, "Mellor", 53.0, 38.0, "Kaylee", "123456", "01098-779011", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("abf8f9e5-a70b-4dad-9063-abd7de21673d"), (short)27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isaiah.Blair@linkedin.info", "Woman", true, false, false, "Coles", 53.0, -178.0, "Caroline", "123456", "01112-219041", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aedf9f48-0ee4-420a-ba09-3d397122f515"), (short)62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lillian.Thornton@linkedin.info", "Man", true, false, false, "Thomas", -15.0, 129.0, "Easton", "123456", "01443-632459", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Latitude", "Longitude", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("af94fef4-cd13-4f90-a944-8b3bd4c7348d"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Hilton@sohu.biz", "Woman", true, false, false, "Lindsay", -8.0, -38.0, "Joshua", "123456", "01894-233106", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bcbd78fe-5c56-48a4-bbeb-1c3236aa4fe8"), (short)24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angel.Blair@bbc.us", "Woman", true, false, false, "Swift", 42.0, 122.0, "John", "123456", "01059-739726", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c359f541-2f72-43e7-b645-408324a6f328"), (short)54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Weaver@arstechnica.info", "Man", true, false, false, "Robinson", -25.0, -105.0, "Jose", "123456", "01584-356531", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1f88994-e49f-44a1-8117-428d7236b2dc"), (short)60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Jennings@sohu.co", "Man", true, false, false, "Wilson", -58.0, -159.0, "Austin", "123456", "01673-326659", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d74e79e3-66cf-40b0-813f-31a264ab2e9e"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", true, true, false, "Gürbüz", -13.0, -30.0, "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc25a7d1-5527-4de3-83f5-a855940cb4ab"), (short)33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allison.Lord@taobao.com", "Man", true, false, false, "Swift", -43.0, 80.0, "Adrian", "123456", "01626-422061", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2aed22f-3093-4369-a5b0-92f8d17c4b85"), (short)49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R.Wilson@ask.us", "Woman", true, false, false, "Dale", -77.0, 134.0, "Claire", "123456", "01629-866708", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f97ec7bd-8ef2-4aa1-afaa-7ec398bbb14e"), (short)26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Watson@wikia.org", "Man", true, false, false, "Whitehead", 13.0, 51.0, "Paul", "123456", "01030-910329", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fcf7ed8b-833a-4eb8-b6bd-d5f7b24eff29"), (short)18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Obrien@bestbuy.us", "Woman", true, false, false, "Boyd", 87.0, -180.0, "Adrian", "123456", "01767-974745", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("00d16b16-ef35-4b04-bb69-d931ca427eeb"), "Answer 0.4", new Guid("95296126-ae3a-406d-8a0b-cf6019aef809") },
                    { new Guid("173c6387-6983-44ab-8c87-9f5e7bae1317"), "Answer 4.2", new Guid("40290278-f7bf-4e13-9003-07c1b0731741") },
                    { new Guid("29eaf03d-28ea-47b4-b8d8-b09318c2d425"), "Answer 3.2", new Guid("c3338318-928f-4858-8546-8db58e6cb8ea") },
                    { new Guid("38ea646d-5ee4-4db6-985b-b8d47b430923"), "Answer 3.1", new Guid("c3338318-928f-4858-8546-8db58e6cb8ea") },
                    { new Guid("3c312f23-0245-4e1e-ba50-f02f1b65e9d6"), "Answer 0.2", new Guid("95296126-ae3a-406d-8a0b-cf6019aef809") },
                    { new Guid("6279d00f-dc89-41a2-a373-7c5b1753dd43"), "Answer 3.3", new Guid("c3338318-928f-4858-8546-8db58e6cb8ea") },
                    { new Guid("684d9439-1f21-43e1-b1dd-dda882064baa"), "Answer 3.4", new Guid("c3338318-928f-4858-8546-8db58e6cb8ea") },
                    { new Guid("71f02a2b-f5ea-4e31-a440-737df30d203b"), "Answer 0.3", new Guid("95296126-ae3a-406d-8a0b-cf6019aef809") },
                    { new Guid("94e72b46-75ec-4af5-9e5d-004df337825c"), "Answer 0.1", new Guid("95296126-ae3a-406d-8a0b-cf6019aef809") },
                    { new Guid("9c33e492-e1d8-4000-9b21-1e3fbe129a0c"), "Answer 1.2", new Guid("71e715dd-294e-458b-93a5-0ad12ed8044b") },
                    { new Guid("9c5df7e6-4354-4409-a1d2-bfa7c0db4f15"), "Answer 2.2", new Guid("00985a58-2d37-4304-b520-b4b5cee5c11a") },
                    { new Guid("a3892926-caa2-48d3-a732-a0845559e115"), "Answer 4.6", new Guid("40290278-f7bf-4e13-9003-07c1b0731741") },
                    { new Guid("baa29dc2-026a-43dd-b1a1-8bbdcb7675e2"), "Answer 4.3", new Guid("40290278-f7bf-4e13-9003-07c1b0731741") },
                    { new Guid("babae112-8ea9-4a2f-9f19-6ba98cadef9a"), "Answer 4.1", new Guid("40290278-f7bf-4e13-9003-07c1b0731741") },
                    { new Guid("beda1042-f407-4dab-8b3c-119364ad4e32"), "Answer 4.4", new Guid("40290278-f7bf-4e13-9003-07c1b0731741") },
                    { new Guid("c130959b-746d-451b-9ed8-86be86395d13"), "Answer 1.4", new Guid("71e715dd-294e-458b-93a5-0ad12ed8044b") },
                    { new Guid("c50115b7-fe14-4acf-93f6-5598e332a092"), "Answer 2.4", new Guid("00985a58-2d37-4304-b520-b4b5cee5c11a") },
                    { new Guid("c84fd55e-8c07-4a35-b03c-31637a2f24c0"), "Answer 4.5", new Guid("40290278-f7bf-4e13-9003-07c1b0731741") },
                    { new Guid("d985cd0f-d52b-4b7f-83ea-1761633d150a"), "Answer 1.3", new Guid("71e715dd-294e-458b-93a5-0ad12ed8044b") },
                    { new Guid("f100857c-96e8-426c-8b38-97d004bf017d"), "Answer 1.1", new Guid("71e715dd-294e-458b-93a5-0ad12ed8044b") },
                    { new Guid("f9a01387-bd2b-4bb9-a756-08e72b358132"), "Answer 2.1", new Guid("00985a58-2d37-4304-b520-b4b5cee5c11a") },
                    { new Guid("fa72925f-92e8-482c-9af6-8810235aac5b"), "Answer 2.3", new Guid("00985a58-2d37-4304-b520-b4b5cee5c11a") }
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
