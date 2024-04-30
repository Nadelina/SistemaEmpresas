namespace SistemaEmpresas.Api.Models
{
	public class Empresa
	{
		public int EmpresaId { get; set; } 
		public string Nombre { get; set; }
		public string RazonSocial { get; set; }
		public DateTime FechaRegistro { get; set; }

		public ICollection<DepartamentoEntity> Departamentos { get; set; }

	}
}
