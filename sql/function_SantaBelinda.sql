use SantaBelinda;

-- =====================================================================================	|
-- ������� 1.																				|
-- ������� ������� �� �������� ��������������� �� ��������									|
-- =====================================================================================   \|/
go
create function Select_occupant_by_surname(@var_name1 nvarchar(20), @var_name2 nvarchar(20))
returns table
as
return(
	select p.ID, p.Name, p.Surname
	from dbo.People p
	where p.Surname IN(@var_name1, @var_name2)
)

select * from Select_occupant_by_surname(N'������', N'����������')


-- ================================================================================================		|
-- ������� 2.																							|
-- ������� ������� �� �������� �� ���������� ������� � ������� ��������                					|
-- ================================================================================================    \|/
go
create function occupants_by_addr_and_by_interval( @var_surname1 nvarchar(20), 
@var_surname2 nvarchar(20), @var_addr nvarchar(30), @interval_from date, @interval_to date )
returns table
as
return (
	select ppl.ID, ppl.Surname, ppl.Name, ppl.Sex, ppl.DateOfBirth, ppl.DateD, ppl.Father, ppl.Mother
	from dbo.People as ppl
	inner join
	dbo.Occupant occp on occp.IdPeople = ppl.ID
	inner join
	dbo.House hs on hs.ID = occp.IdHouse
	where ppl.Surname IN( @var_surname1, @var_surname2 ) and hs.Addres = @var_addr and
	occp.DateIn between @interval_from and @interval_to
)

select * from occupants_by_addr_and_by_interval('���������', '����������', '��.��������, 8', '1985-01-01', getdate())


-- =====================================================================================	|
-- ������� 3.																				|
-- ������� ���������� ���������������� ( ��������  ���� ),									|
-- ������� ����� � ����� ������������ �������  ������� ����,								|
-- �������, ����������� � ������������ ���������� �������.									|
-- =====================================================================================   \|/
go
create function count_bussinessman(@var_sex int)
returns table
as
return(
	select count(bs.IdPeople) as [���������� ����������������],
	avg(bs.Workmans) as [������� �-�� �������],
	min(bs.Workmans) as [����������� �-�� �������],
	max(bs.Workmans) as [������������ �-�� �������]
	from dbo.BusinessMans bs
	inner join
	dbo.People ppl on ppl.ID = bs.IdPeople
	where ppl.Sex = @var_sex
)

select * from count_bussinessman(0)


-- =====================================================================================	|
-- ������� 4.																				|
-- ������� ���������� �����, ����� ����� � ������� ������� ���� �������,					|
-- ������� �������� � ��������� ����														|
-- =====================================================================================   \|/
go
create function count_home_sum_area(@interval_from date, @interval_to date)
returns table
as
return(
	select count(hs.ID) as [�-�� �����], sum(hs.Area) as [����� �������],
	avg(hs.Area) as [������� �������]
	from dbo.House hs
	inner join
	dbo.Occupant occp on occp.IdHouse = hs.ID
	inner join
	dbo.People ppl on ppl.ID = occp.IdPeople
	where ppl.DateOfBirth >= @interval_from and ppl.DateOfBirth <= @interval_to
)

select * from count_home_sum_area('1900-01-01', '1999-12-31')


-- ================================================================================================		|
-- ������� 5.																							|
-- ������� �� �������� ������� ���� ������� ����������������.											|
-- ================================================================================================	   \|/

go
create function select_craft()
returns table
as
return(
	select crf.Name [�������], hs.Addres as [�����]
	from dbo.House hs
	inner join
	dbo.Occupant occp on occp.IdHouse = hs.ID
	inner join
	dbo.BusinessMans bm on bm.IdPeople = occp.IdPeople
	inner join
	dbo.Craft crf on crf.ID = bm.IdCraft
)

select * from select_craft()