USE [master]
GO
/****** Object:  Database [BD_SGCLAP]    Script Date: 20/07/2020 00:06:59 ******/
CREATE DATABASE [BD_SGCLAP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_SGCLAP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BD_SGCLAP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_SGCLAP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BD_SGCLAP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BD_SGCLAP] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_SGCLAP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_SGCLAP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_SGCLAP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_SGCLAP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_SGCLAP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_SGCLAP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET RECOVERY FULL 
GO
ALTER DATABASE [BD_SGCLAP] SET  MULTI_USER 
GO
ALTER DATABASE [BD_SGCLAP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_SGCLAP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_SGCLAP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_SGCLAP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_SGCLAP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_SGCLAP] SET QUERY_STORE = OFF
GO
USE [BD_SGCLAP]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BD_SGCLAP]
GO
/****** Object:  Table [dbo].[T_Cita]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Cita](
	[PK_IC_Cod] [int] IDENTITY(1,1) NOT NULL,
	[VC_Observacion] [varchar](300) NULL,
	[DC_FechaHoraSolicitada] [smalldatetime] NOT NULL,
	[DC_FechaHoraCreada] [smalldatetime] NOT NULL,
	[DC_FechaHoraReprogramada] [smalldatetime] NULL,
	[FK_ITC_Cod] [int] NOT NULL,
	[FK_IEC_Cod] [int] NOT NULL,
	[FK_CU_Dni] [char](8) NOT NULL,
 CONSTRAINT [PK_T_Cita] PRIMARY KEY CLUSTERED 
(
	[PK_IC_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Congelamiento]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Congelamiento](
	[PK_ICo_Cod] [int] IDENTITY(1,1) NOT NULL,
	[VC_Nombre] [nvarchar](100) NOT NULL,
	[VC_CantidadDias] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_T_Congelamiento] PRIMARY KEY CLUSTERED 
(
	[PK_ICo_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Contrato]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Contrato](
	[PK_IC_Cod] [int] IDENTITY(1,1) NOT NULL,
	[VC_Descripcion] [nvarchar](200) NOT NULL,
	[DC_Fecha_Creacion] [datetime] NOT NULL,
	[FK_IEC_Cod] [int] NOT NULL,
	[FK_IP_Cod] [int] NOT NULL,
 CONSTRAINT [PK_T_Contrato] PRIMARY KEY CLUSTERED 
(
	[PK_IC_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Estado_Cita]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Estado_Cita](
	[PK_IEC_Cod] [int] IDENTITY(1,1) NOT NULL,
	[VEC_Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_Estado_Cita] PRIMARY KEY CLUSTERED 
(
	[PK_IEC_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Estado_Contrato]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Estado_Contrato](
	[PF_IEC_Cod] [int] IDENTITY(1,1) NOT NULL,
	[VEC_Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_T_Estado_Contrato] PRIMARY KEY CLUSTERED 
(
	[PF_IEC_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Estado_Plan]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Estado_Plan](
	[PK_IEP_Cod] [int] IDENTITY(1,1) NOT NULL,
	[VEP_Nombre] [nvarchar](100) NULL,
 CONSTRAINT [PK_T_Estado_Plan] PRIMARY KEY CLUSTERED 
(
	[PK_IEP_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Frecuencia]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Frecuencia](
	[PK_IF_Cod] [int] IDENTITY(1,1) NOT NULL,
	[VF_Nombre] [nvarchar](100) NULL,
 CONSTRAINT [PK_T_Frecuencia] PRIMARY KEY CLUSTERED 
(
	[PK_IF_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Membresia]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Membresia](
	[PK_IM_Cod] [int] IDENTITY(1,1) NOT NULL,
	[Im_Duracion] [int] NOT NULL,
 CONSTRAINT [PK_T_Membresia] PRIMARY KEY CLUSTERED 
(
	[PK_IM_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Plan]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Plan](
	[PK_IP_Cod] [int] IDENTITY(1,1) NOT NULL,
	[IP_Cantidad_Sesion_Fisio] [int] NOT NULL,
	[IE_Cantidad_Sesion_Nutri] [int] NOT NULL,
	[FK_IM_Cod] [int] NOT NULL,
	[FK_IF_Cod] [int] NOT NULL,
	[FK_ICo_Cod] [int] NOT NULL,
	[FK_IEP_Cod] [int] NULL,
	[DP_Costo] [float] NOT NULL,
 CONSTRAINT [PK_T_Plan] PRIMARY KEY CLUSTERED 
(
	[PK_IP_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Tipo_Cita]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Tipo_Cita](
	[PK_ITC_Cod] [int] IDENTITY(1,1) NOT NULL,
	[VTC_Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_Tipo_Cita] PRIMARY KEY CLUSTERED 
(
	[PK_ITC_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Tipo_Usuario]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Tipo_Usuario](
	[PK_ITU_Cod] [int] IDENTITY(1,1) NOT NULL,
	[VTU_Rol_Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_Tipo_Usuario] PRIMARY KEY CLUSTERED 
(
	[PK_ITU_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Usuario]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Usuario](
	[PK_CU_Dni] [char](8) NOT NULL,
	[VU_Nombre] [varchar](50) NOT NULL,
	[VU_APaterno] [varchar](50) NOT NULL,
	[VU_AMaterno] [varchar](50) NOT NULL,
	[DU_FechaNacimiento] [datetime] NOT NULL,
	[IU_Edad] [int] NOT NULL,
	[VU_Contrasenia] [nvarchar](50) NOT NULL,
	[VU_Estado] [nvarchar](50) NULL,
	[DU_Fecha_Registro] [datetime] NOT NULL,
	[CU_Celular] [char](9) NOT NULL,
	[VU_Direccion] [varchar](200) NOT NULL,
	[VU_Correo] [varchar](50) NOT NULL,
	[FK_ITU_Cod] [int] NOT NULL,
	[IU_Citas_Nutri_Usadas] [int] NULL,
	[IU_Citas_Fisio_Usadas] [int] NULL,
	[FK_IC_Cod] [int] NULL,
 CONSTRAINT [PK_T_Usuario] PRIMARY KEY CLUSTERED 
(
	[PK_CU_Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_Cita]  WITH CHECK ADD  CONSTRAINT [FK_T_Cita_T_Estado_Cita] FOREIGN KEY([FK_IEC_Cod])
REFERENCES [dbo].[T_Estado_Cita] ([PK_IEC_Cod])
GO
ALTER TABLE [dbo].[T_Cita] CHECK CONSTRAINT [FK_T_Cita_T_Estado_Cita]
GO
ALTER TABLE [dbo].[T_Cita]  WITH CHECK ADD  CONSTRAINT [FK_T_Cita_T_Tipo_Cita] FOREIGN KEY([FK_ITC_Cod])
REFERENCES [dbo].[T_Tipo_Cita] ([PK_ITC_Cod])
GO
ALTER TABLE [dbo].[T_Cita] CHECK CONSTRAINT [FK_T_Cita_T_Tipo_Cita]
GO
ALTER TABLE [dbo].[T_Cita]  WITH CHECK ADD  CONSTRAINT [FK_T_Cita_T_Usuario] FOREIGN KEY([FK_CU_Dni])
REFERENCES [dbo].[T_Usuario] ([PK_CU_Dni])
GO
ALTER TABLE [dbo].[T_Cita] CHECK CONSTRAINT [FK_T_Cita_T_Usuario]
GO
ALTER TABLE [dbo].[T_Contrato]  WITH CHECK ADD  CONSTRAINT [FK_T_Contrato_T_Estado_Contrato] FOREIGN KEY([FK_IEC_Cod])
REFERENCES [dbo].[T_Estado_Contrato] ([PF_IEC_Cod])
GO
ALTER TABLE [dbo].[T_Contrato] CHECK CONSTRAINT [FK_T_Contrato_T_Estado_Contrato]
GO
ALTER TABLE [dbo].[T_Contrato]  WITH CHECK ADD  CONSTRAINT [FK_T_Contrato_T_Plan] FOREIGN KEY([FK_IP_Cod])
REFERENCES [dbo].[T_Plan] ([PK_IP_Cod])
GO
ALTER TABLE [dbo].[T_Contrato] CHECK CONSTRAINT [FK_T_Contrato_T_Plan]
GO
ALTER TABLE [dbo].[T_Plan]  WITH CHECK ADD  CONSTRAINT [FK_T_Plan_T_Congelamiento] FOREIGN KEY([FK_ICo_Cod])
REFERENCES [dbo].[T_Congelamiento] ([PK_ICo_Cod])
GO
ALTER TABLE [dbo].[T_Plan] CHECK CONSTRAINT [FK_T_Plan_T_Congelamiento]
GO
ALTER TABLE [dbo].[T_Plan]  WITH CHECK ADD  CONSTRAINT [FK_T_Plan_T_Estado_Plan] FOREIGN KEY([FK_IEP_Cod])
REFERENCES [dbo].[T_Estado_Plan] ([PK_IEP_Cod])
GO
ALTER TABLE [dbo].[T_Plan] CHECK CONSTRAINT [FK_T_Plan_T_Estado_Plan]
GO
ALTER TABLE [dbo].[T_Plan]  WITH CHECK ADD  CONSTRAINT [FK_T_Plan_T_Frecuencia] FOREIGN KEY([FK_IF_Cod])
REFERENCES [dbo].[T_Frecuencia] ([PK_IF_Cod])
GO
ALTER TABLE [dbo].[T_Plan] CHECK CONSTRAINT [FK_T_Plan_T_Frecuencia]
GO
ALTER TABLE [dbo].[T_Plan]  WITH CHECK ADD  CONSTRAINT [FK_T_Plan_T_Membresia] FOREIGN KEY([FK_IM_Cod])
REFERENCES [dbo].[T_Membresia] ([PK_IM_Cod])
GO
ALTER TABLE [dbo].[T_Plan] CHECK CONSTRAINT [FK_T_Plan_T_Membresia]
GO
ALTER TABLE [dbo].[T_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_T_Usuario_T_Contrato] FOREIGN KEY([FK_IC_Cod])
REFERENCES [dbo].[T_Contrato] ([PK_IC_Cod])
GO
ALTER TABLE [dbo].[T_Usuario] CHECK CONSTRAINT [FK_T_Usuario_T_Contrato]
GO
ALTER TABLE [dbo].[T_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_T_Usuario_T_Tipo_Usuario] FOREIGN KEY([FK_ITU_Cod])
REFERENCES [dbo].[T_Tipo_Usuario] ([PK_ITU_Cod])
GO
ALTER TABLE [dbo].[T_Usuario] CHECK CONSTRAINT [FK_T_Usuario_T_Tipo_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarPlanes]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ListarPlanes]
as
begin 
select u.PK_IP_Cod,u.IP_Cantidad_Sesion_Fisio, u.IP_Cantidad_Sesion_Fisio,u.DP_Costo, cong.VC_CantidadDias
 as Congelamiento, memb.Im_Duracion as MembresiaDuracionString,frec.VF_Nombre as FrecuenciaString
from T_Plan u  inner join T_Congelamiento cong 
on u.FK_ICo_Cod= cong.PK_ICo_Cod inner join T_Membresia memb
on u.FK_IM_Cod= memb.PK_IM_Cod inner join T_Frecuencia frec
on u.FK_IF_Cod = frec.PK_IF_Cod 
where FK_IEP_Cod =1

end
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDatosUsuario]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ObtenerDatosUsuario](
@DNISocio char(8))
as
begin
select TUsuario.PK_CU_Dni ,TUsuario.VU_Nombre, TUsuario.VU_APaterno,TUsuario.VU_AMaterno,TUsuario.CU_Celular,TUsuario.DU_FechaNacimiento,
TUsuario.FK_IC_Cod,TUsuario.FK_ITU_Cod,TUsuario.IU_Citas_Fisio_Usadas,TUsuario.Iu_Citas_Nutri_Usadas,TUsuario.VU_Correo,TUsuario.VU_Direccion
from T_Usuario TUsuario 
 where 
TUsuario.PK_CU_Dni=@DNISocio


	   END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarSocio]    Script Date: 20/07/2020 00:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_RegistrarSocio]
@PK_CU_Dni int,
@VU_Nombre nvarchar(50),
@VU_APaterno nvarchar(50),
@VU_AMaterno nvarchar(50),
@VU_Correo nvarchar(50),
@DU_FechaNacimiento datetime,
--@IU_Edad int,
@NU_Contrasenia nvarchar(50),
--@VU_Estado varchar(200),
@CU_Celular char(9),
@VU_Direccion varchar(200)
--@FK_ITU_Cod int,
--@FK_IC_Cod int
--@IC_Citas_Nutri_Usadas int,
--@IC_Citas_Fisio_Usadas int
AS
begin
INSERT INTO T_Usuario(PK_CU_Dni,
VU_Nombre,
VU_APaterno,
VU_AMaterno,
VU_Correo,
DU_FechaNacimiento,
IU_Edad,
VU_Contrasenia,
VU_Estado,
DU_Fecha_Registro,
CU_Celular,
VU_Direccion,
FK_ITU_Cod,
FK_IC_Cod,
IU_Citas_Nutri_Usadas,
IU_Citas_Fisio_Usadas)
VALUES(@PK_CU_Dni,
@VU_Nombre,
@VU_APaterno,
@VU_AMaterno,
@VU_Correo,
@DU_FechaNacimiento,
(cast(datediff(dd,@DU_FechaNacimiento,GETDATE()) / 366.25 as int)),
@NU_Contrasenia,
--@VU_Estado,
'Activo - SIN CONTRATO',
GETDATE(),
@CU_Celular,
@VU_Direccion,
1,
NULL,
0,
0
)
end
GO
USE [master]
GO
ALTER DATABASE [BD_SGCLAP] SET  READ_WRITE 
GO
