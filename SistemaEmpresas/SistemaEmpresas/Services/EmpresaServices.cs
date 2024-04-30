using AutoMapper;
using SistemaEmpresas.Api.Models;
using SistemaEmpresas.Api.Services.Interfaces;
using SistemaEmpresas.Data.Repositories.Interfaces;

namespace SistemaEmpresas.Api.Services
{
	public class EmpresaServices : IEmpresaService
	{
		private readonly IEmpresaRepository _empresaRepository;
		private readonly IMapper _mapper;

		public EmpresaServices(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
			_mapper = mapper;
		}

		public IEnumerable<Empresa> GetAll()
		{
			return _mapper.Map<List<Empresa>>(_empresaRepository.GetAll().ToList());
		}

		public Empresa GetById(int id)
		{
			return _mapper.Map<Empresa>(_empresaRepository.ObtenerPorIdAsync(id));
		}
		
		public async Task<Empresa> ObtenerConDepartamentos(int id)
		{
			return _mapper.Map<Empresa>(await _empresaRepository.ObtenerConDepartamentosPorIdAsync(id));
		}
	}
}
