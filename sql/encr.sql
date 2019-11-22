--select sysservers.srvname, syslnklgns.name, syslnklgns.pwdhash
--from master.sys.syslnklgns
--inner join
--master.sys.sysservers on syslnklgns.srvid = sysservers.srvid
--where len( pwdhash ) > 0

select * from master.sys.key_encryptions