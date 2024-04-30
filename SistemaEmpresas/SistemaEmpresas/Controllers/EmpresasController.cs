using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEmpresas.Api.Models;
using SistemaEmpresas.Api.Services.Interfaces;

namespace SistemaEmpresas.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpresasController : ControllerBase
	{
        private readonly IEmpresaService _empresaService;
        public EmpresasController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

		[HttpGet("lista")]
		public ActionResult<List<Empresa>> ObtenerLista()
		{
			return _empresaService.GetAll().ToList();
		}
		[HttpGet("{id}")]
		public ActionResult<Empresa> ObtenerPorId(int id)
		{
			return _empresaService.GetById(id);
		}
		
		[HttpGet("ObtenerConDepartamentosPorId/{id}")]
		public async Task<ActionResult<Empresa>> ObtenerConDepartamentosPorId(int id)
		{
			return await _empresaService.ObtenerConDepartamentos(id);
		}

	}
}
