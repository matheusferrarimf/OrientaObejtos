﻿// <auto-generated />
using System;
using ConFinServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConFinServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConFinServer.Model.Cidade", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<string>("EstadoSigla")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Codigo");

                    b.HasIndex("EstadoSigla");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("ConFinServer.Model.Conta", b =>
                {
                    b.Property<int>("numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("numero"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PessoaCodigo")
                        .HasColumnType("integer");

                    b.Property<int>("Situacao")
                        .HasColumnType("integer");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("numero");

                    b.HasIndex("PessoaCodigo");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("ConFinServer.Model.Estado", b =>
                {
                    b.Property<string>("Sigla")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Sigla");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("ConFinServer.Model.Pessoa", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<int>("CidadeCodigo")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<int>("idade")
                        .HasColumnType("integer");

                    b.HasKey("Codigo");

                    b.HasIndex("CidadeCodigo");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("ConFinServer.Model.Cidade", b =>
                {
                    b.HasOne("ConFinServer.Model.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoSigla")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("ConFinServer.Model.Conta", b =>
                {
                    b.HasOne("ConFinServer.Model.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ConFinServer.Model.Pessoa", b =>
                {
                    b.HasOne("ConFinServer.Model.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });
#pragma warning restore 612, 618
        }
    }
}
