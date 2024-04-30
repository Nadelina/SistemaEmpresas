public class DepartamentoEntity
{
	public int DepartamentoId { get; set; } // Primary Key
	public string Nombre { get; set; }
	public int NumeroEmpleados { get; set; }
	public string NivelOrganizacion { get; set; }
	public int EmpresaId { get; set; } // Foreign Key

	// Navegación a Empresa
	public EmpresaEntity Empresa { get; set; }
}