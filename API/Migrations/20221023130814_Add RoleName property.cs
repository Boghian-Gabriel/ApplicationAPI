using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddRoleNameproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("250bba42-2d40-495a-914f-27d73e0a4967"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 2" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7cbea0bc-bf83-4985-97f1-bbb68d5cc32e"),
                columns: new[] { "RealeseDate", "Title" },
                values: new object[] { new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("841aa486-a306-4053-bac6-36db7eb079b7"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"), new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Bean" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9b6aec3f-48ec-4a92-bf12-0598ff4a9d7c"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 2" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b7fcf052-71b1-49d8-9dbd-e23dc66e3f23"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul P2" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ce17fa4f-7687-4a7b-8b86-1f268af474c4"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 1" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("db348d76-8666-4bd1-9a66-f8050ae93018"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("2b44ee54-2d50-437c-996d-40525e268186"), new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The horses" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ddd44de0-0d4b-4861-9fe4-70e81ad2ba7f"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example3" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e0c51a35-6324-44f4-a094-dd41f0deb249"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example6" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f4da5619-73a5-417c-8975-872d12c7da71"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"), new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western P2" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fcd8e3e5-1b03-4416-8678-0405c63d5d0c"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "UserName", "UserRole" },
                values: new object[] { "Ionescu", "Administartor" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "Password", "UserName", "UserRole" },
                values: new object[] { "user@gmail.com", "user12", "Marian", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("250bba42-2d40-495a-914f-27d73e0a4967"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("2b44ee54-2d50-437c-996d-40525e268186"), new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The horses" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7cbea0bc-bf83-4985-97f1-bbb68d5cc32e"),
                columns: new[] { "RealeseDate", "Title" },
                values: new object[] { new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul P2" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("841aa486-a306-4053-bac6-36db7eb079b7"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 1" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9b6aec3f-48ec-4a92-bf12-0598ff4a9d7c"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 2" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b7fcf052-71b1-49d8-9dbd-e23dc66e3f23"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example6" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ce17fa4f-7687-4a7b-8b86-1f268af474c4"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 1" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("db348d76-8666-4bd1-9a66-f8050ae93018"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"), new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Bean" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ddd44de0-0d4b-4861-9fe4-70e81ad2ba7f"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e0c51a35-6324-44f4-a094-dd41f0deb249"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"), new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western P2" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f4da5619-73a5-417c-8975-872d12c7da71"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 2" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fcd8e3e5-1b03-4416-8678-0405c63d5d0c"),
                columns: new[] { "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "UserName",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "Password", "UserName" },
                values: new object[] { "admin123@gmail.com", "pass123", "admin123" });
        }
    }
}
