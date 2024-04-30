using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEmpresas.Data.Repositories.Interfaces
{
	public interface IEmpresaRepository : IGenericRepository<EmpresaEntity>
	{
		EmpresaEntity ObtenerPorIdAsync(int id);
		Task<EmpresaEntity> ObtenerConDepartamentosPorIdAsync(int id);
	}
}
