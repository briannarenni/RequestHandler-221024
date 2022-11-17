CREATE TABLE [dbo].[Tickets] (
    [ticket_id]    INT           IDENTITY (101, 1) NOT NULL,
    [submitted_on] DATE          DEFAULT (getdate()) NOT NULL,
    [submitted_by] VARCHAR (255) NULL,
    [status]       BIT           DEFAULT (NULL) NULL,
    [amount]       MONEY         NULL,
    [desc]         INT           NULL
);

CREATE TABLE [dbo].[User] (
    [user_id]         INT           IDENTITY (1, 2) NOT NULL,
    [username]        VARCHAR (50)  NULL,
    [password]        VARCHAR (255) NULL,
    [is_manager]      BIT           DEFAULT ((0)) NOT NULL,
    [pending_tickets] INT           NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([user_id] ASC)
);
