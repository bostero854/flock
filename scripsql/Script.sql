USE [master]
GO
/****** Object:  Database [flock]    Script Date: 1/5/2022 01:23:53 ******/
CREATE DATABASE [flock]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'flock', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\flock.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'flock_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\flock_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [flock] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [flock].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [flock] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [flock] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [flock] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [flock] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [flock] SET ARITHABORT OFF 
GO
ALTER DATABASE [flock] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [flock] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [flock] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [flock] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [flock] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [flock] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [flock] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [flock] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [flock] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [flock] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [flock] SET  ENABLE_BROKER 
GO
ALTER DATABASE [flock] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [flock] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [flock] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [flock] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [flock] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [flock] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [flock] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [flock] SET RECOVERY FULL 
GO
ALTER DATABASE [flock] SET  MULTI_USER 
GO
ALTER DATABASE [flock] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [flock] SET DB_CHAINING OFF 
GO
ALTER DATABASE [flock] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [flock] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'flock', N'ON'
GO
USE [flock]
GO
/****** Object:  Table [dbo].[Documento]    Script Date: 1/5/2022 01:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Documento](
	[idTipoDoc] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[idTipoDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 1/5/2022 01:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
	[codEstado] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[fechabaja] [datetime] NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[codEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 1/5/2022 01:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[idLogin] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[nick] [varchar](100) NOT NULL,
	[clave] [varchar](100) NOT NULL,
	[codEstado] [int] NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[idLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 1/5/2022 01:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 1/5/2022 01:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfil](
	[codPerfil] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[codPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 1/5/2022 01:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[tipoDocumento] [int] NOT NULL,
	[nroDocumento] [varchar](12) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[nroDireccion] [varchar](10) NOT NULL,
	[codPerfil] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[tipoDocumento] ASC,
	[nroDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Estado] FOREIGN KEY([codEstado])
REFERENCES [dbo].[Estado] ([codEstado])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Estado]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Documento] FOREIGN KEY([tipoDocumento])
REFERENCES [dbo].[Documento] ([idTipoDoc])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Documento]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([codPerfil])
REFERENCES [dbo].[Perfil] ([codPerfil])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
USE [master]
GO
ALTER DATABASE [flock] SET  READ_WRITE 
GO
