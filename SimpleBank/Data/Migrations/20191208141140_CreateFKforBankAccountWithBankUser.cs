using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBank.Data.Migrations
{
    public partial class CreateFKforBankAccountWithBankUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "befafd16-4304-49da-aa78-3e17d6effad3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6a264bf-b787-4353-82f2-4176c9c43ef6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cee3cfd-50af-4f42-a312-2822a7c59191");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "628ce010-1ced-4980-8a6f-e7663ae05282");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba60d58f-b128-4c5c-9e37-f214e90a5c57");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19c1c4e2-6486-489e-a576-2a4e604bfa5d", "d79d35b1-6a52-413f-9633-c5bca14f1e45", "Admin", "ADMIN" },
                    { "6bd06417-4707-47bf-bff9-4cc2e3e23397", "74ad38cc-a36f-4ed5-8fe5-aeed78e5277a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d51a15f-ed7c-4cbc-a3ee-87609034efe3", 0, "9d3a9d65-2915-4c35-8c74-574ce9e7c674", "admin@gmail.com", true, "admin", null, true, "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEOhKJZJPIfL4n+ABYtVJfrqrDTuhJ8xnW3jCncvIH3uEgwozasIWsm3/FIU48Bz6Og==", "123456789", false, "9d93f209-6a51-4b68-b274-4e877f1d6cd6", false, "admin" },
                    { "ddeb8812-6080-42e8-99c7-0f5277245fc9", 0, "7fd4fa46-20a8-4e58-9395-c92879054f2e", "john@gmail.com", true, "John", null, true, "Smith", false, null, "JOHN@GMAIL.COM", "JOHN_SM", "AQAAAAEAACcQAAAAEEgrbWAoy2XUkSnbebmvIqRk78SUo9VcXi5cidxJlRV8NYL56nCsq0mJWqrYaORfdw==", "123456789", false, "fc513613-74ef-48af-9a0e-00d3d0500795", false, "john" },
                    { "ebe210c2-17a0-49b0-a49f-c76ffba82afa", 0, "6095b0ad-6b08-4524-b6ff-59df1cbad5bc", "daniel@gmail.com", true, "Daniel", null, true, "McCadole", false, null, "DANIEL@GMAIL.COM", "DANIEL_MC", "AQAAAAEAACcQAAAAEBhkzfIZ2LR3EuSvYL2T9nUcsb5BrmtCgLUTHDkL9RrlLn2UNHyN7TeXFd8S2iHzmw==", "123456789", false, "8dc5f3d3-f594-438e-81b6-add6233da625", false, "daniel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_AspNetUsers_UserId",
                table: "BankAccounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_AspNetUsers_UserId",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19c1c4e2-6486-489e-a576-2a4e604bfa5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bd06417-4707-47bf-bff9-4cc2e3e23397");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d51a15f-ed7c-4cbc-a3ee-87609034efe3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddeb8812-6080-42e8-99c7-0f5277245fc9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebe210c2-17a0-49b0-a49f-c76ffba82afa");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BankAccounts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "befafd16-4304-49da-aa78-3e17d6effad3", "22b6baec-5ea1-4e35-b38d-207dec1c133f", "Admin", "ADMIN" },
                    { "c6a264bf-b787-4353-82f2-4176c9c43ef6", "2a525193-db82-410a-9308-f1e076cd6528", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1cee3cfd-50af-4f42-a312-2822a7c59191", 0, "93ca445e-4719-4d6a-948d-af327dda5750", "admin@gmail.com", true, "admin", null, true, "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEIevcHpiDN5fenTPAKFfq3vIbTqSrhp6t2P4l1TJ3/6izN3W/jXvOr4xyHPnitdQQQ==", "123456789", false, "497c7708-0eb9-460e-9c4d-efb913c381ce", false, "admin" },
                    { "ba60d58f-b128-4c5c-9e37-f214e90a5c57", 0, "29506ce8-dfde-4071-9f87-e3b60fbde57b", "john@gmail.com", true, "John", null, true, "Smith", false, null, "JOHN@GMAIL.COM", "JOHN_SM", "AQAAAAEAACcQAAAAEHlEJDwUVCrMQeV4YHLiMpRFOHub2fP0YDX8cofqaIeZVo30VhtIngfEnNS321PRbA==", "123456789", false, "1f541ef9-4a86-4674-934b-bb40d7529b57", false, "john" },
                    { "628ce010-1ced-4980-8a6f-e7663ae05282", 0, "361e5e6b-fc1a-4ccc-bd0d-dcdb76b9a8bf", "daniel@gmail.com", true, "Daniel", null, true, "McCadole", false, null, "DANIEL@GMAIL.COM", "DANIEL_MC", "AQAAAAEAACcQAAAAEB6eYcV2i8U3/SsBdTbzDNXtCLYGIocr/I7VDOKtJ/rObMu42uVb/5FlRavbYGmTfA==", "123456789", false, "427025f6-17a4-4962-a452-1646d902221f", false, "daniel" }
                });
        }
    }
}
