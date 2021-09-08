INSERT INTO Tbl_Produtos(Descricao, Preco, Observacao, Multiplicador) VALUES
('Bolo de pote sabor brigadeiro', 8.5, 'Bolo de brigadeiro com cacau 100%', 1),
('Fatia de bolo sabor Ferrero Rocher', 7.00, 'Fatia de bolo sabor Ferrero Rocher', 1),
('Fatia de bolo sabor Ninho com geleia de morango', 7.00, 'Fatia de bolo sabor Ninho com geleia de morango', 1),
('Tortinha de lim�o', 6.00, 'Tortinha de lim�o', 1),
('Cento de salgados fritos tamanho Festa', 60, 'O Cento', 100),
('Mini Naked', 50, 'Bolo mini naked de 10 fatias com direito a dois recheios. (Topper n�o incluso)', 1),
('Bolo 16 fatias', 100, 'Bolo confeitado com direito a dois recheios. Serve 16 fatias. (Topper n�o incluso)', 1)
GO

INSERT INTO Tbl_Imagens(ProdutoId, Caminho, Descricao, OrdemVisualizacao) VALUES
(1, 'C:\Imagens\bolodepote.jpg', 'foto de bolo de pote', 1),
(2, 'C:\Imagens\fatia1.jpg', 'fatia1', 1),
(3, 'C:\Imagens\fatia2.jpg', 'fatia2', 1),
(4, 'C:\Imagens\tortinha.jpg', 'tortinha', 1),
(6, 'C:\Imagens\mininaked1.jpg', 'mininaked', 1),
(6, 'C:\Imagens\mininaked2.jpg', 'mininaked', 2),
(6, 'C:\Imagens\mininaked3.jpg', 'mininaked', 3),
(6, 'C:\Imagens\mininaked4.jpg', 'mininaked', 4),
(7, 'C:\Imagens\Bolo16fatias1.jpg', 'Bolo16fatias', 1),
(7, 'C:\Imagens\Bolo16fatias2.jpg', 'Bolo16fatias', 2),
(7, 'C:\Imagens\Bolo16fatias3.jpg', 'Bolo16fatias', 3),
(7, 'C:\Imagens\Bolo16fatias4.jpg', 'Bolo16fatias', 4),
(5, 'C:\Imagens\centosalgado1.jpg', 'meiocentosalgado', 1),
(5, 'C:\Imagens\centosalgado2.jpg', 'meiocentosalgado', 2),
(5, 'C:\Imagens\centosalgado3.jpg', 'meiocentosalgado', 3)
GO

INSERT INTO Tbl_Kits(Descricao, Desconto) VALUES
('Bolo 16 fatias + Cento de salgado', 0.),
('Mini Naked + Meio cento de salgado', 0.)
GO

INSERT INTO Tbl_Produto_Kit(KitId, ProdutoId, Quantidade) VALUES
(1, 5, 1), (1, 7, 1), (2, 5, 1), (2, 6, 1)
GO

SELECT * FROM Tbl_Kits
SELECT * FROM Tbl_Produtos_Kit
SELECT * FROM Tbl_Produtos