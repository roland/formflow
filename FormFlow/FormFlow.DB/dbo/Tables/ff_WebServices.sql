CREATE TABLE [dbo].[ff_WebServices] (
    [ID]         UNIQUEIDENTIFIER NOT NULL,
    [WsdlUrl]    VARCHAR (1024)   NULL,
    [CachedWsdl] VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_ff_WebServices] PRIMARY KEY CLUSTERED ([ID] ASC)
);

