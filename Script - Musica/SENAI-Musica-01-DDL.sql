CREATE DATABASE Musica_DDL;
GO

USE Musica_DDL;
GO

CREATE TABLE Estilo (
	IdEstilo	INT PRIMARY KEY IDENTITY,
	Nome		VARCHAR (255)
	);
GO

CREATE TABLE Musica (
	IdMusica	INT PRIMARY KEY IDENTITY,
	Nome		VARCHAR (255),
	IdEstilo	INT FOREIGN KEY REFERENCES Estilo (IdEstilo)
);
GO

