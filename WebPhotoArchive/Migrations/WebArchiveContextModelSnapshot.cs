﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebPhotoArchive.Models;

namespace WebPhotoArchive.Migrations
{
    [DbContext(typeof(WebArchiveContext))]
    partial class WebArchiveContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebPhotoArchive.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdComment")
                        .HasColumnType("integer");

                    b.Property<string>("NameComment")
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("PostId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebPhotoArchive.Models.Dialog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FromId")
                        .HasColumnType("integer");

                    b.Property<string>("FromName")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("LastMessage")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ToId")
                        .HasColumnType("integer");

                    b.Property<string>("ToName")
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Dialogs");
                });

            modelBuilder.Entity("WebPhotoArchive.Models.Follow", b =>
                {
                    b.Property<int>("FollowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FollowerId")
                        .HasColumnType("integer");

                    b.Property<int>("FollowingId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("FollowId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("WebPhotoArchive.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("LikerId")
                        .HasColumnType("integer");

                    b.Property<int>("LikingId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("WebPhotoArchive.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DialogId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("WebPhotoArchive.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserDoId")
                        .HasColumnType("integer");

                    b.Property<string>("UserDoName")
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("WebPhotoArchive.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Followers")
                        .HasColumnType("integer");

                    b.Property<int>("Following")
                        .HasColumnType("integer");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea");

                    b.Property<int>("Postnum")
                        .HasColumnType("integer");

                    b.Property<int>("TypeProfile")
                        .HasColumnType("integer");

                    b.Property<string>("Website")
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
