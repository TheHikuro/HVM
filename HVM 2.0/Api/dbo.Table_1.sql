CREATE TABLE [dbo].[Creneau]
(
	[id_Creneau] INT NOT NULL PRIMARY KEY, 
    [heure] TIME NULL, 
    [date] DATE NULL, 
    [disponibilite] BINARY(50) NULL, 
    [reserve] BINARY(50) NULL, 
    [id_Patient] INT NULL, 
    CONSTRAINT [FK_id_Patient_toPatient] FOREIGN KEY ([id_Patient]) REFERENCES [Patient]([id_Patient])
)
