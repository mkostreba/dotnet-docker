-- <Migration ID="24924768-310a-4ed1-af9c-a2d986da8caa" />
GO

PRINT N'Creating [dbo].[TelephoneNumber]...';


GO
CREATE TABLE [dbo].[TelephoneNumber] (
    [Id]          INT           NOT NULL,
    [CountryCode] SMALLINT      NOT NULL,
    [AreaCode]    SMALLINT      NOT NULL,
    [Prefix]      SMALLINT      NOT NULL,
    [LineNumber]  SMALLINT      NOT NULL,
    [IsOnNet]     BIT           NOT NULL,
    [IsAssigned]  BIT           NOT NULL,
    [StringValue] NVARCHAR (20) NULL,
    [OwnedBy]     INT           NULL,
    [IsPorted]    BIT           NULL,
    CONSTRAINT [PK_TelephoneNumber] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[TelephoneNumber]...';


GO
ALTER TABLE [dbo].[TelephoneNumber]
    ADD CONSTRAINT [DF_TelephoneNumber_CountryCode] DEFAULT 1 FOR [CountryCode];


GO
PRINT N'Creating unnamed constraint on [dbo].[TelephoneNumber]...';


GO
ALTER TABLE [dbo].[TelephoneNumber]
    ADD CONSTRAINT [DF_TelephoneNumber_AreaCode] DEFAULT 000 FOR [AreaCode];


GO
PRINT N'Creating unnamed constraint on [dbo].[TelephoneNumber]...';


GO
ALTER TABLE [dbo].[TelephoneNumber]
    ADD CONSTRAINT [DF_TelephoneNumber_Prefix] DEFAULT 000 FOR [Prefix];


GO
PRINT N'Creating unnamed constraint on [dbo].[TelephoneNumber]...';


GO
ALTER TABLE [dbo].[TelephoneNumber]
    ADD CONSTRAINT [DF_TelephoneNumber_LineNumber] DEFAULT 0000 FOR [LineNumber];


GO
PRINT N'Creating unnamed constraint on [dbo].[TelephoneNumber]...';


GO
ALTER TABLE [dbo].[TelephoneNumber]
    ADD CONSTRAINT [DF_TelephoneNumber_IsOnNet] DEFAULT 1 FOR [IsOnNet];


GO
PRINT N'Creating unnamed constraint on [dbo].[TelephoneNumber]...';


GO
ALTER TABLE [dbo].[TelephoneNumber]
    ADD CONSTRAINT [DF_TelephoneNumber_IsAssigned] DEFAULT 0 FOR [IsAssigned];


GO
PRINT N'Creating [dbo].[FK_TelephoneNumber_ToNumberOwners]...';


GO
ALTER TABLE [dbo].[TelephoneNumber] WITH NOCHECK
    ADD CONSTRAINT [FK_TelephoneNumber_ToNumberOwners] FOREIGN KEY ([OwnedBy]) REFERENCES [dbo].[NumberOwners] ([Id]);

