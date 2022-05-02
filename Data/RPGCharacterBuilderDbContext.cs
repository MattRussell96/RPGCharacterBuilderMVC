using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RPGCharacterBuilderMVC.Models.Armor;
using RPGCharacterBuilderMVC.Models.Weapon;
using RPGCharacterBuilderMVC.Models.MagicItem;

#nullable disable

namespace RPGCharacterBuilderMVC.Data
{
    public partial class RPGCharacterBuilderDbContext : DbContext
    {
        public RPGCharacterBuilderDbContext()
        {
        }

        public RPGCharacterBuilderDbContext(DbContextOptions<RPGCharacterBuilderDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Armor> Armors { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<MagicItem> MagicItems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=ConnectionStrings:RPGLocal");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Armor>(entity =>
            {
                entity.ToTable("Armor");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Armors)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Armor__Character__5BE2A6F2");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CharacterNavigation)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Character__Chara__4BAC3F29");
            });

            modelBuilder.Entity<MagicItem>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.MagicItems)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MagicItem__Chara__5DCAEF64");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.GamerTag)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.Property(e => e.MagicDamage)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Weapons__Charact__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<RPGCharacterBuilderMVC.Models.Armor.ArmorDetailModel> ArmorDetailModel { get; set; }

        public DbSet<RPGCharacterBuilderMVC.Models.Armor.ArmorEditModel> ArmorEditModel { get; set; }

        public DbSet<RPGCharacterBuilderMVC.Models.Weapon.WeaponDetailModel> WeaponDetailModel { get; set; }

        public DbSet<RPGCharacterBuilderMVC.Models.Weapon.WeaponEditModel> WeaponEditModel { get; set; }

        public DbSet<RPGCharacterBuilderMVC.Models.MagicItem.MagicItemDetailModel> MagicItemDetailModel { get; set; }

        public DbSet<RPGCharacterBuilderMVC.Models.MagicItem.MagicItemEditModel> MagicItemEditModel { get; set; }
    }
}
