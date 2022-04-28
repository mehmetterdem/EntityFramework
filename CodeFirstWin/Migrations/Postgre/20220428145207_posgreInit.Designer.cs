﻿// <auto-generated />
using CodeFirstWin.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CodeFirstWin.Migrations.Postgre
{
    [DbContext(typeof(PostgreContext))]
    [Migration("20220428145207_posgreInit")]
    partial class posgreInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CodeFirstWin.Entities.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("CategoryName");

                    b.HasKey("Id");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("CodeFirstWin.Entities.Stocks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("StokAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("stookAdi");

                    b.Property<int>("kategoriId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("kategoriId");

                    b.ToTable("Stoklar");
                });

            modelBuilder.Entity("CodeFirstWin.Entities.Stocks", b =>
                {
                    b.HasOne("CodeFirstWin.Entities.Kategori", "kategori")
                        .WithMany("Stoklar")
                        .HasForeignKey("kategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kategori");
                });

            modelBuilder.Entity("CodeFirstWin.Entities.Kategori", b =>
                {
                    b.Navigation("Stoklar");
                });
#pragma warning restore 612, 618
        }
    }
}
