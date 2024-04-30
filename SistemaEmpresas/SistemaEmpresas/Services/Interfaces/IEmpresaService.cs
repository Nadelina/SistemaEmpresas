using SistemaEmpresas.Api.Models;

namespace SistemaEmpresas.Api.Services.Interfaces
{
	public interface IEmpresaService
	{
		//contratos
		IEnumerable<Empresa> GetAll();
		Empresa GetById(int id);
		Task<Empresa> ObtenerConDepartamentos(int id);
	}
}
