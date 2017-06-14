CREATE DATABASE SistemaGimnasio2;
use SistemaGimnasio2;

drop table Asistencia;
drop table Alumnos_GrupoGimnasio;

CREATE TABLE [dbo].[catalogocoord] (
    [clavecct] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]   VARCHAR (100) NULL,
    [latitud]  VARCHAR (100) NULL,
    [longitud] VARCHAR (100) NULL,
    [lada]     VARCHAR (100) NULL,
    [telefono] VARCHAR (100) NULL,
    [email]    VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([clavecct] ASC)
);
CREATE TABLE [dbo].[Hora] (
    [IdHora]     INT      IDENTITY (1, 1) NOT NULL,
    [HoraInicio] DATETIME NOT NULL,
    [HoraFin]    DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([IdHora] ASC)
);

CREATE TABLE [dbo].[HorarioGimnasio] (
    [IdHorario] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]    VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([IdHorario] ASC)
);

CREATE TABLE [dbo].[Licenciatura] (
    [IdLicenciatura] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]         VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([IdLicenciatura] ASC)
);

CREATE TABLE [dbo].[Persona] (
    [idPersona]       INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]          VARCHAR (100) NOT NULL,
    [ApellidoPaterno] VARCHAR (100) NOT NULL,
    [ApellidoMaterno] VARCHAR (100) NOT NULL,
    [Edad]            INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([idPersona] ASC)
);
CREATE TABLE [dbo].[Grupo] (
    [Nombre]         VARCHAR (100) NOT NULL,
    [IdLicenciatura] INT           NOT NULL,
    [idGrupo]        INT           IDENTITY (1, 1) NOT NULL,
    [semestre]       VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([idGrupo] ASC),
    FOREIGN KEY ([IdLicenciatura]) REFERENCES [dbo].[Licenciatura] ([IdLicenciatura])
);
CREATE TABLE [dbo].[Alumno] (
    [Matricula] VARCHAR (8) NOT NULL,
    [idGrupo]   INT         NOT NULL,
    [idPersona] INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([Matricula] ASC),
    FOREIGN KEY ([idGrupo]) REFERENCES [dbo].[Grupo] ([idGrupo]),
    FOREIGN KEY ([idPersona]) REFERENCES [dbo].[Persona] ([idPersona])
);
CREATE TABLE [dbo].[GrupoGimnasio] (
    [idGimnasio] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]     VARCHAR (100) NULL,
    [IdHorario]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([idGimnasio] ASC),
    FOREIGN KEY ([IdHorario]) REFERENCES [dbo].[HorarioGimnasio] ([IdHorario])
);
CREATE TABLE Alumnos_GrupoGimnasio (
    [Matricula]               VARCHAR (8) NOT NULL,
    [idGimnasio]              INT         NOT NULL,
    [idAlumnos_GrupoGimnasio] INT      primary key   IDENTITY (1, 1) NOT NULL,
    FOREIGN KEY ([Matricula]) REFERENCES [Alumno] ([Matricula]),
    FOREIGN KEY ([idGimnasio]) REFERENCES [GrupoGimnasio] ([idGimnasio])
);
CREATE TABLE [dbo].[Usuario] (
    [nombreUsuario] VARCHAR (100) NOT NULL,
    [Contraseña]    VARCHAR (100) NOT NULL,
    [Rol]           VARCHAR (10)  NOT NULL,
    [idPersona]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([nombreUsuario] ASC),
    FOREIGN KEY ([idPersona]) REFERENCES [dbo].[Persona] ([idPersona])
);
CREATE TABLE [dbo].[HorarioGimnasio_Hora] (
    [idHorarioGimnasio_Horas] INT          IDENTITY (1, 1) NOT NULL,
    [IdHora]                  INT          NOT NULL,
    [IdHorario]               INT          NOT NULL,
    [Dia]                     VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([idHorarioGimnasio_Horas] ASC),
    FOREIGN KEY ([IdHorario]) REFERENCES [dbo].[HorarioGimnasio] ([IdHorario]),
    FOREIGN KEY ([IdHora]) REFERENCES [dbo].[Hora] ([IdHora])
);


CREATE TABLE [dbo].[Asistencia] (
    [Fecha]                   DATETIME     NOT NULL,
    [Estado]                  VARCHAR (10) NOT NULL,
    [idAsistencia]            INT          IDENTITY (1, 1) NOT NULL,
    [idAlumnos_GrupoGimnasio] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([idAsistencia] ASC),
    FOREIGN KEY ([idAlumnos_GrupoGimnasio]) REFERENCES [Alumnos_GrupoGimnasio] ([idAlumnos_GrupoGimnasio])
);















CREATE TABLE MigrationHistory(
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC)
);
CREATE TABLE AspNetRoles (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);

CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserRoles]([UserId] ASC);
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);

