CREATE TRIGGER trDeletedViewers
ON [dbo].[Viewer]
After DELETE
AS
BEGIN
    insert into Viewer(Id)
    select d.Id, d.Phone, d.BirthDate, d.Email, d.[Name]
    from inserted  i join deleted d on i.Id=d.Id

END if; 
end