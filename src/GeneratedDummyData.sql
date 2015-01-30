declare @catIds table (Id int)

set identity_insert dbo.Categories on
insert into dbo.Categories (Id, Name , Description , ParentId , CreatedOn , CreatedBy , UpdatedOn , UpdatedBy , Status )
values  
(0, N'All',N'All Catgories' ,null ,getdate() ,N'Ibnoon',getdate(),N'', 1)
set identity_insert dbo.Categories off

insert into dbo.Categories ( Name , Description , ParentId , CreatedOn , CreatedBy , UpdatedOn , UpdatedBy , Status )
output Inserted.Id
into @catIds(Id)
values
( N'Fridge',N'Refrigerator' ,0 ,getdate() ,N'Ibnoon',getdate(),N'', 1),
( N'Mobile',N'CellPhone' ,0 ,getdate() ,N'Ibnoon',getdate(),N'', 1),
( N'Washing Machine',N'Machines' ,0 ,getdate() ,N'Ibnoon',getdate(),N'', 1),
( N'Stapler',N'Acessories' ,0 ,getdate() ,N'Ibnoon',getdate(),N'', 1),
( N'TV',N'Television' ,0 ,getdate() ,N'Ibnoon',getdate(),N'', 1)

select *
from @catIds

insert into dbo.CategoryProperties ( Name, IsMandatory, CategoryId )
select n.Name , 1, Id
from
(
	select  N'CFT' as Name
	union all
	select  N'Screen size' as Name
	union all
	select  N'Voulme' as Name
) n
cross join @catIds

declare @pIds table (Id int)
declare @uId1 varchar(max) = '20c02404-b45a-4cb5-909d-319be0f486d0',
@uId2 varchar(max) = 'f3418060-c47a-44fb-a4fd-27aa7b69b3a0'

insert into dbo.Products
        ( Name ,
          Description ,
          NumberOfUnits ,
          CategoryId ,
          CreatedOn ,
          CreatedBy ,
          UpdatedOn ,
          UpdatedBy ,
          Status ,
          ApplicationUserId ,
          UnitPrice ,
          Discount ,
          DiscountValidity ,
          ImagePaths
        )
output Inserted.Id
into @pIds(Id) 
values
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId1 , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,@uId2 , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg')

