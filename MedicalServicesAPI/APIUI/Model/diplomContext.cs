using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace APIUI.Model;

public partial class diplomContext : DbContext
{
    public diplomContext()
    {
    }

    public diplomContext(DbContextOptions<diplomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ad_block> ad_blocks { get; set; }

    public virtual DbSet<analysis> analyses { get; set; }

    public virtual DbSet<analysis_category> analysis_categories { get; set; }

    public virtual DbSet<analysis_order> analysis_orders { get; set; }

    public virtual DbSet<message> messages { get; set; }

    public virtual DbSet<messages_message> messages_messages { get; set; }

    public virtual DbSet<patient> patients { get; set; }

    public virtual DbSet<patient_analysis_address> patient_analysis_addresses { get; set; }

    public virtual DbSet<patient_analysis_cart> patient_analysis_carts { get; set; }

    public virtual DbSet<patient_analysis_cart_item> patient_analysis_cart_items { get; set; }

    public virtual DbSet<user> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;password=12345;database=diplom;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.38-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ad_block>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("ad_block");

            entity.HasIndex(e => e.analysis_id, "analysis_id");

            entity.Property(e => e.date_end).HasColumnType("datetime");
            entity.Property(e => e.date_start).HasColumnType("datetime");
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.name).HasColumnType("text");
            entity.Property(e => e.price).HasPrecision(10, 2);
            entity.Property(e => e.sex).HasColumnType("text");

            entity.HasOne(d => d.analysis).WithMany(p => p.ad_blocks)
                .HasForeignKey(d => d.analysis_id)
                .HasConstraintName("ad_block_ibfk_1");
        });

        modelBuilder.Entity<analysis>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("analysis");

            entity.HasIndex(e => e.analyses_category_id, "analyses_category_id");

            entity.Property(e => e.biomaterial).HasColumnType("text");
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.name).HasColumnType("text");
            entity.Property(e => e.preparation).HasColumnType("text");
            entity.Property(e => e.price).HasPrecision(10, 2);
            entity.Property(e => e.results_after).HasColumnType("datetime");

            entity.HasOne(d => d.analyses_category).WithMany(p => p.analyses)
                .HasForeignKey(d => d.analyses_category_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("analysis_ibfk_1");
        });

        modelBuilder.Entity<analysis_category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("analysis_category");

            entity.Property(e => e.name).HasColumnType("text");
        });

        modelBuilder.Entity<analysis_order>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("analysis_order");

            entity.HasIndex(e => e.patient_analysis_address_id, "patient_analysis_address_id");

            entity.HasIndex(e => e.patient_analysis_cart_id, "patient_analysis_cart_id");

            entity.HasIndex(e => e.patient_id, "patient_id");

            entity.HasIndex(e => e.user_id, "user_id");

            entity.Property(e => e.analysis_datetime).HasColumnType("datetime");
            entity.Property(e => e.comment).HasColumnType("text");
            entity.Property(e => e.registration_date).HasColumnType("datetime");

            entity.HasOne(d => d.patient_analysis_address).WithMany(p => p.analysis_orders)
                .HasForeignKey(d => d.patient_analysis_address_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("analysis_order_ibfk_4");

            entity.HasOne(d => d.patient_analysis_cart).WithMany(p => p.analysis_orders)
                .HasForeignKey(d => d.patient_analysis_cart_id)
                .HasConstraintName("analysis_order_ibfk_3");

            entity.HasOne(d => d.patient).WithMany(p => p.analysis_orders)
                .HasForeignKey(d => d.patient_id)
                .HasConstraintName("analysis_order_ibfk_2");

            entity.HasOne(d => d.user).WithMany(p => p.analysis_orders)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("analysis_order_ibfk_1");
        });

        modelBuilder.Entity<message>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.patient_id, "patient_id");

            entity.HasOne(d => d.patient).WithMany(p => p.messages)
                .HasForeignKey(d => d.patient_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("messages_ibfk_1");
        });

        modelBuilder.Entity<messages_message>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("messages_message");

            entity.HasIndex(e => e.messages_id, "messages_id");

            entity.HasIndex(e => e.patient_id, "patient_id");

            entity.HasIndex(e => e.user_id, "user_id");

            entity.Property(e => e.message).HasColumnType("text");
            entity.Property(e => e.time).HasColumnType("datetime");

            entity.HasOne(d => d.messages).WithMany(p => p.messages_messages)
                .HasForeignKey(d => d.messages_id)
                .HasConstraintName("messages_message_ibfk_1");

            entity.HasOne(d => d.patient).WithMany(p => p.messages_messages)
                .HasForeignKey(d => d.patient_id)
                .HasConstraintName("messages_message_ibfk_3");

            entity.HasOne(d => d.user).WithMany(p => p.messages_messages)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("messages_message_ibfk_2");
        });

        modelBuilder.Entity<patient>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("patient");

            entity.Property(e => e.email).HasColumnType("text");
            entity.Property(e => e.login).HasColumnType("text");
            entity.Property(e => e.name).HasColumnType("text");
            entity.Property(e => e.passport).HasMaxLength(10);
            entity.Property(e => e.password).HasColumnType("text");
            entity.Property(e => e.patronym).HasColumnType("text");
            entity.Property(e => e.phone).HasMaxLength(11);
            entity.Property(e => e.sex).HasColumnType("enum('Мужской','Женский')");
            entity.Property(e => e.surname).HasColumnType("text");
        });

        modelBuilder.Entity<patient_analysis_address>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("patient_analysis_address");

            entity.Property(e => e.address).HasColumnType("text");
            entity.Property(e => e.intercome).HasColumnType("text");
        });

        modelBuilder.Entity<patient_analysis_cart>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("patient_analysis_cart");

            entity.HasIndex(e => e.patient_id, "patient_id");

            entity.HasOne(d => d.patient).WithMany(p => p.patient_analysis_carts)
                .HasForeignKey(d => d.patient_id)
                .HasConstraintName("patient_analysis_cart_ibfk_1");
        });

        modelBuilder.Entity<patient_analysis_cart_item>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("patient_analysis_cart_item");

            entity.HasIndex(e => e.analysis_id, "analysis_id");

            entity.HasIndex(e => e.patient_analysis_cart_id, "patient_analysis_cart_id");

            entity.HasOne(d => d.analysis).WithMany(p => p.patient_analysis_cart_items)
                .HasForeignKey(d => d.analysis_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patient_analysis_cart_item_ibfk_1");

            entity.HasOne(d => d.patient_analysis_cart).WithMany(p => p.patient_analysis_cart_items)
                .HasForeignKey(d => d.patient_analysis_cart_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patient_analysis_cart_item_ibfk_2");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.login).HasMaxLength(20);
            entity.Property(e => e.name).HasColumnType("text");
            entity.Property(e => e.passport).HasMaxLength(10);
            entity.Property(e => e.password)
                .HasMaxLength(20)
                .HasDefaultValueSql("'123'");
            entity.Property(e => e.patronym).HasColumnType("text");
            entity.Property(e => e.phone).HasMaxLength(11);
            entity.Property(e => e.surname).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
