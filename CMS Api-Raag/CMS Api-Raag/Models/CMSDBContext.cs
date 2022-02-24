using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CMS_Api_Raag.Models
{
    public partial class CMSDBContext : DbContext
    {
        public CMSDBContext()
        {
        }

        public CMSDBContext(DbContextOptions<CMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Appoinment> Appoinment { get; set; }
        public virtual DbSet<ConsultationBillDetails> ConsultationBillDetails { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<DoctorNotes> DoctorNotes { get; set; }
        public virtual DbSet<Dosage> Dosage { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<MedicineBill> MedicineBill { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PrescribedMedicine> PrescribedMedicine { get; set; }
        public virtual DbSet<PrescribedTest> PrescribedTest { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionDetails> PrescriptionDetails { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestBill> TestBill { get; set; }
        public virtual DbSet<TestDetails> TestDetails { get; set; }
        public virtual DbSet<TestPrescription> TestPrescription { get; set; }
        public virtual DbSet<TestUnit> TestUnit { get; set; }
        public virtual DbSet<Token> Token { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= GANESHA\\SQLEXPRESS; Initial Catalog= CMSDB; Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Admin)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__admin__EmployeeI__4316F928");
            });

            modelBuilder.Entity<Appoinment>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__Appoinme__8ECDFCC25872A285");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Appoinment)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Appoinmen__Emplo__4CA06362");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appoinment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appoinmen__Patie__4BAC3F29");
            });

            modelBuilder.Entity<ConsultationBillDetails>(entity =>
            {
                entity.HasKey(e => e.CbillId)
                    .HasName("PK__Consulta__F8C14421037E49B2");

                entity.Property(e => e.CbillId).HasColumnName("CBillId");

                entity.Property(e => e.ConsultationFee).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.ConsultationBillDetails)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Consultat__Appoi__571DF1D5");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ConsultationBillDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Consultat__Emplo__5812160E");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__Departme__DB9CAA5F444A12C6");

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__Doctor__DepId__4F7CD00D");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Doctor__Employee__5070F446");
            });

            modelBuilder.Entity<DoctorNotes>(entity =>
            {
                entity.HasKey(e => e.DnId)
                    .HasName("PK__DoctorNo__7A71D8BDF70C6951");

                entity.Property(e => e.Note)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.DoctorNotes)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__DoctorNot__Appoi__151B244E");
            });

            modelBuilder.Entity<Dosage>(entity =>
            {
                entity.Property(e => e.Dosage1)
                    .HasColumnName("Dosage")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Doj)
                    .HasColumnName("DOJ")
                    .HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Employee__RoleId__403A8C7D");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Medicine)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK__Medicine__AdminI__45F365D3");
            });

            modelBuilder.Entity<MedicineBill>(entity =>
            {
                entity.HasKey(e => e.MbillId)
                    .HasName("PK__Medicine__407BBE89BD23419C");

                entity.Property(e => e.MbillId).HasColumnName("MBillId");

                entity.Property(e => e.MedicinePrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__MedicineB__Appoi__6754599E");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__MedicineB__Presc__66603565");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrescribedMedicine>(entity =>
            {
                entity.HasKey(e => e.Pmid)
                    .HasName("PK__Prescrib__5C86FF467EE3BAA4");

                entity.Property(e => e.Pmid).HasColumnName("PMId");

                entity.HasOne(d => d.Dosage)
                    .WithMany(p => p.PrescribedMedicine)
                    .HasForeignKey(d => d.DosageId)
                    .HasConstraintName("FK__Prescribe__Dosag__5FB337D6");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescribedMedicine)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Prescribe__Medic__5EBF139D");
            });

            modelBuilder.Entity<PrescribedTest>(entity =>
            {
                entity.HasKey(e => e.Ptid)
                    .HasName("PK__Prescrib__BCC07F6FA6DE4EE3");

                entity.Property(e => e.Ptid).HasColumnName("PTId");

                entity.Property(e => e.NormalRange)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.PrescribedTest)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__Prescribe__TestI__6E01572D");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.PrescribedTest)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK__Prescribe__UnitI__6EF57B66");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Prescript__Appoi__5AEE82B9");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Prescript__Docto__5BE2A6F2");
            });

            modelBuilder.Entity<PrescriptionDetails>(entity =>
            {
                entity.HasKey(e => e.PdetailsId)
                    .HasName("PK__prescrip__958A8F246E99FE4F");

                entity.ToTable("prescriptionDetails");

                entity.Property(e => e.PdetailsId).HasColumnName("PDetailsId");

                entity.Property(e => e.Pmid).HasColumnName("PMId");

                entity.HasOne(d => d.Pm)
                    .WithMany(p => p.PrescriptionDetails)
                    .HasForeignKey(d => d.Pmid)
                    .HasConstraintName("FK__prescripti__PMId__6383C8BA");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.PrescriptionDetails)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__prescript__Presc__628FA481");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.TestDescription)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TestType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK__Test__UnitId__48CFD27E");
            });

            modelBuilder.Entity<TestBill>(entity =>
            {
                entity.HasKey(e => e.TbillId)
                    .HasName("PK__TestBill__0B03DA007FE38E9B");

                entity.Property(e => e.TbillId).HasColumnName("TBillId");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TestBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__TestBill__Appoin__76969D2E");

                entity.HasOne(d => d.Tprescription)
                    .WithMany(p => p.TestBill)
                    .HasForeignKey(d => d.TprescriptionId)
                    .HasConstraintName("FK__TestBill__Tpresc__75A278F5");
            });

            modelBuilder.Entity<TestDetails>(entity =>
            {
                entity.HasKey(e => e.Tdid)
                    .HasName("PK__TestDeta__B7317AA470698DBA");

                entity.Property(e => e.Tdid).HasColumnName("TDId");

                entity.Property(e => e.NormalRange)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Ptid).HasColumnName("PTId");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TprescriptionId).HasColumnName("TPrescriptionId");

                entity.HasOne(d => d.Pt)
                    .WithMany(p => p.TestDetails)
                    .HasForeignKey(d => d.Ptid)
                    .HasConstraintName("FK__TestDetail__PTId__72C60C4A");

                entity.HasOne(d => d.Tprescription)
                    .WithMany(p => p.TestDetails)
                    .HasForeignKey(d => d.TprescriptionId)
                    .HasConstraintName("FK__TestDetai__TPres__71D1E811");
            });

            modelBuilder.Entity<TestPrescription>(entity =>
            {
                entity.HasKey(e => e.TprescriptionId)
                    .HasName("PK__TestPres__475D5D2D0687515D");

                entity.Property(e => e.TprescriptionId).HasColumnName("TPrescriptionId");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TestPrescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__TestPresc__Appoi__6B24EA82");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TestPrescription)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__TestPresc__Docto__6A30C649");
            });

            modelBuilder.Entity<TestUnit>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK__TestUnit__44F5ECB56BC75F82");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.HasKey(e => new { e.TokenNo, e.AppointmentId })
                    .HasName("PK__Token__5D639BD1F5B5C81B");

                entity.Property(e => e.TokenNo).ValueGeneratedOnAdd();

                entity.Property(e => e.TokenDate).HasColumnType("date");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Token)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Token__Appointme__534D60F1");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Token)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Token__DoctorId__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
