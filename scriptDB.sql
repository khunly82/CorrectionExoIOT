CREATE DATABASE [iot.db];

GO 

USE [iot.db];

CREATE TABLE InfoMaison (
	Id INT PRIMARY KEY IDENTITY,
	[Value] DECIMAL(10,2) NOT NULL,
	[Date] DATETIME2 NOT NULL,
	[Type] INT NOT NULL
)