USE Filmes_tarde;
GO

SELECT * FROM Generos;
SELECT * FROM Filmes;

SELECT IdGenero, Nome from Generos;

SELECT Filmes.Titulo, Generos.Nome FROM Filmes
INNER JOIN Generos ON Generos.IdGenero = Filmes.IdGenero;