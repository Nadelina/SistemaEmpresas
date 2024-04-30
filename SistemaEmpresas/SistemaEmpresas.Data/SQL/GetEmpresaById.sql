CREATE PROCEDURE GetEmpresaById
    @Id INT
AS
BEGIN
    SELECT EmpresaId, Nombre, RazonSocial, FechaRegistro
    FROM Empresas
    WHERE EmpresaId = @Id;
END;