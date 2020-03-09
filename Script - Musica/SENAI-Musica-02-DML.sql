CREATE DATABASE Musica_DML;
GO

USE Musica_DDL;
GO

INSERT INTO Estilo (Nome)
VALUES	('Reggae'),
		('Rap'),
		('Rock'),
		('Funk'),
		('Trap');
GO

INSERT INTO Musica (Nome, IdEstilo)
VALUES	('Sei lá','4'),
		('Andei só','1'),
		('Old town road','5'),
		('Jesus Chorou','2'),
		('One','3');
GO