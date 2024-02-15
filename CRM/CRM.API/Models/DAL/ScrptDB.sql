-- Crear la base de datos CRMDB
CREATE DATABASE CRMDB
GO
--Utilizar la base de datos CRMDB
USE CRMDB
GO
--Crear la tabla customers (anteriormente Clients)
CREATE TABLE Customers
(
id INT IDENTITY (1,1) PRIMARY KEY,
NAME VARCHAR (50) NOT NULL,
LastName VARCHAR (50) NOT NULL,
Address VARCHAR (255)
)

GO
