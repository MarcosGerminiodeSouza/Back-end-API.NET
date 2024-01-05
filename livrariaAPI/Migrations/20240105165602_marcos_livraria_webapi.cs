using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariaAPI.Migrations
{
    /// <inheritdoc />
    public partial class marcos_livraria_webapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    idt_autor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_autor = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.idt_autor);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    idt_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    des_categoria = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.idt_categoria);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    idt_editora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_editora = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.idt_editora);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idt_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    log_usuario = table.Column<string>(type: "char(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    des_senha = table.Column<string>(type: "char(4)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idt_usuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    idt_livro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idt_autor = table.Column<int>(type: "int", nullable: false),
                    idt_categoria = table.Column<int>(type: "int", nullable: false),
                    idt_editora = table.Column<int>(type: "int", nullable: false),
                    des_titulo = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    des_temporada = table.Column<string>(type: "varchar(25)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    num_ano = table.Column<int>(type: "int", nullable: false),
                    val_livro = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    des_imagem = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ind_lancamento = table.Column<string>(type: "char(1)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    qtd_livro_estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.idt_livro);
                    table.ForeignKey(
                        name: "FK_Livros_Autores_idt_autor",
                        column: x => x.idt_autor,
                        principalTable: "Autores",
                        principalColumn: "idt_autor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livros_Categorias_idt_categoria",
                        column: x => x.idt_categoria,
                        principalTable: "Categorias",
                        principalColumn: "idt_categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livros_Editoras_idt_editora",
                        column: x => x.idt_editora,
                        principalTable: "Editoras",
                        principalColumn: "idt_editora",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    idt_venda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idt_usuario = table.Column<int>(type: "int", nullable: false),
                    dat_venda = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.idt_venda);
                    table.ForeignKey(
                        name: "FK_Vendas_Usuarios_idt_usuario",
                        column: x => x.idt_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "idt_usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "livro_venda",
                columns: table => new
                {
                    idt_livro_venda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idt_livro = table.Column<int>(type: "int", nullable: false),
                    idt_venda = table.Column<int>(type: "int", nullable: false),
                    qtd_livro = table.Column<int>(type: "int", nullable: false),
                    val_livro = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livro_venda", x => x.idt_livro_venda);
                    table.ForeignKey(
                        name: "FK_livro_venda_Livros_idt_livro",
                        column: x => x.idt_livro,
                        principalTable: "Livros",
                        principalColumn: "idt_livro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_livro_venda_Vendas_idt_venda",
                        column: x => x.idt_venda,
                        principalTable: "Vendas",
                        principalColumn: "idt_venda",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_livro_venda_idt_livro",
                table: "livro_venda",
                column: "idt_livro");

            migrationBuilder.CreateIndex(
                name: "IX_livro_venda_idt_venda",
                table: "livro_venda",
                column: "idt_venda");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_idt_autor",
                table: "Livros",
                column: "idt_autor");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_idt_categoria",
                table: "Livros",
                column: "idt_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_idt_editora",
                table: "Livros",
                column: "idt_editora");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_idt_usuario",
                table: "Vendas",
                column: "idt_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "livro_venda");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Editoras");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
