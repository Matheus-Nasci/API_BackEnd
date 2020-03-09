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
VALUES	('Sei l�','4'),
		('Andei s�','1'),
		('Old town road','5'),
		('Jesus Chorou','2'),
		('One','3');
GO