using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM3.Migrations
{
    /// <inheritdoc />
    public partial class TabelaHoleriteComFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Holerites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataReferencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorasTrabalhadas = table.Column<int>(type: "int", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Proventos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalarioLiquido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descontos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    INSS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FGTS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalarioBruto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holerites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holerites_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holerites_FuncionarioId",
                table: "Holerites",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holerites");
        }
    }
}
