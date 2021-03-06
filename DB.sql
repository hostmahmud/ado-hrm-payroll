USE [master]
GO
/****** Object:  Database [humanResourceManagement_DB]    Script Date: 25-May-21 01:55:03 PM ******/
CREATE DATABASE [humanResourceManagement_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'humanResourceManagement_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\humanResourceManagement_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'humanResourceManagement_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\humanResourceManagement_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [humanResourceManagement_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [humanResourceManagement_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [humanResourceManagement_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [humanResourceManagement_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [humanResourceManagement_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [humanResourceManagement_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [humanResourceManagement_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [humanResourceManagement_DB] SET  MULTI_USER 
GO
ALTER DATABASE [humanResourceManagement_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [humanResourceManagement_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [humanResourceManagement_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [humanResourceManagement_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [humanResourceManagement_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [humanResourceManagement_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'humanResourceManagement_DB', N'ON'
GO
ALTER DATABASE [humanResourceManagement_DB] SET QUERY_STORE = OFF
GO
USE [humanResourceManagement_DB]
GO
/****** Object:  Table [dbo].[tbl_admins]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_admins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](20) NOT NULL,
	[password] [varchar](60) NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_department]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](15) NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_designation]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_designation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[deptId] [int] NULL,
	[salaryAmount] [money] NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_empAllowance]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empAllowance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empId] [int] NOT NULL,
	[aOption] [varchar](20) NOT NULL,
	[aTitle] [varchar](50) NOT NULL,
	[aAmount] [money] NOT NULL,
 CONSTRAINT [PK__tbl_empA__3213E83F6622021B] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_empCommission]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empCommission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empId] [int] NULL,
	[cOption] [varchar](30) NOT NULL,
	[cTitle] [varchar](30) NOT NULL,
	[cAmount] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_empDeduction]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empDeduction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empid] [int] NOT NULL,
	[dOption] [varchar](20) NOT NULL,
	[dTitle] [varchar](30) NOT NULL,
	[dAmount] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employee]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employee](
	[id] [int] IDENTITY(101,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[fatherName] [varchar](50) NOT NULL,
	[birthDate] [datetime] NOT NULL,
	[gender] [varchar](10) NOT NULL,
	[email] [varchar](70) NOT NULL,
	[address] [varchar](100) NOT NULL,
	[city] [varchar](20) NOT NULL,
	[country] [varchar](25) NOT NULL,
	[nationalIDNo] [char](13) NOT NULL,
	[photo] [varchar](200) NOT NULL,
	[deptId] [int] NOT NULL,
	[desigID] [int] NOT NULL,
	[joinDate] [datetime] NOT NULL,
	[joinSalary] [money] NOT NULL,
	[bankAccountName] [varchar](50) NOT NULL,
	[bankAccountNumber] [varchar](20) NOT NULL,
	[bankName] [varchar](50) NOT NULL,
	[bankBranch] [varchar](30) NOT NULL,
 CONSTRAINT [PK__tbl_empl__3213E83F666049D1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employeeLeave]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employeeLeave](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empId] [int] NOT NULL,
	[leaveId] [int] NOT NULL,
	[leaveReason] [varchar](100) NOT NULL,
	[leaveDays] [int] NOT NULL,
	[fromDate] [date] NOT NULL,
	[toDate] [date] NOT NULL,
	[leaveIssueDate] [date] NOT NULL,
	[status] [nchar](10) NULL,
 CONSTRAINT [PK__tbl_empl__C2AD5A850D89C93A] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employeeStatus]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employeeStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empId] [int] NOT NULL,
	[statusId] [int] NOT NULL,
 CONSTRAINT [PK__tbl_empl__3213E83F84B1F9A3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_empPayslip]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empPayslip](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empId] [int] NOT NULL,
	[salary] [money] NOT NULL,
	[netSalary] [money] NOT NULL,
	[status] [int] NOT NULL,
	[createdAt] [date] NOT NULL,
	[paidAt] [date] NULL,
	[updatedAt] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_leaveType]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_leaveType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](15) NOT NULL,
	[DaysPerYear] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_status]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_yearlyLeave]    Script Date: 25-May-21 01:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_yearlyLeave](
	[yearlyLeaveID] [int] IDENTITY(1,1) NOT NULL,
	[designationID] [int] NULL,
	[totalLeaveDays] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[yearlyLeaveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_admins] ON 

INSERT [dbo].[tbl_admins] ([id], [username], [password], [status]) VALUES (1, N'admin', N'2251022057731868917119086224872421513662', 1)
SET IDENTITY_INSERT [dbo].[tbl_admins] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_department] ON 

INSERT [dbo].[tbl_department] ([id], [name], [status]) VALUES (1, N'IT', 1)
INSERT [dbo].[tbl_department] ([id], [name], [status]) VALUES (2, N'Administrative', 1)
SET IDENTITY_INSERT [dbo].[tbl_department] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_designation] ON 

INSERT [dbo].[tbl_designation] ([id], [name], [deptId], [salaryAmount], [status]) VALUES (1, N'Jr. Developer', 1, 30000.0000, 1)
INSERT [dbo].[tbl_designation] ([id], [name], [deptId], [salaryAmount], [status]) VALUES (2, N'Sr. Developer', 1, 50000.0000, 1)
INSERT [dbo].[tbl_designation] ([id], [name], [deptId], [salaryAmount], [status]) VALUES (3, N'Manager', 2, 50000.0000, 1)
SET IDENTITY_INSERT [dbo].[tbl_designation] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_empAllowance] ON 

INSERT [dbo].[tbl_empAllowance] ([id], [empId], [aOption], [aTitle], [aAmount]) VALUES (1, 101, N'Non Taxable', N'House rent', 3000.0000)
INSERT [dbo].[tbl_empAllowance] ([id], [empId], [aOption], [aTitle], [aAmount]) VALUES (2, 101, N'Non Taxable', N'Medical allowance', 5000.0000)
SET IDENTITY_INSERT [dbo].[tbl_empAllowance] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_empDeduction] ON 

INSERT [dbo].[tbl_empDeduction] ([id], [empid], [dOption], [dTitle], [dAmount]) VALUES (1, 101, N'Non Taxable', N'Health Insurance', 1500.0000)
SET IDENTITY_INSERT [dbo].[tbl_empDeduction] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employee] ON 

INSERT [dbo].[tbl_employee] ([id], [name], [fatherName], [birthDate], [gender], [email], [address], [city], [country], [nationalIDNo], [photo], [deptId], [desigID], [joinDate], [joinSalary], [bankAccountName], [bankAccountNumber], [bankName], [bankBranch]) VALUES (101, N'Mahmud Sabuj', N'Ali Ahmed', CAST(N'1995-11-11T00:00:00.000' AS DateTime), N'Male', N'mahmud@gmail.com', N'Panthopath', N'Dhaka', N'Bangladesh', N'1234567890123', N'\empImages\1234567890123.jpeg', 1, 1, CAST(N'2021-05-25T00:00:00.000' AS DateTime), 30000.0000, N'Mahmud Sabuj', N'123456', N'Islami Bank Bangladesh Limited', N'Dhanmondi Branch')
SET IDENTITY_INSERT [dbo].[tbl_employee] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employeeLeave] ON 

INSERT [dbo].[tbl_employeeLeave] ([id], [empId], [leaveId], [leaveReason], [leaveDays], [fromDate], [toDate], [leaveIssueDate], [status]) VALUES (1, 101, 2, N'Osusto', 5, CAST(N'2021-05-25' AS Date), CAST(N'2021-05-29' AS Date), CAST(N'2021-05-25' AS Date), N'Pending   ')
SET IDENTITY_INSERT [dbo].[tbl_employeeLeave] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employeeStatus] ON 

INSERT [dbo].[tbl_employeeStatus] ([id], [empId], [statusId]) VALUES (1, 101, 1)
SET IDENTITY_INSERT [dbo].[tbl_employeeStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_empPayslip] ON 

INSERT [dbo].[tbl_empPayslip] ([id], [empId], [salary], [netSalary], [status], [createdAt], [paidAt], [updatedAt]) VALUES (1, 101, 30000.0000, 36500.0000, 1, CAST(N'2021-05-25' AS Date), CAST(N'2021-05-25' AS Date), CAST(N'2021-05-25' AS Date))
SET IDENTITY_INSERT [dbo].[tbl_empPayslip] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_leaveType] ON 

INSERT [dbo].[tbl_leaveType] ([Id], [Name], [DaysPerYear], [Status]) VALUES (1, N'Casual leave', 10, 1)
INSERT [dbo].[tbl_leaveType] ([Id], [Name], [DaysPerYear], [Status]) VALUES (2, N'Medical leave', 15, 1)
SET IDENTITY_INSERT [dbo].[tbl_leaveType] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_status] ON 

INSERT [dbo].[tbl_status] ([id], [Name]) VALUES (1, N'Active')
INSERT [dbo].[tbl_status] ([id], [Name]) VALUES (2, N'Inactive')
INSERT [dbo].[tbl_status] ([id], [Name]) VALUES (3, N'Retired')
INSERT [dbo].[tbl_status] ([id], [Name]) VALUES (4, N'Suspended')
SET IDENTITY_INSERT [dbo].[tbl_status] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [unique_usernema]    Script Date: 25-May-21 01:55:04 PM ******/
ALTER TABLE [dbo].[tbl_admins] ADD  CONSTRAINT [unique_usernema] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tbl_empl__BFFB17753451AB56]    Script Date: 25-May-21 01:55:04 PM ******/
ALTER TABLE [dbo].[tbl_employee] ADD  CONSTRAINT [UQ__tbl_empl__BFFB17753451AB56] UNIQUE NONCLUSTERED 
(
	[nationalIDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_empl__C134C9A094033316]    Script Date: 25-May-21 01:55:04 PM ******/
ALTER TABLE [dbo].[tbl_employeeStatus] ADD  CONSTRAINT [UQ__tbl_empl__C134C9A094033316] UNIQUE NONCLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_employee] ADD  CONSTRAINT [DF__tbl_emplo__fathe__5629CD9C]  DEFAULT ('a') FOR [fatherName]
GO
ALTER TABLE [dbo].[tbl_employee] ADD  CONSTRAINT [DF__tbl_employ__city__34C8D9D1]  DEFAULT ('Dhaka') FOR [city]
GO
ALTER TABLE [dbo].[tbl_employee] ADD  CONSTRAINT [DF__tbl_emplo__photo__1CBC4616]  DEFAULT ('no-image') FOR [photo]
GO
ALTER TABLE [dbo].[tbl_employee] ADD  CONSTRAINT [DF__tbl_emplo__deptI__3A4CA8FD]  DEFAULT ((1)) FOR [deptId]
GO
ALTER TABLE [dbo].[tbl_employeeLeave] ADD  CONSTRAINT [DF__tbl_emplo__leave__4222D4EF]  DEFAULT (getdate()) FOR [leaveIssueDate]
GO
ALTER TABLE [dbo].[tbl_employeeStatus] ADD  CONSTRAINT [DF__tbl_emplo__statu__607251E5]  DEFAULT ((1)) FOR [statusId]
GO
ALTER TABLE [dbo].[tbl_leaveType] ADD  DEFAULT ((0)) FOR [DaysPerYear]
GO
ALTER TABLE [dbo].[tbl_leaveType] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[tbl_designation]  WITH CHECK ADD FOREIGN KEY([deptId])
REFERENCES [dbo].[tbl_department] ([id])
GO
ALTER TABLE [dbo].[tbl_empAllowance]  WITH CHECK ADD  CONSTRAINT [FK__tbl_empAl__empId__756D6ECB] FOREIGN KEY([empId])
REFERENCES [dbo].[tbl_employee] ([id])
GO
ALTER TABLE [dbo].[tbl_empAllowance] CHECK CONSTRAINT [FK__tbl_empAl__empId__756D6ECB]
GO
ALTER TABLE [dbo].[tbl_empCommission]  WITH CHECK ADD FOREIGN KEY([empId])
REFERENCES [dbo].[tbl_employee] ([id])
GO
ALTER TABLE [dbo].[tbl_empDeduction]  WITH CHECK ADD FOREIGN KEY([empid])
REFERENCES [dbo].[tbl_employee] ([id])
GO
ALTER TABLE [dbo].[tbl_employee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_emplo__deptI__3B40CD36] FOREIGN KEY([deptId])
REFERENCES [dbo].[tbl_department] ([id])
GO
ALTER TABLE [dbo].[tbl_employee] CHECK CONSTRAINT [FK__tbl_emplo__deptI__3B40CD36]
GO
ALTER TABLE [dbo].[tbl_employeeStatus]  WITH CHECK ADD  CONSTRAINT [FK__tbl_emplo__emplo__398D8EEE] FOREIGN KEY([empId])
REFERENCES [dbo].[tbl_employee] ([id])
GO
ALTER TABLE [dbo].[tbl_employeeStatus] CHECK CONSTRAINT [FK__tbl_emplo__emplo__398D8EEE]
GO
ALTER TABLE [dbo].[tbl_employeeStatus]  WITH CHECK ADD  CONSTRAINT [FK__tbl_emplo__statu__6166761E] FOREIGN KEY([statusId])
REFERENCES [dbo].[tbl_status] ([id])
GO
ALTER TABLE [dbo].[tbl_employeeStatus] CHECK CONSTRAINT [FK__tbl_emplo__statu__6166761E]
GO
ALTER TABLE [dbo].[tbl_empPayslip]  WITH CHECK ADD FOREIGN KEY([empId])
REFERENCES [dbo].[tbl_employee] ([id])
GO
ALTER TABLE [dbo].[tbl_yearlyLeave]  WITH CHECK ADD FOREIGN KEY([designationID])
REFERENCES [dbo].[tbl_designation] ([id])
GO
ALTER TABLE [dbo].[tbl_employee]  WITH CHECK ADD  CONSTRAINT [CK__tbl_emplo__natio__32E0915F] CHECK  (([nationalIDNo] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[tbl_employee] CHECK CONSTRAINT [CK__tbl_emplo__natio__32E0915F]
GO
ALTER TABLE [dbo].[tbl_employeeLeave]  WITH CHECK ADD  CONSTRAINT [CK__tbl_employeeLeav__5165187F] CHECK  (([toDate]>[fromDate]))
GO
ALTER TABLE [dbo].[tbl_employeeLeave] CHECK CONSTRAINT [CK__tbl_employeeLeav__5165187F]
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteAllowance]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteAllowance]
	@id int
AS
BEGIN
	delete from tbl_empAllowance where id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteDesignation]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
* Create stored procedure for DELETING data from tbl_designation table
*/

CREATE PROC [dbo].[sp_deleteDesignation]
			@id INT
AS
BEGIN
	DELETE FROM tbl_designation 
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteEmpCommission]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteEmpCommission] 
	@id int
AS
BEGIN
	delete from tbl_empCommission where id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteEmpDeduction]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteEmpDeduction] 
				@id int
AS
BEGIN
	delete from tbl_empDeduction where id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteEmployee]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_deleteEmployee]
			@employeeID INT
AS
BEGIN
	DELETE FROM tbl_employee
	WHERE id=@employeeID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteYearlyLeave]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
* Create stored procedure for DELETING data from tbl_yearlyLeave table
*/
CREATE PROC [dbo].[sp_deleteYearlyLeave]
			@designationID INT
AS
BEGIN
	DELETE FROM tbl_yearlyLeave WHERE designationID=@designationID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertDesignation]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
* Create stored procedure for INSERTING data into tbl_designation table
*/

CREATE PROC [dbo].[sp_insertDesignation]
			@name VARCHAR(20),
			@deptID INT,
			@amount MONEY,
			@status INT,
			@dTitle VARCHAR(MAX) OUTPUT
AS
BEGIN
	INSERT INTO tbl_designation VALUES(@name,@deptID,@amount,@status)
	SELECT @dTitle=(SELECT d.name FROM tbl_designation d WHERE d.id=IDENT_CURRENT('tbl_designation'))
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertEmpCommission]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertEmpCommission]
	@empid int,
	@cOption varchar(30),
	@cTitle varchar(30),
	@cAmount money
AS
BEGIN
	insert into tbl_empCommission values(@empid,@cOption,@cTitle,@cAmount)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertEmpDeduction]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertEmpDeduction]
				@empid int,
				@dOption varchar(20),
				@dTitle varchar(30),
				@dAmount money
