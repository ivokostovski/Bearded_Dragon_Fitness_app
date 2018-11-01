CREATE TABLE [dbo].[Trainers] (
    [TrainerId]      INT             IDENTITY (1, 1) NOT NULL,
    [FullName]       NVARCHAR (50)   NOT NULL,
    [Phone]          NVARCHAR (MAX)  NOT NULL,
    [Email]          NVARCHAR (200)  NOT NULL,
    [ShortBiography] NVARCHAR (1000) NULL,
    [ImagePath]      VARBINARY (MAX) NULL,
    [TrainingTypeId] INT             NULL,
    [ScheduleId]     INT             NULL,
    CONSTRAINT [PK_dbo.Trainers] PRIMARY KEY CLUSTERED ([TrainerId] ASC),
    CONSTRAINT [FK_dbo.Trainers_dbo.Schedules_ScheduleId] FOREIGN KEY ([ScheduleId]) REFERENCES [dbo].[Schedules] ([ScheduleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Trainers_dbo.TrainingTypes_TrainingTypeId] FOREIGN KEY ([TrainingTypeId]) REFERENCES [dbo].[TrainingTypes] ([TrainingTypeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TrainingTypeId]
    ON [dbo].[Trainers]([TrainingTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ScheduleId]
    ON [dbo].[Trainers]([ScheduleId] ASC);

