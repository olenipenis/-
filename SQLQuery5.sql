CREATE TRIGGER trAfterUpdateProduct
ON [dbo].[Product]
after UPDATE
AS
BEGIN
    
    insert into PriceHistory(ProductId, OldPrice)
    select i.id, d.price
    from inserted  i join deleted d on i.Id=d.Id
    where i.Price <> d.Price;
END;
