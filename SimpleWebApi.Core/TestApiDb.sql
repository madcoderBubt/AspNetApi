USE [master]
GO
/****** Object:  Database [BloodDonationSystemDb]    Script Date: 10/3/2021 1:20:50 PM ******/
CREATE DATABASE [BloodDonationSystemDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BloodDonationSystemDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BloodDonationSystemDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BloodDonationSystemDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BloodDonationSystemDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BloodDonationSystemDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BloodDonationSystemDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BloodDonationSystemDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BloodDonationSystemDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BloodDonationSystemDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BloodDonationSystemDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BloodDonationSystemDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BloodDonationSystemDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BloodDonationSystemDb] SET  MULTI_USER 
GO
ALTER DATABASE [BloodDonationSystemDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BloodDonationSystemDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BloodDonationSystemDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BloodDonationSystemDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BloodDonationSystemDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BloodDonationSystemDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BloodDonationSystemDb] SET QUERY_STORE = OFF
GO
USE [BloodDonationSystemDb]
GO
/****** Object:  UserDefinedTableType [dbo].[SkillTableType]    Script Date: 10/3/2021 1:20:51 PM ******/
CREATE TYPE [dbo].[SkillTableType] AS TABLE(
	[SkillName] [nvarchar](20) NOT NULL,
	[ExpInYear] [decimal](18, 0) NULL,
	[Proficiency] [nvarchar](15) NOT NULL
)
GO
/****** Object:  Table [dbo].[Donars]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](20) NOT NULL,
	[BloodGroup] [varchar](3) NOT NULL,
	[LastDonation] [datetime] NULL,
	[BirthDate] [datetime] NULL,
	[Gender] [nvarchar](5) NULL,
	[Area] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[EmpId] [int] NOT NULL,
	[SkillName] [nvarchar](20) NOT NULL,
	[ExpInYear] [decimal](18, 0) NULL,
	[Proficiency] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC,
	[SkillName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Skills]  WITH CHECK ADD FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employees] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[CreateDonar]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateDonar]
	@FullName     NVARCHAR (50),
    @Email        NVARCHAR (50),
    @ContactNo    NVARCHAR (20),
    @BloodGroup   VARCHAR (3) ,
    @LastDonation DATETIME , 
    @BirthDate   DATETIME  ,
    @Gender      NVARCHAR (5), 
    @Area         NVARCHAR (50)
AS
Begin
	INSERT INTO Donars
	VALUES (
	@FullName, @Email, @ContactNo, @BloodGroup, @LastDonation, 
	@BirthDate, @Gender, @Area
	);
End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[DelEmployee]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DelEmployee]
	@Id int
AS
Begin	
	Delete Skills where EmpId = @Id;

	Delete Employees where Id = @Id;
End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[DeleteDonar]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteDonar]
	@Id int
AS
Begin
	Delete Donars
	where Id = @Id;
End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[GetAllDonars]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllDonars]
AS
	SELECT * from Donars
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[GetAvailDonars]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAvailDonars]
	@blood varchar(3)
AS
	SELECT * from Donars where BloodGroup=@blood
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[GetDonar]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDonar]
	@id int
AS
	SELECT * from Donars where Id = id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[GetEmployee]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployee]
	@empId int = 0
AS
begin
	SET NOCOUNT ON;
	SELECT * from Employees where Id = @empId;
	select * from Skills where EmpId = @empId;
end
GO
/****** Object:  StoredProcedure [dbo].[GetEmployees]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployees]
AS
Begin
	select * from Employees

	select * from Skills
End
GO
/****** Object:  StoredProcedure [dbo].[SetEmployee]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetEmployee]
	@Id int = 0,
	@FullName nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(20),
	@empId int output
AS
Begin
	if(@Id=0)
	Begin
		INSERT INTO Employees
		VALUES (@FullName, @Email, @Phone)
		select @empId = SCOPE_IDENTITY();
	End
	else
	Begin
		Update Employees
		Set FullName = @FullName, Email = @Email, Phone = @Phone 
		where Id = @Id
		select @empId = @Id;
	End
End
RETURN @empId
GO
/****** Object:  StoredProcedure [dbo].[SetSkills]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SetSkills](
	@table SkillTableType readonly,
	@empId int
)
AS
Begin
	Delete Skills where EmpId = @empId;

	Insert into Skills
	Select @empId, SkillName, ExpInYear, Proficiency
	from @table
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateDonar]    Script Date: 10/3/2021 1:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateDonar]
	@Id int,
	@FullName     NVARCHAR (50),
    @Email        NVARCHAR (50),
    @ContactNo    NVARCHAR (20),
    @BloodGroup   VARCHAR (3) ,
    @LastDonation DATETIME , 
    @BirthDate   DATETIME  ,
    @Gender      NVARCHAR (5), 
    @Area         NVARCHAR (50)
AS
Begin
	Update Donars
	set
	FullName = @FullName, 
	Email = @Email, 
	ContactNo = @ContactNo, 
	BloodGroup = @BloodGroup,
	LastDonation = @LastDonation, 
	BirthDate = @BirthDate, 
	Gender = @Gender, 
	Area = @Area	
	where Id = @Id;
End
RETURN 0
GO
USE [master]
GO
ALTER DATABASE [BloodDonationSystemDb] SET  READ_WRITE 
GO
