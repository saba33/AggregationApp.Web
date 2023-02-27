using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AggregationApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedTableForAggregationDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricityModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tinklas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obt_Pavadinimas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obj_Gv_Tipas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obj_Numeris = table.Column<int>(type: "int", nullable: false),
                    P_Plus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pl_T = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_Minus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPPlus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPMinus = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityModels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricityModels");
        }
    }
}
