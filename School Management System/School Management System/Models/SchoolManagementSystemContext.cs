using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School_Management_System.Models;

public partial class SchoolManagementSystemContext : DbContext
{
    public SchoolManagementSystemContext()
    {
    }

    public SchoolManagementSystemContext(DbContextOptions<SchoolManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassAttendance> ClassAttendances { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Management> Managements { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HALA_MANSOUR\\SQLEXPRESS;Database=School Management System;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Class_At__57FA4934DE926EAD");

            entity.ToTable("Class_Attendance");

            entity.Property(e => e.AttendanceId).HasColumnName("Attendance_ID");
            entity.Property(e => e.AttendanceDate).HasColumnName("Attendance_Date");
            entity.Property(e => e.AttendeeStudentId).HasColumnName("Attendee_Student_ID");
            entity.Property(e => e.ClassCode).HasColumnName("Class_Code");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

            entity.HasOne(d => d.AttendeeStudent).WithMany(p => p.ClassAttendances)
                .HasForeignKey(d => d.AttendeeStudentId)
                .HasConstraintName("FK__Class_Att__Atten__4E88ABD4");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__37E005FB10EFA04A");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("Course_ID");
            entity.Property(e => e.CourseHours).HasColumnName("Course_Hours");
            entity.Property(e => e.CourseName)
                .HasColumnType("text")
                .HasColumnName("Course_Name");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Courses)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Course__Employee__403A8C7D");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__781134818D52530E");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("Employee_ID");
            entity.Property(e => e.EmployeeHiringDate).HasColumnName("Employee_Hiring_Date");
            entity.Property(e => e.EmployeePosition)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Employee_Position");
            entity.Property(e => e.EmployeeSalary).HasColumnName("Employee_Salary");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__FD6BEFE4449D98FF");

            entity.ToTable("Event");

            entity.Property(e => e.EventId)
                .ValueGeneratedNever()
                .HasColumnName("Event_ID");
            entity.Property(e => e.EventName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Event_Name");
            entity.Property(e => e.NumberOfAttendees).HasColumnName("Number_of_Attendees");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grade__D4437153BFC21829");

            entity.ToTable("Grade");

            entity.Property(e => e.GradeId)
                .ValueGeneratedNever()
                .HasColumnName("Grade_ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.StudentGrade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Student_Grade");
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.TotalGrade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Total_Grade");

            entity.HasOne(d => d.Course).WithMany(p => p.Grades)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Grade__Course_ID__48CFD27E");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Grade__Student_I__47DBAE45");
        });

        modelBuilder.Entity<Management>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Management");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.EventId).HasColumnName("Event_ID");
            entity.Property(e => e.ManagementEmployeeEmail)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Management_Employee_Email");
            entity.Property(e => e.ManagementEmployeeName)
                .HasColumnType("text")
                .HasColumnName("Management_Employee_Name");
            entity.Property(e => e.ManagementEmployeePhone).HasColumnName("Management_Employee_Phone");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Managemen__Emplo__38996AB5");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__A2F4E9ACE8C6ABA5");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("Student_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudentEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Student_Email");
            entity.Property(e => e.StudentGrade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Student_Grade");
            entity.Property(e => e.StudentLevel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Student_Level");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Student_Name");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Teacher");

            entity.Property(e => e.ClassCode).HasColumnName("Class_Code");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.TeacherEmail)
                .HasColumnType("text")
                .HasColumnName("Teacher_Email");
            entity.Property(e => e.TeacherName)
                .HasColumnType("text")
                .HasColumnName("Teacher_Name");
            entity.Property(e => e.TeacherPhone).HasColumnName("Teacher_Phone");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Teacher__Employe__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
