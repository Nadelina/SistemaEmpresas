using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaEmpresas.Data.Repositories.Interfaces;
using System.Reflection.Metadata;

namespace SistemaEmpresas.Data.Repositories
{
	public class EmpresaRepository : GenericRepository<EmpresaEntity>, IEmpresaRepository
	{
		private readonly ApplicationDbContext _context;
		public EmpresaRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
		public EmpresaEntity ObtenerPorIdAsync(int id)
		{
			var parametros = new SqlParameter("@Id", id);
			var empresa =  _context.Set<EmpresaEntity>().FromSqlRaw("EXEC GetEmpresaById @Id", parametros)
				.AsEnumerable().FirstOrDefault();

			return empresa; 
		}
		
		public async Task<EmpresaEntity> ObtenerConDepartamentosPorIdAsync(int id)
		{
			var empresa = await _context.Empresas
								.FirstOrDefaultAsync(e => e.EmpresaId == id);

			if (empresa != null)
			{
				await _context.Entry(empresa)
							  .Collection(b => b.Departamentos)
							  .LoadAsync();
			}
			return empresa; 
		}
	}
}
