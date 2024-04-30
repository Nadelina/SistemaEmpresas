
CREATE PROCEDURE spObtenerEmpresaConDepartamentos
    @Id INT
AS
BEGIN
    SELECT 
        e.EmpresaId, 
        e.Nombre AS EmpresaNombre, 
        e.RazonSocial, 
        e.FechaRegistro,
        d.DepartamentoId, 
        d.Nombre AS DepartamentoNombre, 
        d.NumeroEmpleados, 
        d.NivelOrganizacion
    FROM 
        Empresas e
    LEFT JOIN 
        Departamentos d ON e.EmpresaId = d.EmpresaId
    WHERE 
        e.EmpresaId = @Id;
END
GO
