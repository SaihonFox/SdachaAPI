using Microsoft.EntityFrameworkCore;

namespace MedicalServicesAPI.Model;

public partial class DiplomContext : DbContext
{
	public DiplomContext() {}

	public DiplomContext(DbContextOptions<DiplomContext> options) : base(options) {}

	public virtual DbSet<AdBlock> AdBlocks { get; set; }

	public virtual DbSet<Analysis> Analyses { get; set; }

	public virtual DbSet<AnalysisCategory> AnalysisCategories { get; set; }

	public virtual DbSet<AnalysisOrder> AnalysisOrders { get; set; }

	public virtual DbSet<EmailList> EmailLists { get; set; }

	public virtual DbSet<LoginList> LoginLists { get; set; }

	public virtual DbSet<Message> Messages { get; set; }

	public virtual DbSet<MessagesMessage> MessagesMessages { get; set; }

	public virtual DbSet<PassportList> PassportLists { get; set; }

	public virtual DbSet<Patient> Patients { get; set; }

	public virtual DbSet<PatientAnalysisAddress> PatientAnalysisAddresses { get; set; }

	public virtual DbSet<PatientAnalysisCart> PatientAnalysisCarts { get; set; }

	public virtual DbSet<PatientAnalysisCartItem> PatientAnalysisCartItems { get; set; }

	public virtual DbSet<PatientsDataList> PatientsDataLists { get; set; }

	public virtual DbSet<PhoneList> PhoneLists { get; set; }

	public virtual DbSet<User> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseMySql("server=localhost;password=12345;database=diplom;user=root", ServerVersion.Parse("8.0.38-mysql"));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.UseCollation("utf8mb4_0900_ai_ci")
			.HasCharSet("utf8mb4");

		modelBuilder.Entity<AdBlock>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("ad_block");

