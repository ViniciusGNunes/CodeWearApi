USE [master]
GO
/****** Object:  Database [CodeWear3]    Script Date: 6/18/2025 7:24:03 PM ******/
CREATE DATABASE [CodeWear3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CodeWear3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CodeWear3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CodeWear3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CodeWear3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CodeWear3] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CodeWear3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CodeWear3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CodeWear3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CodeWear3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CodeWear3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CodeWear3] SET ARITHABORT OFF 
GO
ALTER DATABASE [CodeWear3] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CodeWear3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CodeWear3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CodeWear3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CodeWear3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CodeWear3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CodeWear3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CodeWear3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CodeWear3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CodeWear3] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CodeWear3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CodeWear3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CodeWear3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CodeWear3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CodeWear3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CodeWear3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CodeWear3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CodeWear3] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CodeWear3] SET  MULTI_USER 
GO
ALTER DATABASE [CodeWear3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CodeWear3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CodeWear3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CodeWear3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CodeWear3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CodeWear3] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CodeWear3] SET QUERY_STORE = ON
GO
ALTER DATABASE [CodeWear3] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CodeWear3]
GO
/****** Object:  Table [dbo].[Carrinho]    Script Date: 6/18/2025 7:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrinho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Finalizado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 6/18/2025 7:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Texto] [nvarchar](max) NOT NULL,
	[ProdutoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImagemProduto]    Script Date: 6/18/2025 7:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImagemProduto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](255) NOT NULL,
	[Caminho] [nvarchar](500) NOT NULL,
	[ProdutoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemCarrinho]    Script Date: 6/18/2025 7:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCarrinho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrinhoId] [int] NOT NULL,
	[ProdutoId] [int] NOT NULL,
	[Quantidade] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 6/18/2025 7:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](255) NOT NULL,
	[TipoProduto] [nvarchar](255) NULL,
	[Preco] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/18/2025 7:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/18/2025 7:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[NomeCompleto] [nvarchar](255) NOT NULL,
	[Senha] [nvarchar](255) NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Carrinho] ON 

INSERT [dbo].[Carrinho] ([Id], [DataCriacao], [UsuarioId], [Finalizado]) VALUES (1, CAST(N'2025-06-18T15:09:59.200' AS DateTime), 1, 0)
INSERT [dbo].[Carrinho] ([Id], [DataCriacao], [UsuarioId], [Finalizado]) VALUES (2, CAST(N'2025-06-18T15:09:59.200' AS DateTime), 2, 0)
INSERT [dbo].[Carrinho] ([Id], [DataCriacao], [UsuarioId], [Finalizado]) VALUES (3, CAST(N'2025-06-18T15:59:24.153' AS DateTime), 6, 0)
INSERT [dbo].[Carrinho] ([Id], [DataCriacao], [UsuarioId], [Finalizado]) VALUES (4, CAST(N'2025-06-18T15:09:59.200' AS DateTime), 4, 1)
INSERT [dbo].[Carrinho] ([Id], [DataCriacao], [UsuarioId], [Finalizado]) VALUES (5, CAST(N'2025-06-18T15:16:15.383' AS DateTime), 5, 0)
INSERT [dbo].[Carrinho] ([Id], [DataCriacao], [UsuarioId], [Finalizado]) VALUES (6, CAST(N'2025-06-18T15:21:10.977' AS DateTime), 6, 0)
SET IDENTITY_INSERT [dbo].[Carrinho] OFF
GO
SET IDENTITY_INSERT [dbo].[Comentario] ON 

INSERT [dbo].[Comentario] ([Id], [UsuarioId], [Texto], [ProdutoId]) VALUES (6, 1, N'Produto excelente!', 1)
INSERT [dbo].[Comentario] ([Id], [UsuarioId], [Texto], [ProdutoId]) VALUES (7, 2, N'Não gostei muito da qualidade.', 1)
INSERT [dbo].[Comentario] ([Id], [UsuarioId], [Texto], [ProdutoId]) VALUES (9, 2, N'Veio com defeito.', 2)
INSERT [dbo].[Comentario] ([Id], [UsuarioId], [Texto], [ProdutoId]) VALUES (10, 1, N'Atendeu às expectativas.', 6)
INSERT [dbo].[Comentario] ([Id], [UsuarioId], [Texto], [ProdutoId]) VALUES (11, 2, N'Não recomendo.', 6)
INSERT [dbo].[Comentario] ([Id], [UsuarioId], [Texto], [ProdutoId]) VALUES (12, 1, N'Mudou profundamente a psique de meu ser e me pôs acima do mundo material', 6)
INSERT [dbo].[Comentario] ([Id], [UsuarioId], [Texto], [ProdutoId]) VALUES (13, 2, N'Produto diferente do anunciado.', 4)
INSERT [dbo].[Comentario] ([Id], [UsuarioId], [Texto], [ProdutoId]) VALUES (14, 1, N'Comprei para presente e foi sucesso.', 5)
INSERT [dbo].[Comentario] ([Id], [UsuarioId], [Texto], [ProdutoId]) VALUES (15, 2, N'Tecido poderia ser melhor.', 5)
INSERT [dbo].[Comentario] ([Id], [UsuarioId], [Texto], [ProdutoId]) VALUES (16, 6, N'Nossa cara, mto massa melhor presente de dia do advogado de minúsculas causas que eu poderia receber', 4)
SET IDENTITY_INSERT [dbo].[Comentario] OFF
GO
SET IDENTITY_INSERT [dbo].[ImagemProduto] ON 

INSERT [dbo].[ImagemProduto] ([Id], [Descricao], [Caminho], [ProdutoId]) VALUES (6, N'Vista frontal da camiseta', N'/imagens/produtos/1_frente.jpg', 1)
INSERT [dbo].[ImagemProduto] ([Id], [Descricao], [Caminho], [ProdutoId]) VALUES (7, N'Vista traseira da camiseta', N'/imagens/produtos/1_verso.jpg', 1)
INSERT [dbo].[ImagemProduto] ([Id], [Descricao], [Caminho], [ProdutoId]) VALUES (8, N'Tênis lateral', N'/imagens/produtos/2_lateral.jpg', 2)
INSERT [dbo].[ImagemProduto] ([Id], [Descricao], [Caminho], [ProdutoId]) VALUES (9, N'Tênis solado', N'/imagens/produtos/2_sola.jpg', 2)
INSERT [dbo].[ImagemProduto] ([Id], [Descricao], [Caminho], [ProdutoId]) VALUES (10, N'Mochila aberta', N'/imagens/produtos/3_aberta.jpg', 6)
INSERT [dbo].[ImagemProduto] ([Id], [Descricao], [Caminho], [ProdutoId]) VALUES (11, N'Mochila fechada', N'/imagens/produtos/3_fechada.jpg', 6)
SET IDENTITY_INSERT [dbo].[ImagemProduto] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemCarrinho] ON 

INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (1, 1, 1, 2)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (2, 1, 2, 1)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (3, 1, 7, 4)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (4, 1, 4, 1)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (5, 2, 2, 2)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (6, 2, 5, 1)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (7, 2, 6, 3)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (8, 2, 1, 2)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (9, 3, 7, 1)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (10, 3, 4, 2)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (11, 3, 5, 5)
INSERT [dbo].[ItemCarrinho] ([Id], [CarrinhoId], [ProdutoId], [Quantidade]) VALUES (12, 3, 6, 2)
SET IDENTITY_INSERT [dbo].[ItemCarrinho] OFF
GO
SET IDENTITY_INSERT [dbo].[Produto] ON 

INSERT [dbo].[Produto] ([Id], [Nome], [TipoProduto], [Preco]) VALUES (1, N'Camiseta Preta', N'Vestuário', CAST(59.90 AS Decimal(10, 2)))
INSERT [dbo].[Produto] ([Id], [Nome], [TipoProduto], [Preco]) VALUES (2, N'Tênis Esportivo', N'Calçado', CAST(249.99 AS Decimal(10, 2)))
INSERT [dbo].[Produto] ([Id], [Nome], [TipoProduto], [Preco]) VALUES (4, N'Tênis Padel', N'Calçado', CAST(449.99 AS Decimal(10, 2)))
INSERT [dbo].[Produto] ([Id], [Nome], [TipoProduto], [Preco]) VALUES (5, N'Camiseta I Love Science', N'Camiseta', CAST(89.90 AS Decimal(10, 2)))
INSERT [dbo].[Produto] ([Id], [Nome], [TipoProduto], [Preco]) VALUES (6, N'Camiseta Hatsune Miku', N'Camiseta', CAST(89.90 AS Decimal(10, 2)))
INSERT [dbo].[Produto] ([Id], [Nome], [TipoProduto], [Preco]) VALUES (7, N'Camiseta Kasane Teto', N'Camiseta', CAST(89.90 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Produto] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Role]) VALUES (1, N'Usuario')
INSERT [dbo].[Role] ([Id], [Role]) VALUES (2, N'Administrador')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Email], [NomeCompleto], [Senha], [RoleId]) VALUES (1, N'João@mail.com', N'JoãoSilva', N'Teste123', 2)
INSERT [dbo].[Usuario] ([Id], [Email], [NomeCompleto], [Senha], [RoleId]) VALUES (2, N'Maria@mail.com', N'Maria Silva', N'123Teste', 2)
INSERT [dbo].[Usuario] ([Id], [Email], [NomeCompleto], [Senha], [RoleId]) VALUES (3, N'Mauro@mail.com', N'Mauro Maurilio', N'@Teste123', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [NomeCompleto], [Senha], [RoleId]) VALUES (4, N'Maria@mail.com', N'Maria Silva', N'senhaTeste123', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [NomeCompleto], [Senha], [RoleId]) VALUES (5, N'Teste@mail.com', N'Teste Silva', N'senhaTeste123', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [NomeCompleto], [Senha], [RoleId]) VALUES (6, N'barba@mail.com', N'Barba Silva', N'senhaTeste123', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [NomeCompleto], [Senha], [RoleId]) VALUES (7, N'barba@mail.com', N'Barba Silva', N'senhaTeste123', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [NomeCompleto], [Senha], [RoleId]) VALUES (8, N'barbsddsa@dmail.com', N'Badssdsrba Silva', N'senhaTeste123', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [NomeCompleto], [Senha], [RoleId]) VALUES (10, N'James@mail.com', N'James Watson Silva', N'senhaTeste123', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Carrinho]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Produto] FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_Produto]
GO
ALTER TABLE [dbo].[ImagemProduto]  WITH CHECK ADD FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[ItemCarrinho]  WITH CHECK ADD FOREIGN KEY([CarrinhoId])
REFERENCES [dbo].[Carrinho] ([Id])
GO
ALTER TABLE [dbo].[ItemCarrinho]  WITH CHECK ADD FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
USE [master]
GO
ALTER DATABASE [CodeWear3] SET  READ_WRITE 
GO