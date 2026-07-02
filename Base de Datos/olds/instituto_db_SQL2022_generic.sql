USE [master]
GO

CREATE DATABASE [instituto_db]
GO

ALTER DATABASE [instituto_db] SET COMPATIBILITY_LEVEL = 150
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [instituto_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [instituto_db] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [instituto_db] SET ANSI_NULLS ON 
GO
ALTER DATABASE [instituto_db] SET ANSI_PADDING ON 
GO
ALTER DATABASE [instituto_db] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [instituto_db] SET ARITHABORT ON 
GO
ALTER DATABASE [instituto_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [instituto_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [instituto_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [instituto_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [instituto_db] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [instituto_db] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [instituto_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [instituto_db] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [instituto_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [instituto_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [instituto_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [instituto_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [instituto_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [instituto_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [instituto_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [instituto_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [instituto_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [instituto_db] SET RECOVERY FULL 
GO
ALTER DATABASE [instituto_db] SET  MULTI_USER 
GO
ALTER DATABASE [instituto_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [instituto_db] SET DB_CHAINING OFF 
GO

ALTER DATABASE [instituto_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [instituto_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [instituto_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [instituto_db] SET QUERY_STORE = OFF
GO
USE [instituto_db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[funCicloLectivoActivo](
@FechaInicio date,
@FechaCierre date
)
RETURNS bit
AS
BEGIN
	IF (@FechaInicio <= GETDATE() AND @FechaCierre >= GETDATE()) RETURN 'True'
	RETURN 'False'
END
GO
/****** Object:  UserDefinedFunction [dbo].[funLicenciasActivo]    Script Date: 13/9/2025 12:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[funLicenciasActivo](
@FechaAlta date,
@FechaBaja date
)
RETURNS bit
AS
BEGIN
	DECLARE @Hoy DATE
	SET @Hoy = CAST(GETDATE() AS DATE)
	IF (@FechaAlta <= @Hoy AND (@FechaBaja IS NULL OR @FechaBaja >= @Hoy)) RETURN 'True'
	RETURN 'False'
END
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 13/9/2025 12:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[AlumnoId] [int] IDENTITY(1,1) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[TipoDocumento] [varchar](10) NOT NULL,
	[NumeroDocumento] [varchar](10) NOT NULL,
	[EstadoCivil] [varchar](15) NULL,
	[Sexo] [char](1) NOT NULL,
	[FechaNacimiento] [date] NULL,
	[LocalidadNacimiento] [varchar](15) NULL,
	[PaisNacimiento] [varchar](50) NULL,
	[Calle] [varchar](255) NOT NULL,
	[Numero] [varchar](10) NULL,
	[Piso] [varchar](10) NULL,
	[Departamento] [varchar](10) NULL,
	[Provincia] [varchar](50) NULL,
	[Distrito] [varchar](50) NULL,
	[Localidad] [varchar](50) NOT NULL,
	[CodigoPostal] [varchar](10) NULL,
	[Telefono] [varchar](30) NULL,
	[Celular] [varchar](30) NULL,
	[Email] [varchar](255) NULL,
	[TituloSecundario] [bit] NULL,
	[MateriasAdeuda] [int] NULL,
	[DescripcionMaterias] [varchar](150) NULL,
	[Titulo] [varchar](50) NULL,
	[Orientacion] [varchar](50) NULL,
	[OtorgadoPor] [varchar](50) NULL,
	[AnioEgreso] [int] NULL,
	[Promedio] [decimal](18, 0) NULL,
	[TituloTramite] [bit] NULL,
	[MayorTitulo] [varchar](50) NULL,
	[OtroTitulo] [varchar](50) NULL,
	[MayorOtorgadoPor] [varchar](50) NULL,
	[MayorPromedio] [decimal](18, 0) NULL,
	[FotocopiaTitulo] [bit] NULL,
	[ConstanciaTituloTramite] [bit] NULL,
	[ConstanciaAdeudaMaterias] [bit] NULL,
	[CantidadAdeudaMaterias] [int] NULL,
	[CertificadoAptitud] [bit] NULL,
	[FotocopiaDocumento] [bit] NULL,
	[FotoCarnet] [bit] NULL,
	[FotocopiaPartidaNacimiento] [bit] NULL,
	[VacunaAntihepatitis] [bit] NULL,
	[VacunaAntitetanica] [bit] NULL,
	[Recibo] [int] NULL,
	[Monto] [int] NULL,
	[ObraSocialPrepaga] [bit] NULL,
	[DescripcionObraSocial] [varchar](50) NULL,
	[TratamientoMedico] [bit] NULL,
	[DescripcionTratamiento] [varchar](150) NULL,
	[Medicacion] [bit] NULL,
	[DescripcionMedicacion] [varchar](150) NULL,
	[Discapacidad] [bit] NULL,
	[DescripcionDiscapacidad] [varchar](150) NULL,
	[EstadoDiscapacidad] [varchar](15) NULL,
	[CertificadoDiscapacidad] [bit] NULL,
	[ContactoEmergencia] [varchar](100) NULL,
	[TelefonoContacto] [varchar](20) NULL,
	[Activo] [bit] NULL,
	[FotoUrl] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[AlumnoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlumnosCarreras]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlumnosCarreras](
	[AlumnoCarreraId] [int] IDENTITY(1,1) NOT NULL,
	[CarreraId] [int] NULL,
	[AlumnoId] [int] NULL,
	[FechaAlta] [date] NULL,
	[FechaBaja] [date] NULL,
	[Activo] [bit] NULL,
	[CicloLectivoId] [int] NULL,
	[Inicializado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[AlumnoCarreraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AniosCarreras]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AniosCarreras](
	[AnioCarreraId] [int] IDENTITY(1,1) NOT NULL,
	[AnioCarrera] [int] NOT NULL,
	[CantidadMaterias] [int] NULL,
	[CargaHorariaCompleta] [int] NULL,
	[CarreraId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AnioCarreraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carreras]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carreras](
	[CarreraId] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](255) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[DescripcionCorta] [varchar](50) NULL,
	[JefeCatedra] [varchar](50) NOT NULL,
	[AnioInicio] [int] NOT NULL,
	[AnioFin] [int] NULL,
	[Activo] [bit] NOT NULL,
	[PlanEstudio] [varchar](255) NULL,
	[Resolucion] [varchar](255) NULL,
	[Correlatividades] [varchar](255) NULL,
	[ImagenDescriptiva] [varchar](255) NULL,
	[NumeroExpediente] [varchar](20) NULL,
	[CantidadHoras] [int] NOT NULL,
	[Duracion] [int] NOT NULL,
	[CarreraEstadoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarreraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursadaAlumnoCarreras]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursadaAlumnoCarreras](
	[CursadaAlumnoCarreraId] [int] IDENTITY(1,1) NOT NULL,
	[AlumnoCarreraId] [int] NULL,
	[CursadaId] [int] NULL,
	[AnioCicloLectivo] [int] NULL,
	[Estado] [char](2) NULL,
	[HorasCursadas] [int] NULL,
	[UltimoPresentismo] [date] NULL,
	[PorcentajeAsistencia] [decimal](18, 0) NULL,
	[Cursada] [varchar](30) NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CursadaAlumnoCarreraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursadas]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursadas](
	[CursadaId] [int] IDENTITY(1,1) NOT NULL,
	[CursoMateriaId] [int] NULL,
	[AnioLectivo] [int] NULL,
	[Anio] [int] NULL,
	[CantidadAlumnos] [int] NULL,
	[CantidadAlumnosRecursantes] [int] NULL,
	[CantidadAlumnosDesertores] [int] NULL,
	[HoraCatedra] [int] NULL,
	[FechaAsistencia] [date] NULL,
	[PorcentajeAsistencia] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[CursadaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursoMaterias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursoMaterias](
	[CursoMateriaId] [int] IDENTITY(1,1) NOT NULL,
	[MateriaId] [int] NULL,
	[CursoId] [int] NULL,
	[FechaAlta] [date] NULL,
	[FechaBaja] [date] NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CursoMateriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Materias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[MateriaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[AnioCarreraId] [int] NULL,
	[Activo] [bit] NOT NULL,
	[EspacioId] [int] NULL,
	[CargaHoraria] [int] NULL,
	[Modulos] [int] NOT NULL,
	[Multiple] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MateriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AlumnoMateriaCursoAnioCarrera]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AlumnoMateriaCursoAnioCarrera]
AS
SELECT Alumnos.AlumnoId, Alumnos.Nombre, Alumnos.Apellido, Materias.MateriaId, Materias.Nombre AS Materia, CursadaAlumnoCarreras.Estado, Cursos.NombreCurso AS Curso, 
AniosCarreras.AnioCarrera AS Anio, AlumnosCarreras.AlumnoCarreraId, Carreras.CarreraId, Carreras.DescripcionCorta AS Carrera, Alumnos.Activo, AlumnosCarreras.Inicializado
FROM Alumnos
INNER JOIN AlumnosCarreras ON AlumnosCarreras.AlumnoId = Alumnos.AlumnoId
INNER JOIN Carreras ON Carreras.CarreraId = AlumnosCarreras.CarreraId
INNER JOIN CursadaAlumnoCarreras ON AlumnosCarreras.AlumnoCarreraId = CursadaAlumnoCarreras.AlumnoCarreraId
INNER JOIN Cursadas ON Cursadas.CursadaId = CursadaAlumnoCarreras.CursadaId
INNER JOIN CursoMaterias ON Cursadas.CursoMateriaId = CursoMaterias.CursoMateriaId
INNER JOIN Materias ON CursoMaterias.MateriaId = Materias.MateriaId
INNER JOIN Cursos ON CursoMaterias.CursoId = Cursos.CursoId
INNER JOIN AniosCarreras ON Cursos.AnioCarreraId = AniosCarreras.AnioCarreraId
GO
/****** Object:  Table [dbo].[CicloLectivo]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CicloLectivo](
	[AnioLectivo] [int] NOT NULL,
	[CantidadSemana] [int] NOT NULL,
	[FechaInicio] [date] NULL,
	[FechaInscripcionInicio] [date] NULL,
	[FechaInscripcionFinal] [date] NULL,
	[FechaMarzoInicio] [date] NULL,
	[FechaMarzoFinal] [date] NULL,
	[FechaJunioInicio] [date] NULL,
	[FechaJunioFinal] [date] NULL,
	[FechaDiciembreInicio] [date] NULL,
	[FechaDiciembreFinal] [date] NULL,
	[FechaEspecialInicio] [date] NULL,
	[FechaEspecialFinal] [date] NULL,
	[FechaCierre] [date] NULL,
	[Activo]  AS ([dbo].[funCicloLectivoActivo]([FechaInicio],[FechaCierre])),
PRIMARY KEY CLUSTERED 
(
	[AnioLectivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MateriasCarrerasVigentes]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MateriasCarrerasVigentes]
AS
SELECT Cursadas.AnioLectivo, Materias.MateriaId, Materias.Nombre AS Materia, Materias.AnioCarreraId, CONCAT(AniosCarreras.AnioCarrera, Cursos.NombreCurso) AS Anio,
Carreras.CarreraId, Carreras.DescripcionCorta AS Carrera, Cursos.CursoId
FROM Cursadas
INNER JOIN CicloLectivo ON CicloLectivo.AnioLectivo = Cursadas.AnioLectivo
INNER JOIN CursoMaterias ON CursoMaterias.CursoMateriaId = Cursadas.CursoMateriaId
INNER JOIN Cursos ON Cursos.CursoId = CursoMaterias.CursoId
INNER JOIN AniosCarreras ON AniosCarreras.AnioCarreraId = Cursos.AnioCarreraId
INNER JOIN Carreras ON Carreras.CarreraId = AniosCarreras.CarreraId
INNER JOIN Materias ON Materias.MateriaId = CursoMaterias.CursoMateriaId
WHERE Materias.Activo = 'True' AND Carreras.CarreraEstadoId = 1 AND CicloLectivo.Activo = 'True'
GO
/****** Object:  Table [dbo].[Cargos]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargos](
	[CargoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Activo] [bit] NULL,
	[TipoAsignacionId] [int] NULL,
	[TipoAplicacionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CargoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[PersonalId] [int] IDENTITY(1,1) NOT NULL,
	[NumeroDocumento] [varchar](10) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNacimiento] [date] NULL,
	[Sexo] [char](1) NOT NULL,
	[Direccion] [varchar](250) NOT NULL,
	[Piso] [varchar](10) NULL,
	[Departamento] [varchar](10) NULL,
	[Localidad] [varchar](250) NOT NULL,
	[Celular] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Nacionalidad] [varchar](150) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[EstadoCivil] [varchar](50) NULL,
	[Foto] [varchar](250) NULL,
	[Titulo] [varchar](50) NULL,
	[TramoPedagogico] [bit] NULL,
	[FechaAlta] [date] NULL,
	[FechaBaja] [date] NULL,
	[PersonalEstadoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[ServicioId] [int] IDENTITY(1,1) NOT NULL,
	[PersonalId] [int] NULL,
	[SituacionRevistaId] [int] NULL,
	[CargoId] [int] NULL,
	[CursoMateriaId] [int] NULL,
	[FechaAlta] [date] NULL,
	[CantidadModulos] [int] NULL,
	[Causa] [varchar](max) NULL,
	[FechaBaja] [date] NULL,
	[Personal] [varchar](50) NULL,
	[Activo] [bit] NOT NULL,
	[LibroActaId] [int] NULL,
	[CarreraId] [int] NULL,
	[Modulo] [int] NULL,
	[Folio] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewCargosServiciosCursoMateria]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewCargosServiciosCursoMateria]
AS
SELECT CursoMaterias.CursoMateriaId, CONCAT(Nombre, ' ', Apellido) [NombreCompleto], 
Cargos.Descripcion AS Cargo, Servicios.Activo
FROM Personal
INNER JOIN Servicios ON Servicios.PersonalId = Personal.PersonalId
INNER JOIN CursoMaterias ON CursoMaterias.CursoMateriaId = Servicios.CursoMateriaId
INNER JOIN Cargos ON Cargos.CargoId = Servicios.CargoId
GO
/****** Object:  Table [dbo].[Licencias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licencias](
	[LicenciaId] [int] IDENTITY(1,1) NOT NULL,
	[PersonalId] [int] NULL,
	[TipoLicenciaId] [varchar](10) NULL,
	[FechaAlta] [date] NULL,
	[Certificado] [varchar](50) NULL,
	[FechaBaja] [date] NULL,
	[Activo]  AS ([dbo].[funLicenciasActivo]([FechaAlta],[FechaBaja])),
PRIMARY KEY CLUSTERED 
(
	[LicenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoLicencias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoLicencias](
	[TipoLicenciaId] [varchar](10) NOT NULL,
	[Descripcion] [varchar](20) NULL,
	[Dias] [int] NULL,
	[FechaFinObligatoria] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoLicenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewLicencias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[viewLicencias]
AS
SELECT LicenciaId, PersonalId, TipoLicencias.Descripcion AS Tipo, FechaAlta, FechaBaja, Certificado, Licencias.Activo 
FROM Licencias
INNER JOIN TipoLicencias ON TipoLicencias.TipoLicenciaId = Licencias.TipoLicenciaId
GO
/****** Object:  Table [dbo].[Asistencias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencias](
	[AsistenciaId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Asistencia] [char](1) NOT NULL,
	[CursadaAlumnoCarreraId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AsistenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarreraEstados]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarreraEstados](
	[CarreraEstadoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarreraEstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Correlativas]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Correlativas](
	[CorrelativaId] [int] IDENTITY(1,1) NOT NULL,
	[MateriaId] [int] NOT NULL,
	[MateriaCorrelativaId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CorrelativaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dias](
	[DiaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[DiaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equivalencias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equivalencias](
	[EquivalenciaId] [int] IDENTITY(1,1) NOT NULL,
	[CarreraId] [int] NULL,
	[MateriaId] [int] NULL,
	[CarreraEquivalenciaId] [int] NULL,
	[MateriaEquivalenciaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EquivalenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Espacios]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Espacios](
	[EspacioId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EspacioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinalEstados]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinalEstados](
	[FinalEstadoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FinalEstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horarios]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horarios](
	[HorarioId] [int] IDENTITY(1,1) NOT NULL,
	[DiaId] [int] NULL,
	[ModuloId] [int] NULL,
	[CursoMateriaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HorarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibroActas]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibroActas](
	[LibroActaId] [int] IDENTITY(1,1) NOT NULL,
	[TipoLibroId] [int] NULL,
	[LibroNumero] [int] NULL,
	[FolioNumero] [int] NULL,
	[FolioMaximo] [int] NULL,
	[FechaAlta] [date] NULL,
	[FechaBaja] [date] NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LibroActaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LicenciaServicios]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenciaServicios](
	[LicenciaServicioId] [int] IDENTITY(1,1) NOT NULL,
	[LicenciaId] [int] NULL,
	[ServicioId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LicenciaServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Llamados]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Llamados](
	[LlamadoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LlamadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mensajes]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mensajes](
	[MensajeId] [int] IDENTITY(1,1) NOT NULL,
	[Mensaje] [text] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Asunto] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MensajeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MesasFinales]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MesasFinales](
	[MesaFinalId] [int] IDENTITY(1,1) NOT NULL,
	[CarreraId] [int] NULL,
	[Fecha] [date] NULL,
	[TurnoId] [int] NULL,
	[LlamadoId] [int] NULL,
	[MateriaId] [int] NULL,
	[PresidenteId] [int] NULL,
	[VocalId] [int] NULL,
	[CicloLectivoId] [int] NULL,
	[FinalEstadoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MesaFinalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulos]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulos](
	[ModuloId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ModuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros](
	[ParametroId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](150) NULL,
	[Valor] [varchar](500) NOT NULL,
	[TipoId] [tinyint] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ParametroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalEstados]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalEstados](
	[PersonalEstadoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonalEstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[PersonaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Documento] [varchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SituacionRevistas]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SituacionRevistas](
	[SituacionRevistaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SituacionRevistaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAplicacion]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAplicacion](
	[TipoAplicacionId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Detalle] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoAplicacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAsignacion]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAsignacion](
	[TipoAsignacionId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoAsignacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoLibros]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoLibros](
	[TipoLibroId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoLibroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoParametro]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoParametro](
	[TipoParametroId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoParametroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[TurnoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TurnoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumnos] ON 

INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4005, N'Lara', N'Laura', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4006, N'Rodriguez', N'Jorge', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4007, N'Lopez', N'Maria', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4008, N'Perez', N'Juan', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4009, N'Santillan', N'Diego', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4010, N'Rosas', N'Federico', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4011, N'Landaburu', N'Ismael', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4012, N'Gomez', N'Ramon', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4013, N'Britos', N'Antonella', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4014, N'Sanchez', N'Diego', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4015, N'Martinez', N'Federico', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4016, N'Landaburu', N'Ismael', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4017, N'Flores', N'Gonzalo', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4018, N'Martinez', N'Leonardo', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 0, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4019, N'Sanchez', N'Fabian', N'DNI', N'32252520', N'Soltero/a', N'M', CAST(N'1980-02-05' AS Date), N'Temperley', N'Argentina', N'Av 9 de Julio', N'200', N'', N'', N'Buenos Aires', N'Lomas de Zamora', N'Temperley', N'1832', N'', N'', N'jorgeluna@gmail.com', 0, 2, N'Matemática y Cs Sociales', N'', N'', N'', 0, CAST(0 AS Decimal(18, 0)), 0, N'', N'', N'', CAST(0 AS Decimal(18, 0)), 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2000, 3000, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'Ernesto Luna', N'1143225585', 1, NULL)
INSERT [dbo].[Alumnos] ([AlumnoId], [Apellido], [Nombre], [TipoDocumento], [NumeroDocumento], [EstadoCivil], [Sexo], [FechaNacimiento], [LocalidadNacimiento], [PaisNacimiento], [Calle], [Numero], [Piso], [Departamento], [Provincia], [Distrito], [Localidad], [CodigoPostal], [Telefono], [Celular], [Email], [TituloSecundario], [MateriasAdeuda], [DescripcionMaterias], [Titulo], [Orientacion], [OtorgadoPor], [AnioEgreso], [Promedio], [TituloTramite], [MayorTitulo], [OtroTitulo], [MayorOtorgadoPor], [MayorPromedio], [FotocopiaTitulo], [ConstanciaTituloTramite], [ConstanciaAdeudaMaterias], [CantidadAdeudaMaterias], [CertificadoAptitud], [FotocopiaDocumento], [FotoCarnet], [FotocopiaPartidaNacimiento], [VacunaAntihepatitis], [VacunaAntitetanica], [Recibo], [Monto], [ObraSocialPrepaga], [DescripcionObraSocial], [TratamientoMedico], [DescripcionTratamiento], [Medicacion], [DescripcionMedicacion], [Discapacidad], [DescripcionDiscapacidad], [EstadoDiscapacidad], [CertificadoDiscapacidad], [ContactoEmergencia], [TelefonoContacto], [Activo], [FotoUrl]) VALUES (4020, N'Luduena', N'Micaela', N'DNI', N'35612832', N'Soltero/a', N'F', CAST(N'2020-08-30' AS Date), N'san vicente', N'Argentina', N'cordoba', N'825', N'', N'', N'buenos aires', N'', N'san vicente', N'1865', N'02225467387', N'02224356672', N'eduar@lolo.com', 1, 0, N'', N'turismo', N'bachiller', N'pedro', 2008, CAST(0 AS Decimal(18, 0)), 0, N'Universitario', N'bachiller', N'pedro', CAST(0 AS Decimal(18, 0)), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, N'', 0, N'', 0, N'', NULL, 0, N'ludueña sara', N'02224537687', 0, NULL)
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
GO
SET IDENTITY_INSERT [dbo].[AlumnosCarreras] ON 

INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2003, 1003, 4005, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2004, 1003, 4006, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2009, 1003, 4007, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2010, 1003, 4008, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2011, 1003, 4009, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2012, 1004, 4010, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2013, 1004, 4011, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2014, 2010, 4012, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2015, 2010, 4013, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2016, 2010, 4014, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2017, 3004, 4015, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2018, 3004, 4016, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2019, 3005, 4017, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2020, 3005, 4018, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2021, 3006, 4019, CAST(N'2022-04-22' AS Date), NULL, NULL, 2022, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2022, 1003, 4005, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2023, 1003, 4006, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2024, 1003, 4007, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2025, 1003, 4008, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2026, 1003, 4009, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2027, 1004, 4010, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2028, 1004, 4011, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2029, 2010, 4012, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2030, 2010, 4013, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2031, 2010, 4014, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2032, 3004, 4015, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2033, 3004, 4016, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2034, 3005, 4017, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2035, 3005, 4018, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2036, 3006, 4019, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2037, 2010, 4013, CAST(N'2022-04-22' AS Date), NULL, NULL, 2024, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2038, 2010, 4014, CAST(N'2022-04-22' AS Date), NULL, NULL, 2024, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2039, 3004, 4015, CAST(N'2022-04-22' AS Date), NULL, NULL, 2024, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2040, 3004, 4016, CAST(N'2022-04-22' AS Date), NULL, NULL, 2024, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2041, 2010, 4014, CAST(N'2022-04-22' AS Date), NULL, NULL, 2025, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2042, 3004, 4015, CAST(N'2022-04-22' AS Date), NULL, NULL, 2025, 1)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (2043, 1003, 4020, CAST(N'2022-06-07' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3043, 1004, 4010, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3044, 1004, 4009, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3045, 1004, 4010, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3046, 1004, 4011, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3047, 1004, 4010, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3048, 1004, 4011, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3049, 1004, 4010, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3050, 1004, 4011, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3051, 1004, 4010, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3052, 1004, 4011, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3053, 1004, 4010, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
INSERT [dbo].[AlumnosCarreras] ([AlumnoCarreraId], [CarreraId], [AlumnoId], [FechaAlta], [FechaBaja], [Activo], [CicloLectivoId], [Inicializado]) VALUES (3054, 1004, 4011, CAST(N'2022-04-22' AS Date), NULL, NULL, 2029, 0)
SET IDENTITY_INSERT [dbo].[AlumnosCarreras] OFF
GO
SET IDENTITY_INSERT [dbo].[AniosCarreras] ON 

INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (2002, 1, 8, 640, 1003)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (2003, 2, 9, 640, 1003)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (2004, 3, 7, 544, 1003)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (2005, 1, 6, 765, 1004)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (2006, 2, 7, 357, 1004)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (2007, 3, 9, 789, 1004)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (3005, 1, 6, 657, 2010)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (3006, 2, 5, 890, 2010)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (3007, 3, 9, 865, 2010)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (4005, 1, 7, 578, 3004)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (4006, 2, 8, 535, 3004)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (4007, 3, 9, 468, 3004)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (4008, 1, 6, 754, 3005)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (4009, 2, 8, 378, 3005)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (4010, 3, 9, 657, 3005)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (4011, 1, 9, 753, 3006)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (4012, 2, 7, 368, 3006)
INSERT [dbo].[AniosCarreras] ([AnioCarreraId], [AnioCarrera], [CantidadMaterias], [CargaHorariaCompleta], [CarreraId]) VALUES (4013, 3, 5, 764, 3006)
SET IDENTITY_INSERT [dbo].[AniosCarreras] OFF
GO
SET IDENTITY_INSERT [dbo].[Cargos] ON 

INSERT [dbo].[Cargos] ([CargoId], [Descripcion], [Activo], [TipoAsignacionId], [TipoAplicacionId]) VALUES (1, N'Director/a', 1, 1, 1)
INSERT [dbo].[Cargos] ([CargoId], [Descripcion], [Activo], [TipoAsignacionId], [TipoAplicacionId]) VALUES (2, N'Vicedirector/a', 1, 1, 1)
INSERT [dbo].[Cargos] ([CargoId], [Descripcion], [Activo], [TipoAsignacionId], [TipoAplicacionId]) VALUES (3, N'Secretario/a', 1, 1, 2)
INSERT [dbo].[Cargos] ([CargoId], [Descripcion], [Activo], [TipoAsignacionId], [TipoAplicacionId]) VALUES (4, N'Profesor/a', 1, 2, 3)
INSERT [dbo].[Cargos] ([CargoId], [Descripcion], [Activo], [TipoAsignacionId], [TipoAplicacionId]) VALUES (5, N'Auxiliar administrativo', 1, 1, 2)
INSERT [dbo].[Cargos] ([CargoId], [Descripcion], [Activo], [TipoAsignacionId], [TipoAplicacionId]) VALUES (6, N'Personal auxiliar', 1, 1, 2)
INSERT [dbo].[Cargos] ([CargoId], [Descripcion], [Activo], [TipoAsignacionId], [TipoAplicacionId]) VALUES (7, N'Coordinador Administracion de empresas', 1, 1, 4)
INSERT [dbo].[Cargos] ([CargoId], [Descripcion], [Activo], [TipoAsignacionId], [TipoAplicacionId]) VALUES (8, N'Ayudante', 1, 2, 3)
INSERT [dbo].[Cargos] ([CargoId], [Descripcion], [Activo], [TipoAsignacionId], [TipoAplicacionId]) VALUES (9, N'Jefe de Área', 1, 3, 4)
SET IDENTITY_INSERT [dbo].[Cargos] OFF
GO
SET IDENTITY_INSERT [dbo].[CarreraEstados] ON 

INSERT [dbo].[CarreraEstados] ([CarreraEstadoId], [Descripcion]) VALUES (1, N'Activa')
INSERT [dbo].[CarreraEstados] ([CarreraEstadoId], [Descripcion]) VALUES (2, N'Inactiva')
INSERT [dbo].[CarreraEstados] ([CarreraEstadoId], [Descripcion]) VALUES (3, N'Borrador')
SET IDENTITY_INSERT [dbo].[CarreraEstados] OFF
GO
SET IDENTITY_INSERT [dbo].[Carreras] ON 

INSERT [dbo].[Carreras] ([CarreraId], [Titulo], [Nombre], [DescripcionCorta], [JefeCatedra], [AnioInicio], [AnioFin], [Activo], [PlanEstudio], [Resolucion], [Correlatividades], [ImagenDescriptiva], [NumeroExpediente], [CantidadHoras], [Duracion], [CarreraEstadoId]) VALUES (1003, N'Tecnicatura Superior en Análisis, Desarrollo y Programación de Aplicaciones', N'Tecnicatura Superior en Análisis, Desarrollo y Programación de Aplicaciones', N'Sistemas', N'Adan Aloe', 2010, 0, 1, NULL, NULL, NULL, NULL, N'5801-3.279.866/03', 1824, 3, 1)
INSERT [dbo].[Carreras] ([CarreraId], [Titulo], [Nombre], [DescripcionCorta], [JefeCatedra], [AnioInicio], [AnioFin], [Activo], [PlanEstudio], [Resolucion], [Correlatividades], [ImagenDescriptiva], [NumeroExpediente], [CantidadHoras], [Duracion], [CarreraEstadoId]) VALUES (1004, N'Tecnicatura Superior en Administración Contable', N'Tecnicatura Superior en Administración Contable', N'Enfermeria', N'PEPE', 2022, 0, 1, NULL, NULL, NULL, NULL, N'5812-3.413.043/99', 2148, 3, 1)
INSERT [dbo].[Carreras] ([CarreraId], [Titulo], [Nombre], [DescripcionCorta], [JefeCatedra], [AnioInicio], [AnioFin], [Activo], [PlanEstudio], [Resolucion], [Correlatividades], [ImagenDescriptiva], [NumeroExpediente], [CantidadHoras], [Duracion], [CarreraEstadoId]) VALUES (2010, N'Tecnicatura Superior en Administración con Orientación en Marketing', N'Tecnicatura Superior en Administración con Orientación en Marketing', N'Marketing', N'lolo', 2022, 0, 1, NULL, NULL, NULL, NULL, N'5812-3.413.043/99', 1824, 3, 1)
INSERT [dbo].[Carreras] ([CarreraId], [Titulo], [Nombre], [DescripcionCorta], [JefeCatedra], [AnioInicio], [AnioFin], [Activo], [PlanEstudio], [Resolucion], [Correlatividades], [ImagenDescriptiva], [NumeroExpediente], [CantidadHoras], [Duracion], [CarreraEstadoId]) VALUES (3004, N'Tecnicatura Superior en Guía de Turismo', N'Tecnicatura Superior en Guía de Turismo', N'Turismo', N'', 2022, 0, 1, NULL, NULL, NULL, NULL, N' 5812-3.413.043/99', 1024, 3, 1)
INSERT [dbo].[Carreras] ([CarreraId], [Titulo], [Nombre], [DescripcionCorta], [JefeCatedra], [AnioInicio], [AnioFin], [Activo], [PlanEstudio], [Resolucion], [Correlatividades], [ImagenDescriptiva], [NumeroExpediente], [CantidadHoras], [Duracion], [CarreraEstadoId]) VALUES (3005, N'Tecnicatura Superior en Administración Pública', N'Tecnicatura Superior en Administración Pública', N'Publica', N'', 2022, 0, 1, NULL, NULL, NULL, NULL, N' 5812-3.413.043/99', 0, 3, 1)
INSERT [dbo].[Carreras] ([CarreraId], [Titulo], [Nombre], [DescripcionCorta], [JefeCatedra], [AnioInicio], [AnioFin], [Activo], [PlanEstudio], [Resolucion], [Correlatividades], [ImagenDescriptiva], [NumeroExpediente], [CantidadHoras], [Duracion], [CarreraEstadoId]) VALUES (3006, N'Tecnicatura Superior en Administración Contable', N'Tecnicatura Superior en Administración Contable', N'Contable', N'', 2022, 0, 1, NULL, NULL, NULL, NULL, N' 5812-3.413.043/99', 0, 3, 1)
SET IDENTITY_INSERT [dbo].[Carreras] OFF
GO
INSERT [dbo].[CicloLectivo] ([AnioLectivo], [CantidadSemana], [FechaInicio], [FechaInscripcionInicio], [FechaInscripcionFinal], [FechaMarzoInicio], [FechaMarzoFinal], [FechaJunioInicio], [FechaJunioFinal], [FechaDiciembreInicio], [FechaDiciembreFinal], [FechaEspecialInicio], [FechaEspecialFinal], [FechaCierre]) VALUES (2024, 37, CAST(N'2024-03-13' AS Date), CAST(N'2023-12-01' AS Date), CAST(N'2023-12-15' AS Date), CAST(N'2024-02-10' AS Date), CAST(N'2024-02-17' AS Date), CAST(N'2024-07-05' AS Date), CAST(N'2024-07-12' AS Date), CAST(N'2024-11-20' AS Date), CAST(N'2024-11-27' AS Date), NULL, NULL, CAST(N'2024-12-20' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Correlativas] ON 

INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (1, 9, 1)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (2, 9, 2)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (3, 10, 2)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (4, 11, 3)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (5, 12, 4)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (6, 13, 6)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (7, 14, 6)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (8, 15, 7)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (9, 16, 6)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (10, 18, 9)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (11, 18, 10)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (12, 18, 13)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (13, 19, 12)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (14, 20, 15)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (15, 22, 12)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (16, 23, 16)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (17, 21, 5)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (18, 21, 13)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (19, 21, 16)
INSERT [dbo].[Correlativas] ([CorrelativaId], [MateriaId], [MateriaCorrelativaId]) VALUES (20, 21, 12)
SET IDENTITY_INSERT [dbo].[Correlativas] OFF
GO
SET IDENTITY_INSERT [dbo].[Cursadas] ON 

INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438322, 1, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438323, 2, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438324, 3, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438325, 4, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438326, 5, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438327, 6, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438328, 7, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438329, 8, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438330, 9, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438331, 10, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438332, 11, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438333, 12, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438334, 13, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438335, 14, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438336, 15, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438337, 16, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438338, 17, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438339, 18, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438340, 19, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438341, 20, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438342, 21, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438343, 22, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438344, 23, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438345, 24, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438346, 1019, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438347, 1020, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438348, 1021, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438349, 1022, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438350, 1023, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438351, 1024, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438352, 1025, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438353, 1026, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438354, 1027, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438355, 1028, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438356, 1029, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438357, 1030, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438358, 1032, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438359, 1033, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438360, 1034, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438361, 1036, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438362, 1038, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438363, 1039, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438364, 1040, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438365, 1041, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438366, 1042, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438367, 1043, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438368, 1044, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438369, 1045, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438370, 1046, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438371, 1047, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438372, 1048, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438373, 1050, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438374, 1051, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438375, 1052, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438376, 1053, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438377, 1054, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438378, 1055, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438379, 1056, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438380, 1058, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438381, 1060, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438382, 1062, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438383, 1063, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438384, 1064, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438385, 1065, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438386, 1066, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438387, 1067, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438388, 1068, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438389, 1069, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438390, 1070, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438391, 1071, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438392, 1072, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438393, 1073, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438394, 1074, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438395, 1075, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438396, 1076, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438397, 1077, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438398, 1078, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438399, 1079, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438400, 1080, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438401, 1083, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438402, 1085, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438403, 1086, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438404, 1087, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438405, 1088, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438406, 1089, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438407, 1090, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438408, 1091, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438409, 1093, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438410, 1094, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438411, 1095, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438412, 1096, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438413, 1097, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438414, 1098, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438415, 1099, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438416, 1100, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438417, 1101, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438418, 1102, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438419, 1104, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438420, 1105, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438421, 1106, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438422, 1107, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438423, 1108, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438424, 1109, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438425, 1110, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438426, 1111, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438427, 2017, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438428, 2018, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438429, 2019, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438430, 2020, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438431, 2021, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438432, 2022, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438433, 2023, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438434, 2024, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438435, 2025, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438436, 2026, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438437, 2027, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438438, 2028, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438439, 2029, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438440, 2030, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438441, 2031, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438442, 2032, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438443, 2033, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438444, 2034, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438445, 2035, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438446, 2036, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438447, 2037, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438448, 2038, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438449, 2039, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438450, 2040, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438451, 2042, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438452, 2043, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438453, 2044, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438454, 2045, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438455, 2046, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438456, 2047, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438457, 2048, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438458, 2049, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438459, 2050, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438460, 2051, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438461, 2074, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438462, 2075, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438463, 2076, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438464, 2077, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438465, 2078, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438466, 2079, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438467, 2080, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438468, 2081, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438469, 2082, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438470, 2083, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438471, 2084, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438472, 2085, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438473, 2086, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438474, 2087, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438475, 2088, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438476, 2089, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438477, 2090, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438478, 2091, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438479, 2092, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438480, 2093, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438481, 2094, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438482, 2096, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438483, 2097, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438484, 2098, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438485, 2099, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438486, 2100, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438487, 2101, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438488, 2102, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438489, 2103, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438490, 2104, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438491, 2105, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438492, 2106, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438493, 2107, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438494, 2108, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438495, 2109, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438496, 2110, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438497, 2111, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438498, 2112, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438499, 2113, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438500, 2114, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438501, 2115, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438502, 2116, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438503, 2117, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438504, 2118, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438505, 2119, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438506, 2120, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438507, 2121, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438508, 2122, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438509, 2124, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438510, 2126, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438511, 2127, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438512, 2128, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438513, 2129, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438514, 2130, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438515, 2131, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438516, 2132, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438517, 2133, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438518, 2134, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438519, 2135, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438520, 2136, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438521, 2137, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438522, 2138, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438523, 2139, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438524, 2140, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438525, 2141, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438526, 2143, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438527, 2144, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (438528, 2145, 2024, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439322, 1, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439323, 2, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439324, 3, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439325, 4, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439326, 5, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439327, 6, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439328, 7, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439329, 8, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439330, 9, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439331, 10, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439332, 11, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439333, 12, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439334, 13, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439335, 14, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439336, 15, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439337, 16, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439338, 17, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439339, 18, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439340, 19, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439341, 20, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439342, 21, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439343, 22, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439344, 23, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439345, 24, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439346, 1019, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439347, 1020, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439348, 1021, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439349, 1022, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439350, 1023, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439351, 1024, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439352, 1025, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439353, 1026, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439354, 1027, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439355, 1028, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439356, 1029, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439357, 1030, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439358, 1032, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439359, 1033, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439360, 1034, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439361, 1036, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439362, 1038, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439363, 1039, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439364, 1040, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439365, 1041, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439366, 1042, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439367, 1043, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439368, 1044, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439369, 1045, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439370, 1046, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439371, 1047, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439372, 1048, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439373, 1050, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439374, 1051, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439375, 1052, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439376, 1053, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439377, 1054, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439378, 1055, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439379, 1056, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439380, 1058, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439381, 1060, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439382, 1062, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439383, 1063, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439384, 1064, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439385, 1065, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439386, 1066, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439387, 1067, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439388, 1068, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439389, 1069, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439390, 1070, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439391, 1071, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439392, 1072, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439393, 1073, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439394, 1074, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439395, 1075, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439396, 1076, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439397, 1077, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439398, 1078, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439399, 1079, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439400, 1080, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439401, 1083, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439402, 1085, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439403, 1086, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439404, 1087, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439405, 1088, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439406, 1089, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439407, 1090, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439408, 1091, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439409, 1093, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439410, 1094, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439411, 1095, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439412, 1096, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439413, 1097, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439414, 1098, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439415, 1099, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439416, 1100, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439417, 1101, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439418, 1102, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439419, 1104, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439420, 1105, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439421, 1106, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439422, 1107, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439423, 1108, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439424, 1109, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439425, 1110, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439426, 1111, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439427, 2017, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439428, 2018, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439429, 2019, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439430, 2020, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439431, 2021, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439432, 2022, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439433, 2023, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439434, 2024, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439435, 2025, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439436, 2026, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439437, 2027, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439438, 2028, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439439, 2029, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439440, 2030, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439441, 2031, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439442, 2032, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439443, 2033, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439444, 2034, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439445, 2035, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439446, 2036, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439447, 2037, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439448, 2038, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439449, 2039, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439450, 2040, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439451, 2042, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439452, 2043, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439453, 2044, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439454, 2045, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439455, 2046, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439456, 2047, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439457, 2048, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439458, 2049, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439459, 2050, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439460, 2051, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439461, 2074, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439462, 2075, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439463, 2076, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439464, 2077, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439465, 2078, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439466, 2079, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439467, 2080, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439468, 2081, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439469, 2082, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439470, 2083, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439471, 2084, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439472, 2085, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439473, 2086, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439474, 2087, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439475, 2088, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439476, 2089, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439477, 2090, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439478, 2091, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439479, 2092, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439480, 2093, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439481, 2094, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439482, 2096, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439483, 2097, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439484, 2098, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439485, 2099, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439486, 2100, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439487, 2101, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439488, 2102, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439489, 2103, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439490, 2104, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439491, 2105, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439492, 2106, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439493, 2107, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439494, 2108, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439495, 2109, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439496, 2110, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439497, 2111, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439498, 2112, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439499, 2113, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439500, 2114, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439501, 2115, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439502, 2116, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439503, 2117, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439504, 2118, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439505, 2119, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439506, 2120, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439507, 2121, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439508, 2122, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439509, 2124, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439510, 2126, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439511, 2127, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439512, 2128, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439513, 2129, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439514, 2130, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439515, 2131, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439516, 2132, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439517, 2133, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439518, 2134, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439519, 2135, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439520, 2136, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439521, 2137, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439522, 2138, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439523, 2139, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439524, 2140, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439525, 2141, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439526, 2143, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439527, 2144, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439528, 2145, 2025, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439529, 1, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439530, 2, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439531, 3, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439532, 4, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439533, 5, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439534, 6, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439535, 7, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439536, 8, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439537, 9, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439538, 10, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439539, 11, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439540, 12, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439541, 13, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439542, 14, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439543, 15, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439544, 16, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439545, 17, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439546, 18, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439547, 19, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439548, 20, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439549, 21, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439550, 22, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439551, 23, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439552, 24, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439553, 1019, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439554, 1020, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439555, 1021, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439556, 1022, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439557, 1023, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439558, 1024, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439559, 1025, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439560, 1026, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439561, 1027, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439562, 1028, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439563, 1029, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439564, 1030, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439565, 1032, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439566, 1033, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439567, 1034, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439568, 1036, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439569, 1038, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439570, 1039, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439571, 1040, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439572, 1041, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439573, 1042, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439574, 1043, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439575, 1044, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439576, 1045, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439577, 1046, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439578, 1047, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439579, 1048, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439580, 1050, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439581, 1051, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439582, 1052, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439583, 1053, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439584, 1054, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439585, 1055, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439586, 1056, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439587, 1058, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439588, 1060, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439589, 1062, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439590, 1063, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439591, 1064, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439592, 1065, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439593, 1066, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439594, 1067, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439595, 1068, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439596, 1069, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439597, 1070, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439598, 1071, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439599, 1072, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439600, 1073, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439601, 1074, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439602, 1075, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439603, 1076, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439604, 1077, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439605, 1078, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439606, 1079, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439607, 1080, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439608, 1083, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439609, 1085, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439610, 1086, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439611, 1087, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439612, 1088, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439613, 1089, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439614, 1090, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439615, 1091, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439616, 1093, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439617, 1094, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439618, 1095, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439619, 1096, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439620, 1097, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439621, 1098, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439622, 1099, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439623, 1100, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439624, 1101, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439625, 1102, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439626, 1104, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439627, 1105, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439628, 1106, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439629, 1107, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439630, 1108, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439631, 1109, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439632, 1110, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439633, 1111, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439634, 2017, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439635, 2018, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439636, 2019, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439637, 2020, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439638, 2021, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439639, 2022, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439640, 2023, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439641, 2024, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439642, 2025, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439643, 2026, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439644, 2027, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439645, 2028, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439646, 2029, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439647, 2030, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439648, 2031, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439649, 2032, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439650, 2033, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439651, 2034, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439652, 2035, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439653, 2036, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439654, 2037, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439655, 2038, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439656, 2039, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439657, 2040, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439658, 2042, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439659, 2043, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439660, 2044, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439661, 2045, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439662, 2046, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439663, 2047, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439664, 2048, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439665, 2049, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439666, 2050, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439667, 2051, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439668, 2074, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439669, 2075, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439670, 2076, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439671, 2077, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439672, 2078, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439673, 2079, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439674, 2080, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439675, 2081, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439676, 2082, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439677, 2083, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439678, 2084, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439679, 2085, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439680, 2086, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439681, 2087, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439682, 2088, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439683, 2089, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439684, 2090, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439685, 2091, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439686, 2092, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439687, 2093, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439688, 2094, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439689, 2096, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439690, 2097, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439691, 2098, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439692, 2099, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439693, 2100, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439694, 2101, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439695, 2102, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439696, 2103, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439697, 2104, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439698, 2105, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439699, 2106, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439700, 2107, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439701, 2108, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439702, 2109, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439703, 2110, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439704, 2111, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439705, 2112, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439706, 2113, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439707, 2114, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439708, 2115, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439709, 2116, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439710, 2117, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439711, 2118, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439712, 2119, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439713, 2120, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439714, 2121, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439715, 2122, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439716, 2124, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439717, 2126, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439718, 2127, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439719, 2128, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439720, 2129, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439721, 2130, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439722, 2131, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439723, 2132, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439724, 2133, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439725, 2134, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439726, 2135, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439727, 2136, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439728, 2137, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439729, 2138, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439730, 2139, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439731, 2140, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439732, 2141, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439733, 2143, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439734, 2144, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cursadas] ([CursadaId], [CursoMateriaId], [AnioLectivo], [Anio], [CantidadAlumnos], [CantidadAlumnosRecursantes], [CantidadAlumnosDesertores], [HoraCatedra], [FechaAsistencia], [PorcentajeAsistencia]) VALUES (439735, 2145, 2026, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Cursadas] OFF
GO
SET IDENTITY_INSERT [dbo].[CursoMaterias] ON 

INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1, 1, 1004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2, 2, 1004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (3, 3, 1004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (4, 4, 1004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (5, 5, 1004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (6, 6, 1004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (7, 7, 1004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (8, 8, 1004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (9, 9, 2004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (10, 10, 2004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (11, 11, 2004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (12, 12, 2004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (13, 13, 2004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (14, 14, 2004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (15, 15, 2004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (16, 16, 2004, CAST(N'2022-04-12' AS Date), NULL, 0)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (17, 17, 2004, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (18, 18, 2005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (19, 19, 2005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (20, 20, 2005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (21, 21, 2005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (22, 22, 2005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (23, 23, 2005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (24, 24, 2005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1019, 28, 2006, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1020, 29, 2006, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1021, 30, 2006, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1022, 31, 2006, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1023, 32, 2006, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1024, 33, 2006, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1025, 34, 2006, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1026, 35, 2006, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1027, 36, 2010, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1028, 38, 2010, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1029, 39, 2010, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1030, 40, 2010, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1032, 42, 2010, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1033, 43, 2010, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1034, 44, 2010, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1036, 46, 2010, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1038, 48, 2010, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1039, 49, 2011, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1040, 50, 2011, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1041, 51, 2011, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1042, 52, 2011, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1043, 53, 2011, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1044, 54, 2011, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1045, 55, 2011, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1046, 56, 2012, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1047, 57, 2012, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1048, 58, 2012, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1050, 60, 2012, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1051, 61, 2012, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1052, 62, 2012, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1053, 63, 2012, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1054, 64, 2012, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1055, 65, 2012, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1056, 66, 2012, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1058, 68, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1060, 70, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1062, 72, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1063, 73, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1064, 74, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1065, 75, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1066, 75, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1067, 76, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1068, 77, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1069, 78, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1070, 80, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1071, 81, 2014, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1072, 83, 2015, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1073, 84, 2015, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1074, 85, 2015, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1075, 86, 2015, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1076, 87, 2015, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1077, 88, 2015, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1078, 89, 2015, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1079, 90, 2015, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1080, 91, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1083, 94, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1085, 96, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1086, 97, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1087, 98, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1088, 99, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1089, 100, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1090, 101, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1091, 102, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1093, 104, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1094, 105, 2016, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1095, 106, 2018, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1096, 107, 2018, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1097, 108, 2018, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1098, 109, 2018, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1099, 110, 2018, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1100, 111, 2018, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1101, 112, 2018, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1102, 113, 2018, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1104, 115, 2019, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1105, 116, 2019, NULL, NULL, NULL)
GO
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1106, 117, 2019, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1107, 118, 2019, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1108, 119, 2019, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1109, 120, 2019, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1110, 121, 2019, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (1111, 122, 2019, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2017, 1, 1005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2018, 2, 1005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2019, 3, 1005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2020, 4, 1005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2021, 5, 1005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2022, 6, 1005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2023, 7, 1005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2024, 8, 1005, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2025, 1, 1006, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2026, 2, 1006, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2027, 3, 1006, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2028, 4, 1006, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2029, 5, 1006, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2030, 6, 1006, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2031, 7, 1006, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2032, 8, 1006, CAST(N'2022-04-12' AS Date), NULL, 1)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2033, 28, 2007, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2034, 29, 2007, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2035, 30, 2007, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2036, 31, 2007, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2037, 32, 2007, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2038, 33, 2007, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2039, 34, 2007, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2040, 35, 2007, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2042, 56, 2013, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2043, 57, 2013, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2044, 58, 2013, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2045, 60, 2013, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2046, 61, 2013, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2047, 62, 2013, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2048, 63, 2013, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2049, 64, 2013, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2050, 65, 2013, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2051, 66, 2013, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2074, 91, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2075, 94, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2076, 96, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2077, 97, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2078, 98, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2079, 99, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2080, 100, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2081, 101, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2082, 102, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2083, 104, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2084, 105, 2017, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2085, 1026, 2023, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2086, 1032, 2023, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2087, 1033, 2023, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2088, 1034, 2023, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2089, 1035, 2023, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2090, 1036, 2023, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2091, 1037, 2023, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2092, 1038, 2023, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2093, 1039, 2023, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2094, 1040, 2023, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2096, 1041, 2024, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2097, 1042, 2024, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2098, 1043, 2024, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2099, 1044, 2024, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2100, 1045, 2024, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2101, 1046, 2024, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2102, 1047, 2024, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2103, 1048, 2024, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2104, 1049, 2024, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2105, 1050, 2024, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2106, 1051, 2025, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2107, 1052, 2025, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2108, 1053, 2025, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2109, 1054, 2025, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2110, 1055, 2025, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2111, 1056, 2025, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2112, 1057, 2025, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2113, 1058, 2025, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2114, 1059, 2025, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2115, 1060, 2020, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2116, 1061, 2020, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2117, 1062, 2020, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2118, 1063, 2020, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2119, 1064, 2020, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2120, 1065, 2020, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2121, 1066, 2020, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2122, 1067, 2020, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2124, 1069, 2020, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2126, 1071, 2020, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2127, 1072, 2021, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2128, 1073, 2021, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2129, 1074, 2021, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2130, 1075, 2021, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2131, 1076, 2021, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2132, 1077, 2021, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2133, 1078, 2021, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2134, 1079, 2021, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2135, 1080, 2021, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2136, 1081, 2022, NULL, NULL, NULL)
GO
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2137, 1082, 2022, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2138, 1083, 2022, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2139, 1084, 2022, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2140, 1085, 2022, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2141, 1086, 2022, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2143, 1088, 2022, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2144, 1089, 2022, NULL, NULL, NULL)
INSERT [dbo].[CursoMaterias] ([CursoMateriaId], [MateriaId], [CursoId], [FechaAlta], [FechaBaja], [Activo]) VALUES (2145, 1090, 2022, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[CursoMaterias] OFF
GO
SET IDENTITY_INSERT [dbo].[Cursos] ON 

INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (1, N'A', 2002, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2, N'B', 2002, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (3, N'C', 2002, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (5, N'A', 2003, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (7, N'A', 2004, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (8, N'A', 3005, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (9, N'A', 3006, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (11, N'A', 3007, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (12, N'A', 4005, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (13, N'A', 4006, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (14, N'A', 4007, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (15, N'A', 4008, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (16, N'B', 4008, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (17, N'A', 4009, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (18, N'A', 4010, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (1004, N'A', 2002, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (1005, N'B', 2002, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (1006, N'C', 2002, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2004, N'A', 2003, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2005, N'A', 2004, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2006, N'A', 2005, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2007, N'B', 2005, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2010, N'A', 2006, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2011, N'A', 2007, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2012, N'A', 3005, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2013, N'B', 3005, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2014, N'A', 3006, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2015, N'A', 3007, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2016, N'A', 4005, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2017, N'B', 4005, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2018, N'A', 4006, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2019, N'A', 4007, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2020, N'A', 4008, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2021, N'A', 4009, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2022, N'A', 4010, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2023, N'A', 4011, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2024, N'A', 4012, 1, 1)
INSERT [dbo].[Cursos] ([CursoId], [NombreCurso], [AnioCarreraId], [Activo], [AdmiteCurso]) VALUES (2025, N'A', 4013, 1, 1)
SET IDENTITY_INSERT [dbo].[Cursos] OFF
GO
SET IDENTITY_INSERT [dbo].[Dias] ON 

INSERT [dbo].[Dias] ([DiaId], [Descripcion]) VALUES (1, N'Lunes')
INSERT [dbo].[Dias] ([DiaId], [Descripcion]) VALUES (2, N'Martes')
INSERT [dbo].[Dias] ([DiaId], [Descripcion]) VALUES (3, N'Miercoles')
INSERT [dbo].[Dias] ([DiaId], [Descripcion]) VALUES (4, N'Jueves')
INSERT [dbo].[Dias] ([DiaId], [Descripcion]) VALUES (5, N'Viernes')
SET IDENTITY_INSERT [dbo].[Dias] OFF
GO
SET IDENTITY_INSERT [dbo].[Equivalencias] ON 

INSERT [dbo].[Equivalencias] ([EquivalenciaId], [CarreraId], [MateriaId], [CarreraEquivalenciaId], [MateriaEquivalenciaId]) VALUES (2006, 1003, 2, 3006, 1026)
INSERT [dbo].[Equivalencias] ([EquivalenciaId], [CarreraId], [MateriaId], [CarreraEquivalenciaId], [MateriaEquivalenciaId]) VALUES (3004, 1003, 3, 3006, 1043)
INSERT [dbo].[Equivalencias] ([EquivalenciaId], [CarreraId], [MateriaId], [CarreraEquivalenciaId], [MateriaEquivalenciaId]) VALUES (3005, 1003, 21, 1004, 55)
INSERT [dbo].[Equivalencias] ([EquivalenciaId], [CarreraId], [MateriaId], [CarreraEquivalenciaId], [MateriaEquivalenciaId]) VALUES (3009, 3006, 1041, 1003, 10)
INSERT [dbo].[Equivalencias] ([EquivalenciaId], [CarreraId], [MateriaId], [CarreraEquivalenciaId], [MateriaEquivalenciaId]) VALUES (3011, 3006, 1051, 1003, 11)
INSERT [dbo].[Equivalencias] ([EquivalenciaId], [CarreraId], [MateriaId], [CarreraEquivalenciaId], [MateriaEquivalenciaId]) VALUES (3012, 1004, 38, 1003, 3)
SET IDENTITY_INSERT [dbo].[Equivalencias] OFF
GO
SET IDENTITY_INSERT [dbo].[Espacios] ON 

INSERT [dbo].[Espacios] ([EspacioId], [Descripcion]) VALUES (1, N'Espacio de Formación Básica')
INSERT [dbo].[Espacios] ([EspacioId], [Descripcion]) VALUES (2, N'Espacio de Formación Específica')
INSERT [dbo].[Espacios] ([EspacioId], [Descripcion]) VALUES (3, N'Espacio de Definición Institucional')
SET IDENTITY_INSERT [dbo].[Espacios] OFF
GO
SET IDENTITY_INSERT [dbo].[FinalEstados] ON 

INSERT [dbo].[FinalEstados] ([FinalEstadoId], [Descripcion]) VALUES (1, N'Activa')
INSERT [dbo].[FinalEstados] ([FinalEstadoId], [Descripcion]) VALUES (2, N'Inactiva')
INSERT [dbo].[FinalEstados] ([FinalEstadoId], [Descripcion]) VALUES (3, N'Borrador')
SET IDENTITY_INSERT [dbo].[FinalEstados] OFF
GO
SET IDENTITY_INSERT [dbo].[LibroActas] ON 

INSERT [dbo].[LibroActas] ([LibroActaId], [TipoLibroId], [LibroNumero], [FolioNumero], [FolioMaximo], [FechaAlta], [FechaBaja], [Activo]) VALUES (1, 1, 1, 2, 200, CAST(N'2023-09-13' AS Date), NULL, 1)
INSERT [dbo].[LibroActas] ([LibroActaId], [TipoLibroId], [LibroNumero], [FolioNumero], [FolioMaximo], [FechaAlta], [FechaBaja], [Activo]) VALUES (2, 2, 1, 18, 200, CAST(N'2023-09-15' AS Date), NULL, 1)
SET IDENTITY_INSERT [dbo].[LibroActas] OFF
GO
SET IDENTITY_INSERT [dbo].[Llamados] ON 

INSERT [dbo].[Llamados] ([LlamadoId], [Descripcion]) VALUES (1, N'1° llamado')
INSERT [dbo].[Llamados] ([LlamadoId], [Descripcion]) VALUES (2, N'2° llamado')
INSERT [dbo].[Llamados] ([LlamadoId], [Descripcion]) VALUES (3, N'Fecha única')
SET IDENTITY_INSERT [dbo].[Llamados] OFF
GO
SET IDENTITY_INSERT [dbo].[Materias] ON 

INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1, N'Álgebra', 2002, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (2, N'Análisis Matemático', 2002, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (3, N'Inglés Técnico', 2002, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (4, N'Administración de las Organizaciones', 2002, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (5, N'Metodología de la Investigación', 2002, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (6, N'Programación I', 2002, 1, 2, 128, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (7, N'Sistemas de Computación', 2002, 1, 2, 128, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (8, N'EDI', 2002, 1, 3, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (9, N'Probabilidad y Estadística', 2003, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (10, N'Análisis Matemático II', 2003, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (11, N'Inglés Técnico II', 2003, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (12, N'Análisis de Sistemas', 2003, 1, 2, 96, 3, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (13, N'Programación Orientada a Objectos', 2003, 1, 2, 128, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (14, N'Seminario de Programación', 2003, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (15, N'Sistemas Operativos', 2003, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (16, N'Base de Datos', 2003, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (17, N'EDI', 2003, 1, 2, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (18, N'Investigación Operativa', 2004, 1, 1, 96, 3, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (19, N'Economía Empresarial', 2004, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (20, N'Teleinformática', 2004, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (21, N'Práctica Profesional', 2004, 1, 2, 128, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (22, N'Diseño e Implementación de Sistemas', 2004, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (23, N'Gestión de Base de Datos', 2004, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (24, N'EDI', 2004, 1, 3, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (28, N'Psicología', 2005, 1, 1, 32, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (29, N'Teorías socio
culturales de la
salud', 2005, 1, 1, 32, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (30, N'Condiciones y
Medio Ambiente
del Trabajo
', 2005, 1, 2, 64, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (31, N'Salud
Pública I
', 2005, 1, 2, 64, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (32, N'Biología
Humana', 2005, 1, 2, 128, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (33, N'Fundamentos
del Cuidado
', 2005, 1, 3, 64, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (34, N'Cuidados de la Salud
Centrados en la
Comunidad y la
Familia
', 2005, 1, 3, 96, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (35, N'Práctica Profesionalizante I', 2005, 1, 3, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (36, N'Comunicación
en Ciencias de
la Salud
', 2006, 1, 1, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (38, N'Inglés', 2006, 1, 1, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (39, N'Introducción a
la Metodología
de
Investigación
en Salud', 2006, 1, 1, 64, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (40, N'Nutrición y
Dietoterapia
', 2006, 1, 2, 32, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (42, N'Salud
Pública II', 2006, 1, 2, 96, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (43, N'Farmacología en
Enfermería
', 2006, 1, 3, 64, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (44, N'Enfermería
Materno
Infantil
', 2006, 1, 3, 64, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (46, N'Enfermería
del Adulto
y del
Adulto
Mayor I', 2006, 1, 3, 96, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (48, N'NULLPráctica
Profesionalizante II', 2006, 1, 3, 256, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (49, N'Organización y
Gestión de
Servicios de
Enfermería
', 2007, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (50, N'Aspectos
Bioéticos y
Legales de la
Profesión
', 2007, 1, 2, 32, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (51, N'Enfermería en
Salud Mental', 2007, 1, 3, 64, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (52, N'Enfermería del
Adulto y del
Adulto Mayor II
', 2007, 1, 3, 64, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (53, N'Enfermería
Comunitaria y
Práctica Educativa
en Salud', 2007, 1, 3, 64, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (54, N'Enfermería en
Emergencias y
Catástrofes
', 2007, 1, 3, 32, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (55, N'Práctica Profesionalizante III
', 2007, 1, 1, 356, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (56, N'Matemática
I
', 3005, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (57, N'Computación
I
', 3005, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (58, N'Derecho', 3005, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (60, N'Economía', 3005, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (61, N'Contabilidad', 3005, 1, 1, 96, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (62, N'Sociología de
la
Organización', 3005, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (63, N'Principios de
Administración', 3005, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (64, N'Metodología
de la
Investigación
', 3005, 1, 1, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (65, N'Marketing', 3005, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (66, N'Espacio de
Definición
Institucional', 3005, 1, 3, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (68, N'Matemática
II ', 3006, 1, 1, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (70, N'Estadística', 3006, 1, 1, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (72, N'Inglés
I
', 3006, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (73, N'Computación
II
', 3006, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (74, N'ión
II
Canales de
Distribución', 3006, 1, 2, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (75, N'Fundamentos
de Psicología y
Comportamiento
del Consumido', 3006, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (76, N'Derecho
Comercial ', 3006, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (77, N'Publicidad
', 3006, 1, 2, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (78, N'd
Práctica
Profesional
I
', 3006, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (80, N'Espacio de
Definición
Institucional', 3006, 1, 3, 128, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (81, N'Inglés II ', 3006, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (83, N'Costos y
Presupuestos', 3007, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (84, N'Administración
Estratégica
', 3007, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (85, N'Política y
Desarrollo
de
Productos
', 3007, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (86, N'Comercio
Internaciona', 3007, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (87, N'Política de
Precios
', 3007, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (88, N'Investigación
de Mercados', 3007, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (89, N'Práctica
Profesional
II
', 3007, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (90, N'Espacio de
Definición
Institucional', 3007, 1, 3, 128, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (91, N'Inglés
I
', 4005, 1, 1, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (94, N'Sicología
Social
', 4005, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (96, N'Metodología
de la
Investigación ', 4005, 1, 1, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (97, N'Introducción
al Turismo
', 4005, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (98, N'Servicios
Turísticos', 4005, 1, 2, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (99, N'Historia
Argentina', 4005, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (100, N'Historia
del Arte
Universal
', 4005, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (101, N'Estudio
del
Espacio
Turístico
de
Argentina
y América', 4005, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (102, N'Patrimonio
Turístico de
Argentina y
América
', 4005, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (104, N'NULLPráctica
Profesional
I
', 4005, 1, 2, 94, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (105, N'Espacio de
Definición
Institucional', 4005, 1, 3, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (106, N'Inglés II', 4006, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (107, N'Programación de
Circuitos Turísticos
', 4006, 1, 2, 96, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (108, N'Historia de
las Culturas
', 4006, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (109, N'Estudio del
Espacio
Turístico de
Europa,
África, Asia y
Oceanía.', 4006, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (110, N'Patrimonio
Turístico de
Europa,
África, Asia y
Oceanía
', 4006, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (111, N'Recreación
y
Animación
Socio
Cultural
', 4006, 1, 2, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (112, N'Práctica Profesional II
', 4006, 1, 2, 160, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (113, N'Espacio de
Definición
Institucional', 4006, 1, 3, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (115, N'Inglés III
', 4007, 1, 1, 96, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (116, N'I
Conservación
del Medio
Ambiente
', 4007, 1, 1, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (117, N'Legislación', 4007, 1, 2, 32, 1, NULL)
GO
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (118, N'n
Historia del Arte
Argentino y
Latinoamericano', 4007, 1, 2, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (119, N'Folklore', 4007, 1, 2, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (120, N'Informática', 4007, 1, 2, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (121, N'Práctica Profesional III', 4007, 1, 2, 256, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (122, N'Espacio de
Definición
Institucional', 4007, 1, 3, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1026, N'Matemátic
a I', 4011, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1032, N'Computació
n I', 4011, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1033, N'Derech
o
', 4011, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1034, N'Economí
a', 4011, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1035, N'Contabilida
d
', 4011, 1, 1, 96, 3, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1036, N'Sociología
de la
Organizació
n', 4011, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1037, N'Principios de
Administració
n
', 4011, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1038, N'Metodología
de la
Investigació
n
', 4011, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1039, N'Gestión
Administrativ
o Contable
', 4011, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1040, N'Espacio de
Definición
Instituciona
l
', 4011, 1, 3, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1041, N'Matemática
II ', 4012, 1, 1, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1042, N'Estadística', 4012, 1, 1, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1043, N'Inglés
I
', 4012, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1044, N'Computación
II
', 4012, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1045, N'Contabilidad
II
', 4012, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1046, N'Matemática
Financiera', 4012, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1047, N'Derecho
Laboral
', 4012, 1, 2, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1048, N'Práctica
Profesional
I
', 4012, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1049, N'Derecho
Comercial', 4012, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1050, N'Espacio de
Definición
Institucional', 4012, 1, 3, 96, 3, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1051, N'Inglés II
', 4013, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1052, N'Técnica
Impositiva
y Laboral', 4013, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1053, N'Régimen
Tributario
', 4013, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1054, N'Contabilidad
III
', 4013, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1055, N'Costos y
Presupuestos', 4013, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1056, N'Administración
Financiera', 4013, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1057, N'Administración
Estratégica
', 4013, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1058, N'Práctica
Profesional
II', 4013, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1059, N'Espacio de
Definición
Institucional
', 4013, 1, 3, 96, 3, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1060, N'Estado y
Sociedad
', 4008, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1061, N'Matemática
Financiera', 4008, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1062, N'Economía', 4008, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1063, N'Producción
Oral y
Escrita', 4008, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1064, N'Informática', 4008, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1065, N'Metodología de la Investigación', 4008, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1066, N'Derecho y
Derecho
Constitucional
', 4008, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1067, N'Contabilidad
Pública', 4008, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1069, N'Principios de
Administración', 4008, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1071, N'Espacio de
Definición
Institucional', 4008, 1, 3, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1072, N'Estadística', 4009, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1073, N'TICS en
la
Gestión
Pública
', 4009, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1074, N'Inglés ', 4009, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1075, N'Comunicación', 4009, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1076, N'Procesos
políticos
económicos', 4009, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1077, N'Derecho
laboral y
relaciones
laborales', 4009, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1078, N'Derecho
Público', 4009, 1, 1, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1079, N'Políticas
públicas y
desarrollo
local
', 4009, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1080, N'Administración
Pública', 4009, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1081, N'Espacio de
Definición
Institucional
', 4009, 1, 3, 32, 1, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1082, N'Finanzas
Públicas', 4010, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1083, N'Derecho
Administrativo', 4010, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1084, N'Desarrollo
local
y Planificación
estratégica
', 4010, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1085, N'Evaluación
de
Proyecto de
Inversión
', 4010, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1086, N'Administración
Económica
Financiera
', 4010, 1, 2, 96, 3, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1088, N'Recursos
Humanos', 4010, 1, 2, 64, 2, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1089, N'Práctica
Profesional', 4010, 1, 2, 128, 4, NULL)
INSERT [dbo].[Materias] ([MateriaId], [Nombre], [AnioCarreraId], [Activo], [EspacioId], [CargaHoraria], [Modulos], [Multiple]) VALUES (1090, N'Espacio de Definición
Institucional
', 4010, 1, 3, 64, 2, NULL)
SET IDENTITY_INSERT [dbo].[Materias] OFF
GO
SET IDENTITY_INSERT [dbo].[Mensajes] ON 

INSERT [dbo].[Mensajes] ([MensajeId], [Mensaje], [Nombre], [FechaHora], [Asunto]) VALUES (1, N'asd', N'sad', CAST(N'2021-10-16T02:56:49.000' AS DateTime), N'asd')
SET IDENTITY_INSERT [dbo].[Mensajes] OFF
GO
SET IDENTITY_INSERT [dbo].[MesasFinales] ON 

INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (1, 1003, NULL, 1, 3, 1, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (2, 1003, NULL, 1, 3, 2, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (3, 1003, NULL, 1, 3, 3, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (4, 1003, NULL, 1, 3, 4, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (5, 1003, NULL, 1, 3, 5, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (6, 1003, NULL, 1, 3, 6, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (7, 1003, NULL, 1, 3, 7, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (8, 1003, NULL, 1, 3, 8, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (9, 1003, NULL, 1, 3, 9, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (10, 1003, NULL, 1, 3, 10, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (11, 1003, NULL, 1, 3, 11, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (12, 1003, NULL, 1, 3, 12, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (13, 1003, NULL, 1, 3, 13, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (14, 1003, NULL, 1, 3, 14, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (15, 1003, NULL, 1, 3, 15, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (16, 1003, NULL, 1, 3, 16, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (17, 1003, NULL, 1, 3, 17, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (18, 1003, NULL, 1, 3, 18, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (19, 1003, NULL, 1, 3, 19, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (20, 1003, NULL, 1, 3, 20, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (21, 1003, CAST(N'2024-08-24' AS Date), 1, 3, 21, 1, 2, 2024, 1)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (22, 1003, NULL, 1, 3, 22, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (23, 1003, NULL, 1, 3, 23, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (24, 1003, NULL, 1, 3, 24, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (25, 1004, NULL, 1, 3, 28, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (26, 1004, NULL, 1, 3, 29, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (27, 1004, NULL, 1, 3, 30, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (28, 1004, NULL, 1, 3, 31, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (29, 1004, NULL, 1, 3, 32, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (30, 1004, NULL, 1, 3, 33, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (31, 1004, NULL, 1, 3, 34, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (32, 1004, NULL, 1, 3, 35, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (33, 1004, NULL, 1, 3, 36, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (34, 1004, NULL, 1, 3, 38, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (35, 1004, NULL, 1, 3, 39, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (36, 1004, NULL, 1, 3, 40, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (37, 1004, NULL, 1, 3, 42, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (38, 1004, NULL, 1, 3, 43, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (39, 1004, NULL, 1, 3, 44, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (40, 1004, NULL, 1, 3, 46, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (41, 1004, NULL, 1, 3, 48, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (42, 1004, NULL, 1, 3, 49, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (43, 1004, NULL, 1, 3, 50, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (44, 1004, NULL, 1, 3, 51, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (45, 1004, NULL, 1, 3, 52, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (46, 1004, NULL, 1, 3, 53, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (47, 1004, NULL, 1, 3, 54, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (48, 1004, NULL, 1, 3, 55, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (49, 2010, NULL, 1, 3, 56, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (50, 2010, NULL, 1, 3, 57, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (51, 2010, NULL, 1, 3, 58, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (52, 2010, NULL, 1, 3, 60, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (53, 2010, NULL, 1, 3, 61, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (54, 2010, NULL, 1, 3, 62, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (55, 2010, NULL, 1, 3, 63, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (56, 2010, NULL, 1, 3, 64, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (57, 2010, NULL, 1, 3, 65, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (58, 2010, NULL, 1, 3, 66, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (59, 2010, NULL, 1, 3, 68, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (60, 2010, NULL, 1, 3, 70, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (61, 2010, NULL, 1, 3, 72, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (62, 2010, NULL, 1, 3, 73, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (63, 2010, NULL, 1, 3, 74, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (64, 2010, NULL, 1, 3, 75, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (65, 2010, NULL, 1, 3, 76, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (66, 2010, NULL, 1, 3, 77, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (67, 2010, NULL, 1, 3, 78, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (68, 2010, NULL, 1, 3, 80, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (69, 2010, NULL, 1, 3, 81, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (70, 2010, NULL, 1, 3, 83, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (71, 2010, NULL, 1, 3, 84, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (72, 2010, NULL, 1, 3, 85, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (73, 2010, NULL, 1, 3, 86, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (74, 2010, NULL, 1, 3, 87, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (75, 2010, NULL, 1, 3, 88, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (76, 2010, NULL, 1, 3, 89, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (77, 2010, NULL, 1, 3, 90, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (78, 3004, NULL, 1, 3, 91, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (79, 3004, NULL, 1, 3, 94, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (80, 3004, NULL, 1, 3, 96, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (81, 3004, NULL, 1, 3, 97, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (82, 3004, NULL, 1, 3, 98, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (83, 3004, NULL, 1, 3, 99, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (84, 3004, NULL, 1, 3, 100, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (85, 3004, NULL, 1, 3, 101, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (86, 3004, NULL, 1, 3, 102, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (87, 3004, NULL, 1, 3, 104, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (88, 3004, NULL, 1, 3, 105, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (89, 3004, NULL, 1, 3, 106, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (90, 3004, NULL, 1, 3, 107, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (91, 3004, NULL, 1, 3, 108, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (92, 3004, NULL, 1, 3, 109, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (93, 3004, NULL, 1, 3, 110, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (94, 3004, NULL, 1, 3, 111, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (95, 3004, NULL, 1, 3, 112, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (96, 3004, NULL, 1, 3, 113, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (97, 3004, NULL, 1, 3, 115, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (98, 3004, NULL, 1, 3, 116, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (99, 3004, NULL, 1, 3, 117, NULL, NULL, 2024, 3)
GO
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (100, 3004, NULL, 1, 3, 118, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (101, 3004, NULL, 1, 3, 119, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (102, 3004, NULL, 1, 3, 120, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (103, 3004, NULL, 1, 3, 121, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (104, 3004, NULL, 1, 3, 122, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (105, 3006, NULL, 1, 3, 1026, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (106, 3006, NULL, 1, 3, 1032, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (107, 3006, NULL, 1, 3, 1033, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (108, 3006, NULL, 1, 3, 1034, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (109, 3006, NULL, 1, 3, 1035, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (110, 3006, NULL, 1, 3, 1036, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (111, 3006, NULL, 1, 3, 1037, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (112, 3006, NULL, 1, 3, 1038, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (113, 3006, NULL, 1, 3, 1039, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (114, 3006, NULL, 1, 3, 1040, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (115, 3006, NULL, 1, 3, 1041, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (116, 3006, NULL, 1, 3, 1042, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (117, 3006, NULL, 1, 3, 1043, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (118, 3006, NULL, 1, 3, 1044, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (119, 3006, NULL, 1, 3, 1045, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (120, 3006, NULL, 1, 3, 1046, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (121, 3006, NULL, 1, 3, 1047, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (122, 3006, NULL, 1, 3, 1048, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (123, 3006, NULL, 1, 3, 1049, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (124, 3006, NULL, 1, 3, 1050, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (125, 3006, NULL, 1, 3, 1051, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (126, 3006, NULL, 1, 3, 1052, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (127, 3006, NULL, 1, 3, 1053, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (128, 3006, NULL, 1, 3, 1054, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (129, 3006, NULL, 1, 3, 1055, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (130, 3006, NULL, 1, 3, 1056, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (131, 3006, NULL, 1, 3, 1057, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (132, 3006, NULL, 1, 3, 1058, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (133, 3006, NULL, 1, 3, 1059, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (134, 3005, NULL, 1, 3, 1060, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (135, 3005, NULL, 1, 3, 1061, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (136, 3005, NULL, 1, 3, 1062, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (137, 3005, NULL, 1, 3, 1063, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (138, 3005, NULL, 1, 3, 1064, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (139, 3005, NULL, 1, 3, 1065, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (140, 3005, NULL, 1, 3, 1066, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (141, 3005, NULL, 1, 3, 1067, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (142, 3005, NULL, 1, 3, 1069, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (143, 3005, NULL, 1, 3, 1071, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (144, 3005, NULL, 1, 3, 1072, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (145, 3005, NULL, 1, 3, 1073, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (146, 3005, NULL, 1, 3, 1074, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (147, 3005, NULL, 1, 3, 1075, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (148, 3005, NULL, 1, 3, 1076, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (149, 3005, NULL, 1, 3, 1077, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (150, 3005, NULL, 1, 3, 1078, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (151, 3005, NULL, 1, 3, 1079, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (152, 3005, NULL, 1, 3, 1080, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (153, 3005, NULL, 1, 3, 1081, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (154, 3005, NULL, 1, 3, 1082, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (155, 3005, NULL, 1, 3, 1083, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (156, 3005, NULL, 1, 3, 1084, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (157, 3005, NULL, 1, 3, 1085, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (158, 3005, NULL, 1, 3, 1086, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (159, 3005, NULL, 1, 3, 1088, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (160, 3005, NULL, 1, 3, 1089, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (161, 3005, NULL, 1, 3, 1090, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (162, 1003, NULL, 2, 3, 1, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (163, 1003, NULL, 2, 3, 2, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (164, 1003, NULL, 2, 3, 3, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (165, 1003, NULL, 2, 3, 4, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (166, 1003, NULL, 2, 3, 5, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (167, 1003, NULL, 2, 3, 6, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (168, 1003, NULL, 2, 3, 7, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (169, 1003, NULL, 2, 3, 8, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (170, 1003, NULL, 2, 3, 9, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (171, 1003, NULL, 2, 3, 10, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (172, 1003, NULL, 2, 3, 11, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (173, 1003, NULL, 2, 3, 12, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (174, 1003, NULL, 2, 3, 13, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (175, 1003, NULL, 2, 3, 14, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (176, 1003, NULL, 2, 3, 15, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (177, 1003, NULL, 2, 3, 16, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (178, 1003, NULL, 2, 3, 17, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (179, 1003, NULL, 2, 3, 18, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (180, 1003, NULL, 2, 3, 19, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (181, 1003, NULL, 2, 3, 20, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (182, 1003, CAST(N'2024-08-10' AS Date), 2, 3, 21, 1, 2, 2024, 1)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (183, 1003, NULL, 2, 3, 22, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (184, 1003, NULL, 2, 3, 23, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (185, 1003, NULL, 2, 3, 24, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (186, 1004, NULL, 2, 3, 28, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (187, 1004, NULL, 2, 3, 29, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (188, 1004, NULL, 2, 3, 30, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (189, 1004, NULL, 2, 3, 31, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (190, 1004, NULL, 2, 3, 32, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (191, 1004, NULL, 2, 3, 33, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (192, 1004, NULL, 2, 3, 34, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (193, 1004, NULL, 2, 3, 35, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (194, 1004, NULL, 2, 3, 36, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (195, 1004, NULL, 2, 3, 38, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (196, 1004, NULL, 2, 3, 39, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (197, 1004, NULL, 2, 3, 40, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (198, 1004, NULL, 2, 3, 42, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (199, 1004, NULL, 2, 3, 43, NULL, NULL, 2024, 3)
GO
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (200, 1004, NULL, 2, 3, 44, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (201, 1004, NULL, 2, 3, 46, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (202, 1004, NULL, 2, 3, 48, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (203, 1004, NULL, 2, 3, 49, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (204, 1004, NULL, 2, 3, 50, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (205, 1004, NULL, 2, 3, 51, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (206, 1004, NULL, 2, 3, 52, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (207, 1004, NULL, 2, 3, 53, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (208, 1004, NULL, 2, 3, 54, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (209, 1004, NULL, 2, 3, 55, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (210, 2010, NULL, 2, 3, 56, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (211, 2010, NULL, 2, 3, 57, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (212, 2010, NULL, 2, 3, 58, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (213, 2010, NULL, 2, 3, 60, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (214, 2010, NULL, 2, 3, 61, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (215, 2010, NULL, 2, 3, 62, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (216, 2010, NULL, 2, 3, 63, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (217, 2010, NULL, 2, 3, 64, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (218, 2010, NULL, 2, 3, 65, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (219, 2010, NULL, 2, 3, 66, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (220, 2010, NULL, 2, 3, 68, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (221, 2010, NULL, 2, 3, 70, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (222, 2010, NULL, 2, 3, 72, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (223, 2010, NULL, 2, 3, 73, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (224, 2010, NULL, 2, 3, 74, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (225, 2010, NULL, 2, 3, 75, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (226, 2010, NULL, 2, 3, 76, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (227, 2010, NULL, 2, 3, 77, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (228, 2010, NULL, 2, 3, 78, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (229, 2010, NULL, 2, 3, 80, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (230, 2010, NULL, 2, 3, 81, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (231, 2010, NULL, 2, 3, 83, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (232, 2010, NULL, 2, 3, 84, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (233, 2010, NULL, 2, 3, 85, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (234, 2010, NULL, 2, 3, 86, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (235, 2010, NULL, 2, 3, 87, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (236, 2010, NULL, 2, 3, 88, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (237, 2010, NULL, 2, 3, 89, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (238, 2010, NULL, 2, 3, 90, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (239, 3004, NULL, 2, 3, 91, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (240, 3004, NULL, 2, 3, 94, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (241, 3004, NULL, 2, 3, 96, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (242, 3004, NULL, 2, 3, 97, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (243, 3004, NULL, 2, 3, 98, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (244, 3004, NULL, 2, 3, 99, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (245, 3004, NULL, 2, 3, 100, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (246, 3004, NULL, 2, 3, 101, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (247, 3004, NULL, 2, 3, 102, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (248, 3004, NULL, 2, 3, 104, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (249, 3004, NULL, 2, 3, 105, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (250, 3004, NULL, 2, 3, 106, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (251, 3004, NULL, 2, 3, 107, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (252, 3004, NULL, 2, 3, 108, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (253, 3004, NULL, 2, 3, 109, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (254, 3004, NULL, 2, 3, 110, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (255, 3004, NULL, 2, 3, 111, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (256, 3004, NULL, 2, 3, 112, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (257, 3004, NULL, 2, 3, 113, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (258, 3004, NULL, 2, 3, 115, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (259, 3004, NULL, 2, 3, 116, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (260, 3004, NULL, 2, 3, 117, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (261, 3004, NULL, 2, 3, 118, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (262, 3004, NULL, 2, 3, 119, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (263, 3004, NULL, 2, 3, 120, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (264, 3004, NULL, 2, 3, 121, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (265, 3004, NULL, 2, 3, 122, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (266, 3006, NULL, 2, 3, 1026, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (267, 3006, NULL, 2, 3, 1032, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (268, 3006, NULL, 2, 3, 1033, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (269, 3006, NULL, 2, 3, 1034, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (270, 3006, NULL, 2, 3, 1035, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (271, 3006, NULL, 2, 3, 1036, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (272, 3006, NULL, 2, 3, 1037, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (273, 3006, NULL, 2, 3, 1038, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (274, 3006, NULL, 2, 3, 1039, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (275, 3006, NULL, 2, 3, 1040, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (276, 3006, NULL, 2, 3, 1041, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (277, 3006, NULL, 2, 3, 1042, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (278, 3006, NULL, 2, 3, 1043, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (279, 3006, NULL, 2, 3, 1044, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (280, 3006, NULL, 2, 3, 1045, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (281, 3006, NULL, 2, 3, 1046, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (282, 3006, NULL, 2, 3, 1047, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (283, 3006, NULL, 2, 3, 1048, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (284, 3006, NULL, 2, 3, 1049, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (285, 3006, NULL, 2, 3, 1050, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (286, 3006, NULL, 2, 3, 1051, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (287, 3006, NULL, 2, 3, 1052, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (288, 3006, NULL, 2, 3, 1053, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (289, 3006, NULL, 2, 3, 1054, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (290, 3006, NULL, 2, 3, 1055, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (291, 3006, NULL, 2, 3, 1056, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (292, 3006, NULL, 2, 3, 1057, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (293, 3006, NULL, 2, 3, 1058, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (294, 3006, NULL, 2, 3, 1059, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (295, 3005, NULL, 2, 3, 1060, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (296, 3005, NULL, 2, 3, 1061, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (297, 3005, NULL, 2, 3, 1062, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (298, 3005, NULL, 2, 3, 1063, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (299, 3005, NULL, 2, 3, 1064, NULL, NULL, 2024, 3)
GO
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (300, 3005, NULL, 2, 3, 1065, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (301, 3005, NULL, 2, 3, 1066, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (302, 3005, NULL, 2, 3, 1067, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (303, 3005, NULL, 2, 3, 1069, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (304, 3005, NULL, 2, 3, 1071, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (305, 3005, NULL, 2, 3, 1072, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (306, 3005, NULL, 2, 3, 1073, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (307, 3005, NULL, 2, 3, 1074, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (308, 3005, NULL, 2, 3, 1075, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (309, 3005, NULL, 2, 3, 1076, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (310, 3005, NULL, 2, 3, 1077, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (311, 3005, NULL, 2, 3, 1078, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (312, 3005, NULL, 2, 3, 1079, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (313, 3005, NULL, 2, 3, 1080, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (314, 3005, NULL, 2, 3, 1081, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (315, 3005, NULL, 2, 3, 1082, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (316, 3005, NULL, 2, 3, 1083, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (317, 3005, NULL, 2, 3, 1084, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (318, 3005, NULL, 2, 3, 1085, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (319, 3005, NULL, 2, 3, 1086, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (320, 3005, NULL, 2, 3, 1088, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (321, 3005, NULL, 2, 3, 1089, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (322, 3005, NULL, 2, 3, 1090, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (323, 1003, NULL, 3, 1, 1, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (324, 1003, NULL, 3, 1, 2, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (325, 1003, NULL, 3, 1, 3, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (326, 1003, NULL, 3, 1, 4, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (327, 1003, NULL, 3, 1, 5, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (328, 1003, NULL, 3, 1, 6, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (329, 1003, NULL, 3, 1, 7, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (330, 1003, NULL, 3, 1, 8, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (331, 1003, NULL, 3, 1, 9, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (332, 1003, NULL, 3, 1, 10, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (333, 1003, NULL, 3, 1, 11, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (334, 1003, NULL, 3, 1, 12, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (335, 1003, NULL, 3, 1, 13, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (336, 1003, NULL, 3, 1, 14, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (337, 1003, NULL, 3, 1, 15, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (338, 1003, NULL, 3, 1, 16, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (339, 1003, NULL, 3, 1, 17, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (340, 1003, NULL, 3, 1, 18, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (341, 1003, NULL, 3, 1, 19, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (342, 1003, NULL, 3, 1, 20, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (343, 1003, NULL, 3, 1, 21, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (344, 1003, NULL, 3, 1, 22, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (345, 1003, NULL, 3, 1, 23, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (346, 1003, NULL, 3, 1, 24, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (347, 1004, NULL, 3, 1, 28, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (348, 1004, NULL, 3, 1, 29, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (349, 1004, NULL, 3, 1, 30, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (350, 1004, NULL, 3, 1, 31, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (351, 1004, NULL, 3, 1, 32, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (352, 1004, NULL, 3, 1, 33, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (353, 1004, NULL, 3, 1, 34, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (354, 1004, NULL, 3, 1, 35, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (355, 1004, NULL, 3, 1, 36, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (356, 1004, NULL, 3, 1, 38, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (357, 1004, NULL, 3, 1, 39, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (358, 1004, NULL, 3, 1, 40, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (359, 1004, NULL, 3, 1, 42, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (360, 1004, NULL, 3, 1, 43, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (361, 1004, NULL, 3, 1, 44, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (362, 1004, NULL, 3, 1, 46, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (363, 1004, NULL, 3, 1, 48, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (364, 1004, NULL, 3, 1, 49, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (365, 1004, NULL, 3, 1, 50, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (366, 1004, NULL, 3, 1, 51, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (367, 1004, NULL, 3, 1, 52, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (368, 1004, NULL, 3, 1, 53, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (369, 1004, NULL, 3, 1, 54, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (370, 1004, NULL, 3, 1, 55, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (371, 2010, NULL, 3, 1, 56, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (372, 2010, NULL, 3, 1, 57, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (373, 2010, NULL, 3, 1, 58, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (374, 2010, NULL, 3, 1, 60, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (375, 2010, NULL, 3, 1, 61, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (376, 2010, NULL, 3, 1, 62, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (377, 2010, NULL, 3, 1, 63, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (378, 2010, NULL, 3, 1, 64, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (379, 2010, NULL, 3, 1, 65, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (380, 2010, NULL, 3, 1, 66, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (381, 2010, NULL, 3, 1, 68, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (382, 2010, NULL, 3, 1, 70, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (383, 2010, NULL, 3, 1, 72, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (384, 2010, NULL, 3, 1, 73, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (385, 2010, NULL, 3, 1, 74, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (386, 2010, NULL, 3, 1, 75, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (387, 2010, NULL, 3, 1, 76, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (388, 2010, NULL, 3, 1, 77, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (389, 2010, NULL, 3, 1, 78, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (390, 2010, NULL, 3, 1, 80, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (391, 2010, NULL, 3, 1, 81, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (392, 2010, NULL, 3, 1, 83, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (393, 2010, NULL, 3, 1, 84, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (394, 2010, NULL, 3, 1, 85, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (395, 2010, NULL, 3, 1, 86, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (396, 2010, NULL, 3, 1, 87, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (397, 2010, NULL, 3, 1, 88, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (398, 2010, NULL, 3, 1, 89, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (399, 2010, NULL, 3, 1, 90, NULL, NULL, 2024, 3)
GO
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (400, 3004, NULL, 3, 1, 91, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (401, 3004, NULL, 3, 1, 94, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (402, 3004, NULL, 3, 1, 96, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (403, 3004, NULL, 3, 1, 97, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (404, 3004, NULL, 3, 1, 98, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (405, 3004, NULL, 3, 1, 99, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (406, 3004, NULL, 3, 1, 100, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (407, 3004, NULL, 3, 1, 101, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (408, 3004, NULL, 3, 1, 102, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (409, 3004, NULL, 3, 1, 104, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (410, 3004, NULL, 3, 1, 105, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (411, 3004, NULL, 3, 1, 106, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (412, 3004, NULL, 3, 1, 107, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (413, 3004, NULL, 3, 1, 108, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (414, 3004, NULL, 3, 1, 109, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (415, 3004, NULL, 3, 1, 110, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (416, 3004, NULL, 3, 1, 111, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (417, 3004, NULL, 3, 1, 112, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (418, 3004, NULL, 3, 1, 113, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (419, 3004, NULL, 3, 1, 115, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (420, 3004, NULL, 3, 1, 116, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (421, 3004, NULL, 3, 1, 117, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (422, 3004, NULL, 3, 1, 118, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (423, 3004, NULL, 3, 1, 119, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (424, 3004, NULL, 3, 1, 120, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (425, 3004, NULL, 3, 1, 121, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (426, 3004, NULL, 3, 1, 122, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (427, 3006, NULL, 3, 1, 1026, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (428, 3006, NULL, 3, 1, 1032, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (429, 3006, NULL, 3, 1, 1033, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (430, 3006, NULL, 3, 1, 1034, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (431, 3006, NULL, 3, 1, 1035, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (432, 3006, NULL, 3, 1, 1036, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (433, 3006, NULL, 3, 1, 1037, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (434, 3006, NULL, 3, 1, 1038, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (435, 3006, NULL, 3, 1, 1039, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (436, 3006, NULL, 3, 1, 1040, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (437, 3006, NULL, 3, 1, 1041, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (438, 3006, NULL, 3, 1, 1042, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (439, 3006, NULL, 3, 1, 1043, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (440, 3006, NULL, 3, 1, 1044, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (441, 3006, NULL, 3, 1, 1045, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (442, 3006, NULL, 3, 1, 1046, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (443, 3006, NULL, 3, 1, 1047, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (444, 3006, NULL, 3, 1, 1048, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (445, 3006, NULL, 3, 1, 1049, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (446, 3006, NULL, 3, 1, 1050, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (447, 3006, NULL, 3, 1, 1051, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (448, 3006, NULL, 3, 1, 1052, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (449, 3006, NULL, 3, 1, 1053, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (450, 3006, NULL, 3, 1, 1054, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (451, 3006, NULL, 3, 1, 1055, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (452, 3006, NULL, 3, 1, 1056, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (453, 3006, NULL, 3, 1, 1057, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (454, 3006, NULL, 3, 1, 1058, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (455, 3006, NULL, 3, 1, 1059, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (456, 3005, NULL, 3, 1, 1060, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (457, 3005, NULL, 3, 1, 1061, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (458, 3005, NULL, 3, 1, 1062, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (459, 3005, NULL, 3, 1, 1063, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (460, 3005, NULL, 3, 1, 1064, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (461, 3005, NULL, 3, 1, 1065, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (462, 3005, NULL, 3, 1, 1066, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (463, 3005, NULL, 3, 1, 1067, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (464, 3005, NULL, 3, 1, 1069, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (465, 3005, NULL, 3, 1, 1071, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (466, 3005, NULL, 3, 1, 1072, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (467, 3005, NULL, 3, 1, 1073, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (468, 3005, NULL, 3, 1, 1074, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (469, 3005, NULL, 3, 1, 1075, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (470, 3005, NULL, 3, 1, 1076, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (471, 3005, NULL, 3, 1, 1077, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (472, 3005, NULL, 3, 1, 1078, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (473, 3005, NULL, 3, 1, 1079, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (474, 3005, NULL, 3, 1, 1080, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (475, 3005, NULL, 3, 1, 1081, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (476, 3005, NULL, 3, 1, 1082, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (477, 3005, NULL, 3, 1, 1083, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (478, 3005, NULL, 3, 1, 1084, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (479, 3005, NULL, 3, 1, 1085, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (480, 3005, NULL, 3, 1, 1086, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (481, 3005, NULL, 3, 1, 1088, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (482, 3005, NULL, 3, 1, 1089, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (483, 3005, NULL, 3, 1, 1090, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (484, 1003, NULL, 3, 2, 1, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (485, 1003, NULL, 3, 2, 2, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (486, 1003, NULL, 3, 2, 3, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (487, 1003, NULL, 3, 2, 4, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (488, 1003, NULL, 3, 2, 5, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (489, 1003, NULL, 3, 2, 6, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (490, 1003, NULL, 3, 2, 7, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (491, 1003, NULL, 3, 2, 8, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (492, 1003, NULL, 3, 2, 9, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (493, 1003, NULL, 3, 2, 10, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (494, 1003, NULL, 3, 2, 11, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (495, 1003, NULL, 3, 2, 12, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (496, 1003, NULL, 3, 2, 13, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (497, 1003, NULL, 3, 2, 14, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (498, 1003, NULL, 3, 2, 15, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (499, 1003, NULL, 3, 2, 16, NULL, NULL, 2024, 3)
GO
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (500, 1003, NULL, 3, 2, 17, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (501, 1003, NULL, 3, 2, 18, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (502, 1003, NULL, 3, 2, 19, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (503, 1003, NULL, 3, 2, 20, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (504, 1003, CAST(N'2024-12-17' AS Date), 3, 2, 21, 1, 2, 2024, 1)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (505, 1003, NULL, 3, 2, 22, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (506, 1003, NULL, 3, 2, 23, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (507, 1003, NULL, 3, 2, 24, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (508, 1004, NULL, 3, 2, 28, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (509, 1004, NULL, 3, 2, 29, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (510, 1004, NULL, 3, 2, 30, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (511, 1004, NULL, 3, 2, 31, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (512, 1004, NULL, 3, 2, 32, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (513, 1004, NULL, 3, 2, 33, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (514, 1004, NULL, 3, 2, 34, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (515, 1004, NULL, 3, 2, 35, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (516, 1004, NULL, 3, 2, 36, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (517, 1004, NULL, 3, 2, 38, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (518, 1004, NULL, 3, 2, 39, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (519, 1004, NULL, 3, 2, 40, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (520, 1004, NULL, 3, 2, 42, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (521, 1004, NULL, 3, 2, 43, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (522, 1004, NULL, 3, 2, 44, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (523, 1004, NULL, 3, 2, 46, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (524, 1004, NULL, 3, 2, 48, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (525, 1004, NULL, 3, 2, 49, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (526, 1004, NULL, 3, 2, 50, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (527, 1004, NULL, 3, 2, 51, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (528, 1004, NULL, 3, 2, 52, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (529, 1004, NULL, 3, 2, 53, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (530, 1004, NULL, 3, 2, 54, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (531, 1004, NULL, 3, 2, 55, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (532, 2010, NULL, 3, 2, 56, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (533, 2010, NULL, 3, 2, 57, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (534, 2010, NULL, 3, 2, 58, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (535, 2010, NULL, 3, 2, 60, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (536, 2010, NULL, 3, 2, 61, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (537, 2010, NULL, 3, 2, 62, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (538, 2010, NULL, 3, 2, 63, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (539, 2010, NULL, 3, 2, 64, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (540, 2010, NULL, 3, 2, 65, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (541, 2010, NULL, 3, 2, 66, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (542, 2010, NULL, 3, 2, 68, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (543, 2010, NULL, 3, 2, 70, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (544, 2010, NULL, 3, 2, 72, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (545, 2010, NULL, 3, 2, 73, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (546, 2010, NULL, 3, 2, 74, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (547, 2010, NULL, 3, 2, 75, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (548, 2010, NULL, 3, 2, 76, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (549, 2010, NULL, 3, 2, 77, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (550, 2010, NULL, 3, 2, 78, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (551, 2010, NULL, 3, 2, 80, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (552, 2010, NULL, 3, 2, 81, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (553, 2010, NULL, 3, 2, 83, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (554, 2010, NULL, 3, 2, 84, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (555, 2010, NULL, 3, 2, 85, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (556, 2010, NULL, 3, 2, 86, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (557, 2010, NULL, 3, 2, 87, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (558, 2010, NULL, 3, 2, 88, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (559, 2010, NULL, 3, 2, 89, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (560, 2010, NULL, 3, 2, 90, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (561, 3004, NULL, 3, 2, 91, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (562, 3004, NULL, 3, 2, 94, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (563, 3004, NULL, 3, 2, 96, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (564, 3004, NULL, 3, 2, 97, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (565, 3004, NULL, 3, 2, 98, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (566, 3004, NULL, 3, 2, 99, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (567, 3004, NULL, 3, 2, 100, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (568, 3004, NULL, 3, 2, 101, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (569, 3004, NULL, 3, 2, 102, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (570, 3004, NULL, 3, 2, 104, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (571, 3004, NULL, 3, 2, 105, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (572, 3004, NULL, 3, 2, 106, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (573, 3004, NULL, 3, 2, 107, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (574, 3004, NULL, 3, 2, 108, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (575, 3004, NULL, 3, 2, 109, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (576, 3004, NULL, 3, 2, 110, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (577, 3004, NULL, 3, 2, 111, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (578, 3004, NULL, 3, 2, 112, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (579, 3004, NULL, 3, 2, 113, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (580, 3004, NULL, 3, 2, 115, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (581, 3004, NULL, 3, 2, 116, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (582, 3004, NULL, 3, 2, 117, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (583, 3004, NULL, 3, 2, 118, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (584, 3004, NULL, 3, 2, 119, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (585, 3004, NULL, 3, 2, 120, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (586, 3004, NULL, 3, 2, 121, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (587, 3004, NULL, 3, 2, 122, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (588, 3006, NULL, 3, 2, 1026, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (589, 3006, NULL, 3, 2, 1032, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (590, 3006, NULL, 3, 2, 1033, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (591, 3006, NULL, 3, 2, 1034, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (592, 3006, NULL, 3, 2, 1035, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (593, 3006, NULL, 3, 2, 1036, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (594, 3006, NULL, 3, 2, 1037, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (595, 3006, NULL, 3, 2, 1038, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (596, 3006, NULL, 3, 2, 1039, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (597, 3006, NULL, 3, 2, 1040, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (598, 3006, NULL, 3, 2, 1041, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (599, 3006, NULL, 3, 2, 1042, NULL, NULL, 2024, 3)
GO
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (600, 3006, NULL, 3, 2, 1043, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (601, 3006, NULL, 3, 2, 1044, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (602, 3006, NULL, 3, 2, 1045, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (603, 3006, NULL, 3, 2, 1046, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (604, 3006, NULL, 3, 2, 1047, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (605, 3006, NULL, 3, 2, 1048, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (606, 3006, NULL, 3, 2, 1049, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (607, 3006, NULL, 3, 2, 1050, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (608, 3006, NULL, 3, 2, 1051, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (609, 3006, NULL, 3, 2, 1052, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (610, 3006, NULL, 3, 2, 1053, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (611, 3006, NULL, 3, 2, 1054, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (612, 3006, NULL, 3, 2, 1055, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (613, 3006, NULL, 3, 2, 1056, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (614, 3006, NULL, 3, 2, 1057, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (615, 3006, NULL, 3, 2, 1058, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (616, 3006, NULL, 3, 2, 1059, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (617, 3005, NULL, 3, 2, 1060, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (618, 3005, NULL, 3, 2, 1061, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (619, 3005, NULL, 3, 2, 1062, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (620, 3005, NULL, 3, 2, 1063, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (621, 3005, NULL, 3, 2, 1064, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (622, 3005, NULL, 3, 2, 1065, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (623, 3005, NULL, 3, 2, 1066, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (624, 3005, NULL, 3, 2, 1067, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (625, 3005, NULL, 3, 2, 1069, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (626, 3005, NULL, 3, 2, 1071, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (627, 3005, NULL, 3, 2, 1072, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (628, 3005, NULL, 3, 2, 1073, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (629, 3005, NULL, 3, 2, 1074, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (630, 3005, NULL, 3, 2, 1075, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (631, 3005, NULL, 3, 2, 1076, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (632, 3005, NULL, 3, 2, 1077, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (633, 3005, NULL, 3, 2, 1078, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (634, 3005, NULL, 3, 2, 1079, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (635, 3005, NULL, 3, 2, 1080, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (636, 3005, NULL, 3, 2, 1081, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (637, 3005, NULL, 3, 2, 1082, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (638, 3005, NULL, 3, 2, 1083, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (639, 3005, NULL, 3, 2, 1084, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (640, 3005, NULL, 3, 2, 1085, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (641, 3005, NULL, 3, 2, 1086, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (642, 3005, NULL, 3, 2, 1088, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (643, 3005, NULL, 3, 2, 1089, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (644, 3005, NULL, 3, 2, 1090, NULL, NULL, 2024, 3)
INSERT [dbo].[MesasFinales] ([MesaFinalId], [CarreraId], [Fecha], [TurnoId], [LlamadoId], [MateriaId], [PresidenteId], [VocalId], [CicloLectivoId], [FinalEstadoId]) VALUES (649, 1003, CAST(N'2024-08-23' AS Date), 4, 3, 21, 1, 2, 2024, 1)
SET IDENTITY_INSERT [dbo].[MesasFinales] OFF
GO
SET IDENTITY_INSERT [dbo].[Modulos] ON 

INSERT [dbo].[Modulos] ([ModuloId], [Descripcion]) VALUES (1, N'Primera')
INSERT [dbo].[Modulos] ([ModuloId], [Descripcion]) VALUES (2, N'Segunda')
INSERT [dbo].[Modulos] ([ModuloId], [Descripcion]) VALUES (3, N'Tercera')
INSERT [dbo].[Modulos] ([ModuloId], [Descripcion]) VALUES (4, N'Cuarta')
SET IDENTITY_INSERT [dbo].[Modulos] OFF
GO
SET IDENTITY_INSERT [dbo].[Parametros] ON 

INSERT [dbo].[Parametros] ([ParametroId], [Nombre], [Descripcion], [Valor], [TipoId], [Activo]) VALUES (1, N'NuevoCicloLectivo', N'Fecha en que el sistema permite crear un nuevo ciclo lectivo', N'30-11-2022', 1, 1)
INSERT [dbo].[Parametros] ([ParametroId], [Nombre], [Descripcion], [Valor], [TipoId], [Activo]) VALUES (2, N'Paginacion', N'Numero de registros a mostrar por pagina', N'100', 3, 1)
INSERT [dbo].[Parametros] ([ParametroId], [Nombre], [Descripcion], [Valor], [TipoId], [Activo]) VALUES (3, N'Maximo x Cursos', NULL, N'32', 3, 1)
INSERT [dbo].[Parametros] ([ParametroId], [Nombre], [Descripcion], [Valor], [TipoId], [Activo]) VALUES (4, N'Hora Ingreso', NULL, N'18:30:00', 4, 1)
SET IDENTITY_INSERT [dbo].[Parametros] OFF
GO
SET IDENTITY_INSERT [dbo].[Personal] ON 

INSERT [dbo].[Personal] ([PersonalId], [NumeroDocumento], [Nombre], [Apellido], [FechaNacimiento], [Sexo], [Direccion], [Piso], [Departamento], [Localidad], [Celular], [Telefono], [Nacionalidad], [Email], [EstadoCivil], [Foto], [Titulo], [TramoPedagogico], [FechaAlta], [FechaBaja], [PersonalEstadoId]) VALUES (1, N'9999999', N'Carlos', N'Bouche', CAST(N'1960-06-25' AS Date), N'M', N'Alguna de por ahí 533', N'', N'', N'San Vicente', N'1122334455', N'1144442222', N'Argentina', N'cbouche@yahoo.com', N'Casado/a', N'', N'Ingeniero en Sistemas', 1, CAST(N'2023-05-19' AS Date), NULL, 1)
INSERT [dbo].[Personal] ([PersonalId], [NumeroDocumento], [Nombre], [Apellido], [FechaNacimiento], [Sexo], [Direccion], [Piso], [Departamento], [Localidad], [Celular], [Telefono], [Nacionalidad], [Email], [EstadoCivil], [Foto], [Titulo], [TramoPedagogico], [FechaAlta], [FechaBaja], [PersonalEstadoId]) VALUES (2, N'8888888', N'Mauricio', N'Torres Ramos', CAST(N'1990-08-30' AS Date), N'M', N'Ni idea 435', N'', N'', N'Alguna', N'1122334455', N'02225442233', N'Argentina', N'placeholdermail@gmail.com', N'Casado/a', N'', N'Analista Programador', 1, CAST(N'2023-09-13' AS Date), NULL, 1)
SET IDENTITY_INSERT [dbo].[Personal] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonalEstados] ON 

INSERT [dbo].[PersonalEstados] ([PersonalEstadoId], [Descripcion]) VALUES (1, N'Activa')
INSERT [dbo].[PersonalEstados] ([PersonalEstadoId], [Descripcion]) VALUES (2, N'Inactiva')
INSERT [dbo].[PersonalEstados] ([PersonalEstadoId], [Descripcion]) VALUES (3, N'Borrador')
SET IDENTITY_INSERT [dbo].[PersonalEstados] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicios] ON 

INSERT [dbo].[Servicios] ([ServicioId], [PersonalId], [SituacionRevistaId], [CargoId], [CursoMateriaId], [FechaAlta], [CantidadModulos], [Causa], [FechaBaja], [Personal], [Activo], [LibroActaId], [CarreraId], [Modulo], [Folio]) VALUES (1, 1, 1, 4, 21, CAST(N'2023-09-13' AS Date), NULL, NULL, NULL, NULL, 1, 1, 1003, 4, NULL)
INSERT [dbo].[Servicios] ([ServicioId], [PersonalId], [SituacionRevistaId], [CargoId], [CursoMateriaId], [FechaAlta], [CantidadModulos], [Causa], [FechaBaja], [Personal], [Activo], [LibroActaId], [CarreraId], [Modulo], [Folio]) VALUES (2, 2, 1, 4, 24, CAST(N'2023-09-14' AS Date), NULL, NULL, NULL, NULL, 1, 1, 1003, 2, NULL)
SET IDENTITY_INSERT [dbo].[Servicios] OFF
GO
SET IDENTITY_INSERT [dbo].[SituacionRevistas] ON 

INSERT [dbo].[SituacionRevistas] ([SituacionRevistaId], [Descripcion]) VALUES (1, N'Titular')
INSERT [dbo].[SituacionRevistas] ([SituacionRevistaId], [Descripcion]) VALUES (2, N'Provisional')
INSERT [dbo].[SituacionRevistas] ([SituacionRevistaId], [Descripcion]) VALUES (3, N'Suplente')
SET IDENTITY_INSERT [dbo].[SituacionRevistas] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoAplicacion] ON 

INSERT [dbo].[TipoAplicacion] ([TipoAplicacionId], [Descripcion], [Detalle]) VALUES (1, N'Unico', N'El personal toma el cargo y no puede ser tomado x otro ni tomar otro cargo.')
INSERT [dbo].[TipoAplicacion] ([TipoAplicacionId], [Descripcion], [Detalle]) VALUES (2, N'Unico  Repetible', N'Una vez asignado, el personal no puede asignarse otro cargo pero se puede asignar el cargo a otro personal.')
INSERT [dbo].[TipoAplicacion] ([TipoAplicacionId], [Descripcion], [Detalle]) VALUES (3, N'Repetible', N'Puede Asignarse, ser asignado por otros y a la vez asignarse a otros cargos.')
INSERT [dbo].[TipoAplicacion] ([TipoAplicacionId], [Descripcion], [Detalle]) VALUES (4, N'Exclusivo y Repetible', N'Puede asignarse varios cargos y ser asignado por varios. Pero una vez asignado el cargo no puede volver a asignarse el mismo cargo.')
SET IDENTITY_INSERT [dbo].[TipoAplicacion] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoAsignacion] ON 

INSERT [dbo].[TipoAsignacion] ([TipoAsignacionId], [Descripcion]) VALUES (1, N'No Asignar')
INSERT [dbo].[TipoAsignacion] ([TipoAsignacionId], [Descripcion]) VALUES (2, N'Asignar a Materia')
INSERT [dbo].[TipoAsignacion] ([TipoAsignacionId], [Descripcion]) VALUES (3, N'Asignar a Carrera')
SET IDENTITY_INSERT [dbo].[TipoAsignacion] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoLibros] ON 

INSERT [dbo].[TipoLibros] ([TipoLibroId], [Descripcion]) VALUES (1, N'Libro de Matriz')
INSERT [dbo].[TipoLibros] ([TipoLibroId], [Descripcion]) VALUES (2, N'Libro de Acta de Examenes')
INSERT [dbo].[TipoLibros] ([TipoLibroId], [Descripcion]) VALUES (3, N'Libro de Certificado Analitico')
SET IDENTITY_INSERT [dbo].[TipoLibros] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoParametro] ON 

INSERT [dbo].[TipoParametro] ([TipoParametroId], [Descripcion]) VALUES (1, N'Date')
INSERT [dbo].[TipoParametro] ([TipoParametroId], [Descripcion]) VALUES (2, N'Text')
INSERT [dbo].[TipoParametro] ([TipoParametroId], [Descripcion]) VALUES (3, N'Num')
INSERT [dbo].[TipoParametro] ([TipoParametroId], [Descripcion]) VALUES (4, N'Time')
SET IDENTITY_INSERT [dbo].[TipoParametro] OFF
GO
SET IDENTITY_INSERT [dbo].[Turnos] ON 

INSERT [dbo].[Turnos] ([TurnoId], [Descripcion]) VALUES (1, N'Marzo')
INSERT [dbo].[Turnos] ([TurnoId], [Descripcion]) VALUES (2, N'Julio')
INSERT [dbo].[Turnos] ([TurnoId], [Descripcion]) VALUES (3, N'Diciembre')
INSERT [dbo].[Turnos] ([TurnoId], [Descripcion]) VALUES (4, N'Especial')
SET IDENTITY_INSERT [dbo].[Turnos] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Parametr__75E3EFCF5C993DE6]    Script Date: 13/9/2025 12:10:35 ******/
ALTER TABLE [dbo].[Parametros] ADD UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Parametr__75E3EFCFAD2C34D7]    Script Date: 13/9/2025 12:10:35 ******/
ALTER TABLE [dbo].[Parametros] ADD UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AlumnosCarreras] ADD  CONSTRAINT [DF_Inicializado]  DEFAULT ('False') FOR [Inicializado]
GO
ALTER TABLE [dbo].[AniosCarreras] ADD  CONSTRAINT [df_CargaHoraria]  DEFAULT ((0)) FOR [CargaHorariaCompleta]
GO
ALTER TABLE [dbo].[Cargos] ADD  DEFAULT ((1)) FOR [TipoAplicacionId]
GO
ALTER TABLE [dbo].[Materias] ADD  DEFAULT ((0)) FOR [Modulos]
GO
ALTER TABLE [dbo].[TipoLicencias] ADD  DEFAULT ('True') FOR [Activo]
GO
ALTER TABLE [dbo].[AlumnosCarreras]  WITH CHECK ADD FOREIGN KEY([AlumnoId])
REFERENCES [dbo].[Alumnos] ([AlumnoId])
GO
ALTER TABLE [dbo].[AlumnosCarreras]  WITH CHECK ADD FOREIGN KEY([AlumnoId])
REFERENCES [dbo].[Alumnos] ([AlumnoId])
GO
ALTER TABLE [dbo].[AlumnosCarreras]  WITH CHECK ADD FOREIGN KEY([CarreraId])
REFERENCES [dbo].[Carreras] ([CarreraId])
GO
ALTER TABLE [dbo].[AlumnosCarreras]  WITH CHECK ADD FOREIGN KEY([CarreraId])
REFERENCES [dbo].[Carreras] ([CarreraId])
GO
ALTER TABLE [dbo].[AniosCarreras]  WITH CHECK ADD FOREIGN KEY([CarreraId])
REFERENCES [dbo].[Carreras] ([CarreraId])
GO
ALTER TABLE [dbo].[AniosCarreras]  WITH CHECK ADD FOREIGN KEY([CarreraId])
REFERENCES [dbo].[Carreras] ([CarreraId])
GO
ALTER TABLE [dbo].[Asistencias]  WITH CHECK ADD  CONSTRAINT [FKAsistenciaCursadaAlumnoCarrera] FOREIGN KEY([CursadaAlumnoCarreraId])
REFERENCES [dbo].[CursadaAlumnoCarreras] ([CursadaAlumnoCarreraId])
GO
ALTER TABLE [dbo].[Asistencias] CHECK CONSTRAINT [FKAsistenciaCursadaAlumnoCarrera]
GO
ALTER TABLE [dbo].[Cargos]  WITH CHECK ADD FOREIGN KEY([TipoAplicacionId])
REFERENCES [dbo].[TipoAplicacion] ([TipoAplicacionId])
GO
ALTER TABLE [dbo].[Cargos]  WITH CHECK ADD  CONSTRAINT [FKCargoTipoAsignacion] FOREIGN KEY([TipoAsignacionId])
REFERENCES [dbo].[TipoAsignacion] ([TipoAsignacionId])
GO
ALTER TABLE [dbo].[Cargos] CHECK CONSTRAINT [FKCargoTipoAsignacion]
GO
ALTER TABLE [dbo].[Carreras]  WITH CHECK ADD  CONSTRAINT [FKCarreraEstadoCarrrera] FOREIGN KEY([CarreraEstadoId])
REFERENCES [dbo].[CarreraEstados] ([CarreraEstadoId])
GO
ALTER TABLE [dbo].[Carreras] CHECK CONSTRAINT [FKCarreraEstadoCarrrera]
GO
ALTER TABLE [dbo].[Correlativas]  WITH CHECK ADD FOREIGN KEY([MateriaId])
REFERENCES [dbo].[Materias] ([MateriaId])
GO
ALTER TABLE [dbo].[Correlativas]  WITH CHECK ADD FOREIGN KEY([MateriaId])
REFERENCES [dbo].[Materias] ([MateriaId])
GO
ALTER TABLE [dbo].[Correlativas]  WITH CHECK ADD  CONSTRAINT [FKMateriaCorrelativaMateria] FOREIGN KEY([MateriaCorrelativaId])
REFERENCES [dbo].[Materias] ([MateriaId])
GO
ALTER TABLE [dbo].[Correlativas] CHECK CONSTRAINT [FKMateriaCorrelativaMateria]
GO
ALTER TABLE [dbo].[CursadaAlumnoCarreras]  WITH CHECK ADD FOREIGN KEY([AlumnoCarreraId])
REFERENCES [dbo].[AlumnosCarreras] ([AlumnoCarreraId])
GO
ALTER TABLE [dbo].[CursadaAlumnoCarreras]  WITH CHECK ADD FOREIGN KEY([AlumnoCarreraId])
REFERENCES [dbo].[AlumnosCarreras] ([AlumnoCarreraId])
GO
ALTER TABLE [dbo].[CursadaAlumnoCarreras]  WITH CHECK ADD FOREIGN KEY([CursadaId])
REFERENCES [dbo].[Cursadas] ([CursadaId])
GO
ALTER TABLE [dbo].[CursadaAlumnoCarreras]  WITH CHECK ADD FOREIGN KEY([CursadaId])
REFERENCES [dbo].[Cursadas] ([CursadaId])
GO
ALTER TABLE [dbo].[Cursadas]  WITH CHECK ADD FOREIGN KEY([CursoMateriaId])
REFERENCES [dbo].[CursoMaterias] ([CursoMateriaId])
GO
ALTER TABLE [dbo].[Cursadas]  WITH CHECK ADD FOREIGN KEY([CursoMateriaId])
REFERENCES [dbo].[CursoMaterias] ([CursoMateriaId])
GO
ALTER TABLE [dbo].[CursoMaterias]  WITH CHECK ADD FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursos] ([CursoId])
GO
ALTER TABLE [dbo].[CursoMaterias]  WITH CHECK ADD FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursos] ([CursoId])
GO
ALTER TABLE [dbo].[CursoMaterias]  WITH CHECK ADD FOREIGN KEY([MateriaId])
REFERENCES [dbo].[Materias] ([MateriaId])
GO
ALTER TABLE [dbo].[CursoMaterias]  WITH CHECK ADD FOREIGN KEY([MateriaId])
REFERENCES [dbo].[Materias] ([MateriaId])
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD FOREIGN KEY([AnioCarreraId])
REFERENCES [dbo].[AniosCarreras] ([AnioCarreraId])
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD FOREIGN KEY([AnioCarreraId])
REFERENCES [dbo].[AniosCarreras] ([AnioCarreraId])
GO
ALTER TABLE [dbo].[Equivalencias]  WITH CHECK ADD FOREIGN KEY([CarreraId])
REFERENCES [dbo].[Carreras] ([CarreraId])
GO
ALTER TABLE [dbo].[Equivalencias]  WITH CHECK ADD FOREIGN KEY([CarreraEquivalenciaId])
REFERENCES [dbo].[Carreras] ([CarreraId])
GO
ALTER TABLE [dbo].[Equivalencias]  WITH CHECK ADD FOREIGN KEY([MateriaId])
REFERENCES [dbo].[Materias] ([MateriaId])
GO
ALTER TABLE [dbo].[Equivalencias]  WITH CHECK ADD FOREIGN KEY([MateriaEquivalenciaId])
REFERENCES [dbo].[Materias] ([MateriaId])
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD FOREIGN KEY([CursoMateriaId])
REFERENCES [dbo].[CursoMaterias] ([CursoMateriaId])
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD FOREIGN KEY([CursoMateriaId])
REFERENCES [dbo].[CursoMaterias] ([CursoMateriaId])
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD FOREIGN KEY([DiaId])
REFERENCES [dbo].[Dias] ([DiaId])
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD FOREIGN KEY([DiaId])
REFERENCES [dbo].[Dias] ([DiaId])
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD FOREIGN KEY([ModuloId])
REFERENCES [dbo].[Modulos] ([ModuloId])
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD FOREIGN KEY([ModuloId])
REFERENCES [dbo].[Modulos] ([ModuloId])
GO
ALTER TABLE [dbo].[LibroActas]  WITH CHECK ADD FOREIGN KEY([TipoLibroId])
REFERENCES [dbo].[TipoLibros] ([TipoLibroId])
GO
ALTER TABLE [dbo].[LibroActas]  WITH CHECK ADD FOREIGN KEY([TipoLibroId])
REFERENCES [dbo].[TipoLibros] ([TipoLibroId])
GO
ALTER TABLE [dbo].[Licencias]  WITH CHECK ADD FOREIGN KEY([PersonalId])
REFERENCES [dbo].[Personal] ([PersonalId])
GO
ALTER TABLE [dbo].[Licencias]  WITH CHECK ADD FOREIGN KEY([PersonalId])
REFERENCES [dbo].[Personal] ([PersonalId])
GO
ALTER TABLE [dbo].[Licencias]  WITH CHECK ADD  CONSTRAINT [FK__Licencias__TipoL] FOREIGN KEY([TipoLicenciaId])
REFERENCES [dbo].[TipoLicencias] ([TipoLicenciaId])
GO
ALTER TABLE [dbo].[Licencias] CHECK CONSTRAINT [FK__Licencias__TipoL]
GO
ALTER TABLE [dbo].[Licencias]  WITH CHECK ADD FOREIGN KEY([TipoLicenciaId])
REFERENCES [dbo].[TipoLicencias] ([TipoLicenciaId])
GO
ALTER TABLE [dbo].[LicenciaServicios]  WITH CHECK ADD FOREIGN KEY([LicenciaId])
REFERENCES [dbo].[Licencias] ([LicenciaId])
GO
ALTER TABLE [dbo].[LicenciaServicios]  WITH CHECK ADD FOREIGN KEY([LicenciaId])
REFERENCES [dbo].[Licencias] ([LicenciaId])
GO
ALTER TABLE [dbo].[LicenciaServicios]  WITH CHECK ADD FOREIGN KEY([ServicioId])
REFERENCES [dbo].[Servicios] ([ServicioId])
GO
ALTER TABLE [dbo].[LicenciaServicios]  WITH CHECK ADD FOREIGN KEY([ServicioId])
REFERENCES [dbo].[Servicios] ([ServicioId])
GO
ALTER TABLE [dbo].[Materias]  WITH CHECK ADD FOREIGN KEY([AnioCarreraId])
REFERENCES [dbo].[AniosCarreras] ([AnioCarreraId])
GO
ALTER TABLE [dbo].[Materias]  WITH CHECK ADD FOREIGN KEY([AnioCarreraId])
REFERENCES [dbo].[AniosCarreras] ([AnioCarreraId])
GO
ALTER TABLE [dbo].[Materias]  WITH CHECK ADD FOREIGN KEY([EspacioId])
REFERENCES [dbo].[Espacios] ([EspacioId])
GO
ALTER TABLE [dbo].[Materias]  WITH CHECK ADD FOREIGN KEY([EspacioId])
REFERENCES [dbo].[Espacios] ([EspacioId])
GO
ALTER TABLE [dbo].[MesasFinales]  WITH CHECK ADD FOREIGN KEY([CarreraId])
REFERENCES [dbo].[Carreras] ([CarreraId])
GO
ALTER TABLE [dbo].[MesasFinales]  WITH CHECK ADD FOREIGN KEY([CicloLectivoId])
REFERENCES [dbo].[CicloLectivo] ([AnioLectivo])
GO
ALTER TABLE [dbo].[MesasFinales]  WITH CHECK ADD FOREIGN KEY([FinalEstadoId])
REFERENCES [dbo].[FinalEstados] ([FinalEstadoId])
GO
ALTER TABLE [dbo].[MesasFinales]  WITH CHECK ADD FOREIGN KEY([LlamadoId])
REFERENCES [dbo].[Llamados] ([LlamadoId])
GO
ALTER TABLE [dbo].[MesasFinales]  WITH CHECK ADD FOREIGN KEY([MateriaId])
REFERENCES [dbo].[Materias] ([MateriaId])
GO
ALTER TABLE [dbo].[MesasFinales]  WITH CHECK ADD FOREIGN KEY([PresidenteId])
REFERENCES [dbo].[Personal] ([PersonalId])
GO
ALTER TABLE [dbo].[MesasFinales]  WITH CHECK ADD FOREIGN KEY([TurnoId])
REFERENCES [dbo].[Turnos] ([TurnoId])
GO
ALTER TABLE [dbo].[MesasFinales]  WITH CHECK ADD FOREIGN KEY([VocalId])
REFERENCES [dbo].[Personal] ([PersonalId])
GO
ALTER TABLE [dbo].[Parametros]  WITH CHECK ADD FOREIGN KEY([TipoId])
REFERENCES [dbo].[TipoParametro] ([TipoParametroId])
GO
ALTER TABLE [dbo].[Parametros]  WITH CHECK ADD FOREIGN KEY([TipoId])
REFERENCES [dbo].[TipoParametro] ([TipoParametroId])
GO
ALTER TABLE [dbo].[Personal]  WITH CHECK ADD FOREIGN KEY([PersonalEstadoId])
REFERENCES [dbo].[PersonalEstados] ([PersonalEstadoId])
GO
ALTER TABLE [dbo].[Personal]  WITH CHECK ADD FOREIGN KEY([PersonalEstadoId])
REFERENCES [dbo].[PersonalEstados] ([PersonalEstadoId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([CargoId])
REFERENCES [dbo].[Cargos] ([CargoId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([CargoId])
REFERENCES [dbo].[Cargos] ([CargoId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([CursoMateriaId])
REFERENCES [dbo].[CursoMaterias] ([CursoMateriaId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([CursoMateriaId])
REFERENCES [dbo].[CursoMaterias] ([CursoMateriaId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([LibroActaId])
REFERENCES [dbo].[LibroActas] ([LibroActaId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([LibroActaId])
REFERENCES [dbo].[LibroActas] ([LibroActaId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([PersonalId])
REFERENCES [dbo].[Personal] ([PersonalId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([PersonalId])
REFERENCES [dbo].[Personal] ([PersonalId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([SituacionRevistaId])
REFERENCES [dbo].[SituacionRevistas] ([SituacionRevistaId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([SituacionRevistaId])
REFERENCES [dbo].[SituacionRevistas] ([SituacionRevistaId])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [FKServicioCarrera] FOREIGN KEY([CarreraId])
REFERENCES [dbo].[Carreras] ([CarreraId])
GO
ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [FKServicioCarrera]
GO
/****** Object:  StoredProcedure [dbo].[ListaLocalidades]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListaLocalidades]
AS
BEGIN
create table #localidades ( LOCALIDAD varchar(50) );

INSERT INTO #localidades
SELECT  Localidad AS LOCALIDAD FROM Alumnos
UNION
SELECT  LocalidadNacimiento AS LOCALIDAD FROM Alumnos

select DISTINCT LOCALIDAD FROM #localidades

DROP TABLE #localidades
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarPorcentajeAsistencia]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE procedure [dbo].[SP_ActualizarPorcentajeAsistencia](@HorascursadasCa int, @PorcentajeAsistenciaCa decimal, @UltimoPresentismoCa date, @FechaAsistencia date, 
  @HoraCatedraC int, @PorcentajeAsistenciaC decimal, @CursadaId int, @AlumnoCarreraId int, @Asistencia char, @CursadaAlumnoCarreraId int)
 as 
 begin
 update CursadaAlumnoCarreras set PorcentajeAsistencia = @PorcentajeAsistenciaCa, UltimoPresentismo = @UltimoPresentismoCa, HorasCursadas = @HorascursadasCa
 where AlumnoCarreraId = @AlumnoCarreraId;
 update Cursadas set HoraCatedra = @HoraCatedraC, PorcentajeAsistencia = @PorcentajeAsistenciaC, FechaAsistencia = @FechaAsistencia
 where CursadaId = @CursadaId;
 update Asistencias set Asistencia = @Asistencia where CursadaAlumnoCarreraId = @CursadaAlumnoCarreraId;
 end
GO
/****** Object:  StoredProcedure [dbo].[SP_CargaCursadas]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_CargaCursadas] (@AnioLectivoId INT)
AS
BEGIN
CREATE TABLE #CursoMaterias(CursoMateriaId INT);
CREATE TABLE #Cursadas(CursoMateriaId INT);

INSERT INTO #Cursadas
SELECT c.CursoMateriaId FROM Cursadas c
WHERE c.AnioLectivo = @AnioLectivoId;

INSERT INTO #CursoMaterias
SELECT cm.CursoMateriaId FROM CursoMaterias cm
INNER JOIN Cursos cur ON cm.CursoId = cur.CursoId
INNER JOIN AniosCarreras ac ON cur.AnioCarreraId = ac.AnioCarreraId
INNER JOIN Carreras car ON ac.CarreraId = car.CarreraId
WHERE
	car.CarreraEstadoId = 1 AND
	cur.Activo = 1 AND
	cm.CursoMateriaId NOT IN (SELECT CursoMateriaId FROM #Cursadas);

INSERT INTO Cursadas (CursoMateriaId, AnioLectivo)
SELECT CursoMateriaId, @AnioLectivoId FROM #CursoMaterias;

DROP TABLE #CursoMaterias;
DROP TABLE #Cursadas;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CargosLibres]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CargosLibres]
@PersonalId int
AS
BEGIN

	--Carga los Cargos Unicos
	Create table #Unico(
	CargoId int
	)
	INSERT INTO #Unico 
	SELECT CargoId FROM Cargos WHERE TipoAplicacionId = 1

	--Carga los Cargos Unicos y Repetibles
	Create table #UnicoRepetible(
	CargoId int
	)
	INSERT INTO #UnicoRepetible 
	SELECT CargoId FROM Cargos WHERE TipoAplicacionId = 2

	--Carga los Cargos Repetibles
	Create table #Repetible(
	CargoId int
	)
	INSERT INTO #Repetible 
	SELECT CargoId FROM Cargos WHERE TipoAplicacionId = 3

	--Carga los Cargos Exclusivos y Repetibles
	Create table #EsclusivoRepetible(
	CargoId int
	)
	INSERT INTO #EsclusivoRepetible 
	SELECT CargoId FROM Cargos WHERE TipoAplicacionId = 4

	--Cargos que dispone la persona
	Create Table #CargosTomados(
	CargoId int
	)
	INSERT INTO #CargosTomados
	SELECT CargoId From Servicios WHERE PersonalId = @PersonalId AND Activo = 'true';

	Create Table #CargosDisponibles(
	CargoId int
	)

	--Carga los Cargos que no sean unicos
	INSERT INTO #CargosDisponibles 
	SELECT CargoId FROM Cargos 
	WHERE CargoId NOT IN (SELECT CargoId FROM Servicios WHERE CargoId IN (SELECT CargoId FROM #Unico) AND Activo = 'True') 
	AND Activo = 'True'

	IF EXISTS (SELECT CargoId From #CargosTomados WHERE CargoId IN (SELECT CargoId FROM #Unico) OR CargoId IN (SELECT CargoId FROM #UnicoRepetible))
		BEGIN
			DELETE FROM #CargosDisponibles
		END
	ELSE IF EXISTS (SELECT CargoId From #CargosTomados WHERE CargoId IN (SELECT CargoId FROM #EsclusivoRepetible))
		BEGIN
			DELETE FROM #CargosDisponibles WHERE CargoId IN (SELECT CargoId From #CargosTomados WHERE CargoId IN (SELECT CargoId FROM #EsclusivoRepetible))				
		END

	SELECT * From Cargos WHERE CargoId IN (SELECT CargoId FROM #CargosDisponibles)

	drop table #Unico
	drop table #UnicoRepetible
	drop table #CargosDisponibles
	drop table #CargosTomados
	drop table #EsclusivoRepetible
	drop table #Repetible
END

GO
/****** Object:  StoredProcedure [dbo].[SP_CarrerasDisponibles]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CarrerasDisponibles](
@TipoAsignacionId as int,
@SituacionRevistaId as int
)
AS
BEGIN 
	IF(@TipoAsignacionId = 3 AND (@SituacionRevistaId = 2 OR @SituacionRevistaId = 1))
		BEGIN		
			SELECT CarreraId, DescripcionCorta FROM Carreras WHERE Activo= 'True' AND CarreraId NOT IN (SELECT CarreraId From Servicios WHERE Activo = 'True')			
		END
	ELSE IF(@TipoAsignacionId = 3 AND @SituacionRevistaId = 3)
		BEGIN
			SELECT CarreraId, DescripcionCorta FROM Carreras WHERE Activo= 'True' AND CarreraId IN (SELECT CarreraId From Servicios WHERE Activo = 'True')
			AND (CarreraId IN (SELECT CarreraId FROM Servicios se INNER JOIN LicenciaServicios ls ON se.ServicioId = ls.ServicioId
			INNER JOIN Licencias li ON li.LicenciaId = ls.LicenciaId WHERE li.FechaBaja IS NULL))
		END
	ELSE
		BEGIN
			SELECT * FROM Carreras WHERE  Activo= 'True'
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CrearMesasFinales]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CrearMesasFinales](@anioLectivo int, @turnoId int)
as
begin
declare @Llamado int, @LlamadoMax int
set @Llamado = 0
set @LlamadoMax = (select MAX(LlamadoId) from MesasFinales where CicloLectivoId = @anioLectivo)
if (@LlamadoMax is null)
set @LlamadoMax = 2
if (select MAX(MesaFinalId) from MesasFinales where CicloLectivoId = @anioLectivo and TurnoId = @turnoId) is null
begin
if (@turnoId != 3)
begin
insert into MesasFinales (CarreraId, TurnoId, LlamadoId, MateriaId, CicloLectivoId, FinalEstadoId) 
select C.CarreraId, @turnoId, 3, M.MateriaId, @anioLectivo, 3 from Materias M 
inner join AniosCarreras AC on M.AnioCarreraId = AC.AnioCarreraId
inner join Carreras C on AC.CarreraId = C.CarreraId
end
else
while (@Llamado < @LlamadoMax)
begin
if (@Llamado = 0 or @Llamado = 2)
set @Llamado = 1
else
set @Llamado = @Llamado + 1
insert into MesasFinales (CarreraId, TurnoId, LlamadoId, MateriaId, CicloLectivoId, FinalEstadoId) 
select C.CarreraId, @turnoId, @Llamado, M.MateriaId, @anioLectivo, 3 from Materias M 
inner join AniosCarreras AC on M.AnioCarreraId = AC.AnioCarreraId
inner join Carreras C on AC.CarreraId = C.CarreraId
if (@Llamado = 2)
break
end
end
else
begin;
THROW 51000, 'Ya hay mesas finales para dicho Turno y Ciclo Lectivo', 1;
end
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CursoMateriasLibres]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CursoMateriasLibres](
@CursoId as int,
@TipoAsignacionId as int,
@SituacionRevistaId as int
)
AS
BEGIN 
	IF(@TipoAsignacionId = 2 AND (@SituacionRevistaId = 2 OR @SituacionRevistaId = 1))
		BEGIN		
			SELECT cm.CursoMateriaId, ma.Nombre FROM CursoMaterias cm FULL JOIN materias ma ON cm.MateriaId=ma.MateriaId 
			WHERE cursoid=@CursoId AND cm.Activo= 'True' AND (cm.CursoMateriaId NOT IN (SELECT CursoMateriaId FROM Servicios WHERE Activo = 'True') 
			OR cm.CursoMateriaId IN (SELECT CursoMateriaId FROM CursoMaterias AS CM INNER JOIN Materias AS MA ON CM.MateriaId = MA.MateriaId
			WHERE MA.Multiple = 'True'))			
		END
	ELSE IF(@TipoAsignacionId = 2 AND @SituacionRevistaId = 3)
		BEGIN
			SELECT cm.CursoMateriaId, ma.Nombre FROM CursoMaterias cm FULL JOIN materias ma ON cm.MateriaId=ma.MateriaId 
			WHERE cursoid=@CursoId AND cm.Activo= 'True' AND (cm.CursoMateriaId IN (SELECT CursoMateriaId FROM Servicios WHERE Activo = 'True')
			AND (cm.CursoMateriaId IN (SELECT se.CursoMateriaId FROM Servicios se INNER JOIN LicenciaServicios ls ON se.ServicioId = ls.ServicioId
			INNER JOIN Licencias li ON li.LicenciaId = ls.LicenciaId WHERE li.FechaBaja IS NULL)))
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CursoMateriasLibres2]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CursoMateriasLibres2](
@CursoId as int,
@TipoAsignacionId as int,
@SituacionRevistaId as int
)
AS
BEGIN 
	IF(@TipoAsignacionId = 2 AND (@SituacionRevistaId = 2 OR @SituacionRevistaId = 1))
		BEGIN		
			SELECT cm.CursoMateriaId, ma.Nombre FROM CursoMaterias cm FULL JOIN materias ma ON cm.MateriaId=ma.MateriaId 
			WHERE cursoid=@CursoId AND cm.Activo= 'True' AND (cm.CursoMateriaId NOT IN (SELECT CursoMateriaId FROM Servicios WHERE Activo = 'True') 
			OR cm.CursoMateriaId IN (SELECT CursoMateriaId FROM CursoMaterias AS CM INNER JOIN Materias AS MA ON CM.MateriaId = MA.MateriaId
			WHERE MA.Multiple = 'True'))			
		END
	ELSE IF(@TipoAsignacionId = 2 AND @SituacionRevistaId = 3)
		BEGIN
			SELECT cm.CursoMateriaId, ma.Nombre FROM CursoMaterias cm FULL JOIN materias ma ON cm.MateriaId=ma.MateriaId 
			WHERE cursoid=@CursoId AND cm.Activo= 'True' AND (cm.CursoMateriaId IN (SELECT CursoMateriaId FROM Servicios WHERE Activo = 'True')
			AND (cm.CursoMateriaId IN (SELECT se.CursoMateriaId FROM Servicios se INNER JOIN LicenciaServicios ls ON se.ServicioId = ls.ServicioId
			INNER JOIN Licencias li ON li.LicenciaId = ls.LicenciaId WHERE li.FechaBaja IS NULL)))
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ExistenFechasFinales]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ExistenFechasFinales] (@anioLectivo int)
as
begin
declare @fecha1 date, @fecha2 date, @fecha3 date, @fecha4 date, @fecha5 date, @fecha6 date, @resultadoMarzo bit, @resultadoJulio bit, @resultadoDiciembre bit
set @fecha1 = (select FechaMarzoInicio from CicloLectivo where AnioLectivo = @anioLectivo)
set @fecha2 = (select FechaMarzoFinal from CicloLectivo where AnioLectivo = @anioLectivo)
set @fecha3 = (select FechaJunioInicio from CicloLectivo where AnioLectivo = @anioLectivo)
set @fecha4 = (select FechaJunioFinal from CicloLectivo where AnioLectivo = @anioLectivo)
set @fecha5 = (select FechaDiciembreInicio from CicloLectivo where AnioLectivo = @anioLectivo)
set @fecha6 = (select FechaDiciembreFinal from CicloLectivo where AnioLectivo = @anioLectivo)
begin
if (@fecha1 is not null and @fecha2 is not null)
set @resultadoMarzo = 1
else
set @resultadoMarzo = 0
end
begin
if (@fecha3 is not null and @fecha4 is not null)
set @resultadoJulio = 1
else
set @resultadoJulio = 0
end
begin
if (@fecha5 is not null and @fecha6 is not null)
set @resultadoDiciembre = 1
else
set @resultadoDiciembre = 0
end
select @resultadoMarzo as 'Marzo', @resultadoJulio as 'Julio', @resultadoDiciembre as 'Diciembre'
end
GO
/****** Object:  StoredProcedure [dbo].[SP_IngresoCursadaPrimero]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [dbo].[SP_IngresoCursadaPrimero] (@AnioLectivoId int)
 AS
 BEGIN   

-- Tabla para almacenar la cantidad de cursos por carrera
CREATE TABLE #CursosTotales
(
	CarreraId INT,
	Cursos INT
);

-- Tabla que contiene los cursos
-- y define un código dependiendo de la cantidad de cursos por carrera
CREATE TABLE #CursosPrimero
(
	CarreraId INT,
	CursoId INT,
	Curso VARCHAR(10),
	Codigo INT
);

-- Tabla que contiene los alumnos no inicializado 
-- y define un código dependiendo de la cantidad de cursos por carrera
CREATE TABlE #AlumnosNoInicializados
(
	Codigo INT,
	AlumnoCarreraId INT,
	CarreraId INT
);

-- Tabla para almacenar los alumnos que ya están inscriptos
-- y así avitar duplicidad
CREATE TABLE #AlumnosInscriptos
(
	AlumnoCarreraId INT,
);

-- Busco los cuantos cursos de primero existe por carrera
INSERT INTO #CursosTotales
SELECT CarreraId, COUNT(CursoId) Cursos
FROM Cursos c
INNER JOIN AniosCarreras ac ON c.AnioCarreraId = ac.AnioCarreraId AND ac.AnioCarrera = 1
GROUP BY ac.CarreraId;

-- Le asigno un codigo al curso dependiendo la cantidad de cursos de primero de la carrera
INSERT INTO #CursosPrimero
SELECT
ac.CarreraId,
c.CursoId CursoId,
c.NombreCurso AS Curso,
IIF( ROW_NUMBER() OVER(ORDER BY c.CursoId ASC) % #CursosTotales.Cursos = 0, #CursosTotales.Cursos,  ROW_NUMBER() OVER(ORDER BY c.CursoId ASC) % #CursosTotales.Cursos) AS Codigo
FROM Cursos c
INNER JOIN AniosCarreras ac ON c.AnioCarreraId = ac.AnioCarreraId AND ac.AnioCarrera = 1
INNER JOIN #CursosTotales ON ac.CarreraId = #CursosTotales.CarreraId;

-- Le asigno un codigo al alumno dependiendo la cantidad de cursos de primero de la carrera
INSERT INTO #AlumnosNoInicializados
SELECT
IIF( ROW_NUMBER() OVER(ORDER BY AlumnoCarreraId ASC) % #CursosTotales.Cursos = 0, #CursosTotales.Cursos,  ROW_NUMBER() OVER(ORDER BY AlumnoCarreraId ASC) % #CursosTotales.Cursos) AS Codigo, 
AlumnoCarreraId,
alc.CarreraId
FROM AlumnosCarreras alc
INNER JOIN #CursosTotales ON alc.CarreraId = #CursosTotales.CarreraId
WHERE alc.Inicializado = 0;

INSERT INTO #AlumnosInscriptos
SELECT car.AlumnoCarreraId FROM CursadaAlumnoCarreras car
INNER JOIN #AlumnosNoInicializados ani ON car.AlumnoCarreraId = ani.AlumnoCarreraId;

-- Se distribuye los alumnos en los distintos cursos de 1ro 
-- respetando el código asignado al alumno y al curso
INSERT INTO CursadaAlumnoCarreras
SELECT
	ani.AlumnoCarreraId,
	curs.CursadaId,
	@AnioLectivoId,
	'CU',
	0,
	NULL,
	0,
	NULL,
	1
FROM #AlumnosNoInicializados ani
INNER JOIN Carreras c ON ani.CarreraId = c.CarreraId
INNER JOIN AniosCarreras anc ON c.CarreraId = anc.CarreraId AND anc.AnioCarrera = 1
INNER JOIN #CursosPrimero cp ON ani.Codigo = cp.Codigo
INNER JOIN CursoMaterias cuma ON cp.CursoId = cuma.CursoId
INNER JOIN Materias m ON cuma.MateriaId = m.MateriaId
INNER JOIN Cursadas curs ON cuma.CursoMateriaId = curs.CursoMateriaId AND curs.AnioLectivo = @AnioLectivoId
WHERE ani.AlumnoCarreraId NOT IN (SELECT AlumnoCarreraId FROM #AlumnosInscriptos);

-- Establezco que los alumnos ya se encuentran inicializados
UPDATE AlumnosCarreras SET Inicializado = 1
WHERE AlumnoCarreraId IN (SELECT AlumnoCarreraId FROM #AlumnosNoInicializados);

-- Elimino todas las tablas temporales
DROP TABLE #AlumnosNoInicializados;
DROP TABLE #AlumnosInscriptos;
DROP TABLE #CursosPrimero;
DROP TABLE #CursosTotales;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InscripcionAlumnos]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InscripcionAlumnos]  ( @AnioLectivoId As int)
 AS
 BEGIN

 -- Tabla que almacena alumnos no inicializados
 CREATE TABLE #AlumnosNoInicializados
 (
	CarreraId INT,
	Alumnos INT
 );

 -- Tabla que almacena alumnos ya inscriptos
CREATE TABLE #AlumnosInscriptos
(
	CursoId INT,
	Alumnos INT
);

 -- Tabla que almacena cantidad de materias por curso
CREATE TABLE #MateriasTotales
(
	CursoId INT,
	Materias INT
);

 -- Obtiene los alumnos no inicializados
 INSERT INTO #AlumnosNoInicializados
 SELECT CarreraId, COUNT(AlumnoCarreraId) AS Alumnos FROM AlumnosCarreras
 WHERE Inicializado = 0
 GROUP BY CarreraId

 -- Obtiene la cantidad de materias por curso
INSERT INTO #MateriasTotales
SELECT CursoId, COUNT(MateriaId) AS Materias FROM CursoMaterias
GROUP BY CursoId;

 -- Obtiene la distribución de alumnos por curso
 SELECT 
 c.DescripcionCorta As Carrera,
 ani.Alumnos As [Alumnos Nuevos],
 CONCAT(ac.AnioCarrera, cu.NombreCurso) AS Curso,
 COUNT(car.AlumnoCarreraId) / mt.Materias AS [Alumnos Inscriptos]
 FROM Cursadas cur
 INNER JOIN CursoMaterias cuma ON cur.CursoMateriaId = cuma.CursoMateriaId
 INNER JOIN #MateriasTotales mt ON cuma.CursoId = mt.CursoId
 INNER JOIN Cursos cu ON cuma.CursoId = cu.CursoId AND cu.Activo = 1
 INNER JOIN AniosCarreras ac ON cu.AnioCarreraId = ac.AnioCarreraId
 INNER JOIN Carreras c ON ac.CarreraId = c.CarreraId AND c.CarreraEstadoId = 1
 LEFT JOIN #AlumnosNoInicializados ani ON c.CarreraId = ani.CarreraId
 LEFT JOIN CursadaAlumnoCarreras car ON cur.CursadaId = car.CursadaId
 GROUP BY cu.NombreCurso, ac.AnioCarrera, c.DescripcionCorta, ani.Alumnos, mt.Materias
 ORDER BY ac.AnioCarrera
 END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertCursosMaterias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_insertCursosMaterias]
	@NombreCurso varchar(10),
	@AnioCarreraId int
AS
	INSERT INTO Cursos(NombreCurso, AnioCarreraId, Activo,AdmiteCurso)
	VALUES(@NombreCurso,@AnioCarreraId,1,1)
	
	DECLARE @CursoId int
    select @CursoId = @@IDENTITY
	DECLARE @fecha date
	set @fecha = GETDATE()

	INSERT INTO CursoMaterias(MateriaId, CursoId,FechaAlta,Activo)
	SELECT MateriaId, @CursoId,@fecha,1 from Materias where AnioCarreraId=@AnioCarreraId
GO
/****** Object:  StoredProcedure [dbo].[SP_libroActas]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_libroActas]
@LibroTipoId int
AS
BEGIN

	IF(SELECT count(*) FROM LibroActas WHERE TipoLibroId=@LibroTipoId)=0
	BEGIN 
		INSERT INTO LibroActas(TipoLibroId, LibroNumero, FolioNumero, FolioMaximo,FechaAlta,Activo) VALUES(@LibroTipoId,1,1,60,GETDATE(),1) 
	END
	ELSE
	BEGIN 
		DECLARE @LibroNumero INT
		DECLARE @FolioNumero INT
		
		SELECT @LibroNumero=MAX(LibroNumero), @FolioNumero=MAX(FolioNumero) FROM LibroActas WHERE TipoLibroId=@LibroTipoId AND LibroNumero=(SELECT MAX(LibroNumero) FROM LibroActas WHERE TipoLibroId=@LibroTipoId)
		IF (@FolioNumero<60)
		BEGIN 
			INSERT INTO LibroActas(TipoLibroId, LibroNumero, FolioNumero, FolioMaximo,FechaAlta,Activo) VALUES(@LibroTipoId,@LibroNumero,(@FolioNumero + 1),60,GETDATE(),1)
		END
		ELSE
		BEGIN
			UPDATE LibroActas SET FechaBaja=GETDATE(), Activo=0 WHERE LibroNumero=@LibroNumero
			INSERT INTO LibroActas(TipoLibroId, LibroNumero, FolioNumero, FolioMaximo,FechaAlta,Activo) VALUES(@LibroTipoId,(@LibroNumero + 1),1,60,GETDATE(),1)
		END
	END
END
 
 
GO
/****** Object:  StoredProcedure [dbo].[SP_ListaMaterias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ListaMaterias](
@MateriaID as int,
@CarreraID as int,
@msj as varchar(50) output
)
AS
BEGIN
BEGIN TRY
   -- Variable interna
	Declare @AnioCarrera As int

	create table #Temporal (
	MateriaCorrelativaId int)

	insert into #Temporal
	select MateriaCorrelativaId from Correlativas
	where MateriaId = @MateriaID


	SELECT @AnioCarrera = AnioCarrera FROM Materias as Mat
	INNER join AniosCarreras AS Ani on Mat.AnioCarreraId = Ani.AnioCarreraId
	WHERE Mat.MateriaId = @MateriaID

	select Mat.MateriaId, CONCAT(Ani.AnioCarrera, '° año - ', Mat.Nombre) AS Materia from Materias as Mat
	INNER join AniosCarreras AS Ani on Mat.AnioCarreraId = Ani.AnioCarreraId INNER JOIN Carreras as C
	ON Ani.CarreraId = C.CarreraId
	WHERE Ani.AnioCarrera < @AnioCarrera AND Ani.CarreraId = @CarreraID AND
	Mat.MateriaId NOT IN (select MateriaCorrelativaId FROM #Temporal)
	ORDER BY Ani.AnioCarrera, Mat.Nombre

	drop table #Temporal
	SET @msj = 'La lista se genero correctamente.'
END TRY

BEGIN CATCH
	SET @msj = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la linea ' + CONVERT(nvarchar(255), ERROR_LINE()) + '.'
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListaMateriasAlumno]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_ListaMateriasAlumno](
@AlumnoID as int,
@AnioCarreraID as int,
@msj as varchar(50) output
)
AS
BEGIN
BEGIN TRY
	create table #Temporal (
	MateriaId int)

	insert into #Temporal
	select MateriaId from AlumnoCicloLectivoMaterias
	where AlumnoId = @AlumnoID

	IF @AnioCarreraID = 0
	BEGIN
		SELECT @AnioCarreraID = AC.AnioCarreraId FROM AlumnosCarreras AlumCar
        INNER JOIN AniosCarreras AC ON AlumCar.CarreraId = AC.CarreraId
        WHERE AlumCar.AlumnoId = @AlumnoID AND AlumCar.Activo = 1 AND AC.AnioCarrera = 1
	END

	select * from Materias as Mat
	INNER join AniosCarreras AS Ani on Mat.AnioCarreraId = Ani.AnioCarreraId
	WHERE Ani.AnioCarreraId = @AnioCarreraID AND
	Mat.MateriaId NOT IN (select MateriaId FROM #Temporal)
	ORDER BY Mat.Nombre 

	drop table #Temporal
	SET @msj = 'La lista se genero correctamente.'
END TRY

BEGIN CATCH
	SET @msj = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la linea ' + CONVERT(nvarchar(255), ERROR_LINE()) + '.'
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListaServiciosCursoMaterias]    Script Date: 13/9/2025 12:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_ListaServiciosCursoMaterias](
@PersonalId as int,
@CursoId as int,
@CargoId as int
)
AS
BEGIN  
	create table #Temporal (
	CursoMateriaId int)
	 
	insert into #Temporal
	SELECT cm.CursoMateriaId from CursoMaterias cm inner join Servicios se on cm.CursoMateriaId=se.CursoMateriaId where se.PersonalId = @PersonalId and SE.Activo=1 AND se.CargoId=@CargoId

	select DISTINCT cm.CursoMateriaId, ma.Nombre from Servicios se full join CursoMaterias cm on se.CursoMateriaId=cm.CursoMateriaId INNER join Materias ma on cm.MateriaId=ma.MateriaId
	where cm.CursoMateriaId is not null AND cm.CursoMateriaId NOT IN (select CursoMateriaId from #temporal) AND cm.CursoId=@CursoId
	
	drop table #Temporal
END
GO
USE [master]
GO
ALTER DATABASE [instituto_db] SET  READ_WRITE 
GO
