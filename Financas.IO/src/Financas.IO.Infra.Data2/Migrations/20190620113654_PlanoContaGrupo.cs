using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Financas.IO.Infra.Data2.Migrations
{
    public partial class PlanoContaGrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Enderecos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCadastro",
                table: "Enderecos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Cidades",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCadastro",
                table: "Cidades",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CentroDeCustos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroDeCustos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoDeContas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoDeContas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasCorrentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    NumeroDaContaCorrente = table.Column<string>(nullable: false),
                    AgenciaId = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasCorrentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasCorrentes_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContasCorrentes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanoDeContas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoDeMovimento = table.Column<int>(nullable: false),
                    GrupoDeContaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoDeContas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoDeContas_GrupoDeContas_GrupoDeContaId",
                        column: x => x.GrupoDeContaId,
                        principalTable: "GrupoDeContas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Sequencial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Observacao = table.Column<string>(type: "varchar(200)", nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    DataDoLancamento = table.Column<DateTime>(nullable: false),
                    Competencia = table.Column<int>(nullable: false),
                    CentroDeCustoId = table.Column<Guid>(nullable: false),
                    PlanoDeContaId = table.Column<Guid>(nullable: false),
                    ContaCorrenteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_CentroDeCustos_CentroDeCustoId",
                        column: x => x.CentroDeCustoId,
                        principalTable: "CentroDeCustos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ContasCorrentes_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContasCorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_PlanoDeContas_PlanoDeContaId",
                        column: x => x.PlanoDeContaId,
                        principalTable: "PlanoDeContas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_AgenciaId",
                table: "ContasCorrentes",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_ClienteId",
                table: "ContasCorrentes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_CentroDeCustoId",
                table: "Lancamentos",
                column: "CentroDeCustoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContaCorrenteId",
                table: "Lancamentos",
                column: "ContaCorrenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_PlanoDeContaId",
                table: "Lancamentos",
                column: "PlanoDeContaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoDeContas_GrupoDeContaId",
                table: "PlanoDeContas",
                column: "GrupoDeContaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "CentroDeCustos");

            migrationBuilder.DropTable(
                name: "ContasCorrentes");

            migrationBuilder.DropTable(
                name: "PlanoDeContas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "GrupoDeContas");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DataDeCadastro",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "DataDeCadastro",
                table: "Cidades");
        }
    }
}
