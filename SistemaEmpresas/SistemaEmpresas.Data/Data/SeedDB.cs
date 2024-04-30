using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEmpresas.Data.Data
{
	public class SeedDb
	{
		private readonly ApplicationDbContext context;

		public SeedDb(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task SeedAsync()
		{
			await context.Database.EnsureCreatedAsync();

			// Verificar si ya existen datos
			if (!context.Empresas.Any())
			{
				var empresa = new EmpresaEntity()
				{
					Nombre = "Banco Agricola",
					RazonSocial = "Bancos",
					FechaRegistro = DateTime.Now,
				};
				context.Empresas.Add(empresa);
				await context.SaveChangesAsync();
			}
		}
	}
}