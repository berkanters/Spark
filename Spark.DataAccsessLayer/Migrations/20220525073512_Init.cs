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
                    { new Guid("54145deb-76bf-4908-ae1e-467afa6c22a4"), "What is your favorite book?" },
                    { new Guid("7e180b35-4b90-41b4-8250-f39270a648e2"), "What is your favorite animal?" },
                    { new Guid("87ea7ab2-e69a-4227-afbd-c71bf7bdc143"), "What is your favorite TV show?" },
                    { new Guid("b5a88634-d209-41cb-9aa6-466290b5d2e4"), "What is your favorite movie?" },
                    { new Guid("b6222443-5296-4699-ae39-b9ff8270b96e"), "What is your favorite color?" },
                    { new Guid("edeccd3d-90fb-4d78-b7fd-fcfa341eff18"), "What is your favorite sport?" },
                    { new Guid("f142e944-f396-4cc0-8566-42588ee8fc00"), "What is your favorite book?" },
                    { new Guid("f29c6a5d-c417-4a2c-9562-dec2af3f461b"), "What is your favorite food?" },
                    { new Guid("fcca64fb-15bb-4981-b76f-2b12f48b968f"), "What is your favorite movie?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("07272899-7597-4a45-a73d-c84f0a301bff"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", true, true, false, "Admin", "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0797d602-d9f4-4726-9989-f8bcfbb0e361"), (short)44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "William.Mac@etsy.com", "Woman", true, false, false, "Silva", "Lauren", "123456", "01946-807445", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("085b49d1-182f-4fbf-be12-b1996e744096"), (short)53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evelyn.Bradshaw@ebay.org", "Man", true, false, false, "Carroll", "Kayden", "123456", "01205-050444", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0a6e136d-a9ca-42d2-8c09-dcc472d1bf3c"), (short)60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z.Mellor@wikia.us", "Woman", true, false, false, "Kenny", "Riley", "123456", "01526-404599", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0ac7a3d6-cf2b-482f-a96b-875e39b9a45c"), (short)37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Wyatt@lego.com", "Woman", true, false, false, "Hilton", "Hunter", "123456", "01726-286525", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f2983f3-3fc9-441f-b8c9-c38ce9d3a949"), (short)42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chloe.Wilson@flipkart.co.uk", "Man", true, false, false, "Wilson", "Evelyn", "123456", "01262-142766", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1190ca82-e738-4915-9276-a38f79491fcf"), (short)22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Hilton@theguardian.co.uk", "Man", true, false, false, "Weaver", "Mia", "123456", "01881-955313", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("137746de-8bac-44ae-adf6-95b2db56cdf3"), (short)51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z.Summers@lego.co.uk", "Woman", true, false, false, "Osborne", "Cameron", "123456", "01571-450129", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("14b1b425-69bc-4e3b-9018-7be92650b2f9"), (short)62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Dale@yahoo.com", "Man", true, false, false, "Lord", "Natalie", "123456", "01483-384691", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("15fde5fc-1667-457d-8d16-f79b0a3e7279"), (short)64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faith.Harris@qq.com", "Woman", true, false, false, "Walker", "Scott", "123456", "01267-226284", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ab0e397-92ce-4ac9-b1d1-e36c84977dda"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Skylar.Wilson@stackoverflow.co", "Woman", true, false, false, "Robinson", "Nolan", "123456", "01100-206174", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1d982e0b-c407-4808-bdd5-484025b50380"), (short)58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "T.Burrows@gmail.info", "Woman", true, false, false, "Obrien", "Ryder", "123456", "01783-225243", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22322d41-07c5-4065-acc9-6a78d13ac9db"), (short)34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Kenny@yelp.info", "Woman", true, false, false, "Mclean", "Eli", "123456", "01664-253068", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("304f9a9f-e998-472d-8e74-a8cf7fa45556"), (short)31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Perkins@arstechnica.com", "Man", true, false, false, "Welch", "Skylar", "123456", "01175-692716", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("30623352-1a75-4e4a-9856-39966c596a96"), (short)29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cooper.Williams@etsy.org.uk", "Woman", true, false, false, "Thornton", "Robert", "123456", "01106-142125", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("387d6984-a33d-4289-b49f-edf16b3c44f0"), (short)46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scott.Chadwick@deviantart.biz", "Woman", true, false, false, "Mcgregor", "Bailey", "123456", "01304-463917", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("56920940-97a4-40a7-8dd6-9b0f5bf2ea65"), (short)42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Williams@bestbuy.biz", "Man", true, false, false, "Stuart", "Benjamin", "123456", "01881-812156", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f39aaee-3fc8-4bab-9f49-bbb401cd3f13"), (short)46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Chadwick@live.org.uk", "Man", true, false, false, "Obrien", "Caroline", "123456", "01736-576355", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("611660f6-70a1-4208-a7af-281c2d08f78c"), (short)45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Mclean@deviantart.biz", "Man", true, false, false, "Lord", "Kylie", "123456", "01255-413564", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6e48fa3c-0eda-43ef-987a-2c71737e017a"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I.Schofield@paypal.co", "Man", true, false, false, "Watson", "Wyatt", "123456", "01172-373803", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("760588f8-acaa-4ea9-a375-3ce3d31c5d51"), (short)31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Mann@etsy.us", "Woman", true, false, false, "Sanders", "Madison", "123456", "01341-859839", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a9efc08-0245-4519-a5b3-660e30d39d93"), (short)29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Peters@flipkart.co.uk", "Man", true, false, false, "Haines", "Jaxon", "123456", "01137-792705", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ec01830-8133-4369-a77f-66272d838fda"), (short)63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Adam@globo.com", "Man", true, false, false, "Sanders", "Autumn", "123456", "01918-770597", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8e97b84c-d6f3-41bf-bcd0-2a472766ed98"), (short)19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Lindsay@pinterest.co.uk", "Man", true, false, false, "Johnson", "Blake", "123456", "01091-264980", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8f9ad609-09fd-4643-9834-0ca71c4174aa"), (short)53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Joyce@msdn.co", "Man", true, false, false, "Haines", "Allison", "123456", "01700-728115", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9662d609-d92c-4f5c-a357-ed705eb2c697"), (short)42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julian.Riddick@etsy.com", "Woman", true, false, false, "Wyatt", "Alexis", "123456", "01161-989411", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("99a9cd11-a163-441b-9791-e6e531af1380"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Lindsay@google.biz", "Woman", true, false, false, "Chadwick", "David", "123456", "01218-917725", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9e0576ae-bef3-4bd6-b399-3fa7841b34b7"), (short)48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Thornton@youtube.net", "Man", true, false, false, "Osborne", "Isaac", "123456", "01269-968969", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("af11174f-81aa-48b8-a523-e7619e51d8c0"), (short)49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X.Schofield@sky.org", "Woman", true, false, false, "Weaver", "Ella", "123456", "01819-051293", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b468cdc2-0aef-4ae3-9236-e0e3749ebd91"), (short)23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian.Jackson@qq.us", "Woman", true, false, false, "Walters", "Morgan", "123456", "01960-065326", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b706b5ad-ee11-41c4-ac16-c9b7d66de3ed"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Baldwin@taobao.org.uk", "Woman", true, false, false, "Cullen", "Nolan", "123456", "01018-414246", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d384c4f0-911d-4089-8775-1ecddf07a7de"), (short)26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victoria.Sinclair@etsy.co.uk", "Man", true, false, false, "Blair", "Arianna", "123456", "01519-524345", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d93cb362-fdb0-4b47-9949-839edde5a4d6"), (short)50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faith.Seymour@globo.com", "Man", true, false, false, "Watson", "Layla", "123456", "01577-690193", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("e00a426c-8535-4512-a301-733c228fe167"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan.Mcgregor@linkedin.co.uk", "Man", true, false, false, "Welch", "Harper", "123456", "01623-298344", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e53ff7e4-b7bc-4d2e-90e9-614d9b75bb1f"), (short)24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lily.Kenny@live.com", "Woman", true, false, false, "Wright", "Jaxon", "123456", "01952-517532", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec39c5dc-e97d-4591-8f98-4cba41579dc1"), (short)28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caroline.Welch@stackoverflow.org.uk", "Man", true, false, false, "Adam", "Allison", "123456", "01932-587125", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec680d37-3c78-4597-959a-826ccbe5cd75"), (short)63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Thorne@arstechnica.biz", "Man", true, false, false, "Peters", "Kimberly", "123456", "01031-820443", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f293b8e4-ff8a-4126-b9c0-a60d8767efd3"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", true, true, false, "Gürbüz", "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6bee0ca-1a57-409a-8901-b02a92af64b6"), (short)63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Johnson@163.com", "Man", true, false, false, "Watson", "Makayla", "123456", "01235-792492", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6e31308-ecd5-406e-8eed-b5f900b35c8f"), (short)18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Barlow@bing.net", "Woman", true, false, false, "Weaver", "Alexis", "123456", "01357-271383", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9b6aee7-06c0-4b7b-a2f2-55a34d92e6ac"), (short)36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stella.Swift@theguardian.us", "Woman", true, false, false, "Thornton", "Tyler", "123456", "01162-725662", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc8732b9-7ebd-464d-b208-bfff84a637c0"), (short)26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinity.Abbott@linkedin.net", "Woman", true, false, false, "Brown", "Kimberly", "123456", "01751-055816", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("0145dd3c-575a-40d6-a39d-a16a9eba290f"), "Answer 4.4", new Guid("b5a88634-d209-41cb-9aa6-466290b5d2e4") },
                    { new Guid("07dfd529-f4d8-4bf6-9045-b43b053deb32"), "Answer 1.2", new Guid("7e180b35-4b90-41b4-8250-f39270a648e2") },
                    { new Guid("0a492e4d-349a-4eb3-983c-51a2299ee72c"), "Answer 4.1", new Guid("b5a88634-d209-41cb-9aa6-466290b5d2e4") },
                    { new Guid("114a4d61-8c68-4f3e-b06d-4f110269a4fe"), "Answer 2.4", new Guid("f29c6a5d-c417-4a2c-9562-dec2af3f461b") },
                    { new Guid("191f53a3-3715-492e-84f0-b5f629e8c7a3"), "Answer 1.1", new Guid("7e180b35-4b90-41b4-8250-f39270a648e2") },
                    { new Guid("1f5b3a24-6bfd-4779-80b4-b3bd368211ed"), "Answer 4.3", new Guid("b5a88634-d209-41cb-9aa6-466290b5d2e4") },
                    { new Guid("2753da9c-06e6-495e-97f0-6832ea3cd79b"), "Answer 1.3", new Guid("7e180b35-4b90-41b4-8250-f39270a648e2") },
                    { new Guid("868c8dc0-8614-415f-8f21-50e393d068ff"), "Answer 2.3", new Guid("f29c6a5d-c417-4a2c-9562-dec2af3f461b") },
                    { new Guid("8ef41893-60a0-43ea-adb5-4db6c095d9af"), "Answer 4.5", new Guid("b5a88634-d209-41cb-9aa6-466290b5d2e4") },
                    { new Guid("91116e78-8fa1-4d25-8d2d-1d062b0ba07c"), "Answer 1.4", new Guid("7e180b35-4b90-41b4-8250-f39270a648e2") },
                    { new Guid("98b6a762-1cf0-4ecb-858e-4e63ad1da857"), "Answer 3.4", new Guid("edeccd3d-90fb-4d78-b7fd-fcfa341eff18") },
                    { new Guid("9fec29ad-1ef4-4344-929a-e2bf4f177372"), "Answer 4.2", new Guid("b5a88634-d209-41cb-9aa6-466290b5d2e4") },
                    { new Guid("b1a1709d-3527-4134-990d-7333b451878d"), "Answer 0.1", new Guid("b6222443-5296-4699-ae39-b9ff8270b96e") },
                    { new Guid("bd5dec57-7d87-49bd-8f33-86a4a5916c97"), "Answer 3.1", new Guid("edeccd3d-90fb-4d78-b7fd-fcfa341eff18") },
                    { new Guid("c7367061-ce34-499d-b3aa-7bbb57635339"), "Answer 4.6", new Guid("b5a88634-d209-41cb-9aa6-466290b5d2e4") },
                    { new Guid("ce4490d6-f803-4501-a36c-d4b305c6e51d"), "Answer 0.2", new Guid("b6222443-5296-4699-ae39-b9ff8270b96e") },
                    { new Guid("d45e560a-3265-4462-bea5-8b1b7127c972"), "Answer 2.2", new Guid("f29c6a5d-c417-4a2c-9562-dec2af3f461b") },
                    { new Guid("d5cb4d38-8b5f-4940-b3ec-b4c0034206cc"), "Answer 0.4", new Guid("b6222443-5296-4699-ae39-b9ff8270b96e") },
                    { new Guid("df56b7cf-7ce8-4820-99cf-3b78f5baa262"), "Answer 2.1", new Guid("f29c6a5d-c417-4a2c-9562-dec2af3f461b") },
                    { new Guid("f2b2de69-18f1-459d-9e2e-7eb5d91c234f"), "Answer 3.3", new Guid("edeccd3d-90fb-4d78-b7fd-fcfa341eff18") },
                    { new Guid("f84d507a-bbac-4e76-b3d7-641d64b1cc09"), "Answer 3.2", new Guid("edeccd3d-90fb-4d78-b7fd-fcfa341eff18") },
                    { new Guid("fbcfd830-903b-40a2-8aa2-92c4537723e1"), "Answer 0.3", new Guid("b6222443-5296-4699-ae39-b9ff8270b96e") }
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
