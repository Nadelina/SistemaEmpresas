using AutoMapper;
using Moq;
using SistemaEmpresas.Api.Models;
using SistemaEmpresas.Api.Services;
using SistemaEmpresas.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEmpresas.Tests.Services
{
	public class EmpresaServiceTests
	{
		[Fact]
		public void ObtieneTodasLasEmpresasCorrectamente()
		{
			// Arrange
			var mockEmpresaRepository = new Mock<IEmpresaRepository>();
			var mockMapper = new Mock<IMapper>();

			var empresasEntities = GetTestEmpresas().AsQueryable();
			var empresas = empresasEntities.Select(e => new Empresa { EmpresaId = e.EmpresaId, Nombre = e.Nombre }).ToList();



			mockEmpresaRepository.Setup(repo => repo.GetAll()).Returns(empresasEntities);
			mockMapper.Setup(m => m.Map<List<Empresa>>(It.IsAny<List<EmpresaEntity>>())).Returns(empresas);


			var service = new EmpresaServices(mockEmpresaRepository.Object, mockMapper.Object);

			// Act
			var result = service.GetAll();

			// Assert
			Assert.IsType<List<Empresa>>(result);
			Assert.Equal(2, result.Count());
		}

		private List<EmpresaEntity> GetTestEmpresas()
		{
			return new List<EmpresaEntity>
			{
				new EmpresaEntity { EmpresaId = 1, Nombre = "Banco Agricola" },
				new EmpresaEntity { EmpresaId = 2, Nombre = "Banco Cuscatlan" }
			};
		}
	}
}
