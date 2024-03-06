CREATE TABLE [dbo].[Firefighters] (
    [FirefighterID]  INT            NOT NULL,
    [Name]           NVARCHAR (255) NOT NULL,
    [Rank]           NVARCHAR (255) NOT NULL,
    [ShiftID]        INT            NULL,
    [ShiftStartDate] DATETIME       NULL,
    [EndDate]        DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([FirefighterID] ASC)
);

