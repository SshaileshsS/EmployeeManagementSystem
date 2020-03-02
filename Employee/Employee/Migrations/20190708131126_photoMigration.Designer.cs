﻿// <auto-generated />
using Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employee.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190708131126_photoMigration")]
    partial class photoMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Employee.Models.EmployeeProp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhotoPath");

                    b.HasKey("Id");

                    b.ToTable("EmployeeProps");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 1,
                            Email = "shailesh@gmail.com",
                            Name = "shailesh"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
