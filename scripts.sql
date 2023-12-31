USE [TP1LUG]
GO
/****** Object:  Table [dbo].[Cuota]    Script Date: 29/9/2023 15:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuota](
	[Cuota_ID] [int] IDENTITY(1,1) NOT NULL,
	[Monto_Cuota] [decimal](13, 2) NOT NULL,
	[Fecha_Pago] [datetime] NOT NULL,
 CONSTRAINT [PK_Cuota] PRIMARY KEY CLUSTERED 
(
	[Cuota_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dia]    Script Date: 29/9/2023 15:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dia](
	[Dia_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Tipo_Ejercicio] [nvarchar](50) NOT NULL,
	[Rutina_ID] [int] NOT NULL,
 CONSTRAINT [PK_Dia] PRIMARY KEY CLUSTERED 
(
	[Dia_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ejercicio]    Script Date: 29/9/2023 15:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ejercicio](
	[Ejercicio_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Series] [int] NOT NULL,
	[Descripcion_Adicional] [nvarchar](1000) NULL,
	[Dia_ID] [int] NOT NULL,
 CONSTRAINT [PK_Ejercicio] PRIMARY KEY CLUSTERED 
(
	[Ejercicio_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rutina]    Script Date: 29/9/2023 15:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rutina](
	[Rutina_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Inicio] [datetime] NOT NULL,
	[Cliente_id] [int] NOT NULL,
	[Descripcion_General] [nvarchar](200) NULL,
 CONSTRAINT [PK_Rutina] PRIMARY KEY CLUSTERED 
(
	[Rutina_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 29/9/2023 15:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[Tarjeta_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cuota_ID] [int] NOT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[Tarjeta_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/9/2023 15:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Usuario_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](20) NOT NULL,
	[Apellido] [nchar](20) NOT NULL,
	[Rol] [int] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Contraseña] [nvarchar](100) NULL,
	[Especializacion] [nvarchar](50) NULL,
	[Telefono] [int] NULL,
	[Peso] [nvarchar](50) NULL,
	[Fecha_Nacimiento] [datetime] NULL,
	[Tarjeta_ID] [int] NULL,
	[Rutina_ID] [int] NULL,
	[Empleado_ID] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Usuario_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dia] ON 

INSERT [dbo].[Dia] ([Dia_ID], [Nombre], [Tipo_Ejercicio], [Rutina_ID]) VALUES (36, N'Lunes/Miercoles/Viernes', N'Tren superior', 7)
INSERT [dbo].[Dia] ([Dia_ID], [Nombre], [Tipo_Ejercicio], [Rutina_ID]) VALUES (37, N'Martes/Jueves', N'Tren inferior', 7)
SET IDENTITY_INSERT [dbo].[Dia] OFF
GO
SET IDENTITY_INSERT [dbo].[Ejercicio] ON 

INSERT [dbo].[Ejercicio] ([Ejercicio_ID], [Nombre], [Series], [Descripcion_Adicional], [Dia_ID]) VALUES (14, N'Press de Banca', 6, N'El press de banca es un ejercicio clásico para trabajar los músculos pectorales, los tríceps y los hombros.', 36)
INSERT [dbo].[Ejercicio] ([Ejercicio_ID], [Nombre], [Series], [Descripcion_Adicional], [Dia_ID]) VALUES (15, N'Dominadas', 4, N'Las dominadas son un excelente ejercicio para fortalecer la espalda, los bíceps y los hombros. ', 36)
INSERT [dbo].[Ejercicio] ([Ejercicio_ID], [Nombre], [Series], [Descripcion_Adicional], [Dia_ID]) VALUES (16, N'Curl de Bíceps', 3, N'El curl de bíceps se centra en los músculos bíceps. Puedes hacerlo con pesas o una barra, doblando los codos para levantar el peso hacia tus hombros.', 36)
INSERT [dbo].[Ejercicio] ([Ejercicio_ID], [Nombre], [Series], [Descripcion_Adicional], [Dia_ID]) VALUES (17, N'Tríceps en Polea Alta', 4, N'Utiliza una máquina de polea alta con una cuerda o barra para extender los brazos hacia abajo y luego volver a la posición inicial.', 36)
INSERT [dbo].[Ejercicio] ([Ejercicio_ID], [Nombre], [Series], [Descripcion_Adicional], [Dia_ID]) VALUES (18, N'Sentadillas', 6, N'Las sentadillas son uno de los ejercicios más efectivos para trabajar las piernas y los glúteos. ', 37)
INSERT [dbo].[Ejercicio] ([Ejercicio_ID], [Nombre], [Series], [Descripcion_Adicional], [Dia_ID]) VALUES (19, N'Prensa de Piernas', 4, N'La prensa de piernas es excelente para fortalecer los músculos cuádriceps y los glúteos.', 37)
INSERT [dbo].[Ejercicio] ([Ejercicio_ID], [Nombre], [Series], [Descripcion_Adicional], [Dia_ID]) VALUES (20, N'Peso Muerto', 6, N'El peso muerto es un ejercicio compuesto que trabaja la parte baja de la espalda, los glúteos y las piernas. Levantas una barra o pesas desde el suelo hasta la posición de pie.', 37)
SET IDENTITY_INSERT [dbo].[Ejercicio] OFF
GO
SET IDENTITY_INSERT [dbo].[Rutina] ON 

INSERT [dbo].[Rutina] ([Rutina_ID], [Fecha_Inicio], [Cliente_id], [Descripcion_General]) VALUES (7, CAST(N'2023-09-29T00:00:00.000' AS DateTime), 29, N'El cliente busca aumentar su masa muscular para fin de año.')
SET IDENTITY_INSERT [dbo].[Rutina] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Usuario_ID], [Nombre], [Apellido], [Rol], [Email], [Contraseña], [Especializacion], [Telefono], [Peso], [Fecha_Nacimiento], [Tarjeta_ID], [Rutina_ID], [Empleado_ID]) VALUES (28, N'Juan                ', N'Rodriguez           ', 2, N'JuanRo.com', N'zATYREWr0/ThRIhSTCTjsg==', N'Lic.Nutricion', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Usuario] ([Usuario_ID], [Nombre], [Apellido], [Rol], [Email], [Contraseña], [Especializacion], [Telefono], [Peso], [Fecha_Nacimiento], [Tarjeta_ID], [Rutina_ID], [Empleado_ID]) VALUES (29, N'Ramiro              ', N'Ramirez             ', 3, N'RaRamirez.com', NULL, NULL, 1134987956, N'89.50', CAST(N'1998-09-29T00:00:00.000' AS DateTime), NULL, NULL, 28)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Dia]  WITH CHECK ADD  CONSTRAINT [FK_Dia_Rutina] FOREIGN KEY([Rutina_ID])
REFERENCES [dbo].[Rutina] ([Rutina_ID])
GO
ALTER TABLE [dbo].[Dia] CHECK CONSTRAINT [FK_Dia_Rutina]
GO
ALTER TABLE [dbo].[Ejercicio]  WITH CHECK ADD  CONSTRAINT [FK_Ejercicio_Dia] FOREIGN KEY([Dia_ID])
REFERENCES [dbo].[Dia] ([Dia_ID])
GO
ALTER TABLE [dbo].[Ejercicio] CHECK CONSTRAINT [FK_Ejercicio_Dia]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Cuota] FOREIGN KEY([Cuota_ID])
REFERENCES [dbo].[Cuota] ([Cuota_ID])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Cuota]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rutina] FOREIGN KEY([Rutina_ID])
REFERENCES [dbo].[Rutina] ([Rutina_ID])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rutina]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Tarjeta] FOREIGN KEY([Tarjeta_ID])
REFERENCES [dbo].[Tarjeta] ([Tarjeta_ID])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Tarjeta]
GO
