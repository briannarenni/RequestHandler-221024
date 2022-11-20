-- When a new ticket is submitted by an employee:
    -- Ticket should be added to table with:
    -- currUser.userId = submitted_by
    -- Ticket.amount = amount
    -- Ticket.category = category

-- Managers should be able to go through View.PendingTickets
-- and approve/deny to update status = 'choice'

INSERT INTO [Ticket] ([submitted_on], [submitted_by], [status], [amount], [category])
VALUES ('MaryJane', DEFAULT, 'pending', 140.00, 'Lodging')

INSERT INTO [Ticket] ([submitted_by], [amount], [category])
VALUES ('BriannaRenni', 'pending', 140.00, 'Lodging')

UPDATE [Ticket]
SET [status] = 'approved'
WHERE ticket_id = 102

DELETE FROM [Ticket]
WHERE username = 'Employee1'