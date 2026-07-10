using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DepartmentId", "Email", "IsActive", "ManagerId", "Name", "PasswordHash", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, "admin@test.com", true, null, "Admin User", "$2a$11$dIRcqLN9ra7kSjzxrk8.ZuAEaPHfo0i4PZL7ek8LyjI1Gx/XOgtsm", 1 },
                    { 2, 2, "manager@test.com", true, null, "Jane Smith", "$2a$11$Cg1Fem.NDJO/UtHAnOGLXOTm8I7tDnFC2gUHEApqvSl7UNJKFW0Au", 2 },
                    { 3, 2, "employee@test.com", true, 2, "John Doe", "$2a$11$90gTurBEthchZx57oyM8Aed7r511ob.c1kIV/76ThFpQOCHxrhNXG", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
