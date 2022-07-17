using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class UpdateWorkerTracker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryCollection_Factory_FactoryId",
                table: "FactoryCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerTracker_Worker_WorkerId",
                table: "WorkerTracker");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkerId",
                table: "WorkerTracker",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<byte>(
                name: "Activity",
                table: "WorkerTracker",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "WorkerTracker",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PickedDate",
                table: "WorkerTracker",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "FactoryId",
                table: "FactoryCollection",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryCollection_Factory_FactoryId",
                table: "FactoryCollection",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerTracker_Worker_WorkerId",
                table: "WorkerTracker",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryCollection_Factory_FactoryId",
                table: "FactoryCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerTracker_Worker_WorkerId",
                table: "WorkerTracker");

            migrationBuilder.DropColumn(
                name: "Activity",
                table: "WorkerTracker");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "WorkerTracker");

            migrationBuilder.DropColumn(
                name: "PickedDate",
                table: "WorkerTracker");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkerId",
                table: "WorkerTracker",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FactoryId",
                table: "FactoryCollection",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryCollection_Factory_FactoryId",
                table: "FactoryCollection",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerTracker_Worker_WorkerId",
                table: "WorkerTracker",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
