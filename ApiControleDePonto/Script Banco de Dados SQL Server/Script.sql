create database CONTROLEDEPONTO;

USE CONTROLEDEPONTO;

CREATE TABLE Cargos(
	CargoId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Descricao VARCHAR(255) NOT NULL 
);

CREATE TABLE Funcionarios(
	FuncionarioId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NomeDoFuncionario VARCHAR(255) NOT NULL,
	Cpf VARCHAR(14) NOT NULL,
	NascimentoFuncionario DATE NOT NULL,
	DataDeAdmissao DATE NOT NULL,
	CelularFuncionario VARCHAR(11) NOT NULL,
	EmailFuncionario VARCHAR(255) NOT NULL,
	SenhaFuncionario VARCHAR(255) NOT NULL,
	CargoId INT FOREIGN KEY  REFERENCES Cargos(CargoId)

);

CREATE TABLE Liderancas(
	LiderancaId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	FuncionarioId INT FOREIGN KEY REFERENCES Funcionarios(FuncionarioId),
	DescricaoEquipe VARCHAR(255) NOT NULL
);

CREATE TABLE Equipes(
	EquipeId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	LiderancaId INT FOREIGN KEY REFERENCES Liderancas(LiderancaId),
	FuncionarioId INT FOREIGN KEY REFERENCES Funcionarios(FuncionarioId)
);

CREATE TABLE Ponto(
	PontoId BIGINT PRIMARY KEY NOT NULL IDENTITY(1,1),
	DataHorarioPonto DATETIME NOT NULL,
	Justificativa VARCHAR(255),
	FuncionarioId INT FOREIGN KEY REFERENCES Funcionarios(FuncionarioId)
);

SELECT * FROM Funcionarios

SELECT * FROM Liderancas

SELECT * FROM Cargos

SELECT * FROM Ponto

SELECT * FROM Equipes


USE CADASTRODEUSUARIOS

DELETE FROM Funcionarios

DELETE FROM Cargos

select f.NomeDoFuncionario, f.DataDeAdmissao, e.DescricaoEquipe from Funcionarios f INNER JOIN Liderancas e ON f.FuncionarioId = e.FuncionarioId  
SELECT a.Nome
FROM Funcionarios A
INNER JOIN Equipes B
ON A.FuncionarioId = B.FuncionarioId


