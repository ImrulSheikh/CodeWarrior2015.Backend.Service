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
		  PostedUserId,
          PostedBy_Id ,
          UnitPrice ,
          Discount ,
          DiscountValidity ,
          ImagePaths
        )
output Inserted.Id
into @pIds(Id) 
values
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'Samsung fridge', N'', 1 ,3 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'317f7abb-5660-4e77-a7ce-9148e49173ad' , 4800.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg'),
( N'NVIDIA Gear W130', N'', 1 ,2 , getdate() , N'Ibnoon' , getdate() , N'',1,1,N'f19a418b-34e7-4f76-81ad-057d39ae6ce5' , 1000.0 ,50.0 ,'2016-01-01' ,N'contents/uploads/001.jpg')

