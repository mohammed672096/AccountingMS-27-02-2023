USE [master]
GO
/****** Object:  Database [SahabSoft-FinalCost]    Script Date: 20/01/2023 11:07:59 PM ******/
CREATE DATABASE [SahabSoft-FinalCost] ON  PRIMARY 
( NAME = N'SahabSoft-FinalCost', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SahabSoft-FinalCost.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SahabSoft-FinalCost_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SahabSoft-FinalCost_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SahabSoft-FinalCost].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SahabSoft-FinalCost] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET ARITHABORT OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET RECOVERY FULL 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET  MULTI_USER 
GO
ALTER DATABASE [SahabSoft-FinalCost] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SahabSoft-FinalCost] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SahabSoft-FinalCost', N'ON'
GO
USE [SahabSoft-FinalCost]
GO
/****** Object:  User [only11]    Script Date: 20/01/2023 11:07:59 PM ******/
CREATE USER [only11] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [admin4]    Script Date: 20/01/2023 11:07:59 PM ******/
CREATE USER [admin4] FOR LOGIN [admin4] WITH DEFAULT_SCHEMA=[dbo]
GO
sys.sp_addrolemember @rolename = N'db_owner', @membername = N'only11'
GO
sys.sp_addrolemember @rolename = N'db_datareader', @membername = N'only11'
GO
sys.sp_addrolemember @rolename = N'db_datawriter', @membername = N'only11'
GO
/****** Object:  UserDefinedFunction [dbo].[GetppmConversion]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetppmConversion](@ppmId int)
returns float
begin
return (select top 1 ppmConversion from tblPrdPriceMeasurment where ppmId=@ppmId)
 end
GO
/****** Object:  Table [dbo].[AbsenceRegulation]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbsenceRegulation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[daypermissionDayDeduction] [float] NULL,
	[daypermissionFixedAmount] [float] NULL,
	[nondaypermissionDayDeduction] [float] NULL,
	[nondaypermissionFixedAmount] [float] NULL,
	[balance] [int] NULL,
 CONSTRAINT [PK_AbsenceRegulation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ancestor]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ancestor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empID] [int] NOT NULL,
	[dateAncestor] [date] NULL,
	[amount] [float] NULL,
	[reason] [nvarchar](150) NULL,
 CONSTRAINT [PK_ancestor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetAccount]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetAccount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AssetName] [nvarchar](max) NULL,
	[AssetNameE] [nvarchar](max) NULL,
 CONSTRAINT [PK_AssetAccount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttendingLeaving]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttendingLeaving](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empID] [int] NULL,
	[date_ancestor] [date] NULL,
	[time_attendance] [time](7) NULL,
	[time_leave] [time](7) NULL,
	[betwen_attendance] [float] NULL,
	[day] [nvarchar](50) NULL,
 CONSTRAINT [PK_AttendingLeaving] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BarcodeTemplates]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BarcodeTemplates](
	[ID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Template] [varbinary](max) NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_BarcodeTemplates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cashingEmp]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cashingEmp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empID] [int] NULL,
	[typePay] [nvarchar](50) NULL,
	[dateAncestor] [date] NULL,
	[BasicSalary] [float] NULL,
	[ExtraHours] [time](7) NULL,
	[valueExtraHours] [float] NULL,
	[numberOfDays] [float] NULL,
	[valueAbsence] [float] NULL,
	[NumberAbsence] [time](7) NULL,
	[DelayValue] [float] NULL,
	[mealAllowance] [float] NULL,
	[TransferAllowance] [float] NULL,
	[OtherRewards] [float] NULL,
	[ancestor] [float] NULL,
	[Insurances] [float] NULL,
	[OtherDiscounts] [float] NULL,
	[NetSalary] [float] NULL,
	[entBoxNo] [int] NULL,
	[entRefNo] [int] NULL,
	[entCurrency] [tinyint] NULL,
	[entCurChange] [smallint] NULL,
	[entBrnId] [smallint] NULL,
	[entStatus] [tinyint] NOT NULL,
	[entDate] [smalldatetime] NULL,
	[entReverseConstraintDate] [datetime] NULL,
	[entDesc] [nvarchar](max) NULL,
 CONSTRAINT [PK_cashingEmp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CouponBarcode]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CouponBarcode](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CouponName] [nvarchar](50) NULL,
	[BarCode] [nvarchar](50) NULL,
	[IsDefault] [bit] NULL,
	[dateExpir] [datetime] NULL,
	[OffersID] [int] NULL,
	[supNo] [int] NULL,
	[supTotal] [decimal](18, 0) NULL,
	[couponPrice] [decimal](18, 0) NULL,
 CONSTRAINT [PK_CouponBarcode] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[parentID] [int] NULL,
	[mangerName] [nvarchar](max) NULL,
	[notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepreciationAccount]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepreciationAccount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DepreciationName] [nvarchar](max) NULL,
	[DepreciationNameE] [nvarchar](max) NULL,
 CONSTRAINT [PK_DepreciationAccount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empID] [int] NOT NULL,
	[date_ancestor] [date] NULL,
	[amount] [float] NULL,
	[reason] [nvarchar](max) NULL,
 CONSTRAINT [PK_Discounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrawerPeriods]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrawerPeriods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PeriodStart] [datetime] NOT NULL,
	[PeriodEnd] [datetime] NULL,
	[OpeningBalance] [float] NOT NULL,
	[ClosingBalance] [float] NOT NULL,
	[ActualBalance] [float] NOT NULL,
	[DifferenceAccountID] [int] NULL,
	[PeriodUserID] [int] NOT NULL,
	[ClosingPeriodUserID] [int] NULL,
	[DrawerID] [int] NOT NULL,
	[ClosingDrwerID] [int] NULL,
	[TransferdBalance] [float] NOT NULL,
	[RemainingBalance] [float] NOT NULL,
	[BranchID] [int] NOT NULL,
	[Status] [bit] NULL,
	[totalSupSccBank] [float] NULL,
 CONSTRAINT [PK_dbo.DrawerPeriods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fatoraCustmer]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fatoraCustmer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supNo] [int] NOT NULL,
	[fatoraDate] [datetime] NULL,
	[fatoraTitel] [nvarchar](80) NULL,
	[fatoraDesc] [nvarchar](max) NULL,
	[fatoraPath] [nvarchar](max) NULL,
	[custNo] [int] NOT NULL,
 CONSTRAINT [PK_fatoraCustmer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixedAssets]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixedAssets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[assetsName] [nvarchar](100) NULL,
	[assetsNameE] [nvarchar](100) NULL,
	[PurchaseValue] [float] NULL,
	[datePurchase] [datetime] NULL,
	[Notes] [nvarchar](max) NULL,
	[stopAssets] [bit] NULL,
	[CreateImplicitSubAccount] [bit] NULL,
	[originalAccount] [int] NULL,
	[DepreciationAccount] [int] NULL,
	[currency] [int] NULL,
	[equalizer] [bit] NULL,
	[DepreciationRate] [float] NULL,
	[currentValue] [float] NULL,
	[originalPhoto] [nvarchar](max) NULL,
	[DepreciationDay] [float] NULL,
	[CountDay] [int] NULL,
	[DepreciationNow] [float] NULL,
	[DepreciationYeer] [float] NULL,
	[photo] [image] NULL,
 CONSTRAINT [PK_FixedAssets] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixedAssetsImg]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixedAssetsImg](
	[imgId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[imgFixedAssetsId] [int] NULL,
	[imgBrn] [varbinary](max) NULL,
 CONSTRAINT [PK_FixedAssetsImg] PRIMARY KEY CLUSTERED 
(
	[imgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HolidayEmp]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HolidayEmp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[holidayName] [nvarchar](max) NULL,
	[dateAncestor] [date] NULL,
	[reason] [nvarchar](max) NULL,
	[empID] [int] NULL,
	[balance] [int] NULL,
 CONSTRAINT [PK_HolidayEmp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryBalanceing]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryBalanceing](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Date] [datetime] NOT NULL,
	[BranchID] [int] NOT NULL,
	[EmployeeName] [nvarchar](max) NOT NULL,
	[TotalShortageQty] [float] NOT NULL,
	[TotalSurplusQty] [float] NOT NULL,
	[TotalShortageValue] [float] NOT NULL,
	[TotalSurplusValue] [float] NOT NULL,
	[NetProfitOrLoses] [float] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[IsPosted] [bit] NOT NULL,
	[TotalShortageValueSale] [float] NOT NULL,
	[TotalSurplusValueSale] [float] NOT NULL,
	[NetProfitOrLosesSale] [float] NOT NULL,
 CONSTRAINT [PK_InventoryBalanceing] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryBalancingDetails]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryBalancingDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MainID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitID] [int] NOT NULL,
	[Qty] [float] NOT NULL,
	[RealQty] [float] NOT NULL,
	[Shotage] [float] NOT NULL,
	[Surplus] [float] NOT NULL,
	[Price] [float] NOT NULL,
	[TotalCost] [float] NOT NULL,
	[Cost] [float] NOT NULL,
	[TotalPrice] [float] NOT NULL,
 CONSTRAINT [PK_InventoryBalancingDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OffersProduct]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OffersProduct](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productID] [int] NULL,
	[OffersID] [int] NULL,
	[productName] [nvarchar](100) NULL,
 CONSTRAINT [PK_OffersProduct] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfficialVacation]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfficialVacation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[fromdate] [datetime] NOT NULL,
	[todate] [nvarchar](max) NOT NULL,
	[notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_OfficialVacation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OvertimeAndDelayRegulation]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OvertimeAndDelayRegulation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[DiscountValuePerHour] [float] NULL,
	[ExtraValuePerHour] [float] NULL,
	[notes] [nvarchar](max) NULL,
	[AbsenceValue] [float] NULL,
 CONSTRAINT [PK_OvertimeAndDelayRegulation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OvertimeAndDelayRegulationMinutesTable]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OvertimeAndDelayRegulationMinutesTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fromMin] [datetime] NOT NULL,
	[ToMin] [datetime] NULL,
	[ToMinute] [datetime] NULL,
	[calculate] [bit] NULL,
 CONSTRAINT [PK_OvertimeAndDelayRegulationMinutesTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RepCommission]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepCommission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NOT NULL,
	[commission] [float] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_RepCommission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RepCommissionDetails]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepCommissionDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RepId] [int] NOT NULL,
	[PrdId] [int] NOT NULL,
	[RepCommission] [int] NOT NULL,
	[StorId] [int] NOT NULL,
 CONSTRAINT [PK_RepCommissionDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reward]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reward](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empid] [int] NULL,
	[dateAncestor] [date] NULL,
	[amount] [float] NULL,
	[reason] [nvarchar](150) NULL,
 CONSTRAINT [PK_Reward] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryExtension]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryExtension](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[CalculationType] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[MainAccount] [int] NULL,
 CONSTRAINT [PK_SalaryExtension] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryRegulation]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryRegulation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[costCenter] [nvarchar](50) NULL,
	[ExpensesAccount] [float] NULL,
	[BenefitsAccount] [float] NULL,
	[DayValue] [float] NULL,
	[HourValue] [float] NULL,
	[SalaryPeriod] [nvarchar](50) NULL,
	[SalaryCalculation] [nvarchar](50) NULL,
	[DefaultSalary] [float] NULL,
	[Equation] [float] NULL,
	[BenefitListid] [int] NULL,
	[DeductionListid] [int] NULL,
 CONSTRAINT [PK_SalaryRegulation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryRegulationExtension]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryRegulationExtension](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SalaryRegulation] [float] NULL,
	[SalaryRegulationID] [int] NULL,
	[SalaryExtensionID] [int] NULL,
 CONSTRAINT [PK_SalaryRegulationExtension] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shift](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[startDate] [date] NOT NULL,
	[repeatEvery] [int] NOT NULL,
	[ShiftDaysid] [int] NULL,
	[clock_work] [time](7) NULL,
	[Holiday1] [nvarchar](50) NULL,
	[Holiday2] [nvarchar](50) NULL,
	[emp_Login] [time](7) NULL,
	[emp_exit] [time](7) NULL,
 CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxDeclaration]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxDeclaration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Sales] [float] NOT NULL,
	[SalesReturn] [float] NOT NULL,
	[SalesTax] [float] NOT NULL,
	[SalesTotal] [float] NOT NULL,
	[SalesReturnTotal] [float] NOT NULL,
	[SalesTaxTotal] [float] NOT NULL,
	[Purchase] [float] NOT NULL,
	[PurchaseReturn] [float] NOT NULL,
	[PurchaseTax] [float] NOT NULL,
	[PurchaseTotal] [float] NOT NULL,
	[PurchaseReturnTotal] [float] NOT NULL,
	[PurchaseTaxTotal] [float] NOT NULL,
	[CurrentTax] [float] NOT NULL,
	[BranchID] [smallint] NULL,
 CONSTRAINT [PK_TaxDeclaration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAccount]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccount](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[accNo] [bigint] NOT NULL,
	[accName] [nvarchar](max) NOT NULL,
	[accCat] [tinyint] NULL,
	[accParent] [int] NULL,
	[accLevel] [tinyint] NOT NULL,
	[accType] [tinyint] NOT NULL,
	[accCurrency] [tinyint] NULL,
	[accBrnId] [smallint] NULL,
	[accStatus] [tinyint] NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_tblAccount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAccountBank]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccountBank](
	[id] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[bankNo] [int] NOT NULL,
	[bankAccNo] [bigint] NOT NULL,
	[bankName] [nvarchar](50) NOT NULL,
	[bankCurrency] [tinyint] NULL,
	[bankCelling] [int] NULL,
	[bankBrnId] [smallint] NULL,
	[bankSwiftCode] [nvarchar](50) NULL,
	[bankAccIBAN] [nvarchar](50) NULL,
	[AccNoInBank] [nvarchar](50) NULL,
	[bankNameEn] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblAccountBank] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAccountBox]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccountBox](
	[id] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[boxNo] [int] NOT NULL,
	[boxAccNo] [bigint] NOT NULL,
	[boxCurrency] [tinyint] NULL,
	[boxName] [nvarchar](50) NOT NULL,
	[boxCelling] [int] NULL,
	[boxBrnId] [smallint] NULL,
 CONSTRAINT [PK_tblAccountBox] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAsset]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAsset](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[asAccNo] [bigint] NOT NULL,
	[asAccName] [nvarchar](max) NOT NULL,
	[asDate] [date] NULL,
	[asEntId] [int] NOT NULL,
	[asEntNo] [int] NOT NULL,
	[asDebit] [float] NULL,
	[asCredit] [float] NULL,
	[asDesc] [nvarchar](max) NULL,
	[asStatus] [tinyint] NULL,
	[asView] [tinyint] NULL,
	[asUserId] [smallint] NULL,
	[asBrnId] [smallint] NULL,
 CONSTRAINT [PK_tblAsset] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAssetFrgn]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAssetFrgn](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[asAccNo] [bigint] NOT NULL,
	[asAccName] [nvarchar](max) NOT NULL,
	[asDate] [date] NULL,
	[asDebit] [float] NULL,
	[asCredit] [float] NULL,
	[asDebitFrgn] [float] NULL,
	[asCreditFrgn] [float] NULL,
	[asCurrency] [tinyint] NULL,
	[asCurrencyChng] [smallint] NULL,
	[asStatus] [tinyint] NULL,
	[asUserId] [smallint] NULL,
	[asBrnId] [smallint] NULL,
 CONSTRAINT [PK_tblAssetFrgn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBarcode]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBarcode](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[brcNo] [nvarchar](50) NULL,
	[brcPrdMsurId] [int] NOT NULL,
	[brcBrnId] [smallint] NOT NULL,
 CONSTRAINT [PK_tblBarcode] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBranch]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBranch](
	[brnId] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[brnNo] [smallint] NOT NULL,
	[brnName] [nvarchar](50) NULL,
	[brnNameEn] [varchar](50) NULL,
	[brnAddress] [nvarchar](100) NULL,
	[brnAddressEn] [varchar](100) NULL,
	[brnEmail] [varchar](50) NULL,
	[brnPhnNo] [varchar](20) NULL,
	[brnFaxNo] [varchar](20) NULL,
	[brnMailBox] [varchar](20) NULL,
	[brnTaxNo] [varchar](20) NULL,
	[brnTradeNo] [varchar](20) NULL,
	[brnStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tblBranch] PRIMARY KEY CLUSTERED 
(
	[brnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBranchImg]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBranchImg](
	[imgId] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[imgBrnId] [smallint] NOT NULL,
	[imgBrn] [varbinary](max) NULL,
 CONSTRAINT [PK_tblBranchImg] PRIMARY KEY CLUSTERED 
(
	[imgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblControl]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblControl](
	[cntId] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[cntucNo] [tinyint] NOT NULL,
	[cntName] [varchar](35) NOT NULL,
	[cntCaption] [nvarchar](35) NOT NULL,
	[cntCaptionEn] [varchar](30) NULL,
 CONSTRAINT [PK_tblControl] PRIMARY KEY CLUSTERED 
(
	[cntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCountry]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCountry](
	[id] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[cntEnName] [varchar](50) NOT NULL,
	[cntArName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblCountry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCurrency]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCurrency](
	[id] [tinyint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[curName] [nvarchar](25) NOT NULL,
	[curSign] [nvarchar](5) NOT NULL,
	[curType] [tinyint] NOT NULL,
	[curChange] [smallint] NULL,
	[curCelling] [smallint] NULL,
	[curFloar] [smallint] NULL,
 CONSTRAINT [PK_tblCurrency] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomerInvoice]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomerInvoice](
	[invId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[invCstId] [int] NOT NULL,
	[invSupId] [int] NOT NULL,
	[invBrnId] [smallint] NOT NULL,
 CONSTRAINT [PK_tblCustomerInvoice] PRIMARY KEY CLUSTERED 
(
	[invId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomers]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomers](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[custNo] [int] NOT NULL,
	[custAccNo] [bigint] NOT NULL,
	[custAccName] [nvarchar](80) NOT NULL,
	[custName] [nvarchar](150) NOT NULL,
	[custPhnNo] [nvarchar](15) NULL,
	[custCountry] [nvarchar](50) NULL,
	[custCity] [nvarchar](25) NULL,
	[custAddress] [nvarchar](100) NULL,
	[custEmail] [varchar](40) NULL,
	[custCellingCredit] [bigint] NULL,
	[custCurrency] [tinyint] NULL,
	[custSalePrice] [tinyint] NULL,
	[custTaxNo] [nvarchar](20) NULL,
	[custBrnId] [smallint] NULL,
	[custStatus] [tinyint] NOT NULL,
	[custNameEn] [nvarchar](80) NULL,
	[custCountryEn] [nvarchar](50) NULL,
	[custCityEn] [nvarchar](50) NULL,
	[custAddressEn] [nvarchar](100) NULL,
	[CommercialRegister] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[cusBankId] [smallint] NULL,
	[cusAddNo] [nvarchar](20) NULL,
	[cusBuildingNo] [nvarchar](20) NULL,
	[cusAnotherID] [nvarchar](50) NULL,
	[cusDistrict] [nvarchar](30) NULL,
	[cusDistrictEn] [nvarchar](30) NULL,
 CONSTRAINT [PK_tblCustomers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDefaultAccount]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDefaultAccount](
	[dflId] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[dflAccNo] [int] NOT NULL,
	[dflStatus] [tinyint] NOT NULL,
	[dfltBrnId] [smallint] NOT NULL,
 CONSTRAINT [PK_tblDefaultAccount] PRIMARY KEY CLUSTERED 
(
	[dflId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDscntPermission]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDscntPermission](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[dscUsrId] [smallint] NOT NULL,
	[dscPercent] [tinyint] NOT NULL,
	[dscPermission] [bit] NOT NULL,
 CONSTRAINT [PK_tblDscntPermission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[empNo] [int] NOT NULL,
	[empAccNo] [bigint] NOT NULL,
	[empName] [nvarchar](50) NOT NULL,
	[empPhnNo] [varchar](15) NULL,
	[empSal] [float] NULL,
	[empCurrency] [tinyint] NULL,
	[empStatus] [tinyint] NOT NULL,
	[empBrnId] [smallint] NULL,
	[expirationInsurance] [date] NULL,
	[expirationResidence] [date] NULL,
	[reminderInsurance] [int] NULL,
	[reminderResidence] [int] NULL,
	[WorkStartDate] [date] NULL,
	[WorkEndDate] [date] NULL,
	[GenderType] [bit] NULL,
	[DepartmentID] [int] NULL,
	[GroupId] [int] NULL,
	[nationalid] [nvarchar](50) NULL,
	[insuranceNo] [nvarchar](50) NULL,
	[InsuranceDate] [datetime] NULL,
	[drivingLicense] [nvarchar](50) NULL,
	[endDate] [datetime] NULL,
	[bankName] [nvarchar](50) NULL,
	[accountNo] [nvarchar](50) NULL,
	[birthDate] [datetime] NULL,
	[birthPlace] [nvarchar](max) NULL,
	[Nationality] [nvarchar](50) NULL,
	[MaritalStatus] [nvarchar](50) NULL,
	[MilitarilyStatus] [nvarchar](50) NULL,
	[phoneFirst] [nvarchar](50) NULL,
	[emailFirst] [nvarchar](max) NULL,
	[addressFirst] [nvarchar](max) NULL,
	[fingerprintcode] [nvarchar](max) NULL,
	[shiftID] [int] NULL,
	[Jobid] [int] NULL,
	[abcenceregistionID] [int] NULL,
	[delayRegulationIDint] [int] NULL,
	[InsuranceValue] [float] NULL,
	[TransferAllowance] [float] NULL,
	[MealAllowance] [float] NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmployeePdf]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployeePdf](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empNo] [int] NOT NULL,
	[pathpdf] [nvarchar](max) NOT NULL,
	[titel] [nvarchar](max) NOT NULL,
	[descr] [nvarchar](max) NULL,
	[empdate] [datetime] NULL,
 CONSTRAINT [PK_tblEmployeePdf] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEntryMain]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEntryMain](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[entNo] [int] NOT NULL,
	[entBoxNo] [int] NULL,
	[entRefNo] [int] NULL,
	[entDate] [smalldatetime] NULL,
	[entDesc] [nvarchar](max) NULL,
	[entAmount] [float] NOT NULL,
	[entTotalTax] [float] NULL,
	[entCurrency] [tinyint] NULL,
	[entCurChange] [smallint] NULL,
	[entBrnId] [smallint] NULL,
	[entUserId] [smallint] NULL,
	[entStatus] [tinyint] NOT NULL,
	[entReverseConstraint] [nvarchar](max) NULL,
	[entReverseConstraintDate] [datetime] NULL,
 CONSTRAINT [PK_tblEntryMain] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEntrySub]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEntrySub](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[entNo] [int] NOT NULL,
	[entAccNo] [bigint] NULL,
	[entAccName] [nvarchar](max) NULL,
	[entBoxNo] [int] NULL,
	[entDesc] [nvarchar](max) NULL,
	[entDebit] [float] NULL,
	[entCredit] [float] NULL,
	[entDebitFrgn] [float] NULL,
	[entCreditFrgn] [float] NULL,
	[entTaxPercent] [tinyint] NULL,
	[entTaxPrice] [float] NULL,
	[entCurrency] [tinyint] NULL,
	[entCurChange] [smallint] NULL,
	[entCusNo] [int] NULL,
	[entCusName] [nvarchar](max) NULL,
	[entStatus] [tinyint] NULL,
	[entDate] [date] NULL,
	[entView] [tinyint] NULL,
	[entIsMain] [tinyint] NULL,
	[entEqfal] [tinyint] NULL,
	[entBrnId] [smallint] NULL,
	[entTaxNumber] [nvarchar](max) NULL,
	[invoNum] [nvarchar](max) NULL,
	[supplyName] [nvarchar](max) NULL,
	[entInvoDate] [date] NULL,
 CONSTRAINT [PK_tblEntrySub] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFinancialYear]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFinancialYear](
	[fyId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[fyName] [nvarchar](15) NOT NULL,
	[fyDateStart] [smalldatetime] NOT NULL,
	[fyDateEnd] [smalldatetime] NOT NULL,
	[fyBranchId] [smallint] NOT NULL,
	[fyStatus] [bit] NOT NULL,
	[fyIsNewYear] [bit] NOT NULL,
 CONSTRAINT [PK_tblFinancialYear] PRIMARY KEY CLUSTERED 
(
	[fyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGroupStr]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGroupStr](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[grpNo] [int] NOT NULL,
	[grpName] [nvarchar](50) NOT NULL,
	[grpAccNo] [bigint] NOT NULL,
	[grpCurrency] [tinyint] NOT NULL,
	[grpSalesAccNo] [bigint] NULL,
	[grpCostAccNo] [bigint] NULL,
	[grpDscntAccNo] [bigint] NULL,
	[grpSalesRtrnAccNo] [bigint] NULL,
	[grpCostRtrnAccNo] [bigint] NULL,
	[grpBrnId] [smallint] NULL,
	[grpStatus] [tinyint] NOT NULL,
	[grpPurchaseAccNo] [bigint] NULL,
	[grpPurchaseRtrnAccNo] [bigint] NULL,
 CONSTRAINT [PK_tblGroupStr] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblInvStoreMain]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInvStoreMain](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[invNo] [int] NOT NULL,
	[invStrId] [smallint] NOT NULL,
	[invDate] [smalldatetime] NOT NULL,
	[invBrnId] [smallint] NOT NULL,
	[invStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblInvStoreMain] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblInvStoreSub]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInvStoreSub](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[invMainId] [int] NOT NULL,
	[invBarcode] [nvarchar](50) NULL,
	[invPrdId] [int] NOT NULL,
	[invPrdMsurId] [int] NOT NULL,
	[invPrdGrpId] [int] NOT NULL,
	[invQuanStr] [float] NOT NULL,
	[invQuanAvl] [float] NOT NULL,
	[invQuanDefr] [float] NOT NULL,
	[invPriceAvrg] [float] NOT NULL,
	[invPriceDefr] [float] NOT NULL,
	[invPriceTotal] [float] NOT NULL,
	[invSalePrice] [float] NOT NULL,
	[invSalePriceTotal] [float] NOT NULL,
 CONSTRAINT [PK_tblInvStore] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNotification]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNotification](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[notSupId] [int] NOT NULL,
	[notEntId] [int] NULL,
	[notNo] [int] NULL,
	[notName] [nvarchar](max) NULL,
	[notDesc] [nvarchar](max) NULL,
	[notAmount] [float] NULL,
	[notAmountPaid] [float] NULL,
	[notDate] [date] NOT NULL,
	[notUsrId] [smallint] NOT NULL,
	[notBrnId] [smallint] NOT NULL,
	[notIsComplete] [bit] NOT NULL,
	[notStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblNotification] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrderMain]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrderMain](
	[ordId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ordNo] [int] NOT NULL,
	[ordDesc] [nvarchar](100) NULL,
	[ordDate] [smalldatetime] NOT NULL,
	[ordBrnId] [smallint] NOT NULL,
	[ordUsrId] [smallint] NOT NULL,
	[ordStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblOrderMain] PRIMARY KEY CLUSTERED 
(
	[ordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrderSub]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrderSub](
	[ordId] [int] IDENTITY(1,1) NOT NULL,
	[ordMainId] [int] NOT NULL,
	[ordPrdId] [int] NOT NULL,
	[ordMsurId] [int] NOT NULL,
	[ordPrdBarcode] [varchar](30) NULL,
	[ordQuantity] [float] NOT NULL,
	[ordDesc] [nvarchar](max) NULL,
	[ordNote] [nvarchar](max) NULL,
	[ordDate] [date] NOT NULL,
	[ordBrnId] [smallint] NOT NULL,
	[ordStatus] [tinyint] NOT NULL,
	[ordPrice] [float] NULL,
	[ordPriceSale] [float] NULL,
	[ordTaxPercent] [tinyint] NULL,
	[ordTax] [float] NULL,
	[ordTotal] [float] NULL,
 CONSTRAINT [PK_tblOrderSub] PRIMARY KEY CLUSTERED 
(
	[ordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPrdExpirate]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPrdExpirate](
	[expId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[expSupMainId] [int] NOT NULL,
	[expSupSubId] [int] NOT NULL,
	[expPrdPrcQuanId] [int] NOT NULL,
	[expPrdId] [int] NOT NULL,
	[expPrdMsurId] [int] NOT NULL,
	[expPrdMsurStatus] [tinyint] NOT NULL,
	[expSupNo] [int] NOT NULL,
	[expQuan] [float] NOT NULL,
	[expPrdDate] [date] NOT NULL,
	[expDate] [date] NOT NULL,
	[expBrnId] [smallint] NOT NULL,
	[expStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblPrdExpirate] PRIMARY KEY CLUSTERED 
(
	[expId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPrdExpirateQuan]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPrdExpirateQuan](
	[expId] [int] IDENTITY(1,1) NOT NULL,
	[expPrdId] [int] NOT NULL,
	[expPrdMsurId] [int] NOT NULL,
	[expPrdMsurStatus] [tinyint] NOT NULL,
	[expPrdPriceQuanId] [int] NOT NULL,
	[expPrdPrice] [float] NOT NULL,
	[expQuan] [float] NOT NULL,
	[expPrdDate] [date] NOT NULL,
	[expDate] [date] NOT NULL,
	[expBrnId] [smallint] NOT NULL,
	[expStatus] [tinyint] NOT NULL,
	[expStrid] [smallint] NOT NULL,
	[expMainId] [int] NULL,
 CONSTRAINT [PK_tblExpirateQuan] PRIMARY KEY CLUSTERED 
(
	[expId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPrdexpirateQuanMain]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPrdexpirateQuanMain](
	[expMainId] [int] IDENTITY(1,1) NOT NULL,
	[expMainStrid] [smallint] NOT NULL,
	[expMainDate] [date] NOT NULL,
	[expMainBrnId] [smallint] NOT NULL,
	[expMainUserId] [smallint] NULL,
 CONSTRAINT [PK_tblexpMainirateQuan] PRIMARY KEY CLUSTERED 
(
	[expMainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPrdManufacture]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPrdManufacture](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[manPrdId] [int] NOT NULL,
	[manPrdSubId] [int] NOT NULL,
	[manPrdMsurId] [int] NOT NULL,
	[manQuan] [float] NOT NULL,
 CONSTRAINT [PK_tblPrdManufacture] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPrdPriceMeasurment]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPrdPriceMeasurment](
	[ppmId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ppmMsurName] [nvarchar](30) NULL,
	[ppmPrice] [float] NULL,
	[ppmSalePrice] [float] NULL,
	[ppmMinSalePrice] [float] NULL,
	[ppmRetailPrice] [float] NULL,
	[ppmBatchPrice] [float] NULL,
	[ppmBarcode1] [nvarchar](30) NULL,
	[ppmBarcode2] [nvarchar](30) NULL,
	[ppmBarcode3] [nvarchar](30) NULL,
	[ppmConversion] [float] NULL,
	[ppmDefault] [bit] NOT NULL,
	[ppmPrdId] [int] NOT NULL,
	[ppmWeight] [bit] NOT NULL,
	[ppmBrnId] [smallint] NULL,
	[ppmStatus] [tinyint] NOT NULL,
	[ppmManufacture] [bit] NOT NULL,
 CONSTRAINT [PK_tblPrdPriceMeasurment] PRIMARY KEY CLUSTERED 
(
	[ppmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPrdPriceQuan]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPrdPriceQuan](
	[prId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[prPrdId] [int] NOT NULL,
	[pr1] [float] NOT NULL,
	[pr2] [float] NOT NULL,
	[pr3] [float] NOT NULL,
	[prQuantity1] [float] NOT NULL,
	[prQuantity2] [float] NOT NULL,
	[prQuantity3] [float] NOT NULL,
	[prdBrnId] [smallint] NULL,
	[prStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tblProductPrice] PRIMARY KEY CLUSTERED 
(
	[prId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prdNo] [nvarchar](max) NOT NULL,
	[prdName] [nvarchar](max) NOT NULL,
	[prdNameEng] [varchar](max) NULL,
	[prdGrpNo] [int] NOT NULL,
	[prdDesc] [nvarchar](max) NULL,
	[prdSaleTax] [bit] NOT NULL,
	[prdBrnId] [smallint] NULL,
	[prdStatus] [tinyint] NOT NULL,
	[prdPriceTax] [bit] NOT NULL,
	[ReorderLevel] [float] NOT NULL,
	[MaxLevel] [float] NOT NULL,
	[prdPurchaseTax] [bit] NOT NULL,
	[Suspended] [bit] NOT NULL,
 CONSTRAINT [PK_colid] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProductColor]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductColor](
	[colId] [tinyint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[colQuan] [smallint] NOT NULL,
	[colHtml] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tblProductColor] PRIMARY KEY CLUSTERED 
(
	[colId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProductPriceOffers]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductPriceOffers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [float] NULL,
	[Price] [float] NULL,
	[ActiveShow] [bit] NULL,
	[Notes] [nvarchar](max) NULL,
	[ExpireDate] [datetime] NULL,
	[StartDate] [datetime] NULL,
	[Date] [datetime] NULL,
	[State] [int] NULL,
	[DiscountType] [int] NULL,
	[TotalFatora] [float] NULL,
	[DiscountName] [nvarchar](100) NULL,
	[StateName] [nvarchar](100) NULL,
	[CustmerStartDate] [datetime] NULL,
	[CustmerEndDate] [datetime] NULL,
	[ShowName] [nvarchar](100) NULL,
	[prdNo] [nvarchar](15) NULL,
 CONSTRAINT [PK_tblProductPriceOffers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProductQtyOpn]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductQtyOpn](
	[qtyId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[qtyPrdId] [int] NOT NULL,
	[qtyPrdMsurId] [int] NOT NULL,
	[qtyPrice] [float] NOT NULL,
	[qtyQuantity] [float] NOT NULL,
	[qtyDate] [datetime] NOT NULL,
	[qtyBranchId] [smallint] NOT NULL,
	[qtyStatus] [tinyint] NOT NULL,
	[qtyStrId] [smallint] NOT NULL,
	[qtyExpireDate] [datetime] NULL,
 CONSTRAINT [PK_tblProductQtyOpn] PRIMARY KEY CLUSTERED 
(
	[qtyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProductQunatity]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductQunatity](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[prdId] [int] NOT NULL,
	[prdQuantity] [float] NULL,
	[prdSubQuantity] [float] NULL,
	[prdSubQuantity3] [float] NULL,
	[prdStrId] [smallint] NULL,
	[prdBrnId] [smallint] NULL,
	[prdStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblProductQunatity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRepresentative]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRepresentative](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[repNo] [int] NOT NULL,
	[repName] [nvarchar](50) NOT NULL,
	[repAccNo] [bigint] NOT NULL,
	[repCurrency] [tinyint] NOT NULL,
	[repPhnNo] [nvarchar](15) NULL,
	[repAddress] [nvarchar](50) NULL,
	[repEmail] [varchar](50) NULL,
	[repBrnId] [smallint] NOT NULL,
	[repStatus] [tinyint] NOT NULL,
	[repPassword] [nvarchar](50) NULL,
	[repMainName] [nvarchar](50) NULL,
	[repEnble] [bit] NULL,
	[repMemo] [nvarchar](max) NULL,
	[repRate] [nvarchar](10) NULL,
	[repMobail] [nvarchar](50) NULL,
	[repTypeRete] [bit] NULL,
	[repValuRate] [nvarchar](10) NULL,
 CONSTRAINT [PK_tblRepresentative] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRepresentativeStore]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRepresentativeStore](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RepId] [int] NULL,
	[StoreId] [int] NULL,
	[ProudctName] [nvarchar](max) NULL,
	[repPrice] [float] NULL,
	[repQuntity] [int] NULL,
	[ProudctNo] [int] NULL,
	[barcode] [nvarchar](max) NULL,
	[RepName] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblRepresentativeStore] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRole]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRole](
	[rolId] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[rolName] [nvarchar](30) NOT NULL,
	[rolStatus] [tinyint] NULL,
 CONSTRAINT [PK_tblRole] PRIMARY KEY CLUSTERED 
(
	[rolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRoleControl]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRoleControl](
	[rcId] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[fkRoleId] [smallint] NOT NULL,
	[fkucNo] [tinyint] NOT NULL,
	[fkControlId] [smallint] NOT NULL,
 CONSTRAINT [PK_tblRoleControl] PRIMARY KEY CLUSTERED 
(
	[rcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSetting]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSetting](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[supplyA4CustomRprt] [bit] NOT NULL,
	[supplyCashierCustomRprt] [bit] NOT NULL,
	[teReportVocherCustom] [bit] NOT NULL,
	[teReportReciptCustom] [bit] NOT NULL,
	[teReportEntryCustom] [bit] NOT NULL,
	[showRprtPurchaseHeader] [bit] NOT NULL,
	[showRprtSaleHeader] [bit] NOT NULL,
	[rprtOrderA4CustomRpt] [bit] NOT NULL,
	[supplyRetuA4CustomRprt] [bit] NOT NULL,
	[rprtSupplyCustomType] [tinyint] NOT NULL,
	[MachineName] [nvarchar](max) NULL,
	[IsInvoiceRound] [bit] NOT NULL,
	[showPrdQtyMssg] [bit] NOT NULL,
	[PayPartInvoValue] [bit] NOT NULL,
	[isSendToECR] [bit] NOT NULL,
	[ecrPort] [nvarchar](max) NULL,
	[GroupProductsInInvoices] [bit] NOT NULL,
	[defaultPrintOnSave] [bit] NOT NULL,
	[ShowPrintMssg] [bit] NOT NULL,
	[GroupWeightProdInInvoices] [bit] NOT NULL,
	[ShowResetMssg] [bit] NOT NULL,
	[defaultPrinterSettings] [nvarchar](max) NULL,
	[defaultSalePriceFloar] [bit] NOT NULL,
	[defaultBox] [bigint] NOT NULL,
	[defaultBank] [smallint] NOT NULL,
	[AllowSaveInvoInBeforeDate] [bit] NOT NULL,
	[printA4] [tinyint] NOT NULL,
	[defaultStrId] [smallint] NOT NULL,
	[ReadFormScaleBarcode] [bit] NOT NULL,
	[BarcodeLength] [tinyint] NOT NULL,
	[ScaleBarcodePrefix] [nvarchar](max) NULL,
	[ProductCodeLength] [tinyint] NOT NULL,
	[ValueCodeLength] [tinyint] NOT NULL,
	[ReadMode] [tinyint] NOT NULL,
	[IgnoreCheckDigit] [bit] NOT NULL,
	[DivideValueBy] [smallint] NOT NULL,
	[defaultPrinterBarcode] [nvarchar](max) NULL,
	[prdPriceTax] [bit] NOT NULL,
	[supPrdLastPrice] [bit] NOT NULL,
	[tsDefaultSalePriceAndBuy] [smallint] NOT NULL,
	[autoSupplyTarhel] [bit] NOT NULL,
	[ShowlayoutControlCarData] [bit] NOT NULL,
	[TaxReadMode] [bit] NOT NULL,
	[InvType] [bit] NOT NULL,
	[dfltAccLevel] [tinyint] NOT NULL,
	[WelcomeMessage] [nvarchar](max) NULL,
	[BranchID] [smallint] NOT NULL,
	[ordersPrintPreview] [bit] NOT NULL,
	[ordersShowPrintMssg] [bit] NOT NULL,
	[ordersPrinter] [nvarchar](max) NULL,
	[ordersVoucherStr] [nvarchar](max) NULL,
	[ordersExecuteStr] [nvarchar](max) NULL,
	[ordersReceiptStr] [nvarchar](max) NULL,
	[ordersVoucherStrPlu] [nvarchar](max) NULL,
	[ordersExecuteStrPlu] [nvarchar](max) NULL,
	[ordersReceiptStrPlu] [nvarchar](max) NULL,
	[CalcTaxAfterDiscount] [bit] NOT NULL,
	[AutoBarcode] [bit] NOT NULL,
	[UserDrawerPeriods] [bit] NULL,
 CONSTRAINT [PK_tblSetting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStockTransMain]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStockTransMain](
	[stcId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[stcNo] [int] NOT NULL,
	[stcRefNo] [int] NULL,
	[stcStrIdFrom] [smallint] NOT NULL,
	[stcStrIdTo] [smallint] NOT NULL,
	[stcDesc] [nvarchar](100) NULL,
	[stcDate] [smalldatetime] NOT NULL,
	[stcBrnId] [smallint] NOT NULL,
	[stcUserId] [smallint] NOT NULL,
 CONSTRAINT [PK_tblStockTransMain] PRIMARY KEY CLUSTERED 
(
	[stcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStockTransSub]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStockTransSub](
	[stcId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[stcMainId] [int] NOT NULL,
	[stcPrdId] [int] NOT NULL,
	[stcMsurId] [int] NOT NULL,
	[stcQuantity] [float] NOT NULL,
	[stcDate] [date] NOT NULL,
	[stcBrnId] [smallint] NOT NULL,
 CONSTRAINT [PK_tblStockTransSub] PRIMARY KEY CLUSTERED 
(
	[stcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStore]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStore](
	[id] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[strNo] [smallint] NOT NULL,
	[strName] [nvarchar](50) NOT NULL,
	[strPhnNo] [varchar](15) NULL,
	[strBrnId] [smallint] NULL,
	[strStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblStore] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSupplier]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSupplier](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[splNo] [int] NOT NULL,
	[splAccNo] [bigint] NOT NULL,
	[splName] [nvarchar](50) NULL,
	[splPhnNo] [nvarchar](15) NULL,
	[splCountry] [nvarchar](50) NULL,
	[splCity] [nvarchar](25) NULL,
	[splAddress] [nvarchar](100) NULL,
	[splEmail] [varchar](40) NULL,
	[splTaxNo] [nvarchar](20) NULL,
	[splCurrency] [tinyint] NULL,
	[splBrnId] [smallint] NULL,
	[splStatus] [tinyint] NULL,
 CONSTRAINT [PK_tblSupplier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSupplierInvoice]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSupplierInvoice](
	[invId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[invSplId] [int] NOT NULL,
	[invSupId] [int] NOT NULL,
	[invBrnId] [smallint] NOT NULL,
 CONSTRAINT [PK_tblSupplierInvoice] PRIMARY KEY CLUSTERED 
(
	[invId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSupplyMain]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSupplyMain](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[supNo] [int] NOT NULL,
	[supAccNo] [bigint] NULL,
	[supAccName] [nvarchar](max) NULL,
	[supRefNo] [nvarchar](max) NULL,
	[supDesc] [nvarchar](max) NULL,
	[supTotal] [float] NOT NULL,
	[supTotalFrgn] [float] NULL,
	[supTaxPercent] [tinyint] NULL,
	[supTaxPrice] [float] NULL,
	[supCurrency] [tinyint] NULL,
	[supDscntPercent] [float] NULL,
	[supDscntAmount] [float] NULL,
	[supBankId] [smallint] NULL,
	[supBankAmount] [float] NULL,
	[supCurrencyChng] [smallint] NULL,
	[supCustSplId] [int] NULL,
	[supDate] [smalldatetime] NULL,
	[supIsCash] [tinyint] NULL,
	[supEqfal] [tinyint] NULL,
	[supStrId] [smallint] NULL,
	[supUserId] [smallint] NOT NULL,
	[supBrnId] [smallint] NULL,
	[supStatus] [tinyint] NOT NULL,
	[supDscntAmountٌRound] [float] NOT NULL,
	[CarType] [nvarchar](max) NULL,
	[PlateNumber] [nvarchar](max) NULL,
	[CounterNumber] [nvarchar](max) NULL,
	[SendToserver] [bit] NULL,
	[IsDelete] [bit] NOT NULL,
	[paidCash] [float] NULL,
	[remin] [float] NULL,
	[supBoxId] [smallint] NULL,
	[PoNumber] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[DueDate] [datetime] NULL,
	[EnterDate] [datetime] NULL,
	[MainNo] [int] NULL,
	[repName] [int] NULL,
	[commission] [float] NULL,
	[TotalAfterDiscount] [float] NULL,
	[net]  AS ((([supTotal]-isnull([supDscntAmount],(0)))*isnull([supTaxPercent],(0)))/(100)+[supTotal]),
 CONSTRAINT [PK_tblSupplyMain] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSupplySub]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSupplySub](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supNo] [int] NOT NULL,
	[supAccNo] [bigint] NOT NULL,
	[supAccName] [nvarchar](max) NOT NULL,
	[supDesc] [nvarchar](max) NULL,
	[supPrdBarcode] [nvarchar](max) NULL,
	[supPrdNo] [nvarchar](max) NULL,
	[supPrdName] [nvarchar](max) NULL,
	[supPrdId] [int] NULL,
	[supMsur] [int] NULL,
	[supCurrency] [tinyint] NULL,
	[supQuanMain] [float] NULL,
	[supPrice] [float] NULL,
	[supSalePrice] [float] NULL,
	[supTaxPercent] [tinyint] NULL,
	[supTaxPrice] [float] NULL,
	[supDscntPercent] [float] NULL,
	[supDscntAmount] [float] NULL,
	[supDebit] [float] NULL,
	[supCredit] [float] NULL,
	[supDebitFrgn] [float] NULL,
	[supCreditFrgn] [float] NULL,
	[supDate] [datetime] NOT NULL,
	[supBrnId] [smallint] NULL,
	[supUserId] [smallint] NULL,
	[supStatus] [tinyint] NOT NULL,
	[supPrdManufacture] [bit] NOT NULL,
	[subQteMeter] [float] NULL,
	[subHeight] [float] NULL,
	[subWidth] [float] NULL,
	[subNoPacks] [int] NULL,
	[ExpireDate] [date] NULL,
	[supOvertime] [float] NULL,
	[supWorkingtime] [float] NULL,
	[StoreID] [smallint] NULL,
	[Conversion] [float] NOT NULL,
	[NumberDays] [float] NULL,
	[EquipmentNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblSupplySub] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTaxAccounts]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaxAccounts](
	[taxId] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[taxAccNo] [bigint] NULL,
	[taxAccName] [nvarchar](80) NULL,
	[taxStatus] [tinyint] NULL,
 CONSTRAINT [PK_tblTaxAccounts] PRIMARY KEY CLUSTERED 
(
	[taxId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[id] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[userName] [nvarchar](20) NULL,
	[userPass] [nvarchar](20) NULL,
	[PrinterName] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserBranch]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserBranch](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[usrId] [smallint] NOT NULL,
	[brnId] [smallint] NOT NULL,
 CONSTRAINT [PK_tblUserBranch] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserControl]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserControl](
	[ucId] [tinyint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ucNo] [tinyint] NOT NULL,
	[ucName] [nvarchar](max) NULL,
	[ucCaption] [nvarchar](max) NULL,
	[ucCaptionEn] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblUserControl] PRIMARY KEY CLUSTERED 
(
	[ucId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserRole]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserRole](
	[urId] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[fkUserId] [smallint] NOT NULL,
	[fkRoleId] [smallint] NOT NULL,
 CONSTRAINT [PK_tblUserRole] PRIMARY KEY CLUSTERED 
(
	[urId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[time_attendance] [time](7) NULL,
	[Time_leave] [time](7) NULL,
	[ShiftType] [bit] NULL,
	[ShiftId] [int] NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_DrawerRev]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_DrawerRev]
AS
SELECT     dbo.tblBranch.brnName, dbo.DrawerPeriods.DrawerID, dbo.DrawerPeriods.BranchID, dbo.tblCurrency.curName, dbo.DrawerPeriods.PeriodUserID, dbo.tblUser.userName, dbo.DrawerPeriods.PeriodStart, dbo.DrawerPeriods.PeriodEnd, dbo.DrawerPeriods.OpeningBalance, 
                  dbo.DrawerPeriods.ClosingBalance, dbo.DrawerPeriods.ActualBalance, dbo.DrawerPeriods.DifferenceAccountID, dbo.DrawerPeriods.ClosingPeriodUserID, dbo.DrawerPeriods.ClosingDrwerID, dbo.DrawerPeriods.TransferdBalance, dbo.DrawerPeriods.RemainingBalance, 
                  dbo.DrawerPeriods.totalSupSccBank, dbo.DrawerPeriods.Status
FROM        dbo.DrawerPeriods INNER JOIN
                  dbo.tblBranch ON dbo.DrawerPeriods.BranchID = dbo.tblBranch.brnId INNER JOIN
                  dbo.tblCurrency ON dbo.DrawerPeriods.DrawerID = dbo.tblCurrency.id INNER JOIN
                  dbo.tblUser ON dbo.DrawerPeriods.PeriodUserID = dbo.tblUser.id
GO
/****** Object:  View [dbo].[View_FixedAssets]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_FixedAssets]
AS
SELECT     dbo.FixedAssets.id, dbo.FixedAssets.assetsName, dbo.FixedAssets.assetsNameE, dbo.FixedAssets.PurchaseValue, dbo.FixedAssets.datePurchase, dbo.FixedAssets.Notes, dbo.FixedAssets.stopAssets, dbo.FixedAssets.CreateImplicitSubAccount, dbo.FixedAssets.originalAccount, 
                  dbo.FixedAssets.DepreciationAccount, dbo.FixedAssets.currency, dbo.FixedAssets.equalizer, dbo.FixedAssets.DepreciationRate, dbo.FixedAssets.currentValue, dbo.FixedAssets.originalPhoto, dbo.FixedAssets.DepreciationDay, dbo.FixedAssets.CountDay, 
                  dbo.FixedAssets.DepreciationNow, dbo.FixedAssets.DepreciationYeer, dbo.AssetAccount.AssetName, dbo.AssetAccount.AssetNameE, dbo.DepreciationAccount.DepreciationNameE, dbo.DepreciationAccount.DepreciationName, dbo.tblCurrency.curName
FROM        dbo.DepreciationAccount INNER JOIN
                  dbo.FixedAssets ON dbo.DepreciationAccount.id = dbo.FixedAssets.DepreciationAccount INNER JOIN
                  dbo.AssetAccount ON dbo.FixedAssets.originalAccount = dbo.AssetAccount.id INNER JOIN
                  dbo.tblCurrency ON dbo.FixedAssets.currency = dbo.tblCurrency.id
GO
/****** Object:  View [dbo].[View_profit]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_profit]
AS
SELECT     dbo.tblSupplyMain.supNo, dbo.tblSupplyMain.supCurrency, dbo.tblSupplyMain.supAccName, dbo.tblSupplyMain.supTotal, dbo.tblSupplyMain.supTaxPrice, dbo.tblSupplyMain.supDate, dbo.tblSupplyMain.repName, dbo.tblRepresentative.repRate, dbo.tblRepresentative.repMobail, 
                  dbo.tblRepresentative.repEnble, dbo.tblRepresentative.repCurrency, dbo.tblRepresentative.repAccNo, dbo.tblRepresentative.repNo, dbo.tblRepresentative.repMainName, dbo.tblSupplyMain.commission, dbo.tblCurrency.curName
FROM        dbo.tblSupplyMain INNER JOIN
                  dbo.tblRepresentative ON dbo.tblSupplyMain.repName = dbo.tblRepresentative.repName INNER JOIN
                  dbo.tblCurrency ON dbo.tblRepresentative.repCurrency = dbo.tblCurrency.id
GO
/****** Object:  View [dbo].[View_repComm]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_repComm]
AS
SELECT     dbo.RepCommission.DisplayName, dbo.RepCommission.commission, dbo.RepCommission.Notes, dbo.RepCommission.isActive, dbo.RepCommission.id AS idrepcom, dbo.tblProduct.prdName, dbo.tblStore.strName, dbo.tblRepresentative.repName, dbo.RepCommissionDetails.id, 
                  dbo.RepCommissionDetails.RepId, dbo.RepCommissionDetails.PrdId, dbo.RepCommissionDetails.RepCommission, dbo.RepCommissionDetails.StorId
FROM        dbo.RepCommission INNER JOIN
                  dbo.RepCommissionDetails ON dbo.RepCommission.id = dbo.RepCommissionDetails.RepCommission INNER JOIN
                  dbo.tblProduct ON dbo.RepCommissionDetails.PrdId = dbo.tblProduct.id INNER JOIN
                  dbo.tblStore ON dbo.RepCommissionDetails.StorId = dbo.tblStore.id INNER JOIN
                  dbo.tblRepresentative ON dbo.RepCommissionDetails.RepId = dbo.tblRepresentative.id
GO
/****** Object:  View [dbo].[View_repCommReport]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_repCommReport]
AS
SELECT     dbo.tblSupplyMain.supNo, dbo.tblSupplySub.supPrdName, dbo.tblSupplySub.supPrdId, dbo.tblSupplySub.supCurrency, dbo.tblSupplySub.supSalePrice, dbo.tblSupplySub.supQuanMain, dbo.tblCurrency.curName, dbo.tblSupplySub.supDate, dbo.RepCommissionDetails.PrdId, 
                  dbo.tblSupplyMain.supStatus, dbo.RepCommissionDetails.RepCommission, dbo.RepCommissionDetails.RepId
FROM        dbo.tblSupplyMain INNER JOIN
                  dbo.tblSupplySub ON dbo.tblSupplyMain.id = dbo.tblSupplySub.supNo INNER JOIN
                  dbo.tblCurrency ON dbo.tblSupplySub.supCurrency = dbo.tblCurrency.id INNER JOIN
                  dbo.RepCommissionDetails ON dbo.tblSupplySub.supPrdId = dbo.RepCommissionDetails.PrdId
WHERE     (dbo.tblSupplyMain.supStatus = 4) AND (dbo.RepCommissionDetails.RepCommission <> 0)
GO
/****** Object:  View [dbo].[View_unit]    Script Date: 20/01/2023 11:08:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_unit]
AS
SELECT     dbo.tblProduct.prdName, dbo.tblPrdPriceMeasurment.ppmMsurName, dbo.tblProduct.id, dbo.tblPrdPriceMeasurment.ppmId, dbo.tblPrdPriceMeasurment.ppmBarcode1, dbo.tblGroupStr.grpName
FROM        dbo.tblPrdPriceMeasurment INNER JOIN
                  dbo.tblProduct ON dbo.tblPrdPriceMeasurment.ppmPrdId = dbo.tblProduct.id INNER JOIN
                  dbo.tblGroupStr ON dbo.tblProduct.prdBrnId = dbo.tblGroupStr.id
WHERE     (dbo.tblPrdPriceMeasurment.ppmMsurName = N'حبة') OR
                  (dbo.tblPrdPriceMeasurment.ppmMsurName = N'حبه')
GO
SET IDENTITY_INSERT [dbo].[BarcodeTemplates] ON 

INSERT [dbo].[BarcodeTemplates] ([ID], [Name], [Template], [IsDefault]) VALUES (40, N'نموذج A4 4*6', 0x2F2F2F203C585254797065496E666F3E0D0A2F2F2F2020203C417373656D626C7946756C6C4E616D653E4163636F756E74696E674D532C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C3C2F417373656D626C7946756C6C4E616D653E0D0A2F2F2F2020203C417373656D626C794C6F636174696F6E3E433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4163636F756E74696E674D532E6578653C2F417373656D626C794C6F636174696F6E3E0D0A2F2F2F2020203C547970654E616D653E4163636F756E74696E674D532E5265706F7274732E7274705F426172636F64653C2F547970654E616D653E0D0A2F2F2F2020203C4C6F63616C697A6174696F6E3E61723C2F4C6F63616C697A6174696F6E3E0D0A2F2F2F2020203C56657273696F6E3E31392E323C2F56657273696F6E3E0D0A2F2F2F2020203C5265666572656E6365733E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4163636F756E74696E674D532E65786522202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C6C6F67346E65742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6E66696775726174696F6E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E436F6E66696775726174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F72655C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4E756D65726963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E4E756D65726963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174615C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5472616E73616374696F6E735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E5472616E73616374696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E456E746572707269736553657276696365735C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E456E746572707269736553657276696365732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E43616368696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E52756E74696D652E43616368696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5765625C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E5765622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E57696E646F77732E466F726D735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E57696E646F77732E466F726D732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4163636573736962696C6974795C76342E305F342E302E302E305F5F623033663566376631316435306133615C4163636573736962696C6974792E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174612E4F7261636C65436C69656E745C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4F7261636C65436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E672E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C55494175746F6D6174696F6E436C69656E745C76342E305F342E302E302E305F5F333162663338353661643336346533355C55494175746F6D6174696F6E436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C57696E646F7773426173655C76342E305F342E302E302E305F5F333162663338353661643336346533355C57696E646F7773426173652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E58616D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E58616D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C50726573656E746174696F6E436F72655C76342E305F342E302E302E305F5F333162663338353661643336346533355C50726573656E746174696F6E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614C61796F75742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614C61796F75742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261456469746F72732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261456469746F72732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E446174612E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E53657269616C697A6174696F6E5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E52756E74696D652E53657269616C697A6174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C2E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615072696E74696E672E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615072696E74696E672E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261426172732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261426172732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261547265654C6973742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261547265654C6973742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446F63732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446F63732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C456E746974794672616D65776F726B2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4D6963726F736F66742E4353686172705C76342E305F342E302E302E305F5F623033663566376631316435306133615C4D6963726F736F66742E4353686172702E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44796E616D69635C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44796E616D69632E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C426172636F64654C69622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E735C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261566572746963616C477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261566572746963616C477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446174614163636573732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446174614163636573732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614E61764261722E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614E61764261722E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E57697A6172645C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E57697A6172642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4D6963726F736F66742E53716C5365727665722E536D6F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4D6963726F736F66742E53716C5365727665722E436F6E6E656374696F6E496E666F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4D6963726F736F66742E53716C5365727665722E536D6F457874656E6465642E646C6C22202F3E0D0A2F2F2F2020203C2F5265666572656E6365733E0D0A2F2F2F2020203C5265736F75726365733E0D0A2F2F2F20202020203C5265736F75726365204E616D653D22587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F6465223E0D0A2F2F2F207A73727676674541414143524141414162464E356333526C625335535A584E7664584A6A5A584D75556D567A62335679593256535A57466B5A5849734947317A5932397962476C694C4342575A584A7A61573975505451754D4334774C6A417349454E3162485231636D5539626D563164484A68624377675548566962476C6A53325635564739725A573439596A63335954566A4E5459784F544D305A5441344F534E5465584E305A573075556D567A623356795932567A4C6C4A31626E5270625756535A584E7664584A6A5A564E6C64414941414141414141414141414141414642425246424252464330414141413C2F5265736F757263653E0D0A2F2F2F2020203C2F5265736F75726365733E0D0A2F2F2F203C2F585254797065496E666F3E0D0A6E616D65737061636520587472615265706F727453657269616C697A6174696F6E207B0D0A202020200D0A202020207075626C696320636C617373207274705F426172636F6465203A20446576457870726573732E587472615265706F7274732E55492E587472615265706F7274207B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6420746F704D617267696E42616E64313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7820787250696374757265426F78313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250616E656C20787250616E656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E44657461696C42616E642044657461696C3B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6420626F74746F6D4D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572205F7265736F75726365733B0D0A20202020202020207072697661746520737472696E67205F7265736F75726365537472696E673B0D0A20202020202020207075626C6963207274705F426172636F64652829207B0D0A202020202020202020202020746869732E5F7265736F75726365537472696E67203D20446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E616765722E4765745265736F75726365466F722822587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F646522293B0D0A202020202020202020202020746869732E496E697469616C697A65436F6D706F6E656E7428293B0D0A20202020202020207D0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572207265736F7572636573207B0D0A202020202020202020202020676574207B0D0A20202020202020202020202020202020696620285F7265736F7572636573203D3D206E756C6C29207B0D0A2020202020202020202020202020202020202020746869732E5F7265736F7572636573203D206E657720446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E6167657228746869732E5F7265736F75726365537472696E67293B0D0A202020202020202020202020202020207D0D0A2020202020202020202020202020202072657475726E20746869732E5F7265736F75726365733B0D0A2020202020202020202020207D0D0A20202020202020207D0D0A20202020202020207072697661746520766F696420496E697469616C697A65436F6D706F6E656E742829207B0D0A202020202020202020202020746869732E62696E64696E67536F7572636531203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E78724C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E78724C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E746F704D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6428293B0D0A202020202020202020202020746869732E787250696374757265426F7831203D206E657720446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7828293B0D0A202020202020202020202020746869732E78724C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E787250616E656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E585250616E656C28293B0D0A202020202020202020202020746869732E44657461696C203D206E657720446576457870726573732E587472615265706F7274732E55492E44657461696C42616E6428293B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6428293B0D0A202020202020202020202020746869732E6C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E426567696E496E697428293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365312E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B436F6D70616E794E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C20342E303239323734452D303546293B0D0A202020202020202020202020746869732E78724C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C312E4E616D65203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283437302E34393939462C2034352E313930383346293B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E54657874203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726963655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C2039302E333831373146293B0D0A202020202020202020202020746869732E78724C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C332E4E616D65203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283437302E34393939462C2034352E313930383646293B0D0A202020202020202020202020746869732E78724C6162656C332E54657874203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7052696768743B0D0A202020202020202020202020746869732E78724C6162656C332E54657874466F726D6174537472696E67203D20227B303A24302E30307D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20746F704D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E746F704D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E4E616D65203D2022746F704D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250696374757265426F78310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250696374757265426F78312E447069203D20323534463B0D0A202020202020202020202020746869732E787250696374757265426F78312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C2022496D616765536F75726365222C20225B426172636F6465496D6167655D22297D293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742831392E3438353937462C203133352E3537323546293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4E616D65203D2022787250696374757265426F7831223B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A696E67203D20446576457870726573732E587472615072696E74696E672E496D61676553697A654D6F64652E4175746F53697A653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C322E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726F647563744E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C322E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C322E4E616D65203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283437302E34393939462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E54657874203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250616E656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250616E656C312E416E63686F72486F72697A6F6E74616C203D202828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E4C656674207C20446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E52696768742929293B0D0A202020202020202020202020746869732E787250616E656C312E416E63686F72566572746963616C203D202828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E546F70207C20446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E426F74746F6D2929293B0D0A202020202020202020202020746869732E787250616E656C312E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E787250616E656C312E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E787250616E656C312E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C312C0D0A202020202020202020202020202020202020202020202020746869732E787250696374757265426F78312C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C317D293B0D0A202020202020202020202020746869732E787250616E656C312E447069203D20323534463B0D0A202020202020202020202020746869732E787250616E656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C20312E343639393146293B0D0A202020202020202020202020746869732E787250616E656C312E4E616D65203D2022787250616E656C31223B0D0A202020202020202020202020746869732E787250616E656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283437302E34393939462C203339372E3036303246293B0D0A202020202020202020202020746869732E787250616E656C312E536E61704C696E6550616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2044657461696C0D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E44657461696C2E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E44657461696C2E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E44657461696C2E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250616E656C317D293B0D0A202020202020202020202020746869732E44657461696C2E447069203D20323534463B0D0A202020202020202020202020746869732E44657461696C2E48656967687446203D20343030463B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F676574686572203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F6765746865725769746844657461696C5265706F727473203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E436F756E74203D20343B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E53706163696E67203D2036463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E5769647468203D20363030463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4C61796F7574203D20446576457870726573732E587472615072696E74696E672E436F6C756D6E4C61796F75742E4163726F73735468656E446F776E3B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4D6F6465203D20446576457870726573732E587472615265706F7274732E55492E4D756C7469436F6C756D6E4D6F64652E557365436F6C756D6E436F756E743B0D0A202020202020202020202020746869732E44657461696C2E4E616D65203D202244657461696C223B0D0A202020202020202020202020746869732E44657461696C2E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F704C6566743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20626F74746F6D4D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E4E616D65203D2022626F74746F6D4D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B4E6F7465735D22297D293B0D0A202020202020202020202020746869732E6C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C203230392E3136323846293B0D0A202020202020202020202020746869732E6C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C312E4E616D65203D20226C6162656C31223B0D0A202020202020202020202020746869732E6C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283437302E34393939462C203130302E3735333346293B0D0A202020202020202020202020746869732E6C6162656C312E54657874203D20226C6162656C31223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F207274705F426172636F64650D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E42616E64732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E42616E645B5D207B0D0A202020202020202020202020202020202020202020202020746869732E44657461696C2C0D0A202020202020202020202020202020202020202020202020746869732E746F704D617267696E42616E64312C0D0A202020202020202020202020202020202020202020202020746869732E626F74746F6D4D617267696E42616E64317D293B0D0A202020202020202020202020746869732E426F726465725769647468203D2030463B0D0A202020202020202020202020746869732E436F6D706F6E656E7453746F726167652E41646452616E6765286E65772053797374656D2E436F6D706F6E656E744D6F64656C2E49436F6D706F6E656E745B5D207B0D0A202020202020202020202020202020202020202020202020746869732E62696E64696E67536F75726365317D293B0D0A202020202020202020202020746869732E447069203D20323534463B0D0A202020202020202020202020746869732E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E373546293B0D0A202020202020202020202020746869732E4D617267696E73203D206E65772053797374656D2E44726177696E672E5072696E74696E672E4D617267696E732835302C2035302C203130302C20313030293B0D0A202020202020202020202020746869732E4E616D65203D20227274705F426172636F6465223B0D0A202020202020202020202020746869732E50616765486569676874203D20323937303B0D0A202020202020202020202020746869732E506167655769647468203D20323130303B0D0A202020202020202020202020746869732E50617065724B696E64203D2053797374656D2E44726177696E672E5072696E74696E672E50617065724B696E642E41343B0D0A202020202020202020202020746869732E5265706F72745072696E744F7074696F6E732E44657461696C436F756E744F6E456D70747944617461536F75726365203D203134343B0D0A202020202020202020202020746869732E5265706F7274556E6974203D20446576457870726573732E587472615265706F7274732E55492E5265706F7274556E69742E54656E7468734F66414D696C6C696D657465723B0D0A202020202020202020202020746869732E53686F775072696E744D617267696E735761726E696E67203D2066616C73653B0D0A202020202020202020202020746869732E536E61704772696453697A65203D2033312E3735463B0D0A202020202020202020202020746869732E56657273696F6E203D202231392E32223B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E456E64496E697428293B0D0A20202020202020207D0D0A202020207D0D0A7D0D0A, 0)
INSERT [dbo].[BarcodeTemplates] ([ID], [Name], [Template], [IsDefault]) VALUES (41, N'نموذج 3*4  بدون ضريبه', 0x2F2F2F203C585254797065496E666F3E0D0A2F2F2F2020203C417373656D626C7946756C6C4E616D653E4163636F756E74696E674D532C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C3C2F417373656D626C7946756C6C4E616D653E0D0A2F2F2F2020203C417373656D626C794C6F636174696F6E3E433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4163636F756E74696E674D532E6578653C2F417373656D626C794C6F636174696F6E3E0D0A2F2F2F2020203C547970654E616D653E4163636F756E74696E674D532E5265706F7274732E7274705F426172636F64653C2F547970654E616D653E0D0A2F2F2F2020203C4C6F63616C697A6174696F6E3E61723C2F4C6F63616C697A6174696F6E3E0D0A2F2F2F2020203C56657273696F6E3E31392E323C2F56657273696F6E3E0D0A2F2F2F2020203C5265666572656E6365733E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4163636F756E74696E674D532E65786522202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C6C6F67346E65742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6E66696775726174696F6E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E436F6E66696775726174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F72655C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4E756D65726963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E4E756D65726963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174615C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5472616E73616374696F6E735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E5472616E73616374696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E456E746572707269736553657276696365735C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E456E746572707269736553657276696365732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E43616368696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E52756E74696D652E43616368696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5765625C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E5765622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E57696E646F77732E466F726D735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E57696E646F77732E466F726D732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4163636573736962696C6974795C76342E305F342E302E302E305F5F623033663566376631316435306133615C4163636573736962696C6974792E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174612E4F7261636C65436C69656E745C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4F7261636C65436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E672E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C55494175746F6D6174696F6E436C69656E745C76342E305F342E302E302E305F5F333162663338353661643336346533355C55494175746F6D6174696F6E436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C57696E646F7773426173655C76342E305F342E302E302E305F5F333162663338353661643336346533355C57696E646F7773426173652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E58616D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E58616D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C50726573656E746174696F6E436F72655C76342E305F342E302E302E305F5F333162663338353661643336346533355C50726573656E746174696F6E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614C61796F75742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614C61796F75742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261456469746F72732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261456469746F72732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E446174612E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E53657269616C697A6174696F6E5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E52756E74696D652E53657269616C697A6174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C2E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615072696E74696E672E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615072696E74696E672E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261426172732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261426172732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261547265654C6973742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261547265654C6973742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446F63732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446F63732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C456E746974794672616D65776F726B2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4D6963726F736F66742E4353686172705C76342E305F342E302E302E305F5F623033663566376631316435306133615C4D6963726F736F66742E4353686172702E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44796E616D69635C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44796E616D69632E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C426172636F64654C69622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E735C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261566572746963616C477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261566572746963616C477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446174614163636573732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446174614163636573732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614E61764261722E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614E61764261722E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E57697A6172645C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E57697A6172642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4D6963726F736F66742E53716C5365727665722E536D6F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4D6963726F736F66742E53716C5365727665722E436F6E6E656374696F6E496E666F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4D6963726F736F66742E53716C5365727665722E536D6F457874656E6465642E646C6C22202F3E0D0A2F2F2F2020203C2F5265666572656E6365733E0D0A2F2F2F2020203C5265736F75726365733E0D0A2F2F2F20202020203C5265736F75726365204E616D653D22587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F6465223E0D0A2F2F2F207A73727676674541414143524141414162464E356333526C625335535A584E7664584A6A5A584D75556D567A62335679593256535A57466B5A5849734947317A5932397962476C694C4342575A584A7A61573975505451754D4334774C6A417349454E3162485231636D5539626D563164484A68624377675548566962476C6A53325635564739725A573439596A63335954566A4E5459784F544D305A5441344F534E5465584E305A573075556D567A623356795932567A4C6C4A31626E5270625756535A584E7664584A6A5A564E6C64414941414141414141414141414141414642425246424252464330414141413C2F5265736F757263653E0D0A2F2F2F2020203C2F5265736F75726365733E0D0A2F2F2F203C2F585254797065496E666F3E0D0A6E616D65737061636520587472615265706F727453657269616C697A6174696F6E207B0D0A202020200D0A202020207075626C696320636C617373207274705F426172636F6465203A20446576457870726573732E587472615265706F7274732E55492E587472615265706F7274207B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E44657461696C42616E642044657461696C3B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250616E656C20787250616E656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7820787250696374757265426F78313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6420746F704D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6420626F74746F6D4D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572205F7265736F75726365733B0D0A20202020202020207072697661746520737472696E67205F7265736F75726365537472696E673B0D0A20202020202020207075626C6963207274705F426172636F64652829207B0D0A202020202020202020202020746869732E5F7265736F75726365537472696E67203D20446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E616765722E4765745265736F75726365466F722822587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F646522293B0D0A202020202020202020202020746869732E496E697469616C697A65436F6D706F6E656E7428293B0D0A20202020202020207D0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572207265736F7572636573207B0D0A202020202020202020202020676574207B0D0A20202020202020202020202020202020696620285F7265736F7572636573203D3D206E756C6C29207B0D0A2020202020202020202020202020202020202020746869732E5F7265736F7572636573203D206E657720446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E6167657228746869732E5F7265736F75726365537472696E67293B0D0A202020202020202020202020202020207D0D0A2020202020202020202020202020202072657475726E20746869732E5F7265736F75726365733B0D0A2020202020202020202020207D0D0A20202020202020207D0D0A20202020202020207072697661746520766F696420496E697469616C697A65436F6D706F6E656E742829207B0D0A202020202020202020202020746869732E44657461696C203D206E657720446576457870726573732E587472615265706F7274732E55492E44657461696C42616E6428293B0D0A202020202020202020202020746869732E78724C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E787250616E656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E585250616E656C28293B0D0A202020202020202020202020746869732E78724C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E746F704D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6428293B0D0A202020202020202020202020746869732E78724C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E787250696374757265426F7831203D206E657720446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7828293B0D0A202020202020202020202020746869732E62696E64696E67536F7572636531203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E426567696E496E697428293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2044657461696C0D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E44657461696C2E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E44657461696C2E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E44657461696C2E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250616E656C317D293B0D0A202020202020202020202020746869732E44657461696C2E447069203D20323534463B0D0A202020202020202020202020746869732E44657461696C2E48656967687446203D20333030463B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F676574686572203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F6765746865725769746844657461696C5265706F727473203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E5769647468203D20363030463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4C61796F7574203D20446576457870726573732E587472615072696E74696E672E436F6C756D6E4C61796F75742E4163726F73735468656E446F776E3B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4D6F6465203D20446576457870726573732E587472615265706F7274732E55492E4D756C7469436F6C756D6E4D6F64652E557365436F6C756D6E436F756E743B0D0A202020202020202020202020746869732E44657461696C2E4E616D65203D202244657461696C223B0D0A202020202020202020202020746869732E44657461696C2E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F704C6566743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B436F6D70616E794E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C20392E373735313632452D303646293B0D0A202020202020202020202020746869732E78724C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C312E4E616D65203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383346293B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E54657874203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250616E656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250616E656C312E416E63686F72486F72697A6F6E74616C203D202828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E4C656674207C20446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E52696768742929293B0D0A202020202020202020202020746869732E787250616E656C312E416E63686F72566572746963616C203D202828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E546F70207C20446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E426F74746F6D2929293B0D0A202020202020202020202020746869732E787250616E656C312E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E787250616E656C312E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E787250616E656C312E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250696374757265426F78312C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C317D293B0D0A202020202020202020202020746869732E787250616E656C312E447069203D20323534463B0D0A202020202020202020202020746869732E787250616E656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428352E353134303336462C20322E39333938313446293B0D0A202020202020202020202020746869732E787250616E656C312E4E616D65203D2022787250616E656C31223B0D0A202020202020202020202020746869732E787250616E656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C203238382E3935383346293B0D0A202020202020202020202020746869732E787250616E656C312E536E61704C696E6550616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C322E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726F647563744E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C322E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C322E4E616D65203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E54657874203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20746F704D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E746F704D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E4E616D65203D2022746F704D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726963655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C2039302E333831363846293B0D0A202020202020202020202020746869732E78724C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C332E4E616D65203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C332E54657874203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7052696768743B0D0A202020202020202020202020746869732E78724C6162656C332E54657874466F726D6174537472696E67203D20227B303A24302E30307D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250696374757265426F78310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250696374757265426F78312E447069203D20323534463B0D0A202020202020202020202020746869732E787250696374757265426F78312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C2022496D616765536F75726365222C20225B426172636F6465496D6167655D22297D293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742831392E3438353937462C203133352E3537323546293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4E616D65203D2022787250696374757265426F7831223B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A696E67203D20446576457870726573732E587472615072696E74696E672E496D61676553697A654D6F64652E4175746F53697A653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365312E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20626F74746F6D4D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E4E616D65203D2022626F74746F6D4D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F207274705F426172636F64650D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E42616E64732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E42616E645B5D207B0D0A202020202020202020202020202020202020202020202020746869732E44657461696C2C0D0A202020202020202020202020202020202020202020202020746869732E746F704D617267696E42616E64312C0D0A202020202020202020202020202020202020202020202020746869732E626F74746F6D4D617267696E42616E64317D293B0D0A202020202020202020202020746869732E426F726465725769647468203D2030463B0D0A202020202020202020202020746869732E436F6D706F6E656E7453746F726167652E41646452616E6765286E65772053797374656D2E436F6D706F6E656E744D6F64656C2E49436F6D706F6E656E745B5D207B0D0A202020202020202020202020202020202020202020202020746869732E62696E64696E67536F75726365317D293B0D0A202020202020202020202020746869732E447069203D20323534463B0D0A202020202020202020202020746869732E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E373546293B0D0A202020202020202020202020746869732E4D617267696E73203D206E65772053797374656D2E44726177696E672E5072696E74696E672E4D617267696E7328302C20302C20302C2030293B0D0A202020202020202020202020746869732E4E616D65203D20227274705F426172636F6465223B0D0A202020202020202020202020746869732E50616765486569676874203D203330303B0D0A202020202020202020202020746869732E506167655769647468203D203430303B0D0A202020202020202020202020746869732E50617065724B696E64203D2053797374656D2E44726177696E672E5072696E74696E672E50617065724B696E642E437573746F6D3B0D0A202020202020202020202020746869732E5265706F72745072696E744F7074696F6E732E44657461696C436F756E744F6E456D70747944617461536F75726365203D203134343B0D0A202020202020202020202020746869732E5265706F7274556E6974203D20446576457870726573732E587472615265706F7274732E55492E5265706F7274556E69742E54656E7468734F66414D696C6C696D657465723B0D0A202020202020202020202020746869732E53686F775072696E744D617267696E735761726E696E67203D2066616C73653B0D0A202020202020202020202020746869732E536E61704772696453697A65203D2033312E3735463B0D0A202020202020202020202020746869732E56657273696F6E203D202231392E32223B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E456E64496E697428293B0D0A20202020202020207D0D0A202020207D0D0A7D0D0A, 1)
INSERT [dbo].[BarcodeTemplates] ([ID], [Name], [Template], [IsDefault]) VALUES (43, N'نموذج 3*4 ضريبه', 0x2F2F2F203C585254797065496E666F3E0D0A2F2F2F2020203C417373656D626C7946756C6C4E616D653E4163636F756E74696E674D532C2056657273696F6E3D332E31312E31322E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C3C2F417373656D626C7946756C6C4E616D653E0D0A2F2F2F2020203C417373656D626C794C6F636174696F6E3E433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4163636F756E74696E674D532E6578653C2F417373656D626C794C6F636174696F6E3E0D0A2F2F2F2020203C547970654E616D653E4163636F756E74696E674D532E5265706F7274732E7274705F426172636F64653C2F547970654E616D653E0D0A2F2F2F2020203C4C6F63616C697A6174696F6E3E61722D41523C2F4C6F63616C697A6174696F6E3E0D0A2F2F2F2020203C56657273696F6E3E32312E313C2F56657273696F6E3E0D0A2F2F2F2020203C5265666572656E6365733E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4163636F756E74696E674D532E65786522202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C6C6F67346E65742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6E66696775726174696F6E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E436F6E66696775726174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F72655C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4E756D65726963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E4E756D65726963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174615C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5472616E73616374696F6E735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E5472616E73616374696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E456E746572707269736553657276696365735C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E456E746572707269736553657276696365732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E43616368696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E52756E74696D652E43616368696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5765625C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E5765622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E57696E646F77732E466F726D735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E57696E646F77732E466F726D732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4163636573736962696C6974795C76342E305F342E302E302E305F5F623033663566376631316435306133615C4163636573736962696C6974792E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174612E4F7261636C65436C69656E745C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4F7261636C65436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E672E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E5574696C732E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E446174612E4465736B746F702E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C57696E646F7773426173655C76342E305F342E302E302E305F5F333162663338353661643336346533355C57696E646F7773426173652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C55494175746F6D6174696F6E436C69656E745C76342E305F342E302E302E305F5F333162663338353661643336346533355C55494175746F6D6174696F6E436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C50726573656E746174696F6E436F72655C76342E305F342E302E302E305F5F333162663338353661643336346533355C50726573656E746174696F6E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E587472614C61796F75742E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E58747261456469746F72732E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E446174612E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E53657269616C697A6174696F6E5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E52756E74696D652E53657269616C697A6174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C2E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E58747261477269642E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E587472615072696E74696E672E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E58747261426172732E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E58747261547265654C6973742E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E446F63732E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C456E746974794672616D65776F726B2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4D6963726F736F66742E4353686172705C76342E305F342E302E302E305F5F623033663566376631316435306133615C4D6963726F736F66742E4353686172702E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44796E616D69635C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44796E616D69632E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E587472615265706F7274732E7632312E312E457874656E73696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E5574696C732E7632312E312E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E5874726152696368456469742E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E496D616765732E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E58747261566572746963616C477269642E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E446174614163636573732E7632312E312E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E587472614E61764261722E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E587472614368617274732E7632312E312E57697A6172642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C426172636F64654C69622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4D6963726F736F66742E506F696E744F66536572766963652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E587472614368617274732E7632312E312E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4D6963726F736F66742E53716C5365727665722E536D6F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4D6963726F736F66742E53716C5365727665722E436F6E6E656374696F6E496E666F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4D6963726F736F66742E53716C5365727665722E536D6F457874656E6465642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C435348415250444C4C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C446576457870726573732E457870726573734170702E7632312E312E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C50726F6772616D2046696C65732028783836295C467574757265546563685C46696E616C436F73745C4E6577746F6E736F66742E4A736F6E2E646C6C22202F3E0D0A2F2F2F2020203C2F5265666572656E6365733E0D0A2F2F2F2020203C5265736F75726365733E0D0A2F2F2F20202020203C5265736F75726365204E616D653D22587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F6465223E0D0A2F2F2F207A73727676674541414143524141414162464E356333526C625335535A584E7664584A6A5A584D75556D567A62335679593256535A57466B5A5849734947317A5932397962476C694C4342575A584A7A61573975505451754D4334774C6A417349454E3162485231636D5539626D563164484A68624377675548566962476C6A53325635564739725A573439596A63335954566A4E5459784F544D305A5441344F534E5465584E305A573075556D567A623356795932567A4C6C4A31626E5270625756535A584E7664584A6A5A564E6C64414941414141414141414141414141414642425246424252464330414141413C2F5265736F757263653E0D0A2F2F2F2020203C2F5265736F75726365733E0D0A2F2F2F203C2F585254797065496E666F3E0D0A6E616D65737061636520587472615265706F727453657269616C697A6174696F6E207B0D0A202020200D0A202020207075626C696320636C617373207274705F426172636F6465203A20446576457870726573732E587472615265706F7274732E55492E587472615265706F7274207B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250616E656C20787250616E656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7820787250696374757265426F78313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C313B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E44657461696C42616E642044657461696C3B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6420746F704D617267696E42616E64313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6420626F74746F6D4D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572205F7265736F75726365733B0D0A20202020202020207072697661746520737472696E67205F7265736F75726365537472696E673B0D0A20202020202020207075626C6963207274705F426172636F64652829207B0D0A202020202020202020202020746869732E5F7265736F75726365537472696E67203D20446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E616765722E4765745265736F75726365466F722822587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F646522293B0D0A202020202020202020202020746869732E496E697469616C697A65436F6D706F6E656E7428293B0D0A20202020202020207D0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572207265736F7572636573207B0D0A202020202020202020202020676574207B0D0A20202020202020202020202020202020696620285F7265736F7572636573203D3D206E756C6C29207B0D0A2020202020202020202020202020202020202020746869732E5F7265736F7572636573203D206E657720446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E6167657228746869732E5F7265736F75726365537472696E67293B0D0A202020202020202020202020202020207D0D0A2020202020202020202020202020202072657475726E20746869732E5F7265736F75726365733B0D0A2020202020202020202020207D0D0A20202020202020207D0D0A20202020202020207072697661746520766F696420496E697469616C697A65436F6D706F6E656E742829207B0D0A202020202020202020202020746869732E78724C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E787250616E656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E585250616E656C28293B0D0A202020202020202020202020746869732E62696E64696E67536F7572636531203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E44657461696C203D206E657720446576457870726573732E587472615265706F7274732E55492E44657461696C42616E6428293B0D0A202020202020202020202020746869732E746F704D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6428293B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6428293B0D0A202020202020202020202020746869732E787250696374757265426F7831203D206E657720446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7828293B0D0A202020202020202020202020746869732E78724C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E426567696E496E697428293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C322E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726F647563744E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C322E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C322E4E616D65203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E54657874203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250616E656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250616E656C312E416E63686F72486F72697A6F6E74616C203D202828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E4C656674207C20446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E52696768742929293B0D0A202020202020202020202020746869732E787250616E656C312E416E63686F72566572746963616C203D202828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E546F70207C20446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E426F74746F6D2929293B0D0A202020202020202020202020746869732E787250616E656C312E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E787250616E656C312E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E787250616E656C312E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C312C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E787250696374757265426F78312C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C317D293B0D0A202020202020202020202020746869732E787250616E656C312E447069203D20323534463B0D0A202020202020202020202020746869732E787250616E656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428352E353134303334462C20322E39333938313146293B0D0A202020202020202020202020746869732E787250616E656C312E4E616D65203D2022787250616E656C31223B0D0A202020202020202020202020746869732E787250616E656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C203136392E3236353946293B0D0A202020202020202020202020746869732E787250616E656C312E536E61704C696E6550616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365312E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2044657461696C0D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E44657461696C2E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E44657461696C2E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E44657461696C2E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250616E656C317D293B0D0A202020202020202020202020746869732E44657461696C2E447069203D20323534463B0D0A202020202020202020202020746869732E44657461696C2E48656967687446203D203233372E303034463B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F676574686572203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F6765746865725769746844657461696C5265706F727473203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E5769647468203D20363030463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4C61796F7574203D20446576457870726573732E587472615072696E74696E672E436F6C756D6E4C61796F75742E4163726F73735468656E446F776E3B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4D6F6465203D20446576457870726573732E587472615265706F7274732E55492E4D756C7469436F6C756D6E4D6F64652E557365436F6C756D6E436F756E743B0D0A202020202020202020202020746869732E44657461696C2E4E616D65203D202244657461696C223B0D0A202020202020202020202020746869732E44657461696C2E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F704C6566743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20746F704D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E746F704D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E4E616D65203D2022746F704D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20626F74746F6D4D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E4E616D65203D2022626F74746F6D4D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250696374757265426F78310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250696374757265426F78312E447069203D20323534463B0D0A202020202020202020202020746869732E787250696374757265426F78312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C2022496D616765536F75726365222C20225B426172636F6465496D6167655D22297D293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742831392E3438353937462C203133382E3231383446293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4E616D65203D2022787250696374757265426F7831223B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A696E67203D20446576457870726573732E587472615072696E74696E672E496D61676553697A654D6F64652E4175746F53697A653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B436F6D70616E794E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C20392E373735313632452D303646293B0D0A202020202020202020202020746869732E78724C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C312E4E616D65203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383346293B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E54657874203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C203846293B0D0A202020202020202020202020746869732E6C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283137312E39373932462C2039302E333831363946293B0D0A202020202020202020202020746869732E6C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C312E4E616D65203D20226C6162656C31223B0D0A202020202020202020202020746869732E6C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283231332E36383733462C2034372E383336363746293B0D0A202020202020202020202020746869732E6C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C312E54657874203D2022D8A7D984D8B3D8B9D8B120D8B4D8A7D985D98420D8A7D984D8B6D8B1D98AD8A8D987223B0D0A202020202020202020202020746869732E6C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7052696768743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B54617850726963655D22297D293B0D0A202020202020202020202020746869732E6C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C2039302E333831363946293B0D0A202020202020202020202020746869732E6C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C322E4E616D65203D20226C6162656C32223B0D0A202020202020202020202020746869732E6C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283137312E39373932462C2034372E383336363746293B0D0A202020202020202020202020746869732E6C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C322E54657874203D20226C6162656C31223B0D0A202020202020202020202020746869732E6C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F207274705F426172636F64650D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E42616E64732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E42616E645B5D207B0D0A202020202020202020202020202020202020202020202020746869732E44657461696C2C0D0A202020202020202020202020202020202020202020202020746869732E746F704D617267696E42616E64312C0D0A202020202020202020202020202020202020202020202020746869732E626F74746F6D4D617267696E42616E64317D293B0D0A202020202020202020202020746869732E426F726465725769647468203D2030463B0D0A202020202020202020202020746869732E436F6D706F6E656E7453746F726167652E41646452616E6765286E65772053797374656D2E436F6D706F6E656E744D6F64656C2E49436F6D706F6E656E745B5D207B0D0A202020202020202020202020202020202020202020202020746869732E62696E64696E67536F75726365317D293B0D0A202020202020202020202020746869732E447069203D20323534463B0D0A202020202020202020202020746869732E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E373546293B0D0A202020202020202020202020746869732E4D617267696E73203D206E65772053797374656D2E44726177696E672E5072696E74696E672E4D617267696E7328302C20302C20302C2030293B0D0A202020202020202020202020746869732E4E616D65203D20227274705F426172636F6465223B0D0A202020202020202020202020746869732E50616765486569676874203D203330303B0D0A202020202020202020202020746869732E506167655769647468203D203430303B0D0A202020202020202020202020746869732E50617065724B696E64203D2053797374656D2E44726177696E672E5072696E74696E672E50617065724B696E642E437573746F6D3B0D0A202020202020202020202020746869732E5265706F72745072696E744F7074696F6E732E44657461696C436F756E744F6E456D70747944617461536F75726365203D203134343B0D0A202020202020202020202020746869732E5265706F7274556E6974203D20446576457870726573732E587472615265706F7274732E55492E5265706F7274556E69742E54656E7468734F66414D696C6C696D657465723B0D0A202020202020202020202020746869732E53686F775072696E744D617267696E735761726E696E67203D2066616C73653B0D0A202020202020202020202020746869732E536E61704772696453697A65203D2033312E3735463B0D0A202020202020202020202020746869732E56657273696F6E203D202232312E31223B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E456E64496E697428293B0D0A20202020202020207D0D0A202020207D0D0A7D0D0A, 0)
INSERT [dbo].[BarcodeTemplates] ([ID], [Name], [Template], [IsDefault]) VALUES (44, N'نموذج 4*5 بدون ضريبه', 0x2F2F2F203C585254797065496E666F3E0D0A2F2F2F2020203C417373656D626C7946756C6C4E616D653E4163636F756E74696E674D532C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C3C2F417373656D626C7946756C6C4E616D653E0D0A2F2F2F2020203C417373656D626C794C6F636174696F6E3E443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E6578653C2F417373656D626C794C6F636174696F6E3E0D0A2F2F2F2020203C547970654E616D653E4163636F756E74696E674D532E5265706F7274732E7274705F426172636F64653C2F547970654E616D653E0D0A2F2F2F2020203C4C6F63616C697A6174696F6E3E61722D41523C2F4C6F63616C697A6174696F6E3E0D0A2F2F2F2020203C56657273696F6E3E31392E323C2F56657273696F6E3E0D0A2F2F2F2020203C5265666572656E6365733E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E65786522202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C6C6F67346E65742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6E66696775726174696F6E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E436F6E66696775726174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F72655C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4E756D65726963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E4E756D65726963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174615C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5472616E73616374696F6E735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E5472616E73616374696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E456E746572707269736553657276696365735C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E456E746572707269736553657276696365732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E43616368696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E52756E74696D652E43616368696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5765625C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E5765622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E57696E646F77732E466F726D735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E57696E646F77732E466F726D732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4163636573736962696C6974795C76342E305F342E302E302E305F5F623033663566376631316435306133615C4163636573736962696C6974792E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174612E4F7261636C65436C69656E745C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4F7261636C65436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E672E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C55494175746F6D6174696F6E436C69656E745C76342E305F342E302E302E305F5F333162663338353661643336346533355C55494175746F6D6174696F6E436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C57696E646F7773426173655C76342E305F342E302E302E305F5F333162663338353661643336346533355C57696E646F7773426173652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E58616D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E58616D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C50726573656E746174696F6E436F72655C76342E305F342E302E302E305F5F333162663338353661643336346533355C50726573656E746174696F6E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614C61796F75742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614C61796F75742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261456469746F72732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261456469746F72732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E446174612E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E53657269616C697A6174696F6E5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E52756E74696D652E53657269616C697A6174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E536572766963654D6F64656C2E496E7465726E616C735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E536572766963654D6F64656C2E496E7465726E616C732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C534D446961676E6F73746963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C534D446961676E6F73746963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C2E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615072696E74696E672E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615072696E74696E672E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261426172732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261426172732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261547265654C6973742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261547265654C6973742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446F63732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446F63732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C456E746974794672616D65776F726B2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C426172636F64654C69622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E735C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261566572746963616C477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261566572746963616C477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446174614163636573732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446174614163636573732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614E61764261722E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614E61764261722E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E57697A6172645C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E57697A6172642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E436F6E6E656374696F6E496E666F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F457874656E6465642E646C6C22202F3E0D0A2F2F2F2020203C2F5265666572656E6365733E0D0A2F2F2F2020203C5265736F75726365733E0D0A2F2F2F20202020203C5265736F75726365204E616D653D22587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F6465223E0D0A2F2F2F207A73727676674541414143524141414162464E356333526C625335535A584E7664584A6A5A584D75556D567A62335679593256535A57466B5A5849734947317A5932397962476C694C4342575A584A7A61573975505451754D4334774C6A417349454E3162485231636D5539626D563164484A68624377675548566962476C6A53325635564739725A573439596A63335954566A4E5459784F544D305A5441344F534E5465584E305A573075556D567A623356795932567A4C6C4A31626E5270625756535A584E7664584A6A5A564E6C64414941414141414141414141414141414642425246424252464330414141413C2F5265736F757263653E0D0A2F2F2F2020203C2F5265736F75726365733E0D0A2F2F2F203C2F585254797065496E666F3E0D0A6E616D65737061636520587472615265706F727453657269616C697A6174696F6E207B0D0A202020200D0A202020207075626C696320636C617373207274705F426172636F6465203A20446576457870726573732E587472615265706F7274732E55492E587472615265706F7274207B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E44657461696C42616E642044657461696C3B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250616E656C20787250616E656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7820787250696374757265426F78313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6420626F74746F6D4D617267696E42616E64313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6420746F704D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365323B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365313B0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572205F7265736F75726365733B0D0A20202020202020207072697661746520737472696E67205F7265736F75726365537472696E673B0D0A20202020202020207075626C6963207274705F426172636F64652829207B0D0A202020202020202020202020746869732E5F7265736F75726365537472696E67203D20446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E616765722E4765745265736F75726365466F722822587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F646522293B0D0A202020202020202020202020746869732E496E697469616C697A65436F6D706F6E656E7428293B0D0A20202020202020207D0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572207265736F7572636573207B0D0A202020202020202020202020676574207B0D0A20202020202020202020202020202020696620285F7265736F7572636573203D3D206E756C6C29207B0D0A2020202020202020202020202020202020202020746869732E5F7265736F7572636573203D206E657720446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E6167657228746869732E5F7265736F75726365537472696E67293B0D0A202020202020202020202020202020207D0D0A2020202020202020202020202020202072657475726E20746869732E5F7265736F75726365733B0D0A2020202020202020202020207D0D0A20202020202020207D0D0A20202020202020207072697661746520766F696420496E697469616C697A65436F6D706F6E656E742829207B0D0A202020202020202020202020746869732E44657461696C203D206E657720446576457870726573732E587472615265706F7274732E55492E44657461696C42616E6428293B0D0A202020202020202020202020746869732E78724C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E78724C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6428293B0D0A202020202020202020202020746869732E746F704D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6428293B0D0A202020202020202020202020746869732E78724C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E62696E64696E67536F7572636532203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E787250616E656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E585250616E656C28293B0D0A202020202020202020202020746869732E787250696374757265426F7831203D206E657720446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7828293B0D0A202020202020202020202020746869732E62696E64696E67536F7572636531203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E6C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653229292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E426567696E496E697428293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2044657461696C0D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E44657461696C2E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E44657461696C2E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E44657461696C2E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250616E656C317D293B0D0A202020202020202020202020746869732E44657461696C2E447069203D20323534463B0D0A202020202020202020202020746869732E44657461696C2E48656967687446203D20343530463B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F676574686572203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F6765746865725769746844657461696C5265706F727473203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E5769647468203D20363030463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4C61796F7574203D20446576457870726573732E587472615072696E74696E672E436F6C756D6E4C61796F75742E4163726F73735468656E446F776E3B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4D6F6465203D20446576457870726573732E587472615265706F7274732E55492E4D756C7469436F6C756D6E4D6F64652E557365436F6C756D6E436F756E743B0D0A202020202020202020202020746869732E44657461696C2E4E616D65203D202244657461696C223B0D0A202020202020202020202020746869732E44657461696C2E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F704C6566743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C322E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E78724C6162656C322E426F726465725769647468203D2032463B0D0A202020202020202020202020746869732E78724C6162656C322E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726F647563744E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C322E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C2036392E303033333146293B0D0A202020202020202020202020746869732E78724C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C322E4E616D65203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283438352E36363635462C2036392E303033333346293B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E54657874203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B436F6D70616E794E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C203131462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C203046293B0D0A202020202020202020202020746869732E78724C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C312E4E616D65203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283438352E36363635462C2036392E303033333146293B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E54657874203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20626F74746F6D4D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E48656967687446203D2032332E3333333336463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E4E616D65203D2022626F74746F6D4D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20746F704D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E746F704D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E4E616D65203D2022746F704D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C332E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E78724C6162656C332E426F726465725769647468203D2032463B0D0A202020202020202020202020746869732E78724C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726963655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C332E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C2039462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C203236322E3738343146293B0D0A202020202020202020202020746869732E78724C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C332E4E616D65203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283235382E31323438462C2036392E303033333346293B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E54657874203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A202020202020202020202020746869732E78724C6162656C332E54657874466F726D6174537472696E67203D20227B303A24302E30307D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365322E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250616E656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250616E656C312E416E63686F72486F72697A6F6E74616C203D202828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E4C656674207C20446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E52696768742929293B0D0A202020202020202020202020746869732E787250616E656C312E416E63686F72566572746963616C203D202828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E546F70207C20446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E426F74746F6D2929293B0D0A202020202020202020202020746869732E787250616E656C312E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E787250616E656C312E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E787250616E656C312E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C312C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E787250696374757265426F78312C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C317D293B0D0A202020202020202020202020746869732E787250616E656C312E447069203D20323534463B0D0A202020202020202020202020746869732E787250616E656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428352E353134303336462C20322E39333938313446293B0D0A202020202020202020202020746869732E787250616E656C312E4E616D65203D2022787250616E656C31223B0D0A202020202020202020202020746869732E787250616E656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283530352E36363635462C203433382E3935383346293B0D0A202020202020202020202020746869732E787250616E656C312E536E61704C696E6550616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250696374757265426F78310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250696374757265426F78312E447069203D20323534463B0D0A202020202020202020202020746869732E787250696374757265426F78312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C2022496D616765536F75726365222C20225B426172636F6465496D6167655D22297D293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742835332E3838313831462C203133382E3030363646293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4E616D65203D2022787250696374757265426F7831223B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A696E67203D20446576457870726573732E587472615072696E74696E672E496D61676553697A654D6F64652E4175746F53697A653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365312E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B5465737450726F705D22297D293B0D0A202020202020202020202020746869732E6C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283230332E35303638462C203333382E3634303146293B0D0A202020202020202020202020746869732E6C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C312E4E616D65203D20226C6162656C31223B0D0A202020202020202020202020746869732E6C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28322C20322C20302C20302C20393646293B0D0A202020202020202020202020746869732E6C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E6C6162656C312E54657874203D20226C6162656C33223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C322E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E6C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B4E6F7465735D22297D293B0D0A202020202020202020202020746869732E6C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E313234383039462C203139362E3432363646293B0D0A202020202020202020202020746869732E6C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C322E4E616D65203D20226C6162656C32223B0D0A202020202020202020202020746869732E6C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283438312E35343137462C2036362E333537343746293B0D0A202020202020202020202020746869732E6C6162656C322E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C322E54657874203D20226C6162656C32223B0D0A202020202020202020202020746869732E6C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C332E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E6C6162656C332E426F726465725769647468203D2032463B0D0A202020202020202020202020746869732E6C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B556E69744E616D655D22297D293B0D0A202020202020202020202020746869732E6C6162656C332E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C2039462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E6C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283235382E31323438462C203236322E3738343146293B0D0A202020202020202020202020746869732E6C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C332E4E616D65203D20226C6162656C33223B0D0A202020202020202020202020746869732E6C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283232372E35343137462C2036392E303033333646293B0D0A202020202020202020202020746869732E6C6162656C332E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C332E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C332E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C332E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C332E54657874203D20226C6162656C31223B0D0A202020202020202020202020746869732E6C6162656C332E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F207274705F426172636F64650D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E42616E64732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E42616E645B5D207B0D0A202020202020202020202020202020202020202020202020746869732E44657461696C2C0D0A202020202020202020202020202020202020202020202020746869732E746F704D617267696E42616E64312C0D0A202020202020202020202020202020202020202020202020746869732E626F74746F6D4D617267696E42616E64317D293B0D0A202020202020202020202020746869732E426F726465725769647468203D2030463B0D0A202020202020202020202020746869732E436F6D706F6E656E7453746F726167652E41646452616E6765286E65772053797374656D2E436F6D706F6E656E744D6F64656C2E49436F6D706F6E656E745B5D207B0D0A202020202020202020202020202020202020202020202020746869732E62696E64696E67536F75726365317D293B0D0A202020202020202020202020746869732E447069203D20323534463B0D0A202020202020202020202020746869732E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E373546293B0D0A202020202020202020202020746869732E4D617267696E73203D206E65772053797374656D2E44726177696E672E5072696E74696E672E4D617267696E7328302C20302C20302C203233293B0D0A202020202020202020202020746869732E4E616D65203D20227274705F426172636F6465223B0D0A202020202020202020202020746869732E50616765486569676874203D203435303B0D0A202020202020202020202020746869732E506167655769647468203D203532303B0D0A202020202020202020202020746869732E50617065724B696E64203D2053797374656D2E44726177696E672E5072696E74696E672E50617065724B696E642E437573746F6D3B0D0A202020202020202020202020746869732E5265706F72745072696E744F7074696F6E732E44657461696C436F756E744F6E456D70747944617461536F75726365203D203134343B0D0A202020202020202020202020746869732E5265706F7274556E6974203D20446576457870726573732E587472615265706F7274732E55492E5265706F7274556E69742E54656E7468734F66414D696C6C696D657465723B0D0A202020202020202020202020746869732E53686F775072696E744D617267696E735761726E696E67203D2066616C73653B0D0A202020202020202020202020746869732E536E61704772696453697A65203D2033312E3735463B0D0A202020202020202020202020746869732E56657273696F6E203D202231392E32223B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653229292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E456E64496E697428293B0D0A20202020202020207D0D0A202020207D0D0A7D0D0A, 0)
INSERT [dbo].[BarcodeTemplates] ([ID], [Name], [Template], [IsDefault]) VALUES (45, N'نموذج A4 3*4', 0x2F2F2F203C585254797065496E666F3E0D0A2F2F2F2020203C417373656D626C7946756C6C4E616D653E4163636F756E74696E674D532C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C3C2F417373656D626C7946756C6C4E616D653E0D0A2F2F2F2020203C417373656D626C794C6F636174696F6E3E443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E6578653C2F417373656D626C794C6F636174696F6E3E0D0A2F2F2F2020203C547970654E616D653E4163636F756E74696E674D532E5265706F7274732E7274705F426172636F64653C2F547970654E616D653E0D0A2F2F2F2020203C4C6F63616C697A6174696F6E3E61722D41523C2F4C6F63616C697A6174696F6E3E0D0A2F2F2F2020203C56657273696F6E3E31392E323C2F56657273696F6E3E0D0A2F2F2F2020203C5265666572656E6365733E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E65786522202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C6C6F67346E65742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6E66696775726174696F6E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E436F6E66696775726174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F72655C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4E756D65726963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E4E756D65726963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174615C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5472616E73616374696F6E735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E5472616E73616374696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E456E746572707269736553657276696365735C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E456E746572707269736553657276696365732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E43616368696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E52756E74696D652E43616368696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5765625C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E5765622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E57696E646F77732E466F726D735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E57696E646F77732E466F726D732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4163636573736962696C6974795C76342E305F342E302E302E305F5F623033663566376631316435306133615C4163636573736962696C6974792E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174612E4F7261636C65436C69656E745C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4F7261636C65436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E672E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C55494175746F6D6174696F6E436C69656E745C76342E305F342E302E302E305F5F333162663338353661643336346533355C55494175746F6D6174696F6E436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C57696E646F7773426173655C76342E305F342E302E302E305F5F333162663338353661643336346533355C57696E646F7773426173652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E58616D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E58616D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C50726573656E746174696F6E436F72655C76342E305F342E302E302E305F5F333162663338353661643336346533355C50726573656E746174696F6E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614C61796F75742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614C61796F75742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261456469746F72732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261456469746F72732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E446174612E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E53657269616C697A6174696F6E5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E52756E74696D652E53657269616C697A6174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E536572766963654D6F64656C2E496E7465726E616C735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E536572766963654D6F64656C2E496E7465726E616C732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C534D446961676E6F73746963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C534D446961676E6F73746963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C2E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615072696E74696E672E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615072696E74696E672E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261426172732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261426172732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261547265654C6973742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261547265654C6973742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446F63732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446F63732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C456E746974794672616D65776F726B2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C426172636F64654C69622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E735C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261566572746963616C477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261566572746963616C477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446174614163636573732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446174614163636573732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614E61764261722E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614E61764261722E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E57697A6172645C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E57697A6172642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E436F6E6E656374696F6E496E666F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F457874656E6465642E646C6C22202F3E0D0A2F2F2F2020203C2F5265666572656E6365733E0D0A2F2F2F2020203C5265736F75726365733E0D0A2F2F2F20202020203C5265736F75726365204E616D653D22587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F6465223E0D0A2F2F2F207A73727676674541414143524141414162464E356333526C625335535A584E7664584A6A5A584D75556D567A62335679593256535A57466B5A5849734947317A5932397962476C694C4342575A584A7A61573975505451754D4334774C6A417349454E3162485231636D5539626D563164484A68624377675548566962476C6A53325635564739725A573439596A63335954566A4E5459784F544D305A5441344F534E5465584E305A573075556D567A623356795932567A4C6C4A31626E5270625756535A584E7664584A6A5A564E6C64414941414141414141414141414141414642425246424252464330414141413C2F5265736F757263653E0D0A2F2F2F2020203C2F5265736F75726365733E0D0A2F2F2F203C2F585254797065496E666F3E0D0A6E616D65737061636520587472615265706F727453657269616C697A6174696F6E207B0D0A202020200D0A202020207075626C696320636C617373207274705F426172636F6465203A20446576457870726573732E587472615265706F7274732E55492E587472615265706F7274207B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C333B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250616E656C20787250616E656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7820787250696374757265426F78313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E44657461696C42616E642044657461696C3B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6420626F74746F6D4D617267696E42616E64313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6420746F704D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572205F7265736F75726365733B0D0A20202020202020207072697661746520737472696E67205F7265736F75726365537472696E673B0D0A20202020202020207075626C6963207274705F426172636F64652829207B0D0A202020202020202020202020746869732E5F7265736F75726365537472696E67203D20446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E616765722E4765745265736F75726365466F722822587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F646522293B0D0A202020202020202020202020746869732E496E697469616C697A65436F6D706F6E656E7428293B0D0A20202020202020207D0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572207265736F7572636573207B0D0A202020202020202020202020676574207B0D0A20202020202020202020202020202020696620285F7265736F7572636573203D3D206E756C6C29207B0D0A2020202020202020202020202020202020202020746869732E5F7265736F7572636573203D206E657720446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E6167657228746869732E5F7265736F75726365537472696E67293B0D0A202020202020202020202020202020207D0D0A2020202020202020202020202020202072657475726E20746869732E5F7265736F75726365733B0D0A2020202020202020202020207D0D0A20202020202020207D0D0A20202020202020207072697661746520766F696420496E697469616C697A65436F6D706F6E656E742829207B0D0A202020202020202020202020746869732E78724C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E62696E64696E67536F7572636531203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E787250616E656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E585250616E656C28293B0D0A202020202020202020202020746869732E44657461696C203D206E657720446576457870726573732E587472615265706F7274732E55492E44657461696C42616E6428293B0D0A202020202020202020202020746869732E787250696374757265426F7831203D206E657720446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7828293B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6428293B0D0A202020202020202020202020746869732E746F704D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6428293B0D0A202020202020202020202020746869732E78724C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E78724C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E426567696E496E697428293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726963655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428312E393037333439452D3035462C2039302E333831373146293B0D0A202020202020202020202020746869732E78724C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C332E4E616D65203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283339392E39393939462C2034352E313930383646293B0D0A202020202020202020202020746869732E78724C6162656C332E54657874203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7052696768743B0D0A202020202020202020202020746869732E78724C6162656C332E54657874466F726D6174537472696E67203D20227B303A24302E30307D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365312E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250616E656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250616E656C312E416E63686F72486F72697A6F6E74616C203D202828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E4C656674207C20446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E52696768742929293B0D0A202020202020202020202020746869732E787250616E656C312E416E63686F72566572746963616C203D202828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E546F70207C20446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E426F74746F6D2929293B0D0A202020202020202020202020746869732E787250616E656C312E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E787250616E656C312E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E787250616E656C312E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250696374757265426F78312C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C317D293B0D0A202020202020202020202020746869732E787250616E656C312E447069203D20323534463B0D0A202020202020202020202020746869732E787250616E656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C20322E39333938323446293B0D0A202020202020202020202020746869732E787250616E656C312E4E616D65203D2022787250616E656C31223B0D0A202020202020202020202020746869732E787250616E656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628343030462C203239372E3036303246293B0D0A202020202020202020202020746869732E787250616E656C312E536E61704C696E6550616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2044657461696C0D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E44657461696C2E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E44657461696C2E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E44657461696C2E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250616E656C317D293B0D0A202020202020202020202020746869732E44657461696C2E447069203D20323534463B0D0A202020202020202020202020746869732E44657461696C2E48656967687446203D20333030463B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F676574686572203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F6765746865725769746844657461696C5265706F727473203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E436F756E74203D20353B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E5769647468203D20343030463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4C61796F7574203D20446576457870726573732E587472615072696E74696E672E436F6C756D6E4C61796F75742E4163726F73735468656E446F776E3B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4D6F6465203D20446576457870726573732E587472615265706F7274732E55492E4D756C7469436F6C756D6E4D6F64652E557365436F6C756D6E436F756E743B0D0A202020202020202020202020746869732E44657461696C2E4E616D65203D202244657461696C223B0D0A202020202020202020202020746869732E44657461696C2E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F704C6566743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250696374757265426F78310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250696374757265426F78312E447069203D20323534463B0D0A202020202020202020202020746869732E787250696374757265426F78312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C2022496D616765536F75726365222C20225B426172636F6465496D6167655D22297D293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742831392E3438353937462C203133352E3537323546293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4E616D65203D2022787250696374757265426F7831223B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A696E67203D20446576457870726573732E587472615072696E74696E672E496D61676553697A654D6F64652E4175746F53697A653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20626F74746F6D4D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E4E616D65203D2022626F74746F6D4D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20746F704D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E746F704D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E4E616D65203D2022746F704D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C322E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726F647563744E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C322E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428312E393037333439452D3035462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C322E4E616D65203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283339392E39393939462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E54657874203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B436F6D70616E794E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428312E393037333439452D3035462C20342E303035343332452D303546293B0D0A202020202020202020202020746869732E78724C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C312E4E616D65203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283339392E39393939462C2034352E313930383346293B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E54657874203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F207274705F426172636F64650D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E42616E64732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E42616E645B5D207B0D0A202020202020202020202020202020202020202020202020746869732E44657461696C2C0D0A202020202020202020202020202020202020202020202020746869732E746F704D617267696E42616E64312C0D0A202020202020202020202020202020202020202020202020746869732E626F74746F6D4D617267696E42616E64317D293B0D0A202020202020202020202020746869732E426F726465725769647468203D2030463B0D0A202020202020202020202020746869732E436F6D706F6E656E7453746F726167652E41646452616E6765286E65772053797374656D2E436F6D706F6E656E744D6F64656C2E49436F6D706F6E656E745B5D207B0D0A202020202020202020202020202020202020202020202020746869732E62696E64696E67536F75726365317D293B0D0A202020202020202020202020746869732E447069203D20323534463B0D0A202020202020202020202020746869732E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E373546293B0D0A202020202020202020202020746869732E4D617267696E73203D206E65772053797374656D2E44726177696E672E5072696E74696E672E4D617267696E732835302C2035302C203130302C20313030293B0D0A202020202020202020202020746869732E4E616D65203D20227274705F426172636F6465223B0D0A202020202020202020202020746869732E50616765486569676874203D20323937303B0D0A202020202020202020202020746869732E506167655769647468203D20323130303B0D0A202020202020202020202020746869732E50617065724B696E64203D2053797374656D2E44726177696E672E5072696E74696E672E50617065724B696E642E41343B0D0A202020202020202020202020746869732E5265706F72745072696E744F7074696F6E732E44657461696C436F756E744F6E456D70747944617461536F75726365203D203134343B0D0A202020202020202020202020746869732E5265706F7274556E6974203D20446576457870726573732E587472615265706F7274732E55492E5265706F7274556E69742E54656E7468734F66414D696C6C696D657465723B0D0A202020202020202020202020746869732E53686F775072696E744D617267696E735761726E696E67203D2066616C73653B0D0A202020202020202020202020746869732E536E61704772696453697A65203D2033312E3735463B0D0A202020202020202020202020746869732E56657273696F6E203D202231392E32223B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E456E64496E697428293B0D0A20202020202020207D0D0A202020207D0D0A7D0D0A, 0)
INSERT [dbo].[BarcodeTemplates] ([ID], [Name], [Template], [IsDefault]) VALUES (51, N'نموذج ', 0x2F2F2F203C585254797065496E666F3E0D0A2F2F2F2020203C417373656D626C7946756C6C4E616D653E4163636F756E74696E674D532C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C3C2F417373656D626C7946756C6C4E616D653E0D0A2F2F2F2020203C417373656D626C794C6F636174696F6E3E443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E6578653C2F417373656D626C794C6F636174696F6E3E0D0A2F2F2F2020203C547970654E616D653E4163636F756E74696E674D532E5265706F7274732E7274705F426172636F64653C2F547970654E616D653E0D0A2F2F2F2020203C4C6F63616C697A6174696F6E3E61722D41523C2F4C6F63616C697A6174696F6E3E0D0A2F2F2F2020203C56657273696F6E3E31392E323C2F56657273696F6E3E0D0A2F2F2F2020203C5265666572656E6365733E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E65786522202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C6C6F67346E65742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6E66696775726174696F6E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E436F6E66696775726174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F72655C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4E756D65726963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E4E756D65726963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174615C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5472616E73616374696F6E735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E5472616E73616374696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E456E746572707269736553657276696365735C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E456E746572707269736553657276696365732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E43616368696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E52756E74696D652E43616368696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5765625C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E5765622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E57696E646F77732E466F726D735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E57696E646F77732E466F726D732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4163636573736962696C6974795C76342E305F342E302E302E305F5F623033663566376631316435306133615C4163636573736962696C6974792E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174612E4F7261636C65436C69656E745C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4F7261636C65436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E672E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C55494175746F6D6174696F6E436C69656E745C76342E305F342E302E302E305F5F333162663338353661643336346533355C55494175746F6D6174696F6E436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C57696E646F7773426173655C76342E305F342E302E302E305F5F333162663338353661643336346533355C57696E646F7773426173652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E58616D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E58616D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C50726573656E746174696F6E436F72655C76342E305F342E302E302E305F5F333162663338353661643336346533355C50726573656E746174696F6E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614C61796F75742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614C61796F75742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261456469746F72732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261456469746F72732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E446174612E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E53657269616C697A6174696F6E5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E52756E74696D652E53657269616C697A6174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E536572766963654D6F64656C2E496E7465726E616C735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E536572766963654D6F64656C2E496E7465726E616C732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C534D446961676E6F73746963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C534D446961676E6F73746963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C2E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615072696E74696E672E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615072696E74696E672E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261426172732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261426172732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261547265654C6973742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261547265654C6973742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4D616E6167656D656E745C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E4D616E6167656D656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446F63732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446F63732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C456E746974794672616D65776F726B2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C426172636F64654C69622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E735C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261566572746963616C477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261566572746963616C477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446174614163636573732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446174614163636573732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614E61764261722E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614E61764261722E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E57697A6172645C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E57697A6172642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E436F6E6E656374696F6E496E666F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F457874656E6465642E646C6C22202F3E0D0A2F2F2F2020203C2F5265666572656E6365733E0D0A2F2F2F2020203C5265736F75726365733E0D0A2F2F2F20202020203C5265736F75726365204E616D653D22587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F6465223E0D0A2F2F2F207A73727676674541414143524141414162464E356333526C625335535A584E7664584A6A5A584D75556D567A62335679593256535A57466B5A5849734947317A5932397962476C694C4342575A584A7A61573975505451754D4334774C6A417349454E3162485231636D5539626D563164484A68624377675548566962476C6A53325635564739725A573439596A63335954566A4E5459784F544D305A5441344F534E5465584E305A573075556D567A623356795932567A4C6C4A31626E5270625756535A584E7664584A6A5A564E6C64414941414141414141414141414141414642425246424252464330414141413C2F5265736F757263653E0D0A2F2F2F2020203C2F5265736F75726365733E0D0A2F2F2F203C2F585254797065496E666F3E0D0A6E616D65737061636520587472615265706F727453657269616C697A6174696F6E207B0D0A202020200D0A202020207075626C696320636C617373207274705F426172636F6465203A20446576457870726573732E587472615265706F7274732E55492E587472615265706F7274207B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250616E656C20787250616E656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C343B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C353B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C363B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7820787250696374757265426F78313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C313B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6420626F74746F6D4D617267696E42616E64313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E44657461696C42616E642044657461696C3B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6420746F704D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572205F7265736F75726365733B0D0A20202020202020207072697661746520737472696E67205F7265736F75726365537472696E673B0D0A20202020202020207075626C6963207274705F426172636F64652829207B0D0A202020202020202020202020746869732E5F7265736F75726365537472696E67203D20446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E616765722E4765745265736F75726365466F722822587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F646522293B0D0A202020202020202020202020746869732E496E697469616C697A65436F6D706F6E656E7428293B0D0A20202020202020207D0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572207265736F7572636573207B0D0A202020202020202020202020676574207B0D0A20202020202020202020202020202020696620285F7265736F7572636573203D3D206E756C6C29207B0D0A2020202020202020202020202020202020202020746869732E5F7265736F7572636573203D206E657720446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E6167657228746869732E5F7265736F75726365537472696E67293B0D0A202020202020202020202020202020207D0D0A2020202020202020202020202020202072657475726E20746869732E5F7265736F75726365733B0D0A2020202020202020202020207D0D0A20202020202020207D0D0A20202020202020207072697661746520766F696420496E697469616C697A65436F6D706F6E656E742829207B0D0A202020202020202020202020746869732E78724C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E787250616E656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E585250616E656C28293B0D0A202020202020202020202020746869732E62696E64696E67536F7572636531203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E78724C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E787250696374757265426F7831203D206E657720446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7828293B0D0A202020202020202020202020746869732E78724C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6428293B0D0A202020202020202020202020746869732E44657461696C203D206E657720446576457870726573732E587472615265706F7274732E55492E44657461696C42616E6428293B0D0A202020202020202020202020746869732E746F704D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6428293B0D0A202020202020202020202020746869732E6C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C34203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C35203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C36203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E426567696E496E697428293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C322E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E78724C6162656C322E426F726465725769647468203D2032463B0D0A202020202020202020202020746869732E78724C6162656C322E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726F647563744E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C322E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C2036392E303033333146293B0D0A202020202020202020202020746869732E78724C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C322E4E616D65203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283438352E36363635462C2036392E303033333346293B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E54657874203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250616E656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250616E656C312E416E63686F72486F72697A6F6E74616C203D202828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E4C656674207C20446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E52696768742929293B0D0A202020202020202020202020746869732E787250616E656C312E416E63686F72566572746963616C203D202828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E546F70207C20446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E426F74746F6D2929293B0D0A202020202020202020202020746869732E787250616E656C312E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E787250616E656C312E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E787250616E656C312E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C312C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C342C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C352C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C362C0D0A202020202020202020202020202020202020202020202020746869732E787250696374757265426F78312C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C317D293B0D0A202020202020202020202020746869732E787250616E656C312E447069203D20323534463B0D0A202020202020202020202020746869732E787250616E656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428352E353134303336462C20322E39333938313446293B0D0A202020202020202020202020746869732E787250616E656C312E4E616D65203D2022787250616E656C31223B0D0A202020202020202020202020746869732E787250616E656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283438352E36363635462C203338382E3935383346293B0D0A202020202020202020202020746869732E787250616E656C312E536E61704C696E6550616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365312E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C332E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E78724C6162656C332E426F726465725769647468203D2032463B0D0A202020202020202020202020746869732E78724C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B54617850726963655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C332E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C2039462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C203136322E3639323546293B0D0A202020202020202020202020746869732E78724C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C332E4E616D65203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283233312E36363635462C2036392E3030333346293B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E54657874203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A202020202020202020202020746869732E78724C6162656C332E54657874466F726D6174537472696E67203D20227B303A24302E30307D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250696374757265426F78310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250696374757265426F78312E447069203D20323534463B0D0A202020202020202020202020746869732E787250696374757265426F78312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C2022496D616765536F75726365222C20225B426172636F6465496D6167655D22297D293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742835332E3838313831462C203133382E3030363646293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4E616D65203D2022787250696374757265426F7831223B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A696E67203D20446576457870726573732E587472615072696E74696E672E496D61676553697A654D6F64652E4175746F53697A653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B436F6D70616E794E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C203131462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742830462C203046293B0D0A202020202020202020202020746869732E78724C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C312E4E616D65203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283438352E36363635462C2036392E303033333146293B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E54657874203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20626F74746F6D4D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E4E616D65203D2022626F74746F6D4D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2044657461696C0D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E44657461696C2E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E44657461696C2E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E44657461696C2E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250616E656C317D293B0D0A202020202020202020202020746869732E44657461696C2E447069203D20323534463B0D0A202020202020202020202020746869732E44657461696C2E48656967687446203D20343030463B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F676574686572203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F6765746865725769746844657461696C5265706F727473203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E5769647468203D20363030463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4C61796F7574203D20446576457870726573732E587472615072696E74696E672E436F6C756D6E4C61796F75742E4163726F73735468656E446F776E3B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4D6F6465203D20446576457870726573732E587472615265706F7274732E55492E4D756C7469436F6C756D6E4D6F64652E557365436F6C756D6E436F756E743B0D0A202020202020202020202020746869732E44657461696C2E4E616D65203D202244657461696C223B0D0A202020202020202020202020746869732E44657461696C2E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F704C6566743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20746F704D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E746F704D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E4E616D65203D2022746F704D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283139342E39313735462C203331332E3634303246293B0D0A202020202020202020202020746869732E6C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C312E4E616D65203D20226C6162656C31223B0D0A202020202020202020202020746869732E6C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E6C6162656C312E54657874203D2022D8AAD8A7D8B1D98AD8AE20D8A7D984D8A5D986D8AAD987D8A7D8A1223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283331302E39323231462C203235392E3539303246293B0D0A202020202020202020202020746869732E6C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C322E4E616D65203D20226C6162656C32223B0D0A202020202020202020202020746869732E6C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283135382E35363338462C2035382E343230303146293B0D0A202020202020202020202020746869732E6C6162656C322E54657874203D2022D8AAD8A7D8B1D98AD8AE20D8A7D984D8A5D986D8AAD8A7D8AC223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B4461746545787069726174655D22297D293B0D0A202020202020202020202020746869732E6C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283235312E35353836462C203230312E3137303246293B0D0A202020202020202020202020746869732E6C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C332E4E616D65203D20226C6162656C33223B0D0A202020202020202020202020746869732E6C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E6C6162656C332E54657874203D20226C6162656C34223B0D0A202020202020202020202020746869732E6C6162656C332E54657874466F726D6174537472696E67203D20227B303A647D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C340D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C342E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C342E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B4461746550726F64756374696F6E5D22297D293B0D0A202020202020202020202020746869732E6C6162656C342E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283135342E34393333462C203235392E3539303246293B0D0A202020202020202020202020746869732E6C6162656C342E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C342E4E616D65203D20226C6162656C34223B0D0A202020202020202020202020746869732E6C6162656C342E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C342E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E6C6162656C342E54657874203D20226C6162656C33223B0D0A202020202020202020202020746869732E6C6162656C342E54657874466F726D6174537472696E67203D20227B303A647D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C350D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C352E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E6C6162656C352E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C352E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B4E6F7465735D22297D293B0D0A202020202020202020202020746869732E6C6162656C352E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E313234383035462C203133302E3036393146293B0D0A202020202020202020202020746869732E6C6162656C352E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C352E4E616D65203D20226C6162656C35223B0D0A202020202020202020202020746869732E6C6162656C352E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C352E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283438312E35343137462C2036362E333537343746293B0D0A202020202020202020202020746869732E6C6162656C352E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C352E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C352E54657874203D20226C6162656C32223B0D0A202020202020202020202020746869732E6C6162656C352E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C360D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C362E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E6C6162656C362E426F726465725769647468203D2032463B0D0A202020202020202020202020746869732E6C6162656C362E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C362E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C2039462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E6C6162656C362E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742838312E3633353531462C203238342E3535383746293B0D0A202020202020202020202020746869732E6C6162656C362E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C362E4E616D65203D20226C6162656C36223B0D0A202020202020202020202020746869732E6C6162656C362E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C362E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2036392E303033333646293B0D0A202020202020202020202020746869732E6C6162656C362E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C362E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C362E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C362E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C362E54657874203D2022D8A7D984D8B3D8B9D8B120D8B4D8A7D985D98420D8A7D984D8B6D8B1D98AD8A8D987223B0D0A202020202020202020202020746869732E6C6162656C362E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F207274705F426172636F64650D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E42616E64732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E42616E645B5D207B0D0A202020202020202020202020202020202020202020202020746869732E44657461696C2C0D0A202020202020202020202020202020202020202020202020746869732E746F704D617267696E42616E64312C0D0A202020202020202020202020202020202020202020202020746869732E626F74746F6D4D617267696E42616E64317D293B0D0A202020202020202020202020746869732E426F726465725769647468203D2030463B0D0A202020202020202020202020746869732E436F6D706F6E656E7453746F726167652E41646452616E6765286E65772053797374656D2E436F6D706F6E656E744D6F64656C2E49436F6D706F6E656E745B5D207B0D0A202020202020202020202020202020202020202020202020746869732E62696E64696E67536F75726365317D293B0D0A202020202020202020202020746869732E447069203D20323534463B0D0A202020202020202020202020746869732E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E373546293B0D0A202020202020202020202020746869732E4D617267696E73203D206E65772053797374656D2E44726177696E672E5072696E74696E672E4D617267696E7328302C20302C20302C2030293B0D0A202020202020202020202020746869732E4E616D65203D20227274705F426172636F6465223B0D0A202020202020202020202020746869732E50616765486569676874203D203430303B0D0A202020202020202020202020746869732E506167655769647468203D203530303B0D0A202020202020202020202020746869732E50617065724B696E64203D2053797374656D2E44726177696E672E5072696E74696E672E50617065724B696E642E437573746F6D3B0D0A202020202020202020202020746869732E5265706F72745072696E744F7074696F6E732E44657461696C436F756E744F6E456D70747944617461536F75726365203D203134343B0D0A202020202020202020202020746869732E5265706F7274556E6974203D20446576457870726573732E587472615265706F7274732E55492E5265706F7274556E69742E54656E7468734F66414D696C6C696D657465723B0D0A202020202020202020202020746869732E53686F775072696E744D617267696E735761726E696E67203D2066616C73653B0D0A202020202020202020202020746869732E536E61704772696453697A65203D2033312E3735463B0D0A202020202020202020202020746869732E5374796C65536865657450617468203D2022223B0D0A202020202020202020202020746869732E56657273696F6E203D202231392E32223B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E456E64496E697428293B0D0A20202020202020207D0D0A202020207D0D0A7D0D0A, 0)
INSERT [dbo].[BarcodeTemplates] ([ID], [Name], [Template], [IsDefault]) VALUES (53, N'جديد1', 0x2F2F2F203C585254797065496E666F3E0D0A2F2F2F2020203C417373656D626C7946756C6C4E616D653E4163636F756E74696E674D532C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C3C2F417373656D626C7946756C6C4E616D653E0D0A2F2F2F2020203C417373656D626C794C6F636174696F6E3E443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E6578653C2F417373656D626C794C6F636174696F6E3E0D0A2F2F2F2020203C547970654E616D653E4163636F756E74696E674D532E5265706F7274732E7274705F426172636F64653C2F547970654E616D653E0D0A2F2F2F2020203C4C6F63616C697A6174696F6E3E61722D41523C2F4C6F63616C697A6174696F6E3E0D0A2F2F2F2020203C56657273696F6E3E31392E323C2F56657273696F6E3E0D0A2F2F2F2020203C5265666572656E6365733E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E65786522202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C6C6F67346E65742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6E66696775726174696F6E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E436F6E66696775726174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F72655C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4E756D65726963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E4E756D65726963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174615C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5472616E73616374696F6E735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E5472616E73616374696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E456E746572707269736553657276696365735C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E456E746572707269736553657276696365732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E43616368696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E52756E74696D652E43616368696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5765625C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E5765622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E57696E646F77732E466F726D735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E57696E646F77732E466F726D732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4163636573736962696C6974795C76342E305F342E302E302E305F5F623033663566376631316435306133615C4163636573736962696C6974792E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174612E4F7261636C65436C69656E745C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4F7261636C65436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E672E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C55494175746F6D6174696F6E436C69656E745C76342E305F342E302E302E305F5F333162663338353661643336346533355C55494175746F6D6174696F6E436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C57696E646F7773426173655C76342E305F342E302E302E305F5F333162663338353661643336346533355C57696E646F7773426173652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E58616D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E58616D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C50726573656E746174696F6E436F72655C76342E305F342E302E302E305F5F333162663338353661643336346533355C50726573656E746174696F6E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614C61796F75742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614C61796F75742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261456469746F72732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261456469746F72732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E446174612E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E53657269616C697A6174696F6E5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E52756E74696D652E53657269616C697A6174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E536572766963654D6F64656C2E496E7465726E616C735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E536572766963654D6F64656C2E496E7465726E616C732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C534D446961676E6F73746963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C534D446961676E6F73746963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C2E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615072696E74696E672E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615072696E74696E672E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261426172732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261426172732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261547265654C6973742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261547265654C6973742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446F63732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446F63732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C456E746974794672616D65776F726B2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C426172636F64654C69622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E735C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261566572746963616C477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261566572746963616C477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446174614163636573732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446174614163636573732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614E61764261722E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614E61764261722E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E57697A6172645C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E57697A6172642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E436F6E6E656374696F6E496E666F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F457874656E6465642E646C6C22202F3E0D0A2F2F2F2020203C2F5265666572656E6365733E0D0A2F2F2F2020203C5265736F75726365733E0D0A2F2F2F20202020203C5265736F75726365204E616D653D22587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F6465223E0D0A2F2F2F207A73727676674541414143524141414162464E356333526C625335535A584E7664584A6A5A584D75556D567A62335679593256535A57466B5A5849734947317A5932397962476C694C4342575A584A7A61573975505451754D4334774C6A417349454E3162485231636D5539626D563164484A68624377675548566962476C6A53325635564739725A573439596A63335954566A4E5459784F544D305A5441344F534E5465584E305A573075556D567A623356795932567A4C6C4A31626E5270625756535A584E7664584A6A5A564E6C64414941414141414141414141414141414642425246424252464330414141413C2F5265736F757263653E0D0A2F2F2F2020203C2F5265736F75726365733E0D0A2F2F2F203C2F585254797065496E666F3E0D0A6E616D65737061636520587472615265706F727453657269616C697A6174696F6E207B0D0A202020200D0A202020207075626C696320636C617373207274705F426172636F6465203A20446576457870726573732E587472615265706F7274732E55492E587472615265706F7274207B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E44657461696C42616E642044657461696C3B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250616E656C20787250616E656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7820787250696374757265426F78313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C313B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6420626F74746F6D4D617267696E42616E64313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6420746F704D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572205F7265736F75726365733B0D0A20202020202020207072697661746520737472696E67205F7265736F75726365537472696E673B0D0A20202020202020207075626C6963207274705F426172636F64652829207B0D0A202020202020202020202020746869732E5F7265736F75726365537472696E67203D20446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E616765722E4765745265736F75726365466F722822587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F646522293B0D0A202020202020202020202020746869732E496E697469616C697A65436F6D706F6E656E7428293B0D0A20202020202020207D0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572207265736F7572636573207B0D0A202020202020202020202020676574207B0D0A20202020202020202020202020202020696620285F7265736F7572636573203D3D206E756C6C29207B0D0A2020202020202020202020202020202020202020746869732E5F7265736F7572636573203D206E657720446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E6167657228746869732E5F7265736F75726365537472696E67293B0D0A202020202020202020202020202020207D0D0A2020202020202020202020202020202072657475726E20746869732E5F7265736F75726365733B0D0A2020202020202020202020207D0D0A20202020202020207D0D0A20202020202020207072697661746520766F696420496E697469616C697A65436F6D706F6E656E742829207B0D0A202020202020202020202020746869732E44657461696C203D206E657720446576457870726573732E587472615265706F7274732E55492E44657461696C42616E6428293B0D0A202020202020202020202020746869732E787250696374757265426F7831203D206E657720446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7828293B0D0A202020202020202020202020746869732E78724C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E62696E64696E67536F7572636531203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E78724C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E78724C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6428293B0D0A202020202020202020202020746869732E746F704D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6428293B0D0A202020202020202020202020746869732E787250616E656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E585250616E656C28293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E426567696E496E697428293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2044657461696C0D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E44657461696C2E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E44657461696C2E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E44657461696C2E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250616E656C317D293B0D0A202020202020202020202020746869732E44657461696C2E447069203D20323534463B0D0A202020202020202020202020746869732E44657461696C2E48656967687446203D20333030463B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F676574686572203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F6765746865725769746844657461696C5265706F727473203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E5769647468203D20363030463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4C61796F7574203D20446576457870726573732E587472615072696E74696E672E436F6C756D6E4C61796F75742E4163726F73735468656E446F776E3B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4D6F6465203D20446576457870726573732E587472615265706F7274732E55492E4D756C7469436F6C756D6E4D6F64652E557365436F6C756D6E436F756E743B0D0A202020202020202020202020746869732E44657461696C2E4E616D65203D202244657461696C223B0D0A202020202020202020202020746869732E44657461696C2E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F704C6566743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250696374757265426F78310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250696374757265426F78312E447069203D20323534463B0D0A202020202020202020202020746869732E787250696374757265426F78312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C2022496D616765536F75726365222C20225B426172636F6465496D6167655D22297D293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742831392E3438353937462C203133352E3537323546293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4E616D65203D2022787250696374757265426F7831223B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A696E67203D20446576457870726573732E587472615072696E74696E672E496D61676553697A654D6F64652E4175746F53697A653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B436F6D70616E794E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C20392E373735313632452D303646293B0D0A202020202020202020202020746869732E78724C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C312E4E616D65203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383346293B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E54657874203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365312E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C322E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726F647563744E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C322E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C322E4E616D65203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E54657874203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726963655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C2039302E333831363846293B0D0A202020202020202020202020746869732E78724C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C332E4E616D65203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C332E54657874203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7052696768743B0D0A202020202020202020202020746869732E78724C6162656C332E54657874466F726D6174537472696E67203D20227B303A24302E30307D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20626F74746F6D4D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E4E616D65203D2022626F74746F6D4D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20746F704D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E746F704D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E4E616D65203D2022746F704D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250616E656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250616E656C312E416E63686F72486F72697A6F6E74616C203D202828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E4C656674207C20446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E52696768742929293B0D0A202020202020202020202020746869732E787250616E656C312E416E63686F72566572746963616C203D202828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E546F70207C20446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E426F74746F6D2929293B0D0A202020202020202020202020746869732E787250616E656C312E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E787250616E656C312E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E787250616E656C312E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250696374757265426F78312C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C317D293B0D0A202020202020202020202020746869732E787250616E656C312E447069203D20323534463B0D0A202020202020202020202020746869732E787250616E656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428352E353134303336462C20322E39333938313446293B0D0A202020202020202020202020746869732E787250616E656C312E4E616D65203D2022787250616E656C31223B0D0A202020202020202020202020746869732E787250616E656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C203238382E3935383346293B0D0A202020202020202020202020746869732E787250616E656C312E536E61704C696E6550616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F207274705F426172636F64650D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E42616E64732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E42616E645B5D207B0D0A202020202020202020202020202020202020202020202020746869732E44657461696C2C0D0A202020202020202020202020202020202020202020202020746869732E746F704D617267696E42616E64312C0D0A202020202020202020202020202020202020202020202020746869732E626F74746F6D4D617267696E42616E64317D293B0D0A202020202020202020202020746869732E426F726465725769647468203D2030463B0D0A202020202020202020202020746869732E436F6D706F6E656E7453746F726167652E41646452616E6765286E65772053797374656D2E436F6D706F6E656E744D6F64656C2E49436F6D706F6E656E745B5D207B0D0A202020202020202020202020202020202020202020202020746869732E62696E64696E67536F75726365317D293B0D0A202020202020202020202020746869732E447069203D20323534463B0D0A202020202020202020202020746869732E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E373546293B0D0A202020202020202020202020746869732E4D617267696E73203D206E65772053797374656D2E44726177696E672E5072696E74696E672E4D617267696E7328302C20302C20302C2030293B0D0A202020202020202020202020746869732E4E616D65203D20227274705F426172636F6465223B0D0A202020202020202020202020746869732E50616765486569676874203D203330303B0D0A202020202020202020202020746869732E506167655769647468203D203430303B0D0A202020202020202020202020746869732E50617065724B696E64203D2053797374656D2E44726177696E672E5072696E74696E672E50617065724B696E642E437573746F6D3B0D0A202020202020202020202020746869732E5265706F72745072696E744F7074696F6E732E44657461696C436F756E744F6E456D70747944617461536F75726365203D203134343B0D0A202020202020202020202020746869732E5265706F7274556E6974203D20446576457870726573732E587472615265706F7274732E55492E5265706F7274556E69742E54656E7468734F66414D696C6C696D657465723B0D0A202020202020202020202020746869732E53686F775072696E744D617267696E735761726E696E67203D2066616C73653B0D0A202020202020202020202020746869732E536E61704772696453697A65203D2033312E3735463B0D0A202020202020202020202020746869732E56657273696F6E203D202231392E32223B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E456E64496E697428293B0D0A20202020202020207D0D0A202020207D0D0A7D0D0A, 0)
INSERT [dbo].[BarcodeTemplates] ([ID], [Name], [Template], [IsDefault]) VALUES (68, N'نسخ', 0x2F2F2F203C585254797065496E666F3E0D0A2F2F2F2020203C417373656D626C7946756C6C4E616D653E4163636F756E74696E674D532C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C3C2F417373656D626C7946756C6C4E616D653E0D0A2F2F2F2020203C417373656D626C794C6F636174696F6E3E443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E6578653C2F417373656D626C794C6F636174696F6E3E0D0A2F2F2F2020203C547970654E616D653E4163636F756E74696E674D532E5265706F7274732E7274705F426172636F64653C2F547970654E616D653E0D0A2F2F2F2020203C4C6F63616C697A6174696F6E3E61722D41523C2F4C6F63616C697A6174696F6E3E0D0A2F2F2F2020203C56657273696F6E3E31392E323C2F56657273696F6E3E0D0A2F2F2F2020203C5265666572656E6365733E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E65786522202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C6C6F67346E65742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6E66696775726174696F6E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E436F6E66696775726174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F72655C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4E756D65726963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E4E756D65726963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174615C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5472616E73616374696F6E735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E5472616E73616374696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E456E746572707269736553657276696365735C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E456E746572707269736553657276696365732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E43616368696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E52756E74696D652E43616368696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5765625C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E5765622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E57696E646F77732E466F726D735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E57696E646F77732E466F726D732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4163636573736962696C6974795C76342E305F342E302E302E305F5F623033663566376631316435306133615C4163636573736962696C6974792E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174612E4F7261636C65436C69656E745C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4F7261636C65436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E672E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C55494175746F6D6174696F6E436C69656E745C76342E305F342E302E302E305F5F333162663338353661643336346533355C55494175746F6D6174696F6E436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C57696E646F7773426173655C76342E305F342E302E302E305F5F333162663338353661643336346533355C57696E646F7773426173652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E58616D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E58616D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C50726573656E746174696F6E436F72655C76342E305F342E302E302E305F5F333162663338353661643336346533355C50726573656E746174696F6E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614C61796F75742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614C61796F75742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261456469746F72732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261456469746F72732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E446174612E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E53657269616C697A6174696F6E5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E52756E74696D652E53657269616C697A6174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E536572766963654D6F64656C2E496E7465726E616C735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E536572766963654D6F64656C2E496E7465726E616C732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C534D446961676E6F73746963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C534D446961676E6F73746963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C2E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615072696E74696E672E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615072696E74696E672E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261426172732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261426172732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261547265654C6973742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261547265654C6973742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4D616E6167656D656E745C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E4D616E6167656D656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446F63732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446F63732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C456E746974794672616D65776F726B2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C426172636F64654C69622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E735C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5874726152696368456469742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5874726152696368456469742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E496D616765732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E496D616765732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261566572746963616C477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261566572746963616C477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446174614163636573732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446174614163636573732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614E61764261722E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614E61764261722E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E57697A6172645C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E57697A6172642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E436F6E6E656374696F6E496E666F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F457874656E6465642E646C6C22202F3E0D0A2F2F2F2020203C2F5265666572656E6365733E0D0A2F2F2F2020203C5265736F75726365733E0D0A2F2F2F20202020203C5265736F75726365204E616D653D22587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F6465223E0D0A2F2F2F207A73727676674541414143524141414162464E356333526C625335535A584E7664584A6A5A584D75556D567A62335679593256535A57466B5A5849734947317A5932397962476C694C4342575A584A7A61573975505451754D4334774C6A417349454E3162485231636D5539626D563164484A68624377675548566962476C6A53325635564739725A573439596A63335954566A4E5459784F544D305A5441344F534E5465584E305A573075556D567A623356795932567A4C6C4A31626E5270625756535A584E7664584A6A5A564E6C64414941414141414141414141414141414642425246424252464330414141413C2F5265736F757263653E0D0A2F2F2F2020203C2F5265736F75726365733E0D0A2F2F2F203C2F585254797065496E666F3E0D0A6E616D65737061636520587472615265706F727453657269616C697A6174696F6E207B0D0A202020200D0A202020207075626C696320636C617373207274705F426172636F6465203A20446576457870726573732E587472615265706F7274732E55492E587472615265706F7274207B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7820787250696374757265426F78313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6420746F704D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E44657461696C42616E642044657461696C3B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250616E656C20787250616E656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6420626F74746F6D4D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572205F7265736F75726365733B0D0A20202020202020207072697661746520737472696E67205F7265736F75726365537472696E673B0D0A20202020202020207075626C6963207274705F426172636F64652829207B0D0A202020202020202020202020746869732E5F7265736F75726365537472696E67203D20446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E616765722E4765745265736F75726365466F722822587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F646522293B0D0A202020202020202020202020746869732E496E697469616C697A65436F6D706F6E656E7428293B0D0A20202020202020207D0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572207265736F7572636573207B0D0A202020202020202020202020676574207B0D0A20202020202020202020202020202020696620285F7265736F7572636573203D3D206E756C6C29207B0D0A2020202020202020202020202020202020202020746869732E5F7265736F7572636573203D206E657720446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E6167657228746869732E5F7265736F75726365537472696E67293B0D0A202020202020202020202020202020207D0D0A2020202020202020202020202020202072657475726E20746869732E5F7265736F75726365733B0D0A2020202020202020202020207D0D0A20202020202020207D0D0A20202020202020207072697661746520766F696420496E697469616C697A65436F6D706F6E656E742829207B0D0A202020202020202020202020746869732E78724C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E787250696374757265426F7831203D206E657720446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7828293B0D0A202020202020202020202020746869732E746F704D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6428293B0D0A202020202020202020202020746869732E62696E64696E67536F7572636531203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E44657461696C203D206E657720446576457870726573732E587472615265706F7274732E55492E44657461696C42616E6428293B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6428293B0D0A202020202020202020202020746869732E787250616E656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E585250616E656C28293B0D0A202020202020202020202020746869732E78724C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E78724C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E426567696E496E697428293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B436F6D70616E794E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C20392E373735313632452D303646293B0D0A202020202020202020202020746869732E78724C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C312E4E616D65203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383346293B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E54657874203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250696374757265426F78310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250696374757265426F78312E447069203D20323534463B0D0A202020202020202020202020746869732E787250696374757265426F78312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C2022496D616765536F75726365222C20225B426172636F6465496D6167655D22297D293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742831392E3438353937462C203133352E3537323546293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4E616D65203D2022787250696374757265426F7831223B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A696E67203D20446576457870726573732E587472615072696E74696E672E496D61676553697A654D6F64652E4175746F53697A653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20746F704D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E746F704D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E4E616D65203D2022746F704D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365312E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2044657461696C0D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E44657461696C2E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E44657461696C2E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E44657461696C2E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250616E656C317D293B0D0A202020202020202020202020746869732E44657461696C2E447069203D20323534463B0D0A202020202020202020202020746869732E44657461696C2E48656967687446203D20333030463B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F676574686572203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F6765746865725769746844657461696C5265706F727473203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E5769647468203D20363030463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4C61796F7574203D20446576457870726573732E587472615072696E74696E672E436F6C756D6E4C61796F75742E4163726F73735468656E446F776E3B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4D6F6465203D20446576457870726573732E587472615265706F7274732E55492E4D756C7469436F6C756D6E4D6F64652E557365436F6C756D6E436F756E743B0D0A202020202020202020202020746869732E44657461696C2E4E616D65203D202244657461696C223B0D0A202020202020202020202020746869732E44657461696C2E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F704C6566743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20626F74746F6D4D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E4E616D65203D2022626F74746F6D4D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250616E656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250616E656C312E416E63686F72486F72697A6F6E74616C203D202828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E4C656674207C20446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E52696768742929293B0D0A202020202020202020202020746869732E787250616E656C312E416E63686F72566572746963616C203D202828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E546F70207C20446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E426F74746F6D2929293B0D0A202020202020202020202020746869732E787250616E656C312E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E787250616E656C312E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E787250616E656C312E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250696374757265426F78312C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C317D293B0D0A202020202020202020202020746869732E787250616E656C312E447069203D20323534463B0D0A202020202020202020202020746869732E787250616E656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428352E353134303336462C20322E39333938313446293B0D0A202020202020202020202020746869732E787250616E656C312E4E616D65203D2022787250616E656C31223B0D0A202020202020202020202020746869732E787250616E656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C203238382E3935383346293B0D0A202020202020202020202020746869732E787250616E656C312E536E61704C696E6550616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726963655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C2039302E333831363846293B0D0A202020202020202020202020746869732E78724C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C332E4E616D65203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C332E54657874203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7052696768743B0D0A202020202020202020202020746869732E78724C6162656C332E54657874466F726D6174537472696E67203D20227B303A24302E30307D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C322E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726F647563744E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C322E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C322E4E616D65203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E54657874203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F207274705F426172636F64650D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E42616E64732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E42616E645B5D207B0D0A202020202020202020202020202020202020202020202020746869732E44657461696C2C0D0A202020202020202020202020202020202020202020202020746869732E746F704D617267696E42616E64312C0D0A202020202020202020202020202020202020202020202020746869732E626F74746F6D4D617267696E42616E64317D293B0D0A202020202020202020202020746869732E426F726465725769647468203D2030463B0D0A202020202020202020202020746869732E436F6D706F6E656E7453746F726167652E41646452616E6765286E65772053797374656D2E436F6D706F6E656E744D6F64656C2E49436F6D706F6E656E745B5D207B0D0A202020202020202020202020202020202020202020202020746869732E62696E64696E67536F75726365317D293B0D0A202020202020202020202020746869732E447069203D20323534463B0D0A202020202020202020202020746869732E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E373546293B0D0A202020202020202020202020746869732E4D617267696E73203D206E65772053797374656D2E44726177696E672E5072696E74696E672E4D617267696E7328302C20302C20302C2030293B0D0A202020202020202020202020746869732E4E616D65203D20227274705F426172636F6465223B0D0A202020202020202020202020746869732E50616765486569676874203D203330303B0D0A202020202020202020202020746869732E506167655769647468203D203430303B0D0A202020202020202020202020746869732E50617065724B696E64203D2053797374656D2E44726177696E672E5072696E74696E672E50617065724B696E642E437573746F6D3B0D0A202020202020202020202020746869732E5265706F72745072696E744F7074696F6E732E44657461696C436F756E744F6E456D70747944617461536F75726365203D203134343B0D0A202020202020202020202020746869732E5265706F7274556E6974203D20446576457870726573732E587472615265706F7274732E55492E5265706F7274556E69742E54656E7468734F66414D696C6C696D657465723B0D0A202020202020202020202020746869732E53686F775072696E744D617267696E735761726E696E67203D2066616C73653B0D0A202020202020202020202020746869732E536E61704772696453697A65203D2033312E3735463B0D0A202020202020202020202020746869732E56657273696F6E203D202231392E32223B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E456E64496E697428293B0D0A20202020202020207D0D0A202020207D0D0A7D0D0A, 0)
INSERT [dbo].[BarcodeTemplates] ([ID], [Name], [Template], [IsDefault]) VALUES (71, N'22', 0x2F2F2F203C585254797065496E666F3E0D0A2F2F2F2020203C417373656D626C7946756C6C4E616D653E4163636F756E74696E674D532C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C3C2F417373656D626C7946756C6C4E616D653E0D0A2F2F2F2020203C417373656D626C794C6F636174696F6E3E443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E6578653C2F417373656D626C794C6F636174696F6E3E0D0A2F2F2F2020203C547970654E616D653E4163636F756E74696E674D532E5265706F7274732E7274705F426172636F64653C2F547970654E616D653E0D0A2F2F2F2020203C4C6F63616C697A6174696F6E3E61722D41523C2F4C6F63616C697A6174696F6E3E0D0A2F2F2F2020203C56657273696F6E3E31392E323C2F56657273696F6E3E0D0A2F2F2F2020203C5265666572656E6365733E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E65786522202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C6C6F67346E65742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6E66696775726174696F6E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E436F6E66696775726174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F72655C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4E756D65726963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E4E756D65726963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174615C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5472616E73616374696F6E735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E5472616E73616374696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E456E746572707269736553657276696365735C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E456E746572707269736553657276696365732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E43616368696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E52756E74696D652E43616368696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5765625C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E5765622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E57696E646F77732E466F726D735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E57696E646F77732E466F726D732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4163636573736962696C6974795C76342E305F342E302E302E305F5F623033663566376631316435306133615C4163636573736962696C6974792E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174612E4F7261636C65436C69656E745C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4F7261636C65436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E672E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C55494175746F6D6174696F6E436C69656E745C76342E305F342E302E302E305F5F333162663338353661643336346533355C55494175746F6D6174696F6E436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C57696E646F7773426173655C76342E305F342E302E302E305F5F333162663338353661643336346533355C57696E646F7773426173652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E58616D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E58616D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C50726573656E746174696F6E436F72655C76342E305F342E302E302E305F5F333162663338353661643336346533355C50726573656E746174696F6E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614C61796F75742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614C61796F75742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261456469746F72732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261456469746F72732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E446174612E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E53657269616C697A6174696F6E5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E52756E74696D652E53657269616C697A6174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E536572766963654D6F64656C2E496E7465726E616C735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E536572766963654D6F64656C2E496E7465726E616C732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C534D446961676E6F73746963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C534D446961676E6F73746963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C2E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615072696E74696E672E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615072696E74696E672E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261426172732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261426172732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261547265654C6973742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261547265654C6973742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4D616E6167656D656E745C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E4D616E6167656D656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446F63732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446F63732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C456E746974794672616D65776F726B2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C426172636F64654C69622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E735C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5874726152696368456469742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5874726152696368456469742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E496D616765732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E496D616765732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261566572746963616C477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261566572746963616C477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446174614163636573732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446174614163636573732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614E61764261722E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614E61764261722E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E57697A6172645C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E57697A6172642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E436F6E6E656374696F6E496E666F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F457874656E6465642E646C6C22202F3E0D0A2F2F2F2020203C2F5265666572656E6365733E0D0A2F2F2F2020203C5265736F75726365733E0D0A2F2F2F20202020203C5265736F75726365204E616D653D22587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F6465223E0D0A2F2F2F207A73727676674541414143524141414162464E356333526C625335535A584E7664584A6A5A584D75556D567A62335679593256535A57466B5A5849734947317A5932397962476C694C4342575A584A7A61573975505451754D4334774C6A417349454E3162485231636D5539626D563164484A68624377675548566962476C6A53325635564739725A573439596A63335954566A4E5459784F544D305A5441344F534E5465584E305A573075556D567A623356795932567A4C6C4A31626E5270625756535A584E7664584A6A5A564E6C64414941414141414141414141414141414642425246424252464330414141413C2F5265736F757263653E0D0A2F2F2F2020203C2F5265736F75726365733E0D0A2F2F2F203C2F585254797065496E666F3E0D0A6E616D65737061636520587472615265706F727453657269616C697A6174696F6E207B0D0A202020200D0A202020207075626C696320636C617373207274705F426172636F6465203A20446576457870726573732E587472615265706F7274732E55492E587472615265706F7274207B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E44657461696C42616E642044657461696C3B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250616E656C20787250616E656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7820787250696374757265426F78313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6420746F704D617267696E42616E64313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6420626F74746F6D4D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365313B0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572205F7265736F75726365733B0D0A20202020202020207072697661746520737472696E67205F7265736F75726365537472696E673B0D0A20202020202020207075626C6963207274705F426172636F64652829207B0D0A202020202020202020202020746869732E5F7265736F75726365537472696E67203D20446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E616765722E4765745265736F75726365466F722822587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F646522293B0D0A202020202020202020202020746869732E496E697469616C697A65436F6D706F6E656E7428293B0D0A20202020202020207D0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572207265736F7572636573207B0D0A202020202020202020202020676574207B0D0A20202020202020202020202020202020696620285F7265736F7572636573203D3D206E756C6C29207B0D0A2020202020202020202020202020202020202020746869732E5F7265736F7572636573203D206E657720446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E6167657228746869732E5F7265736F75726365537472696E67293B0D0A202020202020202020202020202020207D0D0A2020202020202020202020202020202072657475726E20746869732E5F7265736F75726365733B0D0A2020202020202020202020207D0D0A20202020202020207D0D0A20202020202020207072697661746520766F696420496E697469616C697A65436F6D706F6E656E742829207B0D0A202020202020202020202020746869732E78724C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E78724C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E44657461696C203D206E657720446576457870726573732E587472615265706F7274732E55492E44657461696C42616E6428293B0D0A202020202020202020202020746869732E746F704D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6428293B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6428293B0D0A202020202020202020202020746869732E78724C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E62696E64696E67536F7572636531203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E787250616E656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E585250616E656C28293B0D0A202020202020202020202020746869732E787250696374757265426F7831203D206E657720446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7828293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E426567696E496E697428293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C322E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726F647563744E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C322E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C322E4E616D65203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E54657874203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726963655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C2039302E333831363846293B0D0A202020202020202020202020746869732E78724C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C332E4E616D65203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383446293B0D0A202020202020202020202020746869732E78724C6162656C332E54657874203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7052696768743B0D0A202020202020202020202020746869732E78724C6162656C332E54657874466F726D6174537472696E67203D20227B303A24302E30307D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2044657461696C0D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E44657461696C2E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E44657461696C2E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E44657461696C2E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250616E656C317D293B0D0A202020202020202020202020746869732E44657461696C2E447069203D20323534463B0D0A202020202020202020202020746869732E44657461696C2E48656967687446203D20333030463B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F676574686572203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F6765746865725769746844657461696C5265706F727473203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E5769647468203D20363030463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4C61796F7574203D20446576457870726573732E587472615072696E74696E672E436F6C756D6E4C61796F75742E4163726F73735468656E446F776E3B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4D6F6465203D20446576457870726573732E587472615265706F7274732E55492E4D756C7469436F6C756D6E4D6F64652E557365436F6C756D6E436F756E743B0D0A202020202020202020202020746869732E44657461696C2E4E616D65203D202244657461696C223B0D0A202020202020202020202020746869732E44657461696C2E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F704C6566743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20746F704D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E746F704D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E4E616D65203D2022746F704D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20626F74746F6D4D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E4E616D65203D2022626F74746F6D4D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B436F6D70616E794E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E3735462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428342E373638333732452D3037462C20392E373735313632452D303646293B0D0A202020202020202020202020746869732E78724C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C312E4E616D65203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C2034352E313930383346293B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E54657874203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365312E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250616E656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250616E656C312E416E63686F72486F72697A6F6E74616C203D202828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E4C656674207C20446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E52696768742929293B0D0A202020202020202020202020746869732E787250616E656C312E416E63686F72566572746963616C203D202828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E546F70207C20446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E426F74746F6D2929293B0D0A202020202020202020202020746869732E787250616E656C312E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E787250616E656C312E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E787250616E656C312E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250696374757265426F78312C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C317D293B0D0A202020202020202020202020746869732E787250616E656C312E447069203D20323534463B0D0A202020202020202020202020746869732E787250616E656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428352E353134303336462C20322E39333938313446293B0D0A202020202020202020202020746869732E787250616E656C312E4E616D65203D2022787250616E656C31223B0D0A202020202020202020202020746869732E787250616E656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283338352E36363635462C203238382E3935383346293B0D0A202020202020202020202020746869732E787250616E656C312E536E61704C696E6550616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250696374757265426F78310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250696374757265426F78312E447069203D20323534463B0D0A202020202020202020202020746869732E787250696374757265426F78312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C2022496D616765536F75726365222C20225B426172636F6465496D6167655D22297D293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742831392E3438353937462C203133352E3537323546293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4E616D65203D2022787250696374757265426F7831223B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2035382E343246293B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A696E67203D20446576457870726573732E587472615072696E74696E672E496D61676553697A654D6F64652E4175746F53697A653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F207274705F426172636F64650D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E42616E64732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E42616E645B5D207B0D0A202020202020202020202020202020202020202020202020746869732E44657461696C2C0D0A202020202020202020202020202020202020202020202020746869732E746F704D617267696E42616E64312C0D0A202020202020202020202020202020202020202020202020746869732E626F74746F6D4D617267696E42616E64317D293B0D0A202020202020202020202020746869732E426F726465725769647468203D2030463B0D0A202020202020202020202020746869732E436F6D706F6E656E7453746F726167652E41646452616E6765286E65772053797374656D2E436F6D706F6E656E744D6F64656C2E49436F6D706F6E656E745B5D207B0D0A202020202020202020202020202020202020202020202020746869732E62696E64696E67536F75726365317D293B0D0A202020202020202020202020746869732E447069203D20323534463B0D0A202020202020202020202020746869732E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E373546293B0D0A202020202020202020202020746869732E4D617267696E73203D206E65772053797374656D2E44726177696E672E5072696E74696E672E4D617267696E7328302C20302C20302C2030293B0D0A202020202020202020202020746869732E4E616D65203D20227274705F426172636F6465223B0D0A202020202020202020202020746869732E50616765486569676874203D203330303B0D0A202020202020202020202020746869732E506167655769647468203D203430303B0D0A202020202020202020202020746869732E50617065724B696E64203D2053797374656D2E44726177696E672E5072696E74696E672E50617065724B696E642E437573746F6D3B0D0A202020202020202020202020746869732E5265706F72745072696E744F7074696F6E732E44657461696C436F756E744F6E456D70747944617461536F75726365203D203134343B0D0A202020202020202020202020746869732E5265706F7274556E6974203D20446576457870726573732E587472615265706F7274732E55492E5265706F7274556E69742E54656E7468734F66414D696C6C696D657465723B0D0A202020202020202020202020746869732E53686F775072696E744D617267696E735761726E696E67203D2066616C73653B0D0A202020202020202020202020746869732E536E61704772696453697A65203D2033312E3735463B0D0A202020202020202020202020746869732E56657273696F6E203D202231392E32223B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E456E64496E697428293B0D0A20202020202020207D0D0A202020207D0D0A7D0D0A, 0)
INSERT [dbo].[BarcodeTemplates] ([ID], [Name], [Template], [IsDefault]) VALUES (73, N'نموذج 4*5 ضريبه', 0x2F2F2F203C585254797065496E666F3E0D0A2F2F2F2020203C417373656D626C7946756C6C4E616D653E4163636F756E74696E674D532C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C3C2F417373656D626C7946756C6C4E616D653E0D0A2F2F2F2020203C417373656D626C794C6F636174696F6E3E443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E6578653C2F417373656D626C794C6F636174696F6E3E0D0A2F2F2F2020203C547970654E616D653E4163636F756E74696E674D532E5265706F7274732E7274705F426172636F64653C2F547970654E616D653E0D0A2F2F2F2020203C4C6F63616C697A6174696F6E3E61722D41523C2F4C6F63616C697A6174696F6E3E0D0A2F2F2F2020203C56657273696F6E3E31392E323C2F56657273696F6E3E0D0A2F2F2F2020203C5265666572656E6365733E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4163636F756E74696E674D532E65786522202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C6C6F67346E65742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6E66696775726174696F6E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E436F6E66696775726174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F72655C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4E756D65726963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E4E756D65726963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174615C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5472616E73616374696F6E735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E5472616E73616374696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E456E746572707269736553657276696365735C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E456E746572707269736553657276696365732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E43616368696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E52756E74696D652E43616368696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E675C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E5765625C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E5765622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E57696E646F77732E466F726D735C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E57696E646F77732E466F726D732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C4163636573736962696C6974795C76342E305F342E302E302E305F5F623033663566376631316435306133615C4163636573736962696C6974792E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C53797374656D2E446174612E4F7261636C65436C69656E745C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4F7261636C65436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E44726177696E672E44657369676E5C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E44726177696E672E44657369676E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E436F6D706F6E656E744D6F64656C2E44617461416E6E6F746174696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C55494175746F6D6174696F6E436C69656E745C76342E305F342E302E302E305F5F333162663338353661643336346533355C55494175746F6D6174696F6E436C69656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C57696E646F7773426173655C76342E305F342E302E302E305F5F333162663338353661643336346533355C57696E646F7773426173652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E58616D6C5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E58616D6C2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F33325C50726573656E746174696F6E436F72655C76342E305F342E302E302E305F5F333162663338353661643336346533355C50726573656E746174696F6E436F72652E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614C61796F75742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614C61796F75742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261456469746F72732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261456469746F72732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E446174612E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E446174612E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E52756E74696D652E53657269616C697A6174696F6E5C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E52756E74696D652E53657269616C697A6174696F6E2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E536572766963654D6F64656C2E496E7465726E616C735C76342E305F342E302E302E305F5F333162663338353661643336346533355C53797374656D2E536572766963654D6F64656C2E496E7465726E616C732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C534D446961676E6F73746963735C76342E305F342E302E302E305F5F623737613563353631393334653038395C534D446961676E6F73746963732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E586D6C2E4C696E715C76342E305F342E302E302E305F5F623737613563353631393334653038395C53797374656D2E586D6C2E4C696E712E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615072696E74696E672E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615072696E74696E672E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261426172732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261426172732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261547265654C6973742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261547265654C6973742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C53797374656D2E4D616E6167656D656E745C76342E305F342E302E302E305F5F623033663566376631316435306133615C53797374656D2E4D616E6167656D656E742E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446F63732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446F63732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C456E746974794672616D65776F726B2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C426172636F64654C69622E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E735C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472615265706F7274732E7631392E322E457874656E73696F6E732E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5574696C732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5574696C732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E5874726152696368456469742E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E5874726152696368456469742E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E496D616765732E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E496D616765732E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E58747261566572746963616C477269642E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E58747261566572746963616C477269642E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E446174614163636573732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E446174614163636573732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614E61764261722E7631392E325C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614E61764261722E7631392E322E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E57697A6172645C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E57697A6172642E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22433A5C57494E444F57535C4D6963726F736F66742E4E65745C617373656D626C795C4741435F4D53494C5C446576457870726573732E587472614368617274732E7631392E322E55495C76342E305F31392E322E332E305F5F623838643137353464373030653439615C446576457870726573732E587472614368617274732E7631392E322E55492E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E436F6E6E656374696F6E496E666F2E646C6C22202F3E0D0A2F2F2F20202020203C5265666572656E636520506174683D22443A5C4163636F756E74696E675C5461785C4163636F756E74696E6720204D6F68616D6D656420416C2D68656D696172795C4163636F756E74696E674D535C62696E5C52656C656173655C4D6963726F736F66742E53716C5365727665722E536D6F457874656E6465642E646C6C22202F3E0D0A2F2F2F2020203C2F5265666572656E6365733E0D0A2F2F2F2020203C5265736F75726365733E0D0A2F2F2F20202020203C5265736F75726365204E616D653D22587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F6465223E0D0A2F2F2F207A73727676674541414143524141414162464E356333526C625335535A584E7664584A6A5A584D75556D567A62335679593256535A57466B5A5849734947317A5932397962476C694C4342575A584A7A61573975505451754D4334774C6A417349454E3162485231636D5539626D563164484A68624377675548566962476C6A53325635564739725A573439596A63335954566A4E5459784F544D305A5441344F534E5465584E305A573075556D567A623356795932567A4C6C4A31626E5270625756535A584E7664584A6A5A564E6C64414941414141414141414141414141414642425246424252464330414141413C2F5265736F757263653E0D0A2F2F2F2020203C2F5265736F75726365733E0D0A2F2F2F203C2F585254797065496E666F3E0D0A6E616D65737061636520587472615265706F727453657269616C697A6174696F6E207B0D0A202020200D0A202020207075626C696320636C617373207274705F426172636F6465203A20446576457870726573732E587472615265706F7274732E55492E587472615265706F7274207B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6420626F74746F6D4D617267696E42616E64313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7820787250696374757265426F78313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E44657461696C42616E642044657461696C3B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E585250616E656C20787250616E656C313B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C323B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C343B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C353B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C363B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C206C6162656C373B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E58524C6162656C2078724C6162656C333B0D0A20202020202020207072697661746520446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6420746F704D617267696E42616E64313B0D0A2020202020202020707269766174652053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F757263652062696E64696E67536F75726365313B0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572205F7265736F75726365733B0D0A20202020202020207072697661746520737472696E67205F7265736F75726365537472696E673B0D0A20202020202020207075626C6963207274705F426172636F64652829207B0D0A202020202020202020202020746869732E5F7265736F75726365537472696E67203D20446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E616765722E4765745265736F75726365466F722822587472615265706F727453657269616C697A6174696F6E2E7274705F426172636F646522293B0D0A202020202020202020202020746869732E496E697469616C697A65436F6D706F6E656E7428293B0D0A20202020202020207D0D0A2020202020202020707269766174652053797374656D2E5265736F75726365732E5265736F757263654D616E61676572207265736F7572636573207B0D0A202020202020202020202020676574207B0D0A20202020202020202020202020202020696620285F7265736F7572636573203D3D206E756C6C29207B0D0A2020202020202020202020202020202020202020746869732E5F7265736F7572636573203D206E657720446576457870726573732E587472615265706F7274732E53657269616C697A6174696F6E2E58525265736F757263654D616E6167657228746869732E5F7265736F75726365537472696E67293B0D0A202020202020202020202020202020207D0D0A2020202020202020202020202020202072657475726E20746869732E5F7265736F75726365733B0D0A2020202020202020202020207D0D0A20202020202020207D0D0A20202020202020207072697661746520766F696420496E697469616C697A65436F6D706F6E656E742829207B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E426F74746F6D4D617267696E42616E6428293B0D0A202020202020202020202020746869732E78724C6162656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E78724C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E787250696374757265426F7831203D206E657720446576457870726573732E587472615265706F7274732E55492E585250696374757265426F7828293B0D0A202020202020202020202020746869732E44657461696C203D206E657720446576457870726573732E587472615265706F7274732E55492E44657461696C42616E6428293B0D0A202020202020202020202020746869732E787250616E656C31203D206E657720446576457870726573732E587472615265706F7274732E55492E585250616E656C28293B0D0A202020202020202020202020746869732E746F704D617267696E42616E6431203D206E657720446576457870726573732E587472615265706F7274732E55492E546F704D617267696E42616E6428293B0D0A202020202020202020202020746869732E78724C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E62696E64696E67536F7572636531203D206E65772053797374656D2E57696E646F77732E466F726D732E42696E64696E67536F7572636528293B0D0A202020202020202020202020746869732E6C6162656C32203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C33203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C34203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C35203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C36203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020746869732E6C6162656C37203D206E657720446576457870726573732E587472615265706F7274732E55492E58524C6162656C28293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E426567696E496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E426567696E496E697428293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20626F74746F6D4D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E626F74746F6D4D617267696E42616E64312E4E616D65203D2022626F74746F6D4D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C312E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B436F6D70616E794E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C312E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C2039462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742836372E3533313937462C203046293B0D0A202020202020202020202020746869732E78724C6162656C312E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C312E4E616D65203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283438352E36363635462C2034312E333531393646293B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C312E54657874203D202278724C6162656C31223B0D0A202020202020202020202020746869732E78724C6162656C312E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F7043656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C322E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E78724C6162656C322E426F726465725769647468203D2032463B0D0A202020202020202020202020746869732E78724C6162656C322E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C322E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B50726F647563744E616D655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C322E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C2039462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742835332E3838313832462C2034312E333531393646293B0D0A202020202020202020202020746869732E78724C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C322E4E616D65203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283438352E36363635462C2033392E363837393546293B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C322E54657874203D202278724C6162656C32223B0D0A202020202020202020202020746869732E78724C6162656C322E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250696374757265426F78310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250696374757265426F78312E447069203D20323534463B0D0A202020202020202020202020746869732E787250696374757265426F78312E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C2022496D616765536F75726365222C20225B426172636F6465496D6167655D22297D293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283133342E38373532462C2038312E303339393246293B0D0A202020202020202020202020746869732E787250696374757265426F78312E4E616D65203D2022787250696374757265426F7831223B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283433342E36313037462C2036322E3737343746293B0D0A202020202020202020202020746869732E787250696374757265426F78312E53697A696E67203D20446576457870726573732E587472615072696E74696E672E496D61676553697A654D6F64652E4175746F53697A653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2044657461696C0D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E44657461696C2E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E44657461696C2E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E44657461696C2E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E787250616E656C317D293B0D0A202020202020202020202020746869732E44657461696C2E447069203D20323534463B0D0A202020202020202020202020746869732E44657461696C2E48656967687446203D20343030463B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F676574686572203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4B656570546F6765746865725769746844657461696C5265706F727473203D20747275653B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E436F6C756D6E5769647468203D20363030463B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4C61796F7574203D20446576457870726573732E587472615072696E74696E672E436F6C756D6E4C61796F75742E4163726F73735468656E446F776E3B0D0A202020202020202020202020746869732E44657461696C2E4D756C7469436F6C756D6E2E4D6F6465203D20446576457870726573732E587472615265706F7274732E55492E4D756C7469436F6C756D6E4D6F64652E557365436F6C756D6E436F756E743B0D0A202020202020202020202020746869732E44657461696C2E4E616D65203D202244657461696C223B0D0A202020202020202020202020746869732E44657461696C2E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E44657461696C2E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E546F704C6566743B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20787250616E656C310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E787250616E656C312E416E63686F72486F72697A6F6E74616C203D202828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E4C656674207C20446576457870726573732E587472615265706F7274732E55492E486F72697A6F6E74616C416E63686F725374796C65732E52696768742929293B0D0A202020202020202020202020746869732E787250616E656C312E416E63686F72566572746963616C203D202828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C6573292828446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E546F70207C20446576457870726573732E587472615265706F7274732E55492E566572746963616C416E63686F725374796C65732E426F74746F6D2929293B0D0A202020202020202020202020746869732E787250616E656C312E426F7264657273203D20446576457870726573732E587472615072696E74696E672E426F72646572536964652E4E6F6E653B0D0A202020202020202020202020746869732E787250616E656C312E426F726465725769647468203D2031463B0D0A202020202020202020202020746869732E787250616E656C312E43616E47726F77203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E436F6E74726F6C732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E5852436F6E74726F6C5B5D207B0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C342C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C352C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C362C0D0A202020202020202020202020202020202020202020202020746869732E6C6162656C372C0D0A202020202020202020202020202020202020202020202020746869732E787250696374757265426F78312C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C332C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C322C0D0A202020202020202020202020202020202020202020202020746869732E78724C6162656C317D293B0D0A202020202020202020202020746869732E787250616E656C312E447069203D20323534463B0D0A202020202020202020202020746869732E787250616E656C312E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F617428352E353134303336462C20322E39333938313446293B0D0A202020202020202020202020746869732E787250616E656C312E4E616D65203D2022787250616E656C31223B0D0A202020202020202020202020746869732E787250616E656C312E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283538352E36363635462C203338382E3935383346293B0D0A202020202020202020202020746869732E787250616E656C312E536E61704C696E6550616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28302C20302C20302C20302C2032353446293B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E787250616E656C312E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F20746F704D617267696E42616E64310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E746F704D617267696E42616E64312E447069203D20323534463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E48656967687446203D2030463B0D0A202020202020202020202020746869732E746F704D617267696E42616E64312E4E616D65203D2022746F704D617267696E42616E6431223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2078724C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E78724C6162656C332E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E78724C6162656C332E426F726465725769647468203D2032463B0D0A202020202020202020202020746869732E78724C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E78724C6162656C332E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B54617850726963655D22297D293B0D0A202020202020202020202020746869732E78724C6162656C332E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C2039462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E78724C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742835332E3838313839462C203138302E3634313946293B0D0A202020202020202020202020746869732E78724C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E78724C6162656C332E4E616D65203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E78724C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283233312E36363635462C2034332E3339383546293B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E78724C6162656C332E54657874203D202278724C6162656C33223B0D0A202020202020202020202020746869732E78724C6162656C332E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A202020202020202020202020746869732E78724C6162656C332E54657874466F726D6174537472696E67203D20227B303A302E30307D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F2062696E64696E67536F75726365310D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E62696E64696E67536F75726365312E44617461536F75726365203D20747970656F66284163636F756E74696E674D532E5265706F7274437573746F6D4D6F64656C732E426172636F646544617461293B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C320D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C322E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C322E466F7265436F6C6F72203D2053797374656D2E44726177696E672E436F6C6F722E426C61636B3B0D0A202020202020202020202020746869732E6C6162656C322E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283239362E35373133462C203235392E3532393146293B0D0A202020202020202020202020746869732E6C6162656C322E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C322E4E616D65203D20226C6162656C32223B0D0A202020202020202020202020746869732E6C6162656C322E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C322E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283230352E35373134462C2032392E3037343846293B0D0A202020202020202020202020746869732E6C6162656C322E5374796C655072696F726974792E557365466F7265436F6C6F72203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C322E54657874203D2022D8AAD8A7D8B1D98AD8AE20D8A7D984D8A7D986D8AAD987D8A7D8A1223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C330D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C332E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C332E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283239362E35373133462C203232342E3034303446293B0D0A202020202020202020202020746869732E6C6162656C332E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C332E4E616D65203D20226C6162656C33223B0D0A202020202020202020202020746869732E6C6162656C332E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C332E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283233382E38353232462C2033352E343838363546293B0D0A202020202020202020202020746869732E6C6162656C332E54657874203D2022D8AAD8A7D8B1D98AD8AE20D8A7D984D8A7D986D8AAD8A7D8AC223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C340D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C342E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C342E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B4461746550726F64756374696F6E5D22297D293B0D0A202020202020202020202020746869732E6C6162656C342E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742836372E3533313937462C203232342E3034303546293B0D0A202020202020202020202020746869732E6C6162656C342E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C342E4E616D65203D20226C6162656C34223B0D0A202020202020202020202020746869732E6C6162656C342E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C342E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283232392E30333933462C2033342E393438383846293B0D0A202020202020202020202020746869732E6C6162656C342E54657874203D20226C6162656C34223B0D0A202020202020202020202020746869732E6C6162656C342E54657874466F726D6174537472696E67203D20227B303A647D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C350D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C352E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C352E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B4461746545787069726174655D22297D293B0D0A202020202020202020202020746869732E6C6162656C352E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742836372E3533313937462C203235382E3938393346293B0D0A202020202020202020202020746869732E6C6162656C352E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C352E4E616D65203D20226C6162656C35223B0D0A202020202020202020202020746869732E6C6162656C352E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C352E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283232392E30333933462C2032392E363134353646293B0D0A202020202020202020202020746869732E6C6162656C352E54657874203D20226C6162656C33223B0D0A202020202020202020202020746869732E6C6162656C352E54657874466F726D6174537472696E67203D20227B303A647D223B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C360D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C362E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E6C6162656C362E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C362E45787072657373696F6E42696E64696E67732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E675B5D207B0D0A2020202020202020202020202020202020202020202020206E657720446576457870726573732E587472615265706F7274732E55492E45787072657373696F6E42696E64696E6728224265666F72655072696E74222C202254657874222C20225B4E6F7465735D22297D293B0D0A202020202020202020202020746869732E6C6162656C362E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F61742835332E3838313832462C203134332E3831343646293B0D0A202020202020202020202020746869732E6C6162656C362E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C362E4E616D65203D20226C6162656C36223B0D0A202020202020202020202020746869732E6C6162656C362E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C362E53697A6546203D206E65772053797374656D2E44726177696E672E53697A6546283438312E35343137462C2033362E383237333546293B0D0A202020202020202020202020746869732E6C6162656C362E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C362E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C362E54657874203D20226C6162656C32223B0D0A202020202020202020202020746869732E6C6162656C362E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F206C6162656C370D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E6C6162656C372E426F7264657273203D202828446576457870726573732E587472615072696E74696E672E426F72646572536964652928282828446576457870726573732E587472615072696E74696E672E426F72646572536964652E4C656674207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E546F7029200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E526967687429200D0A2020202020202020202020202020202020202020202020207C20446576457870726573732E587472615072696E74696E672E426F72646572536964652E426F74746F6D2929293B0D0A202020202020202020202020746869732E6C6162656C372E426F726465725769647468203D2032463B0D0A202020202020202020202020746869732E6C6162656C372E447069203D20323534463B0D0A202020202020202020202020746869732E6C6162656C372E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C2039462C2053797374656D2E44726177696E672E466F6E745374796C652E426F6C64293B0D0A202020202020202020202020746869732E6C6162656C372E4C6F636174696F6E466C6F6174203D206E657720446576457870726573732E5574696C732E506F696E74466C6F6174283238352E35343833462C203138302E3634313946293B0D0A202020202020202020202020746869732E6C6162656C372E4D756C74696C696E65203D20747275653B0D0A202020202020202020202020746869732E6C6162656C372E4E616D65203D20226C6162656C37223B0D0A202020202020202020202020746869732E6C6162656C372E50616464696E67203D206E657720446576457870726573732E587472615072696E74696E672E50616464696E67496E666F28352C20352C20302C20302C2032353446293B0D0A202020202020202020202020746869732E6C6162656C372E53697A6546203D206E65772053797374656D2E44726177696E672E53697A654628323534462C2034332E3339383546293B0D0A202020202020202020202020746869732E6C6162656C372E5374796C655072696F726974792E557365426F7264657273203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C372E5374796C655072696F726974792E557365426F726465725769647468203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C372E5374796C655072696F726974792E557365466F6E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C372E5374796C655072696F726974792E55736554657874416C69676E6D656E74203D2066616C73653B0D0A202020202020202020202020746869732E6C6162656C372E54657874203D2022D8A7D984D8B3D8B9D8B120D8B4D8A7D985D98420D8A7D984D8B6D8B1D98AD8A8D987223B0D0A202020202020202020202020746869732E6C6162656C372E54657874416C69676E6D656E74203D20446576457870726573732E587472615072696E74696E672E54657874416C69676E6D656E742E4D6964646C6543656E7465723B0D0A2020202020202020202020202F2F200D0A2020202020202020202020202F2F207274705F426172636F64650D0A2020202020202020202020202F2F200D0A202020202020202020202020746869732E42616E64732E41646452616E6765286E657720446576457870726573732E587472615265706F7274732E55492E42616E645B5D207B0D0A202020202020202020202020202020202020202020202020746869732E44657461696C2C0D0A202020202020202020202020202020202020202020202020746869732E746F704D617267696E42616E64312C0D0A202020202020202020202020202020202020202020202020746869732E626F74746F6D4D617267696E42616E64317D293B0D0A202020202020202020202020746869732E426F726465725769647468203D2030463B0D0A202020202020202020202020746869732E436F6D706F6E656E7453746F726167652E41646452616E6765286E65772053797374656D2E436F6D706F6E656E744D6F64656C2E49436F6D706F6E656E745B5D207B0D0A202020202020202020202020202020202020202020202020746869732E62696E64696E67536F75726365317D293B0D0A202020202020202020202020746869732E447069203D20323534463B0D0A202020202020202020202020746869732E466F6E74203D206E65772053797374656D2E44726177696E672E466F6E742822417269616C222C20392E373546293B0D0A202020202020202020202020746869732E4D617267696E73203D206E65772053797374656D2E44726177696E672E5072696E74696E672E4D617267696E7328302C20302C20302C2030293B0D0A202020202020202020202020746869732E4E616D65203D20227274705F426172636F6465223B0D0A202020202020202020202020746869732E50616765486569676874203D203530303B0D0A202020202020202020202020746869732E506167655769647468203D203630303B0D0A202020202020202020202020746869732E50617065724B696E64203D2053797374656D2E44726177696E672E5072696E74696E672E50617065724B696E642E437573746F6D3B0D0A202020202020202020202020746869732E5265706F72745072696E744F7074696F6E732E44657461696C436F756E744F6E456D70747944617461536F75726365203D203134343B0D0A202020202020202020202020746869732E5265706F7274556E6974203D20446576457870726573732E587472615265706F7274732E55492E5265706F7274556E69742E54656E7468734F66414D696C6C696D657465723B0D0A202020202020202020202020746869732E53686F775072696E744D617267696E735761726E696E67203D2066616C73653B0D0A202020202020202020202020746869732E536E61704772696453697A65203D2033312E3735463B0D0A202020202020202020202020746869732E56657273696F6E203D202231392E32223B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A652928746869732E62696E64696E67536F757263653129292E456E64496E697428293B0D0A202020202020202020202020282853797374656D2E436F6D706F6E656E744D6F64656C2E49537570706F7274496E697469616C697A6529287468697329292E456E64496E697428293B0D0A20202020202020207D0D0A202020207D0D0A7D0D0A, 0)
SET IDENTITY_INSERT [dbo].[BarcodeTemplates] OFF
SET IDENTITY_INSERT [dbo].[OffersProduct] ON 

INSERT [dbo].[OffersProduct] ([id], [productID], [OffersID], [productName]) VALUES (31, 1, 2036, N'تجربه')
INSERT [dbo].[OffersProduct] ([id], [productID], [OffersID], [productName]) VALUES (32, 1, 2, N'تجريبي1')
SET IDENTITY_INSERT [dbo].[OffersProduct] OFF
SET IDENTITY_INSERT [dbo].[OfficialVacation] ON 

INSERT [dbo].[OfficialVacation] ([id], [name], [fromdate], [todate], [notes]) VALUES (1, N'العيد الوطنى', CAST(N'2022-12-20T00:00:00.000' AS DateTime), N'03/12/2022 12:00:00 ص', NULL)
INSERT [dbo].[OfficialVacation] ([id], [name], [fromdate], [todate], [notes]) VALUES (1002, N'عيد', CAST(N'2022-12-14T00:00:00.000' AS DateTime), N'21/12/2022 12:00:00 ص', NULL)
INSERT [dbo].[OfficialVacation] ([id], [name], [fromdate], [todate], [notes]) VALUES (1003, N'اجازة', CAST(N'2023-01-08T00:00:00.000' AS DateTime), N'08/01/2023 12:00:00 ص', NULL)
SET IDENTITY_INSERT [dbo].[OfficialVacation] OFF
SET IDENTITY_INSERT [dbo].[OvertimeAndDelayRegulation] ON 

INSERT [dbo].[OvertimeAndDelayRegulation] ([id], [name], [DiscountValuePerHour], [ExtraValuePerHour], [notes], [AbsenceValue]) VALUES (8, N'لائحة الاضافة والتأخير لموظفين عن بعد', 7.4, 7.4, N'', 66.66)
INSERT [dbo].[OvertimeAndDelayRegulation] ([id], [name], [DiscountValuePerHour], [ExtraValuePerHour], [notes], [AbsenceValue]) VALUES (9, N'لائحة2', 10.75, 10.75, N'', 96.77)
SET IDENTITY_INSERT [dbo].[OvertimeAndDelayRegulation] OFF
SET IDENTITY_INSERT [dbo].[RepCommission] ON 

INSERT [dbo].[RepCommission] ([id], [DisplayName], [commission], [Notes], [isActive]) VALUES (1, N'عرض 12', 0.1, N'', 1)
SET IDENTITY_INSERT [dbo].[RepCommission] OFF
SET IDENTITY_INSERT [dbo].[RepCommissionDetails] ON 

INSERT [dbo].[RepCommissionDetails] ([id], [RepId], [PrdId], [RepCommission], [StorId]) VALUES (1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[RepCommissionDetails] OFF
SET IDENTITY_INSERT [dbo].[SalaryRegulation] ON 

INSERT [dbo].[SalaryRegulation] ([id], [name], [costCenter], [ExpensesAccount], [BenefitsAccount], [DayValue], [HourValue], [SalaryPeriod], [SalaryCalculation], [DefaultSalary], [Equation], [BenefitListid], [DeductionListid]) VALUES (2, N'dfsg', N'dsf', 23, 3, 34, 54, N'اسبوع', N'قيمة ثابتة', 23, 32, NULL, NULL)
INSERT [dbo].[SalaryRegulation] ([id], [name], [costCenter], [ExpensesAccount], [BenefitsAccount], [DayValue], [HourValue], [SalaryPeriod], [SalaryCalculation], [DefaultSalary], [Equation], [BenefitListid], [DeductionListid]) VALUES (4, N'لائحة55', N'5', 34, 34, 43, 34, N'شهر', N'قيمة ثابتة', 43, 34, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SalaryRegulation] OFF
SET IDENTITY_INSERT [dbo].[tblAccount] ON 

INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (1, 1, N'الاصول', 1, 0, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (2, 11, N'الاصول المتداولة', 1, 1, 2, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (3, 111, N'النقدية وشبة النقدية', 1, 11, 3, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (4, 1111, N'النقدية في الصناديق', 1, 111, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (5, 111101, N'صناديق الادارة العامة ', 1, 1111, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (6, 1111010001, N'صندوق رقم 1', 1, 111101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (7, 111102, N'صناديق فرع ...', 1, 1111, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (8, 1112, N'النقدية في البنوك', 1, 111, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (9, 111201, N'بنوك الإدارة العامة ', 1, 1112, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (11, 111202, N'بنوك فرع ........', 1, 1112, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (12, 1113, N'شيكات قبض تحت التحصيل', 1, 111, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (13, 111301, N'شيكات قبض تحت التحصيل', 1, 1113, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (14, 1113010001, N'شيكات بنك .... تحت التحصيل ', 1, 111301, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (15, 112, N'المدينون', 1, 11, 3, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (16, 1121, N'العملاء', 1, 112, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (17, 112101, N'عملاء الادارة العامة ', 1, 1121, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (18, 1121010001, N'  اسم العميل', 1, 112101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (19, 112102, N'عملاء فرع .........', 1, 1121, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (20, 114, N'المخزون', 1, 11, 3, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (21, 1141, N'المخزون السلعي', 1, 114, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (22, 114101, N'مخزون ....... مجموعة رئيسية', 1, 1141, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (23, 1141010001, N'مخزون ....... مجموعة فرعية', 1, 114101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (24, 1141010002, N'وسيط التحويلات المخزنية ', 1, 114101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (25, 115, N'الاعتمادات المستندية ', 1, 11, 3, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (26, 1151, N'الاعتمادات المستندية ', 1, 115, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (27, 115101, N'الاعتماد رقم ..... ', 1, 1151, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (28, 1151010001, N'قيمة الاعتمادي المستندي (الفاتورة)', 1, 115101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (29, 1151010002, N'رسوم الشحن', 1, 115101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (30, 1151010003, N'الرسوم الجمركية', 1, 115101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (31, 1151010004, N'مصاريف بنكية ', 1, 115101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (32, 1151010005, N'مصاريف التأمين ', 1, 115101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (33, 1151010006, N'مصاريف اخرى', 1, 115101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (34, 116, N'الارصدة المدينة الاخرى', 1, 11, 3, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (35, 1161, N'سلف العاملين ', 1, 116, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (36, 116101, N'سلف العاملين ', 1, 1161, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (37, 1161010001, N'الموظف .....', 1, 116101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (38, 1162, N'السلف المؤقتة (العهد )', 1, 116, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (39, 116201, N'السلف المؤقتة (العهد )', 1, 1162, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (40, 1162010001, N'الموظف .....', 1, 116201, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (41, 1163, N'الضمانات المدينة ', 1, 116, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (42, 116301, N'ضمانات اعتمادات ', 1, 1163, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (43, 1163010001, N'ضمانات اعتماد رقم ....', 1, 116301, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (44, 1163010002, N'خطاب ضمان رقم ...', 1, 116301, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (45, 1164, N'التامينات المدينة .....', 1, 116, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (46, 116401, N'تأمينات', 1, 1164, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (47, 1164010001, N'تأمين خطاب ضمان رقم...', 1, 116401, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (48, 1165, N'الاصناف المفقودة /الزائدة الادارة العامة', 1, 116, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (49, 116501, N'الأصناف المفقودة ', 1, 1165, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (50, 1165010001, N'الاصناف المفقودة /الزائدة ', 1, 116501, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (51, 116502, N'الاصناف المفقودة /الزائدة فرع ...', 1, 1165, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (52, 1166, N'حسابات انتقالية مدينة ', 1, 116, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (53, 116601, N'المصاريف المدفوعة مقدماً', 1, 1166, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (54, 1166010001, N'ايجارات مدفوعة مقدماً', 1, 116601, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (55, 116602, N'الايرادات المستحقة ', 1, 1166, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (56, 1167, N'حسابات الفروع ', 1, 116, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (57, 116701, N'جاري الفروع ', 1, 1167, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (58, 1167010001, N'جاري الادارة العامة ', 1, 116701, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (59, 1169, N'المصاريف الايرادية المؤجلة ', 1, 116, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (60, 116901, N'مصاريف التاسيس ', 1, 1169, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (61, 1169010001, N'مصاريف التاسيس ', 1, 116901, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (62, 12, N'الاصول الغير متداولة', 1, 1, 2, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (63, 121, N'الاصول الغير متداولة ', 1, 12, 3, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (64, 1211, N'السيارات وشاحنات النقل', 1, 121, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (65, 121101, N'سيارات مواصلات ', 1, 1211, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (66, 1211010001, N'سيارات ....', 1, 121101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (67, 121102, N'شاحنات النقل', 1, 1211, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (68, 1211020001, N'شاحنات النقل ', 1, 121102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (69, 1212, N'الاثاث والتجهيز ات المكتبية', 1, 121, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (70, 121201, N'الاثاث والمفروشات', 1, 1212, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (71, 1212010001, N'اثاث ......', 1, 121201, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (72, 121202, N'التجهيزات المكتبية', 1, 1212, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (73, 1212020001, N'تجهيزات مكتبية ....', 1, 121202, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (74, 1213, N'الكمبيوترات والانظمة', 1, 121, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (75, 121301, N'الكمبيوترات', 1, 1213, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (76, 1213010001, N'كمبيوترات .....', 1, 121301, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (77, 121302, N'الانظمة ', 1, 1213, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (78, 1213020001, N'الانظمة المالية', 1, 121302, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (79, 1214, N'الاجهزة الكهربائية والعدد والادوات', 1, 121, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (80, 121401, N'الاجهزة الكهربائية ', 1, 1214, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (81, 1214010001, N'اجهزة كهربائية ....', 1, 121401, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (82, 121402, N'العددوالادوات', 1, 1214, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (83, 1214020001, N'العدد والادوات الصغيرة', 1, 121402, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (84, 1215, N'المعدات والالات', 1, 121, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (85, 121502, N'المعدات ', 1, 1215, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (86, 1215020001, N'معدات ......', 1, 121502, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (87, 1216, N'العقارات', 1, 121, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (88, 121601, N'المباني ', 1, 1216, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (89, 1216010001, N'مبنى ...', 1, 121601, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (90, 121602, N'الاراضي', 1, 1216, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (91, 1216020001, N'ارضية ....', 1, 121602, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (92, 1217, N'مشاريع قيد التنفيذ', 1, 121, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (93, 121701, N'مشاريع قيد التنفيذ مباني', 1, 1217, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (94, 1217010001, N'مشروع مبنى ....', 1, 121701, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (95, 2, N'الخصوم ', 2, 0, 1, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (96, 21, N'الخصوم المتداولة ', 2, 2, 2, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (97, 211, N'الدائنوان', 2, 21, 3, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (98, 2111, N'الموردون', 2, 211, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (99, 211101, N'موردون محليون', 2, 2111, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (100, 2111010001, N'اسم المورد ......', 2, 211101, 6, 2, 1, 1, 0, NULL)
GO
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (101, 2112, N'ذمم دائنة اخرى', 2, 211, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (102, 212, N'اوراق دفع ', 2, 21, 3, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (103, 2121, N'شيكات دفع تحت التحصيل', 2, 212, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (104, 212101, N'شيكات دفع تحت التحصيل', 2, 2121, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (105, 2121010001, N'شيكات دفع صادرة ', 2, 212101, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (106, 214, N'الارصدة الدئنة الاخرى', 2, 21, 3, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (107, 2141, N'التامينات الدائنة ', 2, 214, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (108, 214101, N'ضمانات العملاء', 2, 2141, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (109, 2141010001, N'ضمانة العميل ............', 2, 214101, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (110, 2142, N'مصاريف مستحقة ', 2, 214, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (111, 214201, N'مصاريف مستحقة اعتمادات', 2, 2142, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (112, 2142010001, N'مصاريف مستحقة اعتماد رقم ...', 2, 214201, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (113, 214202, N'المصاريف المستحقة مصاريف', 2, 2142, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (114, 2142020001, N'المرتبات والاجور المستحقة ', 2, 214202, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (115, 2143, N'الايرادات المدفوعة مقدماً', 2, 214, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (116, 22, N'الخصوم الغير متداولة ', 2, 2, 2, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (117, 221, N'الالتزامات طويلة الاجل', 2, 22, 3, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (118, 23, N'حقوق الملكية ', 2, 2, 2, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (119, 231, N'حقوق ملكية الشركاء', 2, 23, 3, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (120, 2311, N'راس المال ', 2, 231, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (121, 231101, N'راس المال ', 2, 2311, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (122, 2311010001, N'راس المال ', 2, 231101, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (123, 2312, N'الارباح والخسائر', 2, 231, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (124, 231201, N'الارباح والخسائر', 2, 2312, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (125, 2312010001, N'الارباح والخسائر للفترة ', 2, 231201, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (126, 2312010002, N'الارباح والخسائر المرحلة', 2, 231201, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (127, 2314, N'الاحتياطيات ', 2, 231, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (128, 231401, N'الاحتياطيات', 2, 2314, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (129, 2314010001, N'احتياطي قانوني ', 2, 231401, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (130, 2315, N'جاري الشركاء', 2, 231, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (131, 231501, N'جاري الشركاء', 2, 2315, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (132, 2315010001, N'جاري الشريك .....', 2, 231501, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (133, 2316, N'المخصصات والمجمعات', 2, 231, 4, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (134, 231601, N'المخصصات', 2, 2316, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (135, 2316010001, N'مخصصات الديون المشكوك فيها', 2, 231601, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (136, 231602, N'مجمعات الاهلاك', 2, 2316, 5, 1, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (137, 2316020001, N'مجمع اهلاك الاثاث', 2, 231602, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (138, 2316020002, N'مجمع اهلاك التجهيزات المكتبية', 2, 231602, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (139, 2316020003, N'مجمع اهلاك الكمبيوترات', 2, 231602, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (140, 2316020004, N'مجمع اهلاك الانظمة', 2, 231602, 6, 2, 1, 1, 0, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (141, 3, N'المصروفات ', 3, 0, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (142, 31, N'تكلفة النشاط', 3, 3, 2, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (143, 312, N'تكلفة المبيعات ', 3, 31, 3, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (144, 3121, N'تكلفة البضاعة المباعة', 3, 312, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (145, 312101, N'تكلفة مبيعات المخزون السلعي', 3, 3121, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (146, 3121010001, N'تكلفة مبيعات مخزون ......', 3, 312101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (147, 3122, N'تكلفة مردود المبيعات ', 3, 312, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (148, 312201, N'تكلفة مردود المبيعات الفترة', 3, 3122, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (149, 3122010001, N'تكلفة مردود المبيعات مخزون....', 3, 312201, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (150, 312202, N'تكلفة مردود المبيعات سنوات سابقة', 3, 3122, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (151, 3122020001, N'تكلفة مردود مبيعات مخزون ..سنوات', 3, 312202, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (152, 312203, N'تكلفة مبيعات الكميات المجانية ', 3, 3122, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (153, 3122030001, N'تكلفة مبيعات الكميات المجانية مخزون ....', 3, 312203, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (154, 3123, N'مردود المبيعات ', 3, 312, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (155, 312301, N'مردود المبيعات للفترة', 3, 3123, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (156, 3123010001, N'مردود مبيعات مخزون .....', 3, 312301, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (157, 312302, N'مردود المبيعات سنوات سابقة', 3, 3123, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (158, 3123020001, N'مردود المبيعات سابقة مخزون ....', 3, 312302, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (159, 312303, N'مردود مبيعات الكميات المجانية', 3, 3123, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (160, 3123030001, N'مردود مبيعات الكميات المجانية مخزون....', 3, 312303, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (161, 3124, N'الخصم المسموح به ', 3, 312, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (162, 312401, N'الخصم المسموح به ', 3, 3124, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (163, 3124010001, N'الخصم المسموح به ', 3, 312401, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (164, 3125, N'فوراق التكاليف ', 3, 312, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (165, 312501, N'فوراق التكاليف ', 3, 3125, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (166, 3125010001, N'فوراق الكسور ', 3, 312501, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (167, 3125010002, N'فوراق الاعتمادات ', 3, 312501, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (168, 3125010003, N'فوراق التكلفة ', 3, 312501, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (169, 32, N'مصاريف  النشاط ', 3, 3, 2, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (170, 321, N'المصاريف الادارية والتسويقية ', 3, 32, 3, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (171, 3211, N'المصاريف الادارية والعمومية', 3, 321, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (172, 321101, N'المرتبات والاجور', 3, 3211, 5, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (173, 3211010001, N'المرتبات والاجور', 3, 321101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (174, 3211010002, N'المكافات والمزايا', 3, 321101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (175, 3211010003, N'مصاريف رسوم مكتب خدمات تجديد الاقامات', 3, 321101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (176, 3211010004, N'مزايا عينية', 3, 321101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (177, 3211010005, N'السكن', 3, 321101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (178, 3211010006, N'مرتبات واجور اضافية', 3, 321101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (179, 3211010007, N'العلاجات', 3, 321101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (180, 321102, N'اجور شحن وتوصيل', 3, 3211, 5, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (181, 3211020001, N'مصاريف التليفون', 3, 321102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (182, 3211020002, N'الكهرباء', 3, 321102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (183, 3211020003, N'الايجارات ', 3, 321102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (184, 3211020004, N'فوائد بنكية', 3, 321102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (185, 3211020005, N'الضرائب', 3, 321102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (186, 3211020006, N'الزكاة', 3, 321102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (187, 3211020007, N'الاهلاك', 3, 321102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (188, 3211020008, N'الديون المعدومه', 3, 321102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (189, 3211020009, N'عمولات بنكية ', 3, 321102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (190, 321103, N'الصيانة والاصلاحات', 3, 3211, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (191, 3211030001, N'عمولة مرسول', 3, 321103, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (192, 3211030002, N'صيانة السيارات', 3, 321103, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (193, 3221, N'المصاريف التسويقية', 3, 322, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (194, 322101, N'مصاريف البيع والتوزيع', 3, 3221, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (195, 3221010001, N'مرتبات واجور البيع', 3, 322101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (196, 3221010002, N'الدعاية والاعلان ', 3, 322101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (197, 3221010003, N'الهدايا والتبرعات ', 3, 322101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (198, 4, N'الايرادات', 4, 0, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (199, 41, N'ايرادات النشاط', 4, 4, 2, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (200, 411, N'ايرادات المبيعات ', 4, 41, 3, 1, 1, 1, 1, NULL)
GO
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (201, 4111, N'ايرادات المبيعات ', 4, 411, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (202, 411101, N'ايرادات مبيعات المخزون السلعي', 4, 4111, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (203, 4111010001, N'ايرادات مبيعات مخزون ......', 4, 411101, 6, 2, 1, 1, 5, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (204, 412, N'ايرادات مرتبطة بالنشاط', 4, 41, 3, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (205, 4121, N'ايرادات عرضية ', 4, 412, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (206, 412101, N'ايرادات مشتريات الكميات المجانية', 4, 4121, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (207, 4121010001, N'ايرادات الكميات المجانية مخزون ....', 4, 412101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (208, 412102, N'ايرادات الخصم المكتسب', 4, 4121, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (209, 4121020001, N'الخصم المكتسب مخزون .....', 4, 412102, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (210, 42, N'ايرادات النشاط الاخرى', 4, 4, 2, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (211, 421, N'ايرادات اخرى ومتنوعة ', 4, 42, 3, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (212, 4211, N'ايردات الاستثمارات ', 4, 421, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (213, 421101, N'ايرادات استثمارات مالية في شركات شقيقة', 4, 4211, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (214, 4211010001, N'ايرادات استثمارات مالية في شركات شقيقة ..', 4, 421101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (215, 4212, N'ايرادات متنوعة اخرى', 4, 421, 4, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (216, 421201, N'الايرادات المتنوعة', 4, 4212, 5, 1, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (217, 4212020001, N'ارباح بيع اوارق مالية', 4, 421202, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (218, 4212020002, N'ايرادات فروق عملة', 4, 421202, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (219, 4212020003, N'ايرادات عمولات', 4, 421202, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (220, 4212020004, N'ايرادات بيع مخلفات ', 4, 421202, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (221, 4212020005, N'إيرادات رسمالية', 4, 421202, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (222, 4212020006, N'ايرادات ايجارات دائنة', 4, 421202, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (233, 210, N'الضريبة المضافة', 2, 21, 3, 1, 1, 1, NULL, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (234, 2102, N'ضريبة القيمة المضافة', 2, 210, 4, 1, 1, 1, NULL, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (235, 21023001, N'ضريبة القيمة المضافة مبيعات ومشتريات', 2, 2102, 5, 2, 1, 1, NULL, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (236, 21023002, N'ضريبة القيمة المضافة للقيود', 2, 2102, 5, 2, 1, 1, NULL, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (2486, 1141010003, N'مخزون مجموعه رئيسيه', 1, 114101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (2487, 4111010002, N'إرادات مبيعات مخزون مجموعه رئيسيه', 4, 411101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (2488, 3121010002, N'تكلفة مبيعات مخزون مجموعه رئيسيه', 3, 312101, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (2489, 3123010002, N'مردود مبيعات مخزون مجموعه رئيسيه', 3, 312301, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (2490, 3122010002, N'تكلفة مردود مبيعات مخزون مجموعه رئيسيه', 3, 312201, 6, 2, 1, 1, 1, NULL)
INSERT [dbo].[tblAccount] ([id], [accNo], [accName], [accCat], [accParent], [accLevel], [accType], [accCurrency], [accBrnId], [accStatus], [ParentID]) VALUES (2491, 3124010002, N'خصم مخزون مجموعه رئيسيه', 3, 312401, 6, 2, 1, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[tblAccount] OFF
SET IDENTITY_INSERT [dbo].[tblAccountBank] ON 

INSERT [dbo].[tblAccountBank] ([id], [bankNo], [bankAccNo], [bankName], [bankCurrency], [bankCelling], [bankBrnId], [bankSwiftCode], [bankAccIBAN], [AccNoInBank], [bankNameEn]) VALUES (1, 10001, 1112010001, N'بنك الراجحي ', 1, NULL, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblAccountBank] OFF
SET IDENTITY_INSERT [dbo].[tblAccountBox] ON 

INSERT [dbo].[tblAccountBox] ([id], [boxNo], [boxAccNo], [boxCurrency], [boxName], [boxCelling], [boxBrnId]) VALUES (1, 1, 1111010001, 1, N'صندوق الريال', NULL, 1)
SET IDENTITY_INSERT [dbo].[tblAccountBox] OFF
SET IDENTITY_INSERT [dbo].[tblAsset] ON 

INSERT [dbo].[tblAsset] ([id], [asAccNo], [asAccName], [asDate], [asEntId], [asEntNo], [asDebit], [asCredit], [asDesc], [asStatus], [asView], [asUserId], [asBrnId]) VALUES (1, 1141010003, N'مخزون مجموعه رئيسيه', CAST(N'2023-01-10' AS Date), 1, 1, 0, 0, NULL, 6, 2, 1, 1)
INSERT [dbo].[tblAsset] ([id], [asAccNo], [asAccName], [asDate], [asEntId], [asEntNo], [asDebit], [asCredit], [asDesc], [asStatus], [asView], [asUserId], [asBrnId]) VALUES (2, 4111010002, N'إرادات مبيعات مخزون مجموعه رئيسيه', CAST(N'2023-01-10' AS Date), 1, 1, 0, 15.217391304347828, NULL, 6, 2, 1, 1)
INSERT [dbo].[tblAsset] ([id], [asAccNo], [asAccName], [asDate], [asEntId], [asEntNo], [asDebit], [asCredit], [asDesc], [asStatus], [asView], [asUserId], [asBrnId]) VALUES (3, 21023001, N'ضريبة القيمة المضافة مبيعات ومشتريات', CAST(N'2023-01-10' AS Date), 1, 1, 0, 2.2826086956521738, NULL, 6, 2, 1, 1)
INSERT [dbo].[tblAsset] ([id], [asAccNo], [asAccName], [asDate], [asEntId], [asEntNo], [asDebit], [asCredit], [asDesc], [asStatus], [asView], [asUserId], [asBrnId]) VALUES (4, 1111010001, N'صندوق رقم 1', CAST(N'2023-01-10' AS Date), 1, 1, 17.5, 0, NULL, 6, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[tblAsset] OFF
SET IDENTITY_INSERT [dbo].[tblBranch] ON 

INSERT [dbo].[tblBranch] ([brnId], [brnNo], [brnName], [brnNameEn], [brnAddress], [brnAddressEn], [brnEmail], [brnPhnNo], [brnFaxNo], [brnMailBox], [brnTaxNo], [brnTradeNo], [brnStatus]) VALUES (1, 1, N'الرئيسي', N'', N'', N'', N'', N'', N'', N'', N'', N'', 1)
SET IDENTITY_INSERT [dbo].[tblBranch] OFF
SET IDENTITY_INSERT [dbo].[tblBranchImg] ON 

INSERT [dbo].[tblBranchImg] ([imgId], [imgBrnId], [imgBrn]) VALUES (1, 1, 0x89504E470D0A1A0A0000000D49484452000005AF000003840806000000A646CD5F000000097048597300002E2300002E230178A53F760000200049444154789CECDDFD75DB46D60760CC9EFC6F6F05562AB0B6022B1558A9C04A05512AB05241E40A2C5710B982481544AA205205AF55C1BC6792CB84A1F541520430033CCF393CF66E6411044110F8CD9D3B29E7DC0100000000404DFEE3DD0000000000A036C26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AA23BC0600000000A03AC26B0000000000AAF38DB7040000C69152DAEBBA6EEF9127BFCA397FF1F600003047C26B000018404AE9A0EBBAF2D88FC7AB279EF5B6EBBAE3AEEBCEBD3F0000CC91F01A00007A90527AD975DD613CDEAEF90CD711569FE79CAFBC2F0000CC99F01A000076282AAC8FBAAE7BB7C16FBDECBAEE24E77CE1BD000080BF08AF0100600722B43EE9BAEECD86BFEDA79CF3A9F7000000FE4D780D0000CFF08CD0FAAEB414516D0D0000F7135E0300C016524A7B5DD79D6ED0CF7AD591E01A00001EF61FFB0600003693523AEEBAEEEA19C1F5CF39E773BB1D00001E9672CE760F0000AC21A5F4B2EBBAF32D5A842CBBCC391FD8DF0000F038E1350000AC217A5B97E0FAC533F7D7FF72CE57F63900003C4EDB1000007842B409F96D07C1F527C1350000AC47E535C00C44B56067613080CDA594CEBAAE7BB7A35DF76DCEF9C6DB0000004FFBC63E02988E94D25ED775875DD795B07ABFEBBA57CB2F2EA5B4F8EB75D7753731FDFD429002F0B51DF5B75E76E97C0B0000EB53790DD0B808574A605DA6B4BFDEF2D55C765D7796733E733C00FC7D6EBD78C679F53E3F38CF0200C0FA84D7008D8A60E5381ECFEDC1BA70DB75DD89700598B39E82EBE2BF39E72F0E2E0000588FF01AA04129A552697DBADA1664874A25F6B145C580B9E931B8FE9C733E74400100C0FAF4BC06662BA5B41FBDA1CBE3E5033D4D17BDA14B90713E76AFD208554A55F4DB9E9FAAEC8B8B94D2B12A6C602E7A0CAEBBF8BD0000C006545E03B312C1C451B4DAD8A66AF9362A9ECF869EFA1D61FB594FA1CA633EE49C8F077E4E8041F51C5C17FF339B0500003623BC066621A5B4577A39775DF76E47AFF72E42ECD32142EC08AE2F76D8DB7A539F72CE47233D3740AF0608AEEF72CE2FBD8B0000B099FFD85FC0D4A5944A687DB5C3E0BA8B10F97D692912FDA77B5341705DBC2B2D44467C7E803EF53DAB45C53500006C41780D4C56097D534A571132F715FC96DFFB6B4AE92C2AF7762A7EE7F9C8C1F5C22F29A5830AB6036067524AA703AC23A0DF3500006C41780D4C524AA9B4B8F87DC0FED0EF6281C35D07D8E75BF6E6EECB791F213DC018E2BBE2C7019E7AD4C57E0100A055C26B6072228CF838C2EB7ABDCB003BDA74BCD9C5EFDAA117D1EB1BA069D19269A8EF0AE13500006CC1828DC0A48C185C2FBBEEBAEEE0390B3946007E5349BB90FB7C9773360D1E68529C63AF869AD992734E8E140000D89CCA6B60322A09AEBBA8C03E7BE6EF38AE38B82E4E2AD806806D9D0DD892E9CEBB040000DB115E039310D3BF6B6A67F136DA7E6C2C2A02B7FAB7037A63F146A04531D0D9F7028DCBAE1C280000B01DE13530156715562A9FA494F6B6F8778795575D2F1CD5B11900EB8973F2D0039D5BB790020080B9135E03CD8B2ABAD715BE8E6D1737ACBDEA7AE1DDAE16A70418C8E90883832AAF0100604BC26BA069119ED6D42E64D5DB4DDA6BC4EBA931887FC8619D9B05F06F29A5C381DB85000000CF24BC065AD7428B8D4D16376C2D0C165E03D51B79A0F3C611020000DB115E03ADDB24181ECB9B0D7A5FEF37F67EB4B6BDC03C95764CAF467AE5C26B0000D892F01A68564A697FC4306253EBF6B16E2D0C7EA5EF3550B3183C6C652D0100006089F01A68D95143DBBE6E7B8D168360D5D740CD4E1A682F050000DC43780DB46CED85102BF02A2AC59FD2D2628D00558BAAEB77DE2500006893F01A68596B416F4B613BC014B4B02E020000F000E135D0A494528B41B0F61A0003897EFCEBB66CEAD317EF3900006C47780D309CBD359EE9DAFB01B013C795F4BAB6A82D00006C49780DB4AAC5CAEB75028C162BF4541502356A69515F0000E01EC26B80E1ACD3A3FBAAB5F723E7DCDC3603D396522AED425E799B0100A06DC26B80BAB416046B7302D448D53500004C80F01A68558BD5BE776BFCCCC500DBB14BAD6D2F3071B150E35BEF330000B44F780DB4AAC53ECB4F06EE39E79BC6AA99CF2AD80680658795ED8DFD0AB60100009A24BC065AD562E5F5BA817B2B81F0AD7ED740856A0BAFD759AC170000B887F01A6852CEB904C1B78D6DFBBA41EFD99A2D46C676DAC03602335269CB10E13500006C49780DB46C92FDA12398AF3D18BED33204A8D04185DBA46D0800006C49780DB4ECBCA56DCF396F12B69F565E7D7D12213B404D6A0CAFF72AD80600006892F01A6856CEF9BC91F61AC5E74D7EB8F2EAEBEB9CB39621408D6A0CAF5F55B00D0000D024E135D0BA565A576CBC9D39E7931214F7B339CF7254E136013317FDAE5FD7B817524A5A870000C01684D740EB5AA800BE8D2AF16D1C55565DFE43CE79DD852701865463D5F582F01A0000B620BC069A9673BEE9BAEE53E5AFE164DB7F1841F1F16E37676B1F72CE1669046A5573402CBC0600802D08AF812938AEB8F7F5ED7303DFF8F73FEC6E93B6F229E75C4B880E701F95D70000303129E7EC3D059A97522AC1EA2F15BE8EEF72CE17BBF84529A5D242E4E32E7ED7867E50710DD42EA57453F3E28839E754C166F00CD1BBBC0C92EC3D322051BEF3CBA2CB17DA6C01003C9FF01A988C9452B9617C53D1EBF9B0EB6AE594D2612CFEF86297BFF701B7A5E7F6AEC277803EA5946ABFA8DDD96026C349291DC4FA13875B7CF796596165CD8B33EF3D00C076B40D01A6E43002D71A5CF6D16623167E2CD55E973DBFC60FE579DC6C032D8880B1765A8734A4CC768A6AFEDFBAAE7BB7E5A0F18BF8B7BF95DF1533A80000D880F01A988C9CF39708B0C7EE7F7D1DDBD18BB24865CEF920FA60EF3AAC2F8B5F7E5B82F7D89F00EC460B01FBECA594F66226D7C71DB7A129BFEB63F9DDD17E04008035681B024C4EDC145E0CD45A635509AE0F860C7EA392AB84E56FB7FC158B69CD272518DFF1E635298EA197B1EDCB81D3CBA89E3CD3071CEA91523AE9BAEE7DE56F4959C077AF82EDE001F17D7A3AD0F5C34F39E753EF0500C0E384D7C02495CAA908645F0FF8FA3EE59C479B121CAFF960E9F158C558693B72150B4A9D0FB899D588FDB51F8FBDA505B89E0A2D6EA3A58ACA74A84423E17517335B0C125628A574162D3E8634EA750300400B84D7C064A5944A956C09347EECF935DEC5C286D585C011D02E57FA5DCD35748D9EB88BC73A21F543BE9F6BE00FB51A2978DCC60F666DD467E4E347800D00F008E1353079115A9EEDB877E5C28768B7A10AB7324B95E8CF69A9B2EA73CEB9B77EE6C076A247F19B06769FA0B232950C7C382E00001EF08D1D034C5DCEB9841A7BD1CBF27807AD44EE220C3F35FDBB3E3BE801FE90BB387E00B665D1C68AC4F7450D15FBEF524A9D001B00E06B2AAF81D989C5F81601E726D5D89FA38FF6B94AEBBA4495F56270A2AF85B67ECE399FB4BA8FA62666542C16D0EC9642C1976B0E50DD45DFF7E266F911035E34A4A1CAEB4EDFEB3AC4B5C0EF956D96B65400002B84D7C0AC2DF5845E0EBEF656432D61569D06EE6BBE67D062782B0B6B1EC4E7B38F1640ABCAC29C174B0B9B5E6DF6CF195263E1B5BED71548295D0DBCA8F33AEE624160831B000041780D4093524AC7115CF75569BD4CD5F540967A952F1E4304D5EBB88B991717665FD4A7B1F05A7FE391A594CAF9FC7DA59BE7F800005822BC06A02931D5FB6CC08A3955D73D4B291D461B9F9AC2EAA77C8E105B056D051A0BAFEF72CE2F2BD88E598A193B37030D7C6EEB3B33BE0000FEF21FFB018056C4E25A17034FF53E155CEF5E09AC534A6729A5328AFE6B2C9AD64A70DDC582A01F534A5FE275EC55B04DB4E1450CC2318EA3CA83EB2EB6110060F63AE13500AD280161090B070E1D4AD5F5A98364374A601741EF97A5C0BA752FE275FC51AA7F632149788AE3643CC70D6CE33B036200007F115E0350B532C53B5A028C11749EA9BA7E9E78FF8E524A659AFEEFF13ED65EF5B8ADD2B6E23721366B38B493861715EFADCCF0708C0000B3D709AF01A859F4261DB397ADAAEB2D95AAC1A896BF898AF9965A823C97109BA7BC89F31BC36AE9F328BC060066AF135E0350ABA5E07AC8FED6CB3EE79C6F1C209B29616D54CAFF31F12AEB752C42EC732D007AD7E2E276063686D75220DCCA02A40000BD125E0350ABD31183EBE2CC91B1BEA5D0FA37A1CB57DE464FEC13D5B62C51593BBCA616CAB4B0270080F01A800A95906FE4C5FC6E73CEE78E8DA709AD37F2BEEBBAAB9492D072F75AEC4DEF38185E6B3341CCD80000664F780D405522D87B3FF23609AE9F20B4DE5AE9FDFD6BB4125185BD3B570D6EF30B95B5C369745F3B3E0080D9135E03508D08F36A68D761A1C6072C2DC428B47E9ED24AE4C6828E3BD362E5757154C136CC85C12200800609AF01A8C95905D3BAAF2DD4F8B532B010ED5CFE18B9A5CB94BC88051D0D963C53CEB9C5CAEBCEA28D0000F038E1350055880AD4B7156C8B851A57C47B7355413B97A9FAB1B460D146E4D9AE1BDCE6D765364305DB01000055125E03508B5A4263FDAE43545B9F478B9057556CD474BD89C51CF5B8DD5EAB33262CDC0800000F105E0330BA94D25125E1A896212116CEBCA9A41A7E2ECA67E04280BDB5565B87E87B3D8C168F8F567BB90300EC8CF01A801A9C54B21D17156CC3A896AAAD7FADA0FFF81C957DFE7B0CE8B099563FBF5A870C20E7DC6210DCEA800C00C0CE08AF0118554555D7DDDCFB5D476F6BD5D675F828C0DE58CB419FD621C368AD2FBAF01A00983DE1350063ABA5EAFA2EE73CDBA020A5741ABDAD555BD7E3630C28B086A8ACBD6D745F19A818464BE7F8DB46ABC50100764A780DC0682298ABA5EA7A960B35469B9012E8FC58C1E6F0B5733DB037A275088F69E93C3FFB36560000C537156C0300F35553B5E1EC828208452F1AAFB6BE8E45CDAE9616377BEABDDC8BC7CBAEEBF6E3EFB50CA2AC7AB108B05561AEA5BCF7EF1AD8CEFB94D621A7F56DD6A4B4749E9FE5802A00C0AA9473B653002A131578F755E1ED47E0B68E4530D787E5A0F0398E2B0A4EFF3BA77030FA297FAC6053D67517C7DD45FC79B3CB362FA5023D3E2F071122BEEEFD156DE632E7AC85C813E2DCF947D51BF9B0EB9CB32AFB9EA594CE1A18E0282D4354E20300B3D709AF0186B3148E751190754B15A05DFC37FD86C731ABD0A891F0E62E82EA3F1F43F7238FCFEB61CC0E7833E4733FE2E79C732D3DE2AB9552BAA9B892FE29FF9B73EFFD2144BBAADF2ADFCC9F72CEAAF00180D9EB84D700BBB55431BDA8903E883F6BABE2E4DF3EE49C8FA7BE4F22902DC1F5DB0A36E73EB73155FE3CE75CCDF4FEF85C9F44983DF6009370F3098D0CCE3C6416E7A2B1A5942E2A1A945AA5EA1A006089F01A600B4B55D4FB4B3D736BBD11E669DFE79C27DD5F348ED98B0A0752EE22503FAB3D948D7D783C72BB1BED439ED0604B9C6582CB0154DE5E66F2DF4700009B105E03AC21A6192FFAE1EE373C259DFB7D9B73BE99EABEA934B8BE8CC0FAAC826DD948ECCFD311AB7B7F6871BF0D25DE9FFF6BF8257C57D3CC83A94A2995D914EF2B7B799F73CE87156C0700403584D700F788B07AF150513D6D93AE744C29ED47705D4B3FF54FA505C714060BE23C713AC2A080EADC27A494AE1A6ED7F429E77C54C1764C5E65ED43AECB35C79C160E060058C77FEC2580BF02BE94D271B9914D29E558CCE9BDE07A16265BE1585970FD292ADC8FA652E55EAA6363A1CF0F033FF5AB688DC1C35A6EBB7018D5E30CB0AF23341E5B699F7428B80600F89AF01A98AD523599523A4D299520EDF7AEEB7E1156CFD22417BFAB28B8BE9C5A68BD2A16D8FB3E02A8A19C54B303EAD47278FD2242557A1661F1C1C801F65D545C4FB6751500C07308AF8159890AEBB394D297A8AEFE51FFEAD99B5C785D49707D1B0B8FCD22948905D60E060CB05F45DB12EE7F3FAEE2186C95CAFA818C1C602F5A854C72101500601784D7C0E4A594F6CAC24C4B15D6EF2AEAFFCBC8A6B630DAD2E28C631EE3A545C87E04BAB31101D49001B680F3712D7FB6DF94EFAE0AB663169602ECCF03BEDECF826B0080A709AF81C94A2995BEA1253CFB23FA57ABB066550DBD4E77A682E0FA2EAAAD8FE6DABB75E0005B6B89C7B53E7862706240E59C95732E9FA99F7AFEFC96DFFD53792E3DAE01009E26BC0626A58477B1F062A9B2FEB5EBBAB7DE611E31998AB7A5E0FAF5489BB098FE3EAB6AEBFB44803D44B0FC42EB9087C5B138641FF25D135E8F20E77CDA75DD5E0F0BB1DEC5EFDC8BE70000600DC26B601222B42E0B98DDC4C28BAAAC59C794A66B9F55105C9BFE1EA21DCDCF033C95F0FA712D0FA694BEE6AAEB471055D86521D6FF4625F67366E95CC7EF28A1F5B16A6B0080CDA49CB35D06342BAA4D8FE3A18F359BFA6E0A3DAFCB22A4D1CB7D0C9F4A9B9071F740BD524A573D0F2A5C9645315BDF4F7D89F0F7D7865FC2E76865C1C8A20779F9ACEDC7E3E53D9FEDCBF8F32A1E177358B01600A04FC26BA05929A512989D0AAD7986FFB65E05179F838F233DBDE0FA0929A5FD5828B62F7739E797B5BEFE1AA494BE34FE3DF1AD00140080B9D23604684EE9F11AD58C1F05D73CC3DD0482EB831183EB6BC1F5D3A295CAA71E9FC239F069166E0400804609AF8166445FEB5269FDDB88BD7D998EA6FB33C714F6B142B96BBD963772D2E72FB768E39384D7CCDEE21A2AA5D47CAB2C1E56AE0DCA7B1CEBC0F0D73E3929452FD16A10C709D0206D43802644387366214676E8432CC8D5A4017A293FE4AEF47BADAD8D4184F98B5EB4ABCABEBA197341C9088CDEF4F4EB27D1BBBD4F13681DF243CEF9AC82EDA041F75C437D9F736E7D50871529A5E3182C7D11DFD57B735E2034DA762D2F66FD73CE79F661ADE30468D137DE35A0765115F0DE1BC58E35DB433666208C35FBE0A896E03A02EB721376B8CEC0564AE92EAA70CF46087BCF7A0CAF55933DED7CC4454D77E1288E21585B549A966BA81F57FECDE904662410E2BB70F53BE6457C3FCE32AC7DE0DEE1B85C3FCD35A87DE4383935C307A89DB62140B5628AEB85E09A9E34D936242AE8568388A17CA8A15A2FA6BB961BB03F625FAC3B23E3450498BFC574D9FBAAB4FBD2E77E1BF275B4AAF5A0EE4D040FB096F8AEB87AE0FBE255545FD2B8781FAF1E181C3D9EDB79A37CAFC7CCB4FBEE1D1681FEEC4498FFD071F2CEF70B503BE13550A508951EBAC8825D68AEF23AAAE8C60AE16E6BA8E04A291DC5B9E1B955B4E5DCF2FB50FD1EA3D2EB7A88E7E2DEFD7F1EC770CB663FDD9DA7ADAC0FF2D8C0DE891EC0ED5AF42CEEBAEE97475A22BD98D37923BECF7F7F6266DAAC02FD9530FFB1D65966F60055135E03D589E0FA427F6BFA545BCFE6359D8DD8B7F768ECA9B611C87CDCF13E781F55D8438438FA528FABF5EAEB4361238F79A2DA7AD5AC82CD29591AC45DA7C063F255B5E5B84F29DDAC39537336C7FD9A61FEC21B8B3F0335135E0355890BF2DF1B5F588BFA3557019B522A7D9DDF8EF4F497632F08186D42FA6A975202802102ECBE5AD534DBBF7D60AD5796BDD09794FB6C506DBDEA47ED02DA11EFF3F91683B8930C6B9F71DC4F3AD07FA275CA634E87DD5280F509AF816A4470FDD13BC2009A5AAC2742D53183B7516F7CE3DCD0F7627BAF07B871EB2B64165EAF21E77C3581D621FA14F32F1B565BDF4760D58018C0BED97210FBDDD4AA6A1DF75F5B0AF3D7ADB65EF53AAEB700AA23BC06AA20B86660AD857D2723CE4618B5EA3ADA080D756E786711B3C96B3DB078656A37DDF3AA4E57BD754CD56BA9DAFAD7675E074CA2FADA717FBF1D84F90BA7DA530135125E03A38B0B2EC135436A26BC8EF0B6AF7619EB183BEC1BFAF97F69703A7153330946D67ADFEB4EEB107618542DA8BEAED033ABAD5735DFD3B887E3BEF9407F8761FEC20B337C801A09AF8151453037853081B6B414F68D192ADCE69C47FB7CC68C8C7516A4DAB5A6829C6887C17AFBAA04419F1BDF57EF54C6CD530F41D582760115D961B5F5AA2607297A3CEEDFB47CDCF710E62FBCD70B1FA88DF01A184DDC7C9F5B9C91113411F645D5D518E1EDC2D8034B63DD54BEEDE9C6AD8FAAB7D67B388F610A03A687156C0303EA31A85AD02EA0023BAEB65ED5DC20C500C77D93D5D729A5931EC2FC65AD2F700C4C8CF01A18D3798F175D30056357498D76F312E1F198C17D1FD366F77BF89DAAAE3794732EC7F55D531BFD3555B233D163D5E92AED0246D463B5F5AA66C2DA0102DA2ED61168699FECA794CAF7FEFB9E9FEA4D0CA4005441780D8C222E14C70CA698B7EADB864475D498833B7723B7A318FBA6A98FE7EFA3F25A78BD9DD6ABAFDF98D63D7D03549DAED22E60043D575BAF7A55FBC2C4E5181C28A05D386E61D641BC6F6501EDD7033DA5D918403584D7C0E0E2666CA80B52F84A233D82C7AE041A7B1F8DBDB0D4AB5D8638114EF4514D77D1C3EF9C83292C50A72A6EA296AA70FBAE3ABD8FC51B0712EFF3D900D5D6AB4E6A0D25E3BBF26AC080B68B7D5FED71BF743EF865E0E3E495D918402D84D7C0A0E262591F3578440555D75D05A1680DD57FBBDC863E6E004B75BCF07A0B318075DDDC86FF9BD62113347015EE7DDE4691013D8A05CBCBF9FBDD08FBB9BA163103B64D79C8BB784FAA52C1F9C06C0CA00AC26B6068C7FA5CC3936AB8A9BC19F9F987ACBA7AC84E029C0882FA689334858507C7D47A85E96BA1C2745410DE2D6B7211BB5644FB87DF47FE9EAB2694AC20A05DA8E63B61A9D77D0DE7034547C0E884D7C060E22259BB10C6765BF33B1041670DC1EDD8E1F524F43CDBC40DE5F34C21FC57213B011585770B166BEB41049217D1FEA106A30E52543660D3C5713FFA8C96117ADD3FE58DD918C0D884D7C090042DD4A0F650562B806939ED69B6C9AD9621CF93732E0BB77E6AF935E87BDDB60AC3BB657A5FEFD0D200454D8B95BF1B2B94AC70C06661B4450A97AAADC7E875FF14F770C0A884D7C0207A9C360F9311374C63F4BFA40751C1D5D7FB695AFF6EB47E435E5BF0C39A2A0EEF165ED55085DABACA0728BAA1BF4B1AD81FA32CDE5861B5F52AE7036054C26B60288216789A1B837FDC55B00D57DBFEC3B8C9FBB8DBCDF95BA9BA5605B50351BD5E752BA1A798CEDD9606C2BB65276355A14E41030314DD90AD32E25C55FBFEE886AC48AFBCDA7AD56855E900C26BA077AAAE616DC2EB7F6C1D1C8FBD0D7123DA5770DD190CDCB9D6DB23681DD28846C2CC65AF2A5940B829658D97860628BABE07295602DA16F64737C4F74203D5D6AB5E381F00634939673B1FE8555CC09BDADCAFEBAEEBBE3CF319F61AA8FAD885CB9C7375958AB1A0E91F156CCAC27763F6548E1BDD316FE84A75F3DE26FF20A5B41F6D28FA5C70B3CAE3B76511DAFC5FC32FE13AE7BC5FC176F080A5855B5BBC162AB360F6A2473C4F48291DC700632B21EDC2CF39E79D0F8C46407BD6E8F5E54F39E79D87D8713E386928B45EE67C008CE21BBB1DE853047282EBED5D4628BDA8005D84893739E75E171E8CF76E11DE950BED4538B2F8FF5FF61CD2CD4D6DD593634F0D3D1FF9C6EE7CDD1F8CCFCAC940FDCA553DED58B9094F297D6AB8DFFCEB12860813EA14D5D6670D86990B8B6A4B333E1E11DF03670DCF343C2E83C6BB3A8F341ED02E948AF4B35D9E5B1B0FF33BE703602C2AAF815E55503DD98AEB08A8FF7EB414442CF5065CFEB3D670BBD6CAEBDA6628F45285B58994D2CD883778DF3E36401437E687F118EA7DEBA50A8CBFABE67F6F78578C3A5382AF355E6DBD4AB5E5231AAEB65EB593EFFD0904B4CB3EE49C7732683CA17B22E7036070C26BA05729A52F13B898EFC3755451FFF998F205E05205F77E04DAEF47DEA45AC3EBDABE903FE59C47EDC11D81C02F233CF5BF8E9108A1F6978EE383110666467F3FA62EA574D5F06C92D1079BF8C704AAADEFE3185B11835EA7135AD7E559A1E444AAADEFF3E860F653066A293634E7036050C26BA03771F3F6AB3DFCA7BB08AA4B75EDF99CAB1546AEA6ED6A0CAFA34AE9B70A366559157D742B385E6AA0A7F100524A473D2FB4D927BDD02B30B16AEB55AA2D97A4944E2A188CEFC356A1E4C4AAAD576D3D783CE1E3C4F90018D47FEC6EA047B5F5F01DC3E7AEEB7EC839977EA48739E79DF6CE6B54AFBDBA1B5563E8F43A8298B1CDBDDAF8BAD2E3638ACEE386BC450637461603F637135EE7E3859EFB7F55D1C62C8D2906925DF4BE5EFBBBBFFC6CB4C3F86DC203CDEF6216E1DA66709C381F0083125E037D9A6B787D5B2A57BAAEFBEF22B0AE609B6A72D5CEA60EA6D67072F4ED8A3EBE1FC6DE8E91FC195C1BF01A46ECE756CFD72F360D57D88D08EFCE63A6D9D4DBA46D146C4E4D54D1FE3EF1C5AAD70E25A3DAFA6A266BDBACBDDEC44C8E936EEEE7036058C26BA01771413BB75ED7D751655DA6D19D089C1EA4F2FA6BB5564D563100158B255D56B029432AD394F79D4706D7F28298C2EB11C467742E95EF2FE65A98106D85A65A45BB6ADD194F536D13729FB7D1BBFA51333B4E667B3E008627BC06FA32A78B99125A7F1741932AEBA78D5D795D559548544BD63AD053D3E7F8303E6B73F093C519C7118B72B53A50A2BDCC78E6B470D92C17698BEBBBDB0A366508AF22847DCADC8E85272BD267769C74733D1F00C3135E037D99C34DF46D545AEF476B03D63376785DDB34CE9AAB255F441FD7D14575E341F4919FAA724EF95FCEB9E5EADF296875FFABBC1E89607336E614D43DF91ECF30A85DB7F7F59C8E935731DB16A03A585024000020004944415457C26B60E7A2FFD9D4FBBC959ED62AADB7102164AB8BA2F5A1F6E9E6D52CC8538E9DD2477EA23DB017E7143DE14796733E6F3490115E8F4BB03971330B6BDFAC19D4CEED5878F2733EC350DF4C31A077C26BA00F53EEFD781D95917A5A3F8F80EE1FB52F76B3EE0DEC60A207F67713B9392C2D2ABE754EA94E8BD5D76F2AD886D99A61B039973EDFABE63448B14E9B8C8B99AD49F16ECD450AE7749CACBB4F00B626BC06FA30D5E9631FA24588E0F5F946DD879585B12D0400D5DD84C50DF37E542CB7E8327AE51F449F65EA726686085B106C4EDCCC0629D66D1B36B76341EFEBAFA9BE067A25BC06FA30B56A9C12607C1FD59EECC6D8615D4DE1750BD52AEF6AACB28B3622252CFAB6EBBA4F156CD23A3E2D85D67AE5572AAAE0CF5BDB6EBD47C71581D55C16969DD3C2DCABE63248F16A9D752FA2A8A395EFE05D5837A8D54A08604784D7401FA6145E979BD083E881CAEEA85E6F4FB56D144AE572CEB9DC38FD372AB16BAB76BA8DED2AED418E84D6CD9853F0C0EECC65A0FBC55C176E547D7DAFE319CD565937D49FD360D6EBDA5ACC01D322BC06FAF06A227B75115C0B5A77AC82F04E75E2E6DEAC73B336A6452576CEB9DC40FD2F16761CEBC6F176A9CA7A2FB64B7B9086C4FBD55A2F57E1C1C866D60378CED5D72DF6C5DFC65AEF71CC5699CB3EE9B454B9D79CCF0740CF84D7C04E4D68019FCF115C5B40AD3F73A946794A4B8BAC9DB5B2284F19742AAD7E4A9FFA682BF24384C97D1D77771158FD148BBAEEA9B29E84D6C218E1751DE61258BDAD601BC63297BEF82FD6BDB68F365E73A9485F6B91C2B806F830CC268D4E6108D01BE135B06B53586DFA53CEF95070DDBB31AB50A7D6977D282FE286BD29D156E42CC2E4B2E86A2A15D11134FF1CA1F3E59A41C46DFCECE7F8B7DF4758FD32FA589F9AAD311DD1326A4E8B6EB10373EA013CD73EEB33AB34DEA4A2764EAD64D6DD2F7309F5E73C9805F44C780DEC5AEB37319FA2772EFD1B33E09BC220CB58DEA6949AAF2A2CD55011349F44E87C1001747AE2B1173F7B18FFF65C583D79739A0ACFEECCA567FA9CAB2D4F67527DBD76781D95C69FFBDD9C6A6CD2526516B3312C1A0CF445780DF08F6BC1F5A0C66CA75053AB8E166F7C7F7183C28CB4D41EC0E7B212D1337D0ED5D7B33DE666547DFD7AC39661473309F5DFAEBB5F6216CF1C7AE1FB0E027A21BC0676ADD57E9BD72EB806376AB56A45ABA2B75AB57B3EA11EF7F0A008A89A6B9743154E6610E2CDFD7B602ED5D76B5F23C739732E330F3669A93287EAEBB99F0F809E08AF815D6B31BC2E371D7A5C0F2CF6F7983D002D6CF63CA5FFF5452B0B38C233691DC2C6A2FA7AEAC7CE8B397F0FCCA8FA7AA350B2B4E55269FC6F33E985EFDA1AE885F01AE0AFE07ACCC50377AE541597B60E4B8FC394D2493C0E57FEDB98379D63561DABB47F3E0136B310DF1173E9E3CA6ECDA13277EED59673788FB7B9663AB45FBE32F5D918AF2BD8066082BEF1A60233F72116976952B4BED88FC741543CBCDAF4B5A494BA689D72138172D927570354A35F8CB83A792DD5213795F5E0DED4EB08B00FCC5E60E2CE463C5FD1A8725E4C299570F3FD84DFC359575BCEE43DDE788022F64BE97FFD6B3F9B548557E55A7CDD2298F273533F564A4183EB4160D7545E03735616686CAAFF5C54541FA7944ABFE17261F847DC14BC8F0074E3E07AC9EB0866CAEFFAADEBBAFF4B295D958BEC1E17E71BB3F2BA964AB12954FD9763E7460F6CA62C16DC1AB3D511ED3A9DF8B1A355C0F4ABAFB76A0F3393850A37BD469EFAB1E25A10D839E13530674D04D725108C00F926C2EA5F22647E31C0D39750F2C7126697B03CA574B6CB207BE4AAF75AA636B6BA60E3AA450B11372D4C99851BD9D8CC16B09BA599F4BEDEF6FBFD4858FB8F19F54907D819E13530579F6A6F1752A65A96CAE7AEEB7E8F00F93955D5BB50C2C9771164DF4405F82E7A1D5F8FF5827AAC28DFC494FAAD9763E4F798260C5324BC662B39E7B309575FABBCFECBD42B6AB77A9F67B070E936A1FE948F15EBA0003B27BC0676AD8520EEAEE60AA808ADCB7EFC58F1C227AFA202FC26AAB19F73E33AE620C2E8E175AC3E3F351FA3A723DCAB0C7CC582B14D855E0D2CDCA8CF68DDA65A7D2DBC9E4745EDD6EF73CEF964C283371BAF5B32F163C50C3C60E784D7C0AEB5105E9FAEBBB0CA9022C8B98AD07AEC2AEB752DAAB1FF7846883D66785DCB05F614FB41FE183DD3DDC4CC54B43C2AE7B593687D7411C7442E3DF5A3B77E0DB31F36755EF1B64D71306C32265E7DCD5FA65C51FBDC418AC9CECADAF2FA77EA95FA003B23BC06E6A8BA69DF51A5FA5BC595D6EB2821F65504559B4C191C336CA92538ABBA85CD33BC8E3ED87ABD4ED40301F59708A87F8FF3DAFB687DF4E69E735CCD41F0BD22801438B02DE7C3099B7845EDB3C2EB68D737D5C51B37DE377A5F03AC4F780DEC5AED21DCA79AAAAE63EAFC55043B53F02282AAAB75FB49C7FB315625DA8B4A2A83A71A5E778B63222A6E5BACB225AACA9642EAF3A50AEAFB02EA751793BD8C9BF7163517BA5307D5D7B3A0A2F66153ADBEDEAACF73B45371AC003C41780DCC4D3555D7119A5E355E6DFD9057B1B0E3BA15256386B787233EF79FA21A69EA372FAFE398786E8F747AB6D48FFA6451495D5A032D85D46F7774DE6A3900AE75DBB50D6983EAEB098B4139035CF78882850FD56DD8F33DA71042F535C01384D7C04E450857ABDB5AB62F82EB8B867A5B6F6BD1F7F8A9B072D6E17598CB8DEE737BA4B3432B41F5792C16FB7F4B41F52695D49B6A76C641CEF9BCD201270B36B6A1D6E387DD99E200C556D5C5F7506DFC6F2AF5019E20BC06FA705DE95EAD221C8C7ED0E73D0642B5791D6D441EAB4A1933C47ABD618FEEBECCAD4A6B39C4B6A8E300A2F5C7E15245F56A50FD76C001B53298D87A957075EB2734B268F2ECE9753B7D5161FC69622F742733051DFFFF16FBA3C6EF13806A08AF813ED41A48D452E5773E838AEB552F62E1BE7B43CA91FB5E7795B40E399F691FD41262FF1E61EA51250309CD8B6AEAE3A5451473B4FEF875A9A27ACCF3D014FABC57F71A6A5AD3812709EFA66F6AEFF1CEAE51A2D7B3DEEFFF703E007884F01AE84395E1758483A32A6152844673F46880AD75C89FE65C79533E171F4BE5685463D7F29E546DA59AFACFB61F1154976AEA5F961651AC4DF3330D2A6C1D22086A48545B4EAD32972531BBA4D6D988DBD8F5E098DEEF21061E3F57B1310015125E037DA8B1A26EF49B87A8281DE342BDBCF69F63819CCB788C15723C16608F1966BDADA4E2D7B4D1BF8E91528DFD6B59283082ECA3B9F7C75EEA4D7D1CFBE4BE6AEA21DB7E3C4B0D83893B52D3EB5075DD9EA9545B3AF61EA6A2F60139E733836EFF32956B400B07033BF78D5D0AEC5AA9344929DD5616A2D47021753C529FEBBD989EF9951286C50AE907117C0DA1EC835221BA1F95670B630F7A1C8E7DE3502A6F524A9F22BCE59F20FBCFFD9152BA8EE3A47C9E2FA6D822213E932FE373B9178FA9CDD6985275D979459FD729B4629995B85EBADE552FE11109AF1F761EB38AA6A08F73CCC984F6CFB39441DD0AEF9FB661E16060E784D7405F2E2A0BE06AB8B13A1EE9795F94CAD5A870F9979CF345BC57A751795C02DCA301C2B257714377B0F83F4A903DF24DFCE8E17538115E3FE8F5F2F19152BA8B20FB2A3EE37FFE596BA81DD5E37B4BE174B7F41998533BA12985AC35BD1601629B4E8577D315D7369F072C10E8D3CE43C9726D5ADA5E4D20B0DD5591CC59CCA4026049CA39DB1FC0CE45BFDA5F2BDAB3DF8F394DBD82FDF139E7BC760FE1A8FE3C1D2048FE29E7FCF794DAB88119F3A2FDDB1A82CFD2164280FD6CB711E67D59B9A95C0D1B370EBBA3EDCD6A9B994530BD70B0F4F7B9F6B97F48159FB35D292D5C2A798FFF173D7669480C1CFF5FE3EFD9BFBECBF9B752403091018AEFA2E861A7623D985FC67D69CFB6937D1383DC7F8CFF72B697734EAD6E3B502FE135D09BD2AF76A43619F7E9E5827B5D29A5D358386D4CFF5D69D3F1A4016E284AE5ECFE22C88A50F0F711F7511537E01166DC54F4F9815DB9CE393FB4686B936A095E0406ED9AC080E5A8D758B59BC80045B7CD75E43A04B6FF9652BA6AB99590EF22A00F166C04FA349505B976A186B066E36D8820F77F1132F7E1C5F222965135D8D773AD63ACD62EFF12378756E1678AA61870D5F09A2E2BD806B6D7FAF5921EB78F88EFF4D63FA3B77D04D75DACF751C3C2EACFB0EB45275B5EB8D17711D00BE135D0A7A9AC9ABD0B3584D7076BFCCC5722503EE831547E1755370B63DEC4BF8A9629A38B810337014CCDE406352B1874EB2CD6D8B6686B36F631B435ED6AD6D2FA67B4EFED6FF9BB61D7C77FCBFBC2DA0B402F84D7406F620AE9AEAB115AD574FB870102ECE52AE3B12FDA6BAA783E6A39D0801577136E2D30F6EB121EB6AFD5C0CA75DE7A5AFF8CF67D8E6B79FFEC74DB1BAF44F75D04F442780DF4CD023E131101F6514FAFE65DF484ECC65C5833BC59A9041F4DDCC054D1CA047660CAADA4C60EAF555EB7AFD5CF874ACBF508AF1FD772EB993E3EBBAD9ED385D7402F84D740DFCE2AA91CAD228C6C5D04CB9F7A7A19CBC1F8E791775535D5D739E7B31EF7390C69CA01EB98AFEDB2AF5EB40CAAD5CF878193352C16A66ED475E3DBDFA7BB9EDAE634F9B9B2702BD017E135D0ABB8A1AEA1FA7AECF0BAE58568561DF73420B11C5E8F5D81B6DA877B6CC7133B8698A7C9565E8FDCF35758300171BDD4620B0E9596EB6BF57BDC39E6617D7DAFB53858609D16A037C26B6008352CDC38F68289355C84EEE4E6A3C70189D74B81710D21574DD5D75FA2E7B8DEA2B4EA7A06D5C16EDC79AE570DEE41E1F5FA5A3D075A80FD61BD04FB8D2E823AE5D660C0C884D740EF62AAE1D86D0FC60EAF6BA85AD9E585705F373225A05D84B563B70E29D5D707236FC3DF629F1C5AC09146CD21FC30AD9EADA594C6BE4ED9C69D761293773B50905ACDF5D606EE7A0E6C5BBBDE53A10FF446780D0CA5AF5613EB7A35721B88B12FE83EEFB2EAB1C795D0976F5E6A08BBAAA9BEEEFEA9C4391060D3A039DCD40AF1788E1617E715564DDF50D7622D86D7E73DCF286AA9FA7AA8410E60A684D7C0202AE97D3DDA85715CD08DD9EBB08FCA903E7EE7DF9567B138E4D821ED9B94D2D11A3F371801360D9ACB4DAD208FADC4E0FA61837BCF313F7DBD87D771FCBF69704FF6BD6F5A9A8DA16508D02BE13530A4D39103B7B16F0CC70AEF4B70D4C705761F61D4EB95FF5DC3C5F0694AE96505DBF1B7A5005B0F6C5A20E082C795EFE8170DEE2395969B692DA0BD1CA82D4C55B3DCD654AEAD7BFB6E8BEBCE96CE09352CCE0F4C98F01A184C545F8F392DF6ED98AD4322401EA3FABAAF9B825EA64AAEBC47355C0CBFA8B15F6F04D8FB2357F4C33A665191D56790C174A594CE1AAD3AED84D7EB1BB975DDB67ABF068B5EEFEFFA7E9E1EF4BD6F5A9A8971ADF73DD037E13530A808702F47DCEB63B78018FAF92F7BAABAEED3DF377811D0D6505D5C063EAAEB471A034207152C880A8F11EAC23D22B86E31B8FB53CFFD7EA7A6B505396FA37D5BDF5A5CCCF76E80ED6EA91A5DD535D03BE13530863143C0E3315B404418FBD3404F77D7680FCD55B55C149F448550554A7890733E1AF0B8824DEC74B1D806E845CF93CA7548EBC1351B6BED7A6C88AAEBB37BDAC5B5E0B4CFEFB5945209AE5F35B22FEE1A2C92011A24BC06061701EECF23EDF91763AFE89F733E1DA052B60428078D8646AB0B6BD672515C8E9DF3DAFA5F2FC471F59D3ED854666E55D7DA28F0A894D2411C2782EB9988EB86D6C2EB5EABAE1B1FBCE9B3D775299278DFD7EFEF81AA6B6010C26B601439E793117BF58E5A7DDDFDF5FA8F7A0CB017C175DF21CA2055C811C0D7D216A354C25C541C605FC4FBF2B982CD816E2EFDAEE129516D5D829EDF1AAAAA64378E1B5C90B397C1FA89CC3A38EF63265EECEF96067CEF84D7C05084D7C098C6EA3FFDA2868BAD9E5A3D5C0F145C7703F76FACE9E2F875CD3D1AA38D48A9F0FA5E0B0346766B1127E62EC2BA32605F3E0B3F4E6977D4D84AAB36114856B766C61A5EEF7AB03E8E978B09CC3A7811FB6667D5F4B1A0E74563831CBDB64F015826BC06463370FFE755EF62EAEEA8A2D5C3FF76B488E5CF0306D7DD3DED3D7A13AF69CC853E57BD8DCAA16AC5424BE566E843CDDBC9A4A9BA66B64A18B5145ABF6FB0F2761DC2EBA79D35FCDE9700FB6617D7CBB1E8F545A33DAEEF53DED35FCB6C8AE706FC4BAD845ADA37AAAE814109AF815145783B56285945FFE212CCE69CCB85EB0F5BEC8BBB0827BF2DAD5886AA8088EA99A1A73DD776915C0640AAED81DDFD53857DBCC30112D884F07A1802C48A946ACCF2DDD075DD1F130EAD17C69A41D7849452D93F6F1B7F19E5F8FD2DAE77363ED7947D90522A0338BF4CF4B3F06304FC1B7F166280EB2C5A09B5B66F8E555D03434A39673B1C1855847F37235DB85D46705C8D983A78108FBD7BB6EB4B54685C448FE3C145DFCEBEA63FFF1C3DD1BF123740B5F50ABD6E6571CC98E27AAADF2A03B8CB39573BB0D39794523927BF19E1A9FF2B48184F847A47B128DFDCCEAFDF8D752D52B308333F4EF0A55DC7C06479CF6F565B434515F1E23AF670E28337ABEE62DF9CC735FA57E7E4B8E759EC9B56DBA75477EF044C9FF01AA842DCF8FD3ED2B67C88EA54D69452FAD2E30DC98337C215DF0C961B96C3566EE0633F9E08B1E9D1E7E8BD3E2B2386D7BEC70616838107330DAC9709B2564C38B8663377516CB230C677431FFE37608B42803F691B0254212E827E18695B7EDC66BADF5CC5BE1AA59226E75CA657DE56B8EB17D36AEFAD18AF4DD98F39E7BDF8CCD5B83F699F9621C3FA71978B87F1B532C85EFAF646FB843280FB6BCC409AFB20E09BDAD780184A2CCE7926B826BC88C0FACD8482EB9F05D7C018545E0355898BFEB1A6D1FD10E1288F18A075C7A3D3DF1BA868BA8E5E80CD4CA38E7D7A34A19B2BC637CB361623565E7751E577148BB5F24CD1FE607FA98DD79CDA1F6CE353CE79B6850071BC9C19CC60C2AE73CED658004621BC06AA93521A73C56D01F623A2B2F87D8F4FB1569FDC4A7B5FAFFA545A73ACF683AC59B4EF396EB80F237598ED0DEEC8E1F5C283EB0670BF38F72D3F0CE46DE73206509AF9DE7BAE08AD4F1C334CDC5DACEFA2EA1A1885F01AA84E2C667221C0AE4B2C2479D573F5D95ABD33E366F1B74A77D5AA1643EC9751897D34E2E79076CD363CAD6860ED36CE3BBECB96C4B96D39A4DE133AF6A2B9EFBD4DC471741883BDBE239903F746C0A884D74095A20AEA62C469BA16BF5A315045FCDAA15725158E9B28156967AD5DFC471FDD1337E86C60B68B39A5946ABBB0BE8DFEE36773794F9602EABD9587907A789FE35AEEBCF5203BAE4B172D64DE56B049309459B70402EA20BC06AA5541805DC2C6C339F66D5D35602FF2B543AF383E7EEF7F9376EE6E71335FFEACE1863EF6E522F059FE53D8C3A66E6331D059AA30BC5E761BE79E728EBD6AA92FFFC2D2B9AA8B10B15B0AA85F1A64ABDAEDE2D88BC7975A8FC19869B65CA1AFE73973A5CF355005E13550B50A02ECBB08B09BBBC9DF959452A940FF6580A7DA38F44A299D765DF7637F9B3488E51BFA3F8FB35D1C6FD15A65611148774B414F279CA607B3ADD06A7440AD2C30FB6571EE59848AF1F79B4D07D756CE3BEBB8EFE79703EACE796A16AE978EBBE563B0B889C73A9E3C6623985E7C072EFFFDC00008FCCB75F4B99E7D110F303EE13550BD685BF0EBC8DBF921FA37CEEA022EA55442A88F033DDDC6AD5A627AF8D5C457F7BF7CE2BFEFAB08A322DFE79CCFE7F88634D68BFF39EEE2BCBB4CE8472D968F4FDF8FB09DF239DA9FD3E2AB40DD84D74013060E511F522EE48EE7B260C980AD4216BEDDE62279468111B4E0BF73ADD21A70960A00F4E52E2AAE67B9760550A7FF785F80164460FCC3C89B5AAA773EA6946EB6981ADD8C52CD9C523A1F38B8BEDCB6BA235A6C7CD8FD26011BBA9CF9F4E2976BFC0C00D44A700D5449780D342302ECEFE3C26A4CA545C56F29A58BA8089F8C08E56F465849FF6407FFFE7A47DB026C6796ED42964C76501380C9135C03D5D23604684E058B38AE2A0BEE958503CF5AAD3A8CDED1A703575B2F946ACD67873E8D2E960653B255EB9FA928B37226DE7F1F80692A052047826BA056C26BA0491506D80B9F4AF5612B0B9645687D1C8FB1F6E577D1FAE3D9F49C85D1DCE69CF7E6BAFBE35CFA7F156C0A006CE23A2AAEE7DCF60BA89CB6214093A23260BFC25611A572F9D7E88B7D9A523AAC609BBE127DAD4FA245C8FB1183EB4FBB0AAEBBBF8E8BD31840008635F79621FB156C03006CA25C87EF0BAE81DAA9BC069A16D56E25347953F1EBB88B2AF1B29D17634EAB8F30FD70A4F620ABCA7ED9DBF505731C13657FBFDEE5EF051EF57D2B334EFA108381EFA7F7CA0098A0720D7E1CEB0901544F780D4C424AE9AC9240761DB711AE96EAF1AB5D561EAF8A20F72002EBC3CADAACF41676C5EBBEA9B0AD0CF4A9CC44591E0CFA12E79987AC7BEE2955C52F1FF86F7B310835EBC50A534AE7232C740BC0FD2EE33AB0957B8321E96F0D3447780D4C464AE928161D6C31B0BC8D8BEC8B95C0E96A9DCAE4086B1701D3FED2A3D6C5C33EE49C8FFB7C828AFBA2C3BA1661F4F239E1261EC517379F7548297D71AE0118DDBF2A8A534A6560F5A4F2199A43FA39E77C329F970B4C85F01A9894082CCF2B0E6D77E1BAF19618D7A5BFDE104F24C0A6627711487F59F9B3EB733606BB17E799DFED5A60643F978ADA895F033FE42E0A584EEF2BFA8802979399EE9B2E2AD18F0D7803AD125E03931355C867A6705769F015CDE386E5635BBB89895804D48B6AE9ABA896164E4F484AA9CC22F965EEFB81D1FC59691A4FEEBB6EBEFEAEA89D61505B16EA3E59674D9919EE9BDBD8377A5B034D135E03931581C289AADB6A941BECFD3116AC1460D3B345487DB51452AFD5F287F6E977CD48BEAA34F55D375B9F72CE47AB2F7E0641EDDAA1F5AA19EC9BBB38376811024C82F01A98B494D25EB41169B9CDC614DC45C5F568D3151BEF894E3DAE9742EA0B2135292517D30C699DF60802ECF9B837B85E36C1A076EBD07A55EC9BE309DD27DCC6F9E1CCB5093025C26B6016524AE5A2FDBD777B14E542FAB0863E7B7A60B3A1CBA58AEA2BBD225995523AECBAEE573B8601DC464BB47B43EB6502ECD97832B85E3681A07667A1F5AA58D8B1EC9F77BBFEDD03B98CC05A7B10609284D7C06C4415F69915C70735788FEBA708B079C0F552507D21A8661D29A5B386C30EDAB055CF5AB38D26EFE76D5B423416D4AE3D68B30BB16ECE513C6A0FF9EF96F6CDE02DF9008624BC0666C70DDD603E978BFF1AA72DC6CDC9857632B3B5E8517DA1F507CF9152FAE2BB849E7C8E506AEB055E63B0F67C468BD3CDC19F0B74EEA2C2B6F2A0F67354129F8FB50151F47258D9FEB98BCFF4F998FB066068C26B6096E282BD54ACFCE808E8C5D61541435235391BB78B905A5535BBA265083D5854999EEDAA9232AE77CE2C2A3A09D75114B0F3EFB018E8388AB076ACC18EEB3856CF6BAB248ECF51D93707F118721F5DC635CCB9EB1760AE84D7C0AC6925B27377D1DF7AEB4AB1A1A9C49FA4EB95B0DA745A766E8BC1AF725CEE39D7708F4F7D5752C660CB99E3AF591FA27DCC10AD33F623A03DECF9FAF86E11CAB6F65D1D61F6623FEDC7B9FDB9D5D9774B0B422FD6DA68E67A1AA04FC26B807FFAFF9D08B19FE53282EBE6DA2FC420C6B93622CDBA5D6A0172AE050843D8B065C85D841B7B3158E6BB86CBA52AD341CE5911B89D9A71D494DBA8B61E2DC48C6BE45D84B4935F5B6229D4EE96CEF90FF9FB3D1552033C4E780DB04488BD95BBA8063A6D70DBFF25A554DEFBF7156D12F75B0EAB555633B898B1F17183E7FD6E399C48291DC7778D2AD879A9A22D826B9D26DC45CFF32A5BB0C5A07F792C87B5AB4A385D06666E7C4F03F01CC26B807BB8B15B5BB58B326E4B2B992ADDAD5456BB09665429A5F30D7A08DFBB0680B51766E373AD6D116210E6C4828ED5F939826BB3880098BD4E780DF0B8E8FB776C8AED57AE63B5FBC94E738CFEA0A76EEA4771B752596D8122AA11035C7FACB93D9F73CE878FFD40FCBE13DF339371BBD2C7B7FA003242EC63ADB346751703E7A7066801E0DF84D7006B8870E1281E730E33EF22B43EAB605B06A1326D108B3E9817B14091B09A6A6DD05EA81CD707EB8697F13D731CDF33DA89B46332836D31EBECC840CAA06E63A0FC4CA53500DC4F780DB0A1A8C83DDA60CAF814DCC5CDD56CA7B10AB177EA7229ECB972C34E4BD65CA8B19C33F7B7A9A08C76228BEF19ED8BEA33F99921319072188329BEF3FAF129DA609D4FF1C501C02E09AF01B6B474737734E1A9B6B30FAD5745882D545ADFED5255B51620346DCD851AEFA2E2FAD9C7FA4CBE676A37EB9921D13EED288E4341F6F32CFA9F9FBBA60280F509AF0176608201C37504D6B3690FB2A9A51B7A53FCFFED7225E8D1BB93C948295DAD718EFFA18F73E7D2F7CCA1C1B3DE2C82EAAB387F4D765D876D38063776B7E87D2EB00680ED09AF0176ACE1207B719375AA3A7633D14A66F1984B905D2AAA6FE2A6FC46AF6AA62EFA01FFF6C4CBEC25B8BE4F6CCFE22148DC4C09A9BF387F3D8F63F02B161B06801E08AF017AB4D4BBF4A0D260F36E690AABBE8B3B1015D98713B9995F0E78BE4435E28D6A6AE628A574F1C467FA43CEF978AC5D1341E27E3CF684897F0FB05D2D9FC7048AFD89EFBFE5C7948FC1BBE55946661A01407F84D700038A1BBB45C0703052FFC8CBA529AC6EE27BB65499B608946AABC6BF5E0EA605D4F0B53877FFFEC8AEF994733EAA6DD7C54CA0BD3807BD8CF3D0CB09B4B75A04875D7C9F7571FEBA71FEAACBD231B838F60E1A3B062FE3CFE5415C0B0D03C08084D700238ACAECE54AB9C59FBB08B597ABCEAE4C8BAE4704618B9BF86EE9CF5DDDD05FAEFCEF45B8F36529F071F30D6B4A29955620EF1EF8E92A83EBA72C7DFF74F1BDB377CFDFBB9E83C6C5F7D4B245A5F4C2DF7DA7F5A09E9E18E0ED063C06578FB99BA5FFFDF7DF1D6B00500FE13540A596AA95BAA58AB987FCEBE64BD5D9F494C0DBE0030C2FCEC57F3CF0C49739E7036F0B0000F443780D00000F78A4EABAB4DC393083010000FA23BC0600807B444B83DFEEF94F826B000018C07FEC640000B8D77DED9A04D70000301095D70000F08094D2D5D26271826B00001890F01A00001E100B365EC5A2B8826B00001890F01A00001E11BDAFAF04D70000302CE1350000000000D5B160230000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E03A09C5EE0000020004944415400000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000501DE1350000000000D5115E0300000000509D6FBC250000000000A494F6BAAE2B8FFDAEEB5EC60E39B867C7DCC4A3B8287FCF39DFEC7A07A69CF3ECDF140000000080394929BD8C607A7FE9CF17CFD805B711649FE79CCF77B12B85D700000000003390522A21F56184D5AF7B7CC57725C4EEBAEE2CE77CB1ED2F115E03000000004C544AE93002EBC36756566FEB73D7754739E72F9BFE7BE13500000000C084A4944A0B90E31103EB55D7A5DA7BD3005B780D00000000D0B8E8617D14A1F5AB0A5FCDE79CF3E126FF40780D00000000D0A894D25ED775271555593FE6BB4D7A60FF67944D0400000000606B65F1C594525914F18FAEEBDE35105C775119BEB66FC6DD560000000000D61595D6675DD7BD6970A71D6CF2C3DA860000000000542E7A5A9F469575B372CE69DD6DD7360400000000A06229A5B208E34DEBC1F5A6B40D0100000000A8D0C02D42AEBBAEBB8890FC6AE5BF1D8D119C0BAF01000000002A93523A8CE0BACF8518AFA315C979CEF9CB433F5416871C63EF08AF01000000002A92522A81F28F3D6ED165D7752739E78B357F7EB512FB39CFBB36E135000000004025524A673DB6E8B82D2D403608AD1736FDF9879C6FF2C3166C0400000000A840CFC1F587AEEBF6B708AEBB6829F2E999CF7F176D50D69672CECF7C4E00000000009EA3E7E0FA879CF346C1F1AA94D2CB58CC71DB1EDCDFE79C555E0300000000B4227A5CF7155C7FF7DCE0BAFBA7FAFA202AA837F5C3A6C17527BC0600000000184F4AE9B0C7C5197FDAA64DC84372CE65E1C6FD0D165EBC7D4E78AE6D0800000000C00876D08AE331B739E7BDBE5E554AA954611F4598FD7AE93F5DC66B3ADFA6DA7AD9373BDB5A00000000003671D253705D3C2B387E4A5474EFACAAFB3EDA8600000000000C2CA5B4D763BB90E24BEBEFA9F01A000000006078C73D3FE3CBD6DF533DAF0100000000069652FAD263CB90AEEF9ED74350790D0000000030A094D261CFC175F12AA5D4777577AF84D70000000000C3DA1FE8D94E524A433DD7CE09AF0100000000867530D0B395EAEE8B56036C3DAF0100000000063440BFEB55772530CF395FB5F43EABBC060000000018D690C175B75481DD540F6CE13500000000C0F49500FB97945209B1876A5BF22CDA8600000000000C28A55443287BDB75DD69D775E739E79B0AB6E72BC26B00000000800155125E2F2B41F645D77557F1B8A921D0165E03000000000CA8C2F0FA21771166AFBA89C7C222F0DEE98290C26B00000000800135145E6FEA2E2AB8CFA31DC997E7FC32E13500000000C080261C5E2F2B41F659D77527DB86D8FFE96DD30000000000B8CFE50CF6CA8BAEEB7E2CED44524AC7DBFC02E13500000000C0B076DA1BBA7225C4FE25A57491527AB9C9A66A1B020000000030A094D27ED775BFCF709F5F775D77B06E1B11E13500000000C0C0524A375DD7BD9AE17E5F3BC0D636040000000060785BF5819E80D75DD79DAFF33284D7000000000003CB399700F7D34CF7FB9B751671D4360400000000E0FFD9BBFBAB38722C8CC3D29EF91F4F0430119889001C8199088C23308EC03802E3080C1118223044608860E808C644A03DB26FD9E5A6BBE9AA924AF74ABFE71CCEECCEEE8C8BFEA8925E5D5D152007185E4B35726B1E9C73FB2184FB75BF3795D7000000000000005080F47D3E74CE5D35F8FAEF38E74E37FD1FA8BC0600000000000080C2BCF747CEB9B3060F71FC6B5DF53595D7000000000000005098F4C0DE77CEBD75CE2D1A7A3FD6565F53790D00000000000000CA78EF633B9123F9A9B91AFB2184F06CD5FF40780D000000000000008A79EFF7A437F6BEFC1C54F67EFD2395E7BFF9A3EC35010000000000000036919ED0E7FDFF8BF7FE9904D94E82ED4EFFEF5B09B9E3F53E0AAFA9BC06000000000000804A79EFF725DC3E76CE3D57FA5BDE84100E97FF26E13500000000000000344082EC338515D98B10C2DEF2DF24BC06000000000000808678EF6315F6274DBF7108C12FFF3DC26B00000000000000688CF73EB6E9F8A2E5B75E155EFFAFCCA500000000000000004A09215C3BE7DE6B7E03A8BC06000000000000804679EFBF39E7764AFFF6545E0300000000000000FA6E15BC1A37ABFE26E13500000000000000B46B4FC16FFE6DD5DF24BC06000000000000800679EF4F9C73BB0A7EF3EB557F93F01A000000000000001AE3BD3F75CE7D50F25BAF0CAF39B011000000000000001AE1BD3F76CE9D2AA9B88E16218495AD4BFE98FF5A000000000000000073F0DE3F73CE1D3AE78EE46747D90B7FB9EE7FA0F21A000000000000000AF0DEEF3BE762B8DCFDF529B7BDC30D6F4308BF1D74E8BD3F94FFB82F0731C6BF1E287F6FFF0A21DCAFFA1FA8BC06000000000000801978EF63A07C2C95D0934365EFBDF5B7ED665D70EDA8BC0600000000000080BCA4CFF48973EE392FF56FFE0E21DCAEFB1FA9BC06000000000000800C141E8EA8C9C74DC1B5A3F21A00000000000000D2925ED66706FA4D9772175BA72CF7EC5E46780D000000000000008978EF637B900FBC9E6B3DC4832437F5BAEED036040000000000000012F0DE9F3BE75EF15AAEF52015D74F06D7D1FFCA5C2300000000000000D4C17BFFCC7B7F4970BD51D72A64639FEB3EDA8600000000000000C004DEFB18C83EE7355CEBCA3977FC548FEB65B40D010000000000008091A45508C1F56A0F125A5F8EF987691B02000000000000002378EF4F6915B2520CADDF3BE7F6C606D78EB62100000000000000309CF7FEC839F779C03F78E39C8BED4562EB8CEBDEDFBF8F0718C6BED9CEB9FDDEDFDF939FEEEFC79F1DE56F550CADCFE2CFD01621AB105E03000000000000C0001234DF3F11262F9C73B1EAF83284709DE2F5ED05DCDDCF9E9250FB4A7ECFF394FF52C26B0000000000000018C07B1F43E9976BFE890BE7DC79AAC07A1B4BA176FCCF87F28F1D64FA231FA47ABC0BE7275759AF42780D000000000000005BDAD02E64218713CE165A0FB8E62ECCEEC2EDE5FFDCE987DD374BFFDBB5549BDF86106EF35EF10F84D700000000000000B005A9708EC1EDEED2FFFBA373EE34570572ABFE68FD0500000000000000802D9D2C05D70F526D7DC90B981E95D700000000000000F084158734DE49703D4B0B8D1651790D000000000000004F3BE905D7B11FF4116D42F2A2F21A000000000000003658AABABE08211CF37AE5F7BFDA7F410000000000000098E84882EBB704D7F3A1F21A0000000000000036F0DEC7AAEBD310C239AFD37C08AF01000000000000600DEFFD9E73EE90E07A7E84D7000000000000000075E8790D000000000000005087F01A00000000000000A00EE13500000000000000401DC26B00000000000000803A84D700000000000000007508AF0100000000000000EA105E0300000000000000D421BC0600000000000000A843780D0000000000000050E70FDE12000080F978EF0F37FC61DF4208B7BC1D801EDEFB7DE7DC9E736E5F2E6AF93B7C1DBFBBF1AF7C7F0100406DBCF7CF7AE3A0556E4308DF72FDDA3E84C0870A00002031EFFD9E845C87127C1D6CF1275C85108E782F807224AC3E92EFEE36DFDBCE4D0861D3E2140000806A5268732861759CC33C7FE27A1F9C73A72184B35CBF1795D740C37AAB67F1C6B46A252DAE9CC50AA27B5949A39A08003690D0EB5882AFDD2D5EAB38D8BB94CACDCB9C150B00D6F3DE1FC9F736FEEC6CF952F1FD050000A6492E74D45BB8DF661C74D78D814208D7B97F7F2AAF81C64825E091842B4FADA02DEB2669718276C96707007E0EF8E23DF564CBC0DACD51A100E069DEFBF8DD3D1DF0DD75F2FD8DDFDD33026B0000609114DD9C0C5CB88FA1F5C91C81751FE135D00809ADE3E4EC55A2DF7821C1CB399F21002D92FBEA8904D7DB0EF89C0CFA8E4208F77C708032644BECD98885FCF8FD3D66371A0000B048C640A7035BA345EF4308A7257E65C26BA001DEFB78837997E9375DC8246ED695370028452AAD4FE46748681D5DC93D936A4DA00059748AA1F5CB117F7A0CAE0FF9FE0200006BA4D2FA6C44681DBD2E59B848780D544C6E4EE723AA8AC6209001503D6931703622B476045F4059DEFB13A9341AF3FD8DAD42F6F8FE0200004BA4F0268E7FDE8CBCEC6215D71DC26BA052125C5F8F9CA08DB590ADF06CA5055015A9D63C1F59A9E024F8DAA7550830BF04DFDFE805BBCC000080257220F5F9845CE826847058FA57FE5FE90B00905EA1E0DAC96147D7728304802A48B5F5EDC4E0EB94E01A985FA2EFEF47826B00006045ACB6F6DEC7D0FAF3845CE841CEF6298ECA6BA0320583EB65457B2201C054B2C5EE2CC141B78B10C21E6F08309F84DF5FDA85000000332413BA94E2C2298AB70BE950790D5444266A970A82EBE84C6E9A00608EB419B84E107C39E93107602689BFBF6704D70000C002D971769D20B87E90220015A8BCAE80F7FE7BFF19B633C27B7F39F2F4FC5CA85602604EE21D2C545D0333CAB003ED4FC6310000403BEFFDD984431997C59669275A7EE53F145C03B6245524B197700CABF7975752BCF7DD7FBC73CEDD4B05EE353D36DB2027E86B0AAE9D4C1C2FE5330B00EA49B5C259C2E0EB92771D984786EFEF05C1350000D04EFA5BA7D871D6515375EDA8BCD64FDA40C4C03A0693CF475EF04D3C5D94FEC3F592858D5B25ED4256F92784408003403509BE3E25BEC6BF584406F2CBF4FD65FC020000D4EAB58E9D7230F5B2BB1082AA16B084D74AC907F0447E5205928BD8779310BB3E1956D95263DB3C00D532055FEA067E408D327D7F1F4208CFF8C00000008D2437BC9E50E8BACEDB1082AACA6B0E6C54C87B7F2455B4EF1257D2C636239FBCF7D71CA4570FA9BAD61C5C47BB32B104007532055F4E06930032CAF8FDA5E21A0000A89431B8761AE730D586D7319C8D3D80E3017612D686153FB7F2BF9F480058FA9A9FC9817B9F139C0CBA49DC4E704D98588D5323BF889A66FF00D0C9187C39C22F202FBEBF0000A0359983EBB86BFE56DB4B5A55DB1079038F25241B13FE2EA429F9F9DC87B34825F479A60FDF26AA4E10C570DEFB6F8A7B5D2FA3F72B003532075F2E84E0B7F8BF011821F7F7D739F72787350200004D3207D74E0EAB5657E85A45E575AC9A969EBFFF39E73E4CA85ADE957FFEDE7B7F2A1F8AEC24B8CEF9E1DBE48DBC7630485ACC5809AE9D1C3E0A00C5CD107CDDF02E0379CCF0FDBD23B80600000A9D65CE0ED5555DBB1AC2EB1832CB8B9BB2E7EF8EF49BBE9770309B5E705D32807C155BA714FCF331DEA1B1D7CEDAF502A8903C7B73065F4EEBC00FB04EBEBFB90F11E2FB0B00005491C2D3DCE79D115EA7243DAD731C6AD817FFBD9FE307244715B6FC3B2F9554CE7EF0DE132CDA63ED3DE3A0500045F5168D73A3451290586FAB6CEEB13387AD02000035A4E03477701DDB1EAA1C03990CAF65ABE0D719DB6CBC92030E5307D897990F661CEA72AE562948A644AB9929347DDE0134469E71E7332D1A53B90924346370ED587C0200005A48A1E987192E67A1F54D37175ECFD0E36E9DE729036C593539C872A5E3EDCCB00D1389C45EEF165F4BA97A048012E63C1899F01A482B778FC79FB4561D010080B648EE7339D32FAD76F1DE54785D30B8EE2409B0E59F3F4D7A65E9BCA27D881926C36BE71CD5FD0066278BC62F67FA73171CF606A4237380EC5B65C51D6F1D00005062CE56C36A17EFCD84D70A82EBCE73A9DC9AE244499FEB75B406EB00000C263B3EE6D86AD7A1EA1A4864A6031AFB68190200008AF3DECFB6EB4CA89DC39808AF0B0C5A9FF2522AB80693AAEB51FFEC8C0EA8BE0600D4A07738F29C08AF8174E6EA53DFE1FB0B00008A924CEECDCCD7A076E7A895CAEBB907ADDB381DD973F84879D575E758C7656003B6A403C0D34E0B1C164BF80524E0BD3F2D703835DF5F0000504CEF90F959693EF3437D782DED42E61EB46E63ECE186DAABAE3BAF521D4E893C42085627576CC705300BD9B93577C582637111984E8A44DE157829F9FE020080924A14DF3C687EC77D0841C165AC26E1E9BDF24AE517DBAE4EC8EFF35FFE4B4AE6750861F6D51E6CCF7BFFCD4825FF4F2104AFE4520054CE7B7F5B62019CFB1C309DF73E8EAF0FE67E29F9FE02008052A45DC897027FFC4D08416DFB60ED95D7165A6C0C39DCF028E375E460ED7A5B64ADFAFA46C135006880E29D5B009EE0BD3F2A115C03000014A6E9BC3F35B487D74382E1520E06F4BEDE37F0FBF459BBDE16A9ED49B4067D240164273B9D4A0DFCEE788781C94A7D7F17BC750000A084C2C537AAB31AB5E1B5F4A99CBBC7CB58DBF6B1B61606EFD2F75A3D6BE1356D6800CCE1A4E0CE2DFAE5021378EF4F0ACE013897030000CC4EB2B79205BCAAE7309A2BAF8F155CC3B6B66DAF613108A6FA5A31E9B7AEBAB17ECFC2F02193008C90819F95C39101F42898B8010000945072F15E3DCDE1B5DA46E12BEC4AA5F853E8BD891CAC5433D3BB09C01C8EAD1D640BE0A792BB260000006647F1CDD33487D7D6825E4B613BEA6221147EA065088099941EF8D1360418CFD2CE4B00008014342CDED3F37A28EFBDC52098F61A28228410FB335E287FF54F4308043A00B2F2DE1F29D86E477B24600439A488EDB20000A0351A16EFE979DD88BD2D7ECDBBD65F246473A2B8F7F55D0881962100E6A061E0B7CD7800C0636C970500004D61F17E3B5AC36B8B95D7DB1CC668B1F2946A5903A4AA59EB565BB60003C8CE7B1F43E3970A5E69C26B6020393B86B3610000406B58BCDF0295D7E96C33E036B7953884C0F667234208970ADB87BCE53304602647BCD080594CDC00004053942DDEAB2EC021BC9E97B5108F3627C684108E1505D817B40B01302376790076B1F80400005AA369FE42783D82C54ACD6DFA0D5FCF701D2959BB5EFC10AB97AE0ABF167712A4034076CAAA16B669230640C841ABA54FD8EFD0F6070000CC85CC644B5AC36B8B7D969F0CDC4308F7C6AA99CF155C03068AFDAF430847052BB0EF8CF6AD076097A6811F7D7B816134555D7360120000C84ED9E2BD7A545EA7B36DE06E25105ED0ABD836A97C7E3BF32F1103F34339401200E642CB01C02E55DF5FEF3DBB270000406EDA0AFE681B3294045F0B8DD7B6C1B641EFF9962D464AA3577105A4E7F4DF337D9FDEC7C09CE01AC09CBCF77BDAAA25BDF7EC3E01B6202D7FB4551DED2BB806000050376DC53784D72355D91F5A823DEDC1F0032D43EA112BE84308F146F43ED3C2C94D0CC84308A7ADBEC6008AD258754DDF5C603B1ABFBF84D70000201B59BCD7D6AA8CF07AA44BC5D7F648086148D87EA6BCFAFA94EAD9FA48B81C6F921F137DFE6268FD228470488B19000569AC7226FC02B6C3F7170000B446E3F847F5B91F3E84A0E03256F3DE7F33D2C0FC4A0EC8DB9AF73E0689EFCA5EF64A77210406ED95937E8E47F27338E07B76230B4B977200290014E5BDD73890E1590A6C81EF2F0000688DF73E662A2F15FEDA7F6B2D4CD41E5EC70AE5370A2EE529FF841006578A7BEFE387E2F9EC57BB99DA0F2BF2916D2BCFD6AC00C65D05DFF85C00D0467A4B7FD1F8C68410BC82CB00D492B1C757A5D7F727BB100100400EDEFB7BA595CEA3B2CD39FCA1F1A27A2C84D78B096FEEB104835AAACB5F1350B6A9F7BE5BEB350FA06D6AAB2363B03EB0A518D01ACD079BEE3326020000A9C92E78AD2D3AF6B5B670D6DCF3DA495B820B0597B2C9E843EA24303C99E52A9FF63184C0218D00004BB4875F00D6D37C3010DF5F00009083E63186DAB995EAF05A9C283EDC703135F0957FFE75BA4B1AE52284A025440700605B9A077F845FC0667C7F0100406B28BE19417D782DFDE646573767769CE8772C1960C75621497E0F000066A6F9546CC22F6033C26B0000D01ACD3BCF76BCF72AAFCF42E5750C7763EFEB1B0597D2F731652F4B09B0FF99B1CA7CE19C7B41AB100080457258A366CFA5A71D80D5B49CF9B28AB603D50100401D3487D74E6B65B889F05A1C49E0AAC14D8E361B72F0E3FE0C41FDC7F8E770901400C0300BC130D59BC00A06169F4C5C2300003047FBFC40E5F59909AFA57DC89182FED777721D59C4432A430887D2462475581F0FBFFC2B06EFF27A02006095856098F00BB08BC5270000909AE69D674EEBFCE50F05D7B0B510C2AD54415C177AC363707D3847F02BED3CCEBDF7C71296BF1CF9AF8A617FACE83E8DC178E2CB34C97BBFDFABD8EB7F319FC944E59C762A00800408AF81D5B46F9975F2FD3D53701D0000A002465A0AAA6C9D662ABC76BF02EC7D0964E77C512F4A1C6CD80BB1F76410DDFD6C3AA42AB61DB98D21BFB422698EBC5EFBF2B3273FFB5B2C7A2CE4B30500D0CD42304CE526B09A85F09AEF2F000048C9C4D822160D6B6B336C2EBC76D25A432AB04F9D736F32FF71B172F9B874082C55D3E7F2F39D04B4FDC1FF6DABED40E4F3D0FD6C1352AF434B15056445B25B7C78D6FBEB2ADF64B1E69B7C07E8E50E408B7862773C63E29677043067378EB5D9B988317A63D9674F841571DCFA8DE704004091AEE3851A26C36BF7AB07F689F7FE5202DD4D95C8637D94761B2AC34C194C3739A0EE55A24F69A9B2ECAAD54A750DBCF747BD0588A1BB2A7E7E06BCF74E5AFC5CB7BCFB00801A87B2C006C09EC37EE108B08EEC0C3EEE155F6C5B48F3CEFDF8E71F64EC1AC7AD9714D300000A52B7C3D58710145CC674D21BFA24412B910719A49E5169A14F821EE0EBC4F77D9FF77C5E1258773FB9FAD83FF4260204D94025BCF7DF0C1C78E2646134DB41CF8045DEFB18D21D18B8F4226D03619304D85D21C694B94A371F555B440500184E3A067CB1F0D28510BC82CBF8A99AF0BAD35BF53E1A588D7DC54AB74E5265DD2D4EE40A2ADE87104EADBF5616C836CAEEFDCCB1636293456F718AEF396098F7DECA00661142B0D0DF17988DA1F09AEF2F4649347F7990009B834301A002DEFBD36EC78D012F34B564AD2EBCEEEBF584EE4ADE9FC97FEFB6EF7E6FBB418F5C9D24E49CABAFF91E61665EF27E9E645E84D8567CCFCF08B101BB0C85D7D15FECEC017E31145E3BBEBF9822D1F8371EC67FC49815006C33165EAB2AF0AC3ABC865DDEFB1309AEE70839A9BACE4C6ED21A42EB650F1260F3FE03C6180BAFDF523907FC622CBC7E1D42A0EF352691A2AAF3099FFB789ECB21013600D8652CBCBE0B216C3A707856FFD372218093B62FDEFB5819FF61A6A0B3ABC04506B1A793F7FE5E6ED01A7BD3C66B7A17AF51FA4F01400EDC5F00BBF8FE62B258BD1F42889FA58B91FFAE78AED3B55472030090DB734DCF1CC26BA82187315E2738747308DA4664106F72DEFB4B398C60EEBED663C46BFC12AF994901800C08BF00BB387015C9C801A06F47FEFB9ECB194D00009BAC654F6AE63084D750C17B1FB7D17D9AB93A97AAEB0CA482F97EE229EBA5C46BBEA50A1B40623B72A034007BF8FE2229692335B602FB40DA2B0200ECB93576C56A16F009AF519454E8C66AEB5705AEE39CAAEBB4BCF767526DADB145C8B6BA2A6CFA6003BADD197B7F5814037EB1760022D5D7484A2AB06F46FE3B4FA5873600003951790D487B869207F650759D882C42C455C43755FC423FC45ED8F41604F4B2B6F848F805FC42780D38772C3B4187DA9183ED0100C86957CB6229E1358AE805D773F6B7EEBB8A07A7F0EE4F275B69EF0BBE97391D481B11B60B0398EA80C530C02C558716A10E3217195B4CF38AEA6B00C00C542CE0135EA394B3C261E739EFFC74BD43362DB70979CAAE9CEE4E800DE862B1ED13AD4300BBA8BE460E6723ABAF237A5F03802DD67A5E3BC26B344B7A0997E871DD59841038A97B22392C66EE43364BD99100FBB881DF15B082C11F6097C5EF2F8B4F484ECEDF195B54C3B814000C317AE69A8ADDA384D79895F73E4EDCDF157ED509AE27F2DEC741F607D3BFC47031C0FE44800D6002C22FE0078B9337169F90CBD8D6213B32B7020020A7E2CF1AC26BCC46566B34B4EBE0A0C60924B82E59395F1A0136A0C3B5C1F761971644C07716C36B82426421BDAFEF46FEBB591405005B6E0CBE5FC59F3584D798D3B9821613771CD4381EC1F54F9F98C002C5590CBF1CD59BC0F7B0CE62DB10C7F717198D5D9025BC0600E446E535DAE0BD8F03AB970A7E590E6A1C89E0FA91732A28817208BF00144050885CC686D7CF35F42205006CCDE2EED1E2BBCF08AF31172DA131FDAEF8AD95E400002000494441544720B85EA93BC491001B2867EC36EB9262D0B0C7670630B96D96D63FC865CA822C9F4900B083DDA323FC51F20F471BA43FF0AE825F96962123105C6FB42315D887464F0E06AC8BF7F4E7067F8723CE5F00CC4EDEE2B8F644C175A022718EE2BD1FFB0B1D1AADE403500129CAE80A33FA3B94E2C2DAF2CE908381BFF1436F71EF5B08A1861D8CEC1E1D81F01A733855F22A33A81BC87B7F4670FDA4E752D1CF5662607EB74A5A520D754C780D98FDFE1E115E23939B11C18EEB85460090452FA03E94BF763FB98B1477E4BEF850D17CDB6A41656C1DB25FAA7523E135B2525475EDE8773D8CBC776F2C5D734107DEFBD3108296851AA015562B17BEB70E6137101A67F5FBBB5B72F206AC40780D201909AA0FA5727A7FE4A25A6A47B53C7727EEB429ADD8EE337A5E23372D61DE03938CEDC9019B9FAC5CAF12EF4A1F620034C8F27D9DFB055A6779F1E658C135A03E63BF13F4BC06305A0CAB63E19AF7FED27B1F5B7AFD2B59C01B25C1F5EB10426DBBE82D9EFBE14ACE5F08AF918D04A05AAAAE39A8714BB2D2CAEB35CE3927BE03F391CAE507A32F39E1179A66BCA880C527E43036BCDEE1DD003044DC41145B847AEF6F7B61F54B85F7938F21841A77D05BDE7D56640C44788D9C344DCCE977BD05095E2F19048FB643F00FCCCE74EB1005D7019464B5F2E87BEB1005D7017C47F10480A7F402EBB850F6552AAB351F7C7E1742A8F58C0916F007A2E775014BA7B1F6AD3A8D759D6719B788DD263A015E53550A81E2764E953FC02C88FDAF4F42081CC606CCE35AC996C6318E38B8118DBB37FCFD3D61070514D9A75807C032C99E8EE547CBAEF86D3C54BECB89F07A20C2EB4464B5BB0B93BB5350FB21F5BEA16A56AB938875E28A5D8A30BE6AB2FD83031AD3388D3DC3388C0D9885E5C1DF31E1351A17C3B657465F025A8700005492B9FDB1B402B1E8B4E6B9746C9D66F8D0C69DF8F90A21CC5A204A783D40AF62BAAB903E94BF52A9AA1B55084F90C5971A7B4995B223AFE7A1CECB03AA62F91EFFBD75080B5D6898E5C5A7229337548DD61F00469339FD91ECA6B65465BDECA6915DCC37C6778F125E97D6ABA2EE7EF62AAC466E09E1F5D3CEE9739D5C6C1F725CE90113801A71678DF77E6178904EEB1034CB78E5912B317943D5E8A30E6030C9AF4EE4A78639FDA9826B9883E5D687AFA455EA6C1D0E38B0F1C797FD30BEF0719BBF34AFFFCF39F7C539F741B632125CDB66B9AA273BD95264753B9176671CA003CCC2F22265AD07D100DBB27A686374C4731E0050427CFE78EF4FE5FC88779504D78B10422BC587D67FCF59DBA735195E4B581D7BD25E7BEF432FA87E697C7B051E5BB01D7B3DDA8564B7D3D0CA315092E5C1DF6E3CFD5DC17500A558FEFEEED0FB1A09B11002602B7187AF14E9D5125A779AC9262A08E9673DB4BA89F03A4E0AA5B2BA1F56BFA3A2BA09B40CD9EC8C7621D9BD917EF900F261F007D845E511F003E72801D8480A316368FDA9D2C2CBD6F21BCBBBCF0EE6CC39AA0DAFE54B7D266D40BE4A653561757B6819B28654FA593DE1DF1AAADB818C6487CDC2F06B4C788D66555079F492456A4C45FB19009B488B903329C464A1AB1E14E06CA9AAF05A2AACCFBDF7DFE44BFD863620CD23BC5E8F03C2E61357250F5BF96581424CB71E90F307805659AE3C72545F2301DA47015849C688F7926FD5AEB5C560EB873E135E6F2B563A48FFEAAEC2FA156D10D069A8D9FF2012A4B213615EF4BE06F262F007D865FDFBCBC1AB988AF01AC06FA4DA3AEEE0FDDC50C6D554C1570821165B3E28B894B176E72AD2331B5EC7D527EF7D1CE8FE2BFDABA9B0C6B23B5E91B5686331BF032A2B81AC6A683DC0B671B4CAFAF79783573115AD6700FC24CF94DB06DB7C1E35381EA600670BA6C26B59793A912AEBB8FAF452C165412F5A86AC202713B3D85306AD5A804C4208B165D895F1D797052E34492A8F2CF7AD77545F6322163F007C27F3F5AF8DCED9771A7C9E5A5FC07F35C7828389F05A42EB53E9F3F381E00D5B22BC5E4D43FB8ABB462BE377A9BE06B2B25EB9C0FD012DB33E796BB15A0CE94C6DE7F78DF702B04FDA847C6AFCAD7CD7D86E26EBF3173747F5B5EAF07A29B47E472F6B0C4478BD4482D3528B3F31AC7E1D42F021847DF9F1CEB97F9C731785AEA9042AB3807C681D02D8657DF2B6C30214C64811D2C8EE05004649F675DD609B9075CE5B191357B27BB4DDF05AB64A105A630A06718F950A4E2F24AC7ED46B3B8470194288DFF7BF9C7337652E6F5607731D6A00B42684705FC1AE0EC22F34298E078C1F5AE438781523312E041A2621ED75821D183579DE58CB4DEB0BF8CF73671CEAC2EBF80B7BEF6F65AB04A135C67A90152C08A9EA28F140BC91707AA3183A8510E20DEF6D03EF9986D62D40ADAC1F484B788D96599FBCC5056A0EDEC3505327FCD6177D8066F50E667CCEA7E09157D246A505D6778FBADC0BF871FB7ECE7FFFD664B529063A6F545C10ACBB912014426EFC25B621FD25D5905B9387F875E50B58835F17B4ABF78CDCE7DEB6990447FF6ABEC627C4C5575A87CC449E37CFE46779EBFE9EFCDCCB4FDFADF498BDE75E9E8EB437FB6CFCD7F81842A04518B6E6BDFF3671CCCBBC0730A891396F0A17DB14C3592745BCD61731FECC5544AA22BC96F2F2730E6244424C1C7A24F8FAAFC01F3DFA412301D465C5ABD04D3C8431DD8A67E43FB2BD1E6B78EFE3EBF3D2F0EBF32284504305861AF24CD9979F4309A5538E3BEF24E0BEED7E08B5C74910E495C60214B626E1D5D789AFD85508815D3B802104D783553F7796D6C9D60FEB7C1B42C8D2EEA578DB103990F10BC1351263C2F8BB5237FAD1DB7C64D27F5841FFDA758E38980D9BC8C12D672B9E912DF57F1BCB7AB84F0831519C147AEF4FE2428684A1FF4A45EF3B69A1957ADCF95C164CDEC99FF3AFF7FE3EEE7A8A93115A490C62FEE046998002DB485131CD393F80213207BC24B81EE4958CE96A9E3FD7509C94AD80B45878DD3B4DF55DA96B40D518C4FDAEC8246A6AE5A06C39A935C0DE21A0C23A526D7DBBA695D66E0CE578F136B27EF01BDBBF47882D27242CBE974AC60F1228979A1CEE4ABBAE4F1266DF4AA04E90BD590D0B7484D7D8568AFB3D453B8011BDC31929DE1C2E8EE9AE6B0DB025FBB852702953EC4A0BB8E48AB40D912D12977C619111FD8445C1FEAFC9FAEFC9EF705BE1EAF45D0861B9C72A1A36E0FC8718CCEE7130ED7A05FBFCA792AD675C4D6480DCFD587A46DCC4DD492184560E221A441620ACCF13188BE24989DAE4FC1D42A0700730400A380F78AF2659C4715F8DF7BD4A5A87646965357BE575AFB70FC135B261B2F09B52159AC9DE835E0B91DA4E537F2EF744E0A96AEB653B1272633DEBA120D5D76B484B9073097D3ECB2285B5C5CD3871FD24AD454E6923F5480DA13E3B64B0913CF727DFBB08AE011BA4B082E07ABA5DA9C0AE6E17B3143558CF3C5EE6D865386B782DAB085FE9ED83CC6AED913C56A99B7AD205041998D7B80D97ADC58DDBD0DBFA296F683FB09EB42D5A68BDBE2D105EF7C8F7E4584E62FF6A34B05E65575AE81162FFAE86F09AE73B9E92628CCEBC073040B230CB3B02B58963C0CF95B652A4F7F50AB385D79594BFC306B6590B09B6AAD9E510428837F28F0A2E252526B70D1B586DBD0A87376E6639006357863CC7E470EF7B19473E57705939ECF442ECE69F0BB2E3CA7ADF470E6EC45338AC116880ECB465CC9EC707A968AF09677FAC304B784D708D99D132E4971A0F043C355E4DB96CA7C62D4FD86C42B5F5B29712806335CB83D9A6B7954A687D2E6736BC6B68D7DE8EB413B9A6AD14AD43502F293049B11837E970740079C98EAA73BA0F64F54A0EC5AE62F79AEC38B79E77245FC0CF1E5ECBA49AE01A7322BCFEA5C63E50DF2AAC5626BC6E48826AEB655472AC61BD7AB3C5F07229B46E797B6D5CBCF82A55E74D92DD56D6276F9C6D8175522D3C53790DE8765AF1AE314DE26B7C5BD13397EAEB2559C36BF9E0D4D0AF05B6D036E49792957BD9AA41A597ADF5EDC47D84D70D48586DBDEC395BD337B23C0E6926F422B45EEB9D5413B5DADF9EEA6BD42AC5D8EF81C31A01BDA4602555B10A9ED61DE458C3BCA886F1CF41CAF16BB6F05A4AF62FD91E810218C4FD7A5896947BDB4E4D93415A87542E43B5F5B2330E7A5BCDF8A9DDD587D784D65BE9AA895A7C4ED43079E3F98EDFC8F3FA6582578596218052BD76219857D77ECD74E5B2EC36BF50702953255B48C859797D59D341718041A5C3EBACDBA3A41DC0FB9C7FC6CC98DC562863B5F5B21DAAFB36B23A79A836BC96EFC6A92CEA105A3FADE653F5D79267BDF5C91B07376259AA313AE135A0D7097958516FE4FC10CBC53D352C7EE80EAF6532D2F44143288AB6213F140F3D66A8FE3E335C51B98C43F72A3343B5F5B2770DB716788AD5C15F95632909F26E1B3B8831951A4FD57F0AD5D7A84DAACF03E135A0908CC7DFF1DE147760B90FB6B44ABD53702953ECA67AFD9387D73259E78B8A62E8FDF693869B74D64056B6D3D472585DB21B3BCA928AD2CB19AAAD57E1F0C615E4B96072F057D38284B408B99683BCA9461AEF554B01762593B797B476420FFDAE81BAD12E448FAE0FB6D545640E6E1449C36BFAFA003AC87751433030C74382EA6BA82103A3FB44BD2CC778A9A0DFBD5656077FE6C3EB5E8B907FD999974C530176259337AAAFD18D1352EC38A1EA1A5048BEE38C7574E95AAF596CE1755941D69164FC93BAF29ABE3E800E5A2A789FE7AE1AACACFA9AD0D1A85EB5F567056D104ECDBE9079591DFC99BE2FF4DAE7B02B2FBD66026CE307AF763897002EE122C625AF26A012BB20F5FA642DC096ACC3FA582FC90EF364E1357D7DA0C48237E23B4D957A73541AD532792F55AD8B0914545B2F3B30BC352E1B19FC599CEC9B6C3530E361A5AD6BA902DB7A20907D411F26D0EF1AA8941CAACC984737730176250B22938B7152565ED32E041ADCF32E7CA7697294BDD2288410DFF78BDC7FCE1C68F96087B26AEB65547DAC66F17531D70BBFC061A5AD7B65742BEC5035B4096361B161726F4C315E58C8D8178012D2B693DD8F367CB234E796FBFD8D824B9962F2F82749782D6F3C7D7D003D3485D7BB333D1C6A09EB38B4D10085D5D6CB761B09B30691C3ADAC0DFECC545E536D5DD4A7DA0FFD35BC7BA28F05EAB651750DD4EB4461310BD6BB34366EB29E751C4C3DB83A55E5352B4C802EDAB6A566DF996134945A8589AD62CAABAD979D4E1D2454CADA4EB1E70AAEE1493201B8A6DABAA8CB06BEF3D6E71C2FB92F372DD5A232FDAE0145A42514E71AD812E771E7569EC92184CB0A5AE44ECA392687D7545D03D842AC029D63C25943FB222AAF9532506DBD6C9781F46372F01BE7232424F7F7AF5682F68AEDD65E5052499B305A873448C610A916BDA9BC067439A5EADAA4E7C6C64DD6ABAF2785D73E8430E94F970A340E19CBEBCE39F76DE29FB0D7C816DE9B1042F395ABDEFB6F4A1FA02F42085907DC8A7FF721FE94EDD1504056E4CF8D3EEB627FD83D3E4FBF93B0D5D221D3D9EF9D63C877E392220675FE96DD4855922AFFAF867FB78B10026D9D1A2307ABBE4AF05BDF85102874009490AAEB7F793F4CFB472A9B559371F77F865FE849CFAF49E1355FD4C96E2494EE2618DDC4F43EF7211CF2DE75AD259EF5AA3DBBBFFFCC680515E1F58FF777DAAA543E31483BCC39A9967EABD6B7ADAB0CAA5A249552E7C61744DE871068EFD56370F0A7EE9E50C977A356D58F85BCF7D786174D1E4208B40E694CC2E20A9EE980220917A6504EDC91B96FA1D8A782CFDBE822BDA9E1750D21D11CEE24A0FEF963A90AAE77D85EFFAF5AC36DC26BDDE1B5CB1D6057B2A8C6C4A430E3D5D6CBA8BE5EC1D8E0EFB5B43B5181F19F09552F82CAD8F48B824B19ABEAEA78FC4E16FB3E277A59F8EC004A50CC59958F2104F5ED162BD87D36BACAFD8F897F305BDE56BB932AEAEF3FD60383DEE4E7D124A857C1BD2F81B6A56DD82823569D5CC789678EC177DCB5E0BDBF33DE7B55DB819B4DA9B0A274477A5FB320F2BB3343E1B58A7B823CF32FE96D6DC269CD0700C7B1A9F7FEC670F5F5616FE725EA97AACFF903C135A00A63EB7ABC89C519B93B204C159F01C6C73FFB630F1D1E7D6063E24327AC8B556D57B1324ACAE0E3968393B8A2507BA55BFC72C7094408E14C2A4539040BDBE802EC5C0B60D60F3320BC2E20565BCB390E9F2B7CBE9D58394D7B2E1200DCB4F1DB4E27E3BE5B826B330E64B1A166964383E6770936265578ADBE272BD00A79C6D22EA42E56C6156A76638E307AFC333ABCE6A4ECEFAE642BEFB310C251DCD2CBB66CA77AA50AAAC470F0530C0B33846AD607F71CC4333309E6EE2B3E80B8ABBEC6EFAC2C74155D7890032E6B5CD4A95DD5DF79D9196875018AF0BA1152A891EADE49780DE841D5757D5E5958F89756820F0A2E658CD13907E1F570B1B2F8BD54581F69EA41A9045BD930540C0BEF535661CB22D295E1778280682695575B2FA3FA7A89F45CB3B063A8C882967C3FAE690966560BEDFDAC86073BD2B712F54B3967E6306F4001AAAEAB66655C6175A7F9CED8058251E1B51C92D25AB8722755D6F1D0AB532AACD7A2F25A076B2B715D1576CA10DBF4C252EFA0546424F7F25602841D764DAD44E5CC0A12ACDD1AEEA987060252AAAFA1992C18A7DAD175C5FC135083B163BD4C545F1BCF3AE60BAF1B9BFCDEC989EDFB54596FA574E53555853F58AD80DFED87D853AA44A5A2D2EA761ACCABA5012883EDC7B8572C9145C46BB927C3B616C6EC56C7E7545ED72FE5F78F96218002323FA5EABA6EEA77AEC9C192170A2E658C518BF763C3EB162A05165269BD2F551DD84EE9D09483A4EAF03DC476CEFD273DB18F47AE805A1EE87368E34C6461B295C36677331E946A9254B2593FE43519E96FFD89F645D5A87ECC6EF81E4E785DBF94CF5BC26B4007CE90A99F95B992D5C5FB792AAF65A5A9F68030F6B4A6D27A040901A8602BAFA6F62D2F2548F9572AB2CF0684D984D7D8564B15C984D78F35FFBCEFF57FA7BF755D5A69FB62F11E4EC145C5649C9AEAFB47CB104001C9C208AFEBB76BA1ED9A14D9DE29B894A1666B1B527395407CE3FFA6A7F5641CDA585EADBDC76345F69BA5303B56669FACEA114DEB106CABB1EAEB030E0AFB9D81AD7759DF2F998C5D27ECCD0A458CF46E9CC4EAC9FB9C6F51355A8600F53961675A33AC14FB58DC3D3A5B785DEB20EBA3B40821789DAEE86BD8C2246D0BAD1C9CB92B61CB07E7DC17EF7DF0DE5FF7AAB3F70D0FF8F91CCFAFA5EA6BAA461ED35C7D9D6DA224F7C97BAA40ABD6CAF3C4E2048E85C47AA57CCE125E033A58DEBD784351D72026CE0C31BA783FEA4C1D2AAF7FBCD1FF841098C8A7533A3825F46B27BC5EE5A0579DFDD5F0811A7C8E67260F7F8B5BAFC668E9E0E5AD18DE7A375AEF6046AA88EAD64A40DA4CF511749345C15407DED232045040C64C960FB23E0921C49D767FC5B3DD62F1666BE3DE81760D15459A1BFF8C796D5B0FAFE397F5505A0B201DAAD7CBE33D00C66965217387831B576AE6E04679FF3998B10DCF5AF82D25E0B376F23E95D775A2EA1AA88FF51D9ADF3B28C45679B16027166FC6CE03CEB93F25CCBEA032FB112B5D272C9EDD334B786D79B5A9AF0BAE09F91293EAB5929AEF1F2813B856FAF702C9C8FDEBA6915794EAEB25ADF43EF7DE9F4B700DD4C6DA021495D775A2DF355011399FC07A0EB672B134E60612661F4B65F60BA9CA26C836922B1938BB278941E17545073C5D4970CD16AC7CD882521E0B33C038AD545F7338DF6A16AB17B626C1B5D5764AC0465294626901B296A22008EFFD51C21D2DB40C0174A8E15C9CAD82D858C82355D931C8FE47B2B35659CA3FADCD5F06BFB6432BAF6BD876781142386220905DC99ECB6CC1FCA174053C6092841FD5AF5EBB5F9524F85D95E1B5F7FE99F7FE96E01A0D30557D5D5171107E48D9928BAA6BA030E9CD7B50C1FB30B887736CAF1BB333E993FDBEC16A6C3387991BDC3D3C385B1E1A5E5B9FE4C6E09A1E9FF32859F5DB446FC72D105E03E3D55061B10DC2EB25B2F5AEAA2A93185CCB33C1CC201C184BCEB2B1D4FE87716B25E45E9B725713E135505E4D738251E37EE9937D2AADAE9A0AB18D15FA54BD7B744CCF6BABEE08AE67553238AD61657432A91EA5571530422BBDC308AFD7D236F81B1DC4495527C1F58FD7F066C50FE743D4C952F53595D7F54839D7A4650850982C48D5B4636DD2B85FFA63B716629B5960AEFDEC9EA1E1B5D54345EE98A0CFAE68BFE5A15B622A46F53530DE6903833242931514566E8E6AC5D570707D2393AAD8ABF1AF10820F21EC85100E57FCC4BFEF9D737F73DA7E55CE0DBD8F545ED7839621405D6A3B07274926D60BB1F71BE8896D6DAE546DF5750BE1751CB8D2E37A66F27A979CF8135EFF40780D8C24D5D7A67AA78EB023552578CC7470D00BAE531D1CA6D9424EC6FF4782EA184A9F4AAFC6AD82FFB85B69E9B4FDD7C67A07A247C6A1556F9F852E72CF4DB95048780D9457DBCEFDDD94E72C483B91232916A875E1DFDA3CA9DAB96B0B6D438EB69DB85811AB8A63EF9DDECF91F7FE547E8E96FEB7925FB692D5D754DAFFC0C01798E68CEAEB66991DFC35125C3F4895F4DF523D7D2215F34948907D2821B6F57B4055E3E001AC7C8719B3D68196214045BCF7F13BBD5BE17B7A94FA5F28E3AFBD4AABB04DCD93E4D961A1F5E5E0D7F58F3CD7A1C6473975D324697DB12F3F877243187C03F53EEE86FDDE3AE55E02E5F89ADCCE3028BA4E7C68C910545ECB6AA8F7FE863EE026156DBD831FE27DD27B1F03907715BF24DC2F5790FBE79DB5961B32D93AAB38B85E484B9FCB39C29D18627BEF6F8D2F0634195ECB77F8AAE058146DA165085097DA5A86748E721C422963B25848195FB70FA9FFFD18E4CC40AFF6C145B635575EC7031A4DDD70A4A2FAC47B7FE9BD8F5FFE7F9D739F25343998B8F2F75C06EFF1DFF5C539F75F9C8CC55026E309AA25C3372A097F61DBAC4D54DCE87156F9A16E84D7EB69B97F6EF53C95E0FA53A5C1755C887D2155D6E7735625CA01C8C92B95308BDA5B3F4101B9F7A6BAEF3E105E0365656803A4C9F39CE7838510E273F745453B57CDB5579471EB9D824BD96470565873786D22B88E37460990EF25ACFE2021F31C13CF78437E13C3EC18967BEFCF5306D985ABDE5B3B9C6A934B0E9F02C693902C7985024CD012203C19D4F682EBDA74A1F561C97185FCD9567B60B7DA36A47BDFB44FE0605FCAC5AD59769500D8A8D6AAEB4ED6057979F61E56924158CD95B417300E7ECED51A5E5F686F17122799B20DF5AB04C8A5FB29EDC8D6821864DF4B05788A55A66213868C15E5A6C80098CA237B9A0D1B348A959E15575F5379BD869C99A13EF8AA34B856115A2F31590D59DBD92F23681F037168AE6152C198B2350D55D740419281686FB93055F68328A5FAB79600DBA2EA76DF0F0DAF2D0C7E1F3457C849687D2F934CADAB38BB52017E2FD5D853828D92134EC2EB5F5A3874AE36AD870D1AD55A7D4D78BD9986E074ED3554185CC745A27F9485D61D8B671134FFEC97C547CDAF03BB056D4B19023DA43C7816C028B5575D3B691D92BDCD2A017639860E6EDC5A8DE1F599C60A9358052C95D69F0C9D5ADB5563FF3B21C42E39F1A4EFB5A0FADA24B68C2A5379F535D6531B2454165CC789CD7BE9694D78930E87FFFEC0670AB97050235097EC55C94ACCF27B12601755D533A5C6B621EACAE3634F6B3924D17265450CB1E3018FA703DB89949C345179FDBBDA0F9DAB8A3CE8A10FBDAF1B23D5BFA507DC8F16E52B0BAEAFE282730841FBF7CBE22E0576F1FCC0023E92F3DE1F252E4A22BC060ACAF09DD66CB6905EE6B5AD2C0AA821C520D52C1A0C0DAF55F791965ED76A06E931E4956AEB370A2E27855889FD4E42ECAD8261793F4A05A63B736C87B142AAAF5BD806550356A695A2FABA5945C73FCB639B8A82EB0769117264A42FB3C54571C2EB5F1367EEDD488D9621405D5A9A2BEF48583F0BB9BFBD2FFB2B3749EB7365F0DCAAB6CA6B3555D7129ADE56DAC76E570E76DCB68AA5E4A47FB61BB205F2D0A8AAF751A5A8BAD68DEAEBF6947C8EFD16B855145CC76A6B6B2D422C8E29B4179ECC896010C96438A8B1BAC3B5004BE43B7DD0D89B366B35B4ECB0BB99F3CF443D3BCF0685D70A0FCEE95B68B93E09AEAF1BD872F22656966FD10B9BF05A97B8A27CD7FA8BA01CE1B56E556DC1C2564A7E277F56CE4A858CF5E0BA5F6D6DA6B7BFBCF63B0A2E65289E27BF680D071993D9947A8E41780D94D5E20EE59723CF359BE29879D47C14EF3C1B3C07185379AD7580A5A29A42FA415F1A9DE08CF15CDA886C6ACF5132BC7E3EB04777F5242C38E2A1A11ADBBC15E300D4F6145E1CFF1E3ECA73D67AB87127BDAD2D56C05A9CD43E585A20C84D26701AC73EBC4736A5BC272C38EB042847F282567B32CF3ABE9136719676B1D6B0C0AC6EDC3DE6993726BCD6FA60D552157ED95093FF4E0CEAAFD705D885FB5E3BAAAF1F93F784537FF56202A31FE1757B4A0D5EBFF57674595E18FF1842D837D2DBFA3772CE87C5ADC4B40C798CD621984CEE091CD408D4C3EAEEAA148EE72EF60B219C190A856B5860AE623C584D78ADA18AC77B7FD2609FA4CEC6009BD621FAC86A1701B642CA5B34E157F535FDE3DB526AFCF3CD78701D9F31AF430896B7E35AAD786721F4314242A490BA429396213DF16C8702AD0CD0B696CFB3D9295475DE629B9622242BD594F98CEA7B3E26BCD618AA145FB591D5AA1237BD3B39B5F5A37C086E0A56396F0AB04B4E165ED23A64B55E804DBF453D34F6A4C26AB5545FD3A6663BA55EA70FC683EBC31082D960C67B7F6A78471D0BA18F697C4D681B6288CC295216C63CD032E49118A4FDEBBDBFF7DE9F4B98BDA94525309A1C84DDDACEF965B307C952AC65E1F0C65AEECF9A16EF478D7B0687D74A1B7E6BF8409D149A5CC693FA4F63455308E1507EE2DFF3CEB917CEB9B772A2FF5CE26B70B9222C2E3D59A0FA7A8D5E803DE7E704EB31813142BE3B352CFC105E6F872070983B19A398BDA749E59FD9CA2076F13C26BB66B4DDB779EEDB92BABD00BB011EEBBE1331507C2507157FF5DEC7365AB150EA341EA24B75361269B9EABAB32B21FEDC2CBCF6B52C306B1A138E1AF78CA9BC760A27701A26DEA526373BEB6E3471D212FB09C513FD9D737FC66DBB33AD6EED2E0FC4144C1608AF3788EF8F7C4EFEA18D48714C626DA1F7753B08F9B7772315D7D607FC960FE066417A3D427D4C913AE021BC7E6CDD5878475A74BE73CE7D96EAEC2081F6792FD43E24D8C636A8BAFECDEC41B22CB26B2F04AA65FCDF6C78ADED215B34EC890FC9C2939B2783590927CF6365B65464E7BE491C480FF0BED2AD4318C43C41FA21ED491B1A94C1A4DA961A269D6C59DF82C583060BB9905D60A63F57310871CE3D57702963F12C594FDB6BC3A2B5113297487DBE11DFD5C7863E6F0FA442BB0BB5BFF482EDF8732B0177F77309585E0100002000494441542641F78904DD8773FC525089AAEB5F4A555F6B2F04AA62FC2FF3182D0B05A3C63D3E8430EA4F8BDB761455A3BC28B935323E009D736F4AFDF9E2CFA1134509973F64BCA658C1BBDF4DF8A557D9D78C7FDE53DECAC9B6D8426FBBF471C3A72F9730F8BB8CB224E47A65F86D28FA0CB524F6DFA44267A3185C9798F824257DAEDF19FF35FE62C1653519DFFCABE892B8071B91E1DE70238545581243E742AFC99D2CEADFF6FFCA77B43E953CEB535BC416B473FE81D26EF6BF39FFCC81AA194F29C92D9DB4381E6C6CE5B5638BD36F341C2031F81A24C8FD3B639B889DFE6AA6F4BD2CD99282136D078837E9D84B5D2AB15FB30579160B826B93AC3F0FF9CC6D8F3070BD5A82EBE30A26B37704D7EBC96BA3A9451A95D776D032643EA52A049F4B25F79B7E25B75470DFF72AB7BBAAEDE5739E6080BC6F64038FCD5E7D2D735FB5394365E3290D8B70A3DB184F09AFCD9E1C9F8186F07AD4AA7DEFB0BE5C83F8574BED3A4A0ED276D916365CAFE54CD73BFD1F692B62E174606B98C01A24ED76CCF68AB77CA01ED4A8A9E2FA93824B998A0AC1A7A9B9EFB1686D83EC204DBDF386EFEA7A1AC726BBBD60FB83B427F94F42ED4B694542A06DC3193B8BD72AD14A45EBBDB0B6BC43C3EB3CFA1A4687D7B2756631F69FAF8CE91BDF0C0176FF0658BAC280BE561348907D192BB2A5A7A997EAFD5899FD5E6EF0DC17C62344B4CB6AF514DFD761A8667DECAA92E0FABCA2EDC314983C4DCB779942003B5257693EB078BC91A5D72686DA2FE519D20FB4CFA5425B43A11B8414B3596EF7975B89DED75AC3EBAAC6FDB2585EBAEFF5E87BFB94CA6B67A0B93AB62483A75C37A957DD0AB454289674C0C18D69C5CF8E54669F4AA0BD27A1F60BA9D27E2F5B816E2C57A7CE840A1CBBAC86D784B1C3F07AFDEE2EE3D86116717C120FF3AA68227B4720B6152DDF65EE29763C7940FE40B40CD9CCFA7D6C579E2BB142FB6B3C2F4CAAB34F988B962399040BBC4F9BB5E04FF1B8A5C66774E9D77AFECA6B71AE248CE201908004CB1799FEF5FDC96DE99E46545FCF20EECE902AED186A1F49B0FDAC176CBF9060BBABD826DCA6F2DA32AB0B0F2C980CC378E39758B57F68B9E581545FDD4B8FD35A3029DF8E960929CF7D03BCF7471976DAF2FCDDACB6EFC68E5467C730FB5FA9CC3E93CF16E673CAC1DB5BD995566A73D2B813A9C6FB74C97BEBDD9479C3A4F05AFE600DD5D7A52793A54BEF533AC91420F6C3EBD29506CB7DB8313309B6AF25D8EE2AB6FBE1F65F4B95DB2D04DC1CD66898BC77165B70109C0CC3B3E387781F3EB27ACF926AEB33D9DE5D5BCF4BC2EBED105E63881C3B4C08AF37303CAEDAD6AEF4CEFE2C55D9E704D979C982F59B9A7FC7C44E66EEDFAEB1CAB9C66774C9DF69D2736F6AE5B55332482EDD474AC3172DC90028E382C4F35E60AC619B1CD5D78AC5537D972AB75705DC7FF62AB873ED1898131358FB2C5672F0B9C318C7565B53C8E4F5B6D209EC058BA0B6C81942504CC29B9789AF30162CD032E669ADBC463BD262A40BB2CFE8939D16ED4246D9993933D1F67D9F5425AC55E17147D9F05A1EBCA583A3D237770D03CF9493C85C37F63861EC02F2D2AD435EC9041646C9E191D77203AE6180C704D630A3938C0726CF83319974EEBD82F32B06936AEB73A9B6AE75CB3013735B6ADAB959B31CD5B08CF9B6D3E2EBB4238BABB14FF66D8183F36A7546BB9051DE34BC9052F3FDA7C8F863EAFC2145E5B5CBD86A625BBB85DB4094FE605FA55C15923023C707BA1F166B9860517D5D0179A0D6D0AF940A58DB4E0C5E3D93E701649C515B8B89A16EE24E185B97FCFDBD3B918A9E5A0E655C654115AF39BC5F36E408AF19F36DA7F505F638BFF924FDB109B14792D7AEE6E77F6E1ADA049750F37DBAC4BD7572F16A92F05A49EFEB6255B4B275B664F5448E0AA81CFFCE9FAB76B2EA52BA77F10103812A54F1402574B04B424D8B7D0AF9CC0DD37AD5F583B5CF797CC6C749BF1C9055FBC283B96A78700FD62E53CB10C77BBFB5D6C3EBCE6E2FC466E7F00052E4D46AF89ACA811401B4A6E6715589607EF2EB99AAF2DAC94DA16418597A4255EAA6182B6D725431E7F8402F57C76AB8219CCD7C1001129207E94105AFA9C6D395B1BD73A3C118955FC3B47E909299031AE3E4DE7B1FC3A14F0D6D13260C1B464300C47BA65F96FBBED53303E64661C723F179F6C57B7FC9FCF569BD3ED7ADEF9A4BE174864E079A0E45AFB2DF754F8985413DE1B5BCB92557645E966C1D22017289EAEB5CDB77B37C5997DE230DABA03BF488B4492A0F3E54F2EB3089314A7AE85A5D40E173374CCBE1F5470B2182F7FE4842EB2F952C6C0E41C8334CE94972ED13E35AE498DB52B030CCC2D2C5CE24EE068855D8AD2FAA3FE5BC92D6921AECCC5078A829BCAE7D4C3577789DA4CD71CACAEB2EC02DF9402EDD0262EE3FFF2653D5754E3F6F4A5275A06140F2B2D1AD306649BB979AB6F230813548826BB33DF4084EB627F79C562B7716DACF88E8B507F9DC6068FD1DDFE7C14AB701A270423929B8C9117CB1703C0CAD43568B6392CF712C4A15F6633246CFD1F2A765CFE575CD45D3F8ADF667F4DCF7D524B94DD2F05A940C014F4ADEBC258C7D3BD31F67AEF7E41A5A7A509D367C92AE29DEFB53D90A5E539044E860487CCE580FAE3158CB07FC1E6B0C46E57B782AA1754BED4156A19273808CA1E41054CAEB976B9E45783D0CDF95CDE258F4BAE40E746DA4288D317A1EAF729C19A66C17C1A2F6D64E2104C26BF72BC07D9FFADFBBA59DC2E179FCFD63187B91F98F89C1F5A1D12A9BE51E835A56B5BE6F8561E55AAF382893EDE0EF2AFCF5A82A3142DAD5DC32286E870CD25B0D462FB4B50B890BCDB278F49F3C0F5A0EAD314EE94972F513E34AE4EA8BCE980FA9C5C5B85B0AB17E8ED96A692BA9D5A70C07876A0AAF5B39007BAEF30A2F52E596392AAF63807B5AA8FFB32B5D7DED7EFCFEC71903EC2EB8CE3DE89DE5E1271FE4DC61FFB67665E59A005B19A9B6BEAD783B78F3834DEDA4CAF34C7AE9129635429E07AD9E52FF50BA20A023DFBFD81A243E07BEB27884894A7FAE5B99189B25F7FE2C2D0738841099ECC83CB6741BD562E477FFD4E8AF3FB7CB548B25B26B40D3B8AE95B65E732DA2277B3DB384D7A2D48D7347C3445302ECD42D44EE660AAEDDCC619AA660E0397D08F5E8F5317D5779BF59164C94EA5A1348A5D49BCA7E37164D9ED6F229F5A7A57778C5CA1EA9B2EE5A8370F0D26A4DF6F91E43B693975E80649CA95FAE2AC0B92ADD6A42D8BFBD1DA98A6D2EC096B102C1F57C522E96685AD06567545A8B940BB6D9C2EB99FB3F2F7B95612BC360D242E4EF44BD08DFCF185CBB8C5BE51E91DF4953BFC697990F23C00612169E34D6C7B4F8FD0ABF9336355D685DEBE209E1F5065269DFEA613F773286995DF7DD9367C017A9C6697501616B2C463D4DAABB4AF7AFBF63626C02FDAEF5E05C98E19A09B03987A6A86EB164D47355DEBB6B658509644069259D4BE4ACBCEEC2DB52A1A48AFEC571801A4288C1D4EB11AF455C9DFFE89CFB2BB66299AB024A2640730786DAB665C705107A60CFA8D7C7F45E7A95B5D49AE13907ADE8100F0C89DF7DE7DCBF0D54FC37BBB5F42932E9ABAAD27EA059DB2A48607D226D41FEA597F528351CE29DDBA5827B3A13631B5A5DB85487C59ED1AA0FB025B3B826B82EEE5D0CA1872CA2CB67F35EE1CEB1969ED1B9CF5F7848FD7AFE91F25FB6C691BC30730F16776490AAA2A2318410DFB87309A80EE5675558F54D56E5AF0BF6449BFD4117428841F142D964F5A56C87B17A38A67AF27D3892CF5CEBDBC18F1554843549065BC7F2596C29303B90FB1B5B727BA4E2BAE5E0FA668ECF04F7FFE462F87FC6786535591CD7F03923BC562E2E6267BC429EB7E3DCF19C182506D8B7352E0048F879C6CE2C356208FDD57B7F159F7331DB59BEB0DEB84F43FBAE55AE42082D1DA89BFB77BD4C3D26F5218494FFBED57FC88F60E06BF63F68B58F210415070E59E1BDFF96F141F062DDA458F1210B71D5E88880270D028B8DFEA6C2641E32393D6C30B05E7623BB839A273B6DCEA9B85BFF9C9E8AFB7F768C7997F40E5DD55099772167E240B1CC2D08DEC7DDB4BCFFC3D016629287995B8F66C558CD947ED7813D03F3AD6CE35F8DA4DDCBBB8C97F657EAC580AC6D433A72B37C3DC79FB5C29B964FDD1D4A5EAB222B98529DBE28F1673F21BE1E5FC6F673C2CF43B7CE7A5BC23F105CAC744EAB9A3CA42DCD89B4038A0B749FA5BAB6F5D60407F4F8FFB99871CF64287DD535F7FF5931E6ED91C5124D5BCA9BBFD71AC182AE3E14108DB753CBFC420EDC65AC66C741EF47FB7CEB8E42C5A42E7254B1CF5279FDF30F2BBB6AFA5AC2516C200724E5BCB9FCB969FB80E2EAEB4EDCB676C2CD6D333930B5FBD1D6CB4ABB3BA99060EBF704F219DCEF7D0ED956B859931581126E9D739FFA6972D549AF3DDA11DFBD629A1FF34AC871AAE8F31727C61CAAA9DC0CBB859BFF6E8E21C1EB7FF6AE5C95D812C1E4D908920F9C5270828C9ABB3767AEBC4E5E75EDE60EAFDD8F17E9B660C50D03860D66D83AF010427872D57786003D858BF8106DAC2FD24A32D0EFFF10024D17B7F81DAFEA1786C7F80C2673239FBBEAEF6BB2B871CC36E4DF8C6A21B37496C721934B35AEE4FBDCD442A87CB7CF1456F733073140163D3E64BCD2A6B6A5A7543843A885A94205426BCC6411425875165DD532667FD95A529608AF9FC9D61F026C4564F2799BB94265AB0FB24C3CBE687C9D566826C496EF6E170EEE1112CEE2463E5F4C741E7F06BBCF219FC1F4AABCAFC9E7A73B288609F0634F862ABDEFE061EF7BC8A452AF070972CF6B1EA718F86E373931B6C87B7F9D795C41783DD20C0B0BADB893B39C543E13249338961FC617984393F960C6F03ADB195EB387D7EE5795DC75C1AD7C1C68B364A6D5ECAD0F299961F098DA8D4C0E4DDFF87AC1C4B35E38D805D56CFD2E6721AD0D2E6B3FD0B1F719DC5BFA21A49EDF953CAB2FAD065FBD03020FE991B8D1CF9606B280EC7ACF81FEA211CF01BBE2F7F932C7E9EFA548AFFAEE47F36793C21923BCF7B927C684D723D13A24B9F7717153C3F3A0B7007954E958ED41E6716F145C0B7ED7ECE272A6BC2DEBEE8E22E1B5D31160DFC8AA63F37D6567EC45BEF52ACC0C3DE77279E8C29EF8574D818FBCA65DDB962E9CE802C26754229A72233B25EEBBBF5A0817F90C9AB690CF5AF7F34DDB047CA932FF90AA6060AD3B19AB74CF0FF561DA52D5BFA5F334A8BA3662A69D9F84D713C443B759884EAA0B55CFE72C8E59BA9F1F3530FE7F2F7336CDE77AB5AAD97B72A6F03A4BAFEB4EB1F0DAE908B01F24C06E761031E316ACC18377EFFD59052B94FDC0E7FBE76CD5E76D29D4DB4617F82D5B6ECB42B56A5B1EE4B3167DEBFDE74EEA7BDDAA3640CB9F653E83F5BB93CF9BEB82EDDE6F7C2F3FDBD8B808D39BECB8A5450FAA8281E9FACF8FFEB3E2B7E746CE31736F2C5453D53F55D746CC70F68F23BC9EC6586B498B6E56CC1FB619C77D5B157ECBEEB7BDA59DBCAD15163CF4E6ECEC1CD0255B6F660B3284D7D97BEA170DAFDDAF2D7F9F8B5E84731FA5BF676B87DA1CCFB80238B8558B0415B7953FE06E08F700E0A77E80B647E53460CA62C062956B60D1E9673B1EE83753CB42C2EB890CB6966CC90DC5048FFC6C9BCAA1A3EA64AD12D6CE7B7F9F709EF57D9126779E5A3CBC76F387A8EBC417FCA495EA88195B857446DD1C58610700008041049586CCD0EFDAF199988EB9210CF92DD0539279E187ADCF62AB55E267DE2CAFE7FF72FF01DB90C0F875E1CB882B849FE20A44EFB0A2EAC46A66E9173667707D3376554B06781FD35F1200000090C51521A51DD2B2660E54E24F24DFAB2BD3BF045AB17C20E6A504DA282BEE123B6BF93D900E07A92CE65A0850115EBB5F01F63F0ABED0B174FE4BDC9224AB63D59050FEBEC04117533FCCA7D25315000000D02CCE65AA9A433460AE50396560D0B263424028F7B01C904A907DC91B57DC716BED825748F9CC1BD41A780A35E1B5FBF185BE9403C0343C8C0E7A95D8278957276625D5D6E7B2C56AEE1E5437532B4FE4E6C22400000000DA35778E4E0508AF0D616E08034ED63C079A6E55A1C04776457DB7B7C5FF671B5792E1CE425578ED7E3C8C6E1505D84E2AB13FC4D36163002C074C9A20A1F5A9545BCFD926A42FC90D5A3E176F935D1500000090562CDA687A3BB251B40D31460293D26D4781556ED69DA326AD542F78D58AB863F1E0A714CFA28739ABAE9D96031B57F1DEEFC9B60A8D27B22EE4DAAEE75C69D89654899FC84FC9D37E2F42084957C50B1C34090000003C6596D3F6919EF7FEDB4C73A6D81B3455C51B7EBC77318C7AC76B0145FE96C2BB9524ABB92F9CD3B4263E9F0F37BD2F2D892D92A5D3C4146FE75EAC571B5EBB5F5FECCB042F6C4EF18B70DD0BB3471D4C988254851F290977B30CE0E53371AD7451030000006D7AC176649BBCF7734E88FF6481232D39A7EA534DBF13CC7ABFCDE175B12DADECEEC73C5EAFAB866F518267DE5D0861F69D44AAC3EB8EB16ADB8584AB7155E736E7205682DC4309AC8F94ADDEFD93AB2A9DD54A000060C0838C07351761208DAD020BE823BB7DFF9DF1C2B2CD915A26455CE7CC0F51506C1772B8ED1F9FA8FA154F4BDE0DC032EFFDA19C8537C5C6DD05B99808AFDDAF15D533A30FA48584ADF106F54D26324EC2ED2757DE25ACDD97433EF67B3FBBF92F7D94D8083F6BFF1BEFFDBEBC9E0C50000080361FBB83FB98A0568F89B1618926F243649F27B54A1622CEB9DFA280C1BBCEE5F37A4B9E9155910A61CD12B45A2AB6586F26BC76BF02CB4BC5A16D0A77C65B62CC768320C046068BCAEF2F0080BC6EE29923FD8A142942B8E5F952A53BE9A3491B08A30A84D7842999192F7A834DA32A5165C7C067DEF32C783EAF30B1A0A2E8F3EB7FA5FEE031E486105FAC2B4BD73D90E9E05ADA98CC423E0F542E20851BE955B9C709D098D9839C96CF89F9806DDD73E4D1814032713A92EF3BEAC1C418633C978A4B6422BD6DE36BFC9EFB2E66F07A6C0B056921F49E3729B9F8BD3FE6F9BCD2D8E0FAFB6B9AF9DA3632155E3B99008410E204E02D0F2355E27B7134F70D420627843E18AB1F367CEF4F2F5B7F6F784591D9830C56E316C373EE6580590B99B81E6E3AE74426B6878C5DAB5164DC8B2C662BBCE939E2ADCC4B32835309B15FCBBD1A48EDFDD48300E5734AF1543A0FB2B03C7B4F66EDA4D27FACD3D2AFA9B9F0BA134238932AEC3B1D57D4B4EE06715FE245E8853E4C08B1AD47A1F592230611C8A41F5A9FF6830F026CC0941B09ADF7B69DB8126057A3E8B8175560E7E84C24C43E97DD957FCB790404D948E12255EF5F299E22D79A8EE07AB3B1E1F595E4AF4599EA79BD4E82A6E3186F219527C56F10F4C0C61662CBA1B34DD5717DDEFB1848BCE28545020B3944E8ECA94A3DE9D5F889171D50E946AA4FB67A8EACC278C5B43B19F7125C57A2E03C72548F5CA421F7E143097338E01143253FA857CEC7B836DE46B62482EB2778EFEF479CBF32F830D25CAA08AF1DA70B97A2AED71F1342ACF02007BD9E8E996CB238868916F2D91BB4A590C38600752EC63E475669E410F2DAD0E3BA4205C779C9C32F8C27F7E4FECF1EF767ACF13657152A01F66804D74F907BDCD711FFE88B29051B2955135E7798F0CFE64A6B137C6EFA1077722FB89CFA3995FE50E7DC5730C0A02AFF5508B780E216F21C39CF31DE91F1CA25851726C4C58B1382EBFA140CAFD554B3613D198B3D9350FB99546B136CB7EBF5D41ED74F21CB188CE07A0BDEFB389E7D33F01F7B9FAA354E0AD585D7EED717FE74C49B83EDA8FA10AF43CB87267555D667A91F60B2BBE392810436E85A839C27ACCE7C26FFCE97BCF0C06C2EE47B3C4BA5093B7CD43331EEC53885BF7F7CB68C92F15957A97D287F25D0AED7ACAD52E5F3754696F12482EB2D79EFBF0D2CC4BB89E78315BDE8255586D71D5A8924D79DACAE62DBC036A8C46FC695040D97B97F614206AC702115FED93E7F54FF03D925DBAD3386F7FE50BEE3841F7A981BF762B8C2E3BA851C24880A48F6D0F5D13E64CC568D623BCE4756CBB6823328B624F3C8CF03FE91B858B3AF6D6750D5E175472604A784D893DCC8CDC1DCD6362A66AB7525EFEBEC41836C213CE39ED2B41B099A66FBFC5185012477D7FB1E179FFCC877FC84055215D4B6C7435A0A8A12B2B72140191218753F04D9F63CC873207B71D42614B0ACC41914030CEC48A0B69ABD89F0BA43883DCA831C5094E550823951316B5ED712E4BA5465DC32A9EC3FA552AE192A822E9E65C024AA02EB55D83958948AB002F351303FA0FABA72B23079248B931453D9A0EA9C03C605BFE1B0DB01E4FEF3DF807F44ED826A53E1758789FFD6AAAB3AE1C66FCE5D2FAC56B96DB7572977C28A7895BA0AFF6B6D41178B27C0561EBAE7889685CF6D315E9D1D873236484971CBDB1A0A85F034EEEBEADDC87340650F65EFFD897C7E5A9C733EC87BC34E9501E433F361CB7FE26308E144C585AFD06478DD91ADFF276CC17EE44E6E0CD5F6F893ED3767843EEA2C2464B8D618166ED20BB18FF95C99B6E8055DD716420C09B1A9E6017EB9EB7D87CD8F65083BB2531D56202F79867E2AFC32C750668F859376C87DFD8CB19B1A37B2DB5CFD98418AF1CE1A3BCCFD4E8A2A794E0FE4BDBFDF329B507740E3B2A6C3EB8EDC008E099DDA5BCDA272B1B8F820BAB518566F429868CAC3D28289D941914C848E59904583EE96BEC75506407CC793331356201FF95E7D51F012BF0F219C2AB80ECCA8F14A5A0D2EE4D07F73CF818616B6B9378E34E0A046133DC409AF97C81B7CDCD84AD683ACDE9DB5BAE24F883D8B877E501DFF73ED9FB7DEEE0E0E6AD1A39AB07A1D5990ED7A2B724F436D9A7B962C939D3EC77CC747BB92312FA1353485D7D15FB51472607B326EBBA4E865360B69237A5EC3F7ADE2109B5D511379EFAFB7F85CC471F5BE85EF02E1F51ABDC9FF71C50F92E643EB6512621FB33577B285840B3F7F5A1F8C73E27831FDEAFEDBD60640B280722C9F3B422E5874B3F42C6112D3C3777C6B0F12569CB53E1EC1EFE43BF455C9CBA27EDB36F2F1DEC779F91B5EE22C1E7A675F547920AF84D8271514612E645714BDAD27903CF3DF27FE0D0F52716D626C4D78BD850A83EC3B19BC734358A337193C2668DCE86129A4BEA792E96912641F12362477B71472F159ECE93DCB8E58A0834271B272DF2D34C9F384A07A0019BB1CF21DFFCD9554D7551956200DEFBDA609318737364C490FF65A2C7AE75F34F30C30DC1297D03A21EFFDF9166DE65E5B7ABD09AF07321C6477AB8D674C0687A162F6A71B0916BA70E19EEAA5E9E49E72D8FB21CC7E5A0CA9BF759F43AA31C7910A8DEE87A00B73B991EFEF6DF74C61A1293D692DD27DBFF71BFA8E77E3DD6BA9B06367219EA42CBC36B3851B7910608F66F6E0FF5C8CECCEA2B032B12DABAE4D05D78EF07A1A9918F42B28B5059BD56F8F999B3C008E2A0E7B6EE4AFD7BD70A1B97EA225F50287AE826EAFD140BBABC2BCED05D5DF08A9F391FB5BFF87401B63748B4BF74BDF619E2585C98255FF3B5EC36EC2EACF31407E5BF6059D13ED431A4780FDA4FEF917B4A8DC82B2DD590FBDBEE33CB713F3DEC71EE8EF36FC5B2F4208C7E67E2FC2EB747A3784EEAF2502A79B5EB5093782CC7A958BFB12326A9E087661A093CF48FFAF840A8A49A0DD7DC6BA4A6D67385CEC069CAEF719BCEF556132F8544256EEF7E4F3D72DAC3CE350A126DDF47EE9E5EFADA37ADA2619BBEE2D3D63B42E9AF65BCBB0EB06C978EF2F15F6897D1F423855701D2864CB6DFFB57BB45B8B796B1A05B2AB3B797E13586724B9C1FD86C25A93C1B523BCCEAB17382D4F0C52DC18FA55891C62A4883C089EF502C6EEAF29039F9BA5FF7EDF0BA65D2F58205068802CA2B85EE8B0FC9F5DA63062B1F4B973BD2ACB0E9FC58A6DF9D923ECD6E1A9E786EB7F5FD9E980DEE295EB8D6596FFB34BB490DA5FD4FCB6BCC0C9F303396D51A556CA0B3EFB6DF3DEDF161A43BDEE8D11FA21E7D4B9C4F258A4FFF9EEE6108C3F0AE8655787BDB1FCFEC8EE02FD45876B161CE6F3C4F3EC2A847064F67723BC2E636942D0DD28D6E94F30A94A04904D5C7C61C088DAF542F76D740B924FC9B9C57B5378D10FFA7E22F0803671ECCB18161AC9F9369F155E1AFDAF1B2745515F0BBC0A2B174E7A01671FC164E5D6BCEFCB587428EC89AAEB58F97E68F9BB4A780D000000006852C180701BE603074CE3BD3F73CEBD99F965A4EA1F306643D57515CF11C26B0000000040B3BCF79A27C5A6B77A631AA9A6FC6FE69791F01A30443A3BDCAEA8BAAE6601F47F0AAE01000000008052967BF16AF2520EEF43832474BAE0BD07B0C161CDC1B523BC0600000000344E7BAFD657B2251C6DBAE47D07B04E08212E705EF5FEE7456D2DA708AF01000000002DB3D022E19DF7FE58C175606621844B39C01300D63996D03ADE2B8E6A3B2B81F01A00000000D0322BFD7D3F1160374BFBEE00000549587D2415D7D5DD2F08AF0100000000CD9249FF9D91DF9F00BB4D1CA00860A3185AD7185C3BC26B00000000004CF515FE440F6C64449537005508AF0100000000ADB376285EEC817DAEE03A5099DA7AE502B08FF01A00000000D034D96ABD30F61ABC8A01B6F7FE99826B0100200BC26B0000000000EC555F47AF623F64026C2472C30B09401BC26B00000000009CB3DA86E3B973EEDE7BBFAFE05A90078B13009AF5076F3D00006978EF0F9D73F1274E1EF76432B9EC410EC2E97EAE4308F7BC05000094155B8778EF63EB905D836FC58E73EEABF7FE6D08E14CC1F520ADB91626AE79DF0068E34308BC2900008C24554E27CEB92399388E71E79C3B0B2170F01200000579EFE333FD83F1F7E0228E4D3878AF1EDEFBB9829BD78C47016843DB1000004688A1B5F73E56A77C957E9363836B2715DA9FBCF7DF64D20C0000CAA821B88BE3925BDA88D4C17B7F34E32FC26E4000EA105E030030403C10C97B7F26A1F541E2D72E06E01FBCF74C3801002840AA952F2A78ED77A58DC8A9826BC134B385D72104DA86005087B62100006C4902E5F335BDAC7360EB2600003393E7FDD78A5EF7D89EEC38F6F456702D1820164D4835F4941D7EDBBA0B21503C01401D2AAF0100D8824C64AF670CAE9DB41221BC0600604612F2DE54F49A3FA70ADBAC9399826BC7618D00B422BC0600E009BDE07AAEC943DF2B026C0000665763D0FB4E5A931D2AB8163C41AAAEE73C0B85F01A804A84D700006C5038B8EEBCA25A0A0080F948EFDF9AAAAF3BB10AFB4B5C189770147ACD5975ED08AF016845CF6B0000D6F0DEEFC5D3FA0B07D77DFF84102E955C0B000055930AE52F15FF8E0FB1C23C8470A6E05AD053A0EF3AFDAE01A845780D00284A268671B01CAB7FF6E4A71383E36F7250CDEDDC070DC5ADB533F7B87E4A9C64EE8710EE155D130000D5F2DEC76AD483CADFE145ACF265815C07A977FAA9610000115E49444154889FFB9C95B72C6200D08AF01A00302B19901FC9CFCB817F760C6FE3C4EA32F7044BDA74BCCBF9678C741342A05725000033905D58FF36F25ADF482536ED230AF2DE5F8E18234FF5F7DC452200B02DC26B00C02C7A87CEA4EADF17AB84E241866721846F297F0785ED4296BD60620900C03CBCF7B122F54D432F372176217248F7AB99FFF44508616F8BFF1F001441780D00C8CE7B7F1C43E64C6170F2ADAE85260E43D09710008099C802FCBDE245ED5CAE24C4A6227706325EFE54E08FA6650800D508AF0100D9C864EF7CA6AD8F1712624FAAC2966BFE2FDD656543F53500003329182C6A4025766685ABFBFFE23C15009AFD8F77070090839C927E3D63CFBE58297D2D2D3FA63836F281B0729D0000981742389710B745F1C0CA2FF1F04A39681B09C98EBF52C1F515C13500EDA8BC060024D70BAE4B6CAF8D873A1E8EDDE2EABDBF9DF974F7B11E4208CF0C5C27000055307026C65C62CBB65339403BE9B9232D91DD7ED785C79DFFE43E041D00A6A2F21A0090944CEC4A05D74EFEDC6B09D00791498485E03ADAA1FA090080F948852ABD819DDB95162AF7B1DD45825D6FCD9131DC7DE171E782E01A800584D700806424FCBD54509114FFFC73B99E21AC85C184D70000CC2884102B8EEF78CDBFDB917617FF4A4B115A9A3D218E4DA5BFF51705E3E5D3C27F3E006C85F01A0090D299A2CAE5E77258E41083ABB50BB376BD0000D48090F6B1D817FB93F7FE5BECE13C66075CEDBCF747D276A6547FEBBE0729380100F508AF010049C880FC95B257F3A5F7FE64C0FFDFDAB6577A5E030030333957E32DAFFB4A3B321EFCEABDEFDA8A341D64C71621B132DD39F7595AAE687046BF72005670602300603269CF71AB6840DE172B4BF6B619A0CBC4E260D6AB9B86431B010028C4E0B8A1A48554FAC6431EAF5BF885A5AFF5A9C2CF487C2FF609AF015841E53500208513A5C1B5930AA05A0F572ADD2B110080961DC922399EB62BED32BE486B91CBD823BBB6C31EA5A775FCBD6EA5AFB5C6C58D53826B009650790D00982C4E420C04A97F8510EE37FD1F2C56508510BC82CB0000A049D236ED33EFFE24B112F8BAFB796ABCA68DEC403C94C50C6D2DF496DD8510E8470EC014C26B00C02472B2FC2703AFE2FB10C2C653D509AF0100C050B1AFB39243F86AF120EDE8AEE5AFB7DA026D6909B22F81B5A5B1E38B56DAB600A807E135006092B8ED331E8C68E0555C8410366E4DA5E73500001843DA443CE7C5CBEAC639F74D02EDFBEE2767B02D6D4DF624A8EEFE6AB5CFF95508E148C17500C02084D7008049BCF7961E241B5B8778EFCF0D6CF7ECBB09211CEAB91C0000DA24AD23EE398FA2A89BDE1F7E2B41F710CF249C7612546B3DCF658CAD0F3007006DFEE01D01008C255B262D89D77BBEE17A4DF5581C312903000019C45050C6455F797D8BE957445BAD8ECEE598E01A8055FFE39D03004C60EDC097A7C2F6DB99AE23156BD70B0040B54208F1B9FC9A7718CAC4762197BC2900AC22BC06004C61ADDFF2C69ED7723090251CB8030080222184B8C3EB23EF099488ED428E7933005846780D0098C25ADB908DE1B56CA7BC9BEF72A6E1B4780000F409219C38E72E786BA0C011ED42005847780D0068C93607EF6CEA89AD0993620000F43AB1B4208E2A7DA4D001400D08AF0100F89D959E8056427600009A23D5AE8704D828E446760000807984D70000F48410EE0D54352FA8A401004037026C14B288ED4278F101D482F01A0080C74E95BF26DAAF0F0000FC0AB08FE5E03C20B707FA5C03A80DE13500600A6B03E3AD2A9FA4FAFA7DFECB19256E03A5650800004684106EA5029B001BB91DC9E70D00AA41780D0098C2DAE078EBB03D8470AA709BEF83546F0100004308B03183D7B495035023C26B00C014F7C65EBDA161FB91B249E6895485030000637A01F682F70E89BD66671E805A115E0300A6B056793DE87A2528D672E0CD05931200006C93007B9F431C9110C13580AAF91002EF30006034EF7D6CC5B163E415FC73CC0136DEFBD8AAE3539E4BDA4A0CAE691702004025BCF7CF9C73B1C5C373DE534C40700DA07A545E0300A6BA34F20ADE8D3D795D2605FF146A2142700D004065644C125B885CF1DE6224826B004D20BC06004C6565D07C36E51F0E215C16E853F996E01A00803AC5003B8410DB935DF0166320826B00CDA06D08006032EF7DEC0DBDABF8958C15D37B632BAFFB649BEFA973EE4DD22BFC5D0CC88F39311E008036286851061B1E648C6865E723004C46E53500208553E5AFE2598AE0DAFDAA923A71CEBD70CEDDA4F877F6C409C9FB789013C1350000ED902ADABF0BB528830DF1B37148700DA035545E030092F0DEC7B0F540E1ABB90821ECE5FA977BEF632B91582DF56AC2BF66216D4DCE5385EC0000C01E0E72C41A77125C334E04D01CC26B004012DEFB7DE7DC5785AFE68B39AA9865B279283FFBF2B3B3E6FF1E2720F73239BD0E21DCE6BE3E00006087F7FE2C738B32D8C1E1DD009A46780D0048C67B1FDB87BC53F48A7E94161F000000A678EF8FE460EC758BE1A85B6C1372C2C18C005A47780D0048CA7B7F3EB185462A5772823F00008049B2B32B8EAD5EF20E36E54E0E6664771E80E67160230020B51319709774277DA8010000CC9283A2E362FC5B0E736CC6FB10C23EC13500FC40E5350020B9C2870D71A00D0000A88EF77E4F0E78A60ABB4E0BA9B6CE7E560B005842E535002039098EE3C1851733BFBA1752A942700D0000AA1242B8972AEC7F24E8443D62B5F51EC135003C46E53500202BEF7D6C23F221F31FC381360000A019B2CBED44D941D918EE46AAADEF79ED006035C26B004076B2CD3506CB0719FEAC2B09AE19F4030080A6641E63219F858C5F2F798D016033DA860000B2936DAEB18DC80BA9304921B6247911B7CF125C03008016651A63219FB85BF0BD736E9FE01A00B643E535006076522574243FDB560A3DC8219071A07F495F6B000080DF79EF8FE450C75D5E1A752EA4DA9A312C000C40780D0028CE7BBFEF9C8BBD1BF7E4A773EB9C8B03FC7BAAAB010000B6E3BD3F969ED8CF79C98A8BA1F5296359001887F01A00000000800A79EF634B91537A621741680D0009105E03000000005031D9E5162BB15FF13E6747680D0009115E0300000000D000EF7D6CD3D6B514A12F763A0FD26BFC8C9ED6009016E13500000000008D919622C77280F60EEFFF2837CEB9F310C2B9C16B07001308AF0100000000689454631FC9CF4B3E074F5A38E72EA5CA9AD620009019E1350000000000580EB20FA9C8FEE94102EBCB10C2A5926B028026105E03000000008047A4B54817643F6FEC158A15D6D704D6005016E1350000000000D8C87BBF272176FCD9AF34CCBE910AEBEB10C2AD82EB0180E6115E03000000008041A4C5481764777FB5D46624B602B995EAEA18565F2BB82600C012C26B0000000000309954677715DADD7F3E50F0CAC61620F71254C7C0FA96C31601C006C26B000080FFB7778747711D590046EF55ED7F9181E4086023583902918150046623581CC1A2088C22308A605106520628828508EE566B1F2ACA16F2CCF066A69B774ED514B28B41DD6FF8F5A9EB3600B035D329ED7632FBEE6BDCFBEF78E4A9EDBB13D4CDCDF4E76F5F8DFF00189B780D00000074E55EF0BEAF9D98BEF149012C87780D0000000040779EF9480000000000E88D780D000000004077C46B0000000000BA235E0300000000D01DF11A0000000080EE88D700000000007447BC0600000000A03BE2350000000000DD11AF0100000000E88E780D000000004077C46B0000000000BA235E0300000000D01DF11A0000000080EE88D7000000000074E76F3E1200000060A932F35544DCBD0E22E2F00F8FE27344DC44C455447C6A5FABEAC62F0CC0F6655579CC000000C06264E6CB88388B88E38878BEC1BE3F44C465555DF8AD01D81EF11A00000058847BD1FACD4CFBBD8D88F3F6721A1B607EE235000000F0A465E6C114AD7FD9D23E5BC43E75121B605EE235000000F0644D33AD5B547EB1833DB67122274E6103CC43BC060000009EA4CC3C8988DF76BCB72F6D9676557DF25B05F038CF3C3F000000E0A9C9CCF33D84EB984E785F65E6915F2A80C711AF01000080272533B739DF7A15CFA780FDD26F16C0E68C0D01000000FED274E9E17144B419D2ED54F1E103EF696333DAC88CABF6DAF5F88C3D8D0A79C8E7F6BCCCC006D88C780D0000003C28335BB06E41F8F5864FA9C5ECCB8838AFAAEB6D3EE9E9A4F3A7E9E4732FDE55D56947EB011886780D000000FCC97482F96C9AE13C97F7ED676E2B6267663BEDFD8F0E3FCD9FABEAAA8375000C45BC06000000BE992E1A3CDF7204FEB5AACEE6FC819D8D0BF9A32F5565FE35C09AC46B000000E0ABCC6CE32DFEBDA3A7D1E6411FCF750A3B33AF673E253EB7B75575D1F1FA00BA235E030000002DFEB6B0FA66C74FE276BAD0F051973A767EEAFA8ED3D7006B7AE681010000C0B2ED295CC774B1E2D534AAE4318E07F8005F4C911D801589D7000000B0607B0CD7771E15B033B39D667EBD9595CD6F84C80ED00DF11A000000162A33CFF61CAEEFB4807D9199071BBCF7D57696B415AF37DC23C02289D7000000B04099D9A2EFBF3ADAF961449C6DF0BE91E275387D0DB03AF11A00000096E9A2C35DFF3245F5758C16AF1F3BDF1B6031C46B0000005898695CC88B4E777DBEE6F7F7BA8F8788D7002B12AF01000060794E3ADEF16166AEB4BE0D4E69F7C0CC6B801589D7000000B0205318EEFDB4F226B3AF4771F884F706302BF11A0000009665840B035F64A68B0D01164EBC0600008085C8CC36B2E2F520BBED79B409003B205E030000C0728C34237A94C8BEAE2F632D17607FC46B000000588EA12E385CE142C69B1D2D654ED703AE19602FC46B000000588EA3C176FAC3785D559F76B794D988D7002B12AF0100006039468BD7ABACF7F30ED631A711833BC05E88D7000000B01CCF07DBE9C10ADF335A0CBEEA600D004310AF01000080915D0EB4F6DB41479D00EC85780D0000000CABAA5ABCBE1D64FD23857680BD13AF01000080D15D0CB2FE51D609D005F11A00000018DDF900EBFF5C55E65D03AC41BC06000080E51865BCC69D9B55BEA9AAAE23E2FD4E56B4B911023B4057C46B000000588ED12E0B5C67BDA71DC7F98F55656408C09AC46B000000588E271BAFABAA9DD23EDBEE723676DAE9BA00BA265E030000C0728C367379ADF556D57987E343FE5955A3FDA3014017B2AA7C12000000B00099791011FF1D64A7ED82C3A375DF34EDB145EFC3ED2C6B2DEFABEAA48375000CC9C96B000000588869B446EF171BDED96846F4B4C7572D7E6F6555AB13AE011E49BC060000806519E5E2C0CB4DDFD841C016AE0166205E030000C08254551BA9F1B1F31DB7F87BFD981FD002F63476E4DD7CCBFA4BB711F156B806988799D7000000B03099D94E25FFA7E35DFFF4D8787D5F661E4744BBCCF1C55C3FF33BDA3F089CBA9C11603E4E5E030000C0C24CA7AF3F74BAEB777386EBF8FF7EDB0892760AFBD7E974F49CBE4CA7AD5F09D700F372F21A0000001628330F22A245E2E71DEDBE85E0A36966F5564CFB6E27B14F23E2F0117F473B697D5155A3CC1007188E780D0000000B358DD3F8BDA3DDFF7D97A79733F3E574B1E3ABE964F68F62760BEB6D6DEDD4FAE5DCA7C301F833F11A000000162C33DBE582BF75F004DEF6708A790ADA2FEFFDAF1BE34000F643BC0600008085CBCC168DDFECF1297411AE01E88B0B1B01000060E1AAAA9DBE7EBBA7A7205C03F05D4E5E030000005F4D33B02F767489639B217D6C2407000F71F21A000000F8AAAA2EA779CF1FB6FC44DEB50B12856B007E44BC06000000BEA9AA7641613B81FD73447C9CF9C9BC8F889FAAEAB4FD3D9E3A003F626C08000000F0A0CC3C8A8893E9B5C93891DB6914C979555D7BD200AC4ABC06000000563285EC762AFB681A2F72F89DF7B559D62D525FB557555D79BA006C42BC0600000000A03B665E0300000000D01DF11A0000000080EE88D700000000007447BC0600000000A03BE2350000000000DD11AF0100000000E88E780D000000004077C46B0000000000BA235E0300000000D01DF11A0000000080EE88D700000000007447BC0600000000A03BE2350000000000DD11AF0100000000E88E780D000000004077C46B0000000000BA235E0300000000D01DF11A0000000080EE88D70000000000F42522FE070C808E4E58E1331B0000000049454E44AE426082)
SET IDENTITY_INSERT [dbo].[tblBranchImg] OFF
SET IDENTITY_INSERT [dbo].[tblControl] ON 

INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (1, 1, N'bbSave', N'إضافة فرع', N'Add')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (2, 1, N'bbEdit', N'تعديل', N'Update')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (3, 1, N'bbRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (4, 2, N'barButtonItem1', N'إضافة مستخدم', N'Add User')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (5, 2, N'bbiAddRole', N'إضافة صلاحية', N'Add Role')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (6, 2, N'bbiAddPermission', N'إذن الصلاحيات', N'Role Authorization')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (7, 2, N'bbiRoleUser', N'تعين صلاحية المستخدمين', N'User Role')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (8, 2, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (9, 3, N'bbiNew', N'إنشاء حساب', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (10, 3, N'bbiEdit', N'تعديل الحساب', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (11, 3, N'bbiDelete', N'حذف الحساب', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (12, 3, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (13, 3, N'bbiPrintPreview', N'طباعة', N'Print')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (14, 4, N'bbiNew', N'إضافة عملة', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (15, 4, N'bbiEdit', N'تعديل العملة', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (16, 4, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (17, 4, N'bbiPrintPreview', N'طباعة', N'Print')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (18, 5, N'bbiNew', N'إنشاء  صندوق', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (19, 5, N'bbiEdit', N'تعديل', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (20, 5, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (21, 5, N'bbiDelete', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (22, 5, N'bbiPrintPreview', N'طباعة', N'Print')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (23, 6, N'bbiNew', N'إضافة بنك', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (24, 6, N'bbiEdit', N'تعديل', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (25, 6, N'bbiDelete', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (26, 6, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (27, 6, N'bbiPrintPreview', N'طباعة', N'Print')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (28, 7, N'bbiNew', N'إضافة عميل', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (29, 7, N'bbiEdit', N'تعديل', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (30, 7, N'bbiDelete', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (31, 7, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (32, 7, N'bbiPrintPreview', N'طباعة', N'Print')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (33, 8, N'bbiNew', N'إضافة مورد
', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (34, 8, N'bbiEdit', N'تعديل
', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (35, 8, N'bbiDelete', N'حذف
', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (36, 8, N'bbiRefresh', N'تحديث
', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (37, 8, N'bbiPrintPreview', N'طباعة
', N'Print')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (38, 10, N'bbiNew', N'إضافة موظف
', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (39, 10, N'bbiEdit', N'تعديل
', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (40, 10, N'bbiDelete', N'حذف
', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (41, 10, N'bbiRefresh', N'تحديث
', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (42, 10, N'bbiPrintPreview', N'كشف إجمالي المرتبات
', N'Employees Payroll Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (43, 10, N'barButtonItem1', N'كشف مرتب تفصيلي
', N'Detail Employee Payroll Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (44, 11, N'bbiNew', N'صرف مرتبات
', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (45, 11, N'bbiEdit', N'تعديل
', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (46, 11, N'bbiDelete', N'حذف
', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (47, 11, N'bbiRefresh', N'تحديث
', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (48, 11, N'bbiPrintPreview', N'طباعة السند
', N'Print')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (49, 11, N'barButtonItem1', N'عرض / إخفاء الترحيل
', N'Show/Hide Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (50, 11, N'barButtonItem2', N'ترحيل
', N'Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (51, 12, N'bbiNew', N'إنشاء سند', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (52, 12, N'barButtonItem1', N'تعديل', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (53, 12, N'bbiDelete', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (54, 12, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (55, 12, N'barButtonItem3', N'طباعة السند', N'Print Invoice')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (56, 12, N'barButtonItem2', N'عرض/إخفاء الترحيل', N'Show/Hide Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (57, 12, N'bbiTarhel', N'ترحيل', N'Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (58, 13, N'bbiNew', N'سند صرف', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (59, 13, N'barButtonItem1', N'تعديل', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (60, 13, N'bbiDelete', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (61, 13, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (62, 13, N'barButtonItem3', N'طباعة السند', N'Print Invoice')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (63, 13, N'barButtonItem2', N'عرض/إخفاء الترحيل', N'Show/Hide Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (64, 13, N'bbiPhased', N'ترحيل', N'Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (65, 14, N'bbiNew', N'سند قبض', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (66, 14, N'bbiEdit', N'تعديل', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (67, 14, N'bbiDelete', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (68, 14, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (69, 14, N'barButtonItem3', N'طباعة السند', N'Print Invoice')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (70, 14, N'barButtonItem1', N'عرض/إخفاء الترحيل', N'Show/Hide Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (71, 14, N'barButtonItem2', N'نرحيل', N'Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (72, 15, N'barButtonItem4', N'إلغاء الترحيل', N'Undo Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (73, 15, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (74, 15, N'barButtonItem3', N'طباعة السند', N'Print Invoice')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (75, 17, N'bbiNew', N'المخازن', N'Stores')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (76, 17, N'barButtonItem1', N'إنشاء مجموعة', N'Add Group')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (77, 17, N'barButtonItem2', N'إنشاء صنف', N'Add Product')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (78, 17, N'barButtonItem3', N'البراكود', N'Barcode Label')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (79, 17, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (80, 17, N'barButtonItem5', N'تقرير المخازن', N'Stores Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (81, 18, N'bbiNew', N'رصيد إفتتاحي', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (82, 18, N'bbiEdit', N'تعديل', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (83, 18, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (84, 18, N'bbiDelete', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (85, 18, N'bbiNewBatch', N'رصيد إفتتاحي مجموعة (F1)', N'Add Batch Quantity')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (86, 19, N'bbiNew', N'تحويل مخزني', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (87, 19, N'bbiEdit', N'تعديل', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (88, 19, N'bbiDelete', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (89, 19, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (90, 19, N'bbiPrintPreview', N'طباعة الفاتورة', N'Print')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (91, 20, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (92, 20, N'bbiPrintPreview', N'تقرير الأصناف التفصيلي', N'Print')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (93, 21, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (94, 22, N'bbiNew', N'فاتورة مشتريات', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (95, 22, N'bbiEdit', N'تعديل', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (96, 22, N'bbiDelete', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (97, 22, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (98, 22, N'barButtonItem4', N'طباعة الفاتورة', N'Print Invoice')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (99, 22, N'barButtonItem2', N'عرض الترحيل', N'Show/Hide Phase')
GO
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (100, 22, N'barButtonItem1', N'ترحيل', N'Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (101, 23, N'barButtonItem5', N'مردود مشتريات', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (102, 23, N'barButtonItem7', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (103, 23, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (104, 23, N'barButtonItem4', N'طباعة الفاتورة', N'Print Invoice')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (105, 23, N'barButtonItem2', N'عرض الترحيل', N'Show/Hide Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (106, 23, N'barButtonItem1', N'ترحيل', N'Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (107, 24, N'barButtonItem6', N'إلغاء الترحيل', N'Undo Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (108, 24, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (109, 24, N'barButtonItem4', N'طباعة الفاتورة', N'Print Invoice')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (110, 25, N'bbiNew', N'فاتورة مبيعات', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (111, 25, N'bbiEdit', N'تعديل', N'Edit')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (112, 25, N'bbiDelete', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (113, 25, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (114, 25, N'barButtonItem3', N'طباعة الفاتورة', N'Print')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (115, 25, N'barButtonItem2', N'عرض الترحيل', N'Show/Hide Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (116, 25, N'barButtonItem1', N'ترحيل', N'Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (117, 26, N'barButtonItem4', N'مردود مبيعات', N'New')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (118, 26, N'barButtonItem6', N'حذف', N'Delete')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (119, 26, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (120, 26, N'barButtonItem3', N'طباعة الفاتورة', N'Print Invoice')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (121, 26, N'barButtonItem2', N'عرض الترحيل', N'Show/Hide Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (122, 26, N'barButtonItem1', N'ترحيل', N'Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (123, 27, N'barButtonItem5', N'إلغاء الترحيل', N'Undo Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (124, 27, N'bbiRefresh', N'تحديث', N'Refresh')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (125, 27, N'barButtonItem3', N'طباعة الفاتورة', N'Print Invoice')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (126, 31, N'barButtonItemCalculateTax', N'الإقرار الضريبي', N'Calculate Tax')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (127, 31, N'barButtonItem1', N'تصفير', N'Reset')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (128, 31, N'barButtonItem2', N'إعدادات الضريبة', N'Settings')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (129, 35, N'barButtonItemRprtPurchase', N'تقرير المشتريات', N'Puchases Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (130, 35, N'barButtonItemRprtSale', N'تقرير المبيعات', N'Sales Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (131, 35, N'barButtonItemRprtSaleDetail', N'تقرير المبيعات التفصيليه', N'Sales Detail Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (132, 35, N'barButtonItemRprtCustomerInvoice', N'تقرير فواتير العملاء', N'Customer Invoice Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (133, 35, N'barButtonItemRprtCustomerBalance', N'تقرير رصيد العملاء', N'Customer Balance Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (134, 35, N'barButtonItemRprtCustomersBalance', N'تقرير أرصدة العملاء', N'Customers Balance Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (135, 35, N'barButtonItemRprtSupplierInvoice', N'تقرير فواتير الموردين', N'Supplier Invoice Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (136, 35, N'barButtonItemRprtSupplierBalance', N'تقرير رصيد الموردين', N'Supplier Balance Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (137, 35, N'barButtonItemRprtSuppliersBalance', N'تقرير أرصدة الموردين', N'Suppliers Balance Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (138, 35, N'barButtonItemRprtStore', N'تقرير المخازن', N'Store Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (139, 35, N'barButtonItemRprtProduct', N'تقرير حركة الأصناف', N'Products Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (140, 35, N'barButtonItemRprtProductData', N'تقرير بيانات الأصناف', N'Products Detail Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (141, 35, N'barButtonItemRprtEmpSalAll', N'تقرير مرتبات الموظفين', N'Employees Payroll Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (142, 35, N'barButtonItemRprtEmpSal', N'تقرير مرتبات الموظفين التفصيلي', N'Detail Employee Payroll Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (143, 35, N'barButtonItemRprtDailyEntry', N'تقرير الحركة اليومية', N'Daily Entry Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (144, 35, N'barButtonItemRprtTaxDeclaration', N'تقرير الإقرار الضريبي', N'Tax Declaration Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (145, 35, N'barButtonItemRprtAccountBill', N'تقرير كشف الحسابات', N'Account Balance Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (146, 35, N'barButtonItemRprtTrailBalance', N'تقرير ميزان المراجعه', N'Trail Balance Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (147, 35, N'barButtonItemRprtBalanceSheet', N'تقرير الميزانية العمومية', N'Balance Sheet Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (148, 35, N'barButtonItemRprtProfitLoss', N'تقرير حساب الأرباح والخسائر', N'Profit Loss Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (150, 9, N'barButtonItemAccountOpening', N'عرض الأرصدة الإفتتاحية', N'View Opening Balance')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (151, 32, N'barButtonItemFinancialYear', N'عرض السنة المالية', N'View Financial Year')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (152, 33, N'barButtonItemDefaultSettings', N'عرض الإعدادات الإفتراضية', N'View Default Settings')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (153, 34, N'barButtonItemControlPanel', N'عرض لوحة التحكم', N'View Control Panel')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (157, 35, N'barButtonItemRprtSaleGroup', N'تقرير مبيعات المجموعات المحزنية', N'Sales Group Store Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (158, 28, N'bbiNew', N'جديد', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (159, 28, N'bbiEdit', N'تعديل', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (160, 28, N'bbiDelete', N'حذف', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (161, 28, N'bbiRefresh', N'تحديث', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (162, 28, N'bbiPrintPreview', N'طباعة الفاتورة', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (163, 29, N'bbiNew', N'جديد', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (164, 29, N'bbiEdit', N'تعديل', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (165, 29, N'bbiDelete', N'حذف', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (166, 29, N'bbiRefresh', N'تحديث', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (167, 29, N'bbiPrintPreview', N'طباعة الفاتورة', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (168, 30, N'bbiNew', N'جديد', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (169, 30, N'bbiEdit', N'تعديل', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (170, 30, N'bbiDelete', N'حذف', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (171, 30, N'bbiRefresh', N'تحديث', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (172, 30, N'bbiPrintPreview', N'طباعة الفاتورة', NULL)
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (173, 26, N'bbiDirectSalesRtrn', N'مردود مبيعات فورية', N'Direct Sale Return')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (174, 17, N'barButtonItem4', N'عرض نماذج الباركود', N'View barcode samples')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (175, 17, N'barButtonItem6', N'طباعه باركود الاصناف', N'Print barcode items')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (176, 35, N'barButtonItemRprtSaleCashier', N'تقرير المبيعات كاشير', N'Sales Report Cashier')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (178, 35, N'barButtonItemRprtSaleGroupRoll', N'تقرير مبيعات المجموعات المخزنية رول', N'Sales Group Store Report Roll')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (184, 35, N'barButtonItemRprtSaleGroupWithout', N'تقرير مبيعات', N'Sales Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (185, 35, N'barButtonItemRprtSaleUserWithout', N'تقرير مبيعات المستخدمين', N'User Sales Report')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (186, 24, N'BtnShowCancelBuyTarhel', N'عرض إلغاء الترحيل', N'Show/Hide Undo Phase')
INSERT [dbo].[tblControl] ([cntId], [cntucNo], [cntName], [cntCaption], [cntCaptionEn]) VALUES (187, 27, N'BtnShowCancelSalesTarhel', N'عرض إلغاء الترحيل', N'Show/Hide Undo Phase')
SET IDENTITY_INSERT [dbo].[tblControl] OFF
SET IDENTITY_INSERT [dbo].[tblCountry] ON 

INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (1, N'Afghanistan', N'أفغانستان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (2, N'Albania', N'ألبانيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (3, N'Algeria', N'الجزائر')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (4, N'American Samoa', N'ساموا-الأمريكي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (5, N'Andorra', N'أندورا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (6, N'Angola', N'أنغولا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (7, N'Anguilla', N'أنغويلا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (8, N'Antarctica', N'أنتاركتيكا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (9, N'Antigua and Barbuda', N'أنتيغوا وبربودا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (10, N'Argentina', N'الأرجنتين')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (11, N'Armenia', N'أرمينيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (12, N'Aruba', N'أروبه')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (13, N'Australia', N'أستراليا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (14, N'Austria', N'النمسا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (15, N'Azerbaijan', N'أذربيجان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (16, N'Bahamas', N'الباهاماس')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (17, N'Bahrain', N'البحرين')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (18, N'Bangladesh', N'بنغلاديش')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (19, N'Barbados', N'بربادوس')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (20, N'Belarus', N'روسيا البيضاء')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (21, N'Belgium', N'بلجيكا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (22, N'Belize', N'بيليز')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (23, N'Benin', N'بنين')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (24, N'Bermuda', N'جزر برمودا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (25, N'Bhutan', N'بوتان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (26, N'Bolivia', N'بوليفيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (27, N'Bosnia and Herzegovina', N'البوسنة و الهرسك')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (28, N'Botswana', N'بوتسوانا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (29, N'Brazil', N'البرازيل')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (30, N'Brunei Darussalam', N'بروني')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (31, N'Bulgaria', N'بلغاريا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (32, N'Burkina Faso', N'بوركينا فاسو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (33, N'Burundi', N'بوروندي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (34, N'Cambodia', N'كمبوديا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (35, N'Cameroon', N'كاميرون')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (36, N'Canada', N'كندا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (37, N'Cape Verde', N'الرأس الأخضر')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (38, N'Central African Republic', N'جمهورية أفريقيا الوسطى')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (39, N'Chad', N'تشاد')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (40, N'Chile', N'شيلي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (41, N'China', N'جمهورية الصين الشعبية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (42, N'Colombia', N'كولومبيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (43, N'Comoros', N'جزر القمر')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (44, N'Democratic Republic', N'جمهورية الكونغو الديمقراطية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (45, N'Congo, Republic of (Brazzaville)', N'جمهورية الكونغو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (46, N'Cook Islands', N'جزر كوك')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (47, N'Costa Rica', N'كوستاريكا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (48, N'Cote d”Ivoire', N'ساحل العاج')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (49, N'Croatia', N'كرواتيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (50, N'Cuba', N'كوبا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (51, N'Cyprus', N'قبرص')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (52, N'Czech Republic', N'الجمهورية التشيكية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (53, N'Denmark', N'الدانمارك')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (54, N'Djibouti', N'جيبوتي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (55, N'Dominica', N'دومينيكا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (56, N'Dominican Republic', N'الجمهورية الدومينيكية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (57, N'East Timor Timor-Leste', N'تيمور الشرقية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (58, N'Ecuador', N'إكوادور')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (59, N'Egypt', N'مصر')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (60, N'El Salvador', N'إلسلفادور')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (61, N'Equatorial Guinea', N'غينيا الاستوائي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (62, N'Eritrea', N'إريتريا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (63, N'Estonia', N'استونيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (64, N'Ethiopia', N'أثيوبيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (65, N'Faroe Islands', N'جزر فارو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (66, N'Fiji', N'فيجي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (67, N'Finland', N'فنلندا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (68, N'France', N'فرنسا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (69, N'French Guiana', N'غويانا الفرنسية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (70, N'French Polynesia', N'بولينيزيا الفرنسية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (71, N'Gabon', N'الغابون')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (72, N'Gambia', N'غامبيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (73, N'Georgia', N'جيورجيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (74, N'Germany', N'ألمانيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (75, N'Ghana', N'غانا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (76, N'Gibraltar', N'جبل طارق')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (77, N'Greece', N'اليونان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (78, N'Greenland', N'جرينلاند')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (79, N'Grenada', N'غرينادا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (80, N'Guadeloupe', N'جزر جوادلوب')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (81, N'Guam', N'جوام')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (82, N'Guatemala', N'غواتيمال')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (83, N'Guinea', N'غينيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (84, N'Guinea-Bissau', N'غينيا-بيساو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (85, N'Guyana', N'غيانا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (86, N'Haiti', N'هايتي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (87, N'Honduras', N'هندوراس')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (88, N'Hong Kong', N'هونغ كونغ')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (89, N'Hungary', N'المجر')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (90, N'Iceland', N'آيسلندا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (91, N'India', N'الهند')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (92, N'Indonesia', N'أندونيسيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (93, N'Iran', N'إيران')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (94, N'Iraq', N'العراق')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (95, N'Ireland', N'إيرلندا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (96, N'Italy', N'إيطاليا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (97, N'Jamaica', N'جمايكا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (98, N'Japan', N'اليابان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (99, N'Jordan', N'الأردن')
GO
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (100, N'Kazakhstan', N'كازاخستان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (101, N'Kenya', N'كينيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (102, N'Kiribati', N'كيريباتي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (103, N'Korea, (North Korea)', N'كوريا الشمالية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (104, N'Korea, (South Korea)', N'كوريا الجنوبية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (105, N'Kuwait', N'الكويت')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (106, N'Kyrgyzstan', N'قيرغيزستان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (107, N'Lao, PDR', N'لاوس')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (108, N'Latvia', N'لاتفيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (109, N'Lebanon', N'لبنان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (110, N'Lesotho', N'ليسوتو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (111, N'Liberia', N'ليبيريا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (112, N'Libya', N'ليبيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (113, N'Liechtenstein', N'ليختنشتين')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (114, N'Lithuania', N'لتوانيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (115, N'Luxembourg', N'لوكسمبورغ')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (116, N'Macao', N'ماكاو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (117, N'Macedonia, Rep. of', N'مقدونيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (118, N'Madagascar', N'مدغشقر')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (119, N'Malawi', N'مالاوي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (120, N'Malaysia', N'ماليزيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (121, N'Maldives', N'المالديف')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (122, N'Mali', N'مالي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (123, N'Malta', N'مالطا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (124, N'Marshall Islands', N'جزر مارشال')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (125, N'Martinique', N'مارتينيك')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (126, N'Mauritania', N'موريتانيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (127, N'Mauritius', N'موريشيوس')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (128, N'Mexico', N'المكسيك')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (129, N'Micronesia', N'مايكرونيزيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (130, N'Moldova', N'مولدافيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (131, N'Monaco', N'موناكو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (132, N'Mongolia', N'منغوليا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (133, N'Montenegro', N'الجبل الأسو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (134, N'Montserrat', N'مونتسيرات')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (135, N'Morocco', N'المغرب')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (136, N'Mozambique', N'موزمبيق')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (137, N'Myanmar, Burma', N'ميانمار')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (138, N'Namibia', N'ناميبيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (139, N'Nauru', N'نورو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (140, N'Nepal', N'نيبال')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (141, N'Netherlands', N'هولندا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (142, N'Netherlands Antilles', N'جزر الأنتيل الهولندي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (143, N'New Caledonia', N'كاليدونيا الجديدة')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (144, N'New Zealand', N'نيوزيلندا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (145, N'Nicaragua', N'نيكاراجوا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (146, N'Niger', N'النيجر')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (147, N'Nigeria', N'نيجيريا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (148, N'Niue', N'ني')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (149, N'Northern Mariana Islands', N'جزر ماريانا الشمالية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (150, N'Norway', N'النرويج')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (151, N'Oman', N'عُمان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (152, N'Pakistan', N'باكستان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (153, N'Palau', N'بالاو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (154, N'Palestine', N'فلسطين')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (155, N'Panama', N'بنما')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (156, N'Papua New Guinea', N'بابوا غينيا الجديدة')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (157, N'Paraguay', N'باراغواي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (158, N'Peru', N'بيرو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (159, N'Philippines', N'الفليبين')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (160, N'Poland', N'بولونيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (161, N'Portugal', N'البرتغال')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (162, N'Puerto Rico', N'بورتو ريكو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (163, N'Qatar', N'قطر')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (164, N'Reunion Island', N'ريونيون')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (165, N'Romania', N'رومانيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (166, N'Russia', N'روسيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (167, N'Rwanda', N'رواندا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (168, N'Saint Kitts and Nevis', N'سانت كيتس ونيفس')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (169, N'Saint Lucia', N'سانت لوسيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (170, N'Saint Vincent and the', N'سانت فنسنت وجزر غرينادين')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (171, N'Samoa', N'المناطق')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (172, N'San Marino', N'سان مارينو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (173, N'Sao Tome and Pr?ncipe', N'ساو تومي وبرينسيبي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (174, N'Saudi Arabia', N'المملكة العربية السعودية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (175, N'Senegal', N'السنغال')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (176, N'Serbia', N'جمهورية صربيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (177, N'Seychelles', N'سيشيل')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (178, N'Sierra Leone', N'سيراليون')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (179, N'Singapore', N'سنغافورة')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (180, N'Slovakia', N'سلوفاكيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (181, N'Slovenia', N'سلوفينيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (182, N'Solomon Islands', N'جزر سليمان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (183, N'Somalia', N'الصومال')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (184, N'South Africa', N'جنوب أفريقيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (185, N'Spain', N'إسبانيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (186, N'Sri Lanka', N'سريلانكا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (187, N'Sudan', N'السودان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (188, N'Suriname', N'سورينام')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (189, N'Swaziland', N'سوازيلند')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (190, N'Sweden', N'السويد')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (191, N'Switzerland', N'سويسرا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (192, N'Syria', N'سوريا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (193, N'Taiwan', N'تايوان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (194, N'Tajikistan', N'طاجيكستان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (195, N'Tanzania', N'تنزانيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (196, N'Thailand', N'تايلندا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (197, N'Tibet', N'تبت')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (198, N'Timor-Leste (East Timor)', N'تيمور الشرقية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (199, N'Togo', N'توغو')
GO
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (200, N'Tonga', N'تونغا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (201, N'Trinidad and Tobago', N'ترينيداد وتوباغو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (202, N'Tunisia', N'تونس')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (203, N'Turkey', N'تركيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (204, N'Turkmenistan', N'تركمانستان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (205, N'Tuvalu', N'توفالو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (206, N'Uganda', N'أوغندا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (207, N'Ukraine', N'أوكرانيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (208, N'United Arab Emirates', N'الإمارات العرب')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (209, N'United Kingdom', N'المملكة المتحدة')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (210, N'United States', N'الولايات المتحدة')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (211, N'Uruguay', N'أورغواي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (212, N'Uzbekistan', N'أوزباكستان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (213, N'Vanuatu', N'فانواتو')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (214, N'Vatican City State', N'الفاتيكان')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (215, N'Venezuela', N'فنزويلا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (216, N'Vietnam', N'فيتنام')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (217, N'Virgin Islands (British)', N'الجزر العذراء البريطانية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (218, N'Virgin Islands (U.S.)', N'الجزر العذراء الأمريكي')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (219, N'Wallis and ', N'والس وفوتونا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (220, N'Western Sahara', N'الصحراء الغربية')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (221, N'Yemen', N'اليمن')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (222, N'Zambia', N'زامبيا')
INSERT [dbo].[tblCountry] ([id], [cntEnName], [cntArName]) VALUES (223, N'Zimbabwe', N'زمبابوي')
SET IDENTITY_INSERT [dbo].[tblCountry] OFF
SET IDENTITY_INSERT [dbo].[tblCurrency] ON 

INSERT [dbo].[tblCurrency] ([id], [curName], [curSign], [curType], [curChange], [curCelling], [curFloar]) VALUES (1, N'ريال سعودي', N'ري', 1, NULL, NULL, NULL)
INSERT [dbo].[tblCurrency] ([id], [curName], [curSign], [curType], [curChange], [curCelling], [curFloar]) VALUES (2, N'دولار أمريكي', N'$', 2, 400, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblCurrency] OFF
SET IDENTITY_INSERT [dbo].[tblDefaultAccount] ON 

INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (1, 17, 1, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (2, 99, 2, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (12, 5, 3, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (13, 9, 4, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (15, 113, 5, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (16, 22, 6, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (17, 202, 7, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (18, 145, 8, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (19, 155, 9, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (20, 148, 10, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (21, 162, 11, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (22, 183, 12, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (23, 90, 14, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (24, 27, 15, 1)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (25, 17, 1, 8)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (26, 5, 3, 8)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (27, 9, 4, 8)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (28, 99, 2, 8)
INSERT [dbo].[tblDefaultAccount] ([dflId], [dflAccNo], [dflStatus], [dfltBrnId]) VALUES (29, 113, 5, 8)
SET IDENTITY_INSERT [dbo].[tblDefaultAccount] OFF
SET IDENTITY_INSERT [dbo].[tblFinancialYear] ON 

INSERT [dbo].[tblFinancialYear] ([fyId], [fyName], [fyDateStart], [fyDateEnd], [fyBranchId], [fyStatus], [fyIsNewYear]) VALUES (2008, N'2023', CAST(N'2023-01-01T00:00:00' AS SmallDateTime), CAST(N'2023-12-31T23:59:00' AS SmallDateTime), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[tblFinancialYear] OFF
SET IDENTITY_INSERT [dbo].[tblGroupStr] ON 

INSERT [dbo].[tblGroupStr] ([id], [grpNo], [grpName], [grpAccNo], [grpCurrency], [grpSalesAccNo], [grpCostAccNo], [grpDscntAccNo], [grpSalesRtrnAccNo], [grpCostRtrnAccNo], [grpBrnId], [grpStatus], [grpPurchaseAccNo], [grpPurchaseRtrnAccNo]) VALUES (1, 1, N'مجموعه رئيسيه', 1141010003, 1, 4111010002, 3121010002, 3124010002, 3123010002, 3122010002, 1, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblGroupStr] OFF
SET IDENTITY_INSERT [dbo].[tblPrdexpirateQuanMain] ON 

INSERT [dbo].[tblPrdexpirateQuanMain] ([expMainId], [expMainStrid], [expMainDate], [expMainBrnId], [expMainUserId]) VALUES (4, 2, CAST(N'2022-12-08' AS Date), 1, NULL)
INSERT [dbo].[tblPrdexpirateQuanMain] ([expMainId], [expMainStrid], [expMainDate], [expMainBrnId], [expMainUserId]) VALUES (1004, 2, CAST(N'2022-12-09' AS Date), 1, NULL)
SET IDENTITY_INSERT [dbo].[tblPrdexpirateQuanMain] OFF
SET IDENTITY_INSERT [dbo].[tblPrdPriceMeasurment] ON 

INSERT [dbo].[tblPrdPriceMeasurment] ([ppmId], [ppmMsurName], [ppmPrice], [ppmSalePrice], [ppmMinSalePrice], [ppmRetailPrice], [ppmBatchPrice], [ppmBarcode1], [ppmBarcode2], [ppmBarcode3], [ppmConversion], [ppmDefault], [ppmPrdId], [ppmWeight], [ppmBrnId], [ppmStatus], [ppmManufacture]) VALUES (1, N'حبة', 5, 7, 7, 6, 6, NULL, NULL, NULL, 1, 1, 1, 0, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[tblPrdPriceMeasurment] OFF
SET IDENTITY_INSERT [dbo].[tblProductColor] ON 

INSERT [dbo].[tblProductColor] ([colId], [colQuan], [colHtml]) VALUES (1, 62, N'#FDEADA')
INSERT [dbo].[tblProductColor] ([colId], [colQuan], [colHtml]) VALUES (2, 86, N'#FDEADA')
INSERT [dbo].[tblProductColor] ([colId], [colQuan], [colHtml]) VALUES (3, 65, N'#FDEADA')
SET IDENTITY_INSERT [dbo].[tblProductColor] OFF
SET IDENTITY_INSERT [dbo].[tblProductPriceOffers] ON 

INSERT [dbo].[tblProductPriceOffers] ([id], [Quantity], [Price], [ActiveShow], [Notes], [ExpireDate], [StartDate], [Date], [State], [DiscountType], [TotalFatora], [DiscountName], [StateName], [CustmerStartDate], [CustmerEndDate], [ShowName], [prdNo]) VALUES (1, NULL, 15, NULL, N'', NULL, NULL, CAST(N'2023-01-15T11:45:47.173' AS DateTime), 0, 3, 0, N'قسيمة خصم', N'دائم', NULL, NULL, N'', NULL)
INSERT [dbo].[tblProductPriceOffers] ([id], [Quantity], [Price], [ActiveShow], [Notes], [ExpireDate], [StartDate], [Date], [State], [DiscountType], [TotalFatora], [DiscountName], [StateName], [CustmerStartDate], [CustmerEndDate], [ShowName], [prdNo]) VALUES (2, 2, 3, NULL, N'', NULL, NULL, CAST(N'2023-01-18T11:08:57.127' AS DateTime), 0, 0, NULL, N'خصم على المنتج', N'دائم', NULL, NULL, N'منتجات العروض', NULL)
INSERT [dbo].[tblProductPriceOffers] ([id], [Quantity], [Price], [ActiveShow], [Notes], [ExpireDate], [StartDate], [Date], [State], [DiscountType], [TotalFatora], [DiscountName], [StateName], [CustmerStartDate], [CustmerEndDate], [ShowName], [prdNo]) VALUES (3, NULL, 4, NULL, N'', NULL, NULL, CAST(N'2023-01-18T12:16:29.787' AS DateTime), 0, 1, 40, N'خصم على الفاتورة', N'دائم', NULL, NULL, N'', NULL)
INSERT [dbo].[tblProductPriceOffers] ([id], [Quantity], [Price], [ActiveShow], [Notes], [ExpireDate], [StartDate], [Date], [State], [DiscountType], [TotalFatora], [DiscountName], [StateName], [CustmerStartDate], [CustmerEndDate], [ShowName], [prdNo]) VALUES (6, NULL, 5, NULL, N'', NULL, NULL, CAST(N'2023-01-19T11:34:39.020' AS DateTime), 0, 2, 40, N'خصم على فواتير عميل عن فترة', N'دائم', NULL, NULL, N'', NULL)
SET IDENTITY_INSERT [dbo].[tblProductPriceOffers] OFF
SET IDENTITY_INSERT [dbo].[tblProductQunatity] ON 

INSERT [dbo].[tblProductQunatity] ([id], [prdId], [prdQuantity], [prdSubQuantity], [prdSubQuantity3], [prdStrId], [prdBrnId], [prdStatus]) VALUES (1, 1, 0, 0, 0, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[tblProductQunatity] OFF
SET IDENTITY_INSERT [dbo].[tblRepresentativeStore] ON 

INSERT [dbo].[tblRepresentativeStore] ([id], [RepId], [StoreId], [ProudctName], [repPrice], [repQuntity], [ProudctNo], [barcode], [RepName]) VALUES (1, NULL, 1, N'تجريبي1', 15, NULL, 1, NULL, N'محمد سعيد')
SET IDENTITY_INSERT [dbo].[tblRepresentativeStore] OFF
SET IDENTITY_INSERT [dbo].[tblRole] ON 

INSERT [dbo].[tblRole] ([rolId], [rolName], [rolStatus]) VALUES (2, N'محاسب', NULL)
INSERT [dbo].[tblRole] ([rolId], [rolName], [rolStatus]) VALUES (106, N'مبيعات', NULL)
SET IDENTITY_INSERT [dbo].[tblRole] OFF
SET IDENTITY_INSERT [dbo].[tblRoleControl] ON 

INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2136, 2, 2, 8)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2137, 2, 3, 9)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2138, 2, 3, 10)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2139, 2, 3, 12)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2140, 2, 3, 13)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2141, 2, 5, 18)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2142, 2, 5, 19)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2143, 2, 5, 20)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2144, 2, 5, 22)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2145, 2, 6, 23)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2146, 2, 6, 24)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2147, 2, 6, 26)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2148, 2, 6, 27)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2149, 2, 7, 28)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2150, 2, 7, 29)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2151, 2, 7, 31)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2152, 2, 7, 32)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2153, 2, 8, 33)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2154, 2, 8, 34)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2155, 2, 8, 35)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2156, 2, 8, 36)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2157, 2, 8, 37)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2158, 2, 9, 150)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2159, 2, 10, 38)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2160, 2, 10, 39)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2161, 2, 10, 41)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2162, 2, 10, 42)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2163, 2, 10, 43)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2164, 2, 11, 44)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2165, 2, 11, 45)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2166, 2, 11, 47)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2167, 2, 11, 48)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2168, 2, 11, 49)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2169, 2, 11, 50)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2170, 2, 12, 51)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2171, 2, 12, 52)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2172, 2, 12, 53)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2173, 2, 12, 54)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2174, 2, 12, 55)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2175, 2, 12, 56)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2176, 2, 12, 57)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2177, 2, 13, 58)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2178, 2, 13, 59)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2179, 2, 13, 61)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2180, 2, 13, 62)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2181, 2, 13, 63)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2182, 2, 13, 64)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2183, 2, 14, 65)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2184, 2, 14, 66)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2185, 2, 14, 68)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2186, 2, 14, 69)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2187, 2, 14, 70)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2188, 2, 14, 71)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2189, 2, 15, 72)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2190, 2, 15, 73)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2191, 2, 15, 74)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2192, 2, 17, 75)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2193, 2, 17, 76)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2194, 2, 17, 77)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2195, 2, 17, 78)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2196, 2, 17, 79)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2197, 2, 17, 80)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2198, 2, 17, 174)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2199, 2, 17, 175)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2200, 2, 18, 81)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2201, 2, 18, 82)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2202, 2, 18, 83)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2203, 2, 18, 85)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2204, 2, 19, 86)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2205, 2, 19, 87)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2206, 2, 19, 89)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2207, 2, 19, 90)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2208, 2, 20, 91)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2209, 2, 20, 92)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2210, 2, 21, 93)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2211, 2, 22, 94)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2212, 2, 22, 95)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2213, 2, 22, 97)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2214, 2, 22, 98)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2215, 2, 22, 99)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2216, 2, 22, 100)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2217, 2, 23, 101)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2218, 2, 23, 103)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2219, 2, 23, 104)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2220, 2, 23, 105)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2221, 2, 23, 106)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2222, 2, 24, 107)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2223, 2, 24, 108)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2224, 2, 24, 109)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2225, 2, 25, 110)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2226, 2, 25, 111)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2227, 2, 25, 113)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2228, 2, 25, 114)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2229, 2, 25, 115)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2230, 2, 25, 116)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2231, 2, 26, 117)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2232, 2, 26, 119)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2233, 2, 26, 120)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2234, 2, 26, 121)
GO
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2235, 2, 26, 122)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2236, 2, 26, 173)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2237, 2, 27, 123)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2238, 2, 27, 124)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2239, 2, 27, 125)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2240, 2, 28, 158)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2241, 2, 28, 159)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2242, 2, 28, 161)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2243, 2, 28, 162)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2244, 2, 29, 163)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2245, 2, 29, 164)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2246, 2, 29, 166)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2247, 2, 29, 167)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2248, 2, 30, 168)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2249, 2, 30, 169)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2250, 2, 30, 171)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2251, 2, 30, 172)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2252, 2, 31, 126)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2253, 2, 31, 127)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2254, 2, 31, 128)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2255, 2, 32, 151)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2256, 2, 33, 152)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2257, 2, 34, 153)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2258, 2, 35, 129)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2259, 2, 35, 130)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2260, 2, 35, 131)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2261, 2, 35, 132)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2262, 2, 35, 133)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2263, 2, 35, 134)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2264, 2, 35, 135)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2265, 2, 35, 136)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2266, 2, 35, 137)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2267, 2, 35, 138)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2268, 2, 35, 139)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2269, 2, 35, 140)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2270, 2, 35, 143)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2271, 2, 35, 144)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2272, 2, 35, 145)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2273, 2, 35, 146)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2274, 2, 35, 176)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2275, 2, 35, 184)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2276, 2, 35, 185)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2500, 1, 7, 28)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2501, 1, 7, 31)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2502, 1, 7, 32)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2503, 1, 17, 77)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2504, 1, 17, 78)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2505, 1, 17, 79)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2506, 1, 18, 81)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2507, 1, 18, 82)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2508, 1, 18, 83)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2509, 1, 18, 85)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2510, 1, 19, 86)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2511, 1, 19, 87)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2512, 1, 19, 89)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2513, 1, 19, 90)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2514, 1, 20, 91)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2515, 1, 25, 110)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2516, 1, 25, 113)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2517, 1, 25, 114)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2518, 1, 25, 115)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2519, 1, 25, 116)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2520, 1, 27, 123)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2521, 1, 27, 124)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2522, 1, 27, 125)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2626, 106, 17, 78)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2627, 106, 17, 79)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2628, 106, 17, 174)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2629, 106, 17, 175)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2630, 106, 25, 110)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2631, 106, 25, 113)
INSERT [dbo].[tblRoleControl] ([rcId], [fkRoleId], [fkucNo], [fkControlId]) VALUES (2632, 106, 25, 114)
SET IDENTITY_INSERT [dbo].[tblRoleControl] OFF
SET IDENTITY_INSERT [dbo].[tblSetting] ON 

INSERT [dbo].[tblSetting] ([ID], [supplyA4CustomRprt], [supplyCashierCustomRprt], [teReportVocherCustom], [teReportReciptCustom], [teReportEntryCustom], [showRprtPurchaseHeader], [showRprtSaleHeader], [rprtOrderA4CustomRpt], [supplyRetuA4CustomRprt], [rprtSupplyCustomType], [MachineName], [IsInvoiceRound], [showPrdQtyMssg], [PayPartInvoValue], [isSendToECR], [ecrPort], [GroupProductsInInvoices], [defaultPrintOnSave], [ShowPrintMssg], [GroupWeightProdInInvoices], [ShowResetMssg], [defaultPrinterSettings], [defaultSalePriceFloar], [defaultBox], [defaultBank], [AllowSaveInvoInBeforeDate], [printA4], [defaultStrId], [ReadFormScaleBarcode], [BarcodeLength], [ScaleBarcodePrefix], [ProductCodeLength], [ValueCodeLength], [ReadMode], [IgnoreCheckDigit], [DivideValueBy], [defaultPrinterBarcode], [prdPriceTax], [supPrdLastPrice], [tsDefaultSalePriceAndBuy], [autoSupplyTarhel], [ShowlayoutControlCarData], [TaxReadMode], [InvType], [dfltAccLevel], [WelcomeMessage], [BranchID], [ordersPrintPreview], [ordersShowPrintMssg], [ordersPrinter], [ordersVoucherStr], [ordersExecuteStr], [ordersReceiptStr], [ordersVoucherStrPlu], [ordersExecuteStrPlu], [ordersReceiptStrPlu], [CalcTaxAfterDiscount], [AutoBarcode], [UserDrawerPeriods]) VALUES (12, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, N'DESKTOP-M2LHEL4', 0, 1, 0, 0, NULL, 1, 1, 0, 0, 0, NULL, 1, 0, 1, 0, 4, 1, 1, 13, N'99', 5, 6, 1, 1, 100, NULL, 0, 0, 1, 0, 0, 1, 1, 6, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[tblSetting] OFF
SET IDENTITY_INSERT [dbo].[tblStore] ON 

INSERT [dbo].[tblStore] ([id], [strNo], [strName], [strPhnNo], [strBrnId], [strStatus]) VALUES (1, 1, N'مخزن رئيسي', NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[tblStore] OFF
SET IDENTITY_INSERT [dbo].[tblSupplyMain] ON 

INSERT [dbo].[tblSupplyMain] ([id], [supNo], [supAccNo], [supAccName], [supRefNo], [supDesc], [supTotal], [supTotalFrgn], [supTaxPercent], [supTaxPrice], [supCurrency], [supDscntPercent], [supDscntAmount], [supBankId], [supBankAmount], [supCurrencyChng], [supCustSplId], [supDate], [supIsCash], [supEqfal], [supStrId], [supUserId], [supBrnId], [supStatus], [supDscntAmountٌRound], [CarType], [PlateNumber], [CounterNumber], [SendToserver], [IsDelete], [paidCash], [remin], [supBoxId], [PoNumber], [Notes], [DueDate], [EnterDate], [MainNo], [repName], [commission], [TotalAfterDiscount]) VALUES (1, 1, 1111010001, N'صندوق رقم 1', NULL, NULL, 15.217391304347828, 0, 15, 2.2826086956521738, 1, 0, 0, 1, 0, NULL, NULL, CAST(N'2023-01-10T20:45:00' AS SmallDateTime), 1, 2, 1, 1, 1, 8, 0, NULL, NULL, NULL, 0, 0, 17.5, 0, 1, NULL, NULL, NULL, CAST(N'2023-01-10T20:45:13.437' AS DateTime), 1, NULL, NULL, 15.217391304347828)
INSERT [dbo].[tblSupplyMain] ([id], [supNo], [supAccNo], [supAccName], [supRefNo], [supDesc], [supTotal], [supTotalFrgn], [supTaxPercent], [supTaxPrice], [supCurrency], [supDscntPercent], [supDscntAmount], [supBankId], [supBankAmount], [supCurrencyChng], [supCustSplId], [supDate], [supIsCash], [supEqfal], [supStrId], [supUserId], [supBrnId], [supStatus], [supDscntAmountٌRound], [CarType], [PlateNumber], [CounterNumber], [SendToserver], [IsDelete], [paidCash], [remin], [supBoxId], [PoNumber], [Notes], [DueDate], [EnterDate], [MainNo], [repName], [commission], [TotalAfterDiscount]) VALUES (2, 1, 1111010001, N'صندوق رقم 1', N'2', NULL, 1500, 0, 15, 225, 1, 0, 0, 1, 0, NULL, NULL, CAST(N'2023-01-13T22:49:00' AS SmallDateTime), 1, 2, 1, 1, 1, 15, 0, NULL, NULL, NULL, 0, 1, 1725, 0, 1, NULL, NULL, NULL, CAST(N'2023-01-13T22:50:30.613' AS DateTime), 1, NULL, NULL, 1500)
INSERT [dbo].[tblSupplyMain] ([id], [supNo], [supAccNo], [supAccName], [supRefNo], [supDesc], [supTotal], [supTotalFrgn], [supTaxPercent], [supTaxPrice], [supCurrency], [supDscntPercent], [supDscntAmount], [supBankId], [supBankAmount], [supCurrencyChng], [supCustSplId], [supDate], [supIsCash], [supEqfal], [supStrId], [supUserId], [supBrnId], [supStatus], [supDscntAmountٌRound], [CarType], [PlateNumber], [CounterNumber], [SendToserver], [IsDelete], [paidCash], [remin], [supBoxId], [PoNumber], [Notes], [DueDate], [EnterDate], [MainNo], [repName], [commission], [TotalAfterDiscount]) VALUES (3, 2, 1111010001, N'صندوق رقم 1', N'4', NULL, 49, 0, 15, 7.35, 1, 0, 0, 1, 0, NULL, NULL, CAST(N'2023-01-16T15:09:00' AS SmallDateTime), 1, 2, 1, 1, 1, 17, 0, NULL, NULL, NULL, 0, 1, 56.35, 0, 1, N'', NULL, NULL, CAST(N'2023-01-16T15:12:21.357' AS DateTime), 2, NULL, NULL, 49)
INSERT [dbo].[tblSupplyMain] ([id], [supNo], [supAccNo], [supAccName], [supRefNo], [supDesc], [supTotal], [supTotalFrgn], [supTaxPercent], [supTaxPrice], [supCurrency], [supDscntPercent], [supDscntAmount], [supBankId], [supBankAmount], [supCurrencyChng], [supCustSplId], [supDate], [supIsCash], [supEqfal], [supStrId], [supUserId], [supBrnId], [supStatus], [supDscntAmountٌRound], [CarType], [PlateNumber], [CounterNumber], [SendToserver], [IsDelete], [paidCash], [remin], [supBoxId], [PoNumber], [Notes], [DueDate], [EnterDate], [MainNo], [repName], [commission], [TotalAfterDiscount]) VALUES (4, 3, 1111010001, N'صندوق رقم 1', N'1', NULL, 310, 0, 15, 42.3, 1, 9.0322580645161281, 28, 1, 0, NULL, NULL, CAST(N'2023-01-18T16:20:00' AS SmallDateTime), 1, 2, 1, 1, 1, 17, 0, NULL, NULL, NULL, 0, 1, 324.3, 0, 1, NULL, NULL, NULL, CAST(N'2023-01-18T16:21:32.190' AS DateTime), 3, 1, NULL, 282)
INSERT [dbo].[tblSupplyMain] ([id], [supNo], [supAccNo], [supAccName], [supRefNo], [supDesc], [supTotal], [supTotalFrgn], [supTaxPercent], [supTaxPrice], [supCurrency], [supDscntPercent], [supDscntAmount], [supBankId], [supBankAmount], [supCurrencyChng], [supCustSplId], [supDate], [supIsCash], [supEqfal], [supStrId], [supUserId], [supBrnId], [supStatus], [supDscntAmountٌRound], [CarType], [PlateNumber], [CounterNumber], [SendToserver], [IsDelete], [paidCash], [remin], [supBoxId], [PoNumber], [Notes], [DueDate], [EnterDate], [MainNo], [repName], [commission], [TotalAfterDiscount]) VALUES (5, 4, 1111010001, N'صندوق رقم 1', N'10002', NULL, 140, 0, 15, 19.2, 1, 8.5714285714285712, 12, 1, 0, NULL, 1, CAST(N'2023-01-19T11:35:00' AS SmallDateTime), 1, 2, 1, 1, 1, 17, 0, NULL, NULL, NULL, 0, 1, 147.2, 0, 1, NULL, NULL, NULL, CAST(N'2023-01-19T11:39:01.780' AS DateTime), 4, 1, NULL, 128)
INSERT [dbo].[tblSupplyMain] ([id], [supNo], [supAccNo], [supAccName], [supRefNo], [supDesc], [supTotal], [supTotalFrgn], [supTaxPercent], [supTaxPrice], [supCurrency], [supDscntPercent], [supDscntAmount], [supBankId], [supBankAmount], [supCurrencyChng], [supCustSplId], [supDate], [supIsCash], [supEqfal], [supStrId], [supUserId], [supBrnId], [supStatus], [supDscntAmountٌRound], [CarType], [PlateNumber], [CounterNumber], [SendToserver], [IsDelete], [paidCash], [remin], [supBoxId], [PoNumber], [Notes], [DueDate], [EnterDate], [MainNo], [repName], [commission], [TotalAfterDiscount]) VALUES (6, 5, 1111010001, N'صندوق رقم 1', NULL, NULL, 7, 0, 15, 1.05, 1, 0, 0, 1, 0, NULL, NULL, CAST(N'2023-01-19T23:21:00' AS SmallDateTime), 1, 2, 1, 1, 1, 17, 0, NULL, NULL, NULL, 0, 1, 8.05, 0, 1, NULL, NULL, NULL, CAST(N'2023-01-19T23:20:59.017' AS DateTime), 5, NULL, NULL, 7)
INSERT [dbo].[tblSupplyMain] ([id], [supNo], [supAccNo], [supAccName], [supRefNo], [supDesc], [supTotal], [supTotalFrgn], [supTaxPercent], [supTaxPrice], [supCurrency], [supDscntPercent], [supDscntAmount], [supBankId], [supBankAmount], [supCurrencyChng], [supCustSplId], [supDate], [supIsCash], [supEqfal], [supStrId], [supUserId], [supBrnId], [supStatus], [supDscntAmountٌRound], [CarType], [PlateNumber], [CounterNumber], [SendToserver], [IsDelete], [paidCash], [remin], [supBoxId], [PoNumber], [Notes], [DueDate], [EnterDate], [MainNo], [repName], [commission], [TotalAfterDiscount]) VALUES (7, 6, 1111010001, N'صندوق رقم 1', NULL, NULL, 7, 0, 15, 1.05, 1, 0, 0, 1, 0, NULL, NULL, CAST(N'2023-01-19T23:58:00' AS SmallDateTime), 1, 2, 1, 1, 1, 17, 0, NULL, NULL, NULL, 0, 1, 8.05, 0, 1, NULL, NULL, NULL, CAST(N'2023-01-19T23:57:56.197' AS DateTime), 6, NULL, NULL, 7)
INSERT [dbo].[tblSupplyMain] ([id], [supNo], [supAccNo], [supAccName], [supRefNo], [supDesc], [supTotal], [supTotalFrgn], [supTaxPercent], [supTaxPrice], [supCurrency], [supDscntPercent], [supDscntAmount], [supBankId], [supBankAmount], [supCurrencyChng], [supCustSplId], [supDate], [supIsCash], [supEqfal], [supStrId], [supUserId], [supBrnId], [supStatus], [supDscntAmountٌRound], [CarType], [PlateNumber], [CounterNumber], [SendToserver], [IsDelete], [paidCash], [remin], [supBoxId], [PoNumber], [Notes], [DueDate], [EnterDate], [MainNo], [repName], [commission], [TotalAfterDiscount]) VALUES (8, 7, 1111010001, N'صندوق رقم 1', N'1', NULL, 7, 0, 15, 1.05, 1, 0, 0, 1, 0, NULL, NULL, CAST(N'2023-01-20T17:07:00' AS SmallDateTime), 1, 2, 1, 1, 1, 17, 0, NULL, NULL, NULL, 0, 1, 8.05, 0, 1, NULL, NULL, NULL, CAST(N'2023-01-20T17:07:53.967' AS DateTime), 7, NULL, NULL, 7)
INSERT [dbo].[tblSupplyMain] ([id], [supNo], [supAccNo], [supAccName], [supRefNo], [supDesc], [supTotal], [supTotalFrgn], [supTaxPercent], [supTaxPrice], [supCurrency], [supDscntPercent], [supDscntAmount], [supBankId], [supBankAmount], [supCurrencyChng], [supCustSplId], [supDate], [supIsCash], [supEqfal], [supStrId], [supUserId], [supBrnId], [supStatus], [supDscntAmountٌRound], [CarType], [PlateNumber], [CounterNumber], [SendToserver], [IsDelete], [paidCash], [remin], [supBoxId], [PoNumber], [Notes], [DueDate], [EnterDate], [MainNo], [repName], [commission], [TotalAfterDiscount]) VALUES (9, 8, 1111010001, N'صندوق رقم 1', N'6', NULL, 7, 0, 15, 1.05, 1, 0, 0, 1, 0, NULL, NULL, CAST(N'2023-01-20T17:11:00' AS SmallDateTime), 1, 2, 1, 1, 1, 17, 0, NULL, NULL, NULL, 0, 1, 8.05, 0, 1, NULL, NULL, NULL, CAST(N'2023-01-20T17:11:42.837' AS DateTime), 8, NULL, NULL, 7)
SET IDENTITY_INSERT [dbo].[tblSupplyMain] OFF
SET IDENTITY_INSERT [dbo].[tblSupplySub] ON 

INSERT [dbo].[tblSupplySub] ([id], [supNo], [supAccNo], [supAccName], [supDesc], [supPrdBarcode], [supPrdNo], [supPrdName], [supPrdId], [supMsur], [supCurrency], [supQuanMain], [supPrice], [supSalePrice], [supTaxPercent], [supTaxPrice], [supDscntPercent], [supDscntAmount], [supDebit], [supCredit], [supDebitFrgn], [supCreditFrgn], [supDate], [supBrnId], [supUserId], [supStatus], [supPrdManufacture], [subQteMeter], [subHeight], [subWidth], [subNoPacks], [ExpireDate], [supOvertime], [supWorkingtime], [StoreID], [Conversion], [NumberDays], [EquipmentNo]) VALUES (1, 1, 1141010003, N'مخزون مجموعه رئيسيه', NULL, N'617950154532', N'1-2', N'خل طبيعى العلالى', 2, 2, 1, 1, 0, 3.0434782608695654, 15, 0.45652173913043481, NULL, NULL, NULL, 3.5, NULL, NULL, CAST(N'2023-01-10T20:44:56.793' AS DateTime), 1, 1, 8, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[tblSupplySub] ([id], [supNo], [supAccNo], [supAccName], [supDesc], [supPrdBarcode], [supPrdNo], [supPrdName], [supPrdId], [supMsur], [supCurrency], [supQuanMain], [supPrice], [supSalePrice], [supTaxPercent], [supTaxPrice], [supDscntPercent], [supDscntAmount], [supDebit], [supCredit], [supDebitFrgn], [supCreditFrgn], [supDate], [supBrnId], [supUserId], [supStatus], [supPrdManufacture], [subQteMeter], [subHeight], [subWidth], [subNoPacks], [ExpireDate], [supOvertime], [supWorkingtime], [StoreID], [Conversion], [NumberDays], [EquipmentNo]) VALUES (2, 1, 1141010003, N'مخزون مجموعه رئيسيه', NULL, N'617950600060', N'1-3', N'كاتشب طماطم كبير', 3, 3, 1, 1, 0, 12.173913043478262, 15, 1.8260869565217393, NULL, NULL, NULL, 14, NULL, NULL, CAST(N'2023-01-10T20:44:56.793' AS DateTime), 1, 1, 8, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[tblSupplySub] ([id], [supNo], [supAccNo], [supAccName], [supDesc], [supPrdBarcode], [supPrdNo], [supPrdName], [supPrdId], [supMsur], [supCurrency], [supQuanMain], [supPrice], [supSalePrice], [supTaxPercent], [supTaxPrice], [supDscntPercent], [supDscntAmount], [supDebit], [supCredit], [supDebitFrgn], [supCreditFrgn], [supDate], [supBrnId], [supUserId], [supStatus], [supPrdManufacture], [subQteMeter], [subHeight], [subWidth], [subNoPacks], [ExpireDate], [supOvertime], [supWorkingtime], [StoreID], [Conversion], [NumberDays], [EquipmentNo]) VALUES (3, 2, 1141010003, N'مخزون مجموعه رئيسيه', NULL, N'1', N'1-1', N'تجريبي1', 1, 1, 1, 300, 5, 7, 15, 225, NULL, NULL, 1725, NULL, NULL, NULL, CAST(N'2023-01-13T22:49:09.660' AS DateTime), 1, 1, 15, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[tblSupplySub] ([id], [supNo], [supAccNo], [supAccName], [supDesc], [supPrdBarcode], [supPrdNo], [supPrdName], [supPrdId], [supMsur], [supCurrency], [supQuanMain], [supPrice], [supSalePrice], [supTaxPercent], [supTaxPrice], [supDscntPercent], [supDscntAmount], [supDebit], [supCredit], [supDebitFrgn], [supCreditFrgn], [supDate], [supBrnId], [supUserId], [supStatus], [supPrdManufacture], [subQteMeter], [subHeight], [subWidth], [subNoPacks], [ExpireDate], [supOvertime], [supWorkingtime], [StoreID], [Conversion], [NumberDays], [EquipmentNo]) VALUES (4, 3, 1141010003, N'مخزون مجموعه رئيسيه', NULL, N'1', N'1-1', N'تجريبي1', 1, 1, 1, 7, 5, 7, 15, 7.35, NULL, NULL, NULL, 56.35, NULL, NULL, CAST(N'2023-01-16T15:08:48.930' AS DateTime), 1, 1, 17, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[tblSupplySub] ([id], [supNo], [supAccNo], [supAccName], [supDesc], [supPrdBarcode], [supPrdNo], [supPrdName], [supPrdId], [supMsur], [supCurrency], [supQuanMain], [supPrice], [supSalePrice], [supTaxPercent], [supTaxPrice], [supDscntPercent], [supDscntAmount], [supDebit], [supCredit], [supDebitFrgn], [supCreditFrgn], [supDate], [supBrnId], [supUserId], [supStatus], [supPrdManufacture], [subQteMeter], [subHeight], [subWidth], [subNoPacks], [ExpireDate], [supOvertime], [supWorkingtime], [StoreID], [Conversion], [NumberDays], [EquipmentNo]) VALUES (5, 4, 1141010003, N'مخزون مجموعه رئيسيه', NULL, N'1', N'1-1', N'تجريبي1', 1, 1, 1, 50, 5, 6.2, 15, 42.3, 9.0322580645161281, 28, NULL, 324.3, NULL, NULL, CAST(N'2023-01-18T16:20:04.130' AS DateTime), 1, 1, 17, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[tblSupplySub] ([id], [supNo], [supAccNo], [supAccName], [supDesc], [supPrdBarcode], [supPrdNo], [supPrdName], [supPrdId], [supMsur], [supCurrency], [supQuanMain], [supPrice], [supSalePrice], [supTaxPercent], [supTaxPrice], [supDscntPercent], [supDscntAmount], [supDebit], [supCredit], [supDebitFrgn], [supCreditFrgn], [supDate], [supBrnId], [supUserId], [supStatus], [supPrdManufacture], [subQteMeter], [subHeight], [subWidth], [subNoPacks], [ExpireDate], [supOvertime], [supWorkingtime], [StoreID], [Conversion], [NumberDays], [EquipmentNo]) VALUES (6, 5, 1141010003, N'مخزون مجموعه رئيسيه', NULL, N'1', N'1-1', N'تجريبي1', 1, 1, 1, 20, 5, 7, 15, 19.2, 8.5714285714285712, 12, NULL, 147.2, NULL, NULL, CAST(N'2023-01-19T11:35:21.693' AS DateTime), 1, 1, 17, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[tblSupplySub] ([id], [supNo], [supAccNo], [supAccName], [supDesc], [supPrdBarcode], [supPrdNo], [supPrdName], [supPrdId], [supMsur], [supCurrency], [supQuanMain], [supPrice], [supSalePrice], [supTaxPercent], [supTaxPrice], [supDscntPercent], [supDscntAmount], [supDebit], [supCredit], [supDebitFrgn], [supCreditFrgn], [supDate], [supBrnId], [supUserId], [supStatus], [supPrdManufacture], [subQteMeter], [subHeight], [subWidth], [subNoPacks], [ExpireDate], [supOvertime], [supWorkingtime], [StoreID], [Conversion], [NumberDays], [EquipmentNo]) VALUES (7, 6, 1141010003, N'مخزون مجموعه رئيسيه', NULL, N'1', N'1-1', N'تجريبي1', 1, 1, 1, 1, 5, 7, 15, 1.05, NULL, NULL, NULL, 8.05, NULL, NULL, CAST(N'2023-01-19T23:20:37.057' AS DateTime), 1, 1, 17, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[tblSupplySub] ([id], [supNo], [supAccNo], [supAccName], [supDesc], [supPrdBarcode], [supPrdNo], [supPrdName], [supPrdId], [supMsur], [supCurrency], [supQuanMain], [supPrice], [supSalePrice], [supTaxPercent], [supTaxPrice], [supDscntPercent], [supDscntAmount], [supDebit], [supCredit], [supDebitFrgn], [supCreditFrgn], [supDate], [supBrnId], [supUserId], [supStatus], [supPrdManufacture], [subQteMeter], [subHeight], [subWidth], [subNoPacks], [ExpireDate], [supOvertime], [supWorkingtime], [StoreID], [Conversion], [NumberDays], [EquipmentNo]) VALUES (8, 7, 1141010003, N'مخزون مجموعه رئيسيه', NULL, N'1', N'1-1', N'تجريبي1', 1, 1, 1, 1, 5, 7, 15, 1.05, NULL, NULL, NULL, 8.05, NULL, NULL, CAST(N'2023-01-19T23:57:38.893' AS DateTime), 1, 1, 17, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[tblSupplySub] ([id], [supNo], [supAccNo], [supAccName], [supDesc], [supPrdBarcode], [supPrdNo], [supPrdName], [supPrdId], [supMsur], [supCurrency], [supQuanMain], [supPrice], [supSalePrice], [supTaxPercent], [supTaxPrice], [supDscntPercent], [supDscntAmount], [supDebit], [supCredit], [supDebitFrgn], [supCreditFrgn], [supDate], [supBrnId], [supUserId], [supStatus], [supPrdManufacture], [subQteMeter], [subHeight], [subWidth], [subNoPacks], [ExpireDate], [supOvertime], [supWorkingtime], [StoreID], [Conversion], [NumberDays], [EquipmentNo]) VALUES (9, 8, 1141010003, N'مخزون مجموعه رئيسيه', NULL, N'1', N'1-1', N'تجريبي1', 1, 1, 1, 1, 5, 7, 15, 1.05, NULL, NULL, NULL, 8.05, NULL, NULL, CAST(N'2023-01-20T17:06:47.620' AS DateTime), 1, 1, 17, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[tblSupplySub] ([id], [supNo], [supAccNo], [supAccName], [supDesc], [supPrdBarcode], [supPrdNo], [supPrdName], [supPrdId], [supMsur], [supCurrency], [supQuanMain], [supPrice], [supSalePrice], [supTaxPercent], [supTaxPrice], [supDscntPercent], [supDscntAmount], [supDebit], [supCredit], [supDebitFrgn], [supCreditFrgn], [supDate], [supBrnId], [supUserId], [supStatus], [supPrdManufacture], [subQteMeter], [subHeight], [subWidth], [subNoPacks], [ExpireDate], [supOvertime], [supWorkingtime], [StoreID], [Conversion], [NumberDays], [EquipmentNo]) VALUES (10, 9, 1141010003, N'مخزون مجموعه رئيسيه', NULL, N'1', N'1-1', N'تجريبي1', 1, 1, 1, 1, 5, 7, 15, 1.05, NULL, NULL, NULL, 8.05, NULL, NULL, CAST(N'2023-01-20T17:10:58.823' AS DateTime), 1, 1, 17, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblSupplySub] OFF
SET IDENTITY_INSERT [dbo].[tblTaxAccounts] ON 

INSERT [dbo].[tblTaxAccounts] ([taxId], [taxAccNo], [taxAccName], [taxStatus]) VALUES (1, 21023001, N'ضريبة القيمة المضافة مبيعات ومشتريات', 4)
INSERT [dbo].[tblTaxAccounts] ([taxId], [taxAccNo], [taxAccName], [taxStatus]) VALUES (2, 21023001, N'ضريبة القيمة المضافة مبيعات ومشتريات', 5)
INSERT [dbo].[tblTaxAccounts] ([taxId], [taxAccNo], [taxAccName], [taxStatus]) VALUES (3, 21023002, N'ضريبة القيمة المضافة للقيود', 1)
INSERT [dbo].[tblTaxAccounts] ([taxId], [taxAccNo], [taxAccName], [taxStatus]) VALUES (4, 21023002, N'ضريبة القيمة المضافة للقيود', 2)
INSERT [dbo].[tblTaxAccounts] ([taxId], [taxAccNo], [taxAccName], [taxStatus]) VALUES (5, 21023002, N'ضريبة القيمة المضافة للقيود', 3)
SET IDENTITY_INSERT [dbo].[tblTaxAccounts] OFF
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([id], [userName], [userPass], [PrinterName]) VALUES (1, N'admin', N'1', NULL)
SET IDENTITY_INSERT [dbo].[tblUser] OFF
SET IDENTITY_INSERT [dbo].[tblUserControl] ON 

INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (1, 3, N'barButtonItemAccount', N'الدليل المحاسبي', N'Chart of Accounts')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (2, 4, N'barButtonItemCurrency', N'العملات', N'Currencies')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (3, 5, N'barButtonItemBox', N'الصناديق', N'Boxes')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (4, 6, N'barButtonItemBank', N'البنوك', N'Banks')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (5, 7, N'barButtonItemCustomer', N'العملاء', N'Customers')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (6, 8, N'barButtonItemSupplier', N'الموردين', N'Suppliers')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (7, 9, N'barButtonItemAccountOpening', N'الأرصدة الإفتتاحية', N'Opening Balances')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (8, 10, N'barButtonItemEmployee', N'الموظفين', N'Employees')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (9, 11, N'barButtonItemEmployeeVocher', N'مرتبات الموظفين', N'Employees Salaries')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (10, 12, N'barButtonItemEntry', N'القيود اليومية', N'Daily Entry')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (11, 13, N'barButtonItemEntryVocher', N'سندات الصرف', N'Payment Voucher')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (12, 14, N'barButtonItemEntryRecipt', N'سندات القبض', N'Receipt Voucher')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (13, 15, N'barButtonItemEntryTarhel', N'السندات المرحلة', N'Phased Entry Vochers')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (15, 17, N'barButtonItemStore', N'المخازن', N'Stores')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (16, 21, N'barButtonItemProductQuantity', N'جرد المخازن', N'Product Inventory')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (17, 22, N'barButtonItemPurchase', N'المشتريات', N'Purchases')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (18, 23, N'barButtonItemPurchaseRtrn', N'مردود المشتريات', N'Purchases Return')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (19, 24, N'barButtonItemPurchaseAll', N'فواتير المشتريات المرحلة', N'Phased Purchase Invoices')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (20, 25, N'barButtonItemSale', N'المبيعات', N'Sales')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (21, 26, N'barButtonItemSaleRtrn', N'مردود المبيعات', N'Sales Return')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (22, 27, N'barButtonItemSaleAll', N'فواتير المبيعات المرحلة', N'Phased Sales Invoices')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (23, 31, N'barButtonItemTaxDeclaration', N'الإقرار الضريبي', N'Tax Declaration')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (24, 2, N'barButtonItemUserRIght', N'المستخدمين', N'Users')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (25, 1, N'barButtonItemBranches', N'الفروع', N'Branches')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (26, 18, N'bbiStoreProducts', N'تخزين الاصناف', N'Store Products')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (27, 20, N'bbiStoreProductsData', N'بيانات الأصناف', N'Products Data')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (28, 19, N'bbiStockTrans', N'النحويل المخزني', N'Product Transfer')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (29, 35, N'barMenuReports', N'إدارة التقارير', N'Reports Management')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (30, 32, N'barButtonItemFinancialYear', N'السنة المالية', N'Financial Year')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (31, 33, N'barButtonItemDefaultSettings', N'الإعدادات الإفتراضيه', N'Default Settings')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (32, 34, N'barButtonItemControlPanel', N'لوحة التحكم', N'Control Panel')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (33, 28, N'barButtonItemOrderVoucher', N'طلبات الصرف', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (34, 29, N'barButtonItemOrderExecute', N'طلبات التنفيذ', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (35, 30, N'barButtonItemOrderReceipt', N'طلبات التسليم', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (36, 0, N'barMenuAccounts', N'إدارة الحسابات', N'Accounts Management')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (37, 43, N'barButtonItemAccountsBalance', N'أرصدة الحسابات', N'Accounts Balances')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (38, 0, N'barMenuEmployees', N'إدارة الموظفين', N'Employees Management')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (39, 0, N'barMenuEntry', N'إدارة القيود', N'Entries Management')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (40, 16, N'barButtonItemEntryAll', N'الحركة اليومية', N'Daily Track')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (41, 0, N'barMenuStore', N'إدارة المخازن', N'Store Management')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (42, 0, N'barMenuPurchases', N'إدارة المشتريات', N'Purchases Management')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (43, 0, N'barMenuSales', N'إدارة المبيعات', N'Sales Management')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (44, 0, N'barMenuTaxDeclaration', N'إدارة الضرائب', N'Tax Management')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (45, 0, N'barButtonItemRprtPurchase', N'تقرير المشتريات', N'Purchases Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (46, 0, N'barButtonItemRprtSale', N'تقرير المبيعات', N'Sales Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (47, 0, N'barButtonItemRprtStore', N'تقرير المخازن', N'Store Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (48, 0, N'barButtonItemRprtProduct', N'تقرير حركة الأصناف', N'Products Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (49, 0, N'barButtonItemRprtAccountBill', N'تقرير كشف الحسابات', N'Account Balance Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (50, 0, N'barButtonItemRprtTrailBalance', N'تقرير ميزان المراجعه', N'Trail Balance Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (51, 0, N'barButtonItemRprtBalanceSheet', N'تقرير الميزانية العمومية', N'Balance Sheet Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (52, 0, N'barButtonItemRprtProfitLoss', N'تقرير حساب الأرباح والخسائر', N'Profit Loss Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (53, 0, N'barButtonItemRprtEmpSalAll', N'تقرير مرتبات الموظفين', N'Employees Payroll Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (54, 0, N'barButtonItemRprtEmpSal', N'تقرير مرتبات الموظفين التفصيلي', N'Detail Employee Payroll Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (55, 0, N'barButtonItemRprtTaxDeclaration', N'تقرير الإقرار الضريبي', N'Tax Declaration Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (56, 0, N'barButtonItemRprtDailyEntry', N'تقرير الحركة اليومية', N'Daily Entry Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (57, 0, N'barMenuSystemMangment', N'إدارة النظام', N'System Management')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (58, 0, N'barButtonItemRprtSuppliers', N'تقرير الموردين', N'Suppliers Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (59, 0, N'barButtonItemRprtSaleDetail', N'تقرير المبيعات التفصيليه', N'Sales Detail Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (60, 0, N'barButtonItemRprtSupplierInvoice', N'تقرير فواتير الموردين', N'Supplier Invoice Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (61, 0, N'barButtonItemRprtCustomerInvoice', N'تقرير فواتير العملاء', N'Customer Invoice Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (62, 0, N'barButtonItemRprtCustomerBalance', N'تقرير رصيد العملاء التفصيلي', N'Customer Balance Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (63, 0, N'barButtonItemRprtCustomersBalance', N'تقرير أرصدة العملاء', N'Customers Balance Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (64, 0, N'barButtonItemRprtSupplierBalance', N'تقرير رصيد الموردين', N'Supplier Balance Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (65, 0, N'barButtonItemRprtSuppliersBalance', N'تقرير أرصدة الموردين', N'Suppliers Balance Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (66, 0, N'bsiRprtSales', N'تقرير المبيعات', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (67, 0, N'bsiRprtCustomers', N'تقرير العملاء', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (68, 0, N'bsiRprtSuppliers', N'تقرير الموردين', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (69, 0, N'bsiRprtStore', N'تقرير المخازن', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (70, 0, N'bsiRprtEmployees', N'تقرير الموظفين', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (71, 0, N'barButtonItemRprtProductData', N'تقرير بيانات الأصناف', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (72, 0, N'barSubItemNavigation', N'Navigation', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (73, 0, N'skinDropDownButtonItem1', N'Office 2019 Colorful', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (74, 0, N'skinPaletteRibbonGalleryBarItem1', N'skinPaletteRibbonGalleryBarItem1', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (75, 54, N'barButtonItemSaleDel', N'فواتير المبيعات المحذوفه', N'Sales Deleted Invoices')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (76, 55, N'barButtonItemSaleRtrnDel', N'فواتير مردود المبيعات المحذوفه', N'Sales Return Deleted Invoices')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (77, 52, N'barButtonItemPurchaseDel', N'فواتير المشتريات المحذوفه', N'Purchse Deleted Invoices')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (78, 53, N'barButtonItemPurchaseRtrnDel', N'فواتير مردود المشتريات المحذوفه', N'Purchse Return Deleted Invoices')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (79, 0, N'barButtonItemRprtSaleGroup', N'تقرير مبيعات المجموعات المخزنية', N'Sales Group Store Report')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (80, 0, N'bsiRprtDailyEntry', N'تقرير الحركة اليومية', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (81, 0, N'barButtonItemRprtDailyEntryDetail', N'تقرير الحركة اليومية التفصيلي', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (82, 0, N'btnUCmain', N'btnUCmain', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (83, 0, N'barMenuOrders', N'إدارة الطلبات', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (84, 0, N'barButtonItemRprtOrders', N'تقرير فواتير الطلبات', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (85, 0, N'barButtonItemRprtCustomerDailyEntry', N'تقرير فواتير العملاء التفصيلي', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (86, 0, N'btnCalculater', N'btnCalculater', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (87, 44, N'barButtonItemEmpVchrTip', N'إكراميات الموظفين', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (88, 46, N'barButtonItemEmoVchrPhased', N'سندات الموظفين المرحله', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (89, 45, N'barButtonItemEmpVchrOvrTm', N'إضافي مرتبات الموظفين', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (90, 0, N'barButtonItemRprtEmpOvrTm', N'تقرير إضافي مرتبات الموظفين', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (91, 0, N'barButtonItemRprtEmpVchrTip', N'تقرير إكراميات الموظفين', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (92, 37, N'barButtonItemPrdExpirate', N'تاريخ إنتهاء الأصناف', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (93, 48, N'barButtonItemPrdExpirateQuan', N'الأصناف التالفه', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (94, 0, N'bsiRprtEntries', N'تقرير السندات', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (95, 0, N'barButtonItemRprtEntryReceipt', N'تقرير سندات القبض', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (96, 0, N'barButtonItemRprtEntryVoucher', N'تقرير سندات الصرف', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (97, 0, N'barButtonItemRprtProductdQuanPr', N'تقرير كمية الأصناف المتوفرة', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (98, 0, N'barButtonItemRprtPrdQuanOpn', N'تقرير رصيد اللإفتتاحي للأصناف', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (99, 39, N'barButtonItemRepresentative', N'المندوبين', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (100, 0, N'barButtonItemRprtStoreProducts', N'تقرير جرد المخازن', NULL)
GO
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (101, 57, N'barButtonItemRprtAdminReport', N'المراقبه الاداريه', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (102, 0, N'barButtonItem_SalesReportWithTax', N'الكشف الضريبي للمبيعات', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (103, 0, N'barButtonItem_PurchaseReportWithTax', N'الكشف الضريبي للمشتريات', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (104, 0, N'barButtonItem1', N'الخط', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (105, 38, N'barButtonItemDefaultAccount', N'الحسابات الإفتراضية', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (106, 0, N'barButtonItemRprtSaleCashier', N'تقرير المبيعات كاشير', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (107, 0, N'barButtonItemRprtGeneralLedger', N'تقرير الأستاذ العام', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (108, 0, N'barButtonItem11', N'تقرير جرد الاصناف', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (109, 0, N'barSubItemStoreInventory', N'جرد المخازن', N'Store Inventory')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (110, 49, N'barButtonItemInvStoreManual', N'الجرد اليدوي', N'Manual store inventory')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (111, 50, N'barButtonItemInvStoreDirect', N'الجرد الفوري', N'Direct store inventory')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (112, 51, N'barButtonItemInvStoreSettlement', N'التسوية المخزنيه', N'Settlement store inventory')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (113, 0, N'barButtonItemRprtSaleGroupRoll', N'تقرير مبيعات المجموعات المخزنية رول', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (114, 56, N'barButtonItemPurchaseOrders', N'الطلبيات', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (115, 0, N'btnUCnotifications', N'الإشعارات', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (116, 47, N'barButtonItemPrdQuanTracking', N'كمية حركة الأصناف', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (117, 0, N'barButtonItemRprtPrdQuanTracking', N'تقرير كمية حركة الأصناف', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (118, 36, N'barButtonItemSalePriceOffer', N'فواتير عروض الأسعار', N'Sales Price Offers')
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (119, 0, N'barButtonItemRprtSaleGroupWithout', N'تقرير مبيعات ', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (120, 0, N'barButtonItemRprtSuppliersBalanceFy', N'تقرير أرصدة الموردين خلال الفتره الماليه ', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (121, 0, N'barButtonItemRprtCustomersBalanceFy', N'تقرير أرصدة العملاء خلال الفتره الماليه ', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (122, 0, N'barButtonItemRprtSaleUserWithout', N'تقرير مبيعات المستخدمين', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (123, 0, N'barButtonItemRprtProductdQuanAvPr', N'تقرير كمية الاصناف المتوفره 2', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (124, 0, N'barButtonItemRprtAllSale', N'تقرير اجمالي المبيعات ', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (125, 0, N'barButtonItemRprtProdMove', N'تقرير حركة الاصناف في المخازن', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (126, 0, N'barButtonItemRprtManob', N'تقرير عمولة مندوب (اجمالى الفواتير)', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (127, 0, N'barButtonItem12', N'عروض الاصناف', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (128, 0, N'barButtonItemRprtCoupon', N'تقرير فواتير قسيمة الخصم', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (129, 58, N'barButtonItemFixedAsset', N'الأصول الثابتة', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (130, 0, N'barButtonItemRprtManobProduct', N'تقرير عمولة مندوب (اجمالى اصناف)', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (131, 40, N'barButtonOpenBoxDaily', N'فتح يومية صندوق', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (132, 41, N'barButtonCloseBoxDaily', N'اغلاق يومية صندوق', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (133, 42, N'barButtonReviewBoxDaily', N'مراجعة يومية صندوق', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (134, 0, N'barButReportAllSale', N'تقرير المبيعات', NULL)
INSERT [dbo].[tblUserControl] ([ucId], [ucNo], [ucName], [ucCaption], [ucCaptionEn]) VALUES (135, 0, N'btnRefreshAllData', N'تحديث البيانات', NULL)
SET IDENTITY_INSERT [dbo].[tblUserControl] OFF
SET IDENTITY_INSERT [dbo].[tblUserRole] ON 

INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (2, 3, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (3, 4, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (4, 5, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (5, 6, 2)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (7, 2, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (8, 8, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (107, 108, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (207, 208, 2)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (307, 308, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (308, 309, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (309, 310, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (310, 311, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (311, 312, 2)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (312, 313, 2)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (313, 314, 2)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (411, 413, 2)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (511, 513, 2)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (512, 515, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (612, 614, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (712, 714, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (713, 715, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (812, 814, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (912, 914, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (913, 915, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (914, 916, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (915, 917, 1)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (916, 918, 106)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (917, 714, 106)
INSERT [dbo].[tblUserRole] ([urId], [fkUserId], [fkRoleId]) VALUES (918, 8, 106)
SET IDENTITY_INSERT [dbo].[tblUserRole] OFF
/****** Object:  Index [tblAccountBank_bankNoUnique]    Script Date: 20/01/2023 11:08:01 PM ******/
ALTER TABLE [dbo].[tblAccountBank] ADD  CONSTRAINT [tblAccountBank_bankNoUnique] UNIQUE NONCLUSTERED 
(
	[bankNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [tblAccountBox_boxNoUnique]    Script Date: 20/01/2023 11:08:01 PM ******/
ALTER TABLE [dbo].[tblAccountBox] ADD  CONSTRAINT [tblAccountBox_boxNoUnique] UNIQUE NONCLUSTERED 
(
	[boxNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cashingEmp] ADD  CONSTRAINT [DF_cashingEmp_entCurrency]  DEFAULT ((1)) FOR [entCurrency]
GO
ALTER TABLE [dbo].[cashingEmp] ADD  CONSTRAINT [DF_cashingEmp_entStatus]  DEFAULT ((1)) FOR [entStatus]
GO
ALTER TABLE [dbo].[DrawerPeriods] ADD  CONSTRAINT [DF__DrawerPer__Branc__1C873BEC]  DEFAULT ((1)) FOR [BranchID]
GO
ALTER TABLE [dbo].[InventoryBalanceing] ADD  CONSTRAINT [DF__Inventory__Total__1EA48E88]  DEFAULT ((0)) FOR [TotalShortageValueSale]
GO
ALTER TABLE [dbo].[InventoryBalanceing] ADD  CONSTRAINT [DF__Inventory__Total__1F98B2C1]  DEFAULT ((0)) FOR [TotalSurplusValueSale]
GO
ALTER TABLE [dbo].[InventoryBalanceing] ADD  CONSTRAINT [DF__Inventory__NetPr__208CD6FA]  DEFAULT ((0)) FOR [NetProfitOrLosesSale]
GO
ALTER TABLE [dbo].[InventoryBalancingDetails] ADD  CONSTRAINT [DF__InventoryB__Cost__2180FB33]  DEFAULT ((0)) FOR [Cost]
GO
ALTER TABLE [dbo].[InventoryBalancingDetails] ADD  CONSTRAINT [DF__Inventory__Total__22751F6C]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[tblAccount] ADD  CONSTRAINT [DF_tblAccount_accCurrency]  DEFAULT ((1)) FOR [accCurrency]
GO
ALTER TABLE [dbo].[tblAccount] ADD  CONSTRAINT [DF_tblAccount_accBrnId]  DEFAULT ((0)) FOR [accBrnId]
GO
ALTER TABLE [dbo].[tblAccount] ADD  CONSTRAINT [DF_tblAccount_accStatus]  DEFAULT ((1)) FOR [accStatus]
GO
ALTER TABLE [dbo].[tblAsset] ADD  CONSTRAINT [DF_tblAsset_asEntNo]  DEFAULT ((0)) FOR [asEntNo]
GO
ALTER TABLE [dbo].[tblCustomers] ADD  CONSTRAINT [DF_tblCustomers_custStatus]  DEFAULT ((1)) FOR [custStatus]
GO
ALTER TABLE [dbo].[tblDefaultAccount] ADD  CONSTRAINT [DF_tblDefaultAccount_dfltBrnId]  DEFAULT ((0)) FOR [dfltBrnId]
GO
ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF_tblEmployee_empStatus_1]  DEFAULT ((1)) FOR [empStatus]
GO
ALTER TABLE [dbo].[tblEntryMain] ADD  CONSTRAINT [DF_tblEntryMain_entCurrency]  DEFAULT ((1)) FOR [entCurrency]
GO
ALTER TABLE [dbo].[tblEntryMain] ADD  CONSTRAINT [DF_tblEntryMain_entStatus]  DEFAULT ((1)) FOR [entStatus]
GO
ALTER TABLE [dbo].[tblEntrySub] ADD  CONSTRAINT [DF_tblEntrySub_entStatus]  DEFAULT ((1)) FOR [entStatus]
GO
ALTER TABLE [dbo].[tblFinancialYear] ADD  CONSTRAINT [DF_tblFinancialYear_fyIsNewYear]  DEFAULT ((0)) FOR [fyIsNewYear]
GO
ALTER TABLE [dbo].[tblInvStoreSub] ADD  CONSTRAINT [DF_tblInvStoreSub_invPriceTotal]  DEFAULT ((0)) FOR [invPriceTotal]
GO
ALTER TABLE [dbo].[tblInvStoreSub] ADD  CONSTRAINT [DF_tblInvStoreSub_invSalePrice]  DEFAULT ((0)) FOR [invSalePrice]
GO
ALTER TABLE [dbo].[tblInvStoreSub] ADD  CONSTRAINT [DF_tblInvStoreSub_invSalePriceTotal]  DEFAULT ((0)) FOR [invSalePriceTotal]
GO
ALTER TABLE [dbo].[tblPrdExpirateQuan] ADD  CONSTRAINT [DF_tblPrdExpirateQuan_expStrid]  DEFAULT ((1)) FOR [expStrid]
GO
ALTER TABLE [dbo].[tblPrdexpirateQuanMain] ADD  CONSTRAINT [DF_tblPrdexpirateQuanMain_expStrid]  DEFAULT ((1)) FOR [expMainStrid]
GO
ALTER TABLE [dbo].[tblPrdPriceMeasurment] ADD  CONSTRAINT [DF_tblPrdPriceMeasurment_ppmConversion]  DEFAULT ((1)) FOR [ppmConversion]
GO
ALTER TABLE [dbo].[tblPrdPriceMeasurment] ADD  CONSTRAINT [DF_tblPrdPriceMeasurment_ppmWeight]  DEFAULT ((0)) FOR [ppmWeight]
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_prdSaleTax]  DEFAULT ((0)) FOR [prdSaleTax]
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_prdStatus]  DEFAULT ((1)) FOR [prdStatus]
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_ReorderLevel]  DEFAULT ((0)) FOR [ReorderLevel]
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_MaxLevel]  DEFAULT ((0)) FOR [MaxLevel]
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_prdPurchaseTax]  DEFAULT ((0)) FOR [prdPurchaseTax]
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_Suspended]  DEFAULT ((0)) FOR [Suspended]
GO
ALTER TABLE [dbo].[tblProductPriceOffers] ADD  CONSTRAINT [DF_tblProductPriceOffers_State]  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[tblProductQtyOpn] ADD  CONSTRAINT [DF_tblProductQtyOpn_qtyStrId]  DEFAULT ((1)) FOR [qtyStrId]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_supplyA4CustomRprt]  DEFAULT ((0)) FOR [supplyA4CustomRprt]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_supplyCashierCustomRprt]  DEFAULT ((0)) FOR [supplyCashierCustomRprt]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_teReportVocherCustom]  DEFAULT ((0)) FOR [teReportVocherCustom]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_teReportReciptCustom]  DEFAULT ((0)) FOR [teReportReciptCustom]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_teReportEntryCustom]  DEFAULT ((0)) FOR [teReportEntryCustom]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_showRprtPurchaseHeader]  DEFAULT ((1)) FOR [showRprtPurchaseHeader]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_showRprtSaleHeader]  DEFAULT ((1)) FOR [showRprtSaleHeader]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_rprtOrderA4CustomRpt]  DEFAULT ((0)) FOR [rprtOrderA4CustomRpt]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_supplyRetuA4CustomRprt]  DEFAULT ((0)) FOR [supplyRetuA4CustomRprt]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_rprtSupplyCustomType]  DEFAULT ((1)) FOR [rprtSupplyCustomType]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting1_IsInvoiceRound]  DEFAULT ((0)) FOR [IsInvoiceRound]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting1_showPrdQtyMssg]  DEFAULT ((1)) FOR [showPrdQtyMssg]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting1_PayPartInvoValue]  DEFAULT ((0)) FOR [PayPartInvoValue]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting1_isSendToECR]  DEFAULT ((0)) FOR [isSendToECR]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting1_GroupProductsInInvoices]  DEFAULT ((1)) FOR [GroupProductsInInvoices]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting1_PrintAfterSave]  DEFAULT ((1)) FOR [defaultPrintOnSave]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting1_ShowPrintMssg]  DEFAULT ((0)) FOR [ShowPrintMssg]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting1_GroupProductWeightInInvoices]  DEFAULT ((0)) FOR [GroupWeightProdInInvoices]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting1_ShowResetMssg]  DEFAULT ((0)) FOR [ShowResetMssg]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_defaultSalePriceFloar]  DEFAULT ((1)) FOR [defaultSalePriceFloar]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_defaultBox]  DEFAULT ((0)) FOR [defaultBox]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_defaultBank]  DEFAULT ((1)) FOR [defaultBank]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_AllowSaveInvoInBeforeDate]  DEFAULT ((0)) FOR [AllowSaveInvoInBeforeDate]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_printA4]  DEFAULT ((4)) FOR [printA4]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_defaultStrId]  DEFAULT ((1)) FOR [defaultStrId]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_ReadFormScaleBarcode]  DEFAULT ((1)) FOR [ReadFormScaleBarcode]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_BarcodeLength]  DEFAULT ((13)) FOR [BarcodeLength]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_ScaleBarcodePrefix]  DEFAULT ((99)) FOR [ScaleBarcodePrefix]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_ProductCodeLength]  DEFAULT ((5)) FOR [ProductCodeLength]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_ValueCodeLength]  DEFAULT ((6)) FOR [ValueCodeLength]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_ReadMode]  DEFAULT ((1)) FOR [ReadMode]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_IgnoreCheckDigit]  DEFAULT ((1)) FOR [IgnoreCheckDigit]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_DivideValueBy]  DEFAULT ((100)) FOR [DivideValueBy]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_prdPriceTax]  DEFAULT ((0)) FOR [prdPriceTax]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_supPrdLastPrice]  DEFAULT ((0)) FOR [supPrdLastPrice]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_tsDefaultSalePriceAndBuy]  DEFAULT ((1)) FOR [tsDefaultSalePriceAndBuy]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_autoSupplyTarhel]  DEFAULT ((0)) FOR [autoSupplyTarhel]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_ShowlayoutControlCarData]  DEFAULT ((0)) FOR [ShowlayoutControlCarData]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_TaxReadMode]  DEFAULT ((1)) FOR [TaxReadMode]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_InvType]  DEFAULT ((1)) FOR [InvType]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_dfltAccLevel]  DEFAULT ((6)) FOR [dfltAccLevel]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_BranchID]  DEFAULT ((1)) FOR [BranchID]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_ordersPrintPreview]  DEFAULT ((1)) FOR [ordersPrintPreview]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_ordersShowPrintMssg]  DEFAULT ((1)) FOR [ordersShowPrintMssg]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_CalcTaxBeforDiscount]  DEFAULT ((1)) FOR [CalcTaxAfterDiscount]
GO
ALTER TABLE [dbo].[tblSetting] ADD  CONSTRAINT [DF_tblSetting_AutoBarcode]  DEFAULT ((1)) FOR [AutoBarcode]
GO
ALTER TABLE [dbo].[tblSupplyMain] ADD  CONSTRAINT [DF_tblSupplyMain_supStatus]  DEFAULT ((1)) FOR [supStatus]
GO
ALTER TABLE [dbo].[tblSupplyMain] ADD  CONSTRAINT [DF__tblSupply__SendT__706A2341]  DEFAULT ((0)) FOR [SendToserver]
GO
ALTER TABLE [dbo].[tblSupplyMain] ADD  CONSTRAINT [DF__tblSupply__IsDel__715E477A]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[tblSupplyMain] ADD  CONSTRAINT [DF__tblSupply__paidC__73468FEC]  DEFAULT ((0)) FOR [paidCash]
GO
ALTER TABLE [dbo].[tblSupplyMain] ADD  CONSTRAINT [DF__tblSupply__remin__743AB425]  DEFAULT ((0)) FOR [remin]
GO
ALTER TABLE [dbo].[tblSupplyMain] ADD  CONSTRAINT [DF_tblSupplyMain_EnterDate]  DEFAULT (getdate()) FOR [EnterDate]
GO
ALTER TABLE [dbo].[tblSupplySub] ADD  CONSTRAINT [DF_tblSupplySub_supStatus]  DEFAULT ((1)) FOR [supStatus]
GO
ALTER TABLE [dbo].[tblSupplySub] ADD  CONSTRAINT [DF__tblSupply__subQt__752ED85E]  DEFAULT ((0)) FOR [subQteMeter]
GO
ALTER TABLE [dbo].[tblSupplySub] ADD  CONSTRAINT [DF__tblSupply__subHe__7622FC97]  DEFAULT ((0)) FOR [subHeight]
GO
ALTER TABLE [dbo].[tblSupplySub] ADD  CONSTRAINT [DF__tblSupply__subWi__771720D0]  DEFAULT ((0)) FOR [subWidth]
GO
ALTER TABLE [dbo].[tblSupplySub] ADD  CONSTRAINT [DF_tblSupplySub_Conversion]  DEFAULT ((1)) FOR [Conversion]
GO
/****** Object:  StoredProcedure [dbo].[AddCustDataToAccFromPos]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddCustDataToAccFromPos] 
            @No int  OUTPUT
		   ,@AccNo bigint OUTPUT
           ,@ID int
           ,@Name nvarchar(max) 
           ,@PhnNo nvarchar(max) 
           ,@Country nvarchar(max) 
           ,@City nvarchar(max) 
           ,@Address nvarchar(max) 
           ,@Email nvarchar(max) 
           ,@CellingCredit bigint 
           ,@Currency tinyint 
           ,@SalePrice tinyint 
           ,@TaxNo nvarchar(max) 
           ,@BrnId smallint 
           ,@Status tinyint 
           ,@NameEn nvarchar(max) 
           ,@CountryEn nvarchar(max) 
           ,@CityEn nvarchar(max) 
           ,@AddressEn nvarchar(max) 
           ,@CommercialRegister nvarchar(max) 
           ,@PostalCode nvarchar(max) 
           ,@BankId smallint 
           ,@AddNo nvarchar(max) 
           ,@BuildingNo nvarchar(max) 
           ,@AnotherID nvarchar(max) 
           ,@District nvarchar(max) 
           ,@DistrictEn nvarchar(max) 
as 
declare @AccParent bigint
begin
if (@No=0)
begin
------الحصول على رقم الحساب الرئيسي للعملاء 
select @AccParent=accNo from tblAccount where id=(select dflAccNo from tblDefaultAccount where dflStatus=1 and dfltBrnId=@BrnId) 
if @AccParent is not null ------ اذا كان رقم الحساب الرئيسي للعملاء موجود 
begin
select @No=MAX(custNo)+1 from tblCustomers where custBrnId=@BrnId------تهيئة رقم عميل جديد 

select @AccNo=isnull(MAX(accNo),@AccParent*10000)+1 from tblAccount where accParent=@AccParent ------تهيئة رقم حساب جديد للعميل  
------اضافة حساب جديد للعميل  
INSERT INTO [dbo].[tblAccount] ([accNo],[accName],[accCat],[accParent],[accLevel],[accType],[accCurrency],[accBrnId],[accStatus])
                        VALUES (@accNo,@Name,1,@AccParent,6,2,@Currency,@BrnId,1)
							end
------اضافة العميل  
INSERT INTO [dbo].[tblCustomers]
           (--ID,
		    [custNo]
           ,[custAccNo],custAccName
           ,[custName]
           ,[custPhnNo]
           ,[custCountry]
           ,[custCity]
           ,[custAddress]
           ,[custEmail]
           ,[custCellingCredit]
           ,[custCurrency]
           ,[custSalePrice]
           ,[custTaxNo]
           ,[custBrnId]
           ,[custStatus]
           ,[custNameEn]
           ,[custCountryEn]
           ,[custCityEn]
           ,[custAddressEn]
           ,[CommercialRegister]
           ,[PostalCode]
           ,[cusBankId]
           ,[cusAddNo]
           ,[cusBuildingNo]
           ,[cusAnotherID]
           ,[cusDistrict]
           ,[cusDistrictEn])
     VALUES
           (@No,@AccNo,@Name,@Name,@PhnNo,@Country,@City,@Address,@Email,@CellingCredit,@Currency,@SalePrice,@TaxNo,@BrnId,@Status,@NameEn,@CountryEn,@CityEn  
,@AddressEn,@CommercialRegister,@PostalCode,@BankId,@AddNo,@BuildingNo,@AnotherID,@District,@DistrictEn  )
end
end
GO
/****** Object:  StoredProcedure [dbo].[AddInvoiceDataToAccFromPos]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddInvoiceDataToAccFromPos] 
            @supNo int OUTPUT
           ,@supAccNo bigint OUTPUT
           ,@supAccName nvarchar(80) 
           ,@supRefNo nvarchar(max) 
           ,@supDesc nvarchar(100) 
           ,@supTotal float
           ,@supTotalFrgn float
           ,@supTaxPercent tinyint 
           ,@supTaxPrice float
           ,@supCurrency tinyint 
           ,@supDscntPercent float 
           ,@supDscntAmount float
           ,@supBankId smallint 
           ,@supBankAmount float 
           ,@supCurrencyChng smallint 
           ,@supCustSplId int 
           ,@supDate smalldatetime 
           ,@supIsCash tinyint 
           ,@supEqfal tinyint 
           ,@supStrId smallint 
           ,@supUserId smallint 
           ,@supBrnId smallint 
           ,@supStatus tinyint 
           ,@supDscntAmountٌRound decimal
           ,@CarType nvarchar(100) 
           ,@PlateNumber nvarchar(100) 
           ,@CounterNumber nvarchar(100) 
           ,@SendToserver bit 
           ,@IsDelete bit 
           ,@paidCash float 
           ,@remin float 
           ,@supBoxId smallint 
           ,@PoNumber nvarchar(150) 
           ,@Notes nvarchar(max) 
           ,@DueDate datetime 
           ,@EnterDate datetime 
as 
begin
if(@supIsCash=1)
begin 
select @supAccNo=boxAccNo,@supAccName=boxName from tblAccountBox where id=@supBoxId
end
else if(@supIsCash=2)
begin 
select @supAccNo=custAccNo,@supAccName=custAccName from tblCustomers where id=(select top 1 id from tblCustomers where custNo=@supCustSplId and custBrnId=@supBrnId)
end
------اضافة الفاتورة  
INSERT INTO [dbo].[tblSupplyMain]
           ([supNo]
           ,[supAccNo]
           ,[supAccName]
           ,[supRefNo]
           ,[supDesc]
           ,[supTotal]
           ,[supTotalFrgn]
           ,[supTaxPercent]
           ,[supTaxPrice]
           ,[supCurrency]
           ,[supDscntPercent]
           ,[supDscntAmount]
           ,[supBankId]
           ,[supBankAmount]
           ,[supCurrencyChng]
           ,[supCustSplId]
           ,[supDate]
           ,[supIsCash]
           ,[supEqfal]
           ,[supStrId]
           ,[supUserId]
           ,[supBrnId]
           ,[supStatus]
           ,[supDscntAmountٌRound]
           ,[CarType]
           ,[PlateNumber]
           ,[CounterNumber]
           ,[SendToserver]
           ,[IsDelete]
           ,[paidCash]
           ,[remin]
           ,[supBoxId]
           ,[PoNumber]
           ,[Notes]
           ,[DueDate]
           ,[EnterDate])
     VALUES
           (@supNo 
           ,@supAccNo  
           ,@supAccName 
           ,@supRefNo 
           ,@supDesc   
           ,@supTotal
           ,@supTotalFrgn 
           ,@supTaxPercent  
           ,@supTaxPrice
           ,@supCurrency  
           ,@supDscntPercent  
           ,@supDscntAmount 
           ,@supBankId  
           ,@supBankAmount
           ,@supCurrencyChng  
           ,(select top 1 id from tblCustomers where custNo=@supCustSplId and custBrnId=@supBrnId)  
           ,@supDate  
           ,@supIsCash  
           ,@supEqfal  
           ,@supStrId  
           ,@supUserId  
           ,@supBrnId  
           ,@supStatus  
           ,@supDscntAmountٌRound
           ,@CarType   
           ,@PlateNumber   
           ,@CounterNumber   
           ,@SendToserver   
           ,@IsDelete   
           ,@paidCash  
           ,@remin        
		   ,@supBoxId  
           ,@PoNumber 
           ,@Notes
           ,@DueDate  
           ,@EnterDate)
		  set @supNo=(select SCOPE_IDENTITY())
end
GO
/****** Object:  StoredProcedure [dbo].[CalculatePrdQuan]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[CalculatePrdQuan]
as
begin
UPDATE [dbo].[tblProductQunatity]
   SET [prdQuantity] =(
        isnull((select sum(isnull(supQuanMain,0)*Conversion) from tblSupplySub WHERE supPrdId=prdId and StoreID=prdStrId and supStatus in(3,7,11,12)),0)-
        isnull((select sum(isnull(supQuanMain,0)*Conversion) from tblSupplySub WHERE supPrdId=prdId and StoreID=prdStrId and supStatus in(4,8, 9,10)),0)-
        isnull((select sum(expQuan*(dbo.GetppmConversion(expPrdMsurId))) from tblPrdExpirateQuan WHERE expPrdId=prdId and expStrId=prdStrId),0)+
		isnull((select sum(isnull(qtyQuantity,0)*(dbo.GetppmConversion(qtyPrdMsurId))) from tblProductQtyOpn WHERE qtyPrdId=prdId and qtyStrId=prdStrId),0)+
		isnull((SELECT sum(invQuanDefr*(dbo.GetppmConversion(invPrdMsurId))) FROM tblInvStoreMain as Main inner join tblInvStoreSub as Sub on Main.id=Sub.invMainId WHERE Sub.invPrdId=prdId and Main.invStrId=prdStrId),0)-
        isnull((SELECT sum(stcQuantity*(dbo.GetppmConversion(stcMsurId))) FROM tblStockTransMain as Main inner join tblStockTransSub as Sub on Main.stcId=Sub.stcMainId WHERE Sub.stcPrdId=prdId and Main.stcStrIdFrom=prdStrId),0)+
        isnull((SELECT sum(stcQuantity*(dbo.GetppmConversion(stcMsurId))) FROM tblStockTransMain as Main inner join tblStockTransSub as Sub on Main.stcId=Sub.stcMainId WHERE Sub.stcPrdId=prdId and Main.stcStrIdTo=prdStrId),0))
      ,[prdSubQuantity] =0
      ,[prdSubQuantity3] =0
end

GO
/****** Object:  StoredProcedure [dbo].[GetCustomrtWhithBalance]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCustomrtWhithBalance]
@FromDate datetime,
@ToDate datetime
as
SELECT 
       Cus.id
      ,custNo
      ,custAccNo
      ,custAccName
      ,custName
      ,custPhnNo
      ,custAddress
      ,custCellingCredit
      ,custCurrency
      ,custSalePrice
      ,custTaxNo
      ,custAddressEn
	 ,isnull((select sum(net) from tblSupplyMain as supMain where Cus.custAccNo = supMain.supAccNo 
	 and Cus.custBrnId=supMain.supBrnId and supMain.supDate between @FromDate and @ToDate and supStatus in(11,12) and IsDelete=0),0)+
	 isnull((select sum(isnull(supBankAmount,0)+isnull(paidCash,0)) from tblSupplyMain as supMain where Cus.custAccNo = supMain.supAccNo 
	 and Cus.custBrnId=supMain.supBrnId and supMain.supDate between @FromDate and @ToDate and supStatus in(4,8) and IsDelete=0),0) as SupplyCredit

	 ,isnull((select sum(net) from tblSupplyMain as supMain where Cus.custAccNo = supMain.supAccNo 
	 and Cus.custBrnId=supMain.supBrnId and supMain.supDate between @FromDate and @ToDate and supStatus in(4,8) and IsDelete=0),0) as SupplyDebit
	 ,isnull((select sum(isnull(asCredit,0)) from tblAsset where  Cus.custAccNo= tblAsset.asAccNo and tblAsset.asStatus=1 
		  and Cus.custBrnId=tblAsset.asBrnId and tblAsset.asDate between @FromDate and @ToDate),0) as AssetCredit
	 ,isnull((select sum(isnull(asDebit,0)) from tblAsset where  Cus.custAccNo= tblAsset.asAccNo and tblAsset.asStatus=1 
		  and Cus.custBrnId=tblAsset.asBrnId and tblAsset.asDate between @FromDate and @ToDate),0) as AssetDebit
	,isnull((select sum(isnull(entDebit,0)) from tblEntrySub where  Cus.custAccNo= tblEntrySub.entAccNo and tblEntrySub.entStatus in(2,5,4)
		  and Cus.custBrnId=tblEntrySub.entBrnId and tblEntrySub.entDate between @FromDate and @ToDate),0) as EntryDebit 
	 ,isnull((select sum(isnull(entCredit,0)) from tblEntrySub where  Cus.custAccNo= tblEntrySub.entAccNo and tblEntrySub.entStatus in(3,6,4)
		  and Cus.custBrnId=tblEntrySub.entBrnId and tblEntrySub.entDate between @FromDate and @ToDate),0) as EntryCredit
	FROM  dbo.tblCustomers as Cus
GO
/****** Object:  StoredProcedure [dbo].[InsBarcodeToPos]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[InsBarcodeToPos]
 @id int
,@brcNo nvarchar(50) 
,@brcPrdMsurId int
,@brcBrnId smallint 
as
begin
if isnull((select id from tblBarcode where id=@id),0)<=0
begin
SET IDENTITY_INSERT [dbo].[tblBarcode] ON
INSERT INTO [dbo].[tblBarcode]
           (id
		   ,[brcNo]
           ,[brcPrdMsurId]
           ,[brcBrnId])
     VALUES
           (@id
		   ,@brcNo 
           ,@brcPrdMsurId 
           ,@brcBrnId)
SET IDENTITY_INSERT [dbo].[tblBarcode] OFF
end
else begin
UPDATE [dbo].[tblBarcode]
   SET [brcNo] = @brcNo
      ,[brcPrdMsurId] = @brcPrdMsurId
      ,[brcBrnId] = @brcBrnId
 WHERE id=@id
end
end

GO
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[InsertProduct]
@id int,
@No nvarchar(15),
@Name nvarchar(150),
@Branchid smallint,
@state tinyint,
@GrpNo int

as
begin
if isnull((select id from tblProduct where id=@id),0)<=0
begin
SET IDENTITY_INSERT [dbo].[tblProduct] ON
INSERT INTO [dbo].[tblProduct]
           (id,[prdNo]
           ,[prdName]
           ,[prdBrnId]
           ,[prdStatus] ,[prdGrpNo]   
		   ,[prdSaleTax] ,[prdPriceTax] ,[ReorderLevel]
           ,[MaxLevel]
           ,[prdPurchaseTax])
     VALUES (@id,@No,@Name,@Branchid,@state,@GrpNo
	 ,0,1,0,0,0)
SET IDENTITY_INSERT [dbo].[tblProduct] OFF
end
	end

GO
/****** Object:  StoredProcedure [dbo].[InsGroupToPos]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[InsGroupToPos]
 @id int
,@grpNo int 
,@grpName nvarchar(50) 
,@grpAccNo bigint 
,@grpCurrency tinyint 
,@grpSalesAccNo bigint 
,@grpCostAccNo bigint 
,@grpDscntAccNo bigint 
,@grpSalesRtrnAccNo bigint 
,@grpCostRtrnAccNo bigint 
,@grpBrnId smallint 
,@grpStatus tinyint 
,@grpPurchaseAccNo bigint 
,@grpPurchaseRtrnAccNo bigint 
as
begin
if isnull((select id from tblGroupStr where id=@id),0)<=0
begin
SET IDENTITY_INSERT [dbo].[tblGroupStr] ON
INSERT INTO [dbo].[tblGroupStr]
           (id
		   ,[grpNo]
           ,[grpName]
           ,[grpAccNo]
           ,[grpCurrency]
           ,[grpSalesAccNo]
           ,[grpCostAccNo]
           ,[grpDscntAccNo]
           ,[grpSalesRtrnAccNo]
           ,[grpCostRtrnAccNo]
           ,[grpBrnId]
           ,[grpStatus]
           ,[grpPurchaseAccNo]
           ,[grpPurchaseRtrnAccNo])
     VALUES
           (@id,
		    @grpNo
           ,@grpName
           ,@grpAccNo  
           ,@grpCurrency  
           ,@grpSalesAccNo  
           ,@grpCostAccNo  
           ,@grpDscntAccNo  
           ,@grpSalesRtrnAccNo  
           ,@grpCostRtrnAccNo  
           ,@grpBrnId  
           ,@grpStatus  
           ,@grpPurchaseAccNo  
           ,@grpPurchaseRtrnAccNo)
SET IDENTITY_INSERT [dbo].[tblGroupStr] OFF
end
else
begin
UPDATE [dbo].[tblGroupStr]
   SET [grpNo] = @grpNo
      ,[grpName] = @grpName
      ,[grpAccNo] = @grpAccNo
      ,[grpCurrency] = @grpCurrency
      ,[grpSalesAccNo] = @grpSalesAccNo
      ,[grpCostAccNo] = @grpCostAccNo
      ,[grpDscntAccNo] = @grpDscntAccNo
      ,[grpSalesRtrnAccNo] = @grpSalesRtrnAccNo
      ,[grpCostRtrnAccNo] = @grpCostRtrnAccNo
      ,[grpBrnId] = @grpBrnId
      ,[grpStatus] = @grpStatus
      ,[grpPurchaseAccNo] = @grpPurchaseAccNo
      ,[grpPurchaseRtrnAccNo] = @grpPurchaseRtrnAccNo
 WHERE id=@id
end
end

GO
/****** Object:  StoredProcedure [dbo].[InsProductToPos]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[InsProductToPos]
 @id int
,@prdNo nvarchar(15) 
,@prdName nvarchar(150) 
,@prdNameEng varchar(50) 
,@prdGrpNo int 
,@prdDesc nvarchar(150) 
,@prdSaleTax bit 
,@prdBrnId smallint 
,@prdStatus tinyint 
,@prdPriceTax bit 
,@ReorderLevel float 
,@MaxLevel float 
,@prdPurchaseTax bit 
,@Suspended bit 
as
begin
if isnull((select id from tblProduct where id=@id),0)<=0
begin
SET IDENTITY_INSERT [dbo].[tblProduct] ON
INSERT INTO [dbo].[tblProduct]
           (id,[prdNo]
           ,[prdName]
           ,[prdNameEng]
           ,[prdGrpNo]
           ,[prdDesc]
           ,[prdSaleTax]
           ,[prdBrnId]
           ,[prdStatus]
           ,[prdPriceTax]
           ,[ReorderLevel]
           ,[MaxLevel]
           ,[prdPurchaseTax]
           ,[Suspended])
     VALUES
           (@id,@prdNo 
           ,@prdName 
           ,@prdNameEng 
           ,@prdGrpNo  
           ,@prdDesc 
           ,@prdSaleTax  
           ,@prdBrnId  
           ,@prdStatus  
           ,@prdPriceTax  
           ,@ReorderLevel  
           ,@MaxLevel  
           ,@prdPurchaseTax  
           ,@Suspended)
SET IDENTITY_INSERT [dbo].[tblProduct] OFF
end
else begin
UPDATE [dbo].[tblProduct]
   SET [prdNo] = @prdNo
      ,[prdName] = @prdName
      ,[prdNameEng] = @prdNameEng
      ,[prdGrpNo] = @prdGrpNo
      ,[prdDesc] = @prdDesc
      ,[prdSaleTax] = @prdSaleTax
      ,[prdBrnId] = @prdBrnId
      ,[prdStatus] = @prdStatus
      ,[prdPriceTax] = @prdPriceTax
      ,[ReorderLevel] = @ReorderLevel
      ,[MaxLevel] = @MaxLevel
      ,[prdPurchaseTax] = @prdPurchaseTax
      ,[Suspended] = @Suspended
 WHERE id=@id
end
end

GO
/****** Object:  StoredProcedure [dbo].[InsProMeasurmentToPos]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsProMeasurmentToPos]
 @ppmId int
,@ppmMsurName nvarchar(30) 
           ,@ppmPrice float 
           ,@ppmSalePrice float 
           ,@ppmMinSalePrice float 
           ,@ppmRetailPrice float 
           ,@ppmBatchPrice float 
           ,@ppmBarcode1 nvarchar(30) 
           ,@ppmBarcode2 nvarchar(30) 
           ,@ppmBarcode3 nvarchar(30) 
           ,@ppmConversion float 
           ,@ppmDefault bit 
           ,@ppmPrdId int 
           ,@ppmWeight bit 
           ,@ppmBrnId smallint 
           ,@ppmStatus tinyint 
           ,@ppmManufacture bit
as
begin
if isnull((select ppmId from tblPrdPriceMeasurment where ppmId=@ppmId),0)<=0
begin
SET IDENTITY_INSERT [dbo].[tblPrdPriceMeasurment] ON
INSERT INTO [dbo].[tblPrdPriceMeasurment]
           (ppmId,[ppmMsurName]
           ,[ppmPrice]
           ,[ppmSalePrice]
           ,[ppmMinSalePrice]
           ,[ppmRetailPrice]
           ,[ppmBatchPrice]
           ,[ppmBarcode1]
           ,[ppmBarcode2]
           ,[ppmBarcode3]
           ,[ppmConversion]
           ,[ppmDefault]
           ,[ppmPrdId]
           ,[ppmWeight]
           ,[ppmBrnId]
           ,[ppmStatus]
           ,[ppmManufacture])
     VALUES
           (@ppmId,@ppmMsurName  
           ,@ppmPrice  
           ,@ppmSalePrice  
           ,@ppmMinSalePrice  
           ,@ppmRetailPrice  
           ,@ppmBatchPrice  
           ,@ppmBarcode1  
           ,@ppmBarcode2  
           ,@ppmBarcode3  
           ,@ppmConversion  
           ,@ppmDefault  
           ,@ppmPrdId  
           ,@ppmWeight  
           ,@ppmBrnId  
           ,@ppmStatus  
           ,@ppmManufacture)
SET IDENTITY_INSERT [dbo].[tblPrdPriceMeasurment] OFF
end
else
begin
UPDATE [dbo].[tblPrdPriceMeasurment]
   SET [ppmMsurName] =  @ppmMsurName 
      ,[ppmPrice] =  @ppmPrice 
      ,[ppmSalePrice] =  @ppmSalePrice 
      ,[ppmMinSalePrice] =  @ppmMinSalePrice 
      ,[ppmRetailPrice] =  @ppmRetailPrice 
      ,[ppmBatchPrice] =  @ppmBatchPrice 
      ,[ppmBarcode1] =  @ppmBarcode1 
      ,[ppmBarcode2] =  @ppmBarcode2 
      ,[ppmBarcode3] =  @ppmBarcode3 
      ,[ppmConversion] =  @ppmConversion 
      ,[ppmDefault] =  @ppmDefault 
      ,[ppmPrdId] =  @ppmPrdId
      ,[ppmWeight] =  @ppmWeight
      ,[ppmBrnId] =  @ppmBrnId
      ,[ppmStatus] =  @ppmStatus
      ,[ppmManufacture] =  @ppmManufacture
 WHERE ppmId=@ppmId
end
end

GO
/****** Object:  StoredProcedure [dbo].[InsProPriceToPos]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[InsProPriceToPos]
 @prId int
,@prPrdId int 
           ,@pr1 float 
           ,@pr2 float 
           ,@pr3 float 
           ,@prQuantity1 float 
           ,@prQuantity2 float 
           ,@prQuantity3 float 
           ,@prdBrnId smallint 
           ,@prStatus bit 
as
begin
if isnull((select prId from tblPrdPriceQuan where prId=@prId),0)<=0
begin
SET IDENTITY_INSERT [dbo].[tblPrdPriceQuan] ON
INSERT INTO [dbo].[tblPrdPriceQuan]
           (prId,[prPrdId]
           ,[pr1]
           ,[pr2]
           ,[pr3]
           ,[prQuantity1]
           ,[prQuantity2]
           ,[prQuantity3]
           ,[prdBrnId]
           ,[prStatus])
     VALUES
           (@prId,@prPrdId
           ,@pr1
           ,@pr2 
           ,@pr3 
           ,@prQuantity1  
           ,@prQuantity2  
           ,@prQuantity3  
           ,@prdBrnId  
           ,@prStatus)
SET IDENTITY_INSERT [dbo].[tblPrdPriceQuan] OFF
end
else
begin
UPDATE [dbo].[tblPrdPriceQuan]
   SET [prPrdId] = @prPrdId
      ,[pr1] = @pr1
      ,[pr2] = @pr2
      ,[pr3] = @pr3
      ,[prQuantity1] = @prQuantity1
      ,[prQuantity2] = @prQuantity2
      ,[prQuantity3] = @prQuantity3
      ,[prdBrnId] = @prdBrnId
      ,[prStatus] = @prStatus
 WHERE prId=@prId
end
end

GO
/****** Object:  StoredProcedure [dbo].[InsProQuanToPos]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[InsProQuanToPos]
 @id int
,@prdId int
,@prdQuantity float
,@prdSubQuantity float
,@prdSubQuantity3 float
,@prdStrId smallint
,@prdBrnId smallint
,@prdStatus tinyint
as
begin
if isnull((select id from tblProductQunatity where id=@id),0)<=0
begin
SET IDENTITY_INSERT [dbo].[tblProductQunatity] ON
INSERT INTO [dbo].[tblProductQunatity]
           (id,
		    [prdId]
           ,[prdQuantity]
           ,[prdSubQuantity]
           ,[prdSubQuantity3]
           ,[prdStrId]
           ,[prdBrnId]
           ,[prdStatus])
     VALUES
           (@id,
		    @prdId
           ,@prdQuantity 
           ,@prdSubQuantity 
           ,@prdSubQuantity3 
           ,@prdStrId 
           ,@prdBrnId 
           ,@prdStatus)
SET IDENTITY_INSERT [dbo].[tblProductQunatity] OFF
end
else
begin
UPDATE [dbo].[tblProductQunatity]
   SET [prdId] = @prdId
      ,[prdQuantity] = @prdQuantity
      ,[prdSubQuantity] = @prdSubQuantity
      ,[prdSubQuantity3] = @prdSubQuantity3
      ,[prdStrId] = @prdStrId
      ,[prdBrnId] = @prdBrnId
      ,[prdStatus] = @prdStatus
 WHERE id=@id
end
end

GO
/****** Object:  StoredProcedure [dbo].[InsStoreToPos]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[InsStoreToPos]
 @id smallint
,@strNo smallint
,@strName nvarchar(50) 
,@strPhnNo varchar(15) 
,@strBrnId smallint 
,@strStatus tinyint 
as
begin
if isnull((select id from tblStore where id=@id),0)<=0
begin
SET IDENTITY_INSERT [dbo].[tblStore] ON
INSERT INTO [dbo].[tblStore]
           (id
		   ,[strNo]
           ,[strName]
           ,[strPhnNo]
           ,[strBrnId]
           ,[strStatus])
     VALUES
           (@id
		   ,@strNo 
           ,@strName 
           ,@strPhnNo 
           ,@strBrnId  
           ,@strStatus  )
SET IDENTITY_INSERT [dbo].[tblStore] OFF
end
else begin
UPDATE [dbo].[tblStore]
   SET [strNo] = @strNo
      ,[strName] = @strName
      ,[strPhnNo] = @strPhnNo
      ,[strBrnId] = @strBrnId
      ,[strStatus] = @strStatus
 WHERE id=@id
end
end

GO
/****** Object:  StoredProcedure [dbo].[RepMoveProduct]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RepMoveProduct]
@FromDate datetime,
@ToDate datetime
as
exec CalculatePrdQuan
SELECT 
      tblProduct.prdNo as prdNo
	 ,tblProduct.id as ProductID
	 ,tblProduct.prdName as prdName
	 ,tblStore.id as StoreId
	 ,tblStore.strNo as strNo
	 ,tblStore.strName as strName
	 ,(select top 1 ppmPrice from tblPrdPriceMeasurment where ppmPrdId=tblProduct.id and ppmStatus=1)as ppmPrice
	 ,(select top 1 ppmSalePrice from tblPrdPriceMeasurment where ppmPrdId=tblProduct.id and ppmStatus=1) as ppmSalePrice
	 ,tblProduct.prdGrpNo as GroupID
	 ,tblGroupStr.grpNo as grpNo
	 ,tblGroupStr.grpName as grpName
	 ,isnull(Quan.prdQuantity,0) as prdQuantity
	 ,(isnull((select sum(isnull(qtyQuantity,0)*(dbo.GetppmConversion(qtyPrdMsurId))) from tblProductQtyOpn WHERE qtyPrdId=prdId and qtyStrId=prdStrId),0)+
	   isnull((select sum(isnull(supQuanMain,0)*Conversion) from tblSupplySub WHERE supPrdId=prdId and StoreID=prdStrId and supStatus in(3,7,11,12) and supDate<@FromDate),0)-
	   isnull((select sum(isnull(supQuanMain,0)*Conversion) from tblSupplySub WHERE supPrdId=prdId and StoreID=prdStrId and supStatus in(4,8, 9,10) and supDate<@FromDate),0)-
	   isnull((select sum(expQuan*(dbo.GetppmConversion(expPrdMsurId))) from tblPrdExpirateQuan WHERE expPrdId=prdId and expStrId=prdStrId and expDate<@FromDate),0)+
	   isnull((SELECT sum(invQuanDefr*(dbo.GetppmConversion(invPrdMsurId))) FROM tblInvStoreMain as Main inner join tblInvStoreSub as Sub on Main.id=Sub.invMainId WHERE Sub.invPrdId=prdId and Main.invStrId=prdStrId and Main.invDate<@FromDate),0)-
       isnull((SELECT sum(stcQuantity*(dbo.GetppmConversion(stcMsurId))) FROM tblStockTransMain as Main inner join tblStockTransSub as Sub on Main.stcId=Sub.stcMainId WHERE Sub.stcPrdId=prdId and Main.stcStrIdFrom=prdStrId and Sub.stcDate<@FromDate),0)+
       isnull((SELECT sum(stcQuantity*(dbo.GetppmConversion(stcMsurId))) FROM tblStockTransMain as Main inner join tblStockTransSub as Sub on Main.stcId=Sub.stcMainId WHERE Sub.stcPrdId=prdId and Main.stcStrIdTo=prdStrId and Sub.stcDate<@FromDate),0)) as QuFrist
	
	  ,isnull((select sum(isnull(supQuanMain,0)*Conversion) from tblSupplySub WHERE supPrdId=prdId and StoreID=prdStrId and supStatus in(3,7) and (supDate between @FromDate and @ToDate)),0) as QuPur
	  ,isnull((select sum(isnull(supQuanMain,0)*Conversion) from tblSupplySub WHERE supPrdId=prdId and StoreID=prdStrId and supStatus in(11,12) and (supDate between @FromDate and @ToDate)),0) as QuSaleRet
	  ,isnull((select sum(isnull(supQuanMain,0)*Conversion) from tblSupplySub WHERE supPrdId=prdId and StoreID=prdStrId and supStatus in(9,10) and (supDate between @FromDate and @ToDate)),0) as QuPurRet
	  ,isnull((select sum(isnull(supQuanMain,0)*Conversion) from tblSupplySub WHERE supPrdId=prdId and StoreID=prdStrId and supStatus in(4,8) and (supDate between @FromDate and @ToDate)),0) as QuSale
	  ,isnull((select sum(expQuan*(dbo.GetppmConversion(expPrdMsurId))) from tblPrdExpirateQuan WHERE expPrdId=prdId and expStrId=prdStrId and (expDate between @FromDate and @ToDate)),0) as ExpirateQuan
	  ,isnull((SELECT sum(invQuanDefr*(dbo.GetppmConversion(invPrdMsurId))) FROM tblInvStoreMain as Main inner join tblInvStoreSub as Sub on Main.id=Sub.invMainId WHERE Sub.invPrdId=prdId and Main.invStrId=prdStrId and (Main.invDate between @FromDate and @ToDate)),0) as QuInvStore
      ,isnull((SELECT sum(stcQuantity*(dbo.GetppmConversion(stcMsurId))) FROM tblStockTransMain as Main inner join tblStockTransSub as Sub on Main.stcId=Sub.stcMainId WHERE Sub.stcPrdId=prdId and Main.stcStrIdFrom=prdStrId and (Sub.stcDate between @FromDate and @ToDate)),0) as QStrFrom
      ,isnull((SELECT sum(stcQuantity*(dbo.GetppmConversion(stcMsurId))) FROM tblStockTransMain as Main inner join tblStockTransSub as Sub on Main.stcId=Sub.stcMainId WHERE Sub.stcPrdId=prdId and Main.stcStrIdTo=prdStrId and (Sub.stcDate between @FromDate and @ToDate)),0) as QStrTo
	FROM  dbo.tblProductQunatity as Quan
          INNER JOIN dbo.tblProduct ON Quan.prdId = dbo.tblProduct.id
		  INNER JOIN dbo.tblGroupStr ON tblGroupStr.id = dbo.tblProduct.prdGrpNo
		  inner join tblStore on tblStore.id = Quan.prdStrId
		 -- where prdQuantity>0 and prdQuantity is not null
	
GO
/****** Object:  StoredProcedure [dbo].[ResetPrdQuan]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ResetPrdQuan]
as
begin
UPDATE [dbo].[tblProductQunatity]
   SET [prdQuantity] =0,[prdSubQuantity] =0,[prdSubQuantity3] =0
end
GO
/****** Object:  StoredProcedure [dbo].[StorQuantityProduct]    Script Date: 20/01/2023 11:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[StorQuantityProduct]
@FromDate datetime,
@ToDate datetime
as
SELECT 
 tblProduct.id as ProId
	 ,tblPrdPriceMeasurment.ppmId as ppmId
	 ,max(tblProduct.prdGrpNo) as prdGrpNo
	  ,sum(isnull(supQuanMain,0)) as supQuanMain
	  ,tblStore.id as StoreId
	   ,(isnull((select sum(isnull(qtyQuantity,0)) from tblProductQtyOpn where qtyPrdId=tblProduct.id 
	   and qtyPrdMsurId=tblPrdPriceMeasurment.ppmId and qtyStrId=tblStore.id),0)+
	   isnull((SELECT	 sum(isnull(supQuanMain,0))
	   FROM dbo.tblSupplyMain INNER JOIN    dbo.tblSupplySub ON dbo.tblSupplyMain.id = dbo.tblSupplySub.supNo
					 where tblSupplySub.supDate < @FromDate and  tblSupplySub.supPrdId=tblProduct.id and 
					 tblSupplySub.supMsur=tblPrdPriceMeasurment.ppmId and  tblSupplyMain.supStrId=tblStore.id and
					 (tblSupplySub.supStatus=3 or tblSupplySub.supStatus=7 or tblSupplySub.supStatus=11 or tblSupplySub.supStatus=12)),0))
					 - (isnull((select sum(isnull(expQuan,0)) from tblPrdExpirateQuan where expPrdId=tblProduct.id and expPrdMsurId=tblPrdPriceMeasurment.ppmId and expStrid=tblStore.id and (expDate < @FromDate)),0)
					 +isnull((SELECT	 sum(isnull(supQuanMain,0))
	   FROM  dbo.tblSupplyMain INNER JOIN   dbo.tblSupplySub ON dbo.tblSupplyMain.id = dbo.tblSupplySub.supNo
					 where tblSupplySub.supDate < @FromDate and  tblSupplySub.supPrdId=tblProduct.id and 
					 tblSupplySub.supMsur=tblPrdPriceMeasurment.ppmId and  tblSupplyMain.supStrId=tblStore.id and
					 (tblSupplySub.supStatus=4 or tblSupplySub.supStatus=8 or tblSupplySub.supStatus=9 or tblSupplySub.supStatus=10)),0))  as QuFrist
	  ,isnull((select sum(isnull(stcQuantity,0)) from tblStockTransMain 
	  inner join tblStockTransSub on tblStockTransMain.stcId=tblStockTransSub.stcMainId
	  where stcStrIdTo=tblStore.id and stcPrdId=tblProduct.id and stcMsurId=tblPrdPriceMeasurment.ppmId),0) as QStrIdTo
	    ,isnull((select sum(isnull(stcQuantity,0)) from tblStockTransMain 
	  inner join tblStockTransSub on tblStockTransMain.stcId=tblStockTransSub.stcMainId
	  where stcStrIdFrom=tblStore.id and stcPrdId=tblProduct.id and stcMsurId=tblPrdPriceMeasurment.ppmId),0) as QStrIdFrom
	,tblSupplySub.supStatus as supStatus
	FROM  dbo.tblStore INNER JOIN
                      dbo.tblSupplyMain ON dbo.tblStore.id = dbo.tblSupplyMain.supStrId INNER JOIN
                      dbo.tblSupplySub ON dbo.tblSupplyMain.id = dbo.tblSupplySub.supNo INNER JOIN
                      dbo.tblProduct ON dbo.tblSupplySub.supPrdId = dbo.tblProduct.id
					  inner join tblPrdPriceMeasurment on tblSupplySub.supMsur=tblPrdPriceMeasurment.ppmId
					where tblSupplySub.supDate between @FromDate and @ToDate
					  group by  tblProduct.id,tblPrdPriceMeasurment.ppmId,tblStore.id,tblSupplySub.supStatus
	                  order by tblProduct.id


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاريخ انتهاء التامين' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblEmployee', @level2type=N'COLUMN',@level2name=N'expirationInsurance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاريخ انتهاء الاقامة' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblEmployee', @level2type=N'COLUMN',@level2name=N'expirationResidence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblBranch"
            Begin Extent = 
               Top = 216
               Left = 350
               Bottom = 371
               Right = 538
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblCurrency"
            Begin Extent = 
               Top = 142
               Left = 574
               Bottom = 297
               Right = 762
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblUser"
            Begin Extent = 
               Top = 6
               Left = 755
               Bottom = 139
               Right = 943
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DrawerPeriods"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 293
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 6
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 17
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DrawerRev'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'      NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DrawerRev'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DrawerRev'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "DepreciationAccount"
            Begin Extent = 
               Top = 183
               Left = 135
               Bottom = 316
               Right = 358
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FixedAssets"
            Begin Extent = 
               Top = 6
               Left = 525
               Bottom = 320
               Right = 786
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "AssetAccount"
            Begin Extent = 
               Top = 22
               Left = 196
               Bottom = 155
               Right = 384
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblCurrency"
            Begin Extent = 
               Top = 6
               Left = 824
               Bottom = 161
               Right = 1012
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
      ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_FixedAssets'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_FixedAssets'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_FixedAssets'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblRepresentative"
            Begin Extent = 
               Top = 6
               Left = 321
               Bottom = 161
               Right = 509
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblCurrency"
            Begin Extent = 
               Top = 6
               Left = 547
               Bottom = 161
               Right = 735
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblSupplyMain"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 161
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_profit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_profit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "RepCommission"
            Begin Extent = 
               Top = 17
               Left = 64
               Bottom = 317
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RepCommissionDetails"
            Begin Extent = 
               Top = 37
               Left = 352
               Bottom = 267
               Right = 545
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblProduct"
            Begin Extent = 
               Top = 61
               Left = 710
               Bottom = 303
               Right = 899
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblStore"
            Begin Extent = 
               Top = 97
               Left = 964
               Bottom = 252
               Right = 1152
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblRepresentative"
            Begin Extent = 
               Top = 62
               Left = 1201
               Bottom = 217
               Right = 1389
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 3495
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_repComm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'        Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_repComm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_repComm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[14] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblSupplyMain"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 282
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 21
         End
         Begin Table = "tblSupplySub"
            Begin Extent = 
               Top = 66
               Left = 365
               Bottom = 331
               Right = 582
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblCurrency"
            Begin Extent = 
               Top = 54
               Left = 757
               Bottom = 209
               Right = 945
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RepCommissionDetails"
            Begin Extent = 
               Top = 118
               Left = 1170
               Bottom = 344
               Right = 1366
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 3105
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2745
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_repCommReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'        Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_repCommReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_repCommReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblPrdPriceMeasurment"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 296
               Right = 220
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblProduct"
            Begin Extent = 
               Top = 20
               Left = 369
               Bottom = 255
               Right = 546
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "tblGroupStr"
            Begin Extent = 
               Top = 112
               Left = 900
               Bottom = 277
               Right = 1141
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2760
         Alias = 900
         Table = 2160
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_unit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_unit'
GO
USE [master]
GO
ALTER DATABASE [SahabSoft-FinalCost] SET  READ_WRITE 
GO
