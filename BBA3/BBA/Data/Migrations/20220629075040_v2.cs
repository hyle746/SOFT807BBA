using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBA.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91767865-bdd5-4250-bf69-6594fe19c14f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "63fef2a4-dcaf-472f-970f-5dd9ba10fd4d", 0, "cdccf96e-d77f-4cfd-b41b-b95209cc7da0", "ApplicationUser", "customer@bba.co.nz", true, false, null, "CUSTOMER@BBA.CO.NZ", "CUSTOMER@BBA.CO.NZ", "AQAAAAEAACcQAAAAEP48LZk9h2wmVql1zZpNtJP8z1630kWpoWWCsVkagRm8dJPrVIhO0ishKOgz3HBTmg==", null, true, "a9ad2207-616c-46b2-a2d7-fa7a2704e008", false, "customer@bba.co.nz" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f2d61ff4-9924-49ab-a6c1-745035357933", 0, "9dae5aa1-3519-45c5-92ee-7f39a8c761f3", "ApplicationUser", "admin@bba.co.nz", true, false, null, "ADMIN@BBA.CO.NZ", "ADMIN@BBA.CO.NZ", "AQAAAAEAACcQAAAAEIrf/57WllK+VC8HPkq7BMDe05qg18vRwXooaHQUWlzzm+lytItdXkikIa+LrKm5Xw==", "123456789", true, "c7c1412b-1834-499e-9465-b453f256e7a2", false, "admin@bba.co.nz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63fef2a4-dcaf-472f-970f-5dd9ba10fd4d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2d61ff4-9924-49ab-a6c1-745035357933");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "91767865-bdd5-4250-bf69-6594fe19c14f", 0, "5d202a6d-8646-4789-948c-a867ecd492dc", "ApplicationUser", "admin@bba.co.nz", true, false, null, null, null, "AQAAAAEAACcQAAAAEPVJbXAjHmans5MX/mthThP/KNZL5Dxq3A5aLPmNU+wQhJdgg+SKMOih5BvJpwQxDA==", "123456789", true, "76464baf-c50c-4e81-88a5-d42e8986cd22", false, "admin@bba.co.nz" });
        }
    }
}
