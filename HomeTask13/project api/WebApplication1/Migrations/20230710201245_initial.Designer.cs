﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230710201245_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApplication1.Entities.SupportedLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("supportedLanguages");
                });

            modelBuilder.Entity("WebApplication1.Entities.Translate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("OriginalID")
                        .HasColumnType("int");

                    b.Property<int?>("TranslationID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OriginalID");

                    b.HasIndex("TranslationID");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("WebApplication1.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("WebApplication1.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("OriginalWord")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TranslatedWord")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("words");
                });

            modelBuilder.Entity("WebApplication1.Entities.WordAndWordCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("WordCollectionId")
                        .HasColumnType("int");

                    b.Property<int?>("WordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordCollectionId");

                    b.HasIndex("WordId");

                    b.ToTable("WordAndWordCollection");
                });

            modelBuilder.Entity("WebApplication1.Entities.WordCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("wordsCollection");
                });

            modelBuilder.Entity("WebApplication1.Entities.Translate", b =>
                {
                    b.HasOne("WebApplication1.Entities.SupportedLanguage", "Original")
                        .WithMany("Originals")
                        .HasForeignKey("OriginalID");

                    b.HasOne("WebApplication1.Entities.SupportedLanguage", "Translation")
                        .WithMany("Translations")
                        .HasForeignKey("TranslationID");

                    b.Navigation("Original");

                    b.Navigation("Translation");
                });

            modelBuilder.Entity("WebApplication1.Entities.Word", b =>
                {
                    b.HasOne("WebApplication1.Entities.Translate", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("WebApplication1.Entities.WordAndWordCollection", b =>
                {
                    b.HasOne("WebApplication1.Entities.WordCollection", "WordCollection")
                        .WithMany("WordAndWordCollection")
                        .HasForeignKey("WordCollectionId");

                    b.HasOne("WebApplication1.Entities.Word", "Word")
                        .WithMany("WordAndWordCollection")
                        .HasForeignKey("WordId");

                    b.Navigation("Word");

                    b.Navigation("WordCollection");
                });

            modelBuilder.Entity("WebApplication1.Entities.WordCollection", b =>
                {
                    b.HasOne("WebApplication1.Entities.User", null)
                        .WithMany("wordCollections")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("WebApplication1.Entities.SupportedLanguage", b =>
                {
                    b.Navigation("Originals");

                    b.Navigation("Translations");
                });

            modelBuilder.Entity("WebApplication1.Entities.User", b =>
                {
                    b.Navigation("wordCollections");
                });

            modelBuilder.Entity("WebApplication1.Entities.Word", b =>
                {
                    b.Navigation("WordAndWordCollection");
                });

            modelBuilder.Entity("WebApplication1.Entities.WordCollection", b =>
                {
                    b.Navigation("WordAndWordCollection");
                });
#pragma warning restore 612, 618
        }
    }
}
