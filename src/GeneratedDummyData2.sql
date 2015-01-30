declare @oId table (Id int)
declare @uId1 varchar(max) = '20c02404-b45a-4cb5-909d-319be0f486d0',
@uId2 varchar(max) = 'f3418060-c47a-44fb-a4fd-27aa7b69b3a0'

/*
insert into dbo.Orders
(
	Quantity ,
    TotalPrice ,
    OrderDate ,
    DeliveryDate ,
    CreatedOn ,
    CreatedBy ,
    UpdatedOn ,
    UpdatedBy ,
    Status ,
    ApplicationUserId
)
output Inserted.Id
into @oId(Id)
values
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId2 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId2 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId2 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId2 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId2 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId2 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId2 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId2 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId1 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId1 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId1 ),
( 1 , 4800.0 ,getdate() , getdate(), getdate() , N'' , getdate() , N'' , 1 , @uId1 )
*/

insert into dbo.OrderProducts ( Order_Id, Product_Id )
select Id, Id + 2
from @oId

declare @wIds table (Id int)

insert into dbo.UserWishlists ( ApplicationUserId )
output Inserted.Id
into @wIds(Id)
values ( @uId1), (@uId2)

update dbo.Products
set UserWishlistId = 1
where Id <= 18


update dbo.Products
set UserWishlistId = 2
where Id > 18