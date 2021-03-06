USE [StudentDb]
GO
/****** Object:  StoredProcedure [dbo].[Student_Delete]    Script Date: 7/1/2017 1:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Student_Delete] 
(
@ID BIGINT
)
AS
 
UPDATE Students
SET
IsActive = 0
WHERE Id=@ID




GO
/****** Object:  StoredProcedure [dbo].[Student_Insert]    Script Date: 7/1/2017 1:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Student_Insert]
(
	@FirstName NVARCHAR(MAX)
   ,@LASTNAME  NVARCHAR(MAX)
   ,@ADDRESS NVARCHAR(MAX)
,@IsActive Bit
 ,@Country int
   ,@City int
   ,@State int
   ,@Email NVARCHAR(MAX)
   ,@PhnNo NVARCHAR(MAX)
  , @DOB NVARCHAR(MAX)
    ,@Gender NVARCHAR(MAX)
	,@Btech Bit
	,@Bsc Bit
	,@Bca Bit
	,@Ba Bit
	,@LogoUrl NVARCHAR(MAX)
  
)
AS
INSERT INTO [dbo].[Students]
           ([FirstName]
           ,[LastName]
           ,[Address]
         ,[IsActive]
		 ,[Country]
           ,[City]
		   ,[State]
		   ,[Email]
		   ,[PhnNo]
		   ,[DOB]
		   ,[Gender]
		   ,[Btech]
		   ,[Bsc]
		   ,[Bca]
		   ,[Ba]
           )
     VALUES
          (
		  @FirstName
		  ,@LASTNAME 
		  ,@ADDRESS
		,@IsActive 
		,@Country
		  ,@City 
		  ,@State
		  ,@Email 
		  ,@PhnNo 
		  ,@DOB
		  ,@Gender
		  ,@Btech
		  ,@Bsc
		  ,@Bca 
		  ,@Ba
		  )
GO
/****** Object:  StoredProcedure [dbo].[Student_Listing]    Script Date: 7/1/2017 1:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Student_Listing] 
(
@ID BIGINT = NULL,
@FirstName nvarchar(30) = NULL,
@PageSize INT = NULL,
@CurrentPage int = NULL
)
AS
BEGIN
	
	IF @PageSize IS NULL SET @PageSize = 10
	IF @CurrentPage IS NULL SET @CurrentPage = 1

	DECLARE @FirstReocrd INT
	DECLARE @LastReocrd INT
	DECLARE @TotalRecord INT

	SET @FirstReocrd = (@CurrentPage-1)*@PageSize + 1
	SET @LastReocrd =(@CurrentPage-1)*@PageSize + @PageSize

	CREATE TABLE #tempStudentSearch
	(
	 RN BIGINT,
     Id BIGINT,
	 FirstName nvarchar(max),
	 LastName nvarchar(max),
	 Address nvarchar(max),
	 Country int,
    State int,
    City int,
	 [IsActive] BIT,
	 PhnNo nvarchar(max),
	Email nvarchar(max),
	 DOB nvarchar(max),
	 Gender nvarchar(max),
	 SName   nvarchar(max),
    CityName nvarchar(max) ,
	Btech bit,
	Bsc bit,
	Bca bit,
	Ba bit
		)

	INSERT INTO #tempStudentSearch
	SELECT 
	ROW_NUMBER() OVER (ORDER BY c.Id DESC)
	RN,
	 c.Id,
	 c.FirstName ,
	 c.LastName,
	 c.Address,
	 c.Country,
     c.State ,
   c.City,
	 c.[IsActive],
	 c.PhnNo ,
	 c.Email,
	 c.DOB,
	 c.Gender,
	 s.SName,
	 ci.Name AS CityName,
	 c.Btech,
	 c.Bsc,
	 c.Bca,
	 c.Ba
	 FROM Students  c
	 INNER JOIN States s ON s.ID = c.State
     INNER JOIN Cities ci ON ci.Id = c.City 
	   WHERE
	 c.Id=CASE
	  WHEN @ID IS NULL OR @ID=0 THEN c.Id ELSE @ID 
	 END
   AND
  (@FirstName IS NULL or c.FirstName like '%'+@FirstName+'%')
 

	SELECT 
	t.RN,
	 t.Id,
	 t.FirstName ,
	 t.LastName,
	 t.Address,
	 t.Country,
   t.State ,
t.City,
	 t.[IsActive],
	 t.PhnNo ,
     t.Email,
	 t.DOB,
	t.Gender,
	t.SName,
	t.CityName,
	t.Btech,
	t.Bsc,
	t.Bca,
	t.Ba
	FROM #tempStudentSearch t
	 WHERE 
	
    RN BETWEEN @FirstReocrd AND @LastReocrd
	AND t.IsActive=1
	
	SELECT  Count(*) TotalRecords FROM  #tempStudentSearch
	

	DROP TABLE #tempStudentSearch
END

GO
/****** Object:  StoredProcedure [dbo].[Student_Update]    Script Date: 7/1/2017 1:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Student_Update]
(
   @ID Int,
   @FirstName NVARCHAR(MAX),
   @LASTNAME  NVARCHAR(MAX),
   @ADDRESS NVARCHAR(MAX),
   @IsActive Bit,
   @Country int,
   @City NVARCHAR(MAX),

   @State NVARCHAR(MAX),
   @Email NVARCHAR(MAX),
   @PhnNo NVARCHAR(MAX),
   @DOB NVARCHAR(MAX),
   @Gender NVARCHAR(MAX),
   @Btech Bit,
   @Bsc Bit,
   @Bca Bit,
   @Ba Bit
  
)
AS

UPDATE [dbo].[Students]
   SET [FirstName] = @FirstName,
       [LastName] = @LASTNAME,
       [Address] = @ADDRESS,
	   [IsActive] = @IsActive,
	   [Country] = @Country, 
	   [City] = @City,
	   [State] = @State,
	   [Email] = @Email,
	   [PhnNo] = @PhnNo,
	   [DOB] = @DOB,
	   [Gender] = @Gender,
	   [Btech] = @Btech,
	   [Bsc] = @Bsc,
	   [Bca] = @Bsc,
	   [Ba] = @Ba
  WHERE ID = @Id

 




GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 7/1/2017 1:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 7/1/2017 1:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[SId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 7/1/2017 1:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[States]    Script Date: 7/1/2017 1:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.States] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 7/1/2017 1:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[City] [int] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[PhnNo] [nvarchar](max) NULL,
	[DOB] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Btech] [bit] NOT NULL,
	[Bsc] [bit] NOT NULL,
	[Bca] [bit] NOT NULL,
	[Ba] [bit] NOT NULL,
	[State] [int] NOT NULL,
	[LogoUrl] [nvarchar](max) NULL,
	[Country] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT ((0)) FOR [Btech]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT ((0)) FOR [Bsc]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT ((0)) FOR [Bca]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT ((0)) FOR [Ba]
GO
