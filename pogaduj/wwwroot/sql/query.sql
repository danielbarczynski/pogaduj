update Rooms 
set User2 = 0, User1 = 0
where Id = 1;
select * from Rooms

delete Rooms
insert into Rooms values (0, 0), (0, 0),(0, 0)

DBCC CHECKIDENT ('Rooms', RESEED, 0);