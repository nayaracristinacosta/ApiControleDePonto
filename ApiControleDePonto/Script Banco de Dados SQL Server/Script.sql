create database CONTROLEDEPONTO;

USE CONTROLEDEPONTO;

CREATE TABLE Cargos(
	CargoId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Descricao VARCHAR(255) NOT NULL 
);

CREATE TABLE Funcionarios(
	FunconarioId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NomeDoFuncionario VARCHAR(255) NOT NULL,
	Cpf VARCHAR(14) NOT NULL,
	NascimentoFuncionario DATE NOT NULL,
	DataDeAdmissao DATE NOT NULL,
	CelularFuncionario VARCHAR(11) NOT NULL,
	EmailFuncionario VARCHAR(255) NOT NULL,
	CargoId INT FOREIGN KEY  REFERENCES Cargos(CargoId)

);

CREATE TABLE Liderancas(
	LiderancaId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	FuncionarioId INT FOREIGN KEY REFERENCES Funcionarios(FunconarioId),
	DescricaoEquipe VARCHAR(255) NOT NULL
);

CREATE TABLE Equipes(
	EquipeId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	LiderancaId INT FOREIGN KEY REFERENCES Liderancas(LiderancaId),
	FuncionarioId INT FOREIGN KEY REFERENCES Funcionarios(FunconarioId)
);

CREATE TABLE Ponto(
	PontoId BIGINT PRIMARY KEY NOT NULL IDENTITY(1,1),
	DataHorarioPonto DATETIME NOT NULL,
	Justificativa VARCHAR(255),
	FuncionarioId INT FOREIGN KEY REFERENCES Funcionarios(FunconarioId)
);

SELECT * FROM Cargos