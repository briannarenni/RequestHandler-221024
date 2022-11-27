SELECT * FROM [User] AS Users;
SELECT * FROM [Ticket] AS Tickets;
SELECT * FROM [View.PendingTickets] AS PendingTickets;

UPDATE [User]
SET [password] = 'test'
WHERE user_id = 11

INSERT INTO [User] ([username], [password])
VALUES ('AAdmin', 'test');
