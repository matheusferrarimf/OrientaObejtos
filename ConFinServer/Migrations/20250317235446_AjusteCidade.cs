using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConFinServer.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Cidade");

            migrationBuilder.AddColumn<string>(
                name: "EstadoSigla",
                table: "Cidade",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoSigla",
                table: "Cidade",
                column: "EstadoSigla");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade_Estado_EstadoSigla",
                table: "Cidade",
                column: "EstadoSigla",
                principalTable: "Estado",
                principalColumn: "Sigla",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade_Estado_EstadoSigla",
                table: "Cidade");

            migrationBuilder.DropIndex(
                name: "IX_Cidade_EstadoSigla",
                table: "Cidade");

            migrationBuilder.DropColumn(
                name: "EstadoSigla",
                table: "Cidade");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Cidade",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