			entity.HasIndex(e => e.AnalysisId, "analysis_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.AnalysisId).HasColumnName("analysis_id");
			entity.Property(e => e.DateEnd)
				.HasColumnType("datetime")
				.HasColumnName("date_end");
			entity.Property(e => e.DateStart)
				.HasColumnType("datetime")
				.HasColumnName("date_start");
			entity.Property(e => e.Description)
				.HasColumnType("text")
				.HasColumnName("description");
			entity.Property(e => e.Name)
				.HasColumnType("text")
				.HasColumnName("name");
			entity.Property(e => e.Price)
				.HasPrecision(10, 2)
				.HasColumnName("price");
			entity.Property(e => e.Sex)
				.HasColumnType("text")
				.HasColumnName("sex");

			entity.HasOne(d => d.Analysis).WithMany(p => p.AdBlocks)
				.HasForeignKey(d => d.AnalysisId)
				.HasConstraintName("ad_block_ibfk_1");
		});

		modelBuilder.Entity<Analysis>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("analysis");

			entity.HasIndex(e => e.AnalysisCategory, "analysis_category");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.AnalysisCategory).HasColumnName("analysis_category");
			entity.Property(e => e.Biomaterial)
				.HasColumnType("text")
				.HasColumnName("biomaterial");
			entity.Property(e => e.Description)
				.HasColumnType("text")
				.HasColumnName("description");
			entity.Property(e => e.Name)
				.HasColumnType("text")
				.HasColumnName("name");
			entity.Property(e => e.Preparation)
				.HasColumnType("text")
				.HasColumnName("preparation");
			entity.Property(e => e.Price)
				.HasPrecision(10, 2)
				.HasColumnName("price");
			entity.Property(e => e.ResultsAfter)
				.HasColumnType("text")
				.HasColumnName("results_after");

			entity.HasOne(d => d.AnalysisCategoryNavigation).WithMany(p => p.Analyses)
				.HasForeignKey(d => d.AnalysisCategory)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("analysis_ibfk_1");
		});

		modelBuilder.Entity<AnalysisCategory>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("analysis_category");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Name)
				.HasColumnType("text")
				.HasColumnName("name");
		});

		modelBuilder.Entity<AnalysisOrder>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("analysis_order");

			entity.HasIndex(e => e.PatientAnalysisAddress, "patient_analysis_address");

			entity.HasIndex(e => e.PatientAnalysisCart, "patient_analysis_cart");

			entity.HasIndex(e => e.PatientId, "patient_id");

			entity.HasIndex(e => e.UserId, "user_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.AnalysisDatetime)
				.HasColumnType("datetime")
				.HasColumnName("analysis_datetime");
			entity.Property(e => e.Comment)
				.HasColumnType("text")
				.HasColumnName("comment");
			entity.Property(e => e.PatientAnalysisAddress).HasColumnName("patient_analysis_address");
			entity.Property(e => e.PatientAnalysisCart).HasColumnName("patient_analysis_cart");
			entity.Property(e => e.PatientId).HasColumnName("patient_id");
			entity.Property(e => e.RegistrationDate)
				.HasColumnType("datetime")
				.HasColumnName("registration_date");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.PatientAnalysisAddressNavigation).WithMany(p => p.AnalysisOrders)
				.HasForeignKey(d => d.PatientAnalysisAddress)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("analysis_order_ibfk_4");

			entity.HasOne(d => d.PatientAnalysisCartNavigation).WithMany(p => p.AnalysisOrders)
				.HasForeignKey(d => d.PatientAnalysisCart)
				.HasConstraintName("analysis_order_ibfk_3");

			entity.HasOne(d => d.Patient).WithMany(p => p.AnalysisOrders)
				.HasForeignKey(d => d.PatientId)
				.HasConstraintName("analysis_order_ibfk_2");

			entity.HasOne(d => d.User).WithMany(p => p.AnalysisOrders)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("analysis_order_ibfk_1");
		});

		modelBuilder.Entity<EmailList>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("email_list");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Email)
				.HasColumnType("text")
				.HasColumnName("email");
		});

		modelBuilder.Entity<LoginList>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("login_list");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Login)
				.HasMaxLength(20)
				.HasColumnName("login");
		});

		modelBuilder.Entity<Message>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("messages");

			entity.HasIndex(e => e.PatientId, "patient_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.PatientId).HasColumnName("patient_id");

			entity.HasOne(d => d.Patient).WithMany(p => p.Messages)
				.HasForeignKey(d => d.PatientId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("messages_ibfk_1");
		});

		modelBuilder.Entity<MessagesMessage>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("messages_message");

			entity.HasIndex(e => e.MessagesId, "messages_id");

			entity.HasIndex(e => e.PatientId, "patient_id");

			entity.HasIndex(e => e.UserId, "user_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Message)
				.HasColumnType("text")
				.HasColumnName("message");
			entity.Property(e => e.MessagesId).HasColumnName("messages_id");
			entity.Property(e => e.PatientId).HasColumnName("patient_id");
			entity.Property(e => e.Time)
				.HasColumnType("datetime")
				.HasColumnName("time");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.Messages).WithMany(p => p.MessagesMessages)
				.HasForeignKey(d => d.MessagesId)
				.HasConstraintName("messages_message_ibfk_1");

			entity.HasOne(d => d.Patient).WithMany(p => p.MessagesMessages)
				.HasForeignKey(d => d.PatientId)
				.HasConstraintName("messages_message_ibfk_3");

			entity.HasOne(d => d.User).WithMany(p => p.MessagesMessages)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("messages_message_ibfk_2");
		});

		modelBuilder.Entity<PassportList>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("passport_list");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Passport)
				.HasMaxLength(10)
				.HasColumnName("passport");
		});

		modelBuilder.Entity<Patient>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("patient");

			entity.HasIndex(e => e.EmailId, "email_id");

			entity.HasIndex(e => e.LoginId, "login_id");

			entity.HasIndex(e => e.PassportId, "passport_id");

			entity.HasIndex(e => e.PhoneId, "phone_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Birthday).HasColumnName("birthday");
			entity.Property(e => e.EmailId).HasColumnName("email_id");
			entity.Property(e => e.Image).HasColumnName("image");
			entity.Property(e => e.LoginId).HasColumnName("login_id");
			entity.Property(e => e.Name)
				.HasColumnType("text")
				.HasColumnName("name");
			entity.Property(e => e.PassportId).HasColumnName("passport_id");
			entity.Property(e => e.Password)
				.HasMaxLength(20)
				.HasDefaultValueSql("'123'")
				.HasColumnName("password");
			entity.Property(e => e.Patronym)
				.HasColumnType("text")
				.HasColumnName("patronym");
			entity.Property(e => e.PhoneId).HasColumnName("phone_id");
			entity.Property(e => e.Sex)
				.HasColumnType("enum('Мужской','Женский')")
				.HasColumnName("sex");
			entity.Property(e => e.Surname)
				.HasColumnType("text")
				.HasColumnName("surname");

			entity.HasOne(d => d.Email).WithMany(p => p.Patients)
				.HasForeignKey(d => d.EmailId)
				.HasConstraintName("patient_ibfk_3");

			entity.HasOne(d => d.Login).WithMany(p => p.Patients)
				.HasForeignKey(d => d.LoginId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("patient_ibfk_4");

			entity.HasOne(d => d.Passport).WithMany(p => p.Patients)
				.HasForeignKey(d => d.PassportId)
				.HasConstraintName("patient_ibfk_1");

			entity.HasOne(d => d.Phone).WithMany(p => p.Patients)
				.HasForeignKey(d => d.PhoneId)
				.HasConstraintName("patient_ibfk_2");
		});

		modelBuilder.Entity<PatientAnalysisAddress>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("patient_analysis_address");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Address)
				.HasColumnType("text")
				.HasColumnName("address");
			entity.Property(e => e.Entrance).HasColumnName("entrance");
			entity.Property(e => e.Floor).HasColumnName("floor");
			entity.Property(e => e.Intercome)
				.HasColumnType("text")
				.HasColumnName("intercome");
			entity.Property(e => e.Room).HasColumnName("room");
		});

		modelBuilder.Entity<PatientAnalysisCart>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("patient_analysis_cart");

			entity.HasIndex(e => e.PatientId, "patient_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.PatientId).HasColumnName("patient_id");

			entity.HasOne(d => d.Patient).WithMany(p => p.PatientAnalysisCarts)
				.HasForeignKey(d => d.PatientId)
				.HasConstraintName("patient_analysis_cart_ibfk_1");
		});

		modelBuilder.Entity<PatientAnalysisCartItem>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("patient_analysis_cart_item");

			entity.HasIndex(e => e.AnalysisId, "analysis_id");

			entity.HasIndex(e => e.PatientAnalysisCart, "patient_analysis_cart");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.AnalysisId).HasColumnName("analysis_id");
			entity.Property(e => e.Count).HasColumnName("count");
			entity.Property(e => e.PatientAnalysisCart).HasColumnName("patient_analysis_cart");

			entity.HasOne(d => d.Analysis).WithMany(p => p.PatientAnalysisCartItems)
				.HasForeignKey(d => d.AnalysisId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("patient_analysis_cart_item_ibfk_1");

			entity.HasOne(d => d.PatientAnalysisCartNavigation).WithMany(p => p.PatientAnalysisCartItems)
				.HasForeignKey(d => d.PatientAnalysisCart)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("patient_analysis_cart_item_ibfk_2");
		});

		modelBuilder.Entity<PatientsDataList>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("patients_data_list");

			entity.HasIndex(e => e.PatientId, "patient_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.ChangeDt)
				.HasColumnType("datetime")
				.HasColumnName("change_dt");
			entity.Property(e => e.Email)
				.HasColumnType("text")
				.HasColumnName("email");
			entity.Property(e => e.Login)
				.HasMaxLength(20)
				.HasColumnName("login");
			entity.Property(e => e.Method)
				.HasColumnType("text")
				.HasColumnName("method");
			entity.Property(e => e.Name)
				.HasColumnType("text")
				.HasColumnName("name");
			entity.Property(e => e.Passport)
				.HasMaxLength(10)
				.HasColumnName("passport");
			entity.Property(e => e.PatientId).HasColumnName("patient_id");
			entity.Property(e => e.Patronym)
				.HasColumnType("text")
				.HasColumnName("patronym");
			entity.Property(e => e.Phone)
				.HasMaxLength(11)
				.HasColumnName("phone");
			entity.Property(e => e.Surname)
				.HasColumnType("text")
				.HasColumnName("surname");

			entity.HasOne(d => d.Patient).WithMany(p => p.PatientsDataLists)
				.HasForeignKey(d => d.PatientId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("patients_data_list_ibfk_1");
		});

		modelBuilder.Entity<PhoneList>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("phone_list");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Phone)
				.HasMaxLength(11)
				.HasColumnName("phone");
		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("user");

			entity.HasIndex(e => e.LoginId, "login_id");

			entity.HasIndex(e => e.PassportId, "passport_id");

			entity.HasIndex(e => e.PhoneId, "phone_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Birthday).HasColumnName("birthday");
			entity.Property(e => e.Image).HasColumnName("image");
			entity.Property(e => e.LoginId).HasColumnName("login_id");
			entity.Property(e => e.Name)
				.HasColumnType("text")
				.HasColumnName("name");
			entity.Property(e => e.PassportId).HasColumnName("passport_id");
			entity.Property(e => e.Password)
				.HasMaxLength(20)
				.HasDefaultValueSql("'123'")
				.HasColumnName("password");
			entity.Property(e => e.Patronym)
				.HasColumnType("text")
				.HasColumnName("patronym");
			entity.Property(e => e.PhoneId).HasColumnName("phone_id");
			entity.Property(e => e.Post).HasColumnName("post");
			entity.Property(e => e.Surname)
				.HasColumnType("text")
				.HasColumnName("surname");

			entity.HasOne(d => d.Login).WithMany(p => p.Users)
				.HasForeignKey(d => d.LoginId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("user_ibfk_3");

			entity.HasOne(d => d.Passport).WithMany(p => p.Users)
				.HasForeignKey(d => d.PassportId)
				.HasConstraintName("user_ibfk_1");

			entity.HasOne(d => d.Phone).WithMany(p => p.Users)
				.HasForeignKey(d => d.PhoneId)
				.HasConstraintName("user_ibfk_2");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}