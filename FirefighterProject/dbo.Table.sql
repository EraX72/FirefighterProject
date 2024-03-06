CREATE TABLE [dbo].[User]
(
	[UserID]  INT            NOT NULL,
	[Username]           NVARCHAR (255) NOT NULL,
	[Password]           NVARCHAR (255) NOT NULL,
	PRIMARY KEY CLUSTERED ([FirefighterID] ASC),
	CONSTRAINT FK_Firefighters_Users FOREIGN KEY ([FirefighterID]) REFERENCES User([UserID])
)
