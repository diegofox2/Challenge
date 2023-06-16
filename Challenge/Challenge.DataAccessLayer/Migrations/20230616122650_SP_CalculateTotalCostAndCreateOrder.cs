using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SP_CalculateTotalCostAndCreateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE PROCEDURE CalculateTotalCostAndCreateOrder
                @CustomerID INT,
                @ProductID INT,
                @Quantity INT
                AS
                BEGIN
                DECLARE @TotalCost DECIMAL(18, 2)

                -- Calcular el costo total
                SELECT @TotalCost = Price * @Quantity
                FROM Products
                WHERE ID = @ProductID

                -- Insertar el nuevo pedido
                INSERT INTO Orders (CustomerID, ProductID, Quantity, TotalCost)
                VALUES (@CustomerID, @ProductID, @Quantity, @TotalCost)
                END"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE CalculateTotalCostAndCreateOrder");
        }
    }
}
