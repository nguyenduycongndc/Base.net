﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace testPj.Migrations
{
    public partial class themFeild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "token_id",
                table: "TRANSACTION_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "token_id",
                table: "TRANSACTION_HISTORY");
        }
    }
}
