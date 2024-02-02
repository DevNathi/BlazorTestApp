using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTestApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    B_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    B_Active = table.Column<int>(type: "int", nullable: false),
                    B_Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.B_Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    W_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    W_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    W_Active = table.Column<int>(type: "int", nullable: false),
                    W_Wms = table.Column<int>(type: "int", nullable: false),
                    W_TradingWarehouse = table.Column<int>(type: "int", nullable: false),
                    W_BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.W_Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Branches_W_BranchId",
                        column: x => x.W_BranchId,
                        principalTable: "Branches",
                        principalColumn: "B_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    U_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    U_Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    U_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    U_BranchId = table.Column<int>(type: "int", nullable: false),
                    U_WarehouseId = table.Column<int>(type: "int", nullable: false),
                    U_Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.U_Id);
                    table.ForeignKey(
                        name: "FK_Users_Branches_U_BranchId",
                        column: x => x.U_BranchId,
                        principalTable: "Branches",
                        principalColumn: "B_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Warehouses_U_WarehouseId",
                        column: x => x.U_WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "W_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_U_BranchId",
                table: "Users",
                column: "U_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_U_WarehouseId",
                table: "Users",
                column: "U_WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_W_BranchId",
                table: "Warehouses",
                column: "W_BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
