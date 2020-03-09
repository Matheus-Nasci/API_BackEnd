using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai.InLock.WebApi.CodeFirst.Migrations
{
    public partial class CriaBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    IdEstudio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeEstudio = table.Column<string>(type: "VARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.IdEstudio);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    IdJogo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeJogo = table.Column<string>(type: "VARCHAR (150)", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "DATE", nullable: false),
                    Preco = table.Column<decimal>(type: "DECIMAL (18,2)", nullable: false),
                    IdEstudio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.IdJogo);
                    table.ForeignKey(
                        name: "FK_Jogos_Estudios_IdEstudio",
                        column: x => x.IdEstudio,
                        principalTable: "Estudios",
                        principalColumn: "IdEstudio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "VARCHAR (150)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR (150)", maxLength: 30, nullable: false),
                    IdTipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estudios",
                columns: new[] { "IdEstudio", "NomeEstudio" },
                values: new object[,]
                {
                    { 1, "Blizzard" },
                    { 2, "Rockstar Studios" },
                    { 3, "Square Enix" }
                });

            migrationBuilder.InsertData(
                table: "TipoUsuario",
                columns: new[] { "IdTipoUsuario", "Titulo" },
                values: new object[,]
                {
                    { 1, "Adminintrador" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "IdJogo", "DataLancamento", "Descricao", "IdEstudio", "NomeJogo", "Preco" },
                values: new object[,]
                {
                    { 1, new DateTime(2012, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "É Um jogo que comtém bastante ação e é viciante", 1, "Diablo 3", 99.00m },
                    { 2, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jogo eletrônico de Ação e Aventura", 2, "Red Dead Redemption II", 120.00m }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "IdUsuario", "Email", "IdTipoUsuario", "Senha" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", 1, "admin" },
                    { 2, "cliente@cliente.com", 1, "cliente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_IdEstudio",
                table: "Jogos",
                column: "IdEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoUsuario",
                table: "Usuario",
                column: "IdTipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
