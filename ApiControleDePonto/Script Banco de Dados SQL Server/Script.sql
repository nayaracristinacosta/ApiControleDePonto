CREATE DATABASE CONTROLEDEPONTO;

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
	ON DELETE CASCADE

);

CREATE TABLE Liderancas(
	LiderancaId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	FuncionarioId INT FOREIGN KEY REFERENCES Funcionarios(FuncionarioId) ON DELETE CASCADE,
	DescricaoEquipe VARCHAR(255) NOT NULL
);

CREATE TABLE Equipes(
	EquipeId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	LiderancaId INT  NOT NULL, 
	FuncionarioId INT  NOT NULL, 
	FOREIGN KEY (LiderancaId)  REFERENCES Liderancas(LiderancaId) ,
	FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios(FuncionarioId)
);

CREATE TABLE Ponto(
	PontoId BIGINT PRIMARY KEY NOT NULL IDENTITY(1,1),
	DataHorarioPonto DATETIME NOT NULL,
	Justificativa VARCHAR(255),
	FuncionarioId INT FOREIGN KEY REFERENCES Funcionarios(FuncionarioId) ON DELETE CASCADE
);

insert into Cargos values('Administrador');
insert into Cargos values('Recursos Humanos');
insert into Cargos values('Diretoria');
insert into Cargos values('Colaborador');

INSERT INTO Funcionarios(NomeDoFuncionario, Cpf, NascimentoFuncionario, DataDeAdmissao, CelularFuncionario,EmailFuncionario, SenhaFuncionario, CargoId)
VALUES('Administrador', '66136918013', '2000-01-01', '2000-01-01', '999999999','administrador@administrador.com', '12345', 1 );

