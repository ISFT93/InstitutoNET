
truncate table cursos
go
CREATE TABLE [dbo].[Cursos](
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
	[CodigoBloque] [varchar](10) NULL,
	[NombreCurso] [varchar](10) NULL,
	[AnioCarreraId] [int] NULL,
	[Activo] [bit] NULL,
	[AdmiteCurso] [bit] NOT NULL,
	
PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD FOREIGN KEY([AnioCarreraId])
REFERENCES [dbo].[AniosCarreras] ([AnioCarreraId])
GO

ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD FOREIGN KEY([AnioCarreraId])
REFERENCES [dbo].[AniosCarreras] ([AnioCarreraId])
GO


