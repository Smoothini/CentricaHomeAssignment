USE [master]
GO
/****** Object:  Database [CentricaDemo]    Script Date: 03-03-2021 11:41:30 ******/
CREATE DATABASE [CentricaDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CentricaDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CentricaDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CentricaDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CentricaDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CentricaDemo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CentricaDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CentricaDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CentricaDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CentricaDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CentricaDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CentricaDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [CentricaDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CentricaDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CentricaDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CentricaDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CentricaDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CentricaDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CentricaDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CentricaDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CentricaDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CentricaDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CentricaDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CentricaDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CentricaDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CentricaDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CentricaDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CentricaDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CentricaDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CentricaDemo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CentricaDemo] SET  MULTI_USER 
GO
ALTER DATABASE [CentricaDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CentricaDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CentricaDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CentricaDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CentricaDemo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CentricaDemo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CentricaDemo] SET QUERY_STORE = OFF
GO
USE [CentricaDemo]
GO
/****** Object:  Table [dbo].[District]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PrimarySalesPersonID] [int] NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_District] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesPerson]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesPerson](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SalesPerson] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecondarySPMapping]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecondarySPMapping](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[District_ID] [int] NOT NULL,
	[SecondarySalesPerson_ID] [int] NOT NULL,
 CONSTRAINT [PK_SecondarySPMapping] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Info] [nvarchar](50) NULL,
	[District] [int] NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [U_DistrictSSP]    Script Date: 03-03-2021 11:41:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [U_DistrictSSP] ON [dbo].[SecondarySPMapping]
(
	[District_ID] ASC,
	[SecondarySalesPerson_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK_District_PrimarySalesPerson] FOREIGN KEY([PrimarySalesPersonID])
REFERENCES [dbo].[SalesPerson] ([ID])
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK_District_PrimarySalesPerson]
GO
ALTER TABLE [dbo].[SecondarySPMapping]  WITH CHECK ADD  CONSTRAINT [FK_SecondarySPMapping_District] FOREIGN KEY([District_ID])
REFERENCES [dbo].[District] ([ID])
GO
ALTER TABLE [dbo].[SecondarySPMapping] CHECK CONSTRAINT [FK_SecondarySPMapping_District]
GO
ALTER TABLE [dbo].[SecondarySPMapping]  WITH CHECK ADD  CONSTRAINT [FK_SecondarySPMapping_SalesPerson] FOREIGN KEY([SecondarySalesPerson_ID])
REFERENCES [dbo].[SalesPerson] ([ID])
GO
ALTER TABLE [dbo].[SecondarySPMapping] CHECK CONSTRAINT [FK_SecondarySPMapping_SalesPerson]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_District] FOREIGN KEY([District])
REFERENCES [dbo].[District] ([ID])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_District]
GO
/****** Object:  StoredProcedure [dbo].[spDistrictAppendSSP]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDistrictAppendSSP]
@District_ID int,
@SP_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Insert into SecondarySPMapping (District_ID, SecondarySalesPerson_ID) Values (@District_ID, @SP_ID)

END
GO
/****** Object:  StoredProcedure [dbo].[spDistrictListSSP]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDistrictListSSP]
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Select SalesPerson.* from SalesPerson
left join SecondarySPMapping on SalesPerson.ID = SecondarySPMapping.SecondarySalesPerson_ID
where SecondarySPMapping.District_ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[spDistrictPossibleSSP]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDistrictPossibleSSP] 
@District_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select SalesPerson.*
from SalesPerson
where not exists (

select SecondarySPMapping.SecondarySalesPerson_ID from SecondarySPMapping 
where (SecondarySalesPerson_ID = SalesPerson.ID and District_ID = @District_ID))

END
GO
/****** Object:  StoredProcedure [dbo].[spDistrictRemoveSSP]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDistrictRemoveSSP]
@District_ID int,
@SSP_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
delete from SecondarySPMapping
where District_ID = @District_ID
and
SecondarySalesPerson_ID = @SSP_ID
END
GO
/****** Object:  StoredProcedure [dbo].[spDistrictSPView]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDistrictSPView]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
select District.ID, District.Name, District.PrimarySalesPersonID, SalesPerson.Name as PrimarySalesPerson, count(SecondarySPMapping.District_ID) as SSPCount
from District
left join SalesPerson
on SalesPerson.ID = District.PrimarySalesPersonID
left join SecondarySPMapping
on SecondarySPMapping.District_ID = District.ID
group by District.ID, District.Name, District.PrimarySalesPersonID, SalesPerson.Name
END
GO
/****** Object:  StoredProcedure [dbo].[spDistrictStoreCount]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDistrictStoreCount]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		select District.ID, District.Name, count(Store.District) as Stores
from District
left join Store
on Store.District = District.ID
group by District.ID, District.Name
END
GO
/****** Object:  StoredProcedure [dbo].[spSafeDeleteDistrictByID]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSafeDeleteDistrictByID]
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

update Store
set District=NULL
where District = @ID

delete from SecondarySPMapping
where District_ID = @ID

delete from District
where ID = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[spStoreCreate]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spStoreCreate]
@Name nvarchar(50),
@Info nvarchar(50),
@District int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO Store (Name, Info, District) VALUES (@Name, @Info, @District)
END
GO
/****** Object:  StoredProcedure [dbo].[spStoreDeleteById]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spStoreDeleteById] 
@ID int
AS
DELETE FROM Store WHERE ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[spStoreReadAll]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spStoreReadAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Store.ID, Store.Name, Store.Info, Store.District as 'DistrictID', District.Name as 'DistrictName'
from store
inner join District on District.ID=Store.District
END
GO
/****** Object:  StoredProcedure [dbo].[spStoreReadById]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spStoreReadById] 
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Store.ID, Store.Name, Store.Info, Store.District as 'DistrictID', District.Name as 'DistrictName'
from store
inner join District on District.ID=Store.District
where Store.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[spStoreUpdate]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spStoreUpdate] 
@ID int,
@Name nvarchar(50),
@Info nvarchar(50),
@District int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE Store
SET Name=@Name, Info=@Info, District=@District
WHERE ID=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[StoresByDistrictID]    Script Date: 03-03-2021 11:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[StoresByDistrictID] 
	-- Add the parameters for the stored procedure here
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;select * from Store
where Store.District=@ID
END
GO
USE [master]
GO
ALTER DATABASE [CentricaDemo] SET  READ_WRITE 
GO
