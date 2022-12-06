CREATE TABLE [dbo].[Booking] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [CreatedOn]         SMALLDATETIME   NOT NULL,
    [Name]              NVARCHAR(50)    NOT NULL,
    [Flexibility]       NVARCHAR(10)    NOT NULL,
    [VehicleSize]       NVARCHAR(10)    NOT NULL,
    [ContactNumber]     NVARCHAR(20)    NOT NULL,
    [Email]             NVARCHAR(50)    NOT NULL,
    CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED ([Id] ASC)
);