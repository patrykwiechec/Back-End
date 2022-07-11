Create database Turniej;
GO
USE Turniej
GO
/****** Object:  Table [dbo].[trenerzy]    Script Date: 07.07.2022 18:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trenerzy](
	[id_trenera] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[imie_t] [varchar](20) NOT NULL,
	[nazwisko_t] [varchar](25) NOT NULL,
	[ile_medali_t] [int] NOT NULL
	)


CREATE TABLE [dbo].[uczestnictwo](
	[id_uczestnictwa] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[id_zawodnika] [int] NULL,
	[id_zawodow] [int] NULL)

CREATE TABLE [dbo].[zawodnicy](
	[id_zawodnika] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[imie] [varchar](20) NOT NULL,
	[nazwisko] [varchar](25) NOT NULL,
	[kraj] [varchar](20) NOT NULL,
	[ile_medali_t] [int] NOT NULL,
	[id_trenera] [int] NULL,
)

CREATE TABLE [dbo].[zawody](
	[id_zawodow] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[nazwa] [varchar](50) NOT NULL,
	[lokalizacja] [varchar](30) NOT NULL)

ALTER TABLE [dbo].[uczestnictwo]  WITH CHECK ADD FOREIGN KEY([id_zawodnika])
REFERENCES [dbo].[zawodnicy] ([id_zawodnika])
GO
ALTER TABLE [dbo].[uczestnictwo]  WITH CHECK ADD FOREIGN KEY([id_zawodow])
REFERENCES [dbo].[zawody] ([id_zawodow])
GO
ALTER TABLE [dbo].[zawodnicy]  WITH CHECK ADD FOREIGN KEY([id_trenera])
REFERENCES [dbo].[trenerzy] ([id_trenera])
GO


INSERT INTO trenerzy VALUES
('Michał','Aparat',5),
('Aleksander','Lampka',8),
('Mariusz','Naizdup',12)

INSERT INTO zawody VALUES
('Turniej ping-pong "Paletka"','Kraków'),
('Turniej tenisa "Trawka"','Zakopane'),
('Turniej kolarski "Przerzutka"','Warszawa')

INSERT INTO zawodnicy VALUES
('Patryk','Zapał','Polska',3,2),
('Olek','Kraskov','Litwa',4,1),
('Antoni','Makaroni','Włochy',2,3)

INSERT INTO uczestnictwo VALUES
(3,1),
(2,3),
(1,2)

Create database Obiekty;

GO

USE Obiekty;

Create table obiekt(
	IdObiekt int IDENTITY(1,1) PRIMARY KEY,
	lokalizacja varchar(30) not null,
	Nazwa varchar(50) not null,
	Ilosc_miejsc int not null,
	Cena_biletu int not null,
	Cena_biletu_vip int not null
)

Insert into obiekt VALUES
('Kraków','Stadion Miejski im. Henryka Reymana',7000,40,80),
('Warszawa','PGE Narodowy',30000,80,140),
('Zakopane','Stadion lekkoatletyczny COS Zakopane',5000,50,75),
('Wrocław','Tarczyński Arena', 9000, 60, 90),
('Opole','Stadion Miejski OKS Odra Opole', 3000, 30, 60)