create database SistemaGimnasio
go
use SistemaGimnasio
go

/*
Created		9/23/2016
Modified		3/1/2017
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2000 
*/


Drop table [Persona] 
go
Drop table [Usuario] 
go
Drop table [Asistencia] 
go
Drop table [Alumnos_GrupoGimnasio] 
go
Drop table [HorarioGimnasio_Hora] 
go
Drop table [Hora] 
go
Drop table [HorarioGimnasio] 
go
Drop table [GrupoGimnasio] 
go
Drop table [Grupo] 
go
Drop table [Licenciatura] 
go
Drop table [Alumno] 
go


Create table [Alumno]
(
	[Matricula] Varchar(8) NOT NULL,
	[idGrupo] Integer NOT NULL,
	[idPersona] Integer NOT NULL,
Primary Key ([Matricula])
) 
go

Create table [Licenciatura]
(
	[IdLicenciatura] Integer identity NOT NULL,
	[Nombre] Varchar(100) NULL,
Primary Key ([IdLicenciatura])
) 
go

Create table [Grupo]
(
	[Nombre] Varchar(100) NOT NULL,
	[IdLicenciatura] Integer NOT NULL,
	[idGrupo] Integer identity NOT NULL,
	[semestre] Varchar(100) NOT NULL,
Primary Key ([idGrupo])
) 
go

Create table [GrupoGimnasio]
(
	[idGimnasio] Integer identity NOT NULL,
	[nombre] Varchar(100) NULL,
	[IdHorario] Integer NOT NULL,
Primary Key ([idGimnasio])
) 
go

Create table [HorarioGimnasio]
(
	[IdHorario] Integer identity NOT NULL,
	[nombre] Varchar(100) NULL,
Primary Key ([IdHorario])
) 
go

Create table [Hora]
(
	[IdHora] Integer identity NOT NULL,
	[HoraInicio] Datetime NOT NULL,
	[HoraFin] Datetime NOT NULL,
Primary Key ([IdHora])
) 
go

Create table [HorarioGimnasio_Hora]
(
	[idHorarioGimnasio_Horas] Integer identity NOT NULL,
	[IdHora] Integer NOT NULL,
	[IdHorario] Integer NOT NULL,
	[Dia] Varchar(10) NOT NULL,
Primary Key ([idHorarioGimnasio_Horas])
) 
go

Create table [Alumnos_GrupoGimnasio]
(
	[Matricula] Varchar(8) NOT NULL,
	[idGimnasio] Integer NOT NULL,
	[idAlumnos_GrupoGimnasio] Integer NOT NULL,
Primary Key ([Matricula],[idGimnasio],[idAlumnos_GrupoGimnasio])
) 
go

Create table [Asistencia]
(
	[Fecha] Datetime NOT NULL,
	[Estado] Varchar(10) NOT NULL,
	[Matricula] Varchar(8) NOT NULL,
	[idGimnasio] Integer NOT NULL,
	[idAsistencia] Integer identity NOT NULL,
	[idAlumnos_GrupoGimnasio] Integer NOT NULL,
Primary Key ([idAsistencia])
) 
go

Create table [Usuario]
(
	[nombreUsuario] Varchar(100) NOT NULL,
	[Contraseña] Varchar(100) NOT NULL,
	[Rol] Varchar(10) NOT NULL,
	[idPersona] Integer NOT NULL,
Primary Key ([nombreUsuario])
) 
go

Create table [Persona]
(
	[idPersona] Integer identity NOT NULL,
	[Nombre] Varchar(100) NOT NULL,
	[ApellidoPaterno] Varchar(100) NOT NULL,
	[ApellidoMaterno] Varchar(100) NOT NULL,
	[Edad] Integer NOT NULL,
Primary Key ([idPersona])
) 
go


Alter table [Alumnos_GrupoGimnasio] add  foreign key([Matricula]) references [Alumno] ([Matricula])  on update no action on delete no action 
go
Alter table [Grupo] add  foreign key([IdLicenciatura]) references [Licenciatura] ([IdLicenciatura])  on update no action on delete no action 
go
Alter table [Alumno] add  foreign key([idGrupo]) references [Grupo] ([idGrupo])  on update no action on delete no action 
go
Alter table [Alumnos_GrupoGimnasio] add  foreign key([idGimnasio]) references [GrupoGimnasio] ([idGimnasio])  on update no action on delete no action 
go
Alter table [HorarioGimnasio_Hora] add  foreign key([IdHorario]) references [HorarioGimnasio] ([IdHorario])  on update no action on delete no action 
go
Alter table [GrupoGimnasio] add  foreign key([IdHorario]) references [HorarioGimnasio] ([IdHorario])  on update no action on delete no action 
go
Alter table [HorarioGimnasio_Hora] add  foreign key([IdHora]) references [Hora] ([IdHora])  on update no action on delete no action 
go
Alter table [Asistencia] add  foreign key([Matricula],[idGimnasio],[idAlumnos_GrupoGimnasio]) references [Alumnos_GrupoGimnasio] ([Matricula],[idGimnasio],[idAlumnos_GrupoGimnasio])  on update no action on delete no action 
go
Alter table [Alumno] add  foreign key([idPersona]) references [Persona] ([idPersona])  on update no action on delete no action 
go
Alter table [Usuario] add  foreign key([idPersona]) references [Persona] ([idPersona])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


/* Roles permissions */


/* Users permissions */

