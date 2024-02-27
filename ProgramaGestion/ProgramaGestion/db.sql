CREATE DATABASE [dbGestion]

USE [dbGestion]

/****** Object:  Table [dbo].[Articulos]    Script Date: 8/8/2020 21:18:22 ******/
CREATE TABLE [dbo].[Articulos](
	[idArticulo] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Stock] [int] NULL,
	[PrecioUni] [decimal](18, 2) NULL,
	[PrecioLista] [decimal](18, 2) NULL,
	[StockLoc] [int] NULL,
) 

/****** Object:  Table [dbo].[Caja]    Script Date: 8/8/2020 21:18:22 ******/
CREATE TABLE [dbo].[Caja](
	[idCaja] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Apertura] [nvarchar](50) NULL,
	[Cierre] [nvarchar](50) NULL,
	[Tipo] [nvarchar](50) NULL,
	[Valor] [decimal](18, 2) NULL,
	[idVenta] [int] NULL,
	[Observacion] [nvarchar](max) NULL,
)
 
/****** Object:  Table [dbo].[Clientes]    Script Date: 8/8/2020 21:18:22 ******/
CREATE TABLE [dbo].[Clientes](
	[idCliente] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[CUIT] [nvarchar](50) NULL,
	[Domicilio] [nvarchar](50) NULL,
	[Localidad] [nvarchar](50) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
) 

/****** Object:  Table [dbo].[DetallePago]    Script Date: 8/8/2020 21:18:22 ******/
CREATE TABLE [dbo].[DetallePago](
	[idDetalle] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[idVenta] [int] NULL,
	[MedioPago] [nvarchar](50) NULL,
	[Banco] [nvarchar](50) NULL,
	[TipoTarjeta] [nvarchar](50) NULL,
	[NroTarjeta] [nvarchar](50) NULL,
	[FechaVto] [nvarchar](50) NULL,
	[Titular] [nvarchar](50) NULL,
	[TipoCheque] [nvarchar](50) NULL,
	[FechaEmision] [nvarchar](50) NULL,
	[FechaCobro] [nvarchar](50) NULL,
) 

/****** Object:  Table [dbo].[DetalleVentas]    Script Date: 8/8/2020 21:18:22 ******/
CREATE TABLE [dbo].[DetalleVentas](
	[idDetalle] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[idVenta] [int] NULL,
	[Articulo] [nvarchar](50) NULL,
	[Cantidad] [int] NULL,
	[PrecioUni] [decimal](18, 2) NULL,
	[PrecioTot] [decimal](18, 2) NULL,
) 

/****** Object:  Table [dbo].[Remesa]    Script Date: 8/8/2020 21:18:22 ******/
CREATE TABLE [dbo].[Remesa](
	[idRemesa] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Monto] [decimal](18, 2) NULL,
	[Fecha] [nvarchar](50) NULL,
) 

/****** Object:  Table [dbo].[Usuarios]    Script Date: 8/8/2020 21:18:22 ******/
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Clave] [nvarchar](50) NULL,
	[Permisos] [nvarchar](50) NULL,
) 

/****** Object:  Table [dbo].[Ventas]    Script Date: 8/8/2020 21:18:22 ******/
CREATE TABLE [dbo].[Ventas](
	[idVenta] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Fecha] [nvarchar](50) NULL,
	[Cantidad] [int] NULL,
	[ImporteTotal] [decimal](18, 2) NULL,
	[ValorPago] [decimal](18, 2) NULL,
	[Cambio] [decimal](18, 2) NULL,
	[MedioPago] [nvarchar](50) NULL,
	[Recargo] [nvarchar](50) NULL,
	[Observacion] [nvarchar](max) NULL,
	[TipoFactura] [nvarchar](50) NULL,
	[Remito] [int] NULL,
	[Cliente] [nvarchar](50) NULL,
	[Usuario] [nvarchar](50) NULL,
	[NotaCredito] [int] NULL,
) 

/****** Object:  StoredProcedure [dbo].[ReciboVenta]    Script Date: 8/8/2020 21:18:22 ******/
CREATE PROCEDURE [dbo].[ReciboVenta] @idOp INT
AS
SELECT * FROM DetalleVentas WHERE idVenta = @idOp
