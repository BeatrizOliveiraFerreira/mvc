using Microsoft.EntityFrameworkCore.Migrations;

namespace a.Migrations
{
    public partial class TabelaPO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "POS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    CAId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POS_CAS_CAId",
                        column: x => x.CAId,
                        principalTable: "CAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_POS_CAId",
                table: "POS",
                column: "CAId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POS");
        }
    }
}
