update Rooms 
set User2 = 0, User1 = 0
where Id < 20;
select * from Rooms

insert into Rooms values (0, 0), (0, 0),(0, 0)

DBCC CHECKIDENT ('Rooms', RESEED, 0);