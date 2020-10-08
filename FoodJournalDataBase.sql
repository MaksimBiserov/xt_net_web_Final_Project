USE [master]
GO

/****** Object:  Database [FoodJournal]    Script Date: 08.10.2020 21:15:14 ******/
CREATE DATABASE [FoodJournal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodJournal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FoodJournal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FoodJournal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FoodJournal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodJournal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [FoodJournal] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [FoodJournal] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [FoodJournal] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [FoodJournal] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [FoodJournal] SET ARITHABORT OFF 
GO

ALTER DATABASE [FoodJournal] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [FoodJournal] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [FoodJournal] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [FoodJournal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [FoodJournal] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [FoodJournal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [FoodJournal] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [FoodJournal] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [FoodJournal] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [FoodJournal] SET  DISABLE_BROKER 
GO

ALTER DATABASE [FoodJournal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [FoodJournal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [FoodJournal] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [FoodJournal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [FoodJournal] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [FoodJournal] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [FoodJournal] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [FoodJournal] SET RECOVERY FULL 
GO

ALTER DATABASE [FoodJournal] SET  MULTI_USER 
GO

ALTER DATABASE [FoodJournal] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [FoodJournal] SET DB_CHAINING OFF 
GO

ALTER DATABASE [FoodJournal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [FoodJournal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [FoodJournal] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [FoodJournal] SET QUERY_STORE = OFF
GO

ALTER DATABASE [FoodJournal] SET  READ_WRITE 
GO


USE [FoodJournal]
GO

/****** Object:  Table [dbo].[Account]    Script Date: 08.10.2020 21:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NULL,
	[BodyWeight] [float] NULL,
	[Goal] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Account] ADD  DEFAULT ((1)) FOR [Goal]
GO

ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [fk_Goals] FOREIGN KEY([Goal])
REFERENCES [dbo].[Goals] ([ID])
GO

ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [fk_Goals]
GO


USE [FoodJournal]
GO

/****** Object:  Table [dbo].[Categories]    Script Date: 08.10.2020 21:19:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories](
	[id] [int] NOT NULL,
	[Category] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [FoodJournal]
GO

/****** Object:  Table [dbo].[Dish]    Script Date: 08.10.2020 21:20:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dish](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Calorific] [float] NOT NULL,
	[NetMass] [int] NOT NULL,
 CONSTRAINT [PK_Dish] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [FoodJournal]
GO

/****** Object:  Table [dbo].[Goals]    Script Date: 08.10.2020 21:20:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Goals](
	[ID] [int] NOT NULL,
	[Goal] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Goal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [FoodJournal]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 08.10.2020 21:20:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Calorific] [float] NOT NULL,
	[NetMass] [int] NOT NULL,
	[Image] [varbinary](max) NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((1)) FOR [Category]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [fk_Categories] FOREIGN KEY([Category])
REFERENCES [dbo].[Categories] ([id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [fk_Categories]
GO


USE [FoodJournal]
GO

/****** Object:  StoredProcedure [dbo].[AddAccount]    Script Date: 08.10.2020 21:21:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAccount]
	@LoginName nvarchar(50),
	@Password nvarchar(50),
	@Role NVARCHAR(50)=NULL,
	@BodyWeight FLOAT(53)=null,
	@Goal INT,
	@ID INT OUTPUT
AS
BEGIN
	INSERT INTO [Account](LoginName, Password, Role, BodyWeight, Goal)
	VALUES (@LoginName, @Password, @Role, @BodyWeight, @Goal)
	set @ID = SCOPE_IDENTITY();
END
GO


USE [FoodJournal]
GO

/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 08.10.2020 21:21:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddProduct]
	@ProductName nvarchar(50),
	@Calorific FLOAT (53),
	@NetMass INT,
	@Image varbinary(max)=null,
	@Category INT,
	@ID INT OUTPUT
AS
BEGIN
	INSERT INTO Product(ProductName, Calorific, NetMass, Image, Category)
	VALUES (@ProductName, @Calorific, @NetMass, @Image, @Category)
	set @ID = SCOPE_IDENTITY();
END
GO


USE [FoodJournal]
GO

/****** Object:  StoredProcedure [dbo].[AddToDish]    Script Date: 08.10.2020 21:22:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddToDish]
	@ProductName nvarchar(50),
	@Calorific FLOAT (53),
	@NetMass INT,
	@ID INT OUTPUT
AS
BEGIN
	INSERT INTO Dish(ProductName, Calorific, NetMass)
	VALUES (@ProductName, @Calorific, @NetMass)
	set @ID = SCOPE_IDENTITY();
END
GO


