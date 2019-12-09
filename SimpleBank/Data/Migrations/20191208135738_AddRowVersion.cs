using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBank.Data.Migrations
{
    public partial class AddRowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "BankAccounts",
                rowVersion: true,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "BankAccounts");

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
    }
}
