USE [UPASTITI]
GO
/****** Object:  Table [dbo].[staff]    Script Date: 02/06/2018 09:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staff]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[staff](
	[staffno] [int] NOT NULL,
	[staffname] [varchar](50) NOT NULL,
	[plantname] [varchar](50) NOT NULL,
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[samiti]    Script Date: 02/06/2018 09:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[samiti]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[samiti](
	[samitiname] [varchar](250) NOT NULL,
	[title] [varchar](250) NULL,
 CONSTRAINT [PK_samiti] PRIMARY KEY CLUSTERED 
(
	[samitiname] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[plant]    Script Date: 02/06/2018 09:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[plant]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[plant](
	[plantname] [varchar](50) NOT NULL,
	[title] [varchar](250) NULL,
 CONSTRAINT [PK_plant] PRIMARY KEY CLUSTERED 
(
	[plantname] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[movement]    Script Date: 02/06/2018 09:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[movement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[movement](
	[staffno] [int] NOT NULL,
	[moveon] [datetime] NOT NULL,
	[shiftcode] [varchar](20) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_movement_staff]    Script Date: 02/06/2018 09:18:17 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_movement_staff]') AND parent_object_id = OBJECT_ID(N'[dbo].[movement]'))
ALTER TABLE [dbo].[movement]  WITH NOCHECK ADD  CONSTRAINT [FK_movement_staff] FOREIGN KEY([staffno])
REFERENCES [dbo].[staff] ([staffno])
ON UPDATE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_movement_staff]') AND parent_object_id = OBJECT_ID(N'[dbo].[movement]'))
ALTER TABLE [dbo].[movement] CHECK CONSTRAINT [FK_movement_staff]
GO