AS
BEGIN
	insert into tbl_empDeduction values(@empid,@dOption,@dTitle,@dAmount)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertEmployeeAndStatus]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_insertEmployeeAndStatus]
			@name VARCHAR(20),
			@father VARCHAR(50),
			@dob DATETIME,
			@gender VARCHAR(10),
			@email VARCHAR(70),
			@address VARCHAR(100),
			@city VARCHAR(20),
			@country VARCHAR(25),
			@nid CHAR(13),
			@photo VARCHAR(200),
			@deptId INT,
			@desigID INT,
			@joinDate DATE,
			@joinSalary MONEY,
			@bankAccountName VARCHAR(50),
			@bankAccountNumber VARCHAR(20),
			@bankName VARCHAR(50),
			@bankBranch VARCHAR(30),
			@empId int,
			@statusid int
AS
BEGIN
	INSERT INTO tbl_employee(name,fatherName,birthDate,gender,email,address,city,country,nationalIDNo,photo,deptId,desigID,joinDate,joinSalary,bankAccountName,bankAccountNumber,bankName,bankBranch) VALUES(@name,@father,@dob,@gender,@email,@address,@city,@country,@nid,@photo,@deptId,@desigID,@joinDate,@joinSalary,@bankAccountName,@bankAccountNumber,@bankName,@bankBranch);
	INSERT INTO tbl_employeeStatus(empId,statusId) VALUES(@empId,@statusid)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertEmployeeProject]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
