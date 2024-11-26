using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventosEF.Migrations
{
    /// <inheritdoc />
    public partial class BancoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCategorias",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "tbLocais",
                columns: table => new
                {
                    LocalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLocais", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "tbOrganizadores",
                columns: table => new
                {
                    OrganizadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbOrganizadores", x => x.OrganizadorId);
                });

            migrationBuilder.CreateTable(
                name: "tbParticipantes",
                columns: table => new
                {
                    ParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbParticipantes", x => x.ParticipanteId);
                });

            migrationBuilder.CreateTable(
                name: "tbEventos",
                columns: table => new
                {
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEventos", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_tbEventos_tbCategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tbCategorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbEventos_tbLocais_LocalId",
                        column: x => x.LocalId,
                        principalTable: "tbLocais",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbEventos_tbOrganizadores_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "tbOrganizadores",
                        principalColumn: "OrganizadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbInscricaos",
                columns: table => new
                {
                    InscricaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbInscricaos", x => x.InscricaoId);
                    table.ForeignKey(
                        name: "FK_tbInscricaos_tbEventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "tbEventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbInscricaos_tbParticipantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "tbParticipantes",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbEventos_CategoriaId",
                table: "tbEventos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbEventos_LocalId",
                table: "tbEventos",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_tbEventos_OrganizadorId",
                table: "tbEventos",
                column: "OrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbInscricaos_EventoId",
                table: "tbInscricaos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbInscricaos_ParticipanteId",
                table: "tbInscricaos",
                column: "ParticipanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbInscricaos");

            migrationBuilder.DropTable(
                name: "tbEventos");

            migrationBuilder.DropTable(
                name: "tbParticipantes");

            migrationBuilder.DropTable(
                name: "tbCategorias");

            migrationBuilder.DropTable(
                name: "tbLocais");

            migrationBuilder.DropTable(
                name: "tbOrganizadores");
        }
    }
}
