USE T_Peoples;
GO

INSERT INTO Funcionario(Nome, Sobrenome)
VALUES	('Mateus','Braz'),
		('Daniel','Araujo'),
		('Lucas','Souza'),
		('Felipe','Silva'),
		('Judas','Araujo'),
		('Ronaldo','Oliveira'),
		('Felipe','Sugisawa');
		GO

INSERT INTO Funcionario(Nome, Sobrenome)
VALUES	('Catarina','Strada'),
		('Tadeu','Vitelli');
		GO

--Exemplo 
UPDATE Funcionario
SET Nome = 'Igor'

INSERT INTO Data_Nascimento(Data_Nascimento)
VALUES	('01/02/2001'),
		('01/02/2001'),
		('01/02/2001'),
		('01/02/2001'),
		('01/02/2001'),
		('01/02/2001'),
		('01/02/2001'),
		('01/02/2001'),
		('01/02/2001');

INSERT INTO TipoUsuario (NomeUsuario)
VALUES	('Comum'),
		('Administrador');

INSERT INTO Usuario (Email, Senha, IdTipoUsuario)
VALUES	('matheus@email.com','123',1),
		('admin@email.com','123',2);