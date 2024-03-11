using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRMenuAPI.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantUserMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Restaurants_RestaurantId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_States_StateId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Category_CategoryId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_States_StateId",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Food_StateId",
                table: "Foods",
                newName: "IX_Foods_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_CategoryId",
                table: "Foods",
                newName: "IX_Foods_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_StateId",
                table: "Categories",
                newName: "IX_Categories_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_RestaurantId",
                table: "Categories",
                newName: "IX_Categories_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RestaurantUsers",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantUsers", x => new { x.RestaurantId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RestaurantUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantUsers_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUsers_UserId",
                table: "RestaurantUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Restaurants_RestaurantId",
                table: "Categories",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_States_StateId",
                table: "Categories",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_States_StateId",
                table: "Foods",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Restaurants_RestaurantId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_States_StateId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_States_StateId",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "RestaurantUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_StateId",
                table: "Food",
                newName: "IX_Food_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_CategoryId",
                table: "Food",
                newName: "IX_Food_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_StateId",
                table: "Category",
                newName: "IX_Category_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_RestaurantId",
                table: "Category",
                newName: "IX_Category_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Restaurants_RestaurantId",
                table: "Category",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_States_StateId",
                table: "Category",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Category_CategoryId",
                table: "Food",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_States_StateId",
                table: "Food",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");
        }
    }
}
