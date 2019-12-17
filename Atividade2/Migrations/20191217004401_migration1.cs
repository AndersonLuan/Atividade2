using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atividade2.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PecasRoupa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoRoupa = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PecasRoupa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Confeccoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReposicaoId = table.Column<int>(nullable: true),
                    Registro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confeccoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Confeccoes_PecasRoupa_ReposicaoId",
                        column: x => x.ReposicaoId,
                        principalTable: "PecasRoupa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confeccoes_ReposicaoId",
                table: "Confeccoes",
                column: "ReposicaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confeccoes");

            migrationBuilder.DropTable(
                name: "PecasRoupa");
        }
    }
}