* Create stored procedure for INSERTING data into tbl_EmployeeProject table
*/

CREATE PROC [dbo].[sp_insertEmployeeProject]
			@employeeID INT,
			@projectID INT,
			@date DATE
AS
BEGIN
	INSERT INTO tbl_employeeProject VALUES(@employeeID,@projectID,@date)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertProjects]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
* Create stored procedure for INSERTING data into tbl_projects table
*/

CREATE PROC [dbo].[sp_insertProjects]
			@projectName VARCHAR(50),
			@cost MONEY,
			@duration INT
AS
BEGIN
	INSERT INTO tbl_projects VALUES(@projectName,@cost,@duration)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertYearlyLeave]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
* Create stored procedure for INSERTING data into tbl_yearlyLeave table
*/

CREATE PROC [dbo].[sp_insertYearlyLeave]
			@designationID INT,
			@leaveDays INT
AS
BEGIN
	INSERT INTO tbl_yearlyLeave VALUES(@designationID,@leaveDays)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_selectEmpCommission]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_selectEmpCommission]
	@empid int
AS
BEGIN
	select id,cOption 'Tax Option',cTitle 'Title',cAmount 'Amount' from tbl_empCommission 
    where empId=@empid
END
GO
/****** Object:  StoredProcedure [dbo].[sp_selectEmpDeduction]    Script Date: 25-May-21 01:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_selectEmpDeduction]
				@empid int
AS
BEGIN
	select * from tbl_empDeduction where empid=@empid
END
GO
USE [master]
GO
ALTER DATABASE [humanResourceManagement_DB] SET  READ_WRITE 
GO
