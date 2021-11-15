using Microsoft.EntityFrameworkCore.Migrations;

namespace SGS.Repositories.Migrations
{
    public partial class AddInvoiceHDR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemsDTL_InvoiceID",
                table: "ItemsDTL");

            migrationBuilder.DropColumn(
                name: "PaymenMethod",
                table: "InvoiceHDR");

            migrationBuilder.AlterColumn<string>(
                name: "Customer",
                table: "InvoiceHDR",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "InvoiceHDR",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsDTL_InvoiceID",
                table: "ItemsDTL",
                column: "InvoiceID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemsDTL_InvoiceID",
                table: "ItemsDTL");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "InvoiceHDR");

            migrationBuilder.AlterColumn<int>(
                name: "Customer",
                table: "InvoiceHDR",
                type: "int",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymenMethod",
                table: "InvoiceHDR",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsDTL_InvoiceID",
                table: "ItemsDTL",
                column: "InvoiceID");
        }
    }
}
