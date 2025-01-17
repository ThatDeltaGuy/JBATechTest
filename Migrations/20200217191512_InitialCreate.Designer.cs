﻿// <auto-generated />
using System;
using JBATechTest.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JBATechTest.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20200217191512_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("JBATechTest.DAL.RainData", b =>
                {
                    b.Property<int>("RainDataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.Property<int>("XRef")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YRef")
                        .HasColumnType("INTEGER");

                    b.HasKey("RainDataID");

                    b.ToTable("RainData");
                });
#pragma warning restore 612, 618
        }
    }
}
