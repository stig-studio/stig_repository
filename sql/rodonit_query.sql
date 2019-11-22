
	use RodonitCnrKSK
	 
	declare @date_of_totals datetime2( 3 )
	declare @stock varbinary( 16 )
	declare @on_date datetime2( 3 )

	set @date_of_totals = '5999-11-01 00:00:00';	
	select @stock = s._IDRRef from dbo._Reference54 s where s._Fld792 = '   1OA   '
	set @on_date = '4018-11-19 23:59:59'

	select T5._Code code, T5._Description prod_name, T1.Fld2877Balance_ quantity		
	from (
		select T2.Fld2875RRef  Fld2875RRef, T2.Fld2874RRef Fld2874RRef,
		cast( sum( T2.Fld2877Balance_ ) as numeric( 38, 8 ) ) Fld2877Balance_		
		from (
			select T3._Fld2875RRef Fld2875RRef, T3._Fld2874RRef Fld2874RRef,
			cast( sum( T3._Fld2877 ) as numeric( 32, 8 ) ) as Fld2877Balance_
	from dbo._AccumRgT2881 T3 with( nolock )
	where T3._Period = @date_of_totals and T3._Fld2874RRef = @stock
	group by T3._Fld2874RRef, T3._Fld2875RRef
	having ( cast( sum( T3._Fld2877 ) as numeric( 32, 8 ) ) ) <> 0
	--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	union all		
	select T4._Fld2875RRef Fld2875RRef, T4._Fld2874RRef Fld2874RRef,
	cast( cast( sum( case when T4._RecordKind = 0.0 then -T4._Fld2877 else T4._Fld2877 end ) as numeric( 26, 8 ) ) as numeric( 27, 3 ) ) Fld2877Balance_
	from dbo._AccumRg2873 T4 with( nolock )
	where T4._Period >= @on_date and T4._Period < @date_of_totals and T4._Active = 0x01 and T4._Fld2874RRef = @stock
	group by T4._Fld2875RRef, T4._Fld2874RRef
	having ( cast( cast( sum( case when T4._RecordKind = 0 then -T4._Fld2877 else T4._Fld2877 end ) as numeric( 26, 8 ) ) as numeric( 27, 3 ) ) ) <> 0 ) T2
	group by T2.Fld2875RRef, T2.Fld2874RRef
	having ( cast( sum( T2.Fld2877Balance_ ) as numeric( 38, 8 ) ) ) <> 0 ) T1	
	left outer join dbo._Reference45 T5 with( nolock ) on T1.Fld2875RRef = T5._IDRRef
	order by t5._Description asc