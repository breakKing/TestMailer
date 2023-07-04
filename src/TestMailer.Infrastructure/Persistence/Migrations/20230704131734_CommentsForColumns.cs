using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMailer.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CommentsForColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_recipients",
                schema: "Mailing",
                table: "email",
                newName: "recipients");

            migrationBuilder.AlterColumn<string>(
                name: "subject",
                schema: "Mailing",
                table: "email",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                comment: "Тема письма",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "result",
                schema: "Mailing",
                table: "email",
                type: "integer",
                nullable: false,
                comment: "Результат отправки",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "failed_message",
                schema: "Mailing",
                table: "email",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                comment: "Описание ошибки при отправке (если есть)",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                schema: "Mailing",
                table: "email",
                type: "timestamp with time zone",
                nullable: false,
                comment: "Дата создания и отправки",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "body",
                schema: "Mailing",
                table: "email",
                type: "text",
                nullable: false,
                comment: "Тело письма",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<List<string>>(
                name: "recipients",
                schema: "Mailing",
                table: "email",
                type: "text[]",
                nullable: false,
                comment: "Получатели",
                oldClrType: typeof(List<string>),
                oldType: "text[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "recipients",
                schema: "Mailing",
                table: "email",
                newName: "_recipients");

            migrationBuilder.AlterColumn<string>(
                name: "subject",
                schema: "Mailing",
                table: "email",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldComment: "Тема письма");

            migrationBuilder.AlterColumn<int>(
                name: "result",
                schema: "Mailing",
                table: "email",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Результат отправки");

            migrationBuilder.AlterColumn<string>(
                name: "failed_message",
                schema: "Mailing",
                table: "email",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "Описание ошибки при отправке (если есть)");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                schema: "Mailing",
                table: "email",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldComment: "Дата создания и отправки");

            migrationBuilder.AlterColumn<string>(
                name: "body",
                schema: "Mailing",
                table: "email",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Тело письма");

            migrationBuilder.AlterColumn<List<string>>(
                name: "_recipients",
                schema: "Mailing",
                table: "email",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldComment: "Получатели");
        }
    }
}
