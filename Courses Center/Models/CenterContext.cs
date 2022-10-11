using Microsoft.EntityFrameworkCore;

namespace Courses_Center.Models
{
    public class CenterContext : DbContext
    {
        public CenterContext(DbContextOptions<CenterContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>().HasIndex(U => U.Name).IsUnique();
            modelBuilder.Entity<BuyingCart>().HasKey(A => new { A.SId, A.BuyUserName });
            modelBuilder.Entity<CourseProfessor>().HasKey(A => new { A.ProfId, A.CrsId });
            modelBuilder.Entity<College>().HasIndex(A => new { A.Name, A.UniID }).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(A => new { A.Name, A.ColID }).IsUnique();
            modelBuilder.Entity<Course>().HasIndex(A => new { A.Name, A.DeptID }).IsUnique();

            //modelBuilder.Entity<Department>().HasOne(A => A.College).WithMany(A => A.Departments)
            //    .HasForeignKey(A => new { A.ColName, A.UniName });
            //modelBuilder.Entity<Course>().HasOne(A => A.Department).WithMany(A => A.Courses)
            //    .HasForeignKey(A => new { A.ColName, A.DeptName });
            //modelBuilder.Entity<Source>().HasOne(A => A.Course).WithMany(A => A.Sources)
            //    .HasForeignKey(A => new { A.CrsName, A.DeptName });

        }
        public virtual DbSet<Admin> Users { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<BuyingCart> BuyingCarts { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<CourseProfessor> CourseProfessors { get; set; }


    }
}
