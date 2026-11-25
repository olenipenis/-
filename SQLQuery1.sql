declare  @x int;
set @x =1;
print @x

print getdate()
print 'current date:' + getdate()
print concat(N'current date:' + getdate())

declare @n nvarchar(100);
select @n = name from Product
select @n

if year(getdate()) > 200
select N'XXI century'
else
select N'XX century'

declare @m int = 1;

while @m < 10
begin
	print @m;
	set @m +=1;
end;


