CREATE TABLE [dbo].[Lesson]
(
	[LessonID] INT IDENTITY (1, 1) NOT NULL,
    [TeacherID]			INT NOT NULL,
    [TimeslotID]		INT NOT NULL,
	[DayID]				INT NOT NULL,
	[Available]			BIT NULL,
	[SpotsTaken]		INT NULL,
    [Subject]			NVARCHAR (50) NULL,
	
    PRIMARY KEY CLUSTERED ([LessonID] ASC),
    CONSTRAINT [FK_dbo.Lesson_dbo.Teacher_TeacherID] FOREIGN KEY ([TeacherID]) 
        REFERENCES [dbo].[Teacher] ([TeacherID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Lesson_dbo.Timeslot_TimeslotID] FOREIGN KEY ([TimeslotID]) 
        REFERENCES [dbo].[Timeslot] ([TimeslotID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Lesson_dbo.Day_DayID] FOREIGN KEY ([DayID]) 
        REFERENCES [dbo].[Day] ([DayID]) ON DELETE CASCADE
)
