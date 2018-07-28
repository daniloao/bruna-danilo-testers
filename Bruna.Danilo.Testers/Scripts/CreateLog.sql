
CREATE TABLE [dbo].[LogType] (
    [Id] int IDENTITY(1,1) NOT NULL ,
    [Description] nvarchar(20)  NOT NULL ,
    CONSTRAINT [PK_LogType] PRIMARY KEY CLUSTERED (
        [Id] ASC
    )
)

CREATE TABLE [dbo].[Logs] (
    [Id] int IDENTITY(1,1) NOT NULL ,
    [LogTypeId] int  NOT NULL ,
    [Message] nvarchar(max)  NOT NULL ,
    [StackTrace] nvarchar(max)  NOT NULL ,
    [MoreInfo] nvarchar(max)  NOT NULL ,
    [UserId] nvarchar(450)  NULL ,
    [TimeStamp] datetime  NOT NULL ,
    [ParentLogId] int  NOT NULL ,
    CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED (
        [Id] ASC
    )
)
aLTER TABLE [dbo].[Logs] WITH CHECK ADD CONSTRAINT [FK_Logs_LogTypeId] FOREIGN KEY([LogTypeId])
REFERENCES [dbo].[LogTypes] ([Id])

ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_LogTypeId]

ALTER TABLE [dbo].[Logs] WITH CHECK ADD CONSTRAINT [FK_Logs_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])

ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_UserId]

ALTER TABLE [dbo].[Logs] WITH CHECK ADD CONSTRAINT [FK_Logs_ParentLogId] FOREIGN KEY([ParentLogId])
REFERENCES [dbo].[Logs] ([Id])

ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_ParentLogId]

CREATE INDEX [idx_Logs_TimeStamp]
ON [dbo].[Logs] ([TimeStamp])

insert into LogType values('Info')
insert into LogType values('Warning')
insert into LogType values('Error')

