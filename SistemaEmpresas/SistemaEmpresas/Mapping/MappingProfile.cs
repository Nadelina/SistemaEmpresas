using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEmpresas.Api.Models;

namespace SistemaEmpresas.Api.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<EmpresaEntity, Empresa>().ReverseMap();
		}
	}
}