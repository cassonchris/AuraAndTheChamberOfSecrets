using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuraAndTheChamberOfSecrets.Repo.EntityFramework.Migrations
{
    public partial class AddUserLinkToQuestionAndAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Questions");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Questions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Answers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserId",
                table: "Answers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_UserProfiles_UserId",
                table: "Answers",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_UserProfiles_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_UserProfiles_UserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_UserProfiles_UserId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Answers_UserId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Questions",
                nullable: false,
                defaultValue: "");
        }
    }
}
