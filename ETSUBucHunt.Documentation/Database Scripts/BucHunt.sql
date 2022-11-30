-- BucHunt Team 2 Database Tables
--
-- IDENTITY(1,1) indicates auto-increment starting at 1 and incrementing by 1
-- each time an insert occurs.
--
-- Microsoft documentation on Transact-SQL data types: https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16

USE master;

DROP DATABASE IF EXISTS BucHunt;

CREATE DATABASE BucHunt;

USE BucHunt;

CREATE TABLE Hunts (huntId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
				    title VARCHAR(255),
				    theme VARCHAR(255),
				    invitationText VARCHAR(255),
				    url VARCHAR(255),
				    status TINYINT,
				    dateCreated DATETIME2,
					startDate DATETIME2,
					endDate DATETIME2)

CREATE TABLE Tasks (taskId INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
				    label VARCHAR(255),
				    answer VARCHAR(255),
				    latitude FLOAT,
				    longitude FLOAT,
				    displayOrder INT,
				    qrImageUrl VARCHAR(255), 
				    qrValue VARCHAR(255), 
				    huntId INT,
				    FOREIGN KEY (huntId) REFERENCES Hunts(huntId))

CREATE TABLE Users (userId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
					username VARCHAR(255),
					firstName VARCHAR(255),
					lastName VARCHAR(255),
					email VARCHAR(255),
					phoneNumber VARCHAR(255),
					admin BIT DEFAULT 0)

CREATE TABLE Hunt_Groups (groupId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
						  dateStarted DATETIME2,
						  huntId INT,
						  FOREIGN KEY (huntId) REFERENCES Hunts(huntId))

CREATE TABLE Hunt_Group_Members (Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
								 userId INT,
								 groupId INT,
								 FOREIGN KEY (userId) REFERENCES Users(userId),
								 FOREIGN KEY (groupId) REFERENCES Hunt_Groups(groupId))

CREATE TABLE Task_Progress (Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
							complete BIT DEFAULT 0,
							timestamp DATETIME2,
							groupId INT,
							taskId INT,
							userId INT,
							FOREIGN KEY (groupId) REFERENCES Hunt_Groups(groupId),
							FOREIGN KEY (taskId) REFERENCES Tasks(taskId),
							FOREIGN KEY (userId) REFERENCES Users(userId))

CREATE TABLE Codes (accessCode VARCHAR(255) PRIMARY KEY NOT NULL,
					status TINYINT,
					userId INT,
					huntId INT,
					FOREIGN KEY (userId) REFERENCES Users(userId),
					FOREIGN KEY (huntId) REFERENCES Hunts(huntId))

CREATE TABLE Scores (Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
					 timeTaken TIME,
					 userId INT,
					 huntId INT,
					 FOREIGN KEY (userId) REFERENCES Users(userId),
					 FOREIGN KEY (huntId) REFERENCES Hunts(huntId))

USE master;