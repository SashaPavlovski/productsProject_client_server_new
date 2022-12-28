select * into NewProducts from [dbo].[Products]





delete from newProducts where [ProductID] =  @productID 

--select * from NewProducts

drop table [dbo].[newProducts]

--*********************************************************************************************
select * from [dbo].[NewProducts]

declare @productID int = 8,@ProductName nvarchar = 6,
@SupplierID int = 2,
@CategoryID int = 3,
@QuantityPerUnit nvarchar = 8,
@UnitPrice money = 6,
@UnitsInStock smallint = 5,
@UnitsOnOrder smallint = 3,
@ReorderLevel smallint = 2,
@Discontinued bit = 1

update [dbo].[NewProducts] set [ProductName] = @ProductName ,
[UnitPrice] = @UnitPrice, [UnitsInStock] = @UnitsInStock where [ProductID] =  @productID 