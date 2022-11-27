SELECT * FROM [User]

SELECT * FROM [Ticket]

SELECT * FROM [View.PendingTickets]


-- SELECT [ticket_id], [submitted_on], [employee_name], [amount], [category], [status] FROM [Ticket] WHERE employee_name = 'BriannaRenni';

-- SELECT * FROM [Ticket]
-- ORDER BY [submitted_on] DESC;

-- SELECT * FROM [View.PendingTickets]
-- ORDER BY [submitted_on] DESC;

-- INSERT INTO [Ticket] ([submitted_by], [employee_name], [amount], [category])
-- VALUES (@userId, @username, @amount, @category);

-- UPDATE [Ticket]
-- SET
--    status = @status
-- WHERE ticket_id = @ticketId

-- UPDATE [User]
-- SET [password] = 'shaggy'
-- WHERE username = 'MaryJane'