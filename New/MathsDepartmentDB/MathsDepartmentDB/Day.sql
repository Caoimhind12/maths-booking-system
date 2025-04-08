CREATE TABLE [dbo].[Day]
(
	[DayID]     INT           IDENTITY (1, 1) NOT NULL,
    [Day]      NVARCHAR (12) NULL,

    PRIMARY KEY CLUSTERED ([DayID] ASC)
)
