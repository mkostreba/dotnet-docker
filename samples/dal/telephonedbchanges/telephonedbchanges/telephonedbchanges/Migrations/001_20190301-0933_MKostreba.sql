-- <Migration ID="36adfb9f-8333-405f-96b7-3126ff6d85cd" />
GO

PRINT N'Creating [dbo].[NumberOwners]...';


GO
CREATE TABLE [dbo].[NumberOwners] (
    [Id]      INT           NOT NULL,
    [OwnerID] INT           NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_NumberOwners] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[NumberOwners]...';


GO
ALTER TABLE [dbo].[NumberOwners]
    ADD CONSTRAINT [DF_NumberOwners_Name] DEFAULT 'None' FOR [Name];


GO
PRINT N'Creating [dbo].[CK_NumberOwners_Column]...';


GO
ALTER TABLE [dbo].[NumberOwners] WITH NOCHECK
    ADD CONSTRAINT [CK_NumberOwners_Column] CHECK (1 = 1);

