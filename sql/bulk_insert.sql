

create table #source( name nvarchar( 50 ) )

bulk insert
	#source
from
	'C:\Users\STIG\Downloads\subjects.txt' with ( datafiletype = 'widechar' );

insert into dbo.Subjects( name )
select distinct
	name
from #source
order by
	name

drop table #source

select * from dbo.Subjects