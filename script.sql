CREATE TABLE [dbo].[Projeto]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [descricao] VARCHAR(50) NULL, 
    [prazo] VARCHAR(50) NULL, 
    [observacao] VARCHAR(50) NULL, 
    [ativo] BIT NULL
)

CREATE TABLE [dbo].[Competencia]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [descricao] VARCHAR(50) NULL, 
    [ativo] BIT NULL
)

CREATE TABLE [dbo].[Colaborador] (
    [id]            INT          NOT NULL,
    [Nome]          VARCHAR (50) NULL,
    [cpf]           VARCHAR (50) NULL,
    [rg]            VARCHAR (30) NULL,
    [telefone]      VARCHAR (30) NULL,
    [email]         VARCHAR (50) NULL,
    [estadoCivil]   INT          NULL,
    [paginaPessoal] VARCHAR (50) NULL,
    [login]         VARCHAR (50) NULL,
    [senha]         VARCHAR (50) NULL,
    [ativo]         BIT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)


CREATE TABLE [dbo].[Atividade]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [descricao] VARCHAR(50) NULL, 
    [prazo] VARCHAR(50) NULL
)
