
CREATE DATABASE [FLIGHT_TICKET]
Go

use FLIGHT_TICKET
GO

SELECT DB_Name()

-- Create a new database called 'DataStore'
-- Connect to the 'master' database to run this snippet
-- Create the new database if it does not exist already

IF NOT EXISTS (
    SELECT name
FROM sys.databases
WHERE name = N'FLIGHT_TICKET'
)
CREATE DATABASE FLIGHT_TICKET
GO

SELECT *
FROM information_schema.tables;
Go


CREATE TABLE Account
(
    AccountId bigint NOT NULL identity(1, 1) PRIMARY KEY,
    -- primary key column
    AccountUser [NVARCHAR](50) NOT NULL,
    AccountPass [NVARCHAR](50) NOT NULL
    -- specify more columns here
);
GO
drop table Account

CREATE TABLE Profile
(
    ProfileId bigint NOT NULL primary key,
    -- primary key column
    ProfileName [NVARCHAR](50) NOT NULL,
    ProfileTypeID [int] NOT NULL default 1,
    -- specify more columns here
);
GO
drop table Profile

CREATE TABLE Permission
(
    PermissionId bigint NOT NULL identity(1, 1) PRIMARY KEY,
    -- primary key column
    PermissionName [NVARCHAR](50) NOT NULL
    -- specify more columns here
);
GO
drop table Permission


CREATE TABLE Per_Acc
(
    PerID bigint NOT NULL,
    -- primary key column
    AccId bigint NOT NULL,
    -- primary key column
    PRIMARY KEY (PerID, AccId)
    -- specify more columns here
);
GO
drop table Per_Acc


CREATE TABLE PerDetail
(
    PerDetailId bigint NOT NULL identity(1, 1) PRIMARY KEY,
    -- primary key column
    code_action [NVARCHAR](50) NOT NULL
    -- specify more columns here
);
GO
drop table PerDetail

CREATE TABLE Passenger
(
    PassengerId bigint NOT NULL identity(1, 1) PRIMARY KEY,
    -- primary key column
    PassengerName [NVARCHAR](50) NOT NULL,
    PassengerIDCard [NVARCHAR](50) NOT NULL,
    PassenserTel [NVARCHAR](50) NOT NULL

    -- specify more columns here
);
GO
drop table Passenger


CREATE TABLE Ticket
(
    TicketId bigint NOT NULL identity(1, 1) PRIMARY KEY,
    -- primary key column
    TicketIDPassenger [VARCHAR](10) NOT NULL,
    TicketIDBeginPoint int not NULL,
    TicketIDEndPoint int not NULL,

    -- specify more columns here
);
GO
drop table Ticket

CREATE TABLE City
(
    CityId [VARCHAR](10) NOT NULL PRIMARY KEY,
    -- primary key column
    CityName [NVARCHAR](50) NOT NULL
    -- specify more columns here
);
GO
drop table City


ALTER TABLE dbo.Profile ADD CONSTRAINT Profile_FK FOREIGN KEY (ProfileId) REFERENCES dbo.Account(AccountId);
GO
alter table dbo.Profile drop constraint Profile_FK
go

ALTER TABLE dbo.Per_Acc ADD CONSTRAINT Per_Acc_FK FOREIGN KEY (PerID) REFERENCES dbo.Permission(PermissionId);
GO
alter table dbo.Per_Acc drop constraint Per_Acc_FK
go

ALTER TABLE dbo.Per_Acc ADD CONSTRAINT Per_Acc1_FK FOREIGN KEY (AccId) REFERENCES dbo.Profile(ProfileId);
GO
ALTER TABLE dbo.Per_Acc drop CONSTRAINT Per_Acc1_FK
go

ALTER TABLE dbo.Ticket ADD CONSTRAINT Ticket_FK FOREIGN KEY (TicketIDPassenger) REFERENCES dbo.Passenger(PassengerId);
GO
ALTER TABLE dbo.Ticket drop CONSTRAINT Ticket_FK
go


drop PROCEDURE ProcSignup
go
CREATE PROCEDURE ProcSignup
    @user nvarchar(50),
    @pass nvarchar(50),
    @name nvarchar(50),
    @type int
AS
BEGIN
    DECLARE @countAcc INT;
    DECLARE @accountID bigint;

    SELECT @countAcc = COUNT(*)
    FROM dbo.Account
    WHERE AccountUser = @user;

    IF @countAcc = 0
		BEGIN
        INSERT dbo.Account
            (
            AccountUser,
            AccountPass
            )
        VALUES
            (
            @user,
            @pass 
			)
        select @accountID = SCOPE_IDENTITY();

        INSERT profile 
        (
        ProfileId,
        ProfileName,
        ProfileTypeID
        )
        VALUES
            (
            @accountID,
            @name,
            @type 
			)
        END
	ELSE
		BEGIN
        RAISERROR('The username already exists',16,1)
    END
END;
GO

drop PROCEDURE ProcLogin
go
CREATE PROCEDURE ProcLogin
    @user nvarchar(50),
    @pass nvarchar(50)
AS
BEGIN
    DECLARE @ID varchar(10);
    DECLARE @name nvarchar(50);
    DECLARE @PerID int;

    select @PerID = count(*) from dbo.Account
    where AccountUser = @user and AccountPass = @pass;

    IF @PerID = 0
		BEGIN
        RAISERROR('Incorrect information',16,1)
        END
END;
GO


select * from Account
select * from profile

exec ProcSignup 'mingkhoi', '123', 'khoi', 1; 