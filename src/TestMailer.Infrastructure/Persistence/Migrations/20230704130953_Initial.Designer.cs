﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestMailer.Infrastructure.Persistence;

#nullable disable

namespace TestMailer.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(MailingDbContext))]
    [Migration("20230704130953_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestMailer.Domain.Mailing.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("body");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("FailedMessage")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("failed_message");

                    b.Property<int>("Result")
                        .HasColumnType("integer")
                        .HasColumnName("result");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("subject");

                    b.Property<List<string>>("_recipients")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("_recipients");

                    b.HasKey("Id")
                        .HasName("pk_email");

                    b.HasIndex("Subject")
                        .HasDatabaseName("ix_email_subject");

                    b.ToTable("email", "Mailing");
                });
#pragma warning restore 612, 618
        }
    }
}