USE [ArandaDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[descripcion] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisosPorRol](
	[rolId] [tinyint] NULL,
	[permisoId] [int] NULL
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[direccion] [varchar](80) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](60) NULL,
	[edad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[contrasena] [varchar](50) NOT NULL,
	[personaId] [int] NULL,
	[rolId] [tinyint] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([id], [nombre], [descripcion]) VALUES (1, N'ver_info', N'Solo puede ver informacion de la empresa')
INSERT [dbo].[Permiso] ([id], [nombre], [descripcion]) VALUES (2, N'lista_usuarios', N'Listar Ususarios')
INSERT [dbo].[Permiso] ([id], [nombre], [descripcion]) VALUES (3, N'filtros', N'Puede Realizar busqueda por medio de filtros')
INSERT [dbo].[Permiso] ([id], [nombre], [descripcion]) VALUES (4, N'editar', N'Peude editar el contenido')
INSERT [dbo].[Permiso] ([id], [nombre], [descripcion]) VALUES (5, N'crear', N'Puede crear registros')
INSERT [dbo].[Permiso] ([id], [nombre], [descripcion]) VALUES (6, N'eliminar', N'Puede eliminar registros')
SET IDENTITY_INSERT [dbo].[Permiso] OFF
INSERT [dbo].[PermisosPorRol] ([rolId], [permisoId]) VALUES (1, 1)
INSERT [dbo].[PermisosPorRol] ([rolId], [permisoId]) VALUES (4, 2)
INSERT [dbo].[PermisosPorRol] ([rolId], [permisoId]) VALUES (4, 3)
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([id], [nombre], [apellido], [direccion], [telefono], [email], [edad]) VALUES (1, N'Juan Daniel', N'Arboleda', N'Carrera', N'21542541', N'jarbol@g.com', 27)
INSERT [dbo].[Persona] ([id], [nombre], [apellido], [direccion], [telefono], [email], [edad]) VALUES (2, N'Pedro', N'Arbol', N'car', N'2570661', N'j.com', 18)
SET IDENTITY_INSERT [dbo].[Persona] OFF
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([id], [nombre], [descripcion]) VALUES (1, N'Visitante', N'Solo observa un mensaje de bienvenida y noticias de la empresa (información fija)')
INSERT [dbo].[Rol] ([id], [nombre], [descripcion]) VALUES (2, N'Asistente', N'Observar el mensaje de bienvenida, listar usuarios, filtrar por nombre y filtrar por rol')
INSERT [dbo].[Rol] ([id], [nombre], [descripcion]) VALUES (3, N'Editor', N' Lo que hace el asistente y además edición de los datos de cualquier usuario')
INSERT [dbo].[Rol] ([id], [nombre], [descripcion]) VALUES (4, N'Administrador', N'Lo que hace el editor y además crear y eliminar usuario.')
SET IDENTITY_INSERT [dbo].[Rol] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [nombre], [contrasena], [personaId], [rolId]) VALUES (1, N'admon', N'123', 1, 4)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
/****** Object:  Index [AK_PermisosPorRol]    Script Date: 1/29/2022 2:11:41 AM ******/
ALTER TABLE [dbo].[PermisosPorRol] ADD  CONSTRAINT [AK_PermisosPorRol] UNIQUE NONCLUSTERED 
(
	[rolId] ASC,
	[permisoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [AK_Rol]    Script Date: 1/29/2022 2:11:41 AM ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [AK_Rol] UNIQUE NONCLUSTERED 
(
	[rolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PermisosPorRol]  WITH CHECK ADD  CONSTRAINT [FK_PermisosPorRol] FOREIGN KEY([rolId])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[PermisosPorRol] CHECK CONSTRAINT [FK_PermisosPorRol]
GO
ALTER TABLE [dbo].[PermisosPorRol]  WITH CHECK ADD  CONSTRAINT [FK_PermisosPorRolPermiso] FOREIGN KEY([permisoId])
REFERENCES [dbo].[Permiso] ([id])
GO
ALTER TABLE [dbo].[PermisosPorRol] CHECK CONSTRAINT [FK_PermisosPorRolPermiso]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_PersonaUsuario] FOREIGN KEY([personaId])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_PersonaUsuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_RolUsusario] FOREIGN KEY([rolId])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_RolUsusario]
GO
