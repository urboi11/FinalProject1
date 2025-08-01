﻿// <auto-generated />
using System;
using FinalProject1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FinalProject1.Data;

#nullable disable

namespace FinalProject1.Migrations
{
    [DbContext(typeof(FinalProjectContext))]
    [Migration("20250729001133_UpdateToBirthDate")]
    partial class UpdateToBirthDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.18");

            modelBuilder.Entity("FinalProject1.Models.Team", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CollegeProgram")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamMember")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
