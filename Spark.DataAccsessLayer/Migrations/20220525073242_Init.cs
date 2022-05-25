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
                    { new Guid("3d9c3c35-b49b-42f1-8daf-50e5a9b85e49"), "What is your favorite TV show?" },
                    { new Guid("4f3832bd-5cc2-4954-9d30-8b1755c43055"), "What is your favorite book?" },
                    { new Guid("6ae14977-045a-47de-b14d-94e53e1bb972"), "What is your favorite animal?" },
                    { new Guid("79498984-2b27-477e-95a2-b0234deae719"), "What is your favorite food?" },
                    { new Guid("7eda2b79-2cb4-451d-87ad-c6ac3a99edc4"), "What is your favorite color?" },
                    { new Guid("a3baec88-9da7-4d91-9c19-6eb651774236"), "What is your favorite book?" },
                    { new Guid("bb9cfd84-9ddd-4824-aa71-1e1509ccc23f"), "What is your favorite movie?" },
                    { new Guid("bbb97530-6a14-4407-b86d-70371f5f533f"), "What is your favorite sport?" },
                    { new Guid("eef48716-cd6b-4f86-895f-31aaef411982"), "What is your favorite movie?" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01d95066-da58-4590-b117-05b7de551aa2"), (short)26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Carroll@wikipedia.net", "Woman", true, false, false, "Blair", "Jaxon", "123456", "01077-191377", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("03fd2ee4-fc83-4aa9-8960-80a3832a8941"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Davies@bing.org", "Woman", true, false, false, "Walker", "Jace", "123456", "01954-069119", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("075ceb89-5c6e-49b2-996a-85db9fdaf35d"), (short)44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R.Briggs@globo.us", "Woman", true, false, false, "Fleming", "Ellie", "123456", "01373-871442", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("084a374c-5068-4f58-a0fa-2bb63bafb2f1"), (short)54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jace.Chadwick@studio1337.com", "Woman", true, false, false, "Mclean", "Andrew", "123456", "01655-337406", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1085a7a4-6151-479a-ac94-0f2b1bf316c1"), (short)26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z.Giles@lego.com", "Woman", true, false, false, "Power", "Alexis", "123456", "01086-027158", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19ae7f5e-9dbe-44cd-a841-25aed782fd4f"), (short)40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "H.Haines@etsy.biz", "Man", true, false, false, "Hancock", "Caleb", "123456", "01151-731105", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2276e6de-e11a-4847-a77d-a902c66fe2c2"), (short)29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scott.Summers@taobao.co", "Woman", true, false, false, "Blair", "Emma", "123456", "01338-509815", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26f5c70c-43b6-46f7-8f35-e50897767947"), (short)43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z.Swift@live.info", "Man", true, false, false, "Cullen", "Grace", "123456", "01941-384484", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a92ff2d-56dc-4488-9d00-e0e09914aead"), (short)57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Layla.Williams@youtube.co", "Man", true, false, false, "Chadwick", "Daniel", "123456", "01224-994283", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("32e27011-2342-478f-9a34-2cd8e767d36d"), (short)40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R.Taylor@sky.co.uk", "Man", true, false, false, "Welch", "Jacob", "123456", "01559-049807", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("35492d67-9277-439f-a4c3-f9159aff855c"), (short)40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G.Thornton@studio1337.com", "Man", true, false, false, "Leach", "Madison", "123456", "01422-357398", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36544ad4-024a-48af-b912-1375cace7f19"), (short)52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinity.Jackson@baidu.net", "Man", true, false, false, "Taylor", "Jackson", "123456", "01445-049575", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3b5318c3-5e45-4e92-8230-66e203732386"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bentley.Rossi@msdn.net", "Man", true, false, false, "Schofield", "Parker", "123456", "01083-421313", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c76afe0-916c-4a1d-bfd8-ccf731f26228"), (short)34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Thompson@microsoft.biz", "Woman", true, false, false, "Nash", "Makayla", "123456", "01845-723547", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("49162509-0de9-4638-b19f-b8633903ddaf"), (short)38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.Mohamed@baidu.biz", "Man", true, false, false, "Lindsay", "Lucy", "123456", "01168-525580", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c15acb2-9130-4f96-8308-4eabe612fe42"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O.Baldwin@bestbuy.co.uk", "Woman", true, false, false, "Buckley", "Parker", "123456", "01553-790686", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("56360f0d-7ef1-4fb2-a35e-474ee16e795c"), (short)64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Mohamed@yahoo.net", "Woman", true, false, false, "Perkins", "Piper", "123456", "01617-224459", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5d5446df-8ee7-4068-a6f7-f7e148db3fad"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M.Lewis@cnn.org", "Woman", true, false, false, "Adam", "Brianna", "123456", "01035-458748", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("65142a28-31e1-4f64-84c0-1b465b1e7999"), (short)27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Layla.Abbott@msdn.org.uk", "Man", true, false, false, "White", "Brandon", "123456", "01834-311801", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("674a9c07-19bf-488a-94da-8f4799831d85"), (short)47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avery.Lord@studio1337.us", "Man", true, false, false, "Thomas", "Chase", "123456", "01576-765717", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69edbbdc-741a-47af-967c-a3ce25c1574c"), (short)34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morgan.Welch@ebay.biz", "Man", true, false, false, "Baldwin", "Henry", "123456", "01478-107085", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6b393d4a-4666-4914-ab2c-f2ce9c66b3dc"), (short)24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evan.Shepherd@gmail.info", "Woman", true, false, false, "Taylor", "Ella", "123456", "01258-196011", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6c37c6f1-16aa-421e-9a96-63b205fd82ed"), (short)25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaangurbuz97@gmail.com", "Man", true, true, false, "Gürbüz", "Kaan", "123456", "05394643458", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f747f0e-ffcc-4148-b400-f19a0b76e3a3"), (short)23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexis.Smith@theguardian.info", "Woman", true, false, false, "Thorne", "Makayla", "123456", "01042-895700", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f90ecb5-6e2a-469b-ac83-07a1a57ccbdc"), (short)21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ryan.Wright@pinterest.biz", "Woman", true, false, false, "Nash", "Emma", "123456", "01709-828101", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("73fa537b-21bc-4a61-a169-dcf8be7c2166"), (short)39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savannah.Johnson@etsy.com", "Man", true, false, false, "Nelson", "James", "123456", "01905-522977", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74594471-8ab3-460f-9bb6-26db98c96f29"), (short)18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thomas.Sanders@stackoverflow.org.uk", "Man", true, false, false, "Mac", "Mark", "123456", "01486-083549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7aeb8959-8e27-4e35-b672-9e568d0fabcd"), (short)40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lydia.Mcfarlane@etsy.com", "Man", true, false, false, "Leach", "Emily", "123456", "01850-497064", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a754a20-529c-4d25-9d4d-61957d8b5bb9"), (short)62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R.Whitehead@yahoo.org", "Woman", true, false, false, "Taylor", "Juan", "123456", "01534-222569", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9688c23e-f5f0-48ec-8f1f-82826948e2dd"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jasmine.Jackson@taobao.co.uk", "Man", true, false, false, "Jackson", "Addison", "123456", "01733-578524", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9cc170b3-c0da-4787-b66f-a23774af28f1"), (short)48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angel.Nash@sky.com", "Woman", true, false, false, "Bradshaw", "Damian", "123456", "01900-117077", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9faa630f-c223-4e78-8d23-fe7abccb7068"), (short)24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Hooper@bing.co.uk", "Woman", true, false, false, "Kenny", "Owen", "123456", "01524-779386", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bc7c1c88-a9a2-4c3b-bff9-e16cf5aeeff3"), (short)60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Mcfarlane@stackoverflow.com", "Man", true, false, false, "Smith", "Liam", "123456", "01575-101017", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "Email", "Gender", "IsActive", "IsAdmin", "IsDeleted", "LastName", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("bed577fb-cf78-4c74-8452-456565f22aeb"), (short)26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Mac@youtube.net", "Woman", true, false, false, "Thomas", "Addison", "123456", "01778-621974", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("beebf57c-ed3a-4f25-a58e-00a90fbf33ad"), (short)19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Perkins@theguardian.com", "Woman", true, false, false, "Leach", "Daniel", "123456", "01513-354642", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bfd81de4-0fe9-4efd-9795-d0ef3cc2ad17"), (short)46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katherine.Summers@yelp.org.uk", "Man", true, false, false, "Mac", "Brooklyn", "123456", "01509-942936", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ce6c2d3a-8fa5-4b16-9bd7-8652c814f10f"), (short)59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L.Peters@globo.biz", "Woman", true, false, false, "Thomas", "Zoey", "123456", "01886-281937", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cfdb7924-13be-4752-8801-c922d7c868e2"), (short)34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Mcgrath@sky.biz", "Woman", true, false, false, "Cassidy", "Andrea", "123456", "01280-912988", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d6a351a5-2235-4355-ab2c-f910d871b80f"), (short)36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Boyd@microsoft.org.uk", "Man", true, false, false, "Schofield", "Dominic", "123456", "01159-452209", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e8a559b2-f331-4e89-9c0b-91c96b47fc29"), (short)20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@iea.com", "Man", true, true, false, "Admin", "Admin", "123456", "05362454497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f537bdb6-392f-4111-a7e5-ae8e6c9db661"), (short)42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Davies@163.co", "Man", true, false, false, "Wood", "Zoe", "123456", "01179-845362", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc7d42f3-51c3-4857-8ae5-32175f0a0089"), (short)43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Evans@flipkart.us", "Man", true, false, false, "Perkins", "Lauren", "123456", "01151-951726", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblAnswers",
                columns: new[] { "Id", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("11ea9f38-f6cc-45c7-a9cc-3eccaa5098a6"), "Answer 1.2", new Guid("6ae14977-045a-47de-b14d-94e53e1bb972") },
                    { new Guid("1f70ff82-149b-49e8-b336-911ed8622707"), "Answer 3.3", new Guid("bbb97530-6a14-4407-b86d-70371f5f533f") },
                    { new Guid("23bf7b12-da84-4e9b-91b0-844acd997ede"), "Answer 3.4", new Guid("bbb97530-6a14-4407-b86d-70371f5f533f") },
                    { new Guid("23c3bee9-00a7-478f-873a-fc120512bb9f"), "Answer 2.1", new Guid("79498984-2b27-477e-95a2-b0234deae719") },
                    { new Guid("398850d0-2a09-48d3-9362-e2efc4fd6236"), "Answer 4.2", new Guid("eef48716-cd6b-4f86-895f-31aaef411982") },
                    { new Guid("3c61f4d5-8353-45e9-a2ff-ba0d48312684"), "Answer 1.1", new Guid("6ae14977-045a-47de-b14d-94e53e1bb972") },
                    { new Guid("4785e7c3-6352-42f7-a819-0e5d53ec3c79"), "Answer 4.1", new Guid("eef48716-cd6b-4f86-895f-31aaef411982") },
                    { new Guid("4c54cf72-020e-42c2-a8ae-393eb5862f5f"), "Answer 4.6", new Guid("eef48716-cd6b-4f86-895f-31aaef411982") },
                    { new Guid("6103882f-d828-44c2-8e4e-b58da8743273"), "Answer 2.2", new Guid("79498984-2b27-477e-95a2-b0234deae719") },
                    { new Guid("6213e469-347c-4f7c-887e-3611a01ab3ca"), "Answer 1.3", new Guid("6ae14977-045a-47de-b14d-94e53e1bb972") },
                    { new Guid("765feb6f-b03d-423e-ab68-0875e4d270e2"), "Answer 0.3", new Guid("7eda2b79-2cb4-451d-87ad-c6ac3a99edc4") },
                    { new Guid("94d6d97d-438d-4f5c-b9e2-3b7ff676d7de"), "Answer 4.5", new Guid("eef48716-cd6b-4f86-895f-31aaef411982") },
                    { new Guid("9aa0b862-4d6f-4de2-9965-13e62acdd61a"), "Answer 1.4", new Guid("6ae14977-045a-47de-b14d-94e53e1bb972") },
                    { new Guid("9b40c110-9d22-4911-9f82-b3730bda220f"), "Answer 0.1", new Guid("7eda2b79-2cb4-451d-87ad-c6ac3a99edc4") },
                    { new Guid("a69b9778-f961-4f8e-86f5-fc2304f6847c"), "Answer 4.3", new Guid("eef48716-cd6b-4f86-895f-31aaef411982") },
                    { new Guid("a8951950-a289-45c8-aa36-cc4be75d3bec"), "Answer 2.4", new Guid("79498984-2b27-477e-95a2-b0234deae719") },
                    { new Guid("b36c496f-4ebd-4d57-a54f-cbd3f070df3d"), "Answer 4.4", new Guid("eef48716-cd6b-4f86-895f-31aaef411982") },
                    { new Guid("b91572ba-c498-48f5-938f-0c9158d3b87d"), "Answer 3.2", new Guid("bbb97530-6a14-4407-b86d-70371f5f533f") },
                    { new Guid("ba64065b-90e6-4627-a03e-d3ac77f7ee5a"), "Answer 0.2", new Guid("7eda2b79-2cb4-451d-87ad-c6ac3a99edc4") },
                    { new Guid("c58ad3c0-5778-40f0-ba93-9074beb42f01"), "Answer 0.4", new Guid("7eda2b79-2cb4-451d-87ad-c6ac3a99edc4") },
                    { new Guid("ca6041a9-a14b-4b61-9911-d1ba3834c0d9"), "Answer 2.3", new Guid("79498984-2b27-477e-95a2-b0234deae719") },
                    { new Guid("f11ed040-71e6-4b18-a6c4-c8eef1abda5c"), "Answer 3.1", new Guid("bbb97530-6a14-4407-b86d-70371f5f533f") }
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
