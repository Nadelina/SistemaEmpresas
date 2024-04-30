public class EmpresaEntity
{
	public int EmpresaId { get; set; } // Primary Key
	public string Nombre { get; set; }
	public string RazonSocial { get; set; }
	public DateTime FechaRegistro { get; set; }

	// Navegación a Departamentos
	public ICollection<DepartamentoEntity> Departamentos { get; set; }
}