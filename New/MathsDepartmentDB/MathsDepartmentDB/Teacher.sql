CREATE TABLE [dbo].[Teacher] (
    [TeacherID]     INT           IDENTITY (1, 1) NOT NULL,
    [Forename]      NVARCHAR (50) NULL,
    [Surname]		NVARCHAR (50) NULL,
    [Email]			NVARCHAR (50) NULL,
    [TelNum]		NVARCHAR (50) NULL,
    [Room]			NVARCHAR (50) NULL,

    PRIMARY KEY CLUSTERED ([TeacherID] ASC)
)
