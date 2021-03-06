USE [Ventas]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 25/01/2022 6:44:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](200) NULL,
	[cantidad] [int] NULL,
	[valor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 25/01/2022 6:44:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[documento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venta]    Script Date: 25/01/2022 6:44:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NULL,
	[id_producto] [int] NULL,
	[cantidad] [int] NULL,
	[valor_pagar] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[productos] ADD  DEFAULT (NULL) FOR [cantidad]
GO
ALTER TABLE [dbo].[productos] ADD  DEFAULT (NULL) FOR [valor]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [documento]
GO
ALTER TABLE [dbo].[venta] ADD  DEFAULT (NULL) FOR [id_cliente]
GO
ALTER TABLE [dbo].[venta] ADD  DEFAULT (NULL) FOR [id_producto]
GO
ALTER TABLE [dbo].[venta] ADD  DEFAULT (NULL) FOR [cantidad]
GO
ALTER TABLE [dbo].[venta] ADD  DEFAULT (NULL) FOR [valor_pagar]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[productos] ([id])
GO
