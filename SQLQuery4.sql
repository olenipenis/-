CREATE TRIGGER trBeforeDeleteProduct
ON dbo.Product
instead of DELETE
AS
BEGIN

update product 
set IsDeleted = 1
where id in (select id
from deleted);

END;
