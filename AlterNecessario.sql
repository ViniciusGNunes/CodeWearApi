--CREATE TABLE Colecoes (
--    ID INT IDENTITY(1,1) PRIMARY KEY,
--    Nome NVARCHAR(140) NOT NULL,
--    Descricao NVARCHAR(140) NOT NULL
--);

--ALTER TABLE Produto
--ADD ColecaoID INT;

--ALTER TABLE Produto
--ADD CONSTRAINT FK_Produto_Colecoes FOREIGN KEY (ColecaoID) REFERENCES Colecoes(ID);


INSERT INTO Colecoes (Nome, Descricao)
VALUES
('Outono 2025', 'Coleção inspirada nas cores e clima do outono.'),
('Verão Tropical', 'Roupas leves e estampadas para dias quentes.'),
('Inverno Urbano', 'Moda urbana para o frio intenso.'),
('Primavera Floral', 'Peças com estampas florais e cores vivas.');
