using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeFinder.Migrations
{
    /// <inheritdoc />
    public partial class WorkerAddImageUUID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageUUID",
                table: "Workers",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUUID",
                table: "Workers");
        }
    }
}
