using Autobarn.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autobarn.Data;

public class AutobarnDbContext(
	DbContextOptions<AutobarnDbContext> options
) : DbContext(options)
{

		public virtual DbSet<VehicleMake> Makes { get; set; }
		public virtual DbSet<VehicleModel> Models { get; set; }
		public virtual DbSet<Vehicle> Vehicles { get; set; }

		protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
		{
				if (Database.IsSqlite())
				{
						configurationBuilder.Properties<string>().UseCollation("NOCASE");
				}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

				modelBuilder.Entity<VehicleMake>(entity =>
				{
						entity.HasKey(e => e.Code);
						entity.Property(e => e.Code).HasMaxLength(32).IsUnicode(false);
						entity.Property(e => e.Name).HasMaxLength(32).IsUnicode(false);
						entity.HasMany(e => e.Models).WithOne(m => m.VehicleMake).HasForeignKey(m => m.MakeCode);
				});

				modelBuilder.Entity<VehicleModel>(entity =>
				{
						entity.HasKey(e => e.Code);
						entity.Property(e => e.Code).HasMaxLength(32).IsUnicode(false);
						entity.Property(e => e.MakeCode).HasMaxLength(32).IsUnicode(false);
						entity.Property(e => e.Name).HasMaxLength(32).IsUnicode(false);
						entity.HasMany(e => e.Vehicles).WithOne(v => v.Model).HasForeignKey(v => v.ModelCode);
				});

				modelBuilder.Entity<Vehicle>(entity =>
				{
						entity.HasKey(e => e.Registration);
						entity.Property(e => e.Registration).HasMaxLength(16).IsUnicode(false);
						entity.Property(e => e.Color).HasMaxLength(32).IsUnicode(false);
						entity.Property(e => e.ModelCode).HasMaxLength(32).IsUnicode(false);
				});
		}
}
