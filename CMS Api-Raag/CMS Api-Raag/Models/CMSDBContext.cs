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
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= RISVANASHERIN\\SQLEXPRESS; Initial Catalog= CMSDB; Integrated security=True");
            }
        }
        */
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
                    .HasConstraintName("FK__admin__EmployeeI__46E78A0C");
            });

            modelBuilder.Entity<Appoinment>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__Appoinme__8ECDFCC259BF2251");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Appoinment)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Appoinmen__Emplo__5070F446");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appoinment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appoinmen__Patie__4F7CD00D");
            });

            modelBuilder.Entity<ConsultationBillDetails>(entity =>
            {
                entity.HasKey(e => e.CbillId)
                    .HasName("PK__Consulta__F8C14421D5AEE033");

                entity.Property(e => e.CbillId).HasColumnName("CBillId");

                entity.Property(e => e.ConsultationFee).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.ConsultationBillDetails)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Consultat__Appoi__02FC7413");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ConsultationBillDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Consultat__Emplo__03F0984C");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__Departme__DB9CAA5FA44FD290");

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
                    .HasConstraintName("FK__Doctor__DepId__534D60F1");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Doctor__Employee__5441852A");
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
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Employee__RoleId__440B1D61");
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
                    .HasConstraintName("FK__Medicine__AdminI__49C3F6B7");
            });

            modelBuilder.Entity<MedicineBill>(entity =>
            {
                entity.HasKey(e => e.MbillId)
                    .HasName("PK__Medicine__407BBE89C5E72145");

                entity.Property(e => e.MbillId).HasColumnName("MBillId");

                entity.Property(e => e.MedicinePrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__MedicineB__Appoi__1332DBDC");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__MedicineB__Presc__123EB7A3");
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
                    .HasMaxLength(50)
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
                    .HasName("PK__Prescrib__5C86FF46556EA298");

                entity.Property(e => e.Pmid).HasColumnName("PMId");

                entity.HasOne(d => d.Dosage)
                    .WithMany(p => p.PrescribedMedicine)
                    .HasForeignKey(d => d.DosageId)
                    .HasConstraintName("FK__Prescribe__Dosag__0B91BA14");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescribedMedicine)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Prescribe__Medic__0A9D95DB");
            });

            modelBuilder.Entity<PrescribedTest>(entity =>
            {
                entity.HasKey(e => e.Ptid)
                    .HasName("PK__Prescrib__BCC07F6FD2BD5832");

                entity.Property(e => e.Ptid).HasColumnName("PTId");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.PrescribedTest)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__Prescribe__TestI__19DFD96B");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.PrescribedTest)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK__Prescribe__UnitI__1AD3FDA4");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Prescript__Appoi__06CD04F7");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Prescript__Docto__07C12930");
            });

            modelBuilder.Entity<PrescriptionDetails>(entity =>
            {
                entity.HasKey(e => e.PdetailsId)
                    .HasName("PK__prescrip__958A8F2448F512EC");

                entity.ToTable("prescriptionDetails");

                entity.Property(e => e.PdetailsId).HasColumnName("PDetailsId");

                entity.Property(e => e.Pmid).HasColumnName("PMId");

                entity.HasOne(d => d.Pm)
                    .WithMany(p => p.PrescriptionDetails)
                    .HasForeignKey(d => d.Pmid)
                    .HasConstraintName("FK__prescripti__PMId__0F624AF8");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.PrescriptionDetails)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__prescript__Presc__0E6E26BF");
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
                    .HasConstraintName("FK__Test__UnitId__4CA06362");
            });

            modelBuilder.Entity<TestBill>(entity =>
            {
                entity.HasKey(e => e.TbillId)
                    .HasName("PK__TestBill__0B03DA00223FC2A4");

                entity.Property(e => e.TbillId).HasColumnName("TBillId");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TestBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__TestBill__Appoin__22751F6C");

                entity.HasOne(d => d.Tprescription)
                    .WithMany(p => p.TestBill)
                    .HasForeignKey(d => d.TprescriptionId)
                    .HasConstraintName("FK__TestBill__Tpresc__2180FB33");
            });

            modelBuilder.Entity<TestDetails>(entity =>
            {
                entity.HasKey(e => e.Tdid)
                    .HasName("PK__TestDeta__B7317AA405B6A4B7");

                entity.Property(e => e.Tdid).HasColumnName("TDId");

                entity.Property(e => e.NormalRange)
                    .IsRequired()
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
                    .HasConstraintName("FK__TestDetail__PTId__1EA48E88");

                entity.HasOne(d => d.Tprescription)
                    .WithMany(p => p.TestDetails)
                    .HasForeignKey(d => d.TprescriptionId)
                    .HasConstraintName("FK__TestDetai__TPres__1DB06A4F");
            });

            modelBuilder.Entity<TestPrescription>(entity =>
            {
                entity.HasKey(e => e.TprescriptionId)
                    .HasName("PK__TestPres__475D5D2D70D70BA9");

                entity.Property(e => e.TprescriptionId).HasColumnName("TPrescriptionId");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TestPrescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__TestPresc__Appoi__17036CC0");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TestPrescription)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__TestPresc__Docto__160F4887");
            });

            modelBuilder.Entity<TestUnit>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK__TestUnit__44F5ECB52B5EB4F7");

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
                    .HasName("PK__Token__5D639BD1D23CECA8");

                entity.Property(e => e.TokenNo).ValueGeneratedOnAdd();

                entity.Property(e => e.TokenDate).HasColumnType("date");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Token)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Token__Appointme__29221CFB");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Token)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Token__DoctorId__2A164134");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
