using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBA.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "91767865-bdd5-4250-bf69-6594fe19c14f", 0, "5d202a6d-8646-4789-948c-a867ecd492dc", "ApplicationUser", "admin@bba.co.nz", true, false, null, null, null, "AQAAAAEAACcQAAAAEPVJbXAjHmans5MX/mthThP/KNZL5Dxq3A5aLPmNU+wQhJdgg+SKMOih5BvJpwQxDA==", "123456789", true, "76464baf-c50c-4e81-88a5-d42e8986cd22", false, "admin@bba.co.nz" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookID", "Author", "BookImage", "Description", "Genre", "Publisher", "Title" },
                values: new object[] { 1, "Heather Christle", "e43bf711-67bd-48cb-992c-9e95488492c9-9781948226448_grande.webp", "Award-winning poet Heather Christle has just lost a dear friend to suicide and must reckon with her own struggles with depression and the birth of her first child. How she faces her joy, grief, anxiety, impending motherhood, and conflicted truce with the world results in a moving meditation on the nature, rapture, and perils of crying―from the history of tear-catching gadgets (including the woman who designed a gun that shoots tears) to the science behind animal tears (including moths who drink them) to the fraught role of white women's tears in racist violence.", "Other", "Catapult", "The Crying Book" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookID", "Author", "BookImage", "Description", "Genre", "Publisher", "Title" },
                values: new object[] { 2, "Tester", null, "Some description here.", "Crime", "Paper company", "Sample Book" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91767865-bdd5-4250-bf69-6594fe19c14f");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
