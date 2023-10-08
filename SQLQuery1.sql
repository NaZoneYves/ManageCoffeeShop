use QuanLyQuanCafe
go

--Display menu of drink
select a.TypeOfDrink, a.NameDrink,  b.SizeOfDrink, b.PriceOfDrink
from PRODUCT_DRINK_1 a, PRODUCT_DRINK_2 b
where (a.TypeOfDrink = b.TypeOfDrink) 