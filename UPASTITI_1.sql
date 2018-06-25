USE [UPASTITI]
GO
/****** Object:  Table [dbo].[samiti]    Script Date: 06/25/2018 22:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[samiti](
	[samitiname] [varchar](250) NOT NULL,
	[titile] [varchar](250) NULL,
 CONSTRAINT [PK_samiti] PRIMARY KEY CLUSTERED
(
	[samitiname] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[plant]    Script Date: 06/25/2018 22:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[plant](
	[plantname] [varchar](50) NOT NULL,
	[title] [varchar](250) NULL,
 CONSTRAINT [PK_plant] PRIMARY KEY CLUSTERED
(
	[plantname] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[contractor]    Script Date: 06/25/2018 22:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[contractor](
	[contractorname] [varchar](20) NOT NULL,
	[title] [varchar](250) NULL,
 CONSTRAINT [PK_contractor] PRIMARY KEY CLUSTERED
(
	[contractorname] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[staff]    Script Date: 06/25/2018 22:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[staff](
	[staffno] [varchar](20) NOT NULL,
	[staffname] [varchar](50) NOT NULL,
	[fathername] [varchar](50) NOT NULL,
	[plantname] [varchar](50) NOT NULL,
	[contractorname] [varchar](20) NOT NULL,
	[gender] [varchar](10) NOT NULL,
	[skilllevel] [varchar](20) NOT NULL,
	[samitiname] [varchar](250) NOT NULL,
	[status] [varchar](10) NULL,
	[createdon] [datetime] NULL,
	[lastmodifiedon] [datetime] NULL,
	[finger1] [varbinary](512) NOT NULL,
	[finger2] [varbinary](512) NOT NULL,
 CONSTRAINT [PK_staff] PRIMARY KEY CLUSTERED
(
	[staffno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[movement]    Script Date: 06/25/2018 22:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[movement](
	[staffno] [varchar](20) NOT NULL,
	[moveon] [datetime] NOT NULL,
	[shiftcode] [varchar](20) NOT NULL,
 CONSTRAINT [PK_movement] PRIMARY KEY CLUSTERED
(
	[staffno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_movement_staff]    Script Date: 06/25/2018 22:06:39 ******/
ALTER TABLE [dbo].[movement]  WITH CHECK ADD  CONSTRAINT [FK_movement_staff] FOREIGN KEY([staffno])
REFERENCES [dbo].[staff] ([staffno])
GO
ALTER TABLE [dbo].[movement] CHECK CONSTRAINT [FK_movement_staff]
GO
/****** Object:  ForeignKey [FK_staff_contractor]    Script Date: 06/25/2018 22:06:39 ******/
ALTER TABLE [dbo].[staff]  WITH CHECK ADD  CONSTRAINT [FK_staff_contractor] FOREIGN KEY([contractorname])
REFERENCES [dbo].[contractor] ([contractorname])
GO
ALTER TABLE [dbo].[staff] CHECK CONSTRAINT [FK_staff_contractor]
GO
/****** Object:  ForeignKey [FK_staff_plant]    Script Date: 06/25/2018 22:06:39 ******/
ALTER TABLE [dbo].[staff]  WITH CHECK ADD  CONSTRAINT [FK_staff_plant] FOREIGN KEY([plantname])
REFERENCES [dbo].[plant] ([plantname])
GO
ALTER TABLE [dbo].[staff] CHECK CONSTRAINT [FK_staff_plant]
GO
/****** Object:  ForeignKey [FK_staff_samiti]    Script Date: 06/25/2018 22:06:39 ******/
ALTER TABLE [dbo].[staff]  WITH CHECK ADD  CONSTRAINT [FK_staff_samiti] FOREIGN KEY([samitiname])
REFERENCES [dbo].[samiti] ([samitiname])
GO
ALTER TABLE [dbo].[staff] CHECK CONSTRAINT [FK_staff_samiti]
GO
