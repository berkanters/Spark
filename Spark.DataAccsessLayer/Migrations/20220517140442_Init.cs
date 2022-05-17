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
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02c54e10-d31f-42c3-aeca-27b7e7dee195"), (short)60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Abbott@lego.com", "Woman", true, false, false, "Harris", "Jason", "123456", "01468-491255", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("04827000-da8e-4983-bf69-511aee5eda28"), (short)42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Mohamed@yahoo.info", "Man", true, false, false, "Davies", "Aubrey", "123456", "01915-730836", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("068b5a92-63cd-4d8b-83fe-f46cd0a2d1d7"), (short)40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aiden.Wyatt@bestbuy.co", "Man", true, false, false, "Davies", "Ellie", "123456", "01916-293345", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("128c08eb-cf81-4759-bdbd-cf8f791fc6b8"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.Mcgrath@maplin.net", "Woman", true, false, false, "Osborne", "Elijah", "123456", "01337-326357", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("154c5ed7-08ec-4a8b-ac44-1c13a6a1dc62"), (short)26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Sanders@techcrunch.biz", "Woman", true, false, false, "Hooper", "Landon", "123456", "01289-404046", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2217ebbc-c1db-4b4c-abe2-f696ba4b07e9"), (short)63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul.Whittaker@paypal.com", "Woman", true, false, false, "Seymour", "Mackenzie", "123456", "01883-106232", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("242c3e8c-93a5-4e55-a463-4ea7b48c7647"), (short)40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Wilson@yahoo.org", "Man", true, false, false, "Thompson", "Matthew", "123456", "01859-063227", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e504fff-9a7f-4961-9cf5-c078d06b7cc8"), (short)37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claire.Power@microsoft.com", "Woman", true, false, false, "Abbott", "Daniel", "123456", "01508-857626", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f9f90e1-9f80-4b5a-952c-1b50c3487410"), (short)53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peyton.Sanders@expedia.info", "Man", true, false, false, "Obrien", "Damian", "123456", "01175-682114", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("30307393-cda5-4f90-93dc-c61c0cd80e05"), (short)45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandra.Wyatt@stackoverflow.org.uk", "Man", true, false, false, "Harris", "Julian", "123456", "01745-589943", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("347415f3-4b41-494f-a186-2697caaf6a30"), (short)18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hannah.Power@microsoft.org.uk", "Woman", true, false, false, "Smith", "Carlos", "123456", "01184-603182", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("388ab130-196f-4412-acd0-efe270f4ed7d"), (short)50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael.Nash@arstechnica.co.uk", "Woman", true, false, false, "Schofield", "Jason", "123456", "01802-396118", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e896de8-e49a-4449-a155-f59e170441ae"), (short)52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khloe.White@wikipedia.net", "Woman", true, false, false, "Naylor", "Tyler", "123456", "01768-123554", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4047bef2-0e39-4916-8032-6eba0a1bafd6"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.Green@paypal.info", "Woman", true, false, false, "Wright", "Molly", "123456", "01978-453353", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("441803c1-0a5d-47ca-a7c2-dc7b1d0bbafc"), (short)64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Wright@ebay.org", "Man", true, false, false, "Burrows", "Isaiah", "123456", "01934-076842", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4575210c-c311-40ce-8057-e15a93712065"), (short)18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.Mcfarlane@wikia.co.uk", "Woman", true, false, false, "Akhtar", "Owen", "123456", "01057-302785", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a3e85e8-c004-4827-b1f7-40a1589f8bdc"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I.Giles@ebay.us", "Woman", true, false, false, "Kenny", "Joseph", "123456", "01560-717975", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f6710e6-64cd-4ab8-a254-50ecbdbd0c37"), (short)23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Owen.Jones@expedia.us", "Man", true, false, false, "Perkins", "Dylan", "123456", "01207-578913", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74f7da53-a727-465e-a7c5-d517e5fc195f"), (short)43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Johnson@wikipedia.org.uk", "Woman", true, false, false, "Mcgrath", "Brayden", "123456", "01797-217784", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("881e8867-fa27-4872-844c-4d4353f65b3b"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Swift@msdn.info", "Man", true, false, false, "Carroll", "Evelyn", "123456", "01602-059644", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8954f994-d5f5-4489-810b-38f64b00f990"), (short)23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hannah.Whittaker@stackoverflow.co", "Man", true, false, false, "Rossi", "Alexis", "123456", "01925-536470", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89c23e54-ba13-4c2f-813d-51d0ccaf549b"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", true, true, false, "Gürbüz", "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8f2ce7c1-b5c7-4c86-b4d4-b68e2bc75cab"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", true, true, false, "Admin", "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9360a155-1880-4a11-b3ea-d35e4e8f17be"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arianna.Cassidy@arstechnica.co", "Woman", true, false, false, "Jackson", "Lauren", "123456", "01998-917985", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("956b86c3-1bc8-4660-a537-d2f221256ddb"), (short)44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hailey.Harris@microsoft.org", "Man", true, false, false, "Hilton", "Bentley", "123456", "01231-856453", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("98cd6ea1-6175-436e-afb8-6d2d8b6a41d7"), (short)46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.White@pinterest.info", "Woman", true, false, false, "Buckley", "Peyton", "123456", "01883-944999", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2b5a808-2c57-41ef-b1af-af7de29af070"), (short)33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kennedy.Davies@deviantart.net", "Man", true, false, false, "Briggs", "Nicholas", "123456", "01525-516059", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3c7405b-7c66-40b4-9c0b-681eba8b982c"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Davies@adamriddick.biz", "Woman", true, false, false, "Whittaker", "Melanie", "123456", "01615-408052", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad8bd1af-60a5-4a65-9785-76d04b6f1911"), (short)31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Buckley@pinterest.org", "Man", true, false, false, "Thomas", "Khloe", "123456", "01826-885125", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2cc4246-f035-40b8-bc83-d7df899b8549"), (short)19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aaron.Peters@studio1337.org.uk", "Man", true, false, false, "Taylor", "Chloe", "123456", "01206-538844", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c034a690-70dd-4c14-8a6f-ebf7b66ade81"), (short)22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noah.Evans@paypal.net", "Woman", true, false, false, "Shepherd", "Luis", "123456", "01805-314536", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc9695af-c611-4a22-bf32-ab1a8b6f6186"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Johnson@wikia.com", "Man", true, false, false, "Walters", "Alexis", "123456", "01870-299437", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cdfa0dbf-580e-4a29-a146-3600426b22d9"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Stuart@sky.com", "Man", true, false, false, "Lindsay", "Brianna", "123456", "01297-430130", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d211e99e-be26-4690-8db2-be9ba53adbf4"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam.Naylor@bet365.co", "Man", true, false, false, "Vaughan", "John", "123456", "01108-555312", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ddeaccf5-dea7-4644-9f4f-daac14e72b63"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piper.Nash@deviantart.com", "Woman", true, false, false, "Thompson", "Nevaeh", "123456", "01688-437045", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e307c70b-8026-4191-b9be-7f465eb4e541"), (short)23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher.Weaver@globo.co", "Woman", true, false, false, "Sanders", "Eva", "123456", "01611-261454", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e463e88c-d02b-422d-a9db-77cab551f110"), (short)31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brody.Walker@expedia.net", "Man", true, false, false, "Davies", "Jeremiah", "123456", "01227-946726", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7fa2bb8-fc04-41d5-a5a6-d200fe3eaabf"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Summers@bbc.org", "Woman", true, false, false, "Haines", "Maya", "123456", "01820-247582", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ef6f055d-4fcd-480a-b479-e23b2290534c"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samantha.Thornton@microsoft.info", "Woman", true, false, false, "Welch", "Connor", "123456", "01406-496343", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6d47b86-2814-43e8-88f8-f6ac276c8881"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aiden.Akhtar@arstechnica.biz", "Man", true, false, false, "Harris", "Elijah", "123456", "01247-421562", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc993459-168c-40b2-8a39-302be5132be5"), (short)58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R.Wyatt@ask.org", "Man", true, false, false, "Cassidy", "Kylie", "123456", "01932-123820", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe505e7f-6811-44cd-b691-a0bf1710915e"), (short)18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Melanie.Savage@wikia.org.uk", "Man", true, false, false, "Whittaker", "Sophie", "123456", "01438-018488", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
