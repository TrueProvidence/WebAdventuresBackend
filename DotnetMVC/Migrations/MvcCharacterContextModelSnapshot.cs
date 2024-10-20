﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcCharacter.Data;

#nullable disable

namespace DotnetMVC.Migrations
{
    [DbContext(typeof(MvcCharacterContext))]
    partial class MvcCharacterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("DotnetMVC.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Campaign")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Currency")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Items")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Character");
                });
#pragma warning restore 612, 618
        }
    }
}
