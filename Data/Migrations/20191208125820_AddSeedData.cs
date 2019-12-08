using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBank.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b468a8b8-64fc-4290-b88b-14080a10f22a", "9c9a1208-1cf8-4d32-b5ef-a6ae26af0a90", "Admin", "ADMIN" },
                    { "7ae9b4a5-265a-4d60-8815-10008e465adc", "0719c01b-6c3a-43fa-aead-893397ade691", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "46457b21-644e-4893-bf7f-f8b6be5f2190", 0, "689bd7c8-7034-4df1-8b7d-f13ecea78cb6", "admin@gmail.com", true, "admin", null, true, "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEA+18oo/dGyP51394ncMhQx9EClv+w30nBqrUujrm+j/2tBnkgDRdK/vqIRyAAOqgA==", "123456789", false, "31fd357f-51ce-4847-bdb6-dd923649e024", false, "admin" },
                    { "41a97ea0-7c5b-4e1b-b2af-bf8f9a371b52", 0, "e71edaaf-396b-4655-a362-814ef8158c9d", "john@gmail.com", true, "John", null, true, "Smith", false, null, "JOHN@GMAIL.COM", "JOHN_SM", "AQAAAAEAACcQAAAAEA4rvapnkbE1lXiwT92ORauZt5DaMHO0HIKLXFU2fCvSKSBwSUDfE8xV8gs0bf9qvA==", "123456789", false, "b821725d-b7b7-441f-982f-83137d3e0e85", false, "john" },
                    { "92decd29-4634-45ef-b27d-1acf23537f1b", 0, "d9509746-f775-4281-9f02-513748cd794f", "daniel@gmail.com", true, "Daniel", null, true, "McCadole", false, null, "DANIEL@GMAIL.COM", "DANIEL_MC", "AQAAAAEAACcQAAAAEPzIawRAl8+ga1v5NNTC+LndpWwc2ed1Or9Q/6IfUmcv10/k40d13Mhf62qx1Fg2+g==", "123456789", false, "4d472f50-eae7-4a2f-8ca9-02e33a41b283", false, "daniel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ae9b4a5-265a-4d60-8815-10008e465adc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b468a8b8-64fc-4290-b88b-14080a10f22a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41a97ea0-7c5b-4e1b-b2af-bf8f9a371b52");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46457b21-644e-4893-bf7f-f8b6be5f2190");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92decd29-4634-45ef-b27d-1acf23537f1b");
        }
    }
}
