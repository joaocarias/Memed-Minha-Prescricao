-- create database db_prescricao_memed;

use db_prescricao_memed;

create table medicos
(
	 id int IDENTITY(4026,7) PRIMARY KEY,
	 nome varchar(50) not null,
	 sobrenome varchar(200) not null,
	 data_nascimento date,
	 cpf varchar(14),
	 email varchar(254),
	 uf varchar(2),
	 sexo char(1),
	 crm varchar(10),
	 toten varchar(max),
	 idmemed varchar(20)
);

create table medico_cidade
(
	id int IDENTITY(1,1) PRIMARY KEY,
	idcidade int not null,
	idmedico int foreign key references medicos(id) not null
);

create table medico_especialidade
(
	id int IDENTITY(1,1) PRIMARY KEY,
	idespecialidade int not null,
	idmedico int foreign key references medicos(id) not null
);

create table pacientes
(
	id int IDENTITY(92020230,7) PRIMARY KEY,
	nome varchar(255) not null,
	endereco varchar(255),
	cidade varchar(255),
	telefone varchar(30) not null,
	peso int,
	altura float,
	nome_mae varchar(255),
	dificuldade_locomocao bit,
);

-- Renomear coluna
 -- EXEC sp_rename 'pacientes.enderecao', 'endereco', 'COLUMN';

