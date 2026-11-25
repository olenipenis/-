CREATE DEFINER=`ispp5502`@`%` TRIGGER `product_BEFORE_INSERT` BEFORE INSERT ON `product` FOR EACH ROW 
set new.Name=trim(new.Name);
 
 if new price is null then
 set new.price=0;
 end if;
 end