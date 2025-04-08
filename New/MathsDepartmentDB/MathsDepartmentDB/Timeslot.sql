CREATE TABLE [dbo].[Timeslot]
(
	[TimeslotID]     INT           IDENTITY (1, 1) NOT NULL,
    [Timeslot]      NVARCHAR (10) NULL,

    PRIMARY KEY CLUSTERED ([TimeslotID] ASC)
)
