CREATE DATABASE Musica_DQL;
GO

USE Musica_DDL;
GO

SELECT * FROM Musica;
SELECT * FROM Estilo;

SELECT Musica.Nome AS NomeMusica, Estilo.Nome AS Estilo FROM Musica
INNER JOIN Estilo ON Estilo.IdEstilo = Musica.IdEstilo
