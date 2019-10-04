using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoDeUsuario.Infra.Migrations
{
    public partial class Dados_Iniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    SexoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.SexoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Senha = table.Column<string>(type: "varchar(30)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    SexoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "SexoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SexoId",
                table: "Usuarios",
                column: "SexoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Sexo");
        }
    }
}
