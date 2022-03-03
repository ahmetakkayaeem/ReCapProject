USE [master]
GO
/****** Object:  Database [CarRental]    Script Date: 3/1/2022 5:42:44 PM ******/
CREATE DATABASE [CarRental]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRental', FILENAME = N'C:\Users\Fatih Akkaya\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\CarRental.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRental_log', FILENAME = N'C:\Users\Fatih Akkaya\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\CarRental.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CarRental] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRental].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRental] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [CarRental] SET ANSI_NULLS ON 
GO
ALTER DATABASE [CarRental] SET ANSI_PADDING ON 
GO
ALTER DATABASE [CarRental] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [CarRental] SET ARITHABORT ON 
GO
ALTER DATABASE [CarRental] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRental] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRental] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRental] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRental] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [CarRental] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [CarRental] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRental] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [CarRental] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRental] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRental] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRental] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRental] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRental] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRental] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRental] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRental] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRental] SET RECOVERY FULL 
GO
ALTER DATABASE [CarRental] SET  MULTI_USER 
GO
ALTER DATABASE [CarRental] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRental] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRental] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRental] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRental] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarRental] SET QUERY_STORE = OFF
GO
USE [CarRental]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CarRental]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 3/1/2022 5:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 3/1/2022 5:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 3/1/2022 5:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NULL,
	[ColorId] [int] NULL,
	[ModelYear] [int] NOT NULL,
	[DailyPrice] [money] NULL,
	[Description] [char](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 3/1/2022 5:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 3/1/2022 5:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CompanyName] [varchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 3/1/2022 5:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[RentDate] [date] NOT NULL,
	[ReturnDate] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/1/2022 5:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1, N'Renault             ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2, N'Ford                ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (3, N'Toyota              ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (4, N'BMW                 ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (5, N'Mercedes Benz       ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (6, N'Wolfswagen          ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (7, N'Seat                ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (8, N'Mini Cooper         ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1002, N'Skoda               ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1003, N'AstonMartin         ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1004, N'Citroen             ')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2002, N'Lexus')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2003, N'Hyundai')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2004, N'Dodge')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2005, N'Acura')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2006, N'Subaru')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2007, N'Nissan')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2008, N'Pontiac')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2009, N'Mazda')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2010, N'Suzuki')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2011, N'Land Rover')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2012, N'Volvo')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2013, N'Kia')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2014, N'Cadillac')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2015, N'Fiat             ')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 

INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1, 5, N'2b1f101d-fee9-4460-8ddb-26d85e75a9cb.jpg', CAST(N'2022-02-26T16:54:01.323' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2, 5, N'44844a6c-c9f9-44c4-8410-ae54a8782c92.jpg', CAST(N'2022-02-26T17:33:00.437' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (3, 5, N'aa89ea92-2a0a-4885-9111-700d6fb24b23.jpg', CAST(N'2022-02-26T17:33:18.653' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (4, 5, N'd6da03fa-93d9-4a58-bcf1-0e8d41158d09.jpg', CAST(N'2022-02-26T17:33:20.483' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5, 5, N'b60685a7-5d87-4fae-b30f-7e51e34458e8.jpg', CAST(N'2022-02-26T17:33:21.950' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (6, 5, N'43ed2cd7-3293-4855-a136-74535d09118c.jpg', CAST(N'2022-02-26T17:34:42.170' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (7, 2, N'2bd779ad-1a1c-4cf0-a11b-7fceb805127e.jpg', CAST(N'2022-02-26T17:45:35.420' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (8, 2, N'd9c915b6-458f-4f80-9f7c-5565eff4420e.jpg', CAST(N'2022-02-26T17:45:47.080' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (9, 2, N'13bd99b4-4ea1-42d6-be7c-8bb88e8b8aa5.jpg', CAST(N'2022-02-26T17:45:58.920' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (10, 2, N'06c3d9d3-ba5c-4439-a67a-97dbe3aadfb8.jpg', CAST(N'2022-02-26T17:46:09.060' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (11, 2, N'48f63d84-876d-4583-8237-a3066c376db8.jpg', CAST(N'2022-02-26T17:47:01.283' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1002, 6, N'45c69078-719f-42bb-b81b-8ebddd042463.jpeg', CAST(N'2022-02-28T15:25:28.130' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1003, 6, N'80431ef8-6b83-4a9b-8062-b97b067e403e.jpeg', CAST(N'2022-02-28T14:05:16.447' AS DateTime))
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (1, 1, 1, 2012, 475.0000, N'Renault Megane                          ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2, 2, 1, 2014, 395.0000, N'Ford Fiesta                             ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3, 3, 2, 2017, 505.0000, N'Toyota Corolla  Hatchback               ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (5, 4, 2, 2019, 895.0000, N'BMW 3 Series 316i Comfort               ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (6, 5, 3, 2020, 1000.0000, N'Mercedes CLA 180d                       ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (7, 6, 4, 2022, 1200.0000, N'Wolfswagen                              ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2002, 1, 2, 2016, 520.0000, N'Renault Kadjar                          ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2003, 1, 4, 2019, 450.0000, N'Renault Talisman                        ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2005, 2, 3, 2022, 250.0000, N'Ford Focus                              ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2010, 5, 2, 2007, 300.0000, N'Mercedes B180 1.4                       ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2011, 3, 1, 2021, 650.0000, N'Toyota Auris                            ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2013, 4, 5, 2017, 780.0000, N'BMW 5 Series 520i Executive             ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3011, 1002, 4, 2018, 800.0000, N'Skoda Rapid                             ')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3012, 3, 4, 2015, 400.0000, N'Toyota Auris                            ')
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1, N'Black               ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2, N'White               ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (3, N'Silver              ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (4, N'Gray                ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (5, N'Red                 ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (6, N'Blue                ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (7, N'Beige               ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (8, N'Gold                ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (9, N'Yellow              ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1002, N'Orange              ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1003, N'Purple              ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1004, N'Brown               ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1005, N'Forest Green        ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1006, N'Passion Purple      ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1007, N'Phantom Black       ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1008, N'Static Gray         ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1009, N'Titanium Silver     ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1010, N'Copperhead          ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1011, N'Pink                ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1012, N'Apple Green         ')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2002, N'Fuscia')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2003, N'Indigo')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (1, 1, N'Sanogullari')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (4, 2, N'DEF Mühendislik')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (8, 3, N'KareDekoratif As.')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (10, 4, N'Turkish Technic')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (11, 2, N'Günes Sigorta')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1, 1, 1, CAST(N'2022-01-10' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (2, 2, 4, CAST(N'2022-02-22' AS Date), CAST(N'2022-02-23' AS Date))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (3, 3, 8, CAST(N'2021-11-13' AS Date), CAST(N'2022-01-15' AS Date))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (5, 6, 10, CAST(N'2021-11-13' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (6, 2005, 11, CAST(N'2021-12-17' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1002, 3011, 11, CAST(N'2022-02-05' AS Date), CAST(N'2022-02-12' AS Date))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1003, 3011, 11, CAST(N'2022-02-05' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (1, N'Mehmet', N'Altuntas', N'mehmeta@hotmail.com', N'54323sa')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (2, N'Emre', N'Yilmaz', N'emreyilmaz@gmail.comm', N'123ey')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (3, N'Can', N'Koç', N'cankoço@gmail.comm', N'12298m3ey')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (4, N'Mahmut', N'kasim', N'mahmudh@gmail.comm', N'423324a')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (5, N'Tarkan', N'Arman', N'tarkanarman@hotmail.com', N'zali23sa')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (6, N'Fatih', N'Korkmaz', N'korkmazfatih123@hotmail.com', N'kork3sa')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CarImages]  WITH CHECK ADD  CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[CarImages] CHECK CONSTRAINT [FK_CarImages_Cars]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([BrandId])
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([ColorId])
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Users]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK__Rentals__Custome__49C3F6B7] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK__Rentals__Custome__49C3F6B7]
GO
USE [master]
GO
ALTER DATABASE [CarRental] SET  READ_WRITE 
GO
