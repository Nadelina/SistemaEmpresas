using Microsoft.EntityFrameworkCore;
using SistemaEmpresas.Data.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<EmpresaEntity> Empresas { get; set; } 
	public DbSet<DepartamentoEntity> Departamentos { get; set; } 
	public DbSet<BitacoraEntity> Bitacoras { get; set; } 

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<EmpresaEntity>()
			.HasKey(e => e.EmpresaId);

		modelBuilder.Entity<DepartamentoEntity>()
			.HasKey(d => d.DepartamentoId);

		modelBuilder.Entity<EmpresaEntity>()
			.HasMany(e => e.Departamentos)
			.WithOne(d => d.Empresa)
			.HasForeignKey(d => d.EmpresaId);
	}
}