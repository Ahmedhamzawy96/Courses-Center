// <auto-generated />
using System;
using Courses_Center.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Courses_Center.Migrations
{
    [DbContext(typeof(CenterContext))]
    partial class CenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseProfessor", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "ProfessorsId");

                    b.HasIndex("ProfessorsId");

                    b.ToTable("CourseProfessor");
                });

            modelBuilder.Entity("Courses_Center.Models.Admin", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Courses_Center.Models.Buyer", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Courses_Center.Models.BuyingCart", b =>
                {
                    b.Property<int>("SId")
                        .HasColumnType("int");

                    b.Property<string>("BuyUserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VisaNumber")
                        .HasColumnType("int");

                    b.HasKey("SId", "BuyUserName");

                    b.HasIndex("BuyUserName");

                    b.ToTable("BuyingCarts");
                });

            modelBuilder.Entity("Courses_Center.Models.College", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UniID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniID");

                    b.HasIndex("Name", "UniID")
                        .IsUnique();

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("Courses_Center.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DeptID")
                        .HasColumnType("int");

                    b.Property<bool?>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeptID");

                    b.HasIndex("Name", "DeptID")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Courses_Center.Models.CourseProfessor", b =>
                {
                    b.Property<int>("ProfId")
                        .HasColumnType("int");

                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.HasKey("ProfId", "CrsId");

                    b.HasIndex("CrsId");

                    b.ToTable("CourseProfessors");
                });

            modelBuilder.Entity("Courses_Center.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColID")
                        .HasColumnType("int");

                    b.Property<bool>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ColID");

                    b.HasIndex("Name", "ColID")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Courses_Center.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("Courses_Center.Models.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CountOfBuy")
                        .HasColumnType("int");

                    b.Property<int>("CrsID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProfID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CrsID");

                    b.HasIndex("ProfID");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("Courses_Center.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("CourseProfessor", b =>
                {
                    b.HasOne("Courses_Center.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courses_Center.Models.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Courses_Center.Models.BuyingCart", b =>
                {
                    b.HasOne("Courses_Center.Models.Buyer", "Buyer")
                        .WithMany("BuyingCarts")
                        .HasForeignKey("BuyUserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courses_Center.Models.Source", "Source")
                        .WithMany("BuyingCarts")
                        .HasForeignKey("SId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("Courses_Center.Models.College", b =>
                {
                    b.HasOne("Courses_Center.Models.University", "University")
                        .WithMany("Colleges")
                        .HasForeignKey("UniID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("Courses_Center.Models.Course", b =>
                {
                    b.HasOne("Courses_Center.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DeptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Courses_Center.Models.CourseProfessor", b =>
                {
                    b.HasOne("Courses_Center.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courses_Center.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Courses_Center.Models.Department", b =>
                {
                    b.HasOne("Courses_Center.Models.College", "College")
                        .WithMany("Departments")
                        .HasForeignKey("ColID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");
                });

            modelBuilder.Entity("Courses_Center.Models.Source", b =>
                {
                    b.HasOne("Courses_Center.Models.Course", "Course")
                        .WithMany("Sources")
                        .HasForeignKey("CrsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courses_Center.Models.Professor", "Professor")
                        .WithMany("Sources")
                        .HasForeignKey("ProfID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Courses_Center.Models.Buyer", b =>
                {
                    b.Navigation("BuyingCarts");
                });

            modelBuilder.Entity("Courses_Center.Models.College", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Courses_Center.Models.Course", b =>
                {
                    b.Navigation("Sources");
                });

            modelBuilder.Entity("Courses_Center.Models.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Courses_Center.Models.Professor", b =>
                {
                    b.Navigation("Sources");
                });

            modelBuilder.Entity("Courses_Center.Models.Source", b =>
                {
                    b.Navigation("BuyingCarts");
                });

            modelBuilder.Entity("Courses_Center.Models.University", b =>
                {
                    b.Navigation("Colleges");
                });
#pragma warning restore 612, 618
        }
    }
}
