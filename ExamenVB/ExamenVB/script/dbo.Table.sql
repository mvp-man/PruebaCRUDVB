--Creaer BD Ejemplo
--
CREATE TABLE [dbo].[datos]
(
	[Clave] INT NOT NULL PRIMARY KEY, 
    [nombre] NVARCHAR(50) NULL, 
    [apellido_paterno] NVARCHAR(50) NULL, 
    [apellido_materno] NVARCHAR(50) NULL, 
    [edad] INT NULL, 
    [sexo] NCHAR(10) NULL
)
