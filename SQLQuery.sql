use QuanLyQuanCafe
go

select a.NameFood, a.TasteFood, b.PriceFood
from PRODUCT_FOOD_1 a, PRODUCT_FOOD_2 b
where (a.IDFood = b.IDFood) 

select a.NameDrink, b.TypeOfDrink, b.SizeOfDrink, b.PriceOfDrink
from PRODUCT_DRINK_1 a, PRODUCT_DRINK_2 b
where (a.TypeOfDrink = b.TypeOfDrink)
	and (a.IDDrink = 'CF02') and (b.SizeOfDrink = 'M')

select a.NameFood, a.TasteFood, b.PriceFood
from PRODUCT_FOOD_1 a, PRODUCT_FOOD_2 b, PRODUCT_FOOD_3 c
where (a.IDFood = b.IDFood) and (a.TasteFood = c.TasteFood)
	and ((a.IDFood = 'CR001') or (c.IDTaste = 'K002'))

