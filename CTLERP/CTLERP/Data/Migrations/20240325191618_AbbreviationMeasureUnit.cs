﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTLERP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AbbreviationMeasureUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "MeasureUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "MeasureUnits");
        }
    }
}
