use CodeWear3_2


GO

DROP TABLE IF EXISTS [dbo].[ImagemProduto]
GO

CREATE TABLE [dbo].[ImagemProduto](
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Descricao] NVARCHAR(255) NOT NULL,
	[Imagem] VARBINARY(MAX) NOT NULL, -- <- substitui Caminho
	[TipoMime] NVARCHAR(100), -- opcional: armazenar tipo MIME
	[ProdutoId] INT NOT NULL,
	FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produto] ([Id])
)
